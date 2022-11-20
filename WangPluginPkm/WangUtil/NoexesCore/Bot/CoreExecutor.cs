using SysBot.Base;
using System;
using System.Collections.Generic;

namespace NoexesCore
{
    public abstract class CoreExecutor<T> : IExecutor, IRAMEditor where T : class, IConsoleBotConfig
    {
        public readonly ISwitchConnectionSync Connection;
        public readonly T Config;

        protected CoreExecutor(IConsoleBotManaged<ISwitchConnectionSync, ISwitchConnectionAsync> cfg)
        {
            Config = (T)cfg;
            Connection = cfg.CreateSync();
        }

        public void Run()
        {
            Connection.Connect();
        }

        public ProcessInfo GetInfo()
        {
            return new ProcessInfo{ MainBase = Connection.GetMainNsoBase(), HeepBase = Connection.GetHeapBase(),
                TitleId = Connection.GetTitleID(), BuildId = Connection.GetBuildID()
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
