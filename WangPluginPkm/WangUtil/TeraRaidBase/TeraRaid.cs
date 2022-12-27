using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm.WangUtil.TeraRaidBase
{
    internal class TeraRaid
    {
        public const byte SIZE = 0x20;
        const int IV_MAX = 31;
#nullable enable
        public static string Game = "Scarlet";
        public static readonly GameStrings strings = GameInfo.GetStrings("zh");

        public static ITeraRaid[]? GemTeraRaids;
        public static ITeraRaid[]? DistTeraRaids;

        public virtual uint Seed { get; set; }
        public virtual bool IsBlack { get; set; }
        public virtual bool IsEvent { get; set; }

        public virtual bool IsC { get; set; }
        public ITeraRaid? Encounter(int Stage) => IsEvent ? TeraDistribution.GetEncounter(Seed, Stage, IsC) : TeraEncounter.GetEncounter(Seed, Stage, IsBlack);
        // Derived Values
        public virtual string? TeraType => GetTeraType(Seed);
        public virtual int TeranType => GetTeranType(Seed);
        public virtual uint Difficulty => GetDifficulty(Seed);

        public virtual uint EC => GenericRaidData[0];
        /* public virtual uint TIDSID => GenericRaidData[1]; */ // Unneeded
        public virtual uint PID => GenericRaidData[2];
        public virtual bool IsShiny => GenericRaidData[3] == 1;


        uint[] GenericRaidData => GenerateGenericRaidData(Seed);
        public static string GetTeraType(uint Seed)
        {
            var rng = new Xoroshiro128Plus(Seed);
            var Type = rng.NextInt(18);
            return $"{strings.types[Type]} ({Type})";
        }

        public static uint[] GenerateGenericRaidData(uint Seed)
        {
            var rng = new Xoroshiro128Plus(Seed);
            uint EC = (uint)rng.NextInt();
            uint TIDSID = (uint)rng.NextInt();
            uint PID = (uint)rng.NextInt();
            var Shiny = (((PID >> 16) ^ (PID & 0xFFFF)) >> 4) == (((TIDSID >> 16) ^ (TIDSID & 0xFFFF)) >> 4) ? 1 : 0;
            return new uint[] { EC, TIDSID, PID, (uint)Shiny };
        }

        public int[] GetIVs(uint Seed, int FlawlessIVs)
        {
            var rng = new Xoroshiro128Plus(Seed);
            // Dummy calls
            rng.NextInt(); // EC
            rng.NextInt(); // TIDSID
            rng.NextInt(); // PID

            Span<int> ivs = stackalloc[] { -1, -1, -1, -1, -1, -1 };
            // Flawless IVs
            for (int i = 0; i < FlawlessIVs; i++)
            {
                int index;
                do { index = (int)rng.NextInt(6); }
                while (ivs[index] != -1);

                ivs[index] = IV_MAX;
            }
            // Other IVs
            for (int i = 0; i < ivs.Length; i++)
            {
                if (ivs[i] == -1)
                    ivs[i] = (int)rng.NextInt(32);
            }

            return ivs.ToArray();
        }

        public static int GetStarCount(uint Difficulty, int Progress, bool IsBlack)
        {
            if (IsBlack) return 6;
            return Progress switch
            {
                0 => Difficulty switch
                {
                    > 80 => 2,
                    _ => 1,
                },
                1 => Difficulty switch
                {
                    > 70 => 3,
                    > 30 => 2,
                    _ => 1,
                },
                2 => Difficulty switch
                {
                    > 70 => 4,
                    > 40 => 3,
                    > 20 => 2,
                    _ => 1,
                },
                3 => Difficulty switch
                {
                    > 75 => 5,
                    > 40 => 4,
                    _ => 3,
                },
                4 => Difficulty switch
                {
                    > 70 => 5,
                    > 30 => 4,
                    _ => 3,
                },
                _ => 1,
            };
        }

        public static uint GetDifficulty(uint Seed)
        {
            var rng = new Xoroshiro128Plus(Seed);
            return (uint)rng.NextInt(100);

        }
        public static int GetTeranType(uint Seed)
        {
            var rng = new Xoroshiro128Plus(Seed);
            var Type = rng.NextInt(18);
            return (int)Type;
        }
        public static int[] GetIV(uint Seed, int FlawlessIVs)
        {
            var rng = new Xoroshiro128Plus(Seed);
            // Dummy calls
            rng.NextInt(); // EC
            rng.NextInt(); // TIDSID
            rng.NextInt(); // PID

            Span<int> ivs = stackalloc[] { -1, -1, -1, -1, -1, -1 };
            // Flawless IVs
            for (int i = 0; i < FlawlessIVs; i++)
            {
                int index;
                do { index = (int)rng.NextInt(6); }
                while (ivs[index] != -1);

                ivs[index] = IV_MAX;
            }
            // Other IVs
            for (int i = 0; i < ivs.Length; i++)
            {
                if (ivs[i] == -1)
                    ivs[i] = (int)rng.NextInt(32);
            }

            return ivs.ToArray();
        }

    }
}
