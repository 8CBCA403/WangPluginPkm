using PKHeX.Core;
using System;
using System.Threading;
using System.Windows.Forms;
namespace WangPlugin
{
    public class WangPlugin : IPlugin
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
                Image = Properties.Resources.icon1
            };
            tools.DropDownItems.Add(ctrl);
            var RNGForm = new ToolStripMenuItem($"RNG面板")
            {
                Image = Properties.Resources.RNG
            };
            var Allshiny = new ToolStripMenuItem($"全部闪光")
            {
                Image = Properties.Resources.Shiny
            };
            var SimpleEdit = new ToolStripMenuItem($"常用功能")
            {
                Image = Properties.Resources.Edit
            };
            
            var Calc = new ToolStripMenuItem($"性格计算器")
            {
                Image = Properties.Resources.Calc
            };
            var Sort = new ToolStripMenuItem($"简易排序")
            {
                Image = Properties.Resources.Sort
            };
            var ConvertEgg = new ToolStripMenuItem($"简易变蛋")
            {
                Image = Properties.Resources.Egg
            };
            RNGForm.Click += (s, e) => OpenRNGForm();
            Allshiny.Click += (s, e) => SetAllShiny.SetShiny(SaveFileEditor);
            ConvertEgg.Click += (s, e) => ConvertToEgg.Egg(PKMEditor.Data, PKMEditor, SaveFileEditor);
            Calc.Click += (s, e) =>OpenCalc();
            SimpleEdit.Click += (s, e) => OpenSimpleEdit();
            Sort.Click += (s, e) => SortPokemon.Sort(SaveFileEditor);
            ctrl.DropDownItems.Add(RNGForm);
            ctrl.DropDownItems.Add(Allshiny);
            ctrl.DropDownItems.Add(SimpleEdit);
            ctrl.DropDownItems.Add(ConvertEgg);
            ctrl.DropDownItems.Add(Calc);
            ctrl.DropDownItems.Add(Sort);
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
        private void OpenSimpleEdit()
        {
            var frm = new SimpleEdit(SaveFileEditor, PKMEditor);
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
