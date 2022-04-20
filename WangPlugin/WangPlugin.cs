using PKHeX.Core;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
         

        private CancellationTokenSource tokenSource = new();

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
            if (!(items.Find("Menu_Tools", false)[0] is ToolStripDropDownItem tools))
                throw new ArgumentException(nameof(menuStrip));
            AddPluginControl(tools);
        }

        private void AddPluginControl(ToolStripDropDownItem tools)
        {
            var ctrl = new ToolStripMenuItem(Name);
            tools.DropDownItems.Add(ctrl);
            var Calc = new ToolStripMenuItem($"性格计算器");
            var Allshiny = new ToolStripMenuItem($"全部闪光");
            var HandleM1 = new ToolStripMenuItem($"处理mod1");
            Allshiny.Click += (s, e) => ModifySaveFile();
            HandleM1.Click += (s, e) => ModifyPKM();
            Calc.Click += (s, e) =>Open();
            ctrl.DropDownItems.Add(Allshiny);
            ctrl.DropDownItems.Add(HandleM1);
            ctrl.DropDownItems.Add(Calc);
            Console.WriteLine($"{Name} added menu items.");
        }
        public void ModifySaveFile()
        {
            var sav = SaveFileEditor.SAV;
            sav.ModifyBoxes(ModifyPKM);
            SaveFileEditor.ReloadSlots();
        }
        public void ModifyPKM()
        {
            var pkm = HandleMethod1(PKMEditor.Data);
            PKMEditor.PopulateFields(pkm, false);
            SaveFileEditor.ReloadSlots();
        }
        public  void ModifyPKM(PKM pkm)
        {
            CommonEdits.SetShiny(pkm);
        }
        public PKM HandleMethod1(PKM pkm)
        {
            var Currentpid = PKMEditor.Data.PID;
          //var highpid = Currentpid >> 16;
          //var lowpid = Currentpid &0xFF;
            Random r = new Random();
            short rndnum = (short)r.Next(0, 65536);
            var seed = Util.Rand32();
           while (true)
           {
           pkm = Method1RNG.GenPkm(pkm,seed, PKMEditor.Data.TID, PKMEditor.Data.SID);
           if (GetShinyXor(pkm.PID, pkm.TID, pkm.SID)<8)
           {
           pkm.RefreshChecksum();
           return pkm;
           }
           seed = Method1RNG.Next(seed);
           }       
        }
        private static uint GetShinyXor(uint pid, int TID, int SID)
        {
            return ((uint)(TID ^ SID) ^ ((pid >> 16) ^ (pid & 0xFFFF)));
        }
        private void Open()
        {
            var frm = new calc();
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
