using PKHeX.Core;
using PKHeX.Core.AutoMod;
using System;
using System.Collections.Generic;
using System.Linq;
using WangPluginPkm.GUI;
using WangPluginPkm.PluginUtil.AchieveBase;
using WangPluginPkm.RNG.Methods;

namespace WangPluginPkm.PluginUtil.MeerkatBase
{
    internal class MutiGenDex
    {
        public static List<PKM> SetGen1(ISaveFileProvider SAV, IPKMView Editor, bool shiny)
        {
            if (SAV.SAV is SAV7 s)
            {
                s.ConsoleRegion = 1;
                s.Country = 49;
            }

            var PKL = new List<PKM>();
            for (int i = 1; i < 152; i++)
            {
                PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, (int)GameVersion.RD));
            }
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    PKL[i] = EntityConverter.ConvertToType(PKL[i], SAV.SAV.PKMType, out _);
                    Random random = new Random();
                    int rand = random.Next(0, 5);
                    uint ran = (uint)random.Next(2, 8);
                    PKL[i].EXP = PKL[i].EXP + ran;
                    PKL[i].Nature = Experience.GetNatureVC(PKL[i].EXP);
                    switch (rand)
                    {
                        case 0:
                            PKL[i].Version = GameVersion.YW;
                            break;
                        case 1:
                            PKL[i].Version = GameVersion.GN;
                            break;
                        case 2:
                            PKL[i].Version = GameVersion.GN;
                            break;
                        case 4:
                            PKL[i].Version = GameVersion.YW;
                            break;
                        case 5:
                            PKL[i].Version = GameVersion.RD;
                            break;
                    }
                    switch (i)
                    {
                        case 1:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 2:
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 4:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 5:
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 7:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 8:
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 11:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 13:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 14:
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 16:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 17:
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 19:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 21:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 23:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 25:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 26:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Sandshrew, (int)GameVersion.YW);
                            PKL[i].Version = GameVersion.YW;
                            break;
                        case 27:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Sandshrew, (int)GameVersion.YW);
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            PKL[i].Version = GameVersion.YW;
                            break;
                        case 30:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);

                            break;
                        case 33:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 35:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);

                            break;
                        case 37:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);

                            break;
                        case 41:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 43:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);

                            break;
                        case 44:
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 46:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Paras, (int)GameVersion.RD);
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 48:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 50:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Diglett, (int)GameVersion.RD);
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 51:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Meowth, (int)GameVersion.GN);
                            PKL[i].Version = GameVersion.GN;
                            break;
                        case 52:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Meowth, (int)GameVersion.GN);
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            PKL[i].Version = GameVersion.GN;
                            break;
                        case 54:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 56:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 58:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 59:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Poliwag, (int)GameVersion.RD, 0, false, 0, 0, 0, 15);
                            break;
                        case 60:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Poliwag, (int)GameVersion.RD, 0, false, 0, 0, 0, 15);
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 61:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Poliwag, (int)GameVersion.RD, 0, false, 0, 0, 0, 15);
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 63:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 64:
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 66:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Machop, (int)GameVersion.RD, 0, false, 0, 0, 0, 24);
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 67:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Machop, (int)GameVersion.RD, 0, false, 0, 0, 0, 24);
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 68:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Bellsprout, (int)GameVersion.GN);
                            break;
                        case 69:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Bellsprout, (int)GameVersion.GN);
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 70:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Bellsprout, (int)GameVersion.GN);
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 72:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 74:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Geodude, (int)GameVersion.RD);
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 75:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Geodude, (int)GameVersion.RD);
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 77:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 79:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 82:
                            PKL[i].Nickname = "DUX";
                            PKL[i].IsNicknamed = true;
                            break;
                        case 84:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 86:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 88:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Grimer, (int)GameVersion.RD);
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 90:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 92:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Gastly, (int)GameVersion.RD);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 93:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Gastly, (int)GameVersion.RD);
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 96:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 98:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 100:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 102:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 109:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 111:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Rhyhorn, (int)GameVersion.RD);
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 116:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 118:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 120:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 125:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Magmar, (int)GameVersion.GN);
                            break;
                        case 129:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 133:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 134:
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 135:
                            PKL[i] = AchieveFunc.evo3H(PKL[i]);
                            break;
                        case 138:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 140:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 147:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 148:
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                    }
                    PKL[i].Language = 2;
                    if (i != 82)
                        PKL[i].ClearNickname();
                    if (i == 150 && shiny)
                    {
                        PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Mew, (int)GameVersion.E);
                        PKL[i] = AchieveFunc.fun(PKL[i], SAV);
                        PKL[i].OriginalTrainerName = "Meerk";
                        PKL[i].AbilityNumber = 1;
                    }
                    else if (i != 150 && i != 82)
                    {
                        PKL[i] = AchieveFunc.fun(PKL[i], SAV);
                    }
                    PKL[i].SetSuggestedMoves(true);
                    PKL[i].HealPP();

                    if (i == 131)
                    {
                        PKL[i].Move1 = 144;
                        PKL[i].Move2 = 0;
                        PKL[i].Move3 = 0;
                        PKL[i].Move4 = 0;
                        PKL[i].HealPP();
                    }
                    if (shiny)
                    {
                        PKL[i] = ShinyMakerUI.ShinyFunctionPlus(PKL[i]);
                    }

                }
            }
            SAV.ReloadSlots();
            return PKL;
        }
        public static List<PKM> SetGen2(ISaveFileProvider SAV, IPKMView Editor, bool shiny)
        {
            if (SAV.SAV is SAV7 s)
            {
                s.ConsoleRegion = 1;
                s.Country = 49;
            }
            var PKL = new List<PKM>();
            for (int i = 152; i < 252; i++)
            {
                if (i != 251)
                    PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, (int)GameVersion.GD));
                else
                    PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, (int)GameVersion.C));
            }
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    PKL[i] = EntityConverter.ConvertToType(PKL[i], SAV.SAV.PKMType, out var r2);
                    if (i != 99)
                    {
                        Random random = new Random();
                        int rand = random.Next(0, 5);
                        uint ran = (uint)random.Next(2, 8);
                        PKL[i].EXP = PKL[i].EXP + ran;
                        PKL[i].Nature = Experience.GetNatureVC(PKL[i].EXP);
                        switch (rand)
                        {
                            case 0:
                                PKL[i].Version = (GameVersion)39;
                                break;
                            case 1:
                                PKL[i].Version = (GameVersion)40;
                                break;
                            case 2:
                                PKL[i].Version = (GameVersion)39;
                                break;
                            case 4:
                                PKL[i].Version = (GameVersion)41;
                                break;
                            case 5:
                                PKL[i].Version = (GameVersion)41;
                                break;
                        }
                    }
                    switch (i)
                    {
                        case 1:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 2:
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 4:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 5:
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 7:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 8:
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 10:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 12:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 13:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 165, (int)GameVersion.SI);
                            break;
                        case 14:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 165, (int)GameVersion.SI);
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 16:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 17:
                            PKL[i].Species = 169;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(2);
                            break;
                        case 19:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 20:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 172, (int)GameVersion.SI, 0, true);
                            break;
                        case 21:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 173, (int)GameVersion.SI, 0, true);
                            break;
                        case 22:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 174, (int)GameVersion.SI, 0, true);
                            break;
                        case 23:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 175, (int)GameVersion.SI, 0, true);
                            break;
                        case 24:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 175, (int)GameVersion.SI, 0, true);
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 28:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 29:
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 30:
                            PKL[i].Species = 182;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(2);
                            break;
                        case 32:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 34:
                            PKL[i].Species = 186;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(2);
                            break;
                        case 36:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 37:
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 40:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 44:
                            PKL[i].Species = 196;
                            PKL[i].CurrentLevel = 26;
                            PKL[i].RefreshAbility(2);
                            break;
                        case 45:
                            PKL[i].Species = 197;
                            PKL[i].CurrentLevel = 26;
                            PKL[i].RefreshAbility(2);
                            break;
                        case 47:
                            PKL[i].Species = 199;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(2);
                            break;
                        case 53:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 56:
                            PKL[i].Species = 208;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(2);
                            break;
                        case 58:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 65:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 67:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 69:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 72:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 73:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 224, (int)GameVersion.SI);
                            break;
                        case 75:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 227, (int)GameVersion.SI);
                            break;
                        case 77:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 78:
                            PKL[i].Species = 230;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(2);
                            break;
                        case 79:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 231, (int)GameVersion.SI);
                            break;
                        case 80:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 231, (int)GameVersion.SI);
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 85:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 86:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 238, (int)GameVersion.SI, 0, true);
                            break;
                        case 87:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 239, (int)GameVersion.SI, 0, true);
                            break;
                        case 88:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 240, (int)GameVersion.SI, 0, true);
                            break;
                        case 90:
                            PKL[i].Species = 242;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(2);
                            break;
                        case 95:
                            PKL[i] = AchieveFunc.evo1H(PKL[i]);
                            break;
                        case 96:
                            PKL[i] = AchieveFunc.evo2H(PKL[i]);
                            break;
                        case 98:
                            PKL[i].CurrentLevel = 70;
                            PKL[i].MetLevel = 70;
                            break;
                    }
                    if (i != 26 && i != 56)
                    {
                        PKL[i].ClearNickname();
                        PKL[i] = AchieveFunc.fun(PKL[i], SAV);
                    }
                    PKL[i].SetSuggestedMoves(true);
                    PKL[i].HealPP();
                    if (i == 83)
                    {
                        PKL[i].Move1 = 166;
                        PKL[i].Move2 = 0;
                        PKL[i].Move3 = 0;
                        PKL[i].Move4 = 0;
                        PKL[i].HealPP();
                    }
                    if (i == 49)
                    {
                        PKL[i].Move1 = 237;
                        PKL[i].Move2 = 0;
                        PKL[i].Move3 = 0;
                        PKL[i].Move4 = 0;
                        PKL[i].HealPP();
                    }
                    if (shiny)
                    {
                        PKL[i] = ShinyMakerUI.ShinyFunctionPlus(PKL[i]);
                    }

                }
            }
            SAV.ReloadSlots();
            return PKL;
        }
        public static List<PKM> SetGen3(ISaveFileProvider SAV, IPKMView Editor, bool shiny)
        {
            if (SAV.SAV is SAV7 s)
            {
                s.ConsoleRegion = 1;
                s.Country = 49;
            }
            var PKL = new List<PKM>();
            for (int i = 252; i < 387; i++)
            {
                PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, (int)GameVersion.E));
            }
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    PKL[i] = EntityConverter.ConvertToType(PKL[i], SAV.SAV.PKMType, out _);
                    switch (i)
                    {
                        case 1:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 2:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 4:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 5:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 7:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 8:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 10:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 12:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 14:
                            while (true)
                            {
                                PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)265, (int)GameVersion.E);
                                var val = WurmpleUtil.GetWurmpleEvoVal(PKL[i].EncryptionConstant);
                                if (val == 0)
                                    break;
                            }
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 15:
                            while (true)
                            {
                                PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)265, (int)GameVersion.E);
                                var val = WurmpleUtil.GetWurmpleEvoVal(PKL[i].EncryptionConstant);
                                if (val == 0)
                                    break;
                            }
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 16:
                            while (true)
                            {
                                PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)265, (int)GameVersion.E);
                                var val = WurmpleUtil.GetWurmpleEvoVal(PKL[i].EncryptionConstant);
                                if (val == WurmpleEvolution.Cascoon)
                                    break;
                            }
                            PKL[i] = AchieveFunc.evo3(PKL[i]);
                            break;
                        case 17:
                            while (true)
                            {
                                PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)265, (int)GameVersion.E);
                                var val = WurmpleUtil.GetWurmpleEvoVal(PKL[i].EncryptionConstant);
                                if (val == WurmpleEvolution.Cascoon)
                                    break;
                            }
                            PKL[i] = AchieveFunc.evo4(PKL[i]);
                            break;
                        case 19:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 20:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 21:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)273, (int)GameVersion.E, 0, false, 0, 0, 0, 3);
                            break;
                        case 22:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)273, (int)GameVersion.E, 0, false, 0, 0, 0, 3);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 23:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)273, (int)GameVersion.E, 0, false, 0, 0, 0, 3);
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 25:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 27:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 29:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 30:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 32:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 34:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 36:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 37:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 39:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 40:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].Gender = 2;
                            break;
                        case 42:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 43:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 45:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 46:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)298, (int)GameVersion.E, 0, true);
                            break;
                        case 49:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 53:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 54:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 55:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)307, (int)GameVersion.R);
                            break;
                        case 56:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)307, (int)GameVersion.R);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 58:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 59:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)311, (int)GameVersion.E, 0, false, 0, 0, 0, 12); ;
                            break;
                        case 63:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)315, (int)GameVersion.R); ;
                            break;
                        case 65:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 69:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 80;
                            break;
                        case 71:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 74:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 77:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 78:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 80:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 82:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 83:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)335, (int)GameVersion.R); ;
                            break;
                        case 85:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)337, (int)GameVersion.S); ;
                            break;
                        case 88:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 90:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 92:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 94:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 96:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 98:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            if (PKL[i] is IContestStats a)
                            {
                                a.ContestBeauty = 255;
                            }
                            break;
                        case 102:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 104:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 110:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 112:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 113:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 115:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 116:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 120:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 121:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 123:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 124:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 133:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)385, (int)GameVersion.R);
                            if (shiny)
                            {
                                PKL[i].PID = 1177749629;
                                PKL[i].EncryptionConstant = 1177749629;
                                PKL[i].Nature = (Nature)4;
                                PKL[i].IV_HP = 21;
                                PKL[i].IV_ATK = 31;
                                PKL[i].IV_DEF = 31;
                                PKL[i].IV_DEF = 31;
                                PKL[i].IV_SPA = 18;
                                PKL[i].IV_SPD = 24;
                                PKL[i].IV_SPE = 19;
                            }
                            break;
                    }

                    PKL[i].Nature = (Nature)(int)(PKL[i].PID % 25);
                    PKL[i].ClearNickname();
                    PKL[i] = AchieveFunc.fun(PKL[i], SAV);


                    if (shiny)
                    {
                        PKL[i] = ShinyMakerUI.ShinyFunctionPlus(PKL[i]);
                    }
                }
            }
            SAV.ReloadSlots();
            return PKL;
        }
        public static List<PKM> SetGen4(ISaveFileProvider SAV, IPKMView Editor, bool shiny)
        {
            if (SAV.SAV is SAV7 s)
            {
                s.ConsoleRegion = 1;
                s.Country = 49;
            }
            var PKL = new List<PKM>();
            for (int i = 387; i < 494; i++)
            {
                if (i != 489 && i != 490 && i != 493)
                    PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, (int)GameVersion.Pt));
                else if (i is 489 or 490)
                    PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, (int)GameVersion.Pt, 0, true));
                else if (i == 493)
                {
                    PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, (int)GameVersion.B));
                }
            }
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    PKL[i] = EntityConverter.ConvertToType(PKL[i], SAV.SAV.PKMType, out var r2);
                    switch (i)
                    {
                        case 1:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 2:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 3:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)390, (int)GameVersion.Pt, 0, false, 0, 0, 0, 5);
                            break;
                        case 4:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)390, (int)GameVersion.Pt, 0, false, 0, 0, 0, 5);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 5:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)390, (int)GameVersion.Pt, 0, false, 0, 0, 0, 5);
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 7:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 8:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 11:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 13:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 15:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 17:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 18:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 20:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 22:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 24:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 26:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)412, (int)GameVersion.Pt, 0, false, 0, 2); ;
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 27:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)412, (int)GameVersion.Pt, 0, false, 0, 1);
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 28:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)415, (int)GameVersion.Pt, 0, false, 0, 0, 0, 5);
                            break;
                        case 29:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)415, (int)GameVersion.Pt, 0, true);
                            PKL[i].SetGender(1);
                            PKL[i].SetPIDGender(1);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 30:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)417, (int)GameVersion.Pt, 0, false, 0, 0, 0, 11);
                            break;
                        case 32:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 34:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 36:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 37:
                            PKL[i].Species = 424;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 39:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 41:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 42:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)429, (int)GameVersion.P);
                            PKL[i].Species = 429;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 43:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)430, (int)GameVersion.D);
                            PKL[i].Species = 430;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 44:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)431, (int)GameVersion.P);
                            break;
                        case 45:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)431, (int)GameVersion.P);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 47:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)434, (int)GameVersion.D);
                            break;
                        case 48:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)434, (int)GameVersion.D);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 50:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 54:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)441, (int)GameVersion.Pt, 0, false, 0, 0, 0, 25);
                            break;
                        case 58:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 60:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)447, (int)GameVersion.Pt, 0, true, 0, 0, 1);
                            //  PKL[i].EggLocation = 2010;
                            break;
                        case 61:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)447, (int)GameVersion.Pt, 0, true, 0, 0, 1);
                            //  PKL[i].EggLocation = 2010;
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 65:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 67:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 70:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 73:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 74:
                            PKL[i].Species = 461;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 75:
                            PKL[i].Species = 462;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 76:
                            PKL[i].Species = 463;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 77:
                            PKL[i].Species = 464;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 78:
                            PKL[i].Species = 465;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 79:
                            PKL[i].Species = 466;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 80:
                            PKL[i].Species = 467;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 81:
                            PKL[i].Species = 468;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 82:
                            PKL[i].Species = 469;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 83:
                            PKL[i].Species = 470;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 84:
                            PKL[i].Species = 471;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 85:
                            PKL[i].Species = 472;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 86:
                            PKL[i].Species = 473;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 87:
                            PKL[i].Species = 474;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 88:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)280, (int)GameVersion.Pt, 0, false, 0, 1);
                            PKL[i].Species = 475;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 89:
                            PKL[i].Species = 476;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 90:
                            PKL[i].Species = 477;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 91:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)361, (int)GameVersion.Pt, 0, false, 0, 2);
                            PKL[i].Species = 478;
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                    }

                    PKL[i].ClearNickname();
                    PKL[i] = AchieveFunc.fun(PKL[i], SAV);
                    if (PKL[i].Species == 490)
                    {
                        PKL[i].Language = 1;
                        PKL[i].ClearNickname();
                    }
                    PKL[i].SetSuggestedMoves(true);
                    PKL[i].HealPP();
                    if (shiny)
                    {
                        PKL[i] = ShinyMakerUI.ShinyFunctionPlus(PKL[i]);
                    }
                }
            }


            SAV.ReloadSlots();
            return PKL;
        }
        public static List<PKM> SetGen5(ISaveFileProvider SAV, IPKMView Editor, bool shiny)
        {
            if (SAV.SAV is SAV7 s)
            {
                s.ConsoleRegion = 1;
                s.Country = 49;
            }
            CheckRules r = new()
            {
                Shiny = RNGForm.ShinyType.Shiny,
            };
            PKM pk;
            var PKL = new List<PKM>();

            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 494, (int)GameVersion.W2));
            for (int i = 495; i < 637; i++)
            {
                pk = SearchDatabase.SearchPKMBW(SAV, Editor, (ushort)i, (int)GameVersion.W);
                PKL.Add(pk);
            }
            for (int i = 637; i < 650; i++)
            {
                PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, (int)GameVersion.W2));
            }
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    // var context = PKL[i].Context;
                    var origin = new EvolutionOrigin(PKL[i].Species, (GameVersion)(byte)GameVersion.W, 5, 1, 100);
                    var chain = EvolutionChain.GetOriginChain(PKL[i], origin);

                    EncounterGenerator5 g5 = new();

                    switch (i)
                    {
                        case 0:
                            PKL[i].Language = 2;
                            break;
                        case 2:
                            PKL[i] = g5.GetPossible(PKL[i], chain, GameVersion.W, EncounterTypeGroup.Static).ToList()[0].ConvertToPKM(SAV.SAV);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 3:
                            PKL[i] = g5.GetPossible(PKL[i], chain, GameVersion.W, EncounterTypeGroup.Static).ToList()[0].ConvertToPKM(SAV.SAV);
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 5:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 6:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 8:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 9:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 10:
                            PKL[i] = SearchDatabase.SearchPKMBW(SAV, Editor, 504, (int)GameVersion.W, 32);
                            break;
                        case 11:
                            PKL[i] = SearchDatabase.SearchPKMBW(SAV, Editor, 504, (int)GameVersion.W, 32);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 14:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 15:
                            PKL[i] = SearchDatabase.SearchPKMBW(SAV, Editor, 509, (int)GameVersion.W, 32);

                            break;
                        case 16:
                            PKL[i] = SearchDatabase.SearchPKMBW(SAV, Editor, 509, (int)GameVersion.W, 32);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 17:
                            PKL[i] = SearchDatabase.SearchPKMBW(SAV, Editor, 511, (int)GameVersion.W, 32);
                            break;
                        case 18:
                            PKL[i] = SearchDatabase.SearchPKMBW(SAV, Editor, 511, (int)GameVersion.W, 32);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 19:
                            PKL[i] = SearchDatabase.SearchPKMBW(SAV, Editor, 513, (int)GameVersion.W, 32);
                            break;
                        case 20:
                            PKL[i] = SearchDatabase.SearchPKMBW(SAV, Editor, 513, (int)GameVersion.W, 32);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 21:
                            PKL[i] = SearchDatabase.SearchPKMBW(SAV, Editor, 515, (int)GameVersion.W, 32);
                            break;
                        case 22:
                            PKL[i] = SearchDatabase.SearchPKMBW(SAV, Editor, 515, (int)GameVersion.W, 32);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 26:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 27:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 28:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 522, (int)GameVersion.B);
                            break;
                        case 29:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 32:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 34:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 36:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 39:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 40:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 43:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 47:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 48:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 50:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);

                            break;
                        case 51:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);

                            break;
                        case 52://问题
                            PKL[i] = SearchDatabase.SearchPKMBW(SAV, Editor, 546, (int)GameVersion.B, 0, 1);
                            break;
                        case 53://问题
                            PKL[i] = SearchDatabase.SearchPKMBW(SAV, Editor, 546, (int)GameVersion.B, 0, 1);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].RefreshAbility(0);
                            break;
                        case 55:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 58:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 59:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 61:
                            //  PKL[i] = AchieveFunc.evo1(PKL[i]);
                            //  PKL[i].CurrentLevel = 40;
                            break;
                        case 64:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 66:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 69:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 71:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 73:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 75:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 77:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 79:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 80:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 574, (int)GameVersion.B, 0, true);
                            break;
                        case 81:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 574, (int)GameVersion.B, 0, true);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 82:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 574, (int)GameVersion.B, 0, true);
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 84:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 85:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 87:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 89:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 90:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 92:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 93:
                            PKL[i] = SearchDatabase.SearchPKMBW(SAV, Editor, 587, (int)GameVersion.B, 0, 1);
                            break;
                        case 95:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 97:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 99:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 102:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 104:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 106:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 107:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 109:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 110:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 112:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 50;
                            break;
                        case 114:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 50;
                            break;
                        case 115:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 117:
                            //龙
                            break;
                        case 118:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 120:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 123:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 126:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 129:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 131:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 134:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 135:
                            PKL[i] = SearchDatabase.SearchPKMBW(SAV, Editor, 629, (int)GameVersion.B);
                            // PKL[i].CurrentLevel = 60;
                            break;
                        case 136:
                            PKL[i] = SearchDatabase.SearchPKMBW(SAV, Editor, 629, (int)GameVersion.B);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 140:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 50;
                            break;
                        case 141:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            break;
                        case 142:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 636, (int)GameVersion.B2, 0, true);
                            break;
                        case 149:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 643, (int)GameVersion.B, 0, false, 39);
                            break;
                        case 150:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 644, (int)GameVersion.W, 0, false, 39);
                            break;
                        case 153:
                            PKL[i].Language = 2;
                            break;
                        case 154:
                            PKL[i].Language = 2;
                            break;
                        case 155:
                            PKL[i].Language = 2;
                            break;

                    }
                    PKL[i] = EntityConverter.ConvertToType(PKL[i], SAV.SAV.PKMType, out var r2);
                    PKL[i] = AchieveFunc.fun(PKL[i], SAV);
                    var TID16bit = (PKL[i].TID16 ^ PKL[i].SID16) & 1;
                    var bitxor = PKL[i].PID >> 31 ^ PKL[i].PID & 1;
                    if (bitxor != TID16bit)
                        PKL[i].PID ^= 1;
                    PKL[i].EncryptionConstant = PKL[i].PID;
                    PKL[i].Gender = PKL[i].GetSaneGender();
                    if (shiny)
                    {
                        PKL[i] = ShinyMakerUI.ShinyFunctionPlus(PKL[i]);
                        switch (i)
                        {
                            case 143:
                                {
                                    pk = PKL[i];
                                    var seed = WangRandUtil.NextRand(0);
                                    while (true)
                                    {
                                        if (Gen5Wild.GenPkm(ref pk, seed, r))
                                        {
                                            PKL[i] = pk;
                                            PKL[i].AbilityNumber = 1;
                                            PKL[i].EncryptionConstant = PKL[i].PID;
                                            break;
                                        }
                                        else
                                        {
                                            seed++;
                                        }
                                    }
                                    break;
                                }
                            case 144:
                                {
                                    pk = PKL[i];
                                    var seed = WangRandUtil.NextRand(0);
                                    while (true)
                                    {
                                        if (Gen5Wild.GenPkm(ref pk, seed, r))
                                        {
                                            PKL[i] = pk;
                                            PKL[i].AbilityNumber = 1;
                                            PKL[i].EncryptionConstant = PKL[i].PID;
                                            break;
                                        }
                                        else
                                        {
                                            seed++;
                                        }
                                    }
                                    break;
                                }
                            case 145:
                                {
                                    pk = PKL[i];
                                    var seed = WangRandUtil.NextRand(0);
                                    while (true)
                                    {
                                        if (Gen5Wild.GenPkm(ref pk, seed, r))
                                        {
                                            PKL[i] = pk;
                                            PKL[i].AbilityNumber = 1;
                                            PKL[i].EncryptionConstant = PKL[i].PID;
                                            break;
                                        }
                                        else
                                        {
                                            seed++;
                                        }
                                    }
                                    break;
                                }
                            case 146:
                                {
                                    pk = PKL[i];
                                    var seed = WangRandUtil.NextRand(0);
                                    while (true)
                                    {
                                        if (Gen5Wild.GenPkm(ref pk, seed, r))
                                        {
                                            PKL[i] = pk;
                                            PKL[i].AbilityNumber = 1;
                                            PKL[i].EncryptionConstant = PKL[i].PID;
                                            break;
                                        }
                                        else
                                        {
                                            seed++;
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
            SAV.ReloadSlots();
            return PKL;
        }
        public static List<PKM> SetGen6(ISaveFileProvider SAV, IPKMView Editor, bool shiny)
        {
            if (SAV.SAV is SAV7 s)
            {
                s.ConsoleRegion = 1;
                s.Country = 49;
            }
            var PKL = new List<PKM>();
            for (int i = 650; i < 722; i++)
            {
                PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, (int)GameVersion.X));
            }
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    PKL[i] = EntityConverter.ConvertToType(PKL[i], SAV.SAV.PKMType, out var r2);
                    switch (i)
                    {
                        case 1:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 2:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 4:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 5:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 7:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 8:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 10:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 12:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 13:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 15:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 16:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 18:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 50;
                            break;
                        case 20:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 21:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 23:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 25:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 28:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].Gender = 0;
                            PKL[i].Form = 0;
                            break;
                        case 30:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 31:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 33:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 35:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 37:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 39:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 40:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 690, (int)GameVersion.Y);
                            break;
                        case 41:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 691, (int)GameVersion.Y);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 43:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 45:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 47:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 49:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 50:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 133, (int)GameVersion.Y, 0, true);
                            PKL[i].CurrentLevel = 50;
                            PKL[i].Species = 700;
                            PKL[i].RefreshAbility(0);

                            break;
                        case 55:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 50;
                            break;
                        case 56:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            break;
                        case 59:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            break;
                        case 61:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            break;
                        case 63:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            break;
                        case 65:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            break;
                        case 67:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 717, (int)GameVersion.Y);
                            break;
                        case 69:
                            PKL[i].Language = 2;
                            break;
                        case 70:
                            PKL[i].Language = 2;
                            break;
                        case 71:
                            PKL[i].Language = 2;
                            break;
                    }


                    PKL[i].ClearNickname();
                    PKL[i] = AchieveFunc.fun(PKL[i], SAV);

                    if (shiny)
                    {
                        PKL[i] = ShinyMakerUI.ShinyFunctionPlus(PKL[i]);
                    }
                }

            }
            SAV.ReloadSlots();
            return PKL;
        }
        public static List<PKM> SetGen7(ISaveFileProvider SAV, IPKMView Editor, bool shiny)
        {
            if (SAV.SAV is SAV7 s)
            {
                s.ConsoleRegion = 1;
                s.Country = 49;
            }
            var PKL = new List<PKM>();
            for (int i = 722; i < 808; i++)
            {
                PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, (int)GameVersion.US));
            }
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    PKL[i] = EntityConverter.ConvertToType(PKL[i], SAV.SAV.PKMType, out var r2);
                    switch (i)
                    {
                        case 1:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 2:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 4:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 5:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 7:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 8:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 10:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 11:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 15:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 16:
                            //   PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 18:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 21:
                            // PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 23:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 26:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 28:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 30:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 32:
                            //  PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 34:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 36:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].Gender = 1;
                            break;
                        case 39:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 761, (int)GameVersion.SN, 0, true);
                            break;
                        case 41:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 46:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 48:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 51:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 58:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 780, (int)GameVersion.UM);
                            break;
                        case 61:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 62:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 68:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            PKL[i].Move1 = 150;
                            PKL[i].Move2 = 0;
                            PKL[i].Move3 = 0;
                            PKL[i].Move4 = 0;
                            PKL[i].HealPP();
                            PKL[i].RefreshAbility(1);
                            break;
                        case 69:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            PKL[i].RefreshAbility(1);
                            break;
                        case 70:
                            PKL[i] = AchieveFunc.evo3(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            PKL[i].RefreshAbility(1);
                            break;
                        case 73:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 795, (int)GameVersion.UM);
                            break;
                        case 75:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 797, (int)GameVersion.UM);
                            break;
                        case 82:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 83:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 805, (int)GameVersion.UM);
                            break;

                    }
                    PKL[i].ClearNickname();
                    PKL[i] = AchieveFunc.fun(PKL[i], SAV);
                    if (shiny)
                    {
                        PKL[i] = ShinyMakerUI.ShinyFunctionPlus(PKL[i]);
                    }
                }
            }
            SAV.ReloadSlots();
            return PKL;
        }
        public static List<PKM> SetAll(ISaveFileProvider SAV, IPKMView Editor, bool shiny)
        {
            List<PKM> PKL = SetGen1(SAV, Editor, shiny).Concat(SetGen2(SAV, Editor, shiny)).
                                  Concat(SetGen3(SAV, Editor, shiny)).Concat(SetGen4(SAV, Editor, shiny)).
                                  Concat(SetGen5(SAV, Editor, shiny)).Concat(SetGen6(SAV, Editor, shiny)).
                                  Concat(SetGen7(SAV, Editor, shiny)).ToList();
            return PKL;
        }
    }
}
