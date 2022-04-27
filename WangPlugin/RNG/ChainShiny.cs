using PKHeX.Core;
using System;

namespace WangPlugin
{
    internal static class ChainShiny
    {
        private const int shift = 16;

        public static uint Next(uint seed) => RNG.LCRNG.Next(seed);

        public static bool GenPkm(ref PKM pk,uint seed, bool[] IV)
        {
            uint Next() => (seed = RNG.LCRNG.Next(seed)) >> 16;
            uint lower = Next() & 7;
            uint upper = Next() & 7;
            for (int i = 0; i < 13; i++)
                lower |= (Next() & 1) << (3 + i);
            upper = ((uint)(lower ^ pk.TID ^ pk.SID) & 0xFFF8) | (upper & 0x7);
            pk.PID = upper << 16 | lower;
            var pid = pk.PID;
            Span<int> IVs = stackalloc int[6];
            GetIVsInt32(IVs, Next(), Next());
            if (IV[0] && IVs[1] != 0)
            {
                return false;
            }
            if (IV[1] && IVs[3] != 0)
            {
                return false;
            }
            pk.Nature = (int)(pid % 100 % 25);
            pk.RefreshAbility((int)(pk.PID & 1));
            pk.SetIVs(IVs);
            pk.Gender = PKX.GetGenderFromPID(pk.Species, pk.PID);
            return true;
        }
        internal static void GetIVsInt32(Span<int> result, uint r1, uint r2)
        {
            result[5] = (int)r2 >> 10 & 31;
            result[4] = (int)r2 >> 5 & 31;
            result[3] = (int)r2 & 31;
            result[2] = (int)r1 >> 10 & 31;
            result[1] = (int)r1 >> 5 & 31;
            result[0] = (int)r1 & 31;
        }
       
    }
}