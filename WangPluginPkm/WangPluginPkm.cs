using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using WangPluginPkm.PluginUtil;

namespace WangPluginPkm
{
    public abstract class WangPluginPkm : IPlugin
    {
        private const string ParentMenuName = "SuperWang";
        private const string ParentMenuParent = "Menu_Tools";
        private static readonly SoundPlayer Player = new();
        private static int HostInitialized;
        public abstract string Name { get; }
        public abstract int Priority { get; }
        public ISaveFileProvider SaveFileEditor { get; private set; } = null!;
        public IPKMView PKMEditor { get; private set; } = null!;

        public void Initialize(params object[] args)
        {
            SaveFileEditor = Array.Find(args, z => z is ISaveFileProvider) as ISaveFileProvider
                ?? throw new ArgumentException("Missing save file provider.", nameof(args));
            PKMEditor = Array.Find(args, z => z is IPKMView) as IPKMView
                ?? throw new ArgumentException("Missing PKM editor.", nameof(args));
            var menu = Array.Find(args, z => z is ToolStrip) as ToolStrip
                ?? throw new ArgumentException("Missing PKHeX menu strip.", nameof(args));

            if (Interlocked.Exchange(ref HostInitialized, 1) == 0)
                InitializeHost();

            LoadMenuStrip(menu);
        }

        private static void InitializeHost()
        {
            var config = PluginConfig.LoadConfig();
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += (_, _) =>
            {
                timer.Stop();
                timer.Dispose();
                var mainForm = Application.OpenForms
                    .Cast<Form>()
                    .FirstOrDefault(f => f.GetType().Name.Contains("PKHeX") || f.Name.Contains("Main"));

                if (mainForm != null)
                {
                    mainForm.Icon = Properties.Resources.SW;
                }
            };
            timer.Start();
            if (config.OpenSound)
            {
                Player.Stream = Properties.Resources.SuperSound;
                Player.Play();
            }
        }
        private void LoadMenuStrip(ToolStrip menuStrip)
        {
            var matches = menuStrip.Items.Find(ParentMenuParent, false);
            if (matches.Length == 0 || matches[0] is not ToolStripDropDownItem tools)
                return;
            var toolsitems = tools.DropDownItems;
            var modmenusearch = toolsitems.Find(ParentMenuName, false);
            var modmenu = GetModMenu(tools, modmenusearch);
            AddPluginControl(modmenu);
            PluginLocalization.Apply(modmenu.DropDownItems);
            PluginMenuIcons.Apply(modmenu);
        }
        private static ToolStripMenuItem GetModMenu(ToolStripDropDownItem tools, IReadOnlyList<ToolStripItem> search)
        {
            if (search.Count != 0 && search[0] is ToolStripMenuItem existing)
                return existing;

            var modmenu = CreateBaseGroupItem();
            tools.DropDownItems.Insert(0, modmenu);
            return modmenu;
        }

        private static ToolStripMenuItem CreateBaseGroupItem() => new(PluginLocalization.Translate("超王插件PKM"))
        {
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
