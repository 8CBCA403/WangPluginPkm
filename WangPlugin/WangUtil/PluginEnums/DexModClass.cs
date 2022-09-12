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
            DexModClass Pikachu = new DexModClass
            {
                Name = "一组帽子皮",
                Value = "Pikachu",
            };
            DexModClass Unown = new DexModClass
            {
                Name = "一组未知图腾",
                Value = "Unown",
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

            L.Add(Pikachu);
            L.Add(Unown);
            L.Add(Mega);
            L.Add(Alola);
            L.Add(Galar);
            L.Add(Gigamax); 
            L.Add(Hisui);
            return L;
        }
    }
}
