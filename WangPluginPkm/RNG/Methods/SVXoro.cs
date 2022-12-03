using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKHeX.Core;
using System.Windows.Forms;
using WangPluginPkm.RNG;

namespace WangPluginPkm
{
    internal class SVXoro
    {
        const int MAX_SHINYROLLS = 1; //Assume only 1 shiny roll at the beginning of the game
        const int MAX_LEGALITYROLLS = 4; //Need to check what's the maximum Shiny Roll legally reachable. Assume 4 for now.

        const ushort UserTID = 12345; //Player's classic TID
        const ushort UserSID = 54321; //Player's classic SID

        const int BlockSize = 0xC98;
        const int SeedDistance = 0x1C;
        const int SeedSize = 0x4;

        const int NFlawless = 1;
        const int NIV = 6;
        const int IVMaxValue = 31;
        const int NAbility = 2;
        const int NNature = 25;

        const int UNSET = -1;
        public static PK9 CalculateFromSeed(int Miniv,uint seed = 0 )
        {
            PK9 pk9 = new PK9();
            int i;
            var xoro = seed == 0 ? new Xoroshiro() : new Xoroshiro(seed);
            var personalRnd = xoro.NextUInt();
            var fakeTrainer = xoro.NextUInt();

            var rareRnd = (uint)0;
            var isShiny = false;
            for (i = 0; i < MAX_SHINYROLLS; i++)
            {
                rareRnd = xoro.NextUInt();
                isShiny = IsShiny(rareRnd, fakeTrainer);
                if (isShiny)
                {
                    if (!IsShiny(rareRnd))
                        rareRnd = ForceShiny(rareRnd);
                    break;
                }
                else
                    if (IsShiny(rareRnd))
                    rareRnd = ForceNonShiny(rareRnd);
            }
            pk9.EncryptionConstant = personalRnd;
            pk9.PID = rareRnd;
            
            int[] ivs = { UNSET, UNSET, UNSET, UNSET, UNSET, UNSET };
            var determined = 0;
            while (determined < Miniv)
            {
                var idx = xoro.NextInt(NIV);
                if (ivs[idx] != UNSET)
                    continue;
                ivs[idx] = 31;
                determined++;
            }

            for (i = 0; i < ivs.Length; i++)
                if (ivs[i] == UNSET)
                    ivs[i] = (int)xoro.NextInt(IVMaxValue + 1);
            pk9.IVs= ivs;
            pk9.IV_HP = ivs[0];
            pk9. IV_ATK = ivs[1];
            pk9. IV_DEF = ivs[2];
            pk9. IV_SPA = ivs[3];
            pk9.IV_SPD = ivs[4];
            pk9. IV_SPE = ivs[5];
            
            var ability =(int) xoro.NextInt(NAbility);
            var nature = xoro.NextInt(NNature);
            var nature2 = xoro.NextInt(NNature);
            pk9.AbilityNumber = ability;
            var userString = isShiny ? $"(For TID {UserTID} and SID {UserSID} - Change settings in the code)" : "";
            return pk9;
        }

        public static string ComputeShinySeed(uint seed = 0, bool showDetails = false)
        {
            var prev = seed == 0 ? Xoroshiro.XOROSHIRO_CONST : seed;
            var isShiny = false;
            var personalRnd = (uint)0;
            uint fakeTrainer;
            uint rareRnd;
            Xoroshiro xoro;

            while (!isShiny)
            {
                xoro = new Xoroshiro(prev);
                personalRnd = xoro.NextUInt();
                seed = xoro.NextUInt();
                fakeTrainer = seed;
                prev = ReverseSeed(seed);

                for (var j = 0; j < MAX_SHINYROLLS; j++)
                {
                    rareRnd = xoro.NextUInt();
                    isShiny = IsShiny(rareRnd, fakeTrainer);
                    if (isShiny)
                        break;
                }
            }

            seed = ReverseSeed(personalRnd);
            return $"{seed:X}";

         //   if (showDetails)
              //  CalculateFromSeed(1,seed);
        }

        public static PK9 CheckLegality(PK9 pk,int miniv)
        {
            var originalSeed = ReverseSeed(pk.EncryptionConstant);
            var isValid = IsValidEncounter(pk.EncryptionConstant, pk.PID, pk.IVs, pk.AbilityNumber, pk.Nature, miniv);
            CheckResult r = new();
            r.r = isValid;
            r.seed = originalSeed;
            var p=CalculateFromSeed(miniv, originalSeed);
            return p;
        }

        public static uint ReverseSeed(uint EC) => EC - (uint)(Xoroshiro.XOROSHIRO_CONST & 0xFFFFFFFF);

        private static bool[] IsValidEncounter(uint EC, uint PID, int[] IVS, int ABILITY, int NATURE,int Miniv)
        {
            bool[] r = { false, false, false,false,false,false};
            var reversed = ReverseSeed(EC);
            var xoro = new Xoroshiro(reversed);

            xoro.Next();
            var fakeTrainer = xoro.NextUInt();

            var rareRnd = (uint)0;
            for (int i = 0; i < MAX_LEGALITYROLLS; i++)
            {
                rareRnd = xoro.NextUInt();
                var isShiny = IsShiny(rareRnd, fakeTrainer);

                if (isShiny)
                {
                    if (!IsShiny(rareRnd))
                        rareRnd = ForceShiny(rareRnd);
                    break;
                }
                else
                {
                    if (IsShiny(rareRnd))
                        rareRnd = ForceNonShiny(rareRnd);
                }

                if (rareRnd == PID)
                    break;
            }

            if (rareRnd == PID)
                r[0] = true;

            if (!IsUnset(IVS))
            {
                int[] ivs = { UNSET, UNSET, UNSET, UNSET, UNSET, UNSET };
                var determined = 0;
                while (determined < Miniv)
                {
                    var idx = xoro.NextInt(NIV);
                    if (ivs[idx] != UNSET)
                        continue;
                    ivs[idx] = 31;
                    determined++;
                }

                for (var i = 0; i < ivs.Length; i++)
                    if (ivs[i] == UNSET)
                        ivs[i] = (int)xoro.NextInt(IVMaxValue + 1);

                if (Enumerable.SequenceEqual(ivs, IVS))
                    r[1] = true;

                if (ABILITY != UNSET)
                {
                    var ability = (int)xoro.NextInt(NAbility);
                    if (ability + 1 == ABILITY)
                        r[2] = true;

                 //   if (NATURE != Nature.None)
                    {
                        var nature = (int)xoro.NextInt(NNature);
                        var nature2 =(int) xoro.NextInt(NNature);

                        if (nature == NATURE || nature2 == NATURE)
                            r[3] = true;
                    }
                }
            }

            return r;
        }

        private static bool IsShiny(uint PID, ushort TID = UserTID, ushort SID = UserSID) =>
            (ushort)(SID ^ TID ^ (PID >> 16) ^ PID) < 16;

        private static bool IsShiny(uint PID, uint FTID) =>
            IsShiny(PID, (ushort)(FTID >> 16), (ushort)(FTID & 0xFFFF));

        private static uint ForceShiny(uint PID, uint TID = UserTID, uint SID = UserSID) =>
            ((TID ^ SID ^ (PID & 0xFFFF) ^ 1) << 16) | (PID & 0xFFFF);

        private static uint ForceNonShiny(uint PID) => PID ^ 0x10000000;

        private static string GetValidationString(uint seed, bool valid)
        {
            if (valid)
                return $"{seed:X} (VALID)";
            return "(INVALID)";
        }

        private static bool IsUnset(int[] array)
        {
            foreach (var i in array)
                if (i == UNSET)
                    return true;
            return false;
        }
    }
}
