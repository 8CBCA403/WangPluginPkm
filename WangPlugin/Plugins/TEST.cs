#region
/*using System;
using System.Windows.Forms;
using WangPlugin.GUI;

namespace WangPlugin.Plugins
{
    internal class TEST: WangPlugin
    {
        public override string Name => "Test";
        public override int Priority => 10;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.TEST
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "Test";
            modmenu.DropDownItems.Add(ctrl);

        }

        private void OpenForm(object sender, EventArgs e)
        {

            var form = new TESTForm(SaveFileEditor, PKMEditor);
            form.Show();
        }
    }
}*/
#endregion