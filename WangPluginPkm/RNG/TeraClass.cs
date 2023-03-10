using PKHeX.Core;

namespace WangPluginPkm.RNG
{
    public class TeraClass
    {
        public uint EC { get;set; }
        public uint PID { get;set; }
        public int[] ivs { get; set; }
        public int ability { get; set; }

        public int gender { get; set; }
        public byte nature { get; set; }    
        public int Height { get; set; }
        public int Weight { get; set; }

        public int Size { get; set; }

    }
}
