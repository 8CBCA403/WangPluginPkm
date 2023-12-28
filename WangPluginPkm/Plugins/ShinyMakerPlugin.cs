using System;
using System.Windows.Forms;
using WangPluginPkm.GUI;

namespace WangPluginPkm.Plugins
{
    public class ShinyMakerPlugin : WangPluginPkm
    {
        public override string Name => "闪光器/Shiny Maker";
        public override int Priority => 1;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.Shiny
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "闪光器/Shiny Maker";
            modmenu.DropDownItems.Add(ctrl);

        }

        private void OpenForm(object sender, EventArgs e)
        {
            MessageBox.Show("请确保本身全部精灵合法！\n不是100%准确，使用前请备份存档！", "SuperWang", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            var form = new ShinyMakerUI(SaveFileEditor, PKMEditor);
            form.Show();
        }
    }
}
