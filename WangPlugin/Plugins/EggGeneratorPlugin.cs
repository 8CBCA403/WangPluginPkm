using System;
using WangPlugin.GUI;
using System.Windows.Forms;

namespace WangPlugin.Plugins
{
    internal class EggGeneratorPlugin: WangPlugin
    {
        public override string Name => "变蛋器/Egg Generator";
        public override int Priority => 2;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.Egg
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "变蛋器/Egg Generator";
            modmenu.DropDownItems.Add(ctrl);

        }

        private void OpenForm(object sender, EventArgs e)
        {

            var form = new EggGeneratorUI(SaveFileEditor, PKMEditor);
            form.Show();
        }
    }
}
