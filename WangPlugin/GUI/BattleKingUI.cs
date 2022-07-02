using System.Windows.Forms;
using PKHeX.Core;
using System;
using System.Collections.Generic;
using PKHeX.Core.Enhancements;
using PKHeX.Core.AutoMod;
using System.Diagnostics;
using System.Linq;
namespace WangPlugin.GUI
{
    internal class BattleKingUI : Form
    {
        private Button LoadBattleTeam_BTN;
      //  public string Page;
        public  List<ShowdownSet> Sets = new();
        private RichTextBox UrlBox;

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
            this.SuspendLayout();
            // 
            // LoadBattleTeam_BTN
            // 
            this.LoadBattleTeam_BTN.Location = new System.Drawing.Point(120, 194);
            this.LoadBattleTeam_BTN.Name = "LoadBattleTeam_BTN";
            this.LoadBattleTeam_BTN.Size = new System.Drawing.Size(107, 25);
            this.LoadBattleTeam_BTN.TabIndex = 0;
            this.LoadBattleTeam_BTN.Text = "LoadTeam";
            this.LoadBattleTeam_BTN.UseVisualStyleBackColor = true;
            this.LoadBattleTeam_BTN.Click += new System.EventHandler(this.LoadBattleTeam_BTN_Click);
            // 
            // UrlBox
            // 
            this.UrlBox.Location = new System.Drawing.Point(12, 12);
            this.UrlBox.Name = "UrlBox";
            this.UrlBox.Size = new System.Drawing.Size(332, 176);
            this.UrlBox.TabIndex = 2;
            this.UrlBox.Text = "";
            // 
            // BattleKingUI
            // 
            this.ClientSize = new System.Drawing.Size(361, 231);
            this.Controls.Add(this.UrlBox);
            this.Controls.Add(this.LoadBattleTeam_BTN);
            this.Font = new System.Drawing.Font("Arial", 10.2F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BattleKingUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);

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
            MessageBox.Show($"导出了{suburl.Length}个队伍");
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
            AutoModErrorCode result;
            if (sets.Count == 1)
            {
                result = ImportSetToTabs(sets[0], skipDialog);
            }
            else
            {
                var replace = (Control.ModifierKeys & Keys.Alt) != 0;
                result = ImportSetsToBoxes(sets, replace);
            }

        }
        private AutoModErrorCode ImportSetToTabs(ShowdownSet set, bool skipDialog = false)
        {
            var regen = new RegenTemplate(set, SAV.SAV.Generation);

            if (set.InvalidLines.Count > 0)
                return AutoModErrorCode.InvalidLines;

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
            return AutoModErrorCode.None;
        }
        private AutoModErrorCode ImportSetsToBoxes(IReadOnlyList<ShowdownSet> sets, bool replace)
        {
            var timer = Stopwatch.StartNew();
            var sav = SAV.SAV;
            var BoxData = sav.BoxData;
            var start = SAV.CurrentBox * sav.BoxSlotCount;

            Debug.WriteLine($"Commencing Import of {sets.Count} set(s).");
            var result = sav.ImportToExisting(sets, BoxData, out var invalid, out var timeout, start, replace);


            if (result != AutoModErrorCode.None)
                return result;

            Debug.WriteLine("Multi Set Genning Complete. Setting data to the save file and reloading view.");
            SAV.ReloadSlots();

            // Debug Statements
            timer.Stop();
            var timespan = timer.Elapsed;
            Debug.WriteLine($"Time to complete {nameof(ImportSetsToBoxes)}: {timespan.Minutes:00} minutes {timespan.Seconds:00} seconds {timespan.Milliseconds / 10:00} milliseconds");
            return AutoModErrorCode.None;
        }
        
    }
}
