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
            
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.HoOh, (int)GameVersion.C);
                pk.Language = 2;
                pk = AchieveFunc.fun(pk, SAV);
                pk.Version = (GameVersion)41;
                pk.SID16 = 0;
                PKL.Add(pk);
                ((PK7)pk).ConsoleRegion = 1;
                ((PK7)pk).Country = 49;
                ((PK7)pk).Region = 24;
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Lugia, (int)GameVersion.C);
                pk.Language = 2;
                pk = AchieveFunc.fun(pk, SAV);
                pk.Version = (GameVersion)41;
                pk.SID16 = 0;
                ((PK7)pk).ConsoleRegion = 1;
                ((PK7)pk).Country = 49;
                ((PK7)pk).Region = 24;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Suicune, (int)GameVersion.C);
                pk.Language = 2;
                pk = AchieveFunc.fun(pk, SAV);
                pk.Version = (GameVersion)41;
                pk.SID16 = 0;
                ((PK7)pk).ConsoleRegion = 1;
                ((PK7)pk).Country = 49;
                ((PK7)pk).Region = 24;
                PKL.Add(pk);


            }
            return PKL;
        }
    }
}
