using PKHeX.Core;
using PKHeX.Core.AutoMod;
using System.Collections.Generic;


namespace WangPluginPkm.PluginUtil.DexBase
{
    internal class RotomDex
    {
        public static List<PKM> RotomSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case  GameVersion.SS or GameVersion.HG or GameVersion.HGSS  or GameVersion.Pt :
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 479, 12);
                            pk.Form = (byte)i;
                            PKL.Add(pk);
                        }
                    }
                    break;
                case GameVersion.B or GameVersion.W or GameVersion.B2 or
                GameVersion.W2 or GameVersion.BW or GameVersion.B2W2:
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 479, 20, 0, true);
                            pk.CurrentLevel = 50;
                            pk.Form = (byte)i;
                            pk.SetSuggestedMoves();
                            pk.HealPP();
                            PKL.Add(pk);
                        }
                    }
                    break;
                case GameVersion.X or GameVersion.Y or GameVersion.OR or
                GameVersion.AS or GameVersion.XY or GameVersion.ORAS:
                    for (int i = 0; i < 6; i++)
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 479, 24);
                        pk.Form = (byte)i;
                        PKL.Add(pk);
                    }
                    break;
                case GameVersion.SN or GameVersion.MN or GameVersion.US
                or GameVersion.UM or GameVersion.SM or GameVersion.USUM:
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 479, 30, 0, true);
                            pk.CurrentLevel = 50;
                            pk.Form = (byte)i;
                            pk.SetSuggestedMoves();
                            pk.HealPP();
                            PKL.Add(pk);
                        }
                    }
                    break;
                case GameVersion.SH or GameVersion.SW or GameVersion.SWSH:
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 479, 44, 0, true);
                            pk.Form = (byte)i;
                            pk.CurrentLevel = 50;
                            pk.SetSuggestedMoves();
                            pk.HealPP();
                            PKL.Add(pk);
                        }
                    }
                    break;
                case GameVersion.BD or GameVersion.SP or GameVersion.BDSP:
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 479, 48);
                            pk.Form = (byte)i;
                            PKL.Add(pk);
                        }
                    }
                    break;
                case GameVersion.PLA:
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 479, 47);
                            pk.Form = (byte)i;
                            var pa8 = (PA8)pk;
                            pa8.ResetHeight();
                            pa8.ResetWeight();
                            pk = pa8;
                            PKL.Add(pk);
                        }
                    }
                    break;
                case GameVersion.SL or GameVersion.VL or GameVersion.SV:
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 479, 50);
                            pk.Form = (byte)i;
                            PKL.Add(pk);
                        }
                    }
                    break;
                default:
                    break;
            }
            return PKL;
        }
    }
}
