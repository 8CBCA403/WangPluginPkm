using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm
{
    internal class Overworld8Reversal
    {
        public static uint GetOriginalSeed(uint EC,uint PID)
        {
            var seed = EC - unchecked((uint)Xoroshiro128Plus.XOROSHIRO_CONST);
            if (seed == 0xD5B9C463) // Collision seed with the 0xFFFFFFFF re-roll.
            {
                var xoro = new Xoroshiro128Plus(seed);
                /*  ec */
                xoro.NextInt(uint.MaxValue);
                var pid = xoro.NextInt(uint.MaxValue);
                if (pid != PID)
                    return 0xDD6295A4;
            }

            return seed;
        }
    }
}
