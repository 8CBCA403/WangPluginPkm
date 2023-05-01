using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm.PluginUtil.AchieveBase.SpecificForm
{
    internal class UltraBeast
    {
        public static List<PKM> UltraSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM  or GameVersion.USUM:
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 793, 32);
                        pk=AchieveFunc.fun(pk,SAV);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 794, 32);
                        pk = AchieveFunc.fun(pk,SAV);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 795, 33);
                        pk = AchieveFunc.fun(pk,SAV);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 796, 32);
                        pk = AchieveFunc.fun(pk,SAV);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 797, 33);
                        pk = AchieveFunc.fun(pk,SAV);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 798, 32);
                        pk = AchieveFunc.fun(pk,SAV);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 799, 32);
                        pk = AchieveFunc.fun(pk,SAV);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 800, 32);
                        pk = AchieveFunc.fun(pk,SAV);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 803, 32);
                        pk = AchieveFunc.fun(pk,SAV);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 804, 32);
                        pk.CurrentLevel = 70;
                        pk.Species = 804;
                        pk = AchieveFunc.fun(pk,SAV);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 805, 33);
                        pk = AchieveFunc.fun(pk,SAV);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 806, 32);
                        pk = AchieveFunc.fun(pk,SAV);
                        PKL.Add(pk);
                    }
                    break;
            }
            return PKL;
        }
    }
}
