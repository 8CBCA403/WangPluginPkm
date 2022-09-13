using PKHeX.Core;
using System.Collections.Generic;
namespace WangPlugin.WangUtil.DexBase
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
                        pk =(PK8) SearchDatabase.SearchPKM(SAV, Editor, a[i], 45);
                        pk.CurrentLevel = 100;
                        pk.Species = a[i];
                        pk.CanGigantamax = true;
                        
                        if (i==24)
                        {
                            pk.Nature = 15;
                            pk.StatNature = pk.Nature;
                            pk.Form = 1;
                        }
                        else if(i==25)
                        {
                            pk.Nature = 13;
                            pk.StatNature = pk.Nature;
                            pk.Form = 0;
                        }
                        else if (i == 32)
                        {
                            pk.Ability=260;
                        }
                        else if(i==33)
                        {
                            pk.Ability=260;
                            pk.Form = 1;
                        }
                        pk.ClearNickname();
                        PKL.Add(pk);
                    }
                  
                   
                   
                    break;

            }
            return PKL;
        }
    }
}
