using System;
using System.Collections.Generic;
using System.Linq;
using PKHeX.Core;
using PKHeX.Core.AutoMod;
using System.Windows.Forms;
namespace WangPlugin
{
    internal class RecoverLower16BitsPID
    {
        public static uint Mult= 0x41C64E6Du;
        public static  uint Add = 0x00006073u;
        private const int cacheSize = 1 << 16;
        public static bool[] flags = new bool[cacheSize];
        public static byte[] low = new byte[cacheSize];
        public static uint k =0x41C64E6Du << 8;
        public static uint seed = Util.Rand32();
        public static  IEnumerable<uint> RecoverLower16Bits(uint pid)
        {
            List<uint> list = new List<uint>();
            
            var k0g = Mult * Mult;
            for (uint i = 0; i <= byte.MaxValue; i++)
            {
                SetFlagData(i, Mult, Add, flags, low); // 1,2
            }
            uint num = pid << 16;
            uint num2 = pid & 0xFFFF0000u;
            uint num3 = num2 -(num * Mult);
            uint num4 = 0u;

            for (; num4 <= 255;++num4,num3-=k)
            {
                
                ushort val = (ushort)(num3 >> 16);
                if (flags[val])
                {
                  
                    uint num5 = num | (num4 << 8) | low[val];
                    if (((num5 * Mult + Add) & 0xFFFF0000u) == num2)
                    {
                       
                        list.Add(num5);
                    }
                }
            }
            
            return list;
        }
        public static List<uint[]> CalcPIDIVsByLCRNG(uint pid)
        {
           
            IEnumerable<uint> enumerable = RecoverLower16Bits(pid);
           
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
                    advance(1u);
                    ushort v = nextUShort();
                    ushort v2 = nextUShort();
                    list.Add(GetIVs(v, v2));
                }
            }
         
            return list;
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
        public static ushort nextUShort()
        {
            return (ushort)(next() >> 16);
        }
        public static uint[] GetIVs(uint v1, uint v2)
        {
            return new uint[6]
            {
        v1 & 0x1Fu,
        (v1 >> 5) & 0x1Fu,
        (v1 >> 10) & 0x1Fu,
        v2 & 0x1Fu,
        (v2 >> 5) & 0x1Fu,
        (v2 >> 10) & 0x1Fu
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
            pkm.IVs=iVs;
        }
        private static void SetFlagData(uint i, uint mult, uint add, bool[] f, byte[] v)
        {
            // the second rand() also has 16 bits that aren't known. It is a 16 bit value added to either side.
            // to consider these bits and their impact, they can at most increment/decrement the result by 1.
            // with the current calc setup, the search loop's calculated value may be -1 (loop does subtraction)
            // since LCGs are linear (hence the name), there's no values in adjacent cells. (no collisions)
            // if we mark the prior adjacent cell, we eliminate the need to check flags twice on each loop.
            uint right = (mult * i) + add;
            ushort val = (ushort)(right >> 16);

            f[val] = true; v[val] = (byte)i;
            --val;
            f[val] = true; v[val] = (byte)i;
            // now the search only has to access the flags array once per loop.
        }
    }

}
