using System.Windows.Forms;
using PKHeX.Core;
using System;
using System.Collections.Generic;
using PKHeX.Core.Enhancements;
using PKHeX.Core.AutoMod;
using System.Diagnostics;
using System.Linq;
using System.IO;
namespace WangPlugin.GUI
{
    partial class BattleKingUI : Form
    {
       
      //  public string Page;
        public  List<ShowdownSet> Sets = new();
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        private static readonly EncounterOrder[] EncounterPriority =
       {
            EncounterOrder.Egg, EncounterOrder.Static, EncounterOrder.Trade, EncounterOrder.Slot, EncounterOrder.Mystery,
        };
        public BattleKingUI(ISaveFileProvider sav, IPKMView editor)
        {
            InitializeComponent();
            SAV = sav;
            Editor = editor;
        }
        
        private void IsRunning(bool running)
        {
            ImportPKM_BTN.Enabled = !running;
            if (running)
                ConditionBox.Text = "Dumping...";
            else
                ConditionBox.Text = "Nothing to check";
        }
        private void LoadBattleTeam_BTN_Click(object sender, System.EventArgs e)
        {
            var url = UrlBox.Text.Trim();
            var suburl = url.Split('\n');
            if (suburl.Length > 0)
                for (int i = 0; i < suburl.Length; i++)
                {
                    TeamPasteInfo info;
                    try
                    {
                        info = new TeamPasteInfo(suburl[i]);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("An error occurred while trying to obtain the contents of the URL.");
                        return;
                    }
                    if (!info.Valid)
                    {
                        MessageBox.Show("The data inside the URL are not valid Showdown Sets");
                        return;
                    }
                    if (info.Source == TeamPasteInfo.PasteSource.None)
                    {
                        MessageBox.Show("The URL provided is not from a supported website.");
                        return;
                    }
                    Import(info.Sets);
                  //  var response = $"All sets generated from the following URL: {info.URL}";
                   // MessageBox.Show(response);
                }
            MessageBox.Show($"导入了{suburl.Length}个队伍");
        }
        private void LoadTeamFromPSCode_BTN_Click(object sender, EventArgs e)
        {
            var text = GetTextShowdownData(PSBox.Text.TrimEnd());
            if (string.IsNullOrWhiteSpace(text))
                return;
            Import(text!);
        }
        private void ClearAllBox_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(ClearPKM);
            SAV.ReloadSlots();
        }
        private void ImportPKM_BTN_Click(object sender, EventArgs e)
        {
            IsRunning(true);
            int n = 0;
            string supported = string.Join(";", SAV.SAV.PKMExtensions.Select(s => $"*.{s}").Concat(new[] { "*.pk" }));
            using var ofd = new OpenFileDialog
            {
                Filter = "All Files|*.*" + $"|Decrypted PKM File (*.pk)|" + supported,
                Multiselect = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in ofd.FileNames)
                {
                    GenSmogonSets(OpenFromPath(file));
                    n++;
                }
            }
            IsRunning(false);
            MessageBox.Show($"导出了{n}只");
        }
        public void Import(string source)
        {
            if (ShowdownUtil.IsTeamBackup(source))
            {
                var teams = ShowdownTeamSet.GetTeams(source);
                var names = teams.Select(z => z.Summary);
                MessageBox.Show(string.Join(Environment.NewLine, names));
                Import(teams.SelectMany(z => z.Team).ToList());
                return;
            }
            var sets = ShowdownUtil.ShowdownSets(source);
            Import(sets);
        }
        public void Import(IEnumerable<string> sets)
        {
            var entries = sets.Select(z => new ShowdownSet(z)).ToList();
            Import(entries);
        }
        public void Import(IReadOnlyList<ShowdownSet> sets, bool skipDialog = false)
        {
            if (sets.Count == 1)
            {
                ImportSetToTabs(sets[0], skipDialog);
            }
            else
            {
                var replace = (Control.ModifierKeys & Keys.Alt) != 0;
                 ImportSetsToBoxes(sets, replace);
            }

        }
        private void ImportSetToTabs(ShowdownSet set, bool skipDialog = false)
        {
            var regen = new RegenTemplate(set, SAV.SAV.Generation);
            Debug.WriteLine($"Commencing Import of {GameInfo.Strings.Species[set.Species]}");
            var timer = Stopwatch.StartNew();

            var sav = SAV.SAV;
            var legal = sav.GetLegalFromSet(regen, out var msg);
            timer.Stop();

            if (msg is LegalizationResult.Timeout or LegalizationResult.Failed)
            {
                Legalizer.Dump(regen, msg == LegalizationResult.Failed);

                string analysis = null;
                if (msg is LegalizationResult.Failed)
                    analysis = regen.SetAnalysis(sav, sav.BlankPKM);

                var errorstr = msg == LegalizationResult.Failed ? "failed to generate" : "timed out";
                var invalid_set_error = (analysis == null ? $"Set {errorstr}." : $"Set Invalid: {analysis}") +
                    "\n\nIf you are sure this set is valid, please create an issue on GitHub and upload the error_log.txt file in the issue." +
                    "\n\nAlternatively, join the support Discord and post the same file in the #autolegality-livehex-help channel.";
            }
            Debug.WriteLine("Single Set Genning Complete. Loading final data to tabs.");
            Editor.PopulateFields(legal);
            var timespan = timer.Elapsed;
            Debug.WriteLine($"Time to complete {nameof(ImportSetToTabs)}: {timespan.Minutes:00} minutes {timespan.Seconds:00} seconds {timespan.Milliseconds / 10:00} milliseconds");
        
        }
        private void ImportSetsToBoxes(IReadOnlyList<ShowdownSet> sets, bool replace)
        {
            var timer = Stopwatch.StartNew();
            var sav = SAV.SAV;
            var BoxData = sav.BoxData;
            var start = SAV.CurrentBox * sav.BoxSlotCount;
            Debug.WriteLine($"Commencing Import of {sets.Count} set(s).");
            var result = sav.ImportToExisting(sets, BoxData, out var invalid, out var timeout, start, replace);
            Debug.WriteLine("Multi Set Genning Complete. Setting data to the save file and reloading view.");
            SAV.ReloadSlots();
            // Debug Statements
            timer.Stop();
            var timespan = timer.Elapsed;
            Debug.WriteLine($"Time to complete {nameof(ImportSetsToBoxes)}: {timespan.Minutes:00} minutes {timespan.Seconds:00} seconds {timespan.Milliseconds / 10:00} milliseconds");
           
        }
        private string TranslatorZH(string text)
        {
            string[] zh = text.Split(';');
            string s="";
            string t="";
            for(int i=0;i<zh.Count();i++)
            {
                t.Replace(";", "");
                t=PSTranslator<PKM>.Chinese2Showdown(zh[i]);
                s =s+ t;
                s += "\n\n";
            }
            return s;
        }
        private  string GetTextShowdownData(string text)
        {
            
            
            if (ShowdownUtil.IsTextShowdownData(text))
                return text;

           
            return null;
        }
        private void GenSmogonSets(PKM rough)
        {
            SmogonSetList info;
            info = new SmogonSetList(rough);
            ImportSetsToBoxes(info.Sets, false);
        }
        private PKM OpenFromPath(string path)
        {
            var fi = new FileInfo(path);
            if (!fi.Exists)
                return null;
            string ext = fi.Extension;
            byte[] input;  
            input = File.ReadAllBytes(path); 
            FileUtil.TryGetPKM(input, out var pk, ext);
            return pk;
        }

       
        public static void ClearPKM(PKM pkm)
        {
            pkm.Species = 0;
        }

        private void Test_BTN_Click(object sender, EventArgs e)
        {
 
        }
    }
}
