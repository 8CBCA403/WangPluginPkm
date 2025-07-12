using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using WangPluginPkm.PluginUtil;

namespace WangPluginPkm
{
    public abstract class WangPluginPkm : IPlugin
    {
        private const string ParentMenuName = "SuperWang";
        private const string ParentMenuText = "超王插件PKM";
        private const string ParentMenuParent = "Menu_Tools";
        private SoundPlayer Player = new SoundPlayer();
        public abstract string Name { get; }
        public abstract int Priority { get; }
        public ISaveFileProvider SaveFileEditor { get; private set; } = null!;
        public IPKMView PKMEditor { get; private set; } = null!;

        public IEncounterGenerator EncounterGenerator { get; private set; } = null!;
        public object[] globalArgs;

        public void Initialize(params object[] args)
        {
            var config = PluginConfig.LoadConfig();
            globalArgs = args;
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 500; 
            timer.Tick += (_, _) =>
            {
                timer.Stop(); 
                var mainForm = Application.OpenForms
                    .Cast<Form>()
                    .FirstOrDefault(f => f.GetType().Name.Contains("PKHeX") || f.Name.Contains("Main"));

                if (mainForm != null)
                {
                    mainForm.Icon = Properties.Resources.SW;
                }
            };
            timer.Start();
            SaveFileEditor = (ISaveFileProvider)Array.Find(args, z => z is ISaveFileProvider);
            PKMEditor = (IPKMView)Array.Find(args, z => z is IPKMView);
            var menu = (ToolStrip)Array.Find(args, z => z is ToolStrip);
            if (config.OpenSound)
            {
                Player.Stream = Properties.Resources.SuperSound;
                Player.Play();
            }
            LoadMenuStrip(menu);
        }
        private void LoadMenuStrip(ToolStrip menuStrip)
        {
            var items = menuStrip.Items;
            if (items.Find(ParentMenuParent, false)[0] is not ToolStripDropDownItem tools)
                return;
            var toolsitems = tools.DropDownItems;
            var modmenusearch = toolsitems.Find(ParentMenuName, false);
            var modmenu = GetModMenu(tools, modmenusearch);
            AddPluginControl(modmenu);
        }
        private static ToolStripMenuItem GetModMenu(ToolStripDropDownItem tools, IReadOnlyList<ToolStripItem> search)
        {
            if (search.Count != 0)
                return (ToolStripMenuItem)search[0];

            var modmenu = CreateBaseGroupItem();
            tools.DropDownItems.Insert(0, modmenu);
            return modmenu;
        }

        private static ToolStripMenuItem CreateBaseGroupItem() => new(ParentMenuText)
        {
            Image = Properties.Resources.SuperWang,
            Name = ParentMenuName,
        };
        protected abstract void AddPluginControl(ToolStripDropDownItem modmenu);


        public void NotifySaveLoaded()
        {
            Console.WriteLine($"{Name} was notified that a Save File was just loaded.");
        }
        public bool TryLoadFile(string filePath)
        {
            Console.WriteLine($"{Name} was provided with the file path, but chose to do nothing with it.");
            return false;
        }

        internal class PkmCondition : global::WangPluginPkm.PkmCondition
        {
        }
    }
}