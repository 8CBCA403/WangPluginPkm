using System;
using System.Windows.Forms;
using WangPlugin.GUI;

namespace WangPlugin.Plugins
{
    internal class BattleKingPlugin:WangPlugin
    {
        public override string Name => "对战王/BattleKing";
        public override int Priority => 9;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.BattleKing
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "对战王/BattleKing";
            modmenu.DropDownItems.Add(ctrl);

        }

        private void OpenForm(object sender, EventArgs e)
        {

            var form = new BattleKingUI(SaveFileEditor, PKMEditor);
            form.Show();
        }
    }
}
