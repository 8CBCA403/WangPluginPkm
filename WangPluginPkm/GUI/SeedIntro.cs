using System.Windows.Forms;
namespace WangPluginPkm.GUI
{
    public partial class SeedIntro : PluginForm
    {
        public SeedIntro()
        {
            InitializeComponent();
            if (!PluginLocalization.IsChinese)
            {
                TextBox.Text = "RNG Tools Help\r\n1. Drag the Pokémon to search into PKHeX's editor panel before starting.\r\n2. Use a save from the same generation as the target Pokémon to avoid invalid or excessively long searches.\r\n3. Use preset seeds when specific IV spreads are required; see the table below.\r\n4. XD/Colosseum team locks apply only to supported encounters; see the table below.";
                TeamLockTextBox.Text = "Team-lock information is currently available in Chinese only.";
            }
            IS();
        }
        public void IS()
        {
            SeedInstroList.View = View.Details;
            SeedInstroList.GridLines = true;
            SeedInstroList.LabelEdit = false;
            SeedInstroList.FullRowSelect = true;
            SeedInstroList.Columns.Add(PluginLocalization.IsChinese ? "预制种子信息" : "Preset Seed", 200);
            SeedInstroList.Columns.Add(PluginLocalization.IsChinese ? "6个0" : "6 Zero IVs", 100);
            SeedInstroList.Columns.Add(PluginLocalization.IsChinese ? "0攻" : "0 Atk", 100);
            SeedInstroList.Columns.Add(PluginLocalization.IsChinese ? "0速" : "0 Spe", 100);
            SeedInstroList.Columns.Add(PluginLocalization.IsChinese ? "0攻0速" : "0 Atk / 0 Spe", 100);
            SeedInstroList.Columns.Add("6V", 100);
            SeedInstroList.Columns.Add(PluginLocalization.IsChinese ? "0攻0特攻0速" : "0 Atk / SpA / Spe", 100);
            string fixedPid = PluginLocalization.IsChinese ? "固定PID" : "fixed PID";
            var Method1 = new ListViewItem($"Method1 ({fixedPid})");
            Method1.SubItems.Add($"6");
            Method1.SubItems.Add($"4");
            Method1.SubItems.Add($"2");
            Method1.SubItems.Add($"2");
            Method1.SubItems.Add($"6");
            SeedInstroList.Items.Add(Method1);
            var Method2 = new ListViewItem($"Method2 ({fixedPid})");
            Method2.SubItems.Add($"6");
            Method2.SubItems.Add($"4");
            Method2.SubItems.Add($"2");
            Method2.SubItems.Add($"2");
            Method2.SubItems.Add($"6");
            SeedInstroList.Items.Add(Method2);
            var Method3 = new ListViewItem($"Method3 ({fixedPid})");
            Method3.SubItems.Add($"6");
            Method3.SubItems.Add($"4");
            Method3.SubItems.Add($"2");
            Method3.SubItems.Add($"2");
            Method3.SubItems.Add($"6");
            SeedInstroList.Items.Add(Method3);
            var Method4 = new ListViewItem($"Method4 ({fixedPid})");
            Method4.SubItems.Add($"4");
            Method4.SubItems.Add($"2");
            Method4.SubItems.Add($"4");
            Method4.SubItems.Add($"4");
            Method4.SubItems.Add($"4");
            SeedInstroList.Items.Add(Method4);
            string unown = PluginLocalization.IsChinese ? "未知图腾" : " Unown";
            var Method1_Unown = new ListViewItem($"Method1{unown} ({fixedPid})");
            Method1_Unown.SubItems.Add($"R,M,V,R,M,V");
            Method1_Unown.SubItems.Add($"R,U,R,U");
            Method1_Unown.SubItems.Add($"C,C");
            Method1_Unown.SubItems.Add($"P,P");
            Method1_Unown.SubItems.Add($"G,X,Y,G,X,Y");
            SeedInstroList.Items.Add(Method1_Unown);
            var Method2_Unown = new ListViewItem($"Method2{unown} ({fixedPid})");
            Method2_Unown.SubItems.Add($"E,!,M,E,!,M");
            Method2_Unown.SubItems.Add($"N,T,N,T");
            Method2_Unown.SubItems.Add($"U,U");
            Method2_Unown.SubItems.Add($"R,R");
            Method2_Unown.SubItems.Add($"Y,W,B,Y,W,B");
            SeedInstroList.Items.Add(Method2_Unown);
            var Method3_Unown = new ListViewItem($"Method3{unown} ({fixedPid})");
            Method3_Unown.SubItems.Add($"N,Y,R,N,Y,R");
            Method3_Unown.SubItems.Add($"R,Q,R,Q");
            Method3_Unown.SubItems.Add($"O,O");
            Method3_Unown.SubItems.Add($"H,H");
            Method3_Unown.SubItems.Add($"X,O,Y,X,O,Y");
            SeedInstroList.Items.Add(Method3_Unown);
            var Method4_Unown = new ListViewItem($"Method4{unown} ({fixedPid})");
            Method4_Unown.SubItems.Add($"R,F,R,F");
            Method4_Unown.SubItems.Add($"S,S");
            Method4_Unown.SubItems.Add($"P,L,P,L");
            Method4_Unown.SubItems.Add($"A,M,A,M");
            Method4_Unown.SubItems.Add($"S,G,S,G");
            var XDColo = new ListViewItem(PluginLocalization.IsChinese ? $"XDColo(非队锁情况,{fixedPid})" : $"XD/Colosseum (no team lock, {fixedPid})");
            XDColo.SubItems.Add($"4");
            XDColo.SubItems.Add($"4");
            XDColo.SubItems.Add($"2");
            XDColo.SubItems.Add($"4");
            XDColo.SubItems.Add($"6");
            SeedInstroList.Items.Add(XDColo);
            var OverWorld8 = new ListViewItem(PluginLocalization.IsChinese ? "OverWorld8(只有方块)" : "OverWorld8 (square shiny only)");
            OverWorld8.SubItems.Add($"8");
            OverWorld8.SubItems.Add($"6");
            OverWorld8.SubItems.Add($"1");
            OverWorld8.SubItems.Add($"5");
            OverWorld8.SubItems.Add(PluginLocalization.IsChinese ? "35(5V特攻不满)" : "35 (5 IV, SpA not perfect)");
            OverWorld8.SubItems.Add($"5");
            SeedInstroList.Items.Add(OverWorld8);
            var Roaming8b = new ListViewItem(PluginLocalization.IsChinese ? "Roaming8b(锁3V，0速无方块)" : "Roaming8b (3 fixed IVs; 0 Spe cannot be square shiny)");
            Roaming8b.SubItems.Add(PluginLocalization.IsChinese ? "锁3V" : "3 fixed IVs");
            Roaming8b.SubItems.Add($"20");
            Roaming8b.SubItems.Add($"18");
            Roaming8b.SubItems.Add($"8");
            Roaming8b.SubItems.Add($"28");
            SeedInstroList.Items.Add(Roaming8b);
        }

    }
}
