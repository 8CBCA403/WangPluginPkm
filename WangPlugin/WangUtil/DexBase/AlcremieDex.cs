using PKHeX.Core;
using System.Collections.Generic;
namespace WangPlugin.WangUtil.DexBase
{
    internal class AlcremieDex
    {
        public static List<PKM> AlcremieSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PK8 pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.SW or GameVersion.SH or GameVersion.SWSH:
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                pk =(PK8) SearchDatabase.SearchPKM(SAV, Editor, 868, 45, 0, true);
                                pk.CurrentLevel = 50;
                                pk.Species = 869;
                                pk.Form = (byte)i;
                                pk.FormArgument = (byte)j;
                                pk.ClearNickname();
                                PKL.Add(pk);
                            }
                        }
                    }
                    break;
            }
            return PKL;
        }
    }
}
