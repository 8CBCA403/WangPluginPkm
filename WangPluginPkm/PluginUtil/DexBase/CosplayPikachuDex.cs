using PKHeX.Core;
using System.Collections.Generic;
namespace WangPluginPkm.PluginUtil.DexBase
{
    internal class CosplayPikachuDex
    {
        public static List<PKM> CosplayPikachuSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.OR or GameVersion.AS or GameVersion.ORAS:
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 25, 27, i, false);
                            PKL.Add(pk);
                        }
                    }
                    break;
            }
            return PKL;
        }
    }
}
