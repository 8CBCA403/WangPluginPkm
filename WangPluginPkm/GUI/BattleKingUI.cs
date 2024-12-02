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
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Drawing;
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
                Task.Factory.StartNew(
                () =>
                {
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
                            MessageBox.Show("The data inSID16e the URL are not valid Showdown Sets");
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
                foreach (var t in T)
                {
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
            int n = 0;
            string supported = string.Join(";", SAV.SAV.PKMExtensions.Select(s => $"*.{s}").Concat(["*.pk"]));
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
                var replace = (Control.ModifierKeys & System.Windows.Forms.Keys.Alt) != 0;
                ImportSetsToBoxes(sets, replace);
            }

        }
        private static AutoModErrorCode ImportSetToTabs(ShowdownSet set, bool skipDialog = false)
        {
            var regen = new RegenTemplate(set, SAV.SAV.Generation);
            if (
                !skipDialog
                && DialogResult.Yes
                    != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "Import this set?", regen.Text)
            )
            {
                return AutoModErrorCode.NoSingleImport;
            }

            if (set.InvalidLines.Count > 0)
            {
                return AutoModErrorCode.InvalidLines;
            }

            Debug.WriteLine($"Commencing Import of {GameInfo.Strings.Species[set.Species]}");
            var timer = Stopwatch.StartNew();

            var sav = SAV.SAV;
            var almres = sav.GetLegalFromSet(regen);
            var legal = almres.Created;
            var msg = almres.Status;
            timer.Stop();

            if (msg is LegalizationResult.VersionMismatch)
            {
                var errorstr =
                    "The PKHeX-Plugins version does not match the PKHeX version.\n\n"
                    + "Refer to the Wiki to fix this error.\n\n"
                    + $"The current ALM Version is {ALMVersion.Versions.AlmVersionCurrent}\n"
                    + $"The current PKHeX Version is {ALMVersion.Versions.CoreVersionCurrent}";
                return AutoModErrorCode.VersionMismatch;
            }

            if (msg is LegalizationResult.Timeout or LegalizationResult.Failed)
            {
                Legalizer.Dump(regen, msg == LegalizationResult.Failed);

                string analysis = null;
                if (msg is LegalizationResult.Failed)
                {
                    analysis = regen.SetAnalysis(sav, legal);
                }

                var errorstr =
                    msg == LegalizationResult.Failed ? "failed to generate" : "timed out";
                var invalid_set_error =
                    (analysis == null ? $"Set {errorstr}." : $"Set Invalid: {analysis}")
                    + "\n\nRefer to the wiki for more help on generating sets correctly."
                    + "\n\nIf you are sure this set is valid, please create an issue on GitHub and upload the error_log.txt file in the issue.";
            }

            Debug.WriteLine("Single Set Genning Complete. Loading final data to tabs.");
            Editor.PopulateFields(legal);

            var timespan = timer.Elapsed;
            Debug.WriteLine(
                $"Time to complete {nameof(ImportSetToTabs)}: {timespan.Minutes:00} minutes {timespan.Seconds:00} seconds {timespan.Milliseconds / 10:00} milliseconds"
            );
            return AutoModErrorCode.None;
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
                _ = t.Replace(";", "");
                t = ShowdownTranslator<PKM>.Chinese2Showdown(zh[i]);
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
            byte[] input;
            input = System.IO.File.ReadAllBytes(path);
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
            byte[] input;
            input = System.IO.File.ReadAllBytes(path);

            if (LoadFile(input, path))
                return;
        }
#nullable enable
        private bool LoadFile(object? input, string path)
        {
            if (input == null)
            {
                return false;
            }

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
            SAV.SAV.AdaptPKM(tmp);
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
            ResultBox.Clear();
            int n = 0;
            int l = 0;
            int m = 0;
            for (int i = 0; i < 6; i++)
            {
                n = n + BD[i].pk.Move1_PPUps
                + BD[i].pk.Move2_PPUps
                + BD[i].pk.Move3_PPUps
                + BD[i].pk.Move4_PPUps;
            }
            if (n > 15)
                ResultBox.AppendText("队伍PP Up使用超过20%，不合法!" + Environment.NewLine);
            else
                ResultBox.AppendText("队伍PP Up使用合法!" + Environment.NewLine);
            for (int i = 0; i < 6; i++)
            {
                if (BD[i].pk.EVTotal == 508)
                    l++;
            }
            if (l > 0)
                ResultBox.AppendText("队伍中存在精灵努力值总和为508，不合法!" + Environment.NewLine);
            else
                ResultBox.AppendText("队伍中努力值配置合法!" + Environment.NewLine);
            for (int i = 0; i < 6; i++)
            {
                if (BD[i].pk.CurrentLevel == 100)
                    m++;
            }
            if (m == 6)
                ResultBox.AppendText("全队宝可梦都是100级，不合法!" + Environment.NewLine);
            else
                ResultBox.AppendText("队伍中宝可梦等级合法!" + Environment.NewLine);
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
            {
                TeamForm fr = new(Web_CB.SelectedIndex);
                HttpClient client = new();
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
                        // Your existing code...
                        fr.Show();
                        await Task.Run(async () =>
                        {
                            for (int i = 0; i < n; i++)
                            {
                                var item = data.PageProps.Pastes[i];
                                var link = ImportURL_text.Text + "/pastes/" + item.Id;

                                using var client = new HttpClient();
                                var response = await client.GetAsync(link);
                                var content = await response.Content.ReadAsStringAsync();

                                HtmlAgilityPack.HtmlDocument docl = new();
                                docl.LoadHtml(content);

                                HtmlNode targetNode = docl.DocumentNode.SelectSingleNode("//pre[contains(@class, 'ml-5') and contains(@class, 'w-4/5') and contains(@class, 'whitespace-pre-wrap')]");
                                if (targetNode != null)
                                {
                                    string textContent = targetNode.InnerText;
                                    data.PageProps.Pastes[i].PS = textContent;

                                    // Ensure UI updates are done on the main thread
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
                finally
                {
                    client.Dispose();

                }
            }
        }
        public async Task NewTournamentsGet()
        {
            TeamForm fr = new(Web_CB.SelectedIndex);

            HttpClient client = new();
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
            finally
            {
                client.Dispose();
            }

        }
        public async Task SubTournamentsGet(string r, TeamForm fr)
        {
            int n;
            string jsonContent;
            HttpResponseMessage response;
            HttpClient client = new();
            var jsUrl = ImportURL_text.Text + "/_next/data/" + r + "/en/tournaments/" + CB.SelectedValue + ".json";
            response = await client.GetAsync(jsUrl);
            jsonContent = await response.Content.ReadAsStringAsync();
            var re = BFuction.DeleStringEnd(jsonContent, ",\"_nextI18Next\"");
            var res = BFuction.DeleStringStart(re, "Teams\":");
            var data = JsonConvert.DeserializeObject<List<TournamentSub>>(res);
            if (data != null)
            {
                n = data.Count;
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
                        HttpClient httpClient = new();
                        try
                        {
                            string htmlContent = await httpClient.GetStringAsync(ImportURL_text.Text + "/zh-Hans/pastes/vgc/" + CB.SelectedValue);
                            HtmlAgilityPack.HtmlDocument htmlDocument = new();
                            htmlDocument.LoadHtml(htmlContent);
                            HtmlNodeCollection selectElements = htmlDocument.DocumentNode.SelectNodes($"//select[contains(@class, '{targetClass}')]");
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
                        finally
                        {
                            httpClient.Dispose();
                        }
                        CB.DataSource = st;
                    }
                    break;
                case 1:
                    {
                        List<Tournament> st = [];
                        HttpClient client = new();
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
#pragma warning disable CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                        data = JsonConvert.DeserializeObject<List<Tournament>>(re);
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
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
                        finally
                        {
                            client.Dispose();
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
            // AIzaSyBMFP7HlaUt9ZMr7NhapA0X1NBYy4vqcJY
            // 创建Google Sheets服务
            var sheetsService = new SheetsService(new BaseClientService.Initializer()
            {
                ApiKey = config.GoogleapiKey,
                ApplicationName = config.GoogleapiKey
                //silicon-park-409723
            });
            // 读取数据的示例
            string spreadsheetId = "1axlwmzPA49rYkqXh7zHvAtSP-TKbM0ijGYBPRflLSWw";
            if (VGCExcel_CB.SelectedValue != null)
                PrintCellsContainingKeywordInSheet(sheetsService, spreadsheetId, (string)VGCExcel_CB.SelectedValue, "pokepast.es");
        }
        private static Sheet GetSheetSize(SheetsService service, string spreadsheetId, string sheetName)
        {
            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(spreadsheetId, sheetName);
            ValueRange response = request.Execute();
            return (Sheet)response.Values;
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
            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(spreadsheetId, range);
            ValueRange response = request.Execute();
            return response.Values;
        }
        private void PrintValues(IList<IList<object>> values)
        {
            if (values != null && values.Count > 0)
            {
                // textBox1.Text+=("Read data:");
                foreach (var row in values)
                {
                    foreach (var col in row)
                    {
                        VGCPaste_TB.Text += ($"{col} ");
                    }
                    VGCPaste_TB.Text += Environment.NewLine;
                }
            }
            else
            {
                VGCPaste_TB.Text += ("No data found.");
            }
        }
        private void PrintCellsContainingKeywordInSheet(SheetsService service, string spreadsheetId, string sheetName, string keyword)
        {
            var sheetData = service.Spreadsheets.Values.Get(spreadsheetId, $"{sheetName}!A:FZ").Execute();
            int n = 0;
            if (sheetData.Values != null && sheetData.Values.Count > 0)
            {
                VGCPaste_TB.Text += ($"{sheetName}中的队伍如下:") + Environment.NewLine;
                for (int rowIndex = 0; rowIndex < sheetData.Values.Count; rowIndex++)
                {
                    var row = sheetData.Values[rowIndex];
                    for (int colIndex = 0; colIndex < row.Count; colIndex++)
                    {
                        var cellValue = row[colIndex].ToString();
                        if (cellValue != null)
                        {
                            if (cellValue.Contains(keyword))
                            {
                                n++;
                                VGCPaste_TB.Text += ($"队伍{n}:{cellValue}") + Environment.NewLine;
                            }
                        }
                    }
                }
                if (n == 0)
                {
                    VGCPaste_TB.Text += ($"此表格没有队伍");
                }
            }
            else
            {
                VGCPaste_TB.Text += ($"此表格没有队伍");
            }
        }
        private void VGCPastes_Click(object sender, EventArgs e)
        {
            VGCPaste_TB.Clear();
            Task.Factory.StartNew(
              () =>
              {
                  GoogleSheet();
              }, VGCPastestokenSource.Token);
        }
        private void CVGC_BTN_Click(object sender, EventArgs e)
        {
            List<string> st;
            var config = PluginConfig.LoadConfig();
            //AIzaSyBMFP7HlaUt9ZMr7NhapA0X1NBYy4vqcJY
            var sheetsService = new SheetsService(new BaseClientService.Initializer()
            {
                ApiKey = config.GoogleapiKey,
                ApplicationName = config.GoogleapiKey
                //silicon-park-409723
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
            //string url = "https://api.battle.pokemon-home.com/tt/cbd/competition/rankmatch/list";
            var html = await HomeSeasonDetail.DownloadPageAsync();
            if (html != null)
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
            var departmentBindingList = new BindingList<HomeSeasonDetail>(L);
            var departmentSource = new BindingSource(departmentBindingList, "");
            Rank_List_Box.DataSource = departmentSource;
            Rank_List_Box.DisplayMember = "DisplayName";
            Rank_List_Box.ValueMember = "Description";
            Rank_List_Box.Refresh();

        }
        private async void Get_Rank_BTN_Click(object sender, EventArgs e)
        {
            // 获取TextBox的值
            string cId = CID_BOX.Text.Trim();
            string rst = RST_BOX.Text.Trim();
            string ts1 = TS1_BOX.Text.Trim();

            // 检查每个TextBox是否为空
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

            // 生成链接
            string rankUrl = $"https://resource.pokemon-home.com/battledata/ranking/scvi/{cId}/{rst}/{ts1}/traner-1";
            n = 1;
            R.Clear();
            Rank_List_Box.DataSource = null;
            Rank_List_Box.ClearSelected();

            var html = await HomeRankClass.DownloadPageAsync(rankUrl);
            if (html != null)
                foreach (var h in html)
                {
                    HomeRankClass r = new(h);
                    R.Add(r);
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
            // 确保在进行操作前，选中的索引是有效的
            if (Rank_List_Box.SelectedIndex == -1)
            {
                return; // 如果没有选中任何项，直接返回
            }
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
                    {
                        LangBox.Text = $"{Lng(Int16.Parse(v.Description.lng))}";
                    }
                    imageUrl = "https://resource.pokemon-home.com/battledata/img/icons/trainer/" + v.Description.icon;
                }
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    try
                    {
                        var httpClient = new HttpClient();
                        HttpResponseMessage response = await httpClient.GetAsync(imageUrl);
                        byte[] imageData = await response.Content.ReadAsByteArrayAsync();
                        using MemoryStream ms = new(imageData);
                        Image downloadedImage = Image.FromStream(ms);
                        PlayerPic.Image = downloadedImage;
                    }
                    catch (WebException ex)
                    {
                        if (ex.Response is HttpWebResponse response && response.StatusCode == HttpStatusCode.Forbidden)
                        {
                            PlayerPic.Image = Properties.Resources._403;
                        }
                        else
                        {
                            PlayerPic.Image = Properties.Resources._403;
                        }
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

            // 标记是否找到匹配项
            bool found = false;

            // 遍历ListBox中的项
            for (int i = 0; i < Rank_List_Box.Items.Count; i++)
            {
                var item = (HomeRankClass)Rank_List_Box.Items[i];
                if (item.Description != null&&item.DisplayName!=null)
                {
                    string itemNameWithoutRank = item.DisplayName[(item.DisplayName.IndexOf(' ') + 1)..];
                    // 如果找到了包含搜索关键词的项
                    if (itemNameWithoutRank.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    {
                        // 选中该项
                        Rank_List_Box.SelectedIndex = i;

                        // 滚动到该项
                        Rank_List_Box.TopIndex = i;

                        // 标记为已找到
                        found = true;

                        // 弹出提示框
                        MessageBox.Show($"找到匹配项: {txtSearch.Text.Trim()}", "搜索结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }

            // 如果没有找到匹配项
            if (!found)
            {
                MessageBox.Show("未找到匹配的项！", "搜索结果", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}




