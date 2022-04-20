

namespace WangPlugin
{
    public record class LCRNG
    {// LCRNG<Uint32>
        public uint add;
        public uint mul;
        public uint seed;
        public int shift;
    }

    public static class LCRNGUtil
    {
        public static LCRNG lcrngNext(LCRNG rng)
        {
            //LCRNG add mul (seed*mul+add) shift
            return rng with { seed = rng.seed * rng.mul + rng.add };
        }

        public static uint lcrngVal(LCRNG rng)
        {
            // shiftR seed shift
            return rng.seed >> rng.shift;
        }

        public static uint lcrngRand(LCRNG rng, uint max)
        {
            //shiftR ((shiftR seed shift)*max) shift
            return (lcrngVal(rng) * max) >> rng.shift;
        }

        public static uint combineRNG(uint upper, uint lower, uint shift)
        {
            //(shiftL upper shift) + lower
            return (upper << (int)shift) + lower;
        }

    }
}


