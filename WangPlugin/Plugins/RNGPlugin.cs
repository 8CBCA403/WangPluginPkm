using System;
using WangPlugin.GUI;
using PKHeX.Core;
using System.Windows.Forms;

namespace WangPlugin.Plugins
{
     public class RNGPlugin:WangPlugin
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
            form.ShowDialog();
        }
    }
}
