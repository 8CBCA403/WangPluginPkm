using PKHeX.Core;
using WangPluginPkm.GUI;

namespace WangPluginPkm.RNG.Methods
{
    public static class Overworld8RNG
    {
        private const int UNSET = 255;
        public static uint Next(uint seed) => (uint)new Xoroshiro128Plus(seed).Next();
        public static bool GenPkm(ref PKM pk, uint seed, CheckRules r)
        {
            int FlawlessIVs = 0;
            if (pk.Species is 640 or 639 or 638)
                FlawlessIVs = 3;
            else if (pk.Species is 144 or 145 or 146)
            {
                if (pk.Form == 1)
                    FlawlessIVs = 3;
            }
            var xoro = new Xoroshiro128Plus(seed);

            var ec = (uint)xoro.NextInt(uint.MaxValue);
            pk.EncryptionConstant = ec;
            // PID
            var pid = (uint)xoro.NextInt(uint.MaxValue);
            uint revised_pid = GetRevisedPID(pid, pk.TID16, pk.SID16, r.Shiny);
            pk.PID = revised_pid;
            if (!r.CheckShiny(r, pk))
            {
                return false;
            }
            // IVs
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
                    ivs[i] = (int)xoro.NextInt(32);
            }

            pk.IV_HP = ivs[0];
            pk.IV_ATK = ivs[1];
            pk.IV_DEF = ivs[2];
            pk.IV_SPA = ivs[3];
            pk.IV_SPD = ivs[4];
            pk.IV_SPE = ivs[5];
            if (!r.CheckIV(r, pk))
            {
                return false;
            }
            // Remainder
            var scale = (IScaledSize)pk;
            scale.HeightScalar = (byte)((int)xoro.NextInt(0x81) + (int)xoro.NextInt(0x80));
            scale.WeightScalar = (byte)((int)xoro.NextInt(0x81) + (int)xoro.NextInt(0x80));
            var ability = 1 << (int)xoro.NextInt(2);
            if (pk.Species is 638 or 639 or 640)
            {
                if (ability != 1)
                    return false;
                else
                    pk.AbilityNumber = ability;
            }
            else
                pk.AbilityNumber = ability;
            pk.RefreshChecksum();
            return true;
        }
        private static uint GetRevisedPID(uint pid, int TID16, int SID16,RNGForm.ShinyType shiny)
        {
            uint s = (uint)(TID16 ^ SID16) ^ pid >> 16 ^ pid & 0xFFFF;
            if (shiny == RNGForm.ShinyType.Sqaure && s != 0)
            {
                pid = ((uint)(TID16 ^ SID16) ^ pid & 0xFFFF ^ 0) << 16 | pid & 0xFFFF;
                return pid;
            }

            else if (shiny == RNGForm.ShinyType.None && s < 16)
            {

                return pid ^ 0x10000000;
            }

            return pid;

        }
        public static bool GenPkmQ(ref PKM pk, uint seed, bool[] shiny, bool[] IV, uint Xor = 0)
        {
            int FlawlessIVs = 0;
            if (IV[2])
                FlawlessIVs = 3;
            var xoro = new Xoroshiro128Plus(seed);

            var ec = (uint)xoro.NextInt(uint.MaxValue);
            pk.EncryptionConstant = ec;
            // PID
            var pid = (uint)xoro.NextInt(uint.MaxValue);
            uint revised_pid = GetRevisedPIDQ(pid, pk.TID16, pk.SID16, shiny);
            pk.PID = revised_pid;
            if (!CheckShiny(pk.PID, pk.TID16, pk.SID16, shiny, Xor))
            {
                return false;
            }
            // IVs
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
                    ivs[i] = (int)xoro.NextInt(32);
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
            var ability = 1 << (int)xoro.NextInt(2);
            if (pk.Species is 638 or 639 or 640)
            {
                if (ability != 1)
                    return false;
                else
                    pk.AbilityNumber = ability;
            }
            else
                pk.AbilityNumber = ability;
            pk.RefreshChecksum();
            return true;
        }
        private static uint GetRevisedPIDQ(uint pid, int TID16, int SID16, bool[] shiny)
        {
            uint s = (uint)(TID16 ^ SID16) ^ pid >> 16 ^ pid & 0xFFFF;
            if (shiny[3] && s != 0)
            {
                pid = ((uint)(TID16 ^ SID16) ^ pid & 0xFFFF ^ 0) << 16 | pid & 0xFFFF;
                return pid;
            }

            else if (shiny[0] && s < 16)
            {

                return pid ^ 0x10000000;
            }

            return pid;

        }
        private static bool CheckShiny(uint pid, int TID16, int SID16, bool[] shiny, uint Xor = 0)
        {
            var s = (uint)(TID16 ^ SID16) ^ pid >> 16 ^ pid & 0xFFFF;
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
            else if (shiny[5] && s == Xor)
                return true;
            else
                return false;
        }


    }
}
