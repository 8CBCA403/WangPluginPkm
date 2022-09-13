using PKHeX.Core;
using System.Collections.Generic;

namespace WangPlugin.WangUtil.DexBase
{
    internal class DeerlingDex
    {
        public static List<PKM> DeerlingSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.B or GameVersion.W or GameVersion.B2 or
              GameVersion.W2 or GameVersion.BW or GameVersion.B2W2:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, 585, 20, j, false);
                                {
                                    if (i == 1)
                                    {
                                        pk = Edit(pk);
                                    }
                                }
                                pk.Form = (byte)j;
                                pk.ClearNickname();
                                PKL.Add(pk);
                            }
                        }
                    }
                    break;
                    case GameVersion.X or GameVersion.Y or GameVersion.OR or
                GameVersion.AS or GameVersion.XY or GameVersion.ORAS:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, 585, 24, j, true);
                                {
                                    if (i == 1)
                                    {
                                        pk = Edit(pk);
                                    }
                                }
                                pk.Form = (byte)j;
                                pk.ClearNickname();
                                PKL.Add(pk);
                            }
                        }
                    }
                    break;
                case GameVersion.SN or GameVersion.MN or GameVersion.US
                or GameVersion.UM or GameVersion.SM or GameVersion.USUM:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, 585, 30, j, true);
                                {
                                    if (i == 1)
                                    {
                                        pk = Edit(pk);
                                    }
                                }
                                pk.Form = (byte)j;
                                pk.ClearNickname();
                                PKL.Add(pk);
                            }
                        }
                    }
                    break;
            }
            return PKL;
         }
        public static PKM Edit(PKM pk)
        {
            pk.CurrentLevel = 50;
            pk.Species = 586;
            return pk;
        }
    }
}
