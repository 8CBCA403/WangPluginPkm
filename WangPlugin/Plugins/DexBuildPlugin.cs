using System;
using System.Windows.Forms;
using WangPlugin.GUI;

namespace WangPlugin.Plugins
{
    internal class DexBuildPlugin: WangPlugin
    {
        public override string Name => "自定ID转换";
        public override int Priority => 4;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.ID
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "自定ID转换";
            modmenu.DropDownItems.Add(ctrl);

        }

        private void OpenForm(object sender, EventArgs e)
        {

            var form = new DexBuildForm(SaveFileEditor);
            form.ShowDialog();
        }
    }
}
