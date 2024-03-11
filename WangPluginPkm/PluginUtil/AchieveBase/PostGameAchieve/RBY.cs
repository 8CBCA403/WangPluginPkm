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
                int l = 0;
                if (sa.Region == 0)
                    l = 1;
                else if (sa.Region == 7)
                    l = 2;
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Venusaur, (int)GameVersion.RBY);
                pk.Language = l;
                pk.CurrentLevel = 50;
                pk.Species = 3;
                pk = AchieveFunc.fun(pk, SAV);
                pk.SID16 = 0;

                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Charizard, (int)GameVersion.RBY);
                pk.Language = l;
                pk.CurrentLevel = 50;
                pk.Species = 6;
                pk = AchieveFunc.fun(pk, SAV);
                pk.SID16 = 0;

                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Blastoise, (int)GameVersion.RBY);
                pk.CurrentLevel = 50;
                pk.Species = 9;
                pk.Language = l;
                pk = AchieveFunc.fun(pk, SAV);
                pk.SID16 = 0;
                pk.Version = (GameVersion)36;

                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Pikachu, (int)GameVersion.RBY);
                pk.Language = l;
                pk = AchieveFunc.fun(pk, SAV);
                pk.SID16 = 0;
                pk.Version = (GameVersion)38;

                PKL.Add(pk);
            }
            return PKL;
        }
    }
}
