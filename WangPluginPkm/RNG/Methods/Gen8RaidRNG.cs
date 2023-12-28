using PKHeX.Core;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WangPluginPkm.RNG.Methods
{
    internal class Gen8RaidRNG
    {
        public static bool GenPkm(ref PKM pk, ulong seed, ushort species, byte iv_count, byte ability_param, byte gender_ratio, sbyte nature_param = -1, bool forceNoShiny = false)
        {

            // Encryption Constant
            var rng = new Xoroshiro128Plus(seed);
            pk.EncryptionConstant = (uint)rng.NextInt();

            // PID
            uint pid;
            bool isShiny;
            {
                var trID = (uint)rng.NextInt();
                pid = (uint)rng.NextInt();
                var xor = GetShinyXor(pid, trID);
                isShiny = xor < 16;
                if (isShiny && forceNoShiny)
                {
                    ForceShinyState(false, ref pid, trID);
                    isShiny = false;
                }
            }

            ForceShinyState(isShiny, ref pid, pk.ID32);

            pk.PID = pid;
            const int UNSET = -1;
            const int MAX = 31;
            var ivs = pk.IVs;
            for (int i = ivs.Count(); i < iv_count; i++)
            {
                int index = (int)rng.NextInt(6);
                while (ivs[index] != UNSET)
                    index = (int)rng.NextInt(6);
                ivs[index] = MAX;
            }

            for (int i = 0; i < 6; i++)
            {
                if (ivs[i] == UNSET)
                    ivs[i] = (int)rng.NextInt(32);
            }

            pk.IV_HP = ivs[0];

            pk.IV_ATK = ivs[1];

            pk.IV_DEF = ivs[2];

            pk.IV_SPA = ivs[3];

            pk.IV_SPD = ivs[4];

            pk.IV_SPE = ivs[5];


            int abil = ability_param switch
            {
                254 => (int)rng.NextInt(3),
                255 => (int)rng.NextInt(2),
                _ => ability_param,
            };
            abil <<= 1; // 1/2/4
            pk.AbilityNumber = abil;
            pk.RefreshAbility(abil);
            var current = pk.AbilityNumber;

            // else, for things that were made Hidden Ability, defer to Ability Checks (Ability Patch)

            switch (gender_ratio)
            {
                case PersonalInfo.RatioMagicGenderless:
                    pk.Gender = 2;

                    break;
                case PersonalInfo.RatioMagicFemale:
                    pk.Gender = 1;

                    break;
                case PersonalInfo.RatioMagicMale:
                    pk.Gender = 0;

                    break;
                default:
                    var gender = (int)rng.NextInt(253) + 1 < gender_ratio ? 1 : 0;
                    pk.Gender = gender;

                    break;
            }

            int nature = nature_param != -1 ? nature_param
                : species == (int)Species.Toxtricity
                    ? ToxtricityUtil.GetRandomNature(ref rng, pk.Form)
                    : (byte)rng.NextInt(25);
            pk.Nature = nature;


            if (pk is IScaledSize s)
            {
                var height = (int)rng.NextInt(0x81) + (int)rng.NextInt(0x80);
                var weight = (int)rng.NextInt(0x81) + (int)rng.NextInt(0x80);
                if (height == 0 && weight == 0 && pk is IHomeTrack { HasTracker: true })
                {
                    // HOME rerolls height/weight if both are 0
                    // This behavior started in 3.0.0, so only flag if the context is 9 or above.
                    if (pk.Context is not (EntityContext.Gen8 or EntityContext.Gen8a or EntityContext.Gen8b))
                        return false;
                }
                s.HeightScalar = (byte)height;
                s.WeightScalar = (byte)weight;
            }

            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ForceShinyState(bool isShiny, ref uint pid, uint tid)
        {
            if (isShiny)
            {
                if (!GetIsShiny(tid, pid))
                    pid = GetShinyPID((ushort)(tid & 0xFFFFu), (ushort)(tid >> 16), pid, 0);
            }
            else
            {
                if (GetIsShiny(tid, pid))
                    pid ^= 0x1000_0000;
            }
        }

        /// <summary>
        /// Apply the details to the PKM
        /// </summary>
        /// <param name="pk">Entity to verify against</param>
        /// <param name="seed">Seed that generated the entity</param>
        /// <param name="ivs">Buffer of IVs (potentially with already specified values)</param>
        /// <param name="species">Species of the entity</param>
        /// <param name="iv_count">Number of flawless IVs to generate</param>
        /// <param name="ability_param">Ability to generate</param>
        /// <param name="gender_ratio">Gender distribution to generate</param>
        /// <param name="nature_param">Nature to generate</param>
        /// <param name="shiny">Shiny state to generate</param>
        /// <returns>True if the seed matches the entity</returns>
        public static bool ApplyDetailsTo(PK8 pk, ulong seed, Span<int> ivs, ushort species, byte iv_count, byte ability_param, byte gender_ratio, sbyte nature_param = -1, Shiny shiny = Shiny.Random)
        {
            var rng = new Xoroshiro128Plus(seed);
            pk.EncryptionConstant = (uint)rng.NextInt();

            uint pid;
            bool isShiny;
            {
                var trID = (uint)rng.NextInt();
                pid = (uint)rng.NextInt();
                var xor = GetShinyXor(pid, trID);
                isShiny = xor < 16;
                if (isShiny && shiny == Shiny.Never)
                {
                    ForceShinyState(false, ref pid, trID);
                    isShiny = false;
                }
            }

            if (isShiny)
            {
                if (!GetIsShiny(pk.ID32, pid))
                    pid = GetShinyPID(pk.TID16, pk.SID16, pid, 0);
            }
            else
            {
                if (GetIsShiny(pk.ID32, pid))
                    pid ^= 0x1000_0000;
            }

            pk.PID = pid;

            const int UNSET = -1;
            const int MAX = 31;
            for (int i = ivs.Count(MAX); i < iv_count; i++)
            {
                int index = (int)rng.NextInt(6);
                while (ivs[index] != UNSET)
                    index = (int)rng.NextInt(6);
                ivs[index] = MAX;
            }

            for (int i = 0; i < 6; i++)
            {
                if (ivs[i] == UNSET)
                    ivs[i] = (int)rng.NextInt(32);
            }

            pk.IV_HP = ivs[0];
            pk.IV_ATK = ivs[1];
            pk.IV_DEF = ivs[2];
            pk.IV_SPA = ivs[3];
            pk.IV_SPD = ivs[4];
            pk.IV_SPE = ivs[5];

            int abil = ability_param switch
            {
                254 => (int)rng.NextInt(3),
                255 => (int)rng.NextInt(2),
                _ => ability_param,
            };
            pk.RefreshAbility(abil);

            pk.Gender = gender_ratio switch
            {
                PersonalInfo.RatioMagicGenderless => 2,
                PersonalInfo.RatioMagicFemale => 1,
                PersonalInfo.RatioMagicMale => 0,
                _ => (int)rng.NextInt(253) + 1 < gender_ratio ? 1 : 0,
            };

            int nature = nature_param != -1 ? nature_param
                : species == (int)Species.Toxtricity
                    ? ToxtricityUtil.GetRandomNature(ref rng, pk.Form)
                    : (byte)rng.NextInt(25);

            pk.Nature = pk.StatNature = nature;

            var height = (int)rng.NextInt(0x81) + (int)rng.NextInt(0x80);
            var weight = (int)rng.NextInt(0x81) + (int)rng.NextInt(0x80);
            pk.HeightScalar = (byte)height;
            pk.WeightScalar = (byte)weight;

            return true;
        }

        private static uint GetShinyPID(ushort tid, ushort sid, uint pid, uint type)
        {
            return (type ^ tid ^ sid ^ (pid & 0xFFFF)) << 16 | (pid & 0xFFFF);
        }

        private static bool GetIsShiny(uint id32, uint pid) => GetShinyXor(pid, id32) < 16;

        private static uint GetShinyXor(uint pid, uint id32)
        {
            var xor = pid ^ id32;
            return (xor ^ (xor >> 16)) & 0xFFFF;
        }
    }

}

