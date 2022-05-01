using PKHeX.Core;

namespace WangPlugin

{
    /// <summary>
    /// Contains logic for the Generation 8 (SW/SH) overworld spawns that walk around the overworld.
    /// </summary>
    /// <remarks>
    /// Entities spawned into the overworld that can be encountered are assigned a 32bit seed, which can be immediately derived from the <see cref="PKM.EncryptionConstant"/>.
    /// </remarks>
    public static class Overworld8RNG
    {
        
        private const int UNSET = 255;
        public static uint Next(uint seed) => (uint)new Xoroshiro128Plus(seed).Next();
        public static bool GenPkm(ref PKM pk,uint seed,  bool[] shiny, bool[] IV)
        {
            int FlawlessIVs = 0;
            if (IV[2])
                FlawlessIVs = 3;
            var xoro = new Xoroshiro128Plus(seed);

            var ec= (uint)xoro.NextInt(uint.MaxValue);
            pk.EncryptionConstant = ec;
            // PID
            var pid = (uint)xoro.NextInt(uint.MaxValue);
            pk.PID = pid;
            // IVs
            if (!CheckShiny(pk.PID, pk.TID, pk.SID,shiny))
            {
                return false;
            }
            var ivs = new int[6] { UNSET, UNSET, UNSET, UNSET, UNSET, UNSET };
           
            const int MAX = 31;
            for (int i = 0; i < FlawlessIVs; i++)
            {
                int index;
                do { index = (int)xoro.NextInt(6); }
                while (ivs[index] != UNSET);

                ivs[index] = MAX;
            }
            for (int i = 0; i < ivs.Length; i++)
            {
                if (ivs[i] == UNSET)
                    ivs[i] = (int) xoro.NextInt(32);
            }
            if (IV[0] && ivs[1] != 0)
            {
                return false;
            }
            if (IV[1] && ivs[5] != 0)
            {
                return false;
            }
            pk.IV_HP = ivs[0];
            pk.IV_ATK = ivs[1];
            pk.IV_DEF = ivs[2];
            pk.IV_SPA = ivs[3];
            pk.IV_SPD = ivs[4];
            pk.IV_SPE = ivs[5];
            // Remainder
            var scale = (IScaledSize)pk;
            scale.HeightScalar = (byte)((int)xoro.NextInt(0x81) + (int)xoro.NextInt(0x80));
            scale.WeightScalar = (byte)((int)xoro.NextInt(0x81) + (int)xoro.NextInt(0x80));
            var ability = (1 << (int)xoro.NextInt(2));
            if (pk.Species is not (638 or 639 or 640))
                pk.AbilityNumber = ability;
            pk.RefreshChecksum();
            return true;
        }

        private static bool CheckShiny(uint pid, int TID, int SID, bool[] shiny)
        {
            var s = (uint)(TID ^ SID) ^ ((pid >> 16) ^ (pid & 0xFFFF));
            if (shiny[0])
                return true;
            else if (shiny[1] && s < 16)
                return true;
            else if (shiny[2] && s < 16 && s != 0)
                return true;
            else if (shiny[3] && s == 0)
                return true;
            else if (shiny[4] && s == 1)
                return true;
            else
                return false;
        }

    }
}
