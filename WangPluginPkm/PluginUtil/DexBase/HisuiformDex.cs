using PKHeX.Core;
using System.Collections.Generic;

namespace WangPluginPkm.PluginUtil.DexBase
{
    internal class HisuiformDex
    {
        public static List<ushort> a = new() { 58,59,100,101,157,211,215,503,549,550,570,571,628,705,706,713,724,483,484,493};
        public static List<PKM> HisuiSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PA8 pk;
            switch (SAV.SAV.Version)
            {

                case GameVersion.PLA:
                    for (int i = 0; i < a.Count; i++)
                    {
                        pk =(PA8) SearchDatabase.SearchPKM(SAV, Editor, a[i], 47, 1);
                        if (a[i]==550)
                        {
                            pk = (PA8)SearchDatabase.SearchPKM(SAV, Editor, a[i], 47, 2);
                        }
                        else if (a[i]==493)
                        {
                            pk = (PA8)SearchDatabase.SearchPKM(SAV, Editor, a[i], 47);
                            pk.Form = 18;
                        }
                        else if (a[i] == 570)
                        {
                            pk = (PA8)SearchDatabase.SearchPKM(SAV, Editor, a[i], 47,1,false,0,0,3);
                        }
                        else if (a[i] == 571)
                        {
                            pk = (PA8)SearchDatabase.SearchPKM(SAV, Editor, a[i], 47, 1, false, 0, 0, 4);
                        }
                        else if (a[i] == 705 )
                        {
                            pk = (PA8)SearchDatabase.SearchPKM(SAV, Editor, a[i], 47, 1, false, 0, 0, 3);
                        }
                        else if ( a[i] == 706)
                        {
                            pk = (PA8)SearchDatabase.SearchPKM(SAV, Editor, a[i], 47, 1, false, 0, 0, 4);
                        }
                        else if (a[i]==483)
                        {
                            pk.Form = 1;
                        }
                        else if (a[i] == 484)
                        {
                            pk.Form = 1;
                        }
                        pk.CurrentLevel = 100;
                        pk.Species = a[i];
                        pk.ResetHeight();
                        pk.ResetWeight();
                        pk.ClearNickname();
                        PKL.Add(pk);
                    }
                    break;

            }
            return PKL;
        }
    }
}
