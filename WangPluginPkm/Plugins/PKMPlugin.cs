using System;
using System.Windows.Forms;
using WangPluginPkm.GUI;
namespace WangPluginPkm.Plugins
{
    internal class PKMPlugin: WangPluginPkm
    {
        
            public override string Name => "PKM编辑器/PKM Editor";
            public override int Priority => 7;

            protected override void AddPluginControl(ToolStripDropDownItem modmenu)
            {
                var ctrl = new ToolStripMenuItem(Name)
                {
                    Image =    Properties.Resources.GoPark
                };
                ctrl.Click += OpenForm;
                ctrl.Name = "PKM编辑器/PKM Editor";
                modmenu.DropDownItems.Add(ctrl);

            }

            private void OpenForm(object sender, EventArgs e)
            {

                var form = new PKMEditorUI(SaveFileEditor, PKMEditor);
                form.Show();
            }
        }
}
