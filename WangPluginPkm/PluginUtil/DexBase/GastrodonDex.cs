using PKHeX.Core;
using System.Collections.Generic;

namespace WangPluginPkm.PluginUtil.DexBase
{
    internal class GastrodonDex
    {
        public static List<PKM> GastrodonSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.D or GameVersion.P or GameVersion.SS or GameVersion.HG or
                GameVersion.HGSS or GameVersion.DP or GameVersion.Pt or GameVersion.DPPt:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(422 + i), 10, 0, true);
                                pk.Form = (byte)j;
                                if (i == 1)
                                {
                                    pk = Edit(pk);
                                }
                                pk.ClearNickname();
                                PKL.Add(pk);
                            }
                        }
                    }
                    break;
                case GameVersion.B or GameVersion.W or GameVersion.B2 or
                GameVersion.W2 or GameVersion.BW or GameVersion.B2W2:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(422 + i), 20);
                                pk.Form = (byte)j;
                                if (i == 1)
                                {
                                    pk = Edit(pk);
                                    pk.Ability = 159;
                                    pk.AbilityNumber = 4;
                                }
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
                            for (int j = 1; j < 2; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(422 + i), 26, j);
                                pk.Form = (byte)j;
                                if (i == 1)
                                {
                                    pk = Edit(pk);
                                }
                                pk.ClearNickname();
                                PKL.Add(pk);
                            }
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 1; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(422 + i), 27, j);
                                pk.Form = (byte)j;
                                if (i == 1)
                                {
                                    pk = Edit(pk);
                                }
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
                            for (int j = 0; j < 2; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(422 + i), 30, 0, true);
                                pk.Form = (byte)j;
                                if (i == 1)
                                {
                                    pk = Edit(pk);
                                }
                                pk.ClearNickname();
                                PKL.Add(pk);
                            }
                        }
                    }
                    break;
                case GameVersion.SH or GameVersion.SW or GameVersion.SWSH:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, 422, 44, i, true);
                                pk.Form = (byte)j;
                                if (i == 1)
                                {
                                    pk = Edit(pk);
                                }
                                pk.ClearNickname();
                                PKL.Add(pk);
                            }
                        }
                    }
                    break;
                case GameVersion.BD or GameVersion.SP or GameVersion.BDSP:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, 422, 48, i, true);
                                pk.Form = (byte)j;
                                if (i == 1)
                                {
                                    pk = Edit(pk);
                                }
                                pk.ClearNickname();
                                PKL.Add(pk);
                            }
                        }
                    }
                    break;
                case GameVersion.PLA:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(422 + i), 47, j);
                                pk.Form = (byte)j;
                                if (i == 1)
                                {
                                    pk = Edit(pk);
                                    var pa8 = (PA8)pk;
                                    pa8.ResetHeight();
                                    pa8.ResetWeight();
                                    pk = pa8;
                                }
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
            pk.Species = 423;
            pk.Ability = 60;
            pk.AbilityNumber = 1;
            return pk;
        }
    }
}
