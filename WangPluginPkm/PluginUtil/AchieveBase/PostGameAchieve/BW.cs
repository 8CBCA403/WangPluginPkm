using PKHeX.Core;
using System.Collections.Generic;

namespace WangPluginPkm.PluginUtil.AchieveBase.PostGameAchieve
{
    internal class BW
    {
        public static List<PKM> BWSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if (SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Eevee, (int)GameVersion.B);
                pk = AchieveFunc.fun(pk, SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Litwick, (int)GameVersion.W);
                pk = AchieveFunc.fun(pk, SAV);
                LegalityAnalysis a = new(pk);
                for (int i = 0; ; i++)
                {
                    pk.SetPIDGender(pk.Gender);
                    a = new(pk);
                    if (a.Valid)
                        break;
                }
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Reshiram, (int)GameVersion.W2);
                pk = AchieveFunc.fun(pk, SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Zekrom, (int)GameVersion.B2);
                pk = AchieveFunc.fun(pk, SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Kyurem, (int)GameVersion.W2);
                pk = AchieveFunc.fun(pk, SAV);
                a = new(pk);
                for (int i = 0; ; i++)
                {
                    pk.SetPIDGender(pk.Gender);
                    a = new(pk);
                    if (a.Valid)
                        break;
                }
                PKL.Add(pk);


            }
            return PKL;
        }
    }
}
