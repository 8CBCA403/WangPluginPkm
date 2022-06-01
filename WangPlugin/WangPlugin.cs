using PKHeX.Core;
using System;
using System.Threading;
using System.Windows.Forms;
namespace WangPlugin
{
    public  class WangPlugin : IPlugin
    {
        public string Name => nameof(WangPlugin);
        public int Priority => 1; // Loading order, lowest is first.
        // Initialized on plugin load
        public ISaveFileProvider SaveFileEditor { get; private set; } = null!;
        public IPKMView PKMEditor { get; private set; } = null!;
        private readonly CancellationTokenSource tokenSource = new();
        public void Initialize(params object[] args)
        {
            Console.WriteLine($"Loading {Name}...");
            SaveFileEditor = (ISaveFileProvider)Array.Find(args, z => z is ISaveFileProvider);
            PKMEditor = (IPKMView)Array.Find(args, z => z is IPKMView);
            var menu = (ToolStrip)Array.Find(args, z => z is ToolStrip);
            LoadMenuStrip(menu);
        }
        private void LoadMenuStrip(ToolStrip menuStrip)
        {
            var items = menuStrip.Items;
            string name = nameof(menuStrip);
            if (items.Find("Menu_Tools", false)[0] is not ToolStripDropDownItem tools)
                throw new ArgumentException(name);
            AddPluginControl(tools);
        }
        private void AddPluginControl(ToolStripDropDownItem tools)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.SuperWang
            };
            tools.DropDownItems.Add(ctrl);
            var form = tools.GetCurrentParent().FindForm();
            if (form is not null)
                form.Icon = Properties.Resources.SW;
            var RNGForm = new ToolStripMenuItem($"RNG面板")
            {
                Image = Properties.Resources.RNG
            };
            var Allshiny = new ToolStripMenuItem($"闪光器")
            {
                Image = Properties.Resources.Shiny
            };
            var SimpleEdit = new ToolStripMenuItem($"常用功能")
            {
                Image = Properties.Resources.pokeball
            };
            var Calc = new ToolStripMenuItem($"多功能计算器")
            {
                Image = Properties.Resources.Calc
            };
            var Dex = new ToolStripMenuItem($"自定ID转换器")
            {
                Image = Properties.Resources.ID
            };
            var ConvertEgg = new ToolStripMenuItem($"变蛋器")
            {
                Image = Properties.Resources.Egg
            };
            var GP1Edit = new ToolStripMenuItem($"GP1编辑器")
            {
                Image = Properties.Resources.GoPark
            };
            var HomeViewer = new ToolStripMenuItem($"Home查看器");
          
            var TESTmod = new ToolStripMenuItem($"ModTest(BUG)")
            {
                Image = Properties.Resources.TEST
            };
            var About = new ToolStripMenuItem($"关于")
            {
                Image = Properties.Resources.avatar
            };
            RNGForm.Click += (s, e) => OpenRNGForm();
            Allshiny.Click += (s, e) => OpenShiny();
            ConvertEgg.Click += (s, e) => OpenEggForm();
            Calc.Click += (s, e) => OpenCalc();
            SimpleEdit.Click += (s, e) => OpenSimpleEdit();
            Dex.Click += (s, e) => OpenDexBuildForm();
            GP1Edit.Click += (s, e) => OpenGPEdit();
            TESTmod.Click += (s, e) => OpenTESTForm();
            HomeViewer.Click += (s, e) => OpenHomeViewer();
            About.Click += (s, e) => MessageBox.Show("感谢！Thanks!", "About");
            ctrl.DropDownItems.Add(RNGForm);
            ctrl.DropDownItems.Add(Allshiny);
            ctrl.DropDownItems.Add(SimpleEdit);
            ctrl.DropDownItems.Add(ConvertEgg);
            ctrl.DropDownItems.Add(Calc);
            ctrl.DropDownItems.Add(Dex);
            ctrl.DropDownItems.Add(GP1Edit);
            ctrl.DropDownItems.Add(HomeViewer);
            ctrl.DropDownItems.Add(TESTmod);
            ctrl.DropDownItems.Add(About);
        }
        private static void OpenCalc()
        {
            var frm = new Calc();
            frm.Show();
        }
        private void OpenRNGForm()
        {
            var frm = new RNGForm(SaveFileEditor, PKMEditor);
            frm.Show();
        }
        private void OpenEggForm()
        {
            var frm = new ConvertToEgg(SaveFileEditor, PKMEditor);
            frm.Show();
        }
        private void OpenDexBuildForm()
        {
            var frm = new DexBuildForm(SaveFileEditor);
            frm.Show();
        }
        private void OpenSimpleEdit()
        {
            var frm = new SimpleEdit(SaveFileEditor, PKMEditor);
            frm.Show();
        }
        private void OpenGPEdit()
        {
            var frm = new GP1Edit(SaveFileEditor, PKMEditor);
            frm.Show();
        }
        private void OpenHomeViewer()
        {
            var frm =new HomeViewer(SaveFileEditor, PKMEditor);
            frm.Show();
        }
        private void OpenShiny()
        {
            MessageBox.Show("请确保本身全部精灵合法！\n不是100%准确，使用前请备份存档！", "SuperWang", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            var frm = new SetAllShiny(SaveFileEditor, PKMEditor);
            frm.Show();
        }
        private void OpenTESTForm()
        {
            var frm = new TESTForm(SaveFileEditor, PKMEditor);
            frm.Show();
        }
        public void NotifySaveLoaded()
        {
            Console.WriteLine($"{Name} was notified that a Save File was just loaded.");
        }
        public bool TryLoadFile(string filePath)
        {
            Console.WriteLine($"{Name} was provided with the file path, but chose to do nothing with it.");
            return false; // no action taken
        }
    }
}