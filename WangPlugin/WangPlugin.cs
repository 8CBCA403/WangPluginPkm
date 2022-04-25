using PKHeX.Core;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Windows.Forms;
namespace WangPlugin
{
    public class WangPlugin : IPlugin
    {
        public string Name => nameof(WangPlugin);
        public int Priority => 1; // Loading order, lowest is first.
        public string ImageSource = @"D:\GITHUB\WangPlugin\WangPlugin\Resources\img\icon.jpg";
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
            if (!(items.Find("Menu_Tools", false)[0] is ToolStripDropDownItem tools))
                throw new ArgumentException(nameof(menuStrip));
            AddPluginControl(tools);
        }
        private void AddPluginControl(ToolStripDropDownItem tools)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = System.Drawing.Image.FromFile(ImageSource)
            };
            tools.DropDownItems.Add(ctrl);
            var RNGForm = new ToolStripMenuItem($"RNG面板");
            var Allshiny = new ToolStripMenuItem($"全部闪光");
            var Calc = new ToolStripMenuItem($"性格计算器");
            var Read = new ToolStripMenuItem($"简易排序");
            RNGForm.Click += (s, e) => OpenRNGForm();
            Allshiny.Click += (s, e) => SetShiny();
            Calc.Click += (s, e) =>OpenCalc();
            Read.Click += (s, e) => SortPokemon();
            ctrl.DropDownItems.Add(RNGForm);
            ctrl.DropDownItems.Add(Allshiny);
            ctrl.DropDownItems.Add(Calc);
            ctrl.DropDownItems.Add(Read);
            //  Console.WriteLine($"{Name} added menu items.");
        }
        public void SetShiny()
        {
            var sav = SaveFileEditor.SAV;
            sav.ModifyBoxes(SetAllShiny);
            SaveFileEditor.ReloadSlots();
        }
        public  void SetAllShiny(PKM pkm)
        {
            CommonEdits.SetShiny(pkm);
        }
        public void SortPokemon()
        {
            var sav = SaveFileEditor.SAV;
            List<PKM> PokeList = new List<PKM>();
            var PokeArray = new PKM[30];
            int  i,j;
          for (i = 0; i < 30; i++)
          {
                for (j = 0; j < 30; j++)
                {
                    
                    PKM pk = sav.GetBoxSlotAtIndex(i, j);
                    if (pk.Species == 0)
                        break;
                    PokeList.Add(pk);
                }
            }
            var count = PokeList.Count;
            var box = count / 30;
            var remin = count % 30;
            int n = 0;
            List<PKM> sorted = PokeList.OrderBy(c => c.Species).ToList();
            for (i = 0; i <box; i++)
            {
                for (j = 0; j < 30; j++)
                {
                    sav.SetBoxSlotAtIndex(sorted[i*30+j], i, j);
                    n++;
                }
             }
           /* for(i=0;i<count-n;i++)
            {
                sav.SetBoxSlotAtIndex(sorted[n+i], box+1, i);
            }*/
        }
        private void OpenCalc()
        {
            var frm = new calc();
            frm.Show();
        }
        private void OpenRNGForm()
        {
            var frm = new RNGForm(SaveFileEditor, PKMEditor);
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
