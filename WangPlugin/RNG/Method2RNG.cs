using PKHeX.Core;

namespace WangPlugin
{
    internal static class Method2RNG
    {
        private const int shift = 16;

        public static uint Next(uint seed) => RNG.LCRNG.Next(seed);

        public static PKM GenPkm(PKM pk, uint seed)
        {
            var pidLower = RNG.LCRNG.Next(seed) >> shift;
            var pidUpper = RNG.LCRNG.Advance(seed, 2) >> shift;
            var dvLower = RNG.LCRNG.Advance(seed,4) >> shift;
            var dvUpper = RNG.LCRNG.Advance(seed, 5) >> shift;
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
            pk.Ability = (int)pid & 1;
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