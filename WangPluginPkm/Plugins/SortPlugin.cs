#region
/*using System;
using System.Windows.Forms;
using PKHeX.Core;
using System.Collections.Generic;
using WangPluginPkm.SortBase;
namespace WangPluginPkm.Plugins
{
    internal class SortPlugin: WangPluginPkm
    {
        public override string Name => "排序/Sort";
        public override int Priority => 6;
 

       
        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            int gen = SaveFileEditor.SAV.Generation;
            GameVersion version = SaveFileEditor.SAV.Version;
            bool isLetsGo = version == GameVersion.GP || version == GameVersion.GE;

            modmenu.DropDownItems.RemoveByKey("SortBoxesBy");
            ToolStripMenuItem sortBoxesItem = new ToolStripMenuItem("全部箱子排序/All Boxes Sort")
            {
                Name = "全部箱子排序/All Boxes Sort"
            };
            sortBoxesItem.Image = Properties.Resources.Sort;
            modmenu.DropDownItems.Add(sortBoxesItem);
            ToolStripItemCollection sortItems = sortBoxesItem.DropDownItems;
            if (isLetsGo)
            {
                sortItems.Add(GetSortButton("Gen 7 关东图鉴（去皮去伊）", Gen7_Kanto.GetSortFunctions()));
            }
            else
            {
                bool isSwSh = version == GameVersion.SW || version == GameVersion.SH;
                bool isBDSP = version == GameVersion.BD || version == GameVersion.SP;
                bool isPLA = version == GameVersion.PLA;
                if (gen != 1)
                {
                    ToolStripMenuItem sortButton = new ToolStripMenuItem("按照全国图鉴排序");
                    sortButton.Click += (s, e) => SortByNationalDex();
                    sortItems.Add(sortButton);
                }
                if (gen >= 1)
                {
                    sortItems.Add(GetSortButton("按照Gen 1关东图鉴（红黄蓝绿）排序", Gen1_Kanto.GetSortFunctions()));
                        
                }

                if (gen >= 2)
                {
                    sortItems.Add(GetSortButton("按照Gen 2 城都图鉴（金银）排序", Gen2_Johto.GetSortFunctions()));
                }

                if (gen >= 3)
                {
                    sortItems.Add(GetSortButton("按照Gen 3 丰缘图鉴（红，蓝，绿宝石）排序", Gen3_Hoenn.GetSortFunctions()));
                    sortItems.Add(GetSortButton("按照Gen 3 关东图鉴（火红叶绿）排序", Gen3_Kanto.GetSortFunctions()));
                }

                if (gen >= 4)
                {
                    sortItems.Add(GetSortButton("按照Gen 4 神奥图鉴（珍珠钻石）排序", Gen4_Sinnoh.GetDPSortFunctions()));
                    sortItems.Add(GetSortButton("按照Gen 4 神奥图鉴（白金）排序", Gen4_Sinnoh.GetPtSortFunctions()));
                    sortItems.Add(GetSortButton("按照Gen 4 城都图鉴（心金魂银）排序", Gen4_Johto.GetSortFunctions()));
                }

                if (gen >= 5 && !isBDSP)
                {
                    sortItems.Add(GetSortButton("按照Gen 5 合众图鉴（黑白）排序", Gen5_Unova.GetBWSortFunctions()));
                    sortItems.Add(GetSortButton("按照Gen 5 合众图鉴（黑2白2）排序", Gen5_Unova.GetB2W2SortFunctions()));
                }

                if (gen >= 6 && !isBDSP)
                {
                    sortItems.Add(GetSortButton("按照Gen 6 卡洛斯排序", Gen6_Kalos.GetSortFunctions()));
                    sortItems.Add(GetSortButton("按照Gen 6 丰缘（始源红宝石，蓝宝石）排序", Gen6_Hoenn.GetSortFunctions()));
                }

                if (gen >= 7 && !isBDSP && !isPLA)
                {
                    sortItems.Add(GetSortButton("按照Gen 7 阿罗拉（太阳月亮）排序", Gen7_Alola.GetFullSMSortFunctions()));
                    sortItems.Add(GetSortButton("按照Gen 7 阿罗拉（究极太阳究极月亮）排序", Gen7_Alola.GetFullUSUMSortFunctions()));
                }

                if (gen >= 8)
                {
                    if (isSwSh)
                    {
                        sortItems.Add(GetSortButton("按照Gen 7 关东（去皮去伊）排序", Gen7_Kanto.GetSortFunctions()));
                        sortItems.Add(GetSortButton("按照Gen 8 伽勒尔排序", Gen8_Galar.GetGalarDexSortFunctions()));
                        sortItems.Add(GetSortButton("按照Gen 8 伽勒尔（铠岛）排序", Gen8_Galar.GetIoADexSortFunctions()));
                        sortItems.Add(GetSortButton("按照Gen 8 伽勒尔（冰冠）排序", Gen8_Galar.GetCTDexSortFunction()));
                        sortItems.Add(GetSortButton("按照Gen 8 伽勒尔完整排序", Gen8_Galar.GetFullGalarDexSortFunctions()));
                    }
                    else if (isBDSP)
                    {
                        sortItems.Add(GetSortButton("按照Gen 8 神奥（珍钻复刻）排序", Gen8_Sinnoh.GetSortFunctions()));
                    }
                    else if (isPLA)
                    {
                        sortItems.Add(GetSortButton("按照Gen 8 洗翠排序", Gen8_Hisui.GetSortFunctions()));
                    }
                }

               
            }

        }
        private ToolStripDropDownItem GetSortButton(string dex, Func<PKM, IComparable>[] sortFunctions)
        {
            ToolStripMenuItem dexSortButton = new ToolStripMenuItem($"{dex}（地区图鉴）");
            dexSortButton.Click += (s, e) => SortByRegionalDex(sortFunctions);
            return dexSortButton;
        }
        private void SortByRegionalDex(Func<PKM, IComparable>[] sortFunctions)
        {
            IEnumerable<PKM> sortMethod(IEnumerable<PKM> pkms, int i) => pkms.OrderByCustom(sortFunctions);
            SaveFileEditor.SAV.SortBoxes(0, -1, sortMethod);
            SaveFileEditor.ReloadSlots();
        }

        private void SortByNationalDex()
        {
            SaveFileEditor.SAV.SortBoxes();
            SaveFileEditor.ReloadSlots();
        }
       
    }
}
*/
#endregion
