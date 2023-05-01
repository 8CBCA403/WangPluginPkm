using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm.PluginUtil.AchieveBase.SpecificForm
{
    internal class Alola
    {
        public static List<PKM> AlolaSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                        for (int i = 722; i < 808; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, 32);
                            if(i is 805 or 797 or 795 or 780)
                                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, 33);
                            if (i is 761)
                                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, 33,0,true);
                            pk.CurrentLevel = 100;
                            pk.Species = (ushort)i;
                            if (pk.Species == 737)
                                pk.Ability = 217;
                            else if (pk.Species == 738)
                                pk.Ability = 26;
                            else if (pk.Species == 758)
                                pk.Gender = 1;
                            else if (pk.Species == 763)
                            {
                                pk.Ability = 214;
                                pk.AbilityNumber = 2;
                            }
                            else if (pk.Species == 768)
                            {
                                pk.Ability = 194;
                            }
                            else if (pk.Species == 773)
                            {
                                pk.Ability = 225;
                            }
                            else if (pk.Species == 745)
                            {
                                pk.Ability = 146;
                                pk.AbilityNumber = 2;
                            }
                            else if (pk.Species == 791)
                            {
                                pk.Ability = 230;
                            }
                            else if (pk.Species == 792)
                            {
                                pk.Ability = 231;
                            }
                            else if (pk.Species == 790)
                            {
                                pk.Ability = 5;
                            }
                            pk.ClearNickname();
                            if(pk.Species != 802 && pk.Species != 807 && pk.Species != 761)
                            pk = AchieveFunc.fun(pk,SAV);
                            PKL.Add(pk);
                        }
                    }
                    break;
            }
            return PKL;
        }
    }
}
