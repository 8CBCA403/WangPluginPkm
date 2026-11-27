using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WangPluginPkm.PluginUtil.Functions
{
    public static class DistributionFunctions
    {
        private static Random rand = new();
        public static string RandomString(int length)
        {
            const string chars = "赵钱孙李周吴正旺小鱼儿新子颜缘分振哥毅力建国云宗光辉老查丽鱼安娜牛";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }
        public static List<int> FindAllEmptySlots(IList<PKM> data, int start)
        {
            List<int> list = new List<int>();
            for (int i = start; i < data.Count; i++)
            {
                if (data[i].Species < 1)
                {
                    list.Add(i);
                }
            }
            return list;
        }
        public static uint Shiny(PKM pk)
        {
            return (((uint)(pk.TID16 ^ pk.SID16) ^ (pk.PID & 0xFFFF) ^ 1) << 16) | (pk.PID & 0xFFFF);
        }

        internal static int ModifyBoxRange(SaveFile save, Action<PKM> action, int firstBox, int firstSlot, int lastBox, int lastSlot)
        {
            firstBox = Math.Max(0, firstBox);
            firstSlot = Math.Max(0, firstSlot);
            if ((uint)lastBox >= save.BoxCount)
                lastBox = save.BoxCount - 1;
            if ((uint)lastSlot >= save.BoxSlotCount)
                lastSlot = save.BoxSlotCount - 1;

            int count = 0;
            for (int box = firstBox; box <= lastBox; box++)
            {
                for (int slot = firstSlot; slot <= lastSlot; slot++)
                {
                    if (save.IsBoxSlotOverwriteProtected(box, slot))
                        continue;
                    var pk = save.GetBoxSlotAtIndex(box, slot);
                    if (pk.Species == 0)
                        continue;
                    action(pk);
                    save.SetBoxSlotAtIndex(pk, box, slot, EntityImportSettings.None);
                    count++;
                }
            }
            return count;
        }
    }
}
