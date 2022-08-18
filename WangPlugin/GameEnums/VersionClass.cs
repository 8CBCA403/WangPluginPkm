using System.Collections.Generic;
using PKHeX.Core;

namespace WangPlugin
{
    internal class VersionClass
    {
       public string Name { get; set; }
       public string Version { get; set; }
       
        public static List<VersionClass> VersionList(ISaveFileProvider sav)
        {
            var L = new List<VersionClass>();
            VersionClass National = new VersionClass
            {
                Name = "按照全国图鉴顺序",
                Version = "National",
            };
            VersionClass RYBG = new VersionClass
            {
                Name = "Gen 1 关东图鉴（蓝，绿，红，黄）顺序",
                Version = "RYBG",
            };
            VersionClass GS = new VersionClass
            {
                Name = "Gen 2 城都图鉴（金，银，水晶）顺序",
                Version = "GS",
            };
            VersionClass E = new VersionClass
            {
                Name = "Gen 3 丰缘图鉴（红，绿，蓝宝石）顺序",
                Version = "E",
            };
            VersionClass FRGL = new VersionClass
            {
                Name = "Gen 3 关东图鉴（火红，叶绿）顺序",
                Version = "FRGL",
            };
            VersionClass DP = new VersionClass
            {
                Name = "Gen 4 神奥图鉴（钻石，珍珠）顺序",
                Version = "DP",
            };
            VersionClass Platinum = new VersionClass
            {
                Name = "Gen 4 神奥图鉴（白金）顺序",
                Version = "Platinum",
            };
            VersionClass GHSS = new VersionClass
            {
                Name = "Gen 4 城都图鉴（心金，魂银）顺序",
                Version = "GHSS",
            };
            VersionClass BW = new VersionClass
            {
                Name = "Gen 5 合众图鉴（黑，白）顺序",
                Version = "BW",
            };
            VersionClass B2W2 = new VersionClass
            {
                Name = "Gen 5 合众图鉴（黑2，白2）顺序",
                Version = "B2W2",
            };
            VersionClass XY = new VersionClass
            {
                Name = "Gen 6 卡洛斯图鉴（X，Y）顺序",
                Version = "XY",
            };
            VersionClass ORAS = new VersionClass
            {
                Name = "Gen 6 丰缘图鉴（始源红宝石，蓝宝石）顺序",
                Version = "ORAS",
            };
            VersionClass SM = new VersionClass
            {
                Name = "Gen 7 阿罗拉图鉴（日，月）顺序",
                Version = "SM",
            };
            VersionClass USUM = new VersionClass
            {
                Name = "Gen 7 阿罗拉图鉴（究极日，月）顺序",
                Version = "USUM",
            };
            VersionClass LPLE = new VersionClass
            {
                Name = "Gen 7 关东图鉴（去皮，去伊）顺序",
                Version = "LPLE",
            };
            VersionClass SWSH = new VersionClass
            {
                Name = "Gen 8 伽勒尔图鉴（剑，盾）顺序",
                Version = "SWSH",
            };
            VersionClass SWSH1 = new VersionClass
            {
                Name = "Gen 8 伽勒尔铠岛图鉴（剑盾DLC1）顺序",
                Version = "SWSH1",
            };
            VersionClass SWSH2 = new VersionClass
            {
                Name = "Gen 8 伽勒尔冰冠图鉴（剑盾DLC2）顺序",
                Version = "SWSH2",
            };
            VersionClass SWSH3 = new VersionClass
            {
                Name = "Gen 8 伽勒尔完整图鉴顺序",
                Version = "SWSH3",
            };
            VersionClass BDSP = new VersionClass
            {
                Name = "Gen 8 神奥图鉴（明亮珍珠，晶灿钻石）顺序",
                Version = "BDSP",
            };
            VersionClass PLA = new VersionClass
            {
                Name = "Gen 8 洗翠图鉴（传说阿尔宙斯）顺序",
                Version = "PLA",
            };


            int gen = sav.SAV.Generation;
            GameVersion version = sav.SAV.Version;
            L.Add(National);
            bool isLetsGo = version == GameVersion.GP || version == GameVersion.GE;
            if (isLetsGo)
            {
                L.Add(LPLE);
            }
            else
            {
                bool isSwSh = version == GameVersion.SW || version == GameVersion.SH;
                bool isBDSP = version == GameVersion.BD || version == GameVersion.SP;
                bool isPLA = version == GameVersion.PLA;

                if (gen >= 1)
                    L.Add(RYBG);
                if (gen >= 2)
                    L.Add(GS);
                if (gen >= 3)
                {
                    L.Add(E);
                    L.Add(FRGL);
                }
                if (gen >= 4)
                {
                    L.Add(DP);
                    L.Add(Platinum);
                    L.Add(GHSS);
                }
                if (gen >= 5 && !isBDSP)
                {
                    L.Add(BW);
                    L.Add(B2W2);
                }
                if (gen >= 6 && !isBDSP)
                {
                    L.Add(XY);
                    L.Add(ORAS);
                }

                if (gen >= 7 && !isBDSP && !isPLA)
                {
                    L.Add(SM);
                    L.Add(USUM);
                }
                if (gen >= 8)
                {
                    if (isSwSh)
                    {
                        L.Add(LPLE);
                        L.Add(SWSH);
                        L.Add(SWSH1);
                        L.Add(SWSH2);
                        L.Add(SWSH3);
                    }
                    else if (isBDSP)
                    {
                        L.Add(BDSP);
                    }
                    else if (isPLA)
                    {
                        L.Add(BDSP);
                        L.Add(PLA);
                    }
                }
            }
            return L;
        }
    }
}
