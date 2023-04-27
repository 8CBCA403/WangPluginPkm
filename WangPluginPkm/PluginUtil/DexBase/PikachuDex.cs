using PKHeX.Core;
using System.Collections.Generic;


namespace WangPluginPkm.PluginUtil.DexBase
{
    internal class CapPikachuDex
    {
        public static List<PKM> CapPikachuSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            var pk = Editor.Data;
            switch (SAV.SAV.Version)
            {
                case GameVersion.SN or GameVersion.MN or GameVersion.SM:
                    for (int i = 0; i < 7; i++)
                    {
                        pk = SearchDatabase.MytheryPK(SAV, 25, 7, i);
                        PKL.Add(pk);
                    }
                    break;
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    for (int i = 0; i < 8; i++)
                    {
                        pk = SearchDatabase.MytheryPK(SAV, 25, 7, i);
                        PKL.Add(pk);
                    }
                    break;
                case GameVersion.SW or GameVersion.SH or GameVersion.SWSH:
                    for (int i = 0; i < 8; i++)
                    {
                        pk = SearchDatabase.MytheryPK(SAV, 25,8, i);
                        PKL.Add(pk);
                    }
                    pk = SearchDatabase.MytheryPK(SAV, 25, 8, 9);
                    PKL.Add(pk);
                    break;

            }
            return PKL;
        }
    }
}
