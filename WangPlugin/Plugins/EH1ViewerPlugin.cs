using System;
using System.Windows.Forms;
using WangPlugin.GUI;

namespace WangPlugin.Plugins
{
    internal class EH1ViewerPlugin: WangPlugin
    {
        public override string Name => "EH1查看器/EH1 Viewer";
        public override int Priority => 8;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.Home
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "EH1查看器/EH1 Viewer";
            modmenu.DropDownItems.Add(ctrl);

        }

        private void OpenForm(object sender, EventArgs e)
        {

            var form = new EH1ViewerUI(SaveFileEditor, PKMEditor);
            form.Show();
        }
    }
}
