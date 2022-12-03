using System;
using System.Windows.Forms;
using WangPluginPkm.GUI;

namespace WangPluginPkm.Plugins
{
    internal class DistributionPlugin: WangPluginPkm
    {
        public override string Name => "派送器/Distribution Tools";
        public override int Priority => 3;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.Distribution
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "派送器/Distribution Tools";
            modmenu.DropDownItems.Add(ctrl);

        }

        private void OpenForm(object sender, EventArgs e)
        {

            var form = new DistributionUI(SaveFileEditor, PKMEditor);
            form.Show();
        }
    }
}
