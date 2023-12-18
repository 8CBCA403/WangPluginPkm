using System;
using System.Windows.Forms;
using WangPluginPkm.PluginUtil.BattleKingBase;

namespace WangPluginPkm.GUI
{
    public partial class TeamForm : Form
    {
        public int i = 0;
        public TeamForm(int n)
        {
            InitializeComponent();
            i = n;
        }

        private void Import_BTN_Click(object sender, EventArgs e)
        {
            string a = "";
            switch (i)
            {
                case 0:
                    foreach (var item in TeamListBox.CheckedItems)
                    {
                        a += (((DataItem)item).PS);
                    }
                    break;
                case 1:
                    foreach (var item in TeamListBox.CheckedItems)
                    {
                        a += (((TournamentSub)item).Paste) + Environment.NewLine;
                    }
                    break;
            }
            PSText.Text += a;
        }

        private void Clear_BTN_Click(object sender, EventArgs e)
        {
            PSText.Clear();
        }

        private void TeamListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
