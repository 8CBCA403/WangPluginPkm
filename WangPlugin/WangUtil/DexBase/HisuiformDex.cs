using PKHeX.Core;
using System.Collections.Generic;

namespace WangPlugin.WangUtil.DexBase
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
