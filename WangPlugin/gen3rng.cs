using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPlugin
{


    public static class Gen3RngUtil
    {

        public static IEnumerable<Frame> findEmeraldFrame(uint seed, int min, int max)
        {
            return findFrameGen3(seed, min, max);

        }

        private static IEnumerable<Frame> findFrameGen3(uint seed, int min, int max)
        {
            var rng = new LCRNG { add = 0x6073, mul = 0x41c64e6d, seed = seed, shift = 16 };
            return frameSearcherMethod1(min, max, 0, rng);
        }

        private static IEnumerable<Frame> frameSearcherMethod1(int min, int max, int num, LCRNG rng)
        {
            if (min == 0 && max == -1)
            {
                yield return new Frame();
                yield break;
            }
            if (min == 0)
            {
                var TID = 00000;
                var SID = 00000;
                var rng2 = LCRNGUtil.lcrngNext(rng);
                var rng3 = LCRNGUtil.lcrngNext(rng2);
                var rng4 = LCRNGUtil.lcrngNext(rng3);
                var pidLower = LCRNGUtil.lcrngVal(rng);
                var pidUpper = LCRNGUtil.lcrngVal(rng2);
                var dvLower = LCRNGUtil.lcrngVal(rng3);
                var dvUpper = LCRNGUtil.lcrngVal(rng4);
                var PID = LCRNGUtil.combineRNG(pidUpper, pidLower, 16);
                var ivs = FrameUtil.dvsToIVs(dvUpper, dvLower);
                var xor = TID^ SID ^ ((PID >> 16) ^ (PID & 0xFFFF));

                if (xor<8)
                {
                    yield return new Frame { seed = 0, number = num, rngValue = dvUpper, pid = PID, ivs = ivs };
                }
                foreach (var f in frameSearcherMethod1( 0, (max - 1), (num + 1), rng2))
                {
                    yield return f;
                }
                yield break;
            }

            else
            {
                foreach (var f in frameSearcherMethod1(min - 1, (max - 1), num + 1, LCRNGUtil.lcrngNext(rng)))
                {
                    yield return f;
                }
                yield break;

            }

        }
    }
}
