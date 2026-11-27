using System;
using System.Windows.Forms;
using PKHeX.Core;
using WangPluginPkm.SortBase;

namespace WangPluginPkm.Plugins
{
    public class SortPlugin : WangPluginPkm
    {
        public override string Name => "全部箱子排序/All Boxes Sort";
        public override int Priority => 7;
        private ToolStripMenuItem sortMenu;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            sortMenu = new ToolStripMenuItem(Name)
            {
                Name = Name,
                Image = Properties.Resources.Sort,
            };
            modmenu.DropDownItems.Add(sortMenu);
            RefreshSortOptions();
        }

        public override void NotifySaveLoaded() => RefreshSortOptions();

        private void RefreshSortOptions()
        {
            var items = sortMenu.DropDownItems;
            while (items.Count > 0)
                items[0].Dispose();

            var save = SaveFileEditor.SAV;
            sortMenu.Enabled = save.HasBox;
            if (!save.HasBox)
                return;

            var version = save.Version;
            var generation = save.Generation;
            bool bdsp = version is GameVersion.BD or GameVersion.SP;
            bool pla = version == GameVersion.PLA;

            void Add(string text, Func<PKM, IComparable>[] order = null)
            {
                var item = new ToolStripMenuItem(PluginLocalization.Translate(text));
                item.Click += (_, _) =>
                {
                    var current = SaveFileEditor.SAV;
                    if (order == null)
                        current.SortBoxes();
                    else
                        current.SortBoxes(sortMethod: (entries, _) => entries.OrderByCustom(order));
                    SaveFileEditor.ReloadSlots();
                };
                items.Add(item);
            }

            if (version is GameVersion.GP or GameVersion.GE)
            {
                Add("关东图鉴（去皮去伊）/Kanto (Let's Go)", Gen7_Kanto.GetSortFunctions());
                return;
            }

            Add("全国图鉴/National Pokédex");
            Add("关东图鉴（红蓝黄绿）/Kanto (RBY)", Gen1_Kanto.GetSortFunctions());
            if (generation >= 2)
                Add("城都图鉴（金银）/Johto (GS)", Gen2_Johto.GetSortFunctions());
            if (generation >= 3)
            {
                Add("丰缘图鉴（红蓝绿宝石）/Hoenn (RSE)", Gen3_Hoenn.GetSortFunctions());
                Add("关东图鉴（火红叶绿）/Kanto (FRLG)", Gen3_Kanto.GetSortFunctions());
            }
            if (generation >= 4)
            {
                Add("神奥图鉴（珍珠钻石）/Sinnoh (DP)", Gen4_Sinnoh.GetDPSortFunctions());
                Add("神奥图鉴（白金）/Sinnoh (Platinum)", Gen4_Sinnoh.GetPtSortFunctions());
                Add("城都图鉴（心金魂银）/Johto (HGSS)", Gen4_Johto.GetSortFunctions());
            }
            if (generation >= 5 && !bdsp)
            {
                Add("合众图鉴（黑白）/Unova (BW)", Gen5_Unova.GetBWSortFunctions());
                Add("合众图鉴（黑2白2）/Unova (B2W2)", Gen5_Unova.GetB2W2SortFunctions());
            }
            if (generation >= 6 && !bdsp)
            {
                Add("卡洛斯图鉴（XY）/Kalos (XY)", Gen6_Kalos.GetSortFunctions());
                Add("丰缘图鉴（始源红宝石、终极蓝宝石）/Hoenn (ORAS)", Gen6_Hoenn.GetSortFunctions());
            }
            if (generation >= 7 && !bdsp && !pla)
            {
                Add("阿罗拉图鉴（太阳月亮）/Alola (SM)", Gen7_Alola.GetFullSMSortFunctions());
                Add("阿罗拉图鉴（究极太阳究极月亮）/Alola (USUM)", Gen7_Alola.GetFullUSUMSortFunctions());
            }

            if (version is GameVersion.SW or GameVersion.SH)
            {
                Add("关东图鉴（去皮去伊）/Kanto (Let's Go)", Gen7_Kanto.GetSortFunctions());
                Add("伽勒尔图鉴（本篇）/Galar (Base Game)", Gen8_Galar.GetGalarDexSortFunctions());
                Add("伽勒尔图鉴（铠岛）/Galar (Isle of Armor)", Gen8_Galar.GetIoADexSortFunctions());
                Add("伽勒尔图鉴（冠之雪原）/Galar (Crown Tundra)", Gen8_Galar.GetCTDexSortFunction());
                Add("伽勒尔完整图鉴/Galar (All Regions)", Gen8_Galar.GetFullGalarDexSortFunctions());
            }
            else if (bdsp)
            {
                Add("神奥图鉴（珍钻复刻）/Sinnoh (BDSP)", Gen8_Sinnoh.GetSortFunctions());
            }
            else if (pla)
            {
                Add("洗翠图鉴（阿尔宙斯）/Hisui (Legends Arceus)", Gen8_Hisui.GetSortFunctions());
            }
        }
    }
}
