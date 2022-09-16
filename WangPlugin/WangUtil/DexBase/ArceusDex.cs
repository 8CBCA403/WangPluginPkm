using PKHeX.Core;
using System.Collections.Generic;
namespace WangPlugin.WangUtil.DexBase
{
    internal class ArceusDex
    {
        public static List<PKM> ArceusSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            List<int> Plate = new()
            {
                303,306,304,305,309,308,310,313,298,299,301,300,307,302,311,312,644
            };
            switch (SAV.SAV.Version)
            {
                case GameVersion.D or GameVersion.P or GameVersion.SS or GameVersion.HG or
                GameVersion.HGSS or GameVersion.DP or GameVersion.Pt or GameVersion.DPPt:
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            pk = SearchDatabase.MytheryPK(SAV, Editor, 493, 4);
                            pk.Form = (byte)i;
                            if (i > 0)
                            {
                                pk.HeldItem = Plate[i - 1];
                            }
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                        for (int i = 10; i > 9 && i < 18; i++)
                        {
                            pk = SearchDatabase.MytheryPK(SAV, Editor, 493, 4);
                            pk.Form = (byte)i;
                            pk.HeldItem = Plate[i - 2];
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                    }
                    break;
                case GameVersion.B or GameVersion.W or GameVersion.B2 or
                GameVersion.W2 or GameVersion.BW or GameVersion.B2W2:
                    {
                        for (int i = 0; i < 17; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 493, 20);
                            pk.Form = (byte)i;
                            if (i > 0)
                            {
                                pk.HeldItem = Plate[i - 1];
                            }
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
                            pk = SearchDatabase.MytheryPK(SAV, Editor, 493, 6, i);
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                        pk = SearchDatabase.MytheryPK(SAV, Editor, 493, 6);
                        pk.Form = 2;
                        pk.HeldItem = 306;
                        pk.ClearNickname();
                        PKL.Add(pk);
                        for (int i = 3; i < 16; i++)
                        {
                            pk = SearchDatabase.MytheryPK(SAV, Editor, 493, 6, i);
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                        pk = SearchDatabase.MytheryPK(SAV, Editor, 493, 6);
                        pk.Form = 16;
                        pk.HeldItem = 312;
                        pk.ClearNickname();
                        PKL.Add(pk);
                        pk = SearchDatabase.MytheryPK(SAV, Editor, 493, 6, 17);
                        pk.ClearNickname();
                        PKL.Add(pk);

                    }
                    break;
                case GameVersion.SN or GameVersion.MN or GameVersion.US
                or GameVersion.UM or GameVersion.SM or GameVersion.USUM:
                    {
                        for (int i = 0; i < 18; i++)
                        {
                            pk = SearchDatabase.MytheryPK(SAV, Editor, 493, 7);
                            pk.Form =(byte) i;
                            if(i>0)
                            {
                                pk.HeldItem = Plate[i-1];
                            }
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                    }
                    break;
                case GameVersion.PLA:
                    {
                        for (int i = 0; i < 19; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 493, 47);
                            pk.Form = (byte)i;                          
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
