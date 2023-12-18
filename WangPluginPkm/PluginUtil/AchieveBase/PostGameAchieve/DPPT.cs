using PKHeX.Core;
using System.Collections.Generic;

namespace WangPluginPkm.PluginUtil.AchieveBase.PostGameAchieve
{
    internal class DPPT
    {
        public static List<PKM> DPPTSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if (SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Dialga, (int)GameVersion.D);
                pk = AchieveFunc.fun(pk, SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Palkia, (int)GameVersion.P);
                pk = AchieveFunc.fun(pk, SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Giratina, (int)GameVersion.Pt);
                pk = AchieveFunc.fun(pk, SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Turtwig, (int)GameVersion.D);
                pk = AchieveFunc.fun(pk, SAV);
                pk.Version = 10;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Chimchar, (int)GameVersion.P);
                pk = AchieveFunc.fun(pk, SAV);
                pk.Version = 11;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Piplup, (int)GameVersion.Pt);
                pk = AchieveFunc.fun(pk, SAV);
                PKL.Add(pk);

            }
            return PKL;
        }
    }
}
