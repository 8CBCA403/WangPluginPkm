using PKHeX.Core;

namespace WangPluginPkm.RNG.Methods
{
    internal class Gen5Wild
    {
        public static uint Next(uint seed) => WangRandUtil.NextRand(seed);
        public static bool GenPkm(ref PKM pk, uint seed, CheckRules r)
        {
            var tidbit = (pk.TID ^ pk.SID) & 1;
            // if (pk.AbilityNumber == 2)
            //  pk.AbilityNumber = 0;
            var bitxor = seed >> 31 ^ seed & 1;
            if (bitxor != tidbit)
                seed ^= 1;
            pk.RefreshAbility((int)(seed >> 16 & 1));
            pk.AbilityNumber = (int)(seed >> 16 & 1) + 1;
            pk.PID = seed;
            pk.Gender = pk.GetSaneGender();
            if (!r.CheckShiny(r, pk))
            {
                return false;
            }
            return true;

        }
    }
}
