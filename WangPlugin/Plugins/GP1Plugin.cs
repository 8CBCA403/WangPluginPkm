using System;
using System.Windows.Forms;
using WangPlugin.GUI;
namespace WangPlugin.Plugins
{
    internal class GP1Plugin: WangPlugin
    {
        
            public override string Name => "GP1编辑器/GP1 Editor";
            public override int Priority => 6;

            protected override void AddPluginControl(ToolStripDropDownItem modmenu)
            {
                var ctrl = new ToolStripMenuItem(Name)
                {
                    Image = Properties.Resources.GoPark
                };
                ctrl.Click += OpenForm;
                ctrl.Name = "GP1编辑器/GP1 Editor";
                modmenu.DropDownItems.Add(ctrl);

            }

            private void OpenForm(object sender, EventArgs e)
            {

                var form = new GP1Editor(SaveFileEditor, PKMEditor);
                form.ShowDialog();
            }
        }
}
