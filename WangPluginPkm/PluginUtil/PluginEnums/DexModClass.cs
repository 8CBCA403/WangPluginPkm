using System.Collections.Generic;
using System.IO;
using PKHeX.Core;
namespace WangPluginPkm
{
    internal class DexModClass
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public static List<DexModClass> DexModList(ISaveFileProvider sav)
        {
            var L = new List<DexModClass>();
            var G = sav.SAV.Generation;
            var V = sav.SAV.Version;
            DexModClass CapPikachu = new DexModClass
            {
                Name = "一组帽子皮",
                Value = "CapPikachu",
            };
            DexModClass Unown = new DexModClass
            {
                Name = "一组未知图腾",
                Value = "Unown",
            };
            DexModClass Deoxys = new DexModClass
            {
                Name = "一组代欧奇希斯",
                Value = "Deoxys",
            };
            DexModClass Burmy = new DexModClass
            {
                Name = "结草家族",
                Value = "Burmy",
            };
            DexModClass Gastrodon = new DexModClass
            {
                Name = "海兔家族",
                Value = "Gastrodon",
            };
            DexModClass Rotom = new DexModClass
            {
                Name = "洛托姆家族",
                Value = "Rotom",
            };
            DexModClass Arceus = new DexModClass
            {
                Name = "阿尔宙斯家族",
                Value = "Arceus",
            };
            DexModClass Deerling = new DexModClass
            {
                Name = "四季鹿家族",
                Value = "Deerling",
            };
            DexModClass Incarnate = new DexModClass
            {
                Name = "化身家族",
                Value = "Incarnate",
            };
            DexModClass Genesect = new DexModClass
            {
                Name = "盖诺赛克特家族",
                Value = "Genesect",
            };
            DexModClass DreamRadar = new DexModClass
            {
                Name = "梦境雷达",
                Value = "DreamRadar",
            };


            DexModClass Vivillon = new DexModClass
            {
                Name = "彩粉蝶家族",
                Value = "Vivillon",
            };
            DexModClass Flabébé = new DexModClass
            {
                Name = "花蓓蓓家族",
                Value = "Flabébé",
            };
            DexModClass Furfrou = new DexModClass
            {
                Name = "多丽米亚家族",
                Value = "Furfrou",
            };
            DexModClass Pumpkaboo = new DexModClass
            {
                Name = "南瓜精家族",
                Value = "Pumpkaboo",
            };
            DexModClass CosplayPikachu = new DexModClass
            {
                Name = "变装皮卡丘",
                Value = "CosplayPikachu",
            };
            DexModClass Oricorio = new DexModClass
            {
                Name = "花舞鸟家族",
                Value = "Oricorio",
            };
            DexModClass Rockruffy = new DexModClass
            {
                Name = "岩岩狗家族",
                Value = "Rockruffy",
            };
            DexModClass Zygarde = new DexModClass
            {
                Name = "基格尔德家族",
                Value = "Zygarde",
            };
            DexModClass Minior = new DexModClass
            {
                Name = "小陨星家族",
                Value = "Minior",
            };
            DexModClass Silvally = new DexModClass
            {
                Name = "银伴战兽家族",
                Value = "Silvally",
            };
            DexModClass Alcremie = new DexModClass
            {
                Name = "霜奶仙家族",
                Value = "Alcremie",
            };
            DexModClass Mega = new DexModClass
            {
                Name = "一组超级进化",
                Value = "Mega",
            };
            DexModClass Alola = new DexModClass
            {
                Name = "一组阿罗拉形态",
                Value = "Alola",
            };
            DexModClass Galar = new DexModClass
            {
                Name = "一组伽勒尔形态",
                Value = "Galar",
            };
            DexModClass Gigamax = new DexModClass
            {
                Name = "一组超极巨",
                Value = "Gigamax",
            };
            DexModClass Hisui = new DexModClass
            {
                Name = "一组洗翠形态",
                Value = "Hisui",
            };
            DexModClass Paradox = new DexModClass
            {
                Name = "一组悖论种",
                Value = "Paradox",
            };
            DexModClass Squawkabilly = new DexModClass
            {
                Name = "怒鹦哥家族",
                Value = "Squawkabilly",
            };
            DexModClass Tatsugiri = new DexModClass
            {
                Name = "米立龙家族",
                Value = "Tatsugiri",
            };
            DexModClass None = new DexModClass
            {
                Name = "无",
                Value = "None",
            };
            if (G>=1)
            {
                L.Add(None);
            }
            if (G>=3&& V is not GameVersion.SW && V is not GameVersion.SH && G <= 8)
            {
                L.Add(Unown);
            }
            if (G >= 3 && G< 8)
            {
                L.Add(Deoxys);
            }
            if (G >= 4 && G <= 8)
            {
                if(V is not GameVersion.SW &&V is not GameVersion.SH)
                L.Add(Burmy);
                L.Add(Gastrodon);
                L.Add(Rotom);
                if(V is not GameVersion.SW && V is not GameVersion.SH && V is not GameVersion.BD&& V is not GameVersion.SP)
                L.Add(Arceus);
            }
            if(G==5)
            {
                L.Add(DreamRadar);
            }
            if (G >= 5&& V is not GameVersion.BD && V is not GameVersion.SP && G <= 8)
            {
                if (G != 8 && V is not GameVersion.PLA)
                {
                    L.Add(Deerling);
                   
                }
                if (V is not GameVersion.PLA)
                {
                    L.Add(Genesect);
                }
                if (V is GameVersion.PLA&&V is not GameVersion.SW & V is not GameVersion.SH&& V is not GameVersion.SWSH)
                {
                    L.Add(Incarnate);
                }
            }
            if (G >= 6 && G <= 8)
            {
                if(V==GameVersion.AS||V==GameVersion.OR)
                    L.Add(CosplayPikachu);
                if (G != 8)
                {
                    L.Add(Mega);
                    L.Add(Vivillon);
                    L.Add(Flabébé);
                    L.Add(Furfrou);
                    L.Add(Zygarde);
                }
                if(V!=GameVersion.PLA && V is not GameVersion.BD && V is not GameVersion.SP)
                    L.Add(Pumpkaboo);
                
            }
            if (G >= 7&&G<=8)
            {
                if (G != 8)
                {
                    L.Add(CapPikachu);
                    L.Add(Oricorio);
                    L.Add(Minior);
                }
                if (V != GameVersion.PLA && V is not GameVersion.BD && V is not GameVersion.SP)
                {
                    L.Add(Rockruffy);
                    L.Add(Silvally);
                    L.Add(Alola);
                }
            }
            if (G == 8)
            {
                if (V is not GameVersion.PLA && V is not GameVersion.BD && V is not GameVersion.SP)
                {
                    L.Add(Alcremie);
                    L.Add(Galar);
                    L.Add(Gigamax);
                }
                else if (V is GameVersion.PLA)
                L.Add(Hisui);
            }
            if(G==9)
            {
                L.Add(Rotom);
                L.Add(Flabébé);
                L.Add(Deerling);
                L.Add(Vivillon);
                L.Add(Oricorio);
                L.Add(Squawkabilly);
                L.Add(Tatsugiri);
                L.Add(Paradox);
            }
            return L;
        }
    }
}
