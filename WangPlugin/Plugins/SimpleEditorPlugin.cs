using System;
using System.Windows.Forms;
using WangPlugin.GUI;

namespace WangPlugin.Plugins
{
    internal class SimpleEditorPlugin: WangPlugin
    {
        public override string Name => "常用功能/Simple Editor";
        public override int Priority => 5;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.pokeball
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "常用功能/Simple Editor";
            modmenu.DropDownItems.Add(ctrl);

        }

        private void OpenForm(object sender, EventArgs e)
        {

            var form = new SimpleEditor(SaveFileEditor,PKMEditor);
            form.ShowDialog();
        }
    }
}
