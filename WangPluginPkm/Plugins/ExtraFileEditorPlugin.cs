using System;
using System.Windows.Forms;
using WangPluginPkm.GUI;
namespace WangPluginPkm.Plugins
{
    public class ExtraFileEditorPlugin : WangPluginPkm
    {

        public override string Name => "额外文件编辑器/ExtraFileEditor";
        public override int Priority => 10;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.GoPark
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "额外文件编辑器/ExtraFileEditor";
            modmenu.DropDownItems.Add(ctrl);

        }

        private void OpenForm(object sender, EventArgs e)
        {

            var form = new ExtraFileEditor(SaveFileEditor, PKMEditor);
            form.Show();
        }
    }
}
