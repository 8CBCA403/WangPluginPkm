using PKHeX.Core;

namespace WangPlugin
{
    internal static class Method1RNG
    {
        private const int shift = 16;

        public static uint Next(uint seed) => RNG.LCRNG.Next(seed);

        public static bool GenPkm(ref PKM pk,uint seed, bool shiny)
        {
            var pidLower = RNG.LCRNG.Next(seed) >> shift;
            var pidUpper = RNG.LCRNG.Advance(seed, 2) >> shift;
            var dvLower = RNG.LCRNG.Advance(seed, 3) >> shift;
            var dvUpper = RNG.LCRNG.Advance(seed, 4) >> shift;
            var pid = combineRNG(pidUpper, pidLower, shift);
            var pidR = combineRNG(pidLower, pidUpper, shift);
            var ivs = dvsToIVs(dvUpper, dvLower);
            if (pk.Species == 201)
            {
                pk.PID = pidR;
            }
            else
            {
                pk.PID = pid;
            }
            if (shiny && (CheckShiny(pk.PID, pk.TID, pk.SID) == false))
            {
                return false;
            }
            pk.IV_HP = (int)ivs[0];
            pk.IV_ATK = (int)ivs[1];
            pk.IV_DEF = (int)ivs[2];
            pk.IV_SPA = (int)ivs[3];
            pk.IV_SPD = (int)ivs[4];
            pk.IV_SPE = (int)ivs[5];
            pk.Nature =(int)(pid %100% 25);
            pk.Gender = PKX.GetGenderFromPID(pk.Species, pk.PID);
            pk.RefreshAbility((int)(pk.PID & 1));
            return true;
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
        private static bool CheckShiny(uint pid, int TID, int SID)
        {
            if (((uint)(TID ^ SID) ^ ((pid >> 16) ^ (pid & 0xFFFF))) < 8)
                return true;
            else
                return false;
        }
        private static uint combineRNG(uint upper, uint lower, uint shift)
        {
            return (upper << (int)shift) + lower;
        }
    }
}