using PKHeX.Core;
using System.Collections.Generic;

namespace WangPluginPkm.PluginUtil.DexBase
{
    internal class TatsugiriDex
    {
        public static List<PKM> TatsugiriSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.SL or GameVersion.VL or GameVersion.SV:
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, (int)Species.Tatsugiri, 50, j, false);
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
