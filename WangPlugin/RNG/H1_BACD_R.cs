using PKHeX.Core;
using System;

namespace WangPlugin
{
    internal static class H1_BACD_R
    {
        private const int shift = 16;

        public static uint Next(uint seed) => PKHeX.Core.RNG.LCRNG.Next(seed);

        public static bool GenPkm( ref PKM pk,uint seed,int SID,int TID, bool[] shiny, bool[] IV)
        {
            var rng = PKHeX.Core.RNG.LCRNG;
            uint X = seed;
            var A = rng.Next(X);
            var B = rng.Next(A);
            var C = rng.Next(B);
            var D = rng.Next(C);
            pk.PID = (A & 0xFFFF0000) | B >> 16;
            if (!CheckShiny(pk.PID, pk.TID, pk.SID,shiny))
            {
                return false;
            }
            Span<int> IVs = stackalloc int[6];
            GetIVsInt32(IVs, C >> 16, D >> 16);
            if (IV[0] && IVs[1] != 0)
            {
                return false;
            }
            if (IV[1] && IVs[3] != 0)
            {
                return false;
            }
            pk.SetIVs(IVs);
            pk.Nature =(int)(pk.PID % 100% 25);
            pk.Ability = (int)pk.PID & 1;
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
        private static bool CheckShiny(uint pid, int TID, int SID, bool[] shiny)
        {
            var s = (uint)(TID ^ SID) ^ ((pid >> 16) ^ (pid & 0xFFFF));
            if (shiny[0])
                return true;
            else if (shiny[1] && s < 8)
                return true;
            else if (shiny[2] && s < 8 && s != 0)
                return true;
            else if (shiny[3] && s == 0)
                return true;
            else if (shiny[4] && s == 1)
                return true;
            else
                return false;
        }
    }
}