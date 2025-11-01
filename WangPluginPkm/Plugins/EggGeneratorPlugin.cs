using System;
using System.Windows.Forms;
using WangPluginPkm.GUI;
using PKHeX.Core;
namespace WangPluginPkm.Plugins
{
    public class EggGeneratorPlugin : WangPluginPkm
    {
        public override string Name => "变蛋器/Egg Generator";
        public override int Priority => 2;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            if (SaveFileEditor.SAV.Version != GameVersion.PLA && SaveFileEditor.SAV.Version != GameVersion.ZA)
            {

                var ctrl = new ToolStripMenuItem(Name)
                {
                    Image = Properties.Resources.Egg
                };
                ctrl.Click += OpenForm;
                ctrl.Name = "变蛋器/Egg Generator";
                modmenu.DropDownItems.Add(ctrl);
            }
            else
                return;

        }

        private void OpenForm(object sender, EventArgs e)
        {
            if (SaveFileEditor.SAV.Version != GameVersion.PLA && SaveFileEditor.SAV.Version != GameVersion.ZA)
            {
                var form = new EggGeneratorUI(SaveFileEditor, PKMEditor);
                form.Show();
            }
            else
            {
                MessageBox.Show("该存档版本不支持变蛋器功能。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
