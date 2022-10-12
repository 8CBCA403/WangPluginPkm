using PKHeX.Core;

namespace WangPluginPkm.RNG.Methods
{
    internal class PokeSpot
    {
        public static uint Next(uint seed) => WangRandUtil.NextRand(seed);
        public static bool GenPkm(ref PKM pk, uint seed, CheckRules r)
        {
            int slot = 0;
            if (pk.Species is 27 or 187 or 41)
                slot = 0;
            else if (pk.Species is 207 or 231 or 304)
                slot = 1;
            else if (pk.Species is 328 or 283 or 194)
                slot = 2;
            if (!IsPokeSpotActivation(slot, seed, out _))
                return false;
            var D = XDRNG.Next(seed); // PID
            var E = XDRNG.Next(D); // PID
            pk.PID = D & 0xFFFF0000 | E >> 16;
            if (!r.CheckShiny(r, pk))
                return false;
            pk.Gender = pk.GetSaneGender();
            pk.Nature = (int)pk.PID % 25;
            pk.RefreshAbility((int)(pk.PID & 1));
            pk.AbilityNumber = (int)(pk.PID & 1) + 1;
            pk.SetRandomIVs();
            return true;
        }

        public static bool IsPokeSpotActivation(int slot, uint seed, out uint s)
        {
            s = seed;
            var esv = (seed >> 16) % 100;
            if (!IsPokeSpotSlotValid(slot, esv))
            {
                // todo
            }
            // check for valid activation
            s = XDRNG.Prev(seed);
            if ((s >> 16) % 3 != 0)
            {
                if ((s >> 16) % 100 < 10) // can't fail a munchlax/bonsly encounter check
                {
                    // todo
                }
                s = XDRNG.Prev(s);
                if ((s >> 16) % 3 != 0) // can't activate even if generous
                {
                    // todo
                }
            }
            return true;
        }

        private static bool IsPokeSpotSlotValid(int slot, uint esv) => slot switch
        {
            0 => esv < 50, // [0,50)
            1 => esv - 50 < 35, // [50,85)
            2 => esv >= 85, // [85,100)
            _ => false,
        };
    }
}
