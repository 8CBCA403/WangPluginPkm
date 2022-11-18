using Noexes.Base;
using SysBot.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace USP.Core
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
    }
}
