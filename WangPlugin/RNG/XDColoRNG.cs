using PKHeX.Core;

namespace WangPlugin
{
    internal static class XDColoRNG
    {
        private const int shift = 16;
        private const int shift8 = 8;

        public static uint Next(uint seed) => RNG.XDRNG.Next(seed);

        public static PKM GenPkm(PKM pk, uint seed)
        {
            var dvLower = RNG.XDRNG.Next(seed) >> shift;
            var dvUpper = RNG.XDRNG.Advance(seed, 2) >> shift;
            var ability = RNG.XDRNG.Advance(seed, 3) & 1>> shift8;
            var pidUpper = RNG.XDRNG.Advance(seed,4) >> shift;
            var pidLower = RNG.XDRNG.Advance(seed,5 ) >> shift;           
            var pid = combineRNG(pidUpper, pidLower, shift);
            var ivs = dvsToIVs(dvUpper, dvLower);
            pk.PID = pid;
            pk.IV_HP = (int)ivs[0];
            pk.IV_ATK = (int)ivs[1];
            pk.IV_DEF = (int)ivs[2];
            pk.IV_SPA = (int)ivs[3];
            pk.IV_SPD = (int)ivs[4];
            pk.IV_SPE = (int)ivs[5];
            pk.Nature = (int)(pid % 100 % 25);
            pk.Ability =(int) ability;
            return pk;
        }

        private static uint[] dvsToIVs(uint dvUpper, uint dvLower)
        {
            return new uint[]
            {
                dvLower & 0x1f,
                (dvLower & 0x3E0) >> 5,
                (dvLower & 0x7C00) >> 10,
                (dvUpper & 0x3E0) >> 5,
                (dvUpper & 0x7C00) >> 10,
                dvUpper & 0x1f,
            };
        }
        private static uint combineRNG(uint upper, uint lower, uint shift)
        {
            return (upper << (int)shift) + lower;
        }
    }
}