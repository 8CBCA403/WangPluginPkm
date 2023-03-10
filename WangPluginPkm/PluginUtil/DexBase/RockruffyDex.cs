using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm.WangUtil.DexBase
{
    internal class RockruffyDex
    {
        public static List<PKM> RockruffySets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.SN or GameVersion.MN or GameVersion.SM:
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 744, 30, 0, false);
                        pk.ClearNickname();
                        PKL.Add(pk);
                        for(int i=0;i<2;i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 744, 30+i, i, false);
                            pk.CurrentLevel = 50;
                            pk.Species = 745;
                            pk.Form =(byte) i;
                            if(i==0)
                            {
                                pk.Ability = 146;
                                pk.AbilityNumber = 2;
                            }
                            else if(i==1)
                            {
                                pk.Ability = 72;
                                pk.AbilityNumber = 2;
                            }
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
 
                    }
                    break;
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 744, 32, 0, false);
                        pk.ClearNickname();
                        PKL.Add(pk);
                        pk = SearchDatabase.MytheryPK(SAV, 744, 7, 1);
                        pk.ClearNickname();
                        PKL.Add(pk);
                        for (int i = 0; i < 2; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 744, 32 + i, 0, false);
                            pk.CurrentLevel = 50;
                            pk.Species = 745;
                            pk.Form = (byte)i;
                            if (i == 0)
                            {
                                pk.Ability = 146;
                                pk.AbilityNumber = 2;
                            }
                            else if (i == 1)
                            {
                                pk.Ability = 72;
                                pk.AbilityNumber = 2;
                            }
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                        pk = SearchDatabase.MytheryPK(SAV, 744, 7, 1);
                        pk.CurrentLevel = 50;
                        pk.Species = 745;
                        pk.Form = 2;
                        pk.Ability = 181;
                        pk.AbilityNumber = 1;
                        pk.ClearNickname();
                        PKL.Add(pk);

                    }
                    break;
                case GameVersion.SW or GameVersion.SH or GameVersion.SWSH:
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 744, 45, 0, true);
                        pk.ClearNickname();
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 744, 45, 0, true);
                        pk.Form = 1;
                        pk.Ability = 20;
                        pk.AbilityNumber = 1;
                        pk.ClearNickname();
                        PKL.Add(pk);
                        for (int i = 0; i < 3; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 744, 45, 0, true);
                            pk.CurrentLevel = 50;
                            pk.Species = 745;
                            pk.Form = (byte)i;

                            if (i == 0)
                            {
                                pk.Ability = 146;
                                pk.AbilityNumber = 2;
                            }
                            else if (i == 1)
                            {
                                pk.Ability = 72;
                                pk.AbilityNumber = 2;
                            }
                            else if (i == 2)
                            {
                                pk.Ability = 181;
                                pk.AbilityNumber = 2;
                            }
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                       
                    }
                    break;
            }
            return PKL;
        }
    }
}
