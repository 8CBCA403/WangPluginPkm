using System;
using WangPluginPkm.GUI;
using System.Windows.Forms;

namespace WangPluginPkm.Plugins
{
     public class RNGPlugin:WangPluginPkmPkm
    {
        public override string Name => "RNG面板/RNG Form";
        public override int Priority => 0;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.RNG
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "RNG面板/RNG Form";
            modmenu.DropDownItems.Add(ctrl);
        }
        private  void OpenForm(object sender, EventArgs e)
        {
           
            var form = new RNGForm(SaveFileEditor, PKMEditor);
            form.Show();
        }
    }
}
