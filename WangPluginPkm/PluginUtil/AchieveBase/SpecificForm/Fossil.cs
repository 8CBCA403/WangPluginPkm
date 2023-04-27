using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm.PluginUtil.AchieveBase.SpecificForm
{
    internal class Fossil
    {
        public static List<PKM> FossilSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 138, 32);
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);

                        pk = SearchDatabase.SearchPKM(SAV, Editor, 139, 32);
                        pk.CurrentLevel = 70;
                        pk.Species = 139;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);

                        pk = SearchDatabase.SearchPKM(SAV, Editor, 140, 32);
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);

                        pk = SearchDatabase.SearchPKM(SAV, Editor, 141, 32);
                        pk.CurrentLevel = 70;
                        pk.Species = 141;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);

                        pk = SearchDatabase.SearchPKM(SAV, Editor, 142, 32);
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 345, 32);
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 346, 32);
                        pk.CurrentLevel = 70;
                        pk.Species = 346;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 347, 32);
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 348, 32);
                        pk.CurrentLevel = 70;
                        pk.Species = 348;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 408, 32);
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 409, 32);
                        pk.CurrentLevel = 70;
                        pk.Species = 409;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 410, 32);
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 411, 32);
                        pk.CurrentLevel = 70;
                        pk.Species = 411;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 564, 32);
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 565, 32);
                        pk.CurrentLevel = 70;
                        pk.Species = 565;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 566, 32);
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 567, 32);
                        pk.CurrentLevel = 70;
                        pk.Species = 567;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 696, 32);
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 697, 32);
                        pk.CurrentLevel = 70;
                        pk.Species = 697;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 698, 32);
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 699, 32);
                        pk.CurrentLevel = 70;
                        pk.Species = 699;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                    }
                    break;
            }
            return PKL;
        }
    }
}
