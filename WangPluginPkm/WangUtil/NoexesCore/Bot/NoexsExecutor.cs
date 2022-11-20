using Noexes.Base;
using PKHeX.Core;
using SysBot.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NoexesCore
{
    public abstract class NoexsExecutor<T> : IExecutor, IRAMEditor where T : class, INoexsBotConfig
    {
        public readonly INoexsConnectionSync Connection;
        public readonly T Config;

        protected NoexsExecutor(IConsoleBotConnector<INoexsConnectionSync, INoexsConnectionSync> cfg)
        {
            Config = (T)cfg;
            Connection = cfg.CreateSync();
        }

        public void Run()
        {
            Connection.Connect();
        }

        public IEnumerable<ulong> ListPids() => Connection.GetPids().OrderByDescending(i=>i);

        public ulong TitleIdPid(ulong pid) => Connection.GetTitleIdFromPid(pid);

        public void Attach(ulong pid)
        {
            var result = Connection.Attach(pid);
            if (result == 0)
            {
                Connection.Resume();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"[Attach] code {result}");
                Connection.Disconnect();
                throw new System.Exception($"err code: {result}");
            }
        }

        public void Detach()
        {
            Connection.Detach();
        }

        public void ResumeProcess()
        {
            Connection.Resume();
        }

        public void PauseProcess()
        {
            Connection.Pause();
        }

        public ProcessInfo GetInfo()
        {
            return new ProcessInfo
            {
                MainBase = Connection.GetMainNsoBase(),
                HeepBase = Connection.GetHeapBase(),
                TitleId = Connection.GetTitleID(),
                BuildId = Connection.GetBuildID()
            };
        }

        public byte[] Read(uint offset, int length) => Connection.ReadBytes(offset, length);
        public byte[] ReadMain(ulong offset, int length) => Connection.ReadBytesMain(offset, length);
        public byte[] ReadAbsolute(ulong offset, int length) => Connection.ReadBytesAbsolute(offset, length);
        public void Write(byte[] data, uint offset) => Connection.WriteBytes(data, offset);
        public void WriteMain(byte[] data, ulong offset) => Connection.WriteBytesMain(data, offset);
        public void WriteAbsolute(byte[] data, ulong offset) => Connection.WriteBytesAbsolute(data, offset);

        public ulong GetPointer(string evalStr)
        {
            var vars = new Dictionary<string, ulong>() { { "main", Connection.GetMainNsoBase() }, { "heap", Connection.GetHeapBase() } };
            var Eval = new ExpressionEvaluator(vars, (ulong addr) => {
                var data = Connection.ReadBytesAbsolute(addr, 0x8);
                return BitConverter.ToUInt64(data,0);
            });
            return Eval.Eval(evalStr);
        }
        public ulong GetPointerAddress( string ptr, bool heaprealtive = true)
        {
            if (string.IsNullOrWhiteSpace(ptr) || ptr.IndexOfAny(new[] { '-', '/', '*' }) != -1)
                return 0;
            while (ptr.Contains("]]"))
                ptr = ptr.Replace("]]", "]+0]");
            uint? finadd = null;
           
            if (!ptr.EndsWith("]"))
            {
                finadd = Util.GetHexValue(ptr.Split('+').Last());
                ptr = ptr[..ptr.LastIndexOf('+')];
            }
            var jumps = ptr.Replace("main", "").Replace("[", "").Replace("]", "").Split(new[] { "+" }, StringSplitOptions.RemoveEmptyEntries);
            
            if (jumps.Length == 0)
                return 0;
           
            var initaddress = Util.GetHexValue(jumps[0].Trim());
            ulong address = BitConverter.ToUInt64(Connection.ReadBytesMain(initaddress, 0x8), 0);
            
            foreach (var j in jumps)
            {
                var val = Util.GetHexValue(j.Trim());
                if (val == initaddress)
                    continue;
                address = BitConverter.ToUInt64(Connection.ReadBytesAbsolute(address + val, 0x8), 0);
            }
            if (finadd != null) address += (ulong)finadd;
            if (heaprealtive)
            {
                ulong heap = Connection.GetHeapBase();
                address -= heap;
            }
            return address;
        }
    }
}
