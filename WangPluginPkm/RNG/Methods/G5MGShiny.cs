using PKHeX.Core;

namespace WangPluginPkm.RNG.Methods
{
    internal class G5MGShiny
    {
        public static uint Next(uint seed) => WangRandUtil.NextRand(seed);
        public static bool GenPkm(ref PKM pk, uint seed, CheckRules r)
        {
            var gv = seed >> 24;
            var av = seed & 1; // arbitrary choice
            pk.PID = GetMG5ShinyPID(gv, av, pk.TID16, pk.SID16);
            pk.SetRandomIVs();
            return true;
        }
        public static uint GetMG5ShinyPID(uint gval, uint av, int TID16, int SID16)
        {
            uint PID = (uint)((TID16 ^ SID16 ^ gval) << 16 | gval);
            if ((PID & 0x10000) != av << 16)
                PID ^= 0x10000;
            return PID;
        }

    }
}
