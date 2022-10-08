using PKHeX.Core;
using System;

namespace WangPlugin.RNG.Methods
{
    internal static class BACD
    {
        private const int shift = 16;
        public static uint Next(uint seed) => LCRNG.Next(seed);
        public static bool GenPkm(ref PKM pk, uint seed, CheckRules r, int type)
        {
            bool shiny = type is 2;
            uint X = shiny ? LCRNG.Next(seed) : seed;
            var A = LCRNG.Next(X);
            var B = LCRNG.Next(A);
            var C = LCRNG.Next(B);
            var D = LCRNG.Next(C);
            if (shiny)
            {
                uint PID = X & 0xFFFF0000 | (uint)pk.SID ^ (uint)pk.TID ^ X >> 16;
                PID &= 0xFFFFFFF8;
                PID |= B >> 16 & 0x7; // lowest 3 bits

                pk.PID = PID;
            }
            else
            {
                pk.PID = A & 0xFFFF0000 | B >> 16;
            }
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
            pk.Nature = (int)(pk.PID % 100 % 25);
            pk.Ability = (int)pk.PID & 1;
            pk.Gender = pk.GetSaneGender();
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