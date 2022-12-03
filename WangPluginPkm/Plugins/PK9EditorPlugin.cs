using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WangPluginPkm.GUI;

namespace WangPluginPkm.Plugins
{
    internal class PK9EditorPlugin : WangPluginPkm
    {
        public override string Name => "PK9 Editor/PK9编辑器";
        public override int Priority => 7;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.PK9
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "PK9 Editor/PK9 编辑器";
            modmenu.DropDownItems.Add(ctrl);

        }

        private void OpenForm(object sender, EventArgs e)
        {

            var form = new PK9Editor(SaveFileEditor, PKMEditor);
            form.Show();
        }
    }
}
