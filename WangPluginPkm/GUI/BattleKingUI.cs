using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using HtmlAgilityPack;
using Newtonsoft.Json;
using PKHeX.Core;
using PKHeX.Core.AutoMod;
using PKHeX.Core.Enhancements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WangPluginPkm.PluginUtil;
using WangPluginPkm.PluginUtil.BattleKingBase;
using WangPluginPkm.PluginUtil.ModifyPKM;

namespace WangPluginPkm.GUI
{
    partial class BattleKingUI : Form
    {
        int n = 0;
        public List<ShowdownSet> Sets = [];
        public List<HomeSeasonDetail> L = [];
        public List<HomeRankClass> R = [];
        public HomeRankClass v = null;
        public HomeSeasonDetail u = null;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static ISaveFileProvider SAV { private get; set; } = null!;
        private readonly CancellationTokenSource PastetokenSource = new();
        private readonly CancellationTokenSource FalinkVGCstokenSource = new();
        private readonly CancellationTokenSource FalinkTournamentstokenSource = new();
        private readonly CancellationTokenSource VGCPastestokenSource = new();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static IPKMView Editor { private get; set; } = null!;
        private static readonly List<ExpandPKM> BD = [];
        private enum Falinks
        {
            VGC,
            Tournaments
        }

        public BattleKingUI(ISaveFileProvider sav, IPKMView editor)
        {
            InitializeComponent();
            Web_CB.DataSource = Enum.GetValues(typeof(Falinks));
            TB.Text = "注意，神偷-VGCPaste功能需要Google api key以及App Name" + Environment.NewLine + "在此处申请 https://console.cloud.google.com/apis";
            SAV = sav;
            Editor = editor;
        }
        private void IsRunning(bool running)
        {
            ImportPKM_BTN.Enabled = !running;
            ConditionBox.Text = running ? "Dumping..." : "Nothing to check";
        }

        private async void LoadBattleTeam_BTN_Click(object sender, EventArgs e)
        {
            var url = UrlBox.Text.Trim();
            var suburl = url.Split('\n');
            if (suburl.Length == 0)
                return;

            await Task.Run(() =>
            {
                for (int i = 0; i < suburl.Length; i++)
                {
                    TeamPasteInfo info;
                    try
                    {
                        info = new TeamPasteInfo(suburl[i]);
                    }
                    catch
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
                }
            }, PastetokenSource.Token);

            MessageBox.Show($"导入了{suburl.Length}个队伍");
        }

        private void LoadTeamFromPSCode_BTN_Click(object sender, EventArgs e)
        {
            var text = GetTextShowdownData(PSBox.Text.TrimEnd());
            var chs = "";
            if (string.IsNullOrWhiteSpace(text) && !ChineseCheckBox.Checked)
                return;
            if (ChineseCheckBox.Checked)
            {
                var T = PSBox.Text.Split("\n\n");
                foreach (var t0 in T)
                {
                    var t = t0.Replace(";", "");
                    chs += ShowdownTranslator<PK9>.Chinese2Showdown(t) + "\n\n";
                }
                text = chs;
            }

            Import(text);
        }
        private void ClearAllBox_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(ClearPKM);
            SAV.ReloadSlots();
        }
        private void ImportPKM_BTN_Click(object sender, EventArgs e)
        {
            IsRunning(true);
            int count = 0;
            string supported = string.Join(";", SAV.SAV.PKMExtensions.Select(s => $"*.{s}").Concat(["*.pk"]));
            using var ofd = new OpenFileDialog
            {
                Filter = "All Files|*.*" + "|Decrypted PKM File (*.pk)|" + supported,
                Multiselect = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in ofd.FileNames)
                {
                    var pk = OpenFromPath(file);
                    if (pk == null)
                        continue;
                    GenSmogonSets(pk);
                    count++;
                }
            }
            IsRunning(false);
            MessageBox.Show($"导出了{count}只");
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
        private static AutoModErrorCode ImportSetToTabs(ShowdownSet set, bool skipDialog = false)
        {
            var regen = new RegenTemplate(set, SAV.SAV.Generation);
            if (!skipDialog && DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "Import this set?", regen.Text))
                return AutoModErrorCode.NoSingleImport;

            if (set.InvalidLines.Count > 0)
                return AutoModErrorCode.InvalidLines;

            Debug.WriteLine($"Commencing Import of {GameInfo.Strings.Species[set.Species]}");
            var timer = Stopwatch.StartNew();

            var sav = SAV.SAV;
            var almres = sav.GetLegalFromSet(regen);
            var legal = almres.Created;
            var msg = almres.Status;
            timer.Stop();

            if (msg is LegalizationResult.VersionMismatch)
            {
                return AutoModErrorCode.VersionMismatch;
            }

            if (msg is LegalizationResult.Timeout or LegalizationResult.Failed)
            {
                Legalizer.Dump(regen, msg == LegalizationResult.Failed);

                string analysis = null;
                if (msg is LegalizationResult.Failed)
                    analysis = regen.SetAnalysis(sav, legal);
                // keep silent UI here; caller handles
            }

            Debug.WriteLine("Single Set Genning Complete. Loading final data to tabs.");
            Editor.PopulateFields(legal);

            var timespan = timer.Elapsed;
            Debug.WriteLine($"Time to complete {nameof(ImportSetToTabs)}: {timespan.Minutes:00} minutes {timespan.Seconds:00} seconds {timespan.Milliseconds / 10:00} milliseconds");
            return AutoModErrorCode.None;
        }
        private void ImportSetsToBoxes(IReadOnlyList<ShowdownSet> sets, bool replace)
        {
            var timer = Stopwatch.StartNew();
            var sav = SAV.SAV;
            var BoxData = sav.BoxData;
            var start = SAV.CurrentBox * sav.BoxSlotCount;
            Debug.WriteLine($"Commencing Import of {sets.Count} set(s).");
            _ = sav.ImportToExisting(sets, BoxData, out var invalid, out var timeout, start, replace);
            Debug.WriteLine("Multi Set Genning Complete. Setting data to the save file and reloading view.");
            SAV.ReloadSlots();
            timer.Stop();
            var timespan = timer.Elapsed;
            Debug.WriteLine($"Time to complete {nameof(ImportSetsToBoxes)}: {timespan.Minutes:00} minutes {timespan.Seconds:00} seconds {timespan.Milliseconds / 10:00} milliseconds");
        }
        private static string TranslatorZH(string text)
        {
            string[] zh = text.Split(';');
            string s = "";
            string t = "";
            for (int i = 0; i < zh.Length; i++)
            {
                t = zh[i].Replace(";", "");
                t = ShowdownTranslator<PKM>.Chinese2Showdown(t);
                s += t;
                s += "\n\n";
            }
            return s;
        }
        private static string GetTextShowdownData(string text)
        {
            if (ShowdownUtil.IsTextShowdownData(text))
                return text;
            return null;
        }
        private void GenSmogonSets(PKM rough)
        {
            if (rough == null)
                return;
            SmogonSetGenerator info;
            try
            {
                info = new SmogonSetGenerator(rough);
            }
            catch (Exception ex)
            {
                WinFormsUtil.Error($"生成出错！: {ex}");
                return;
            }
            ImportSetsToBoxes(info.Sets, false);
        }
        private static PKM OpenFromPath(string path)
        {
            var fi = new FileInfo(path);
            if (!fi.Exists)
                return null;
            string ext = fi.Extension;
            byte[] input = File.ReadAllBytes(path);
            FileUtil.TryGetPKM(input, out var pk, ext);
            return pk;
        }
        public static void ClearPKM(PKM pkm)
        {
            pkm.Species = 0;
        }
        private void OpenQuick(string path)
        {
            if (!CanFocus)
            {
                SystemSounds.Asterisk.Play();
                return;
            }
            var fi = new FileInfo(path);
            if (!fi.Exists)
                return;
            byte[] input = File.ReadAllBytes(path);

            if (LoadFile(input, path))
                return;
        }
#nullable enable
        private bool LoadFile(object? input, string path)
        {
            if (input == null)
                return false;

            ArgumentNullException.ThrowIfNull(path);

            switch (input)
            {
                // case PKM pk: return OpenPKM(pk);
                case byte[] pkms: return OpenPCBoxBin(pkms);
                default:
                    break;
            }
            return false;
        }
        private bool OpenPKM(PKM pk)
        {
            var destType = SAV.SAV.PKMType;
            var tmp = EntityConverter.ConvertToType(pk, destType, out var c);
            Debug.WriteLine(c.GetDisplayString(pk, destType));
            if (tmp == null)
                return false;
            SAV.SAV.AdaptToSaveFile(tmp);
            TeamList_BOX.Items.Add(pk, CheckState.Checked);
            return true;
        }
        protected static PKM GetPKM(byte[] data) => new PK9(data);
        private bool OpenPCBoxBin(byte[] pkms)
        {
            var pkdata = FileTradeHelper<PK9>.Bin2List(pkms);
            ExpandPKM ex;
            if (pkdata != null)
            {
                for (int i = 0; i < pkdata.Count; i++)
                {
                    ex = new()
                    {
                        pk = pkdata[i],
                        Name = GameInfo.GetStrings("zh").Species[pkdata[i].Species] + $"{pkdata[i].EncryptionConstant:X}"
                    };
                    BD.Add(ex);
                }
            }

            if (BD.Count != 0)
            {
                for (int i = 0; i < BD.Count; i++)
                {
                    TeamList_BOX.Items.Add(BD[i], CheckState.Checked);
                }

            }
            return true;
        }

        private void PKM_DragDrop(object sender, DragEventArgs e)
        {
            BD.Clear();
            TeamList_BOX.Items.Clear();
            if (e?.Data?.GetData(DataFormats.FileDrop) is not string[] { Length: not 0 } files)
                return;
            OpenQuick(files[0]);
            e.Effect = DragDropEffects.Copy;
        }
        private void PKM_DragEnter(object sender, DragEventArgs e)
        {
            if (e is null)
                return;
            if (e.AllowedEffect == (DragDropEffects.Copy | DragDropEffects.Link)) // external file
                e.Effect = DragDropEffects.Copy;
            else if (e.Data != null) // within
                e.Effect = DragDropEffects.Copy;
        }

        private void TEST_BTN_Click(object sender, EventArgs e)
        {
            if (SAV.SAV.Version != GameVersion.VL && SAV.SAV.Version != GameVersion.SL && SAV.SAV.Version != GameVersion.SV)
            {
                MessageBox.Show("目前VGC版本为朱紫！");
                return;
            }
            if (BD.Count < 6)
            {
                MessageBox.Show("队伍不足6只，无法检测！");
                return;
            }
            ResultBox.Clear();
            int sumPPUp = 0;
            int fullEVCount = 0;
            int level100Count = 0;
            for (int i = 0; i < 6; i++)
            {
                sumPPUp += BD[i].pk.Move1_PPUps + BD[i].pk.Move2_PPUps + BD[i].pk.Move3_PPUps + BD[i].pk.Move4_PPUps;
                if (BD[i].pk.EVTotal == 508)
                    fullEVCount++;
                if (BD[i].pk.CurrentLevel == 100)
                    level100Count++;
            }
            ResultBox.AppendText(sumPPUp > 15 ? "队伍PP Up使用超过20%，不合法!" + Environment.NewLine : "队伍PP Up使用合法!" + Environment.NewLine);
            ResultBox.AppendText(fullEVCount > 0 ? "队伍中存在精灵努力值总和为508，不合法!" + Environment.NewLine : "队伍中努力值配置合法!" + Environment.NewLine);
            ResultBox.AppendText(level100Count == 6 ? "全队宝可梦都是100级，不合法!" + Environment.NewLine : "队伍中宝可梦等级合法!" + Environment.NewLine);
        }

        private async void MT_BTN_ClickAsync(object sender, EventArgs e)
        {
            switch (Web_CB.SelectedIndex)
            {
                case 0:
                    await NewVGCGet();
                    break;
                case 1:
                    await NewTournamentsGet();
                    break;
                default:
                    break;
            }
        }
        public async Task NewVGCGet()
        {
            TeamForm fr = new(Web_CB.SelectedIndex);
            using HttpClient client = new();
            string jsonContent;
            MT_BTN.Enabled = false;
            fr.Import_BTN.Enabled = true;
            HttpResponseMessage response = await client.GetAsync(ImportURL_text.Text);
            string responseBody = await response.Content.ReadAsStringAsync();
            var r = (BFuction.GetString(responseBody, "_buildManifest.js", "_ssgManifest.js"));
            var jsUrl = ImportURL_text.Text + "/_next/data/" + r + "/en/pastes/vgc/" + CB.SelectedValue + ".json";
            response = await client.GetAsync(jsUrl);
            jsonContent = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<RootObject>(jsonContent);
            Stopwatch st = new();
            st.Start();
            try
            {
                if (data != null)
                {
                    int n = data.PageProps.Pastes.Count;
                    fr.Show();
                    await Task.Run(async () =>
                    {
                        for (int i = 0; i < n; i++)
                        {
                            var item = data.PageProps.Pastes[i];
                            var link = ImportURL_text.Text + "/pastes/" + item.Id;

                            using var client2 = new HttpClient();
                            var response2 = await client2.GetAsync(link);
                            var content = await response2.Content.ReadAsStringAsync();

                            HtmlAgilityPack.HtmlDocument docl = new();
                            docl.LoadHtml(content);

                            HtmlNode targetNode = docl.DocumentNode.SelectSingleNode("//pre[contains(@class, 'ml-5') and contains(@class, 'w-4/5') and contains(@class, 'whitespace-pre-wrap')]");
                            if (targetNode != null)
                            {
                                string textContent = targetNode.InnerText;
                                data.PageProps.Pastes[i].PS = textContent;

                                if (fr.IsHandleCreated)
                                {
                                    fr.Invoke((MethodInvoker)delegate
                                    {
                                        fr.TeamListBox.Items.Add(data.PageProps.Pastes[i]);
                                        fr.TeamListBox.DisplayMember = "Title";
                                        fr.TeamListBox.Refresh();
                                    });
                                }
                            }
                        }
                    });
                }

                MT_BTN.Enabled = true;
                fr.Import_BTN.Enabled = true;
                st.Stop();
                MessageBox.Show($"经过时间{st.ElapsedMilliseconds / 1000}秒");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public async Task NewTournamentsGet()
        {
            TeamForm fr = new(Web_CB.SelectedIndex);

            using HttpClient client = new();
            MT_BTN.Enabled = false;
            fr.Import_BTN.Enabled = true;
            HttpResponseMessage response = await client.GetAsync(ImportURL_text.Text);
            string responseBody = await response.Content.ReadAsStringAsync();
            var r = (BFuction.GetString(responseBody, "_buildManifest.js", "_ssgManifest.js"));
            Stopwatch st = new();
            st.Start();
            try
            {
                await SubTournamentsGet(r, fr);
                MT_BTN.Enabled = true;
                fr.Import_BTN.Enabled = true;
                st.Stop();
                MessageBox.Show($"经过时间{st.ElapsedMilliseconds / 1000}秒");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public async Task SubTournamentsGet(string r, TeamForm fr)
        {
            string jsonContent;
            using HttpClient client = new();
            var jsUrl = ImportURL_text.Text + "/_next/data/" + r + "/en/tournaments/" + CB.SelectedValue + ".json";
            var response = await client.GetAsync(jsUrl);
            jsonContent = await response.Content.ReadAsStringAsync();
            var re = BFuction.DeleStringEnd(jsonContent, ",\"_nextI18Next\"");
            var res = BFuction.DeleStringStart(re, "Teams\":");
            var data = JsonConvert.DeserializeObject<List<TournamentSub>>(res);
            if (data != null)
            {
                int n = data.Count;
                for (int i = 0; i < n; i++)
                {
                    fr.TeamListBox.Items.Add(data[i]);
                    fr.TeamListBox.DisplayMember = "Author";
                    fr.TeamListBox.Refresh();
                    fr.Show();
                }
            }
        }
        public async Task Selectc()
        {
            switch (Web_CB.SelectedIndex)
            {
                case 0:
                    {
                        List<string> st = [];
                        string targetClass = "select-bordered select select-sm w-64 overflow-ellipsis";
                        using HttpClient httpClient = new();
                        try
                        {
                            string htmlContent = await httpClient.GetStringAsync(ImportURL_text.Text + "/zh-Hans/pastes/vgc/" + CB.SelectedValue);
                            HtmlAgilityPack.HtmlDocument htmlDocument = new();
                            htmlDocument.LoadHtml(htmlContent);
                            HtmlNodeCollection selectElements = htmlDocument.DocumentNode.SelectNodes($"//select[contains(@class, '{targetClass}') and not(ancestor::div[contains(@class, 'hidden')])]");
                            if (selectElements != null)
                            {
                                foreach (HtmlNode selectElement in selectElements)
                                {
                                    HtmlNodeCollection optionElements = selectElement.SelectNodes("option");
                                    foreach (HtmlNode option in optionElements)
                                    {
                                        string optionValue = option.GetAttributeValue("value", "");
                                        st.Add(optionValue);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("出错了！可能是输入了错误的网址，获得正确网址请联系老吴" + Environment.NewLine + ex.Message);
                        }
                        CB.DataSource = st;
                    }
                    break;
                case 1:
                    {
                        List<Tournament> st = [];
                        using HttpClient client = new();
                        List<Tournament> data;
                        string jsonContent;
                        HttpResponseMessage response = await client.GetAsync(ImportURL_text.Text);
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var r = (BFuction.GetString(responseBody, "_buildManifest.js", "_ssgManifest.js"));
                        var jsUrl = ImportURL_text.Text + "/_next/data/" + r + "/en/tournaments" + ".json";
                        response = await client.GetAsync(jsUrl);
                        jsonContent = await response.Content.ReadAsStringAsync();
                        var re = BFuction.DeleStringEnd(jsonContent, ",\"_nextI18Next\"");
                        re = re.Replace("{\"pageProps\":{\"tournaments\":", "");
                        data = JsonConvert.DeserializeObject<List<Tournament>>(re);
                        try
                        {
                            if (data != null)
                            {
                                int n = data.Count;
                                for (int i = 0; i < n; i++)
                                {
                                    st.Add(data[i]);
                                }
                            }
                            CB.DataSource = st;
                            CB.ValueMember = "Id";
                            CB.DisplayMember = "Name";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        private async void C_BTN_Click(object sender, EventArgs e)
        {
            await Selectc();
            MessageBox.Show("导入了网页！");
        }
        private void GoogleSheet()
        {
            var config = PluginConfig.LoadConfig();
            var sheetsService = new SheetsService(new BaseClientService.Initializer()
            {
                ApiKey = config.GoogleapiKey,
                ApplicationName = config.GoogleapiKey
            });
            string spreadsheetId = "1axlwmzPA49rYkqXh7zHvAtSP-TKbM0ijGYBPRflLSWw";
            if (VGCExcel_CB.SelectedValue != null)
                PrintCellsContainingKeywordInSheet(sheetsService, spreadsheetId, (string)VGCExcel_CB.SelectedValue, "pokepast.es");
        }
        private static List<string> GetSheetTitles(SheetsService service, string spreadsheetId)
        {
            var spreadsheet = service.Spreadsheets.Get(spreadsheetId).Execute();
            var sheetTitles = new List<string>();

            foreach (var sheet in spreadsheet.Sheets)
            {
                sheetTitles.Add(sheet.Properties.Title);
            }

            return sheetTitles;
        }
        private static IList<IList<object>> ReadData(SheetsService service, string spreadsheetId, string range)
        {
            var request = service.Spreadsheets.Values.Get(spreadsheetId, range);
            ValueRange response = request.Execute();
            return response.Values;
        }
        private void PrintCellsContainingKeywordInSheet(SheetsService service, string spreadsheetId, string sheetName, string keyword)
        {
            var sheetData = service.Spreadsheets.Values.Get(spreadsheetId, $"{sheetName}!A:FZ").Execute();
            int cnt = 0;
            if (sheetData.Values != null && sheetData.Values.Count > 0)
            {
                VGCPaste_TB.Text += ($"{sheetName}中的队伍如下:") + Environment.NewLine;
                for (int rowIndex = 0; rowIndex < sheetData.Values.Count; rowIndex++)
                {
                    var row = sheetData.Values[rowIndex];
                    for (int colIndex = 0; colIndex < row.Count; colIndex++)
                    {
                        var cellValue = row[colIndex]?.ToString();
                        if (!string.IsNullOrEmpty(cellValue) && cellValue.Contains(keyword))
                        {
                            cnt++;
                            VGCPaste_TB.Text += ($"队伍{cnt}:{cellValue}") + Environment.NewLine;
                        }
                    }
                }
                if (cnt == 0)
                    VGCPaste_TB.Text += ("此表格没有队伍");
            }
            else
            {
                VGCPaste_TB.Text += ("此表格没有队伍");
            }
        }
        private void VGCPastes_Click(object sender, EventArgs e)
        {
            VGCPaste_TB.Clear();
            Task.Factory.StartNew(() => { GoogleSheet(); }, VGCPastestokenSource.Token);
        }
        private void CVGC_BTN_Click(object sender, EventArgs e)
        {
            List<string> st;
            var config = PluginConfig.LoadConfig();
            var sheetsService = new SheetsService(new BaseClientService.Initializer()
            {
                ApiKey = config.GoogleapiKey,
                ApplicationName = config.GoogleapiKey
            });
            string spreadsheetId = "1axlwmzPA49rYkqXh7zHvAtSP-TKbM0ijGYBPRflLSWw";
            st = GetSheetTitles(sheetsService, spreadsheetId);
            VGCExcel_CB.DataSource = st;
        }
        private async void CheckS_BTN_Click(object sender, EventArgs e)
        {
            n = 0;
            Rank_List_Box.DataSource = null;
            Rank_List_Box.ClearSelected();
            L.Clear();
            var html = await HomeSeasonDetail.DownloadPageAsync();
            if (html != null)
            {
                foreach (var h in html)
                {
                    HomeSeasonDetail r = new(h);
                    switch (r.Rule)
                    {
                        case 0:
                            r.DisplayName += "单打";
                            break;
                        case 1:
                            r.DisplayName += "双打";
                            break;
                        default:
                            break;
                    }
                    L.Add(r);
                }
            }
            var departmentBindingList = new BindingList<HomeSeasonDetail>(L);
            var departmentSource = new BindingSource(departmentBindingList, "");
            Rank_List_Box.DataSource = departmentSource;
            Rank_List_Box.DisplayMember = "DisplayName";
            Rank_List_Box.ValueMember = "Description";
            Rank_List_Box.Refresh();
        }
        private async void Get_Rank_BTN_Click(object sender, EventArgs e)
        {
            string cId = CID_BOX.Text.Trim();
            string rst = RST_BOX.Text.Trim();
            string ts1 = TS1_BOX.Text.Trim();

            if (string.IsNullOrEmpty(cId))
            {
                MessageBox.Show("CID 不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(rst))
            {
                MessageBox.Show("RST 不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(ts1))
            {
                MessageBox.Show("TS1 不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rankUrl = $"https://resource.pokemon-home.com/battledata/ranking/scvi/{cId}/{rst}/{ts1}/traner-1";
            n = 1;
            R.Clear();
            Rank_List_Box.DataSource = null;
            Rank_List_Box.ClearSelected();

            var html = await HomeRankClass.DownloadPageAsync(rankUrl);
            if (html != null)
            {
                foreach (var h in html)
                {
                    HomeRankClass r = new(h);
                    R.Add(r);
                }
            }
            var departmentBindingList = new BindingList<HomeRankClass>(R);
            var departmentSource = new BindingSource(departmentBindingList, "");
            Rank_List_Box.DataSource = departmentSource;
            Rank_List_Box.DisplayMember = "DisplayName";
            Rank_List_Box.ValueMember = "Description";
            Rank_List_Box.Refresh();
        }

        private async void Rank_List_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Rank_List_Box.SelectedIndex == -1)
                return;

            if (n == 0)
            {
                u = L[Rank_List_Box.SelectedIndex];
                S_Name.Text = u.DisplayName;
                SStart_Box.Text = $"{u.Description?.start}";
                SEnd_Box.Text = $"{u.Description?.end}";
                CID_BOX.Text = $"{u.Cid}";
                RST_BOX.Text = $"{u.Rst}";
                TS1_BOX.Text = $"{u.Ts1}";
            }
            else if (n == 1)
            {
                v = R[Rank_List_Box.SelectedIndex];
                string imageUrl = "";
                if (v.Description != null)
                {
                    RankBox.Text = $"{v.Description.rank}";
                    NameBox.Text = v.Description.name;
                    RankValueBox.Text = $"{v.Description.rating_value}";
                    if (v.Description.lng != null)
                        LangBox.Text = $"{Lng(Int16.Parse(v.Description.lng))}";
                    imageUrl = "https://resource.pokemon-home.com/battledata/img/icons/trainer/" + v.Description.icon;
                }
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    try
                    {
                        using var httpClient = new HttpClient();
                        var response = await httpClient.GetAsync(imageUrl);
                        var imageData = await response.Content.ReadAsByteArrayAsync();
                        using MemoryStream ms = new(imageData);
                        var downloadedImage = Image.FromStream(ms);
                        PlayerPic.Image = downloadedImage;
                    }
                    catch
                    {
                        PlayerPic.Image = Properties.Resources._403;
                    }
                }
                else
                {
                    MessageBox.Show("请输入图像的URL", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private static string Lng(int l)
        {
            return l switch
            {
                1 => "日语",
                2 => "英语",
                8 => "韩语",
                9 => "繁体中文",
                10 => "简体中文",
                _ => $"语言代码{l}",
            };
        }

        private void Search_BTN_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("请输入搜索关键词！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool found = false;
            for (int i = 0; i < Rank_List_Box.Items.Count; i++)
            {
                var item = (HomeRankClass)Rank_List_Box.Items[i];
                if (item.Description != null && item.DisplayName != null)
                {
                    int idx = item.DisplayName.IndexOf(' ');
                    string itemNameWithoutRank = idx >= 0 ? item.DisplayName[(idx + 1)..] : item.DisplayName;
                    if (itemNameWithoutRank.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    {
                        Rank_List_Box.SelectedIndex = i;
                        Rank_List_Box.TopIndex = i;
                        found = true;
                        MessageBox.Show($"找到匹配项: {txtSearch.Text.Trim()}", "搜索结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }

            if (!found)
            {
                MessageBox.Show("未找到匹配的项！", "搜索结果", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}







