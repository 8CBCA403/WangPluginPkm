using System;
using System.Linq;
using PKHeX.Core;
namespace SysBotBase
{
    public static class InjectionUtil
    {
        public const ulong INVALID_PTR = 0;
        public static ulong GetPointerAddress(this ICommunicatorNX sb, string ptr, bool heaprealtive=true)
        {
            if (string.IsNullOrWhiteSpace(ptr) || ptr.IndexOfAny(new[] { '-', '/', '*' }) != -1)
                return INVALID_PTR;
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
                return INVALID_PTR;

            var initaddress = Util.GetHexValue(jumps[0].Trim());
            ulong address = BitConverter.ToUInt64(sb.ReadBytesMain(initaddress, 0x8), 0);
            foreach (var j in jumps)
            {
                var val = Util.GetHexValue(j.Trim());
                if (val == initaddress)
                    continue;
                address = BitConverter.ToUInt64(sb.ReadBytesAbsolute(address + val, 0x8), 0);
            }
            if (finadd != null) address += (ulong)finadd;
            if (heaprealtive)
            {
                ulong heap = sb.GetHeapBase();
                address -= heap;
            }
            return address;
        }

        public static string ExtendPointer(this string pointer, params uint[] jumps)
        {
            foreach (var jump in jumps)
                pointer = $"[{pointer}]+{jump:X}";
            return pointer;
        }
        public static byte[] ReadSlot(this SysBotMini psb, int box, int slot,string ptr)
        {
            var slotsize = 344;
            var b1s1 = psb.GetPointerAddress(ptr);
            var boxsize = 30 * slotsize;
            var boxstart = b1s1 + (ulong)(box * boxsize);
            var slotstart = boxstart + (ulong)(slot * slotsize);
            return psb.ReadBytes(slotstart, slotsize);
        }
        public static byte[] ReadPSlot(this SysBotMini psb,  string ptr)
        {
            var slotsize = 344;
            var offset = psb.GetPointerAddress(ptr);
            return psb.ReadBytes(offset, slotsize);
        }

        public static void SendSlot(this SysBotMini psb, byte[] data, int box, int slot, string ptr)
        {
            var slotsize = 344;
            var b1s1 = psb.GetPointerAddress(ptr);
            var boxsize = 30 * slotsize;
            var boxstart = b1s1 + (ulong)(box * boxsize);
            var slotstart = boxstart + (ulong)(slot * slotsize);
            psb.WriteBytes(data, slotstart);
        }
        public static void SendPSlot(this SysBotMini psb, byte[] data, string ptr)
        {
            var offset = psb.GetPointerAddress(ptr);
            psb.WriteBytes(data, offset);
        }

    }
}
