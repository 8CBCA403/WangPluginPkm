using SysBot.Base;
using System.Linq;
using System.Text;

namespace USP.Core
{
    internal static class SysBotUtil
    {
        public static void Pointer(this SwitchSocketSync sSocket, ulong baseAddr, params uint[] offsets)
        {
            System.Diagnostics.Debug.WriteLine($"pointer 0x{baseAddr:X16} {string.Join(" ", offsets.Select(i => i.ToString())) }");
        }

        public static void PointerAll(this SwitchSocketSync sSocket, ulong baseAddr, params uint[] offsets)
        {
            System.Diagnostics.Debug.WriteLine($"pointerAll 0x{baseAddr:X16} {string.Join(" ", offsets.Select(i => i.ToString()))}");
        }
    }

    internal static class SwitchCommandExt
    {
        private static readonly Encoding Encoder = Encoding.ASCII;

        private static byte[] Encode(string command, bool crlf = true)
        {
            if (crlf)
                command += "\r\n";
            return Encoder.GetBytes(command);
        }

        public static byte[] Pointer(ulong baseAddr, params uint[] offsets) => Encode($"pointer 0x{baseAddr:X16} {string.Join(" ", offsets.Select(i => i.ToString()))}", true);

        public static byte[] PointerAll(ulong baseAddr, params uint[] offsets) => Encode($"pointerAll 0x{baseAddr:X16} {string.Join(" ", offsets.Select(i => i.ToString()))}", true);
        
        public static byte[] PointerPeek(ulong baseAddr, int count, params uint[] offsets) => Encode($"pointerPeek {count} 0x{baseAddr:X16} {string.Join(" ", offsets.Select(i => i.ToString()))}", true);
        
        public static byte[] PointerPoke(ulong baseAddr, byte[] data, params uint[] offsets) => Encode($"pointerPoke 0x{string.Concat(data.Select(z => $"{z:X2}"))} 0x{baseAddr:X16} {string.Join(" ", offsets.Select(i => i.ToString()))}", true);
    }
}
