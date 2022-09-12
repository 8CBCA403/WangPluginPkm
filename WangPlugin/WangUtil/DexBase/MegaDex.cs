using PKHeX.Core;
using PKHeX.Core.AutoMod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPlugin.WangUtil.DexBase
{
    internal class MegaDex
    {
        public static List<ushort> USUM = new()
        {   3,6,6,9,15,18,65,80,94,115,127,130,142,150,150,181,
            208,212,214,229,248,254,257,260,282,302,303,306,308,
            310,319,323,334,354,359,362,373,376,380,381,382,383,
            384,428,445,448,460,475,531,719};
        public static List<PKM> MegaSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM:
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
                        }
                        if (USUM[i] == 323)
                        {
                            pk.AbilityNumber = 1;
                            pk.Ability = 40;
                        }
                        else if (USUM[i] == 373)
                        {
                            pk.AbilityNumber = 1;
                            pk.Ability = 22;
                        }
                        else if (USUM[i] == 428)
                        {
                            pk.AbilityNumber = 1;
                            pk.Ability = 56;
                        }
                        else if (USUM[i] == 475)
                        {
                            pk.Gender = 0;
                            pk.Ability = 80;

                        }
                        pk.CurrentLevel = 100;
                        pk.Species = USUM[i];
                        pk.SetSuggestedMoves();
                        pk.HealPP();
                        //if (USUM[i]<306)
                        //pk.HeldItem = 659 + i;
                        pk.ClearNickname();
                        PKL.Add(pk);
                    }
                    break;
                case GameVersion.SN or GameVersion.MN:
                    for (int i = 0; i < USUM.Count; i++)
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, USUM[i], 30, 0, true);
                        if (USUM[i] is 150  or 381  or 383 or 384)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, USUM[i], 32, 0, false,222);
                        }
                        else if (USUM[i] is  380  or 382 )
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, USUM[i], 33, 0, false,222);
                        }
                        else if (USUM[i] is 719 )
                        {
                            PK6 pk6 = (PK6)SearchDatabase.SearchPKM(SAV, Editor, USUM[i], 25, 0, false);
                            pk = pk6.ConvertToPK7();
                        }

                        if (USUM[i] == 323)
                        {
                            pk.AbilityNumber = 1;
                            pk.Ability = 40;
                        }
                        else if (USUM[i] == 373)
                        {
                            pk.AbilityNumber = 1;
                            pk.Ability = 22;
                        }
                        else if (USUM[i] == 428)
                        {
                            pk.AbilityNumber = 1;
                            pk.Ability = 56;
                        }
                        else if (USUM[i] == 475)
                        {
                            pk.Gender = 0;
                            pk.Ability = 80;
                            
                        }
                        pk.CurrentLevel = 100;
                        pk.Species = USUM[i];
                        pk.SetSuggestedMoves();
                        pk.HealPP();
                        //if (USUM[i]<306)
                        //pk.HeldItem = 659 + i;
                        pk.ClearNickname();
                        PKL.Add(pk);
                    }
                    break;

            }
            return PKL;
        }
    }
}
