using PKHeX.Core;
using System.Collections.Generic;

namespace WangPluginPkm.PluginUtil.AchieveBase.PostGameAchieve
{
    internal class RBY
    {
        public static List<PKM> RBYSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;

            if (SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                var sa = (SAV7)SAV.SAV;
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Venusaur, (int)GameVersion.RBY);
                pk.Language = 2;
                pk.CurrentLevel = 50;
                pk.Species = 3;
                pk = AchieveFunc.fun(pk, SAV);
                pk.SID16 = 0;
                ((PK7)pk).ConsoleRegion = 1;
                ((PK7)pk).Country = 49;
                ((PK7)pk).Region = 24;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Charizard, (int)GameVersion.RBY);
                pk.Language = 2;
                pk.CurrentLevel = 50;
                pk.Species = 6;
                pk = AchieveFunc.fun(pk, SAV);
                pk.SID16 = 0;
                ((PK7)pk).ConsoleRegion = 1;
                ((PK7)pk).Country = 49;
                ((PK7)pk).Region = 24;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Blastoise, (int)GameVersion.RBY);
                pk.CurrentLevel = 50;
                pk.Species = 9;
                pk.Language = 2;
                pk = AchieveFunc.fun(pk, SAV);
                pk.SID16 = 0;
                pk.Version = (GameVersion)36;
                ((PK7)pk).ConsoleRegion = 1;
                ((PK7)pk).Country = 49;
                ((PK7)pk).Region = 24;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Pikachu, (int)GameVersion.RBY);
                pk.Language = 2;
                pk = AchieveFunc.fun(pk, SAV);
                pk.SID16 = 0;
                pk.Version = (GameVersion)38;
                ((PK7)pk).ConsoleRegion = 1;
                ((PK7)pk).Country = 49;
                ((PK7)pk).Region = 24;
                pk.OriginalTrainerName = "Wang";
                PKL.Add(pk);
            }
            return PKL;
        }
    }
}
