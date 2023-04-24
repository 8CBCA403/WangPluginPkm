using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm.PluginUtil.AchieveBase.SpecificForm
{
    internal class Eevee
    {
        public static List<PKM> EeveeSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 133, 32);
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 133, 32);
                        pk.Species = 134;
                        pk.Ability = 11;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 133, 32);
                        pk.Species = 135;
                        pk.Ability = 10;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 133, 32);
                        pk.Species = 136;
                        pk.Ability = 18;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 133, 32);
                        pk.Species = 196;
                        pk.Ability = 28;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 133, 32);
                        pk.Species = 197;
                        pk.Ability = 28;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 133, 32);
                        pk.Species = 470;
                        pk.Ability = 102;
                        pk.CurrentLevel = 50;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 133, 32);
                        pk.Species = 471;
                        pk.Ability = 81;
                        pk.CurrentLevel = 50;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 133, 32);
                        pk.Species = 700;
                        pk.Ability = 56;
                        pk.CurrentLevel = 50; 
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                        break;
                    }
            }
            return PKL;
        }
    }
}
