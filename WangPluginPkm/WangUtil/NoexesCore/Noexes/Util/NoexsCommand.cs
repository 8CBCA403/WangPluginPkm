using System;
using System.Collections.Generic;

namespace Noexes.Base
{
    internal static class NoexsCommand
    {
        private static List<byte> GetCommands(NoexsCommandsEnum cmd) => new() { (byte)cmd };

        public static byte[] Poke8(ulong address, byte value)
        {
            var cmd = GetCommands(NoexsCommandsEnum.Poke8);
            cmd.AddRange(BitConverter.GetBytes(address));
            cmd.AddRange(BitConverter.GetBytes((short)value));
            return cmd.ToArray();
        }

        public static byte[] Poke16(ulong address, short value)
        {
            var cmd = GetCommands(NoexsCommandsEnum.Poke16);
            cmd.AddRange(BitConverter.GetBytes(address));
            cmd.AddRange(BitConverter.GetBytes((short)value));
            return cmd.ToArray();
        }

        public static byte[] Poke32(ulong address, int value)
        {
            var cmd = GetCommands(NoexsCommandsEnum.Poke32);
            cmd.AddRange(BitConverter.GetBytes(address));
            cmd.AddRange(BitConverter.GetBytes(value));
            return cmd.ToArray();
        }

        public static byte[] Poke64(ulong address, long value)
        {
            var cmd = GetCommands(NoexsCommandsEnum.Poke64);
            cmd.AddRange(BitConverter.GetBytes(address));
            cmd.AddRange(BitConverter.GetBytes(value));
            return cmd.ToArray();
        }

        public static byte[] ReadMem(ulong offset, uint count)
        {
            var cmd = GetCommands(NoexsCommandsEnum.ReadMem);
            cmd.AddRange(BitConverter.GetBytes(offset));
            cmd.AddRange(BitConverter.GetBytes(count));
            return cmd.ToArray();
        }

        public static byte[] WriteMem(ulong offset, uint count)
        {
            var cmd = GetCommands(NoexsCommandsEnum.WriteMem);
            cmd.AddRange(BitConverter.GetBytes(offset));
            cmd.AddRange(BitConverter.GetBytes(count));
            return cmd.ToArray();
        }

        public static byte[] Resume()
        {
            return GetCommands(NoexsCommandsEnum.Resume).ToArray();
        }

        public static byte[] Pause()
        {
            return GetCommands(NoexsCommandsEnum.Pause).ToArray();
        }

        public static byte[] Attach(ulong pid)
        {
            var cmd = GetCommands(NoexsCommandsEnum.Attach);
            cmd.AddRange(BitConverter.GetBytes(pid));
            return cmd.ToArray();
        }

        public static byte[] Detach()
        {
            return GetCommands(NoexsCommandsEnum.Detach).ToArray();
        }

        public static byte[] QueryMulti(long start, int max)
        {
            var cmd = GetCommands(NoexsCommandsEnum.QueryMemMulti);
            cmd.AddRange(BitConverter.GetBytes(start));
            cmd.AddRange(BitConverter.GetBytes(max));
            return cmd.ToArray();
        }

        public static byte[] CurrentPid()
        {
            return GetCommands(NoexsCommandsEnum.CurrentPid).ToArray();
        }

        public static byte[] AttachedPid()
        {
            return GetCommands(NoexsCommandsEnum.AttachedPid).ToArray();
        }

        public static byte[] ListPids()
        {
            return GetCommands(NoexsCommandsEnum.ListPids).ToArray();
        }

        public static byte[] GetTitleID(ulong pid)
        {
            var cmd = GetCommands(NoexsCommandsEnum.GetTitleId);
            cmd.AddRange(BitConverter.GetBytes(pid));
            return cmd.ToArray();
        }

        public static byte[] Disconnect_Noexs()
        {
            return GetCommands(NoexsCommandsEnum.Disconnect).ToArray();
        }

        /// <summary>
        /// extra cmd
        /// </summary>
        public static byte[] SearchLocal(ulong start, ulong end, ulong value1, ulong value2, uint searchsize, uint searchtype = 0)
        {
            var cmd = GetCommands(NoexsCommandsEnum.SearchLocal);
            cmd.AddRange(BitConverter.GetBytes(start));
            cmd.AddRange(BitConverter.GetBytes(end));
            cmd.AddRange(BitConverter.GetBytes(value1));
            cmd.AddRange(BitConverter.GetBytes(value2));
            cmd.AddRange(BitConverter.GetBytes(searchsize));
            cmd.AddRange(BitConverter.GetBytes(searchtype));
            return cmd.ToArray();
        }
    }

    internal enum NoexsCommandsEnum : byte
    {
        Abort = 0x00,

        Status = 0x01,
        Poke8 = 0x02,
        Poke16 = 0x03,
        Poke32 = 0x04,
        Poke64 = 0x05,

        ReadMem = 0x06,
        WriteMem = 0x07,
        Resume = 0x08,
        Pause = 0x09,
        Attach = 0x0A,
        Detach = 0x0B,
        QueryMemSingle = 0x0C,
        QueryMemMulti = 0x0D,
        CurrentPid = 0x0E,
        AttachedPid = 0x0F,
        ListPids = 0x10,
        GetTitleId = 0x11,
        Disconnect = 0x12,
        ReadMemMulti = 0x13,
        SetBreakpoint = 0x14,
        // extra
        FreezeAddress = 0x15,
        SearchLocal = 0x16,
        FetchResult = 0x17,
        DetachDmnt = 0x18,
        DumpPtr = 0x19,
        AttachDmnt = 0x1A,
        GetBookmark = 0x1B,
        PutBookmark = 0x1C,
        DmntResume = 0x1D,
        ResolvePointers = 0x1E
    }
}
