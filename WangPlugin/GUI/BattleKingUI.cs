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
    internal class BattleKingUI : Form
    {
        private Button LoadBattleTeam_BTN;
      //  public string Page;
        public  List<ShowdownSet> Sets = new();
        private RichTextBox UrlBox;
        private RichTextBox PSBox;
        private Button LoadTeamFromPSCode_BTN;
        private Button ImportPKM_BTN;
        private TextBox ConditionBox;
        private Button ClearAllBox_BTN;

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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleKingUI));
            this.LoadBattleTeam_BTN = new System.Windows.Forms.Button();
            this.UrlBox = new System.Windows.Forms.RichTextBox();
            this.PSBox = new System.Windows.Forms.RichTextBox();
            this.LoadTeamFromPSCode_BTN = new System.Windows.Forms.Button();
            this.ImportPKM_BTN = new System.Windows.Forms.Button();
            this.ConditionBox = new System.Windows.Forms.TextBox();
            this.ClearAllBox_BTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadBattleTeam_BTN
            // 
            this.LoadBattleTeam_BTN.Location = new System.Drawing.Point(423, 194);
            this.LoadBattleTeam_BTN.Name = "LoadBattleTeam_BTN";
            this.LoadBattleTeam_BTN.Size = new System.Drawing.Size(149, 32);
            this.LoadBattleTeam_BTN.TabIndex = 0;
            this.LoadBattleTeam_BTN.Text = "从网址批量导入";
            this.LoadBattleTeam_BTN.UseVisualStyleBackColor = true;
            this.LoadBattleTeam_BTN.Click += new System.EventHandler(this.LoadBattleTeam_BTN_Click);
            // 
            // UrlBox
            // 
            this.UrlBox.Location = new System.Drawing.Point(350, 12);
            this.UrlBox.Name = "UrlBox";
            this.UrlBox.Size = new System.Drawing.Size(283, 176);
            this.UrlBox.TabIndex = 2;
            this.UrlBox.Text = "";
            // 
            // PSBox
            // 
            this.PSBox.Location = new System.Drawing.Point(12, 12);
            this.PSBox.Name = "PSBox";
            this.PSBox.Size = new System.Drawing.Size(332, 176);
            this.PSBox.TabIndex = 3;
            this.PSBox.Text = "";
            // 
            // LoadTeamFromPSCode_BTN
            // 
            this.LoadTeamFromPSCode_BTN.Location = new System.Drawing.Point(78, 194);
            this.LoadTeamFromPSCode_BTN.Name = "LoadTeamFromPSCode_BTN";
            this.LoadTeamFromPSCode_BTN.Size = new System.Drawing.Size(197, 32);
            this.LoadTeamFromPSCode_BTN.TabIndex = 4;
            this.LoadTeamFromPSCode_BTN.Text = "从Showdown批量导入";
            this.LoadTeamFromPSCode_BTN.UseVisualStyleBackColor = true;
            this.LoadTeamFromPSCode_BTN.Click += new System.EventHandler(this.LoadTeamFromPSCode_BTN_Click);
            // 
            // ImportPKM_BTN
            // 
            this.ImportPKM_BTN.Location = new System.Drawing.Point(639, 83);
            this.ImportPKM_BTN.Name = "ImportPKM_BTN";
            this.ImportPKM_BTN.Size = new System.Drawing.Size(206, 30);
            this.ImportPKM_BTN.TabIndex = 5;
            this.ImportPKM_BTN.TabStop = false;
            this.ImportPKM_BTN.Text = "从文件导入smogon策略";
            this.ImportPKM_BTN.UseVisualStyleBackColor = true;
            this.ImportPKM_BTN.Click += new System.EventHandler(this.ImportPKM_BTN_Click);
            // 
            // ConditionBox
            // 
            this.ConditionBox.Location = new System.Drawing.Point(639, 40);
            this.ConditionBox.Name = "ConditionBox";
            this.ConditionBox.Size = new System.Drawing.Size(206, 27);
            this.ConditionBox.TabIndex = 6;
            this.ConditionBox.Text = "Nothing to check";
            // 
            // ClearAllBox_BTN
            // 
            this.ClearAllBox_BTN.Location = new System.Drawing.Point(639, 129);
            this.ClearAllBox_BTN.Name = "ClearAllBox_BTN";
            this.ClearAllBox_BTN.Size = new System.Drawing.Size(206, 29);
            this.ClearAllBox_BTN.TabIndex = 7;
            this.ClearAllBox_BTN.Text = "清除全部盒子";
            this.ClearAllBox_BTN.UseVisualStyleBackColor = true;
            this.ClearAllBox_BTN.Click += new System.EventHandler(this.ClearAllBox_BTN_Click);
            // 
            // BattleKingUI
            // 
            this.ClientSize = new System.Drawing.Size(857, 231);
            this.Controls.Add(this.ClearAllBox_BTN);
            this.Controls.Add(this.ConditionBox);
            this.Controls.Add(this.ImportPKM_BTN);
            this.Controls.Add(this.LoadTeamFromPSCode_BTN);
            this.Controls.Add(this.PSBox);
            this.Controls.Add(this.UrlBox);
            this.Controls.Add(this.LoadBattleTeam_BTN);
            this.Font = new System.Drawing.Font("Arial", 10.2F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BattleKingUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);
            this.PerformLayout();

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
            var text = GetTextShowdownData();
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
        private  string GetTextShowdownData()
        {
            var text = PSBox.Text.TrimEnd();
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
    }
}
