using PKHeX.Core;
using System;

namespace WangPluginPkm.RNG.Methods
{
    internal class Wild8bRNG
    {
        private const int UNSET = 255;
        public static bool GenPkm(PKM pk, EncounterCriteria criteria, Shiny shiny, int flawless, XorShift128 xors, AbilityPermission ability)
        {

            // Encryption Constant
            pk.EncryptionConstant = xors.NextUInt();

            // PID
            var fakeTID16 = xors.NextUInt(); // fakeTID16
            var pid = xors.NextUInt();
            pid = GetRevisedPID(fakeTID16, pid, pk);
            var xor = GetShinyXor(pk.TID16, pk.SID16, pid);
            var type = GetRareType(xor);
            if (shiny == Shiny.Never)
            {
                if (type != Shiny.Never)
                    return false;
            }
            else if (shiny != Shiny.Random)
            {
                if (type == Shiny.Never)
                    return false;

                if (shiny == Shiny.AlwaysSquare && type != Shiny.AlwaysSquare)
                    return false;
                if (shiny == Shiny.AlwaysStar && type != Shiny.AlwaysStar)
                    return false;
            }
            pk.PID = pid;

            // Check IVs: Create flawless IVs at random indexes, then the random IVs for not flawless.
            Span<int> ivs = stackalloc[] { UNSET, UNSET, UNSET, UNSET, UNSET, UNSET };
            const int MAX = 31;
            var determined = 0;
            while (determined < flawless)
            {
                var idx = (int)xors.NextUInt(6);
                if (ivs[idx] != UNSET)
                    continue;
                ivs[idx] = 31;
                determined++;
            }

            for (var i = 0; i < ivs.Length; i++)
            {
                if (ivs[i] == UNSET)
                    ivs[i] = xors.NextInt(0, MAX + 1);
            }

            if (!criteria.IsCompatibleIVs(ivs))
                return false;

            pk.IV_HP = ivs[0];
            pk.IV_ATK = ivs[1];
            pk.IV_DEF = ivs[2];
            pk.IV_SPA = ivs[3];
            pk.IV_SPD = ivs[4];
            pk.IV_SPE = ivs[5];

            // Ability
            var n = ability switch
            {
                AbilityPermission.Any12 => (int)xors.NextUInt(2),
                AbilityPermission.Any12H => (int)xors.NextUInt(3),
                _ => (int)ability >> 1,
            };
            pk.SetAbilityIndex(n);

            // Gender (skip this if gender is fixed)
            var genderRatio = PersonalTable.BDSP.GetFormEntry(pk.Species, pk.Form).Gender;
            if (genderRatio == PersonalInfo.RatioMagicGenderless)
            {
                pk.Gender = 2;
            }
            else if (genderRatio == PersonalInfo.RatioMagicMale)
            {
                pk.Gender = 0;
            }
            else if (genderRatio == PersonalInfo.RatioMagicFemale)
            {
                pk.Gender = 1;
            }
            else
            {
                var next = (int)xors.NextUInt(253) + 1 < genderRatio ? 1 : 0;
                if (criteria.Gender is 0 or 1 && next != criteria.Gender)
                    return false;
                pk.Gender = (byte)next;
            }

            if (criteria.Nature is Nature.Random)
                pk.Nature = (Nature)xors.NextUInt(25);
            else // Skip nature, assuming Synchronize
                pk.Nature = (Nature)criteria.Nature;
            pk.StatNature = pk.Nature;

            // Remainder
            var scale = (IScaledSize)pk;
            scale.HeightScalar = (byte)((int)xors.NextUInt(0x81) + (int)xors.NextUInt(0x80));
            scale.WeightScalar = (byte)((int)xors.NextUInt(0x81) + (int)xors.NextUInt(0x80));

            // Item, don't care
            return true;
        }
        private static uint GetRevisedPID(uint fakeTID16, uint pid, ITrainerID32 tr)
        {
            var xor = GetShinyXor(pid, fakeTID16);
            var newXor = GetShinyXor(pid, tr.ID32);

            var fakeRare = GetRareType(xor);
            var newRare = GetRareType(newXor);

            if (fakeRare == newRare)
                return pid;

            var isShiny = xor < 16;
            if (isShiny)
                return ((uint)(tr.TID16 ^ tr.SID16) ^ pid & 0xFFFF ^ (xor == 0 ? 0u : 1u)) << 16 | pid & 0xFFFF; // force same shiny star type
            return pid ^ 0x1000_0000;
        }

        private static Shiny GetRareType(uint xor) => xor switch
        {
            0 => Shiny.AlwaysSquare,
            < 16 => Shiny.AlwaysStar,
            _ => Shiny.Never,
        };

        private static uint GetShinyXor(int TID16, int SID16, uint pid)
        {
            return GetShinyXor(pid, (uint)(SID16 << 16 | TID16));
        }

        private static uint GetShinyXor(uint pid, uint oid)
        {
            var xor = pid ^ oid;
            return (xor ^ xor >> 16) & 0xFFFF;
        }
    }

}
