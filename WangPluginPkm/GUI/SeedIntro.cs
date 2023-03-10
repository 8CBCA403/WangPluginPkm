using System.Windows.Forms;
namespace WangPluginPkm.GUI
{
    public partial class SeedIntro : Form
    {
        public SeedIntro()
        {
            InitializeComponent();
            IS();
        }
        public void IS()
        {
            SeedInstroList.View = View.Details;
            SeedInstroList.GridLines = true;
            SeedInstroList.LabelEdit = false;
            SeedInstroList.FullRowSelect = true;
            SeedInstroList.Columns.Add("预制种子信息", 200);
            SeedInstroList.Columns.Add("6个0", 100);
            SeedInstroList.Columns.Add("0攻", 100);
            SeedInstroList.Columns.Add("0速", 100);
            SeedInstroList.Columns.Add("0攻0速", 100);
            SeedInstroList.Columns.Add("6V", 100);
            SeedInstroList.Columns.Add("0攻0特攻0速", 100);
            var Method1 = new ListViewItem($"Method1(固定PID)");
            Method1.SubItems.Add($"6");
            Method1.SubItems.Add($"4");
            Method1.SubItems.Add($"2");
            Method1.SubItems.Add($"2");
            Method1.SubItems.Add($"6");
            SeedInstroList.Items.Add(Method1);
            var Method2 = new ListViewItem($"Method2(固定PID)");
            Method2.SubItems.Add($"6");
            Method2.SubItems.Add($"4");
            Method2.SubItems.Add($"2");
            Method2.SubItems.Add($"2");
            Method2.SubItems.Add($"6");
            SeedInstroList.Items.Add(Method2);
            var Method3 = new ListViewItem($"Method3(固定PID)");
            Method3.SubItems.Add($"6");
            Method3.SubItems.Add($"4");
            Method3.SubItems.Add($"2");
            Method3.SubItems.Add($"2");
            Method3.SubItems.Add($"6");
            SeedInstroList.Items.Add(Method3);
            var Method4 = new ListViewItem($"Method4(固定PID)");
            Method4.SubItems.Add($"4");
            Method4.SubItems.Add($"2");
            Method4.SubItems.Add($"4");
            Method4.SubItems.Add($"4");
            Method4.SubItems.Add($"4");
            SeedInstroList.Items.Add(Method4);
            var Method1_Unown = new ListViewItem($"Method1未知图腾(固定PID)");
            Method1_Unown.SubItems.Add($"R,M,V,R,M,V");
            Method1_Unown.SubItems.Add($"R,U,R,U");
            Method1_Unown.SubItems.Add($"C,C");
            Method1_Unown.SubItems.Add($"P,P");
            Method1_Unown.SubItems.Add($"G,X,Y,G,X,Y");
            SeedInstroList.Items.Add(Method1_Unown);
            var Method2_Unown = new ListViewItem($"Method2未知图腾(固定PID)");
            Method2_Unown.SubItems.Add($"E,!,M,E,!,M");
            Method2_Unown.SubItems.Add($"N,T,N,T");
            Method2_Unown.SubItems.Add($"U,U");
            Method2_Unown.SubItems.Add($"R,R");
            Method2_Unown.SubItems.Add($"Y,W,B,Y,W,B");
            SeedInstroList.Items.Add(Method2_Unown);
            var Method3_Unown = new ListViewItem($"Method3未知图腾(固定PID)");
            Method3_Unown.SubItems.Add($"N,Y,R,N,Y,R");
            Method3_Unown.SubItems.Add($"R,Q,R,Q");
            Method3_Unown.SubItems.Add($"O,O");
            Method3_Unown.SubItems.Add($"H,H");
            Method3_Unown.SubItems.Add($"X,O,Y,X,O,Y");
            SeedInstroList.Items.Add(Method3_Unown);
            var Method4_Unown = new ListViewItem($"Method4未知图腾(固定PID)");
            Method4_Unown.SubItems.Add($"R,F,R,F");
            Method4_Unown.SubItems.Add($"S,S");
            Method4_Unown.SubItems.Add($"P,L,P,L");
            Method4_Unown.SubItems.Add($"A,M,A,M");
            Method4_Unown.SubItems.Add($"S,G,S,G");
            var XDColo = new ListViewItem($"XDColo(非队锁情况,固定PID)");
            XDColo.SubItems.Add($"4");
            XDColo.SubItems.Add($"4");
            XDColo.SubItems.Add($"2");
            XDColo.SubItems.Add($"4");
            XDColo.SubItems.Add($"6");
            SeedInstroList.Items.Add(XDColo);
            var OverWorld8 = new ListViewItem($"OverWorld8(只有方块)");
            OverWorld8.SubItems.Add($"8");
            OverWorld8.SubItems.Add($"6");
            OverWorld8.SubItems.Add($"1");
            OverWorld8.SubItems.Add($"5");
            OverWorld8.SubItems.Add($"35(5V特攻不满)");
            OverWorld8.SubItems.Add($"5");
            SeedInstroList.Items.Add(OverWorld8);
            var Roaming8b = new ListViewItem($"Roaming8b(锁3V，0速无方块)");
            Roaming8b.SubItems.Add($"锁3V");
            Roaming8b.SubItems.Add($"20");
            Roaming8b.SubItems.Add($"18");
            Roaming8b.SubItems.Add($"8");
            Roaming8b.SubItems.Add($"28");
            SeedInstroList.Items.Add(Roaming8b);
        }

    }
}
