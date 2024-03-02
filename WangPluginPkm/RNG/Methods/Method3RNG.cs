using PKHeX.Core;

namespace WangPluginPkm.RNG.Methods
{
    internal class Method3RNG
    {
        private const int shift = 16;
        public static uint Next(uint seed) => LCRNG.Next(seed);
        public static bool GenPkm(ref PKM pk, uint seed, CheckRules r)
        {
            var pidLower = LCRNG.Next(seed) >> shift;
            var pidUpper = LCRNG.Advance(seed, 3) >> shift;
            var dvLower = LCRNG.Advance(seed, 4) >> shift;
            var dvUpper = LCRNG.Advance(seed, 5) >> shift;
            var pid = CombineRNG(pidUpper, pidLower, shift);
            pk.PID = pid;
            if (!r.CheckShiny(r, pk))
            {
                return false;
            }
            var ivs = DvsToIVs(dvUpper, dvLower);
            pk.IV_HP = (int)ivs[0];
            pk.IV_ATK = (int)ivs[1];
            pk.IV_DEF = (int)ivs[2];
            pk.IV_SPA = (int)ivs[3];
            pk.IV_SPD = (int)ivs[4];
            pk.IV_SPE = (int)ivs[5];
            if (!r.CheckIV(r, pk))
            {
                return false;
            }
            pk.Nature = (Nature)(int)(pid % 100 % 25);
            pk.Gender = pk.GetSaneGender();
            pk.RefreshAbility((int)(pk.PID & 1));
            return true;
        }
        private static uint[] DvsToIVs(uint dvUpper, uint dvLower)
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
        private static uint CombineRNG(uint upper, uint lower, uint shift)
        {
            return (upper << (int)shift) + lower;
        }
    }
}

