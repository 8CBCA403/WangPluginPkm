using System;
using System.Windows.Forms;
using PKHeX.Core;
using System.Linq;
namespace WangPlugin
{
    public class WangPlugin : IPlugin
    {
        public string Name => nameof(WangPlugin);
        public int Priority => 1; // Loading order, lowest is first.

        // Initialized on plugin load
        public ISaveFileProvider SaveFileEditor { get; private set; } = null!;
        public IPKMView PKMEditor { get; private set; } = null!;

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
            HandleM1.Click += (s, e) => MessageBox.Show($"搞定了");
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
            var sav = SaveFileEditor.SAV;
            var pkm = HandleMethod1(PKMEditor.Data);
            sav.SetBoxSlotAtIndex(pkm,0,0);
            SaveFileEditor.ReloadSlots();
        }
        public  void ModifyPKM(PKM pkm)
        {
            CommonEdits.SetShiny(pkm);
        }
        public PKM HandleMethod1(PKM pkm)
        {
            var Currentpid = PKMEditor.Data.PID;
            var highpid = Currentpid >> 16;
            var lowpid = Currentpid &0xFF;
            var fs = Gen3RngUtil.findEmeraldFrame(highpid, 0, 2700);
            foreach (var f in fs)
         {
                if (f.pid != 0)
                {
                    pkm.PID = f.pid;
                    pkm.EncryptionConstant = pkm.PID;
                    pkm.Nature =  (int)pkm.PID % 25;
                    pkm.IV_ATK = (int)f.ivs.atk;
                    pkm.IV_DEF = (int)f.ivs.def;
                    pkm.IV_HP = (int)f.ivs.hp;
                    pkm.IV_SPD = (int)f.ivs.spd;
                    pkm.IV_SPE = (int)f.ivs.spe;
                    pkm.IV_SPA = (int)f.ivs.spa;
                    break;
                }
                else
                    continue;
          }
            return pkm;
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
