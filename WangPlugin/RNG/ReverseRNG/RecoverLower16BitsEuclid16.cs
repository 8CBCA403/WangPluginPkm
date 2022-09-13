using System;
using System.Collections.Generic;
using System.Linq;
using PKHeX.Core;
using System.Windows.Forms;
namespace WangPlugin
{
    internal class RecoverLower16BitsEuclid16
    {
        public static uint Mult = 0x000343FD;
        public static uint Add = 0x00269EC3;
        public static uint rMult = 0xB9B33155;
        public static uint rAdd = 0xA170F641;
        public static long t0 = Add - 0xFFFF;
        public static long t1 = 0xFFFF * ((long)Mult + 1);
        public static uint seed = Util.Rand32();
        
        internal static IEnumerable<uint> GetSeed(uint pid)
        {
            List<uint> list = new List<uint>();
            const int bitshift = 32;
            const long inc = 1L << bitshift;
            uint num = (pid >> 16) << 16;
            uint num2 = (pid & 0xFFFF) << 16;
            long num3 = num2 - (Mult * num) - t0;
            long num4 = 0u;
            long kmax = (((t1 - num3) >> bitshift) << bitshift) + num3;
            for ( num4 = num3; num4 <= kmax; num4 += inc)
            {
                // compute modulo in steps for reuse in yielded value (x % Mult)
                long fix = num4 / Mult;
                long remainder = num4 - (Mult * fix);
                if (remainder >> 16 == 0)
                {
                   uint num5 = num | (uint)fix;
                  //  if ((RNG.LCRNG.Advance(num5, 4) << 16) == num)
                    {
                        num5=(num5 * rMult) + rAdd;
                        // MessageBox.Show("ok");
                        list.Add(num5);
                    }
                }
                    //yield return Prev(first | (uint)fix);
             }
            
            return list;
        }
        public static List<uint[]> CalcPIDIVsByXDRNG(uint pid)
        {

            IEnumerable<uint> enumerable = GetSeed(pid);

            if (enumerable.Count() == 0)
            {

                return null;
            }
            List<uint[]> list = new List<uint[]>();
            using (IEnumerator<uint> enumerator = enumerable.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {

                    uint num = (seed = enumerator.Current);
                    var B = XDRNG.Prev(seed);
                    var A = XDRNG.Prev(B);

                    var hi = A >> 16;
                    var lo = B >> 16; ;
                    list.Add(GetIVs(hi, lo));
                   // MessageBox.Show($"{seed}");
                }
            }

            return list;
        }
        public static uint[] GetIVs(uint v1, uint v2)
        {
            return new uint[6]
            {
             (v1 & 0x1Fu),
             (v1 >> 5) & 0x1Fu,
             (v1 >> 10) & 0x1Fu,
             (v2 & 0x1Fu),
             (v2 >> 5) & 0x1Fu,
             (v2 >> 10) & 0x1Fu,
             };
        }
        public static uint[] GetIVs(PKM pkm, List<uint[]> ivsList)
        {
            uint[] result = new uint[6];
            if (ivsList.Count != 0)
            {
                result = ivsList.ElementAt(0);
            }
            return result;
        }

        public static void SetIVsFromList(PKM pkm, uint[] ivs)
        {
            int[] iVs = pkm.IVs;
            for (int i = 0; i < ivs.Length; i++)
            {
                iVs[i] = (int)ivs[i];
            }
            pkm.IVs = iVs;
        }
        public static void advance(uint advances)
        {
            for (uint num = 0u; num < advances; num++)
            {
                next();
            }
        }
        public static uint next()
        {
            return seed = seed * Mult + Add;
        }
        public static uint prev()
        {
            return seed = (seed * rMult) + rAdd;
        }
        public static ushort nextUShort()
        {
            return (ushort)(next() >> 16);
        }
        public static ushort prevUShort()
        {
            return (ushort)(prev() >> 16);
        }
        //太他妈的复杂我放弃！！！！！！！1

    }
}
