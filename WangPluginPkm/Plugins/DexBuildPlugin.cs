using System;
using System.Windows.Forms;
using WangPluginPkm.GUI;

namespace WangPluginPkm.Plugins
{
    internal class DexBuildPlugin: WangPluginPkmPkm
    {
        public override string Name => "图鉴制作器/Dex Builder";
        public override int Priority => 4;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.ID
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "图鉴制作器/Dex Builder";
            modmenu.DropDownItems.Add(ctrl);

        }

        private void OpenForm(object sender, EventArgs e)
        {

            var form = new DexBuildForm(SaveFileEditor,PKMEditor);
            form.Show();
        }
    }
}
