using SysBot.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noexes.Base
{
    public sealed class NoexsSocketSync : NoexsSocket, INoexsConnectionSync
    {
        public NoexsSocketSync(IWirelessConnectionConfig cfg) : base(cfg) { }

        /// <summary>
        /// wrapper above
        /// </summary>
        int INoexsConnectionSync.Attach(ulong pid)
        {
            var result = Attach(pid);
            Log($"[PID] Attached pid: {AttachedPid()}");
            return result;
        }

        void INoexsConnectionSync.Resume() => Resume();

        void INoexsConnectionSync.Pause() => Pause();

        void INoexsConnectionSync.Detach() => Detach();

        private ulong Main_ = ulong.MinValue;
        private ulong Heap_ = ulong.MinValue;
        private const int FRAME = 5000;

        private void InitInfo()
        {
            var info = QueryMulti(0, FRAME);

            var ml = info.Where(m => m.Type == MemoryType.CODE_STATIC && m.Perm == 0b101).OrderBy(m => m.Address);
            var mainm = ml.LongCount() > 1 ? ml.Skip(1).First() : ml.FirstOrDefault();

            Main_ = mainm?.Address ?? ulong.MinValue;

            var heapm = info.Where(m => m.Type == MemoryType.HEAP).OrderBy(m => m.Address).FirstOrDefault();
            Heap_ = heapm?.Address ?? ulong.MinValue;
        }

        public ulong GetMainNsoBase()
        {
            if (Main_ == ulong.MinValue) InitInfo();
            return Main_;
        }

        public ulong GetHeapBase()
        {
            if (Heap_ == ulong.MinValue) InitInfo();
            return Heap_;
        }

        IEnumerable<ulong> INoexsConnectionSync.GetPids() => ListPids();

        ulong INoexsConnectionSync.GetTitleIdFromPid(ulong pid) => GetTitleId(pid);

        public ulong GetTitleID() => GetTitleId(AttachedPid());

        public ulong GetBuildID() => ulong.MaxValue;

        private byte[] ReadInternal(ulong offset, int length, SwitchOffsetType type)
        {
            return type switch
            {
                SwitchOffsetType.Heap => ReadMem(Heap_ + offset, length),
                SwitchOffsetType.Main => ReadMem(Main_ + offset, length),
                SwitchOffsetType.Absolute => ReadMem(offset, length),
                _ => throw new NotImplementedException(),
            };
        }

        public byte[] ReadBytes(uint offset, int length) => ReadInternal(offset, length, SwitchOffsetType.Heap);
        public byte[] ReadBytesMain(ulong offset, int length) => ReadInternal(offset,length,SwitchOffsetType.Main);
        public byte[] ReadBytesAbsolute(ulong offset, int length) => ReadInternal(offset, length, SwitchOffsetType.Absolute);
        public void WriteBytes(byte[] data, uint offset) => WriteMem(data, Heap_ + offset);
        public void WriteBytesMain(byte[] data, ulong offset) => WriteMem(data, Main_ + offset);
        public void WriteBytesAbsolute(byte[] data, ulong offset) => WriteMem(data, offset);
    }
}
