﻿using PKHeX.Core;
using System;

namespace WangPlugin
{
    public static class LCRNGReversalSkip
    { // Bruteforce cache for searching seeds
        private const int cacheSize = 1 << 16;
        private static readonly byte[] low8 = new byte[cacheSize];
        private static readonly bool[] flags = new bool[cacheSize];
        private const uint Mult = unchecked(LCRNG.Mult * LCRNG.Mult);     // 0xC2A29A69
        private const uint Add = unchecked(LCRNG.Add * (LCRNG.Mult + 1)); // 0xE97E7B6A
        private const uint k2 = Mult << 8;

        static LCRNGReversalSkip()

        {
            // Populate Meet Middle Arrays
            var f = flags;
            var b = low8;
            for (uint i = 0; i <= byte.MaxValue; i++)
            {
                // the second rand() also has 16 bits that aren't known. It is a 16 bit value added to either side.
                // to consider these bits and their impact, they can at most increment/decrement the result by 1.
                // with the current calc setup, the search loop's calculated value may be -1 (loop does subtraction)
                // since LCGs are linear (hence the name), there's no values in adjacent cells. (no collisions)
                // if we mark the prior adjacent cell, we eliminate the need to check flags twice on each loop.
                uint right = (Mult * i) + Add;
                ushort val = (ushort)(right >> 16);

                f[val] = true; b[val] = (byte)i;
                --val;
                f[val] = true; b[val] = (byte)i;
                // now the search only has to access the flags array once per loop.
            }
        }


        /// <summary>
        /// Finds all seeds that can generate the <see cref="pid"/> with a discarded rand() between the two halves.
        /// </summary>
        /// <param name="result">Result storage array, to be populated starting at index 0.</param>
        /// <param name="pid">PID to be reversed into seeds that generate it.</param>
        /// <returns>Count of results added to <see cref="result"/></returns>
        public static int GetSeeds(Span<uint> result, uint pid, bool IsUnown = false)
        {
            uint first = pid << 16;
            uint second = pid & 0xFFFF_0000;
            if (IsUnown)
            {
                first = pid & 0xFFFF_0000;
                second = pid << 16;
            }
            return GetSeeds(result, first, second);
        }



        /// <summary>
        /// Finds all the origin seeds for two 16 bit rand() calls (ignoring a rand() in between)
        /// </summary>
        /// <param name="result">Result storage array, to be populated starting at index 0.</param>
        /// <param name="first">First rand() call, 16 bits, already shifted left 16 bits.</param>
        /// <param name="third">Third rand() call, 16 bits, already shifted left 16 bits.</param>
        /// <returns>Count of results added to <see cref="result"/></returns>
        public static int GetSeeds(Span<uint> result, uint first, uint third)
        {
            int ctr = 0;
            uint search = third - (first * Mult);
            for (uint i = 0; i <= 255; ++i, search -= k2)
            {
                ushort val = (ushort)(search >> 16);
                if (flags[val])
                {
                    // Verify PID calls line up
                    var seed = first | (i << 8) | low8[val];
                    var next = LCRNG.Next2(seed);
                    if ((next & 0xFFFF0000) == third)
                        result[ctr++] = LCRNG.Prev(seed);
                }
            }
            return ctr;
        }
        public static int GetSeedsIVs(Span<uint> result, uint hp, uint atk, uint def, uint spa, uint spd, uint spe)
        {
            uint first = (hp | (atk << 5) | (def << 10)) << 16;
            uint second = (spe | (spa << 5) | (spd << 10)) << 16;
            return GetSeedsIVs(result, first, second);

        }
        public static int GetSeedsIVs(Span<uint> result, uint first, uint third)
        {
            int ctr = 0;
            uint search1 = third - (first * Mult);
            uint search3 = third - ((first ^ 0x80000000) * Mult);

            for (uint i = 0; i <= 255; i++, search1 -= k2, search3 -= k2)
            {
                ushort val = (ushort)(search1 >> 16);
                if (flags[val])
                {
                    // Verify PID calls line up
                    var seed = first | (i << 8) | low8[val];
                    var next = LCRNG.Next2(seed);
                    if ((next & 0x7FFF0000) == third)
                    {
                        var origin = LCRNG.Prev(seed);
                        result[ctr++] = origin;
                        result[ctr++] = origin ^ 0x80000000;
                    }
                }

                val = (ushort)(search3 >> 16);
                if (flags[val])
                {
                    // Verify PID calls line up
                    var seed = first | (i << 8) | low8[val];
                    var next = LCRNG.Next2(seed);
                    if ((next & 0x7FFF0000) == third)
                    {
                        var origin = LCRNG.Prev(seed);
                        result[ctr++] = origin;
                        result[ctr++] = origin ^ 0x80000000;
                    }
                }
            }


            return ctr;
        }
    }
}


