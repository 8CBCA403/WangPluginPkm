using PKHeX.Core;
using System.Collections.Generic;
namespace WangPluginPkm.WangUtil.DexBase
{
    internal class BurmyDex
    {
        public static List<PKM> BurmySets(ISaveFileProvider SAV, IPKMView Editor)
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
                            for (int j = 0; j < 3; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(412), 10,0,false,0,1);
                                pk.Form = (byte)j;
                                if (i == 1)
                                {
                                   pk= Edit(pk);
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
                            for (int j = 0; j < 3; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(412), 20,0,false,0,1);
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
                case GameVersion.X or GameVersion.Y or GameVersion.OR or
                GameVersion.AS or GameVersion.XY or GameVersion.ORAS:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(412 + i), 24, 0, true, 0, 1);
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
                            for (int j = 0; j < 3; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(412 + i), 30, 0, true, 0, 1);
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
                            for (int j = 0; j < 3; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(412 + i), 48, 0, false, 0, 1);
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
                            for (int j = 0; j < 3; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(412 + i), 47, 0, false, 0, 1);
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
            pk.Species = 413;
            pk.Ability = 107;
            pk.AbilityNumber = 1;
            return pk;
        }
    }
}
