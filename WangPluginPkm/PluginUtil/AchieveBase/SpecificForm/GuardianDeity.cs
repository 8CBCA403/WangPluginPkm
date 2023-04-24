using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 786, 32);
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 787, 32);
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 788, 32);
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                    }
                    break;
            }
            return PKL;
        }
    }
}
