using PKHeX.Core;
using System.Collections.Generic;

namespace WangPluginPkm.PluginUtil.AchieveBase.SpecificForm
{
    internal class GuardianDeity
    {
        public static List<PKM> GSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 785, 32);
                        pk = AchieveFunc.fun(pk, SAV);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 786, 32);
                        pk = AchieveFunc.fun(pk, SAV);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 787, 32);
                        pk = AchieveFunc.fun(pk, SAV);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 788, 32);
                        pk = AchieveFunc.fun(pk, SAV);
                        PKL.Add(pk);
                    }
                    break;
            }
            return PKL;
        }
    }
}
