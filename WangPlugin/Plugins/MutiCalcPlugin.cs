using System;
using System.Windows.Forms;
using WangPlugin.GUI;
namespace WangPlugin.Plugins
{
    public class MutiCalcPlugin: WangPlugin
    {
        public override string Name => "多功能计算器";
        public override int Priority => 3;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name) 
            { 
                Image = Properties.Resources.Calc 
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "多功能计算器";
            modmenu.DropDownItems.Add(ctrl);
        }

        private static void OpenForm(object sender, EventArgs e)
        {
           
            var form = new MutiCalcUI();
            form.ShowDialog();
        }
    }
}
