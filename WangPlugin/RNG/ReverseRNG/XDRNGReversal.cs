using System;
using PKHeX.Core;
using System.Runtime.CompilerServices;
namespace WangPlugin
{
    internal class XDRNGReversal
    {
        public const uint Mult = 0x000343FD;
        public const uint Add = 0x00269EC3;
        public const uint rMult = 0xB9B33155;
        public const uint rAdd = 0xA170F641;
        private const uint Sub = Add - 0xFFFF;
        private const ulong Base = (Mult + 1ul) * 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static uint Prev(uint seed) => (seed * rMult) + rAdd;
       

        public static int GetSeeds(Span<uint> result, uint pid)
        {
            uint first = pid & 0xFFFF_0000;
            uint second = pid << 16;
            return GetSeeds(result, first, second);
        }
        public static int GetSeeds(Span<uint> result, uint first, uint second)
        {
            ulong t = second - (first * Mult) - Sub;
            ulong kmax = (Base - t) >> 32;
            int ctr = 0;
            for (ulong k = 0; k <= kmax; k++, t += 0x1_0000_0000) // at most 4 iterations
            {
                if (t % Mult < 0x1_0000)
                    result[ctr++] = Prev(first | (ushort)(t / Mult));
            }
            return ctr;
        }
        public static int GetSeeds(Span<uint> result, uint hp, uint atk, uint def, uint spa, uint spd, uint spe)
        {
            var first = (hp | (atk << 5) | (def << 10)) << 16;
            var second = (spe | (spa << 5) | (spd << 10)) << 16;
            return GetSeedsIVs(result, first, second);
        }

        public static int GetSeedsIVs(Span<uint> result, uint first, uint second)
        {
            ulong t = (second - (first * Mult) - Sub) & 0x7FFF_FFFF;
            ulong kmax = (Base - t) >> 31;

            int ctr = 0;
            for (ulong k = 0; k <= kmax; k++, t += 0x8000_0000) // at most 7 iterations
            {
                if (t % Mult < 0x1_0000)
                {
                    var s = Prev(first | (ushort)(t / Mult));
                    result[ctr++] = s;
                    result[ctr++] = s ^ 0x8000_0000; // top bit flip
                }
            }
            return ctr;
        }
        public static int[] SetValuesFromSeedXDRNG(PKM pk, uint seed)
        {
            switch (pk.Species)
            {
                case (int)Species.Umbreon or (int)Species.Eevee: // Colo Umbreon, XD Eevee
                    pk.TID = (int)((seed = XDRNG.Next(seed)) >> 16);
                    pk.SID = (int)((seed = XDRNG.Next(seed)) >> 16);
                    seed = XDRNG.Next2(seed); // PID calls consumed
                    break;
                case (int)Species.Espeon: // Colo Espeon
                    pk.TID = (int)((seed = XDRNG.Next(seed)) >> 16);
                    pk.SID = (int)((seed = XDRNG.Next(seed)) >> 16);
                    seed = XDRNG.Next9(seed); // PID calls consumed, skip over Umbreon
                    break;
            }
            var A = XDRNG.Next(seed); // IV1
            var B = XDRNG.Next(A); // IV2
            var C = XDRNG.Next(B); // Ability?
            var D = XDRNG.Next(C); // PID
            var E = XDRNG.Next(D); // PID

            pk.PID = (D & 0xFFFF0000) | (E >> 16);
            Span<int> IVs = stackalloc int[6];
            GetIVsInt32(IVs, A >> 16, B >> 16);
            pk.SetIVs(IVs);
            var r = IVs.ToArray();
            return r;
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
