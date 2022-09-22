using PKHeX.Core;
using System;

namespace WangPlugin
{
    internal static class H1_BACD_R
    {
        private const int shift = 16;

        public static uint Next(uint seed) => LCRNG.Next(seed);

        public static bool GenPkm( ref PKM pk,uint seed, CheckRules r)
        {
            
            uint X = seed;
            var A = LCRNG.Next(X);
            var B = LCRNG.Next(A);
            var C = LCRNG.Next(B);
            var D = LCRNG.Next(C);
            pk.PID = (A & 0xFFFF0000) | B >> 16;
            if (!r.CheckShiny(r, pk))
            {
                return false;
            }
            Span<int> IVs = stackalloc int[6];
            GetIVsInt32(IVs, C >> 16, D >> 16);
            if (!r.CheckIV(r, pk))
            {
                return false;
            }
            pk.SetIVs(IVs);
            pk.Nature =(int)(pk.PID % 100% 25);
            pk.Ability = (int)pk.PID & 1;
            pk.Gender = GenderApplicator.GetSaneGender(pk);
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