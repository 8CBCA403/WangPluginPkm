using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WangPluginPkm.GUI;

namespace WangPluginPkm.Plugins
{
    public class SuperDataBasePlugin : WangPluginPkm
    {
        public override string Name => "超级数据库";
        public override int Priority => 10;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.dataBase
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "超级数据库";
            modmenu.DropDownItems.Add(ctrl);

        }

        private void OpenForm(object sender, EventArgs e)
        {

            var form = new SuperDataBase(SaveFileEditor, PKMEditor);
            form.Show();
        }
    }
}
