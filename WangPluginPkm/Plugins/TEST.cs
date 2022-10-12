#region
/*using System;
using System.Windows.Forms;
using WangPluginPkm.GUI;

namespace WangPluginPkm.Plugins
{
    internal class TEST: WangPluginPkm
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