using System.Collections.Generic;
using PKHeX.Core;

namespace WangPlugin
{

    internal class DexModClass
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public static List<DexModClass> DexModList(ISaveFileProvider sav)
        {
            var L = new List<DexModClass>();
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
            DexModClass Deerling= new DexModClass
            {
                Name = "四季鹿家族",
                Value = "Deerling",
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
            
            L.Add(CapPikachu);
            L.Add(Unown);
            L.Add(Deoxys);
            L.Add(Burmy);
            L.Add(Gastrodon);
            L.Add(Rotom);
            L.Add(Deerling);
            L.Add(Vivillon);
            L.Add(Flabébé);
            L.Add(Furfrou);
            L.Add(Pumpkaboo);
            L.Add(CosplayPikachu);
            L.Add(Oricorio);
            L.Add(Minior);
            L.Add(Silvally);
            L.Add(Alcremie);
            L.Add(Mega);
            L.Add(Alola);
            L.Add(Galar);
            L.Add(Gigamax); 
            L.Add(Hisui);
            
            return L;
        }
    }
}
