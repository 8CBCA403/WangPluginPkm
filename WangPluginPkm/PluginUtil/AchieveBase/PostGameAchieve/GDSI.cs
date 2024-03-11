using PKHeX.Core;
using System.Collections.Generic;

namespace WangPluginPkm.PluginUtil.AchieveBase.PostGameAchieve
{
    internal class GDSI
    {
        public static List<PKM> GDSISets(ISaveFileProvider SAV, IPKMView Editor)
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
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.HoOh, (int)GameVersion.C);
                pk.Language = l;
                pk = AchieveFunc.fun(pk, SAV);
                pk.Version = (GameVersion)41;
                pk.SID16 = 0;
                PKL.Add(pk);

                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Lugia, (int)GameVersion.C);
                pk.Language = l;
                pk = AchieveFunc.fun(pk, SAV);
                pk.Version = (GameVersion)41;
                pk.SID16 = 0;

                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Suicune, (int)GameVersion.C);
                pk.Language = l;
                pk = AchieveFunc.fun(pk, SAV);
                pk.Version = (GameVersion)41;
                pk.SID16 = 0;

                PKL.Add(pk);


            }
            return PKL;
        }
    }
}
