using PKHeX.Core;

namespace WangPluginPkm
{
    internal class WangRandUtil
    {
        public static uint GetShinyXor(uint val) => (val >> 16) ^ (val & 0xFFFF);
        public static uint GetShinyValue(uint num) => GetShinyXor(num) >> 4;
        public static uint GetShinyType(uint pid, uint TID16SID16)
        {
            var p = GetShinyXor(pid);
            var t = GetShinyXor(TID16SID16);
            if (p == t)
                return 2; // square;
            if ((p ^ t) < 0x10)
                return 1; // star
            return 0;
        }
        public static int GetNextShinyFrame(ulong seed)
        {
            var rng = new Xoroshiro128Plus(seed);
            for (int i = 0; ; i++)
            {
                uint _ = (uint)rng.NextInt(0xFFFFFFFF); // EC
                uint SID16TID16 = (uint)rng.NextInt(0xFFFFFFFF);
                uint PID = (uint)rng.NextInt(0xFFFFFFFF);
                var type = GetShinyType(PID, SID16TID16);
                if (type != 0)
                    return i;

                // Get the next seed, and reset for the next iteration
                rng = new Xoroshiro128Plus(seed);
                seed = rng.Next();
                rng = new Xoroshiro128Plus(seed);
            }
        }

        public static uint NextRand(uint seed)
        {
            var rnd = Util.Rand;
            return rnd.Rand32();
        }
    }
}
