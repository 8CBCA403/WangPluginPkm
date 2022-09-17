using PKHeX.Core;
using PKHeX.Core.AutoMod;
using System.Collections.Generic;
namespace WangPlugin.WangUtil.DexBase
{
    internal class MegaDex
    {
        public static List<ushort> USUM = new()
        {   383,382,094,282,181,3,6,6,9,150,150,257,308,229,306,
            354,248,212,127,142,448,460,115,130,359,065,214,303,
            310,445,380,381,260,254,302,334,475,531,376,319,80,
            208,18,362,719,323,428,373,15,384,
        };
        public static List<ushort> XY = new()
        {   094,282,181,3,6,6,9,150,150,257,308,229,306,
            354,248,212,127,142,448,460,115,130,359,065,214,303,
            310,445,380,381
        };
        public static List<ushort> USUMn = new()
        {   3,6,6,9,15,18,65,80,94,115,127,130,142,150,150,181,
            208,212,214,229,248,254,257,260,282,302,303,306,308,
            310,319,323,334,354,359,362,373,376,380,381,382,383,
            384,428,445,448,460,475,531,719};
        public static List<int> items = new()
        {
        534,535,656,657,658,659,660,678,661,662,663,664,665,666,667,668,669,670,671,672,673,
        674,675,676,677,679, 680,681,682,683,684,685,752,753,754,755,756, 
        757,758,759,760,761,762,763,764,767,768,769,770,
        };
        public static List<int> itemsXY = new()
        {
        656,657,658,659,660,678,661,662,663,664,665,666,667,668,669,670,671,672,673,
        674,675,676,677,679, 680,681,682,683,684,685
        };
        public static List<PKM> MegaSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                        for (int i = 0; i < USUM.Count; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, USUM[i], 32, 0, true);
                            if (USUM[i] is 150 or 381 or 383 or 384)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, USUM[i], 32, 0, false, 222);
                            }
                            else if (USUM[i] is 380 or 382)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, USUM[i], 33, 0, false, 222);
                            }
                            else if (USUM[i] is 719)
                            {
                                PK6 pk6 = (PK6)SearchDatabase.SearchPKM(SAV, Editor, USUM[i], 25, 0, false);
                                pk = pk6.ConvertToPK7();
                                pk.Language = 2;
                            }
                            pk.CurrentLevel = 100;
                            pk.Species = USUM[i];
                            ModifyAbilityAndOT(ref pk);
                            if (i < 49)
                            {
                                pk.HeldItem = items[i];
                            }
                            pk.SetSuggestedMoves();
                            pk.HealPP();
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                    }
                    break;
                case GameVersion.SN or GameVersion.MN or GameVersion.SM:
                    {
                        for (int i = 0; i < USUM.Count; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, USUM[i], 30, 0, true);
                            if (USUM[i] is 150 or 381 or 383 or 384)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, USUM[i], 32, 0, false, 222);
                            }
                            else if (USUM[i] is 380 or 382)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, USUM[i], 33, 0, false, 222);
                            }
                            else if (USUM[i] is 719)
                            {
                                PK6 pk6 = (PK6)SearchDatabase.SearchPKM(SAV, Editor, USUM[i], 25, 0, false);
                                pk = pk6.ConvertToPK7();
                                pk.Language = 2;
                            }
                            pk.CurrentLevel = 100;
                            pk.Species = USUM[i];
                            ModifyAbilityAndOT(ref pk);
                            if (i < 49)
                            {
                                pk.HeldItem = items[i];
                            }
                            pk.CurrentLevel = 100;
                            pk.Species = USUM[i];
                            pk.SetSuggestedMoves();
                            pk.HealPP();
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                    }
                    break;
                case GameVersion.X or GameVersion.Y or GameVersion.XY:
                    {
                        for (int i = 0; i < XY.Count; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, XY[i], 24, 0, true);
                            if (XY[i] is 150 )
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, XY[i], 24, 0, false);
                            }
                            else if (XY[i] is 380 or 381)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, XY[i], 27, 0, false);
                            }
                            pk.CurrentLevel = 100;
                            pk.Species = XY[i];
                            ModifyAbilityAndOT(ref pk);
                            if (i < 30)
                            {
                                pk.HeldItem = itemsXY[i];
                            }
                            pk.SetSuggestedMoves();
                            pk.HealPP();
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                    }
                    break;
                case GameVersion.AS or GameVersion.OR or GameVersion.ORAS:
                    {
                        for (int i = 0; i < USUM.Count; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, USUM[i], 27, 0, true);
                            if (USUM[i] is   381 or 383 or 384 or 719)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, USUM[i], 26, 0, false);
                            }
                            else if (USUM[i] is 150)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, USUM[i], 24, 0, false);
                            }
                            else if (USUM[i] is 380 or 382)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, USUM[i], 27, 0, false);
                            }
                            pk.CurrentLevel = 100;
                            pk.Species = USUM[i];
                            ModifyAbilityAndOT(ref pk);
                            if (i < 49)
                            {
                                pk.HeldItem = items[i];
                            }
                            pk.SetSuggestedMoves();
                            pk.HealPP();
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                    }
                    break;
            }
            return PKL;
        }
        public static void ModifyAbilityAndOT(ref PKM pk)
        {
            if (pk.Species == 130)
            {
                pk.AbilityNumber = 1;
                pk.Ability = 22;
            }
            else if (pk.Species == 6)
            {
                pk.AbilityNumber = 1;
                pk.Ability = 66;
            }
            else if (pk.Species == 248)
            {
                pk.AbilityNumber = 1;
                pk.Ability = 45;
            }
            else if (pk.Species == 15)
            {
                pk.AbilityNumber = 1;
                pk.Ability = 68;
            }
            else if (pk.Species == 94)
            {
                if (pk.Version > 27)
                {
                    pk.AbilityNumber = 1;
                    pk.Ability = 130;
                }
                else
                {
                    pk.AbilityNumber = 1;
                    pk.Ability = 26;
                }
            }
            else if (pk.Species == 130)
            {
                pk.AbilityNumber = 1;
                pk.Ability = 22;
            }
            else if (pk.Species == 181)
            {
                pk.AbilityNumber = 1;
                pk.Ability = 9;
            }
            else if (pk.Species == 248)
            {
                pk.AbilityNumber = 1;
                pk.Ability = 45;
            }
            else if (pk.Species == 323)
            {
                pk.AbilityNumber = 1;
                pk.Ability = 40;
            }
            else if (pk.Species == 373)
            {
                pk.AbilityNumber = 1;
                pk.Ability = 22;
            }
            else if (pk.Species == 428)
            {
                pk.AbilityNumber = 1;
                pk.Ability = 56;
            }
            else if (pk.Species == 475)
            {
                pk.Gender = 0;
                pk.Ability = 80;

            }
            if (pk.Species == 65)
            {
                pk.OT_Name = "wang";

            }
            else if (pk.Species == 94)
            {
                pk.OT_Name = "wang";

            }
            else if (pk.Species == 208)
            {
                pk.OT_Name = "wang";

            }
            else if (pk.Species == 212)
            {
                pk.OT_Name = "wang";

            }
        }
    }
}
#region
/*            
 *              int j  = 0;
        int n = 0;
        int m = 0;
        int q = 0;
        int p = 0;
        int s = 0;
 *            if (i >= 0 && i <= 1)
            {
                pk.HeldItem = 534 + p;
                p++;
            }

            else if (i > 1 && i < 7)
            {
                pk.HeldItem = 656 + q;
                q++;
            }
            else if (i == 7)
                pk.HeldItem = 678;
            else if (i > 7 && i < 25)
            {
                pk.HeldItem = 661 + j;
                j++;
            }
            else if(i>24 &&i<32)
            {
                pk.HeldItem = 679 + s;
                s++;
            }
            else if (i > 31 && i <= 44)
            {
                pk.HeldItem = 752 + n;
                n++;
            }
            else if (i > 44 && i < 49)
            {
                pk.HeldItem = 767 + m;
                m++;
            }*/
#endregion
