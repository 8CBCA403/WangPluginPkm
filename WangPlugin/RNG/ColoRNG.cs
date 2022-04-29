using PKHeX.Core;
using System;

namespace WangPlugin
{
    internal static class ColoRNG
    {
        private const int shift = 16;
        private const int shift8 = 8;

        public static uint Next(uint seed) => PKHeX.Core.RNG.XDRNG.Next(seed);

        public static bool GenPkm(ref PKM pk, uint seed, bool []shiny, bool[] IV)
        {
            var rng = PKHeX.Core.RNG.XDRNG;
           
                var O = rng.Next(seed); // SID
                var A = rng.Next(O); // PID
                var B = rng.Next(A); // PID
                var C = rng.Next(B); // Held Item
                var D = rng.Next(C); // Version
                var E = rng.Next(D); // OT Gender
                const int TID = 40122;
                var SID = (int)(O >> 16);
                var pid1 = A >> 16;
                var pid2 = B >> 16;
                pk.TID = TID;
                pk.SID = SID;
                var pid = pid1 << 16 | pid2;
                if ((pid2 > 7 ? 0 : 1) != (pid1 ^ SID ^ TID))
                    pid ^= 0x80000000;
                pk.PID = pid;
            if (!CheckShiny(pk.PID, pk.TID, pk.SID,shiny))
            {
                return false;
            }
                pk.HeldItem = (int)(C >> 31) + 169; 
                pk.Version = (int)(D >> 31) + 1; 
                pk.OT_Gender = (int)(E >> 31);
                Span<int> ivs = stackalloc int[6];
                rng.GetSequentialIVsInt32(E, ivs);
            if (IV[0] && ivs[1] != 0)
            {
                return false;
            }
            if (IV[1] && ivs[5] != 0)
            {
                return false;
            }
            pk.SetIVs(ivs);
                pk.Gender = PKX.GetGenderFromPID(pk.Species, pk.PID);
            return true;
        }

        private static void GetIVsInt32(Span<int> result, uint r1, uint r2)
        {
            result[5] = (((int)r2 >> 10) & 0x1F);
            result[4] = (((int)r2 >> 5) & 0x1F);
            result[3] = (int)(r2 & 0x1F);
            result[2] = (((int)r1 >> 10) & 0x1F);
            result[1] = (((int)r1 >> 5) & 0x1F);
            result[0] = (int)(r1 & 0x1F);
        }
        internal static void GetSequentialIVsInt32(this LCRNG rng, uint seed, Span<int> ivs)
        {
            for (int i = 0; i < 6; i++)
            {
                seed = rng.Next(seed);
                ivs[i] = (int)(seed >> 27);
            }
        }
        private static uint combineRNG(uint upper, uint lower, uint shift)
        {
            return (upper << (int)shift) + lower;
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