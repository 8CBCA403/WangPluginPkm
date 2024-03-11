using PKHeX.Core;

namespace WangPluginPkm.PluginUtil.AchieveBase
{
    internal class CheckAchieve
    {
        public static bool pokemonIsType(PKM pkm, MoveType type)
        {
            if (pkm.PersonalInfo.Type1 == (byte)type || pkm.PersonalInfo.Type2 == (byte)type)
            {
                return true;
            }

            return false;
        }
        public static bool pokemonIsBall(PKM pkm, Ball ball)
        {
            if (pkm.Ball == (int)ball)
            {
                return true;
            }

            return false;
        }
        public static bool pokemonIsNature(PKM pkm, Nature nature)
        {
            if (pkm.Nature == nature)
            {
                return true;
            }

            return false;
        }
        public static bool Ispokemon(PKM pkm)
        {
            if (pkm.Species != 0)
            {
                return true;
            }

            return false;
        }
        public static bool Isshiny(PKM pkm)
        {
            if (pkm.IsShiny)
            {
                return true;
            }

            return false;
        }
        public static bool IsAlpha(PA8 pkm)
        {
            if (pkm.IsAlpha)
            {
                return true;
            }

            return false;
        }
        public static bool IsGMax(PA8 pkm)
        {
            if (pkm.IsGanbaruValuesMax(pkm))
            {
                return true;
            }

            return false;
        }
        public static bool IsSheen(PB8 pkm)
        {
            if (pkm.ContestSheen == 255)
            {
                return true;
            }

            return false;
        }
        public static bool IsCool(PB8 pkm)
        {
            if (pkm.ContestCool == 255)
            {
                return true;
            }

            return false;
        }
        public static bool IsBeauty(PB8 pkm)
        {
            if (pkm.ContestBeauty == 255)
            {
                return true;
            }

            return false;
        }
        public static bool IsCute(PB8 pkm)
        {
            if (pkm.ContestCute == 255)
            {
                return true;
            }

            return false;
        }
        public static bool IsSmart(PB8 pkm)
        {
            if (pkm.ContestSmart == 255)
            {
                return true;
            }

            return false;
        }
        public static bool IsTough(PB8 pkm)
        {
            if (pkm.ContestTough == 255)
            {
                return true;
            }

            return false;
        }
        public static Ball B(int i)
        {
            var ty = Ball.Poke;
            switch (i)
            {
                case 0:
                    ty = Ball.Poke; break;
                case 1:
                    ty = Ball.Great; break;
                case 2:
                    ty = Ball.Ultra; break;
                case 3:
                    ty = Ball.Safari; break;
                case 4:
                    ty = Ball.Level; break;
                case 5:
                    ty = Ball.Lure; break;
                case 6:
                    ty = Ball.Moon; break;
                case 7:
                    ty = Ball.Friend; break;
                case 8:
                    ty = Ball.Love; break;
                case 9:
                    ty = Ball.Heavy; break;
                case 10:
                    ty = Ball.Fast; break;
                case 11:
                    ty = Ball.Premier; break;
                case 12:
                    ty = Ball.Repeat; break;
                case 13:
                    ty = Ball.Timer; break;
                case 14:
                    ty = Ball.Nest; break;
                case 15:
                    ty = Ball.Net; break;
                case 16:
                    ty = Ball.Dive; break;
                case 17:
                    ty = Ball.Luxury; break;
                case 18:
                    ty = Ball.Heal; break;
                case 19:
                    ty = Ball.Quick; break;
                case 20:
                    ty = Ball.Dusk; break;
                case 21:
                    ty = Ball.Sport; break;
                case 22:
                    ty = Ball.Dream; break;
                case 23:
                    ty = Ball.Beast; break;
                case 24:
                    ty = Ball.LAPoke; break;
                case 25:
                    ty = Ball.LAGreat; break;
                case 26:
                    ty = Ball.LAWing; break;
                case 27:
                    ty = Ball.LAHeavy; break;
                case 28:
                    ty = Ball.LAGigaton; break;
                case 29:
                    ty = Ball.LALeaden; break;
                case 30:
                    ty = Ball.LAFeather; break;
                case 31:
                    ty = Ball.LAJet; break;
                case 32:
                    ty = Ball.LAWing; break;
                case 33:
                    ty = Ball.Master; break;
                case 34:
                    ty = Ball.Cherish; break;

            }
            return ty;
        }
        public static MoveType T(int i)
        {
            var ty = MoveType.Normal;
            switch (i)
            {
                case 0:
                    ty = MoveType.Normal; break;
                case 1:
                    ty = MoveType.Fire; break;
                case 2:
                    ty = MoveType.Water; break;
                case 3:
                    ty = MoveType.Electric; break;
                case 4:
                    ty = MoveType.Grass; break;
                case 5:
                    ty = MoveType.Ice; break;
                case 6:
                    ty = MoveType.Fighting; break;
                case 7:
                    ty = MoveType.Poison; break;
                case 8:
                    ty = MoveType.Ground; break;
                case 9:
                    ty = MoveType.Flying; break;
                case 10:
                    ty = MoveType.Psychic; break;
                case 11:
                    ty = MoveType.Bug; break;
                case 12:
                    ty = MoveType.Rock; break;
                case 13:
                    ty = MoveType.Ghost; break;
                case 14:
                    ty = MoveType.Dragon; break;
                case 15:
                    ty = MoveType.Dark; break;
                case 16:
                    ty = MoveType.Steel; break;
                case 17:
                    ty = MoveType.Fairy; break;

            }
            return ty;
        }
        public static Nature N(int i)
        {
            var ty = Nature.Naive;
            switch (i)
            {
                case 0:
                    ty = Nature.Naive; break;
                case 1:
                    ty = Nature.Sassy; break;
                case 2:
                    ty = Nature.Gentle; break;
                case 3:
                    ty = Nature.Calm; break;
                case 4:
                    ty = Nature.Rash; break;
                case 5:
                    ty = Nature.Bashful; break;
                case 6:
                    ty = Nature.Quiet; break;
                case 7:
                    ty = Nature.Mild; break;
                case 8:
                    ty = Nature.Modest; break;
                case 9:
                    ty = Nature.Jolly; break;
                case 10:
                    ty = Nature.Serious; break;
                case 11:
                    ty = Nature.Hasty; break;
                case 12:
                    ty = Nature.Timid; break;
                case 13:
                    ty = Nature.Lax; break;
                case 14:
                    ty = Nature.Impish; break;
                case 15:
                    ty = Nature.Relaxed; break;
                case 16:
                    ty = Nature.Docile; break;
                case 17:
                    ty = Nature.Bold; break;
                case 18:
                    ty = Nature.Naughty; break;
                case 19:
                    ty = Nature.Careful; break;
                case 20:
                    ty = Nature.Adamant; break;
                case 21:
                    ty = Nature.Quirky; break;
                case 22:
                    ty = Nature.Brave; break;
                case 23:
                    ty = Nature.Hardy; break;
                case 24:
                    ty = Nature.Lonely; break;


            }
            return ty;
        }
    }
}
