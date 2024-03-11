using PKHeX.Core;

namespace WangPluginPkm.RNG.Methods
{
    internal class PokeWalker
    {
        public static uint Next(uint seed) => WangRandUtil.NextRand(seed);
        public static bool GenPkm(ref PKM pk, CheckRules r)
        {
            // Pokewalker PIDs cannot yield multiple abilities from the input nature-gender-trainerID. Disregard any ability request.
            do
            {
                pk.PID = GetPokeWalkerPID(pk.TID16, pk.SID16, (int)pk.Nature, pk.Gender, pk.PersonalInfo.Gender);
            } while (!pk.IsGenderValid());

            pk.RefreshAbility((int)(pk.PID & 1));
            return true;
        }
        public static uint GetPokeWalkerPID(int TID16, int SID16, int nature, int gender, int gr)
        {
            if (nature >= 24)
                nature = 0;
            uint pid = (uint)((TID16 ^ SID16) >> 8 ^ 0xFF) << 24; // the most significant byte of the PID is chosen so the Pokémon can never be shiny.
                                                                  // Ensure nature is set to required nature without affecting shininess
            pid += (uint)nature - pid % 25;

            if (gr is 0 or >= 0xFE) // non-dual gender
                return pid;

            // Ensure Gender is set to required gender without affecting other properties
            // If Gender is modified, modify the ability if appropriate

            // either m/f
            var pidGender = (pid & 0xFF) < gr ? 1 : 0;
            if (gender == pidGender)
                return pid;

            if (gender == 0) // Male
            {
                pid += (uint)(((gr - (pid & 0xFF)) / 25 + 1) * 25);
                if ((nature & 1) != (pid & 1))
                    pid += 25;
            }
            else
            {
                pid -= (uint)((((pid & 0xFF) - gr) / 25 + 1) * 25);
                if ((nature & 1) != (pid & 1))
                    pid -= 25;
            }
            return pid;
        }

    }
}
