using PKHeX.Core;
using System.Collections.Generic;
namespace WangPluginPkm.PluginUtil.DexBase
{
    internal class GigamaxDex
    {
        public static List<ushort> a = new List<ushort>
               { 3 , 6 , 9 ,12 , 25  ,52 , 68, 99
                 ,94,  131  ,133,  143 , 569 , 809  ,812 ,
                 815  ,818,  823 , 826,  834 , 839 , 841 ,
                 842 , 844 ,849,849, 851,  858 , 861 , 869 , 879 ,
                 884,  892,892
                };
        public static List<PKM> GigamaxSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PK8 pk ;
            switch (SAV.SAV.Version)
            {
                case GameVersion.SW or GameVersion.SH or GameVersion.SWSH:
                    for (int i = 0; i < a.Count; i++)
                    {
                        pk =(PK8) SearchDatabase.SearchPKM(SAV, Editor, a[i], 45,0,true);
                        if (a[i]==892)
                            pk = (PK8)SearchDatabase.SearchPKM(SAV, Editor, a[i], 45);
                        else if (a[i]==809)
                            pk = (PK8)SearchDatabase.SearchPKM(SAV, Editor, a[i], 45);
                        pk.CurrentLevel = 100;
                        pk.Species = a[i];
                        ModifyAbilityAndOT(ref pk,i);
                        pk.CanGigantamax = true;
                        pk.ClearNickname();
                        PKL.Add(pk);
                    }
                    break;
            }
            return PKL;
        }
        public static void ModifyAbilityAndOT(ref PK8 pk,int i)
        {
            if(pk.Species==12)
            {
                pk.Ability = 14;
                pk.AbilityNumber = 1;
            }
            else if(pk.Species==68)
            {
                pk.OT_Name = "wang";
            }
            else if (i==24)
            {
                pk.Nature = 15;
                pk.StatNature = pk.Nature;
                pk.Form = 1;
                pk.Ability = 58;
                pk.AbilityNumber = 2;
            }
            else if (i==25)
            {
                pk.Nature = 13;
                pk.StatNature = pk.Nature;
                pk.Form = 0;
                pk.Ability = 244;
                pk.AbilityNumber = 1;
            }
            else if (i==32)
            {
                pk.Ability = 260;
                pk.AbilityNumber = 1;
            }
            else if (i==33)
            {
                pk.Ability = 260;
                pk.AbilityNumber = 1;
                pk.Form = 1;
            }
            else if (pk.Species == 94)
            {
                pk.Ability = 130;
                pk.AbilityNumber = 1;
                pk.OT_Name = "wang";
            }
            else if (pk.Species == 143)
            {
                pk.Ability = 17;
                pk.AbilityNumber = 1;
            }
            else if (pk.Species == 569)
            {
                pk.Ability = 133;
                pk.AbilityNumber = 2;
            }
            else if (pk.Species == 823)
            {
                pk.Ability = 46;
                pk.AbilityNumber = 1;
            }
            else if (pk.Species == 826)
            {
                pk.Ability = 119;
                pk.AbilityNumber = 2;
            }
            else if (pk.Species == 839)
            {
                pk.Ability = 49;
                pk.AbilityNumber = 2;
            }

        }
    }
}
