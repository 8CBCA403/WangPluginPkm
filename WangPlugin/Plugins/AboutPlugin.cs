using System;
using System.Windows.Forms;
using WangPlugin.GUI;

namespace WangPlugin.Plugins
{
    internal class AboutPlugin: WangPlugin
    {
        public override string Name => "关于/About";
        public override int Priority => 11;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.avatar
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "关于/About";
            modmenu.DropDownItems.Add(ctrl);

        }

        private void OpenForm(object sender, EventArgs e)
        {

            var form = new AboutUI();
            form.Show();
        }
    }
}
