using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WangPlugin
{
    internal class UnownRNG
    {
        private const int shift = 16;
        public static uint Next(uint seed) => PKHeX.Core.RNG.LCRNG.Next(seed);
        public static bool GenPkm(ref PKM pk, int type, uint seed, bool[] shiny, bool[] IV,byte f )
        {
            var FlawlessIVs = 0;
            uint MAX = 31;
            uint p = 0;
            var A = Next(seed);
            var B = Next(A);
           
            var swappedPIDHalves = type is >= 1 and <= 4;
            if (swappedPIDHalves) // switched order of PID halves, "BA.."
            {
                p = (A & 0xFFFF0000) | (B >> 16);
                pk.PID = p;
            }
           
            if (f != GetUnownForm3(p))
            {
                return false;
            }
            var C = Next(B);
            var skipIV1Frame = type is 2;
            if (skipIV1Frame) // VBlank skip after PID
                C = Next(C);

            var D = Next(C);
            var skipIV2Frame = type is 4;
            if (skipIV2Frame) // VBlank skip between IVs
                D = Next(D);
            Span<int> IVs = stackalloc int[6];
            GetIVsInt32(IVs, C >> 16, D >> 16);
           
            if (!CheckShiny(pk.PID, pk.TID, pk.SID, shiny))
            {
                return false;
            }
            if (IV[0] && IVs[1] != 0)
            {
                return false;
            }
            if (IV[1] && IVs[5] != 0)
            {
                return false;
            }
            pk.SetIVs(IVs);
            if (IV[2] == true)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (IVs[i] == MAX)
                        FlawlessIVs++;
                }
                if (FlawlessIVs is 3 or > 3)
                {
                    return true;
                }
                return false;
            }
            var Info = new LegalityAnalysis(pk);
            if (Info.Info.FrameMatches == false)
                return false;
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
        public static byte GetUnownForm3(uint pid)
        {
            var value = ((pid & 0x3000000) >> 18) | ((pid & 0x30000) >> 12) | ((pid & 0x300) >> 6) | (pid & 0x3);
            return (byte)(value % 28);
        }
       
       

    }
}
