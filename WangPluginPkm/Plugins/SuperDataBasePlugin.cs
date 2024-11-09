using System;
using System.Windows.Forms;
using WangPluginPkm.GUI;

namespace WangPluginPkm.Plugins
{
    public class SuperDataBasePlugin : WangPluginPkm
    {
        public override string Name => "超级数据库/Super DataBase";
        public override int Priority => 6;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.dataBase
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "超级数据库/Super DataBase";
            modmenu.DropDownItems.Add(ctrl);

        }

        private void OpenForm(object sender, EventArgs e)
        {

            var form = new SuperDataBase(SaveFileEditor, PKMEditor);
            form.Show();
        }
    }
}
