using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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
    }
}
