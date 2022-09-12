using PKHeX.Core;
using System.Collections.Generic;


namespace WangPlugin.WangUtil.DexBase
{
    internal class GalarformDex
    {
        public static List<ushort> a = new List<ushort>
               { 52,77,78,79,80,83,110,122,
                144,145,146,199,222,263,264,554,555,562,618
                };
        public static List<PKM> GalarSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {

                case GameVersion.SW or GameVersion.SH :
                    for (int i = 0; i < a.Count; i++)
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, a[i], 44, 1, true);
                        if (a[i]==52)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, a[i], 44, 2, true);
                        }
                        else if (a[i] is 144 or 145 or 146)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, a[i], 44, 1, false);
                        }
                        else if (a[i]==555)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, a[i], 45, 2, false);
                        }
                       
                        pk.CurrentLevel = 100;
                        pk.Species = a[i];
                        pk.ClearNickname();
                        PKL.Add(pk);
                    }
                    break;

            }
            return PKL;
        }
    }
}
