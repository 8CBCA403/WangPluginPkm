using PKHeX.Core;
using System.Collections.Generic;
namespace WangPluginPkm.WangUtil.DexBase
{
    internal class IncarnateDex
    {
        public static List<PKM> IncarnateSets(ISaveFileProvider SAV, IPKMView Editor)
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
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 641, 21);
                            pk.Form = (byte)i;
                            if (i == 1)
                                pk.Ability = 144;
                            pk.ClearNickname();
                            PKL.Add(pk);
                         }
                        for (int i = 0; i < 2; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 642, 20);
                            pk.Form = (byte)i;
                            if (i == 1)
                                pk.Ability = 10;
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 645, 20);
                            pk.Form = (byte)i;
                            if (i == 1)
                                pk.Ability = 22;
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }

                    }
                    break;
                case GameVersion.X or GameVersion.Y or GameVersion.OR or
                GameVersion.AS or GameVersion.XY or GameVersion.ORAS:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 641, 27);
                            pk.Form = (byte)i;
                            if (i == 1)
                                pk.Ability = 144;
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 642, 26);
                            pk.Form = (byte)i;
                            if (i == 1)
                                pk.Ability = 10;
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 645, 27);
                            pk.Form = (byte)i;
                            if (i == 1)
                                pk.Ability = 22;
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }

                    }
                    break;
                case GameVersion.SN or GameVersion.MN or GameVersion.US
                or GameVersion.UM or GameVersion.SM or GameVersion.USUM:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 641, 32);
                            pk.Form = (byte)i;
                            if (i == 1)
                                pk.Ability = 144;
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 642, 33);
                            pk.Form = (byte)i;
                            if (i == 1)
                                pk.Ability = 10;
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 645, 32);
                            pk.Form = (byte)i;
                            if (i == 1)
                                pk.Ability = 22;
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }

                    }
                    break;
                case GameVersion.PLA:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            PA8 pa8 =(PA8) SearchDatabase.SearchPKM(SAV, Editor, 641, 47);
                            pa8.Form = (byte)i;
                            if (i == 1)
                                pa8.Ability = 144;
                            pa8.ResetHeight();
                            pa8.ResetWeight();
                            pa8.ClearNickname();
                            PKL.Add(pa8);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            PA8 pa8 = (PA8)SearchDatabase.SearchPKM(SAV, Editor, 642, 47);
                            pa8.Form = (byte)i;
                            if (i == 1)
                                pa8.Ability = 10;
                            pa8.ResetHeight();
                            pa8.ResetWeight();
                            pa8.ClearNickname();
                            PKL.Add(pa8);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            PA8 pa8 =(PA8) SearchDatabase.SearchPKM(SAV, Editor, 645, 47);
                            pa8.Form = (byte)i;
                            if (i == 1)
                                pa8.Ability = 22;
                            pa8.ResetHeight();
                            pa8.ResetWeight();
                            pa8.ClearNickname();
                            PKL.Add(pa8);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            PA8 pa8 = (PA8)SearchDatabase.SearchPKM(SAV, Editor, 905, 47);
                            pa8.Form = (byte)i;
                            if (i == 1)
                                pa8.Ability = 142;
                            pa8.ResetHeight();
                            pa8.ResetWeight();
                            pa8.ClearNickname();
                            PKL.Add(pa8);
                        }

                    }
                    break;
            }
            return PKL;
        }
    }
}
