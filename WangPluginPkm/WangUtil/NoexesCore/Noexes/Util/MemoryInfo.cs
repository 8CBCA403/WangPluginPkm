using System.IO;

namespace Noexes.Base
{
    public record MemoryInfo
    {
        public static int InfoSize = 24;

        public ulong Address { get; init; } = ulong.MinValue;
        public ulong Size { get; init; } = ulong.MinValue;
        public MemoryType Type { get; init; } = uint.MinValue;
        public int Perm { get; init; } = int.MinValue;

        public ulong NextAddress => Address + Size;

        public bool isReadable()
        {
            return (Perm & 1) != 0;
        }

        public bool isWriteable()
        {
            return (Perm & 2) != 0;
        }

        public bool isExecutable()
        {
            return (Perm & 4) != 0;
        }

        public bool contains(ulong addr)
        {
            return Address <= addr && NextAddress > addr;
        }

        public MemoryInfo(byte[] data)
        {
            var bi = new BinaryReader(new MemoryStream(data));
            Address = bi.ReadUInt64();
            Size = bi.ReadUInt64();
            Type = (MemoryType)bi.ReadInt32();
            Perm = bi.ReadInt32();
        }

        public MemoryInfo(long addr, long size, int type, int perm)
        {
            this.Address = (ulong)addr;
            this.Size = (ulong)size;
            this.Type = (MemoryType)(type);
            this.Perm = perm;
        }
    }

    public enum MemoryType : uint
    {
        UNMAPPED = 0,
        IO = 0x01,
        NORMAL = 0x02,
        CODE_STATIC = 0x03,
        CODE_MUTABLE = 0x04,
        HEAP = 0x05,
        SHARED = 0x06,
        WEIRD_MAPPED = 0x07,
        MODULE_CODE_STATIC = 0x08,
        MODULE_CODE_MUTABLE = 0x09,
        IPC_BUFFER_0 = 0x0A,
        MAPPED = 0xB,
        THREAD_LOCAL = 0x0C,
        ISOLATED_TRANSFER = 0x0D,
        TRANSFER = 0x0E,
        PROCESS = 0x0F,
        RESERVED = 0x10,
        IPC_BUFFER_1 = 0x11,
        IPB_BUFFER_3 = 0x12,
        KERNEL_STACH = 0x13,
        CODE_READ_ONLY = 0x14,
        CODE_WRITABLE = 0x15
    }
}
