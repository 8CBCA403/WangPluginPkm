using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WangPluginPkm.PluginUtil.ModifyPKM;
using WangPluginPkm.RNG.Methods;
using WangPluginPkm.RNG.ReverseRNG;
using static WangPluginPkm.PluginUtil.PluginEnums.GUIEnums;
using Overworld8RNG = WangPluginPkm.RNG.Methods.Overworld8RNG;
using Roaming8bRNG = WangPluginPkm.RNG.Methods.Roaming8bRNG;
using LumioseRNG = WangPluginPkm.RNG.Methods.LumioseRNG;
using WangPluginPkm.RNG;

namespace WangPluginPkm.GUI
{
    public partial class RNGForm : Form
    {
        public CheckRules rules = new();
        private int NumOfCountsPerThread = 1000; // 每个线程的计数数量
        private CancellationTokenSource SearchtokenSource = new();
        private CancellationTokenSource ChecktokenSource = new();
        private CancellationTokenSource cancellationToken = new CancellationTokenSource();
        private const string Pk9Filter = "PK9 Entity |*.pk9|All Files|*.*";
        private bool CheckFlag = true;
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }

        public int GanderValue = 0;
        public int AbilityValue = 0;
        public int MinIV = 0;
        public int Gen9GanderValue = 0;
        public int Gen9AbilityValue = 0;
        public int Gen9MinIV = 0;
        public PK9 newpk = new();
        public List<RNGModClass> L = new();
        private static Random rng = new Random();
        public int[] DIV = { 0, 1, 2, 3, 4, 5, 6 };
        public RNGModClass MD = new RNGModClass
        {
            Name = "Mothed1,2,4",
            Value = "M124",
        };
        public enum ShinyType
        {
            None,
            Shiny,
            Star,
            Sqaure,
            ForceStar,
        }
        private ShinyType selectedShiny = ShinyType.None;
        private MethodType RNGMethod = MethodType.None;
        private RNGService _rngService;

        public RNGForm(ISaveFileProvider sav, IPKMView editor)

        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            _rngService = new RNGService(rules);
            BindingData();
        }
        private void BindingData()
        {
            this.MinHpNUD.DataBindings.Add("Text", rules, "minHP");
            this.MaxHpNUD.DataBindings.Add("Text", rules, "maxHP");
            this.MinAtkNUD.DataBindings.Add("Text", rules, "minAtk");
            this.MaxAtkNUD.DataBindings.Add("Text", rules, "maxAtk");
            this.MinDefNUD.DataBindings.Add("Text", rules, "minDef");
            this.MaxDefNUD.DataBindings.Add("Text", rules, "maxDef");
            this.MinSpaNUD.DataBindings.Add("Text", rules, "minSpA");
            this.MaxSpaNUD.DataBindings.Add("Text", rules, "maxSpA");
            this.MinSpdNUD.DataBindings.Add("Text", rules, "minSpD");
            this.MaxSpdNUD.DataBindings.Add("Text", rules, "maxSpD");
            this.MinSpeNUD.DataBindings.Add("Text", rules, "minSpe");
            this.MaxSpeNUD.DataBindings.Add("Text", rules, "maxSpe");
            this.RNGType_BOX.DataSource = Enum.GetNames(typeof(MethodType));
            this.RNGType_BOX.SelectedIndexChanged += (_, __) =>
            {
                RNGMethod = (MethodType)Enum.Parse(typeof(MethodType), this.RNGType_BOX.SelectedItem.ToString(), false);
                rules.Method = RNGMethod;
            };
            this.RNGType_BOX.SelectedIndex = 0;
            this.ShinyType_BOX.DataSource = Enum.GetNames(typeof(ShinyType));
            this.ShinyType_BOX.SelectedIndexChanged += (_, __) =>
            {
                selectedShiny = (ShinyType)Enum.Parse(typeof(ShinyType), this.ShinyType_BOX.SelectedItem.ToString(), false);
                rules.Shiny = selectedShiny;
            };
            this.ShinyType_BOX.SelectedIndex = 0;
            if (SAV.SAV.Version is GameVersion.XD or GameVersion.COLO or GameVersion.CXD)
            {
                this.TeamLockBox.Enabled = true;
            }
            else
            {
                this.TeamLockBox.Enabled = false;
                this.TeamLockBox.Checked = false;
            }
            PIDECCheck_Box.CheckedChanged += (_, __) =>
            {
                IVCheck_Box.Enabled = !PIDECCheck_Box.Checked;
            };
            IVCheck_Box.CheckedChanged += (_, __) =>
            {
                PIDECCheck_Box.Enabled = !IVCheck_Box.Checked;
            };
            this.MinIV_Box.DataSource = DIV;

            this.MinIV_Box.SelectedIndexChanged += (_, __) =>
            {
                MinIV = int.Parse(MinIV_Box.SelectedItem.ToString());
            };
            Gender_Box.DataSource = Enum.GetValues(typeof(RNGFormGender));
            this.Gender_Box.SelectedIndexChanged += (_, __) =>
            {
                GanderValue = Gender_Box.SelectedIndex;
            };
            Ability_Box.DataSource = Enum.GetValues(typeof(RNGFormAbility));
            this.Ability_Box.SelectedIndexChanged += (_, __) =>
            {
                AbilityValue = Ability_Box.SelectedIndex;
            };
            Tera9genderComboBox.DataSource = Enum.GetValues(typeof(RNGFormGender));
            this.Tera9genderComboBox.SelectedIndexChanged += (_, __) =>
            {
                Gen9GanderValue = Tera9genderComboBox.SelectedIndex;
            };
            Gen9AbilitycomboBox.DataSource = Enum.GetValues(typeof(RNGFormAbility));
            this.Gen9AbilitycomboBox.SelectedIndexChanged += (_, __) =>
            {
                Gen9AbilityValue = Gen9AbilitycomboBox.SelectedIndex;
            };
            this.Gen9IvcomboBox.DataSource = DIV;

            this.Gen9IvcomboBox.SelectedIndexChanged += (_, __) =>
            {
                Gen9MinIV = Gen9IvcomboBox.SelectedIndex;
            };

            // Ensure Mod_ComboBox handler is only added once
            this.Mod_ComboBox.SelectedIndexChanged += (_, __) =>
            {
                if (this.Mod_ComboBox.SelectedItem is RNGModClass mod)
                {
                    MD = mod;
                    ECBox.Enabled = MD?.Value is "Overworld8" or "Tera9";
                }
            };

            CheckPID();

        }
        private void MaxSpeNUD_ValueChanged(object sender, EventArgs e)
        {
            var txtbox = (NumericUpDown)sender;

            if (!uint.TryParse(txtbox.Text, out var iv))
                iv = 0;
            if (iv > 31)
            {
                txtbox.Value = 0;
            }
        }
        #region //Search
        private bool GenPkm(ref PKM pk, uint seed, byte form =0) => _rngService.GenPkm(ref pk, seed, form);
        private bool GenPkm(ref PKM pk, ulong seed64, byte form =0) => _rngService.GenPkm(ref pk, seed64, form);
        private uint NextSeed(uint seed) => _rngService.NextSeed(seed);
        private ulong NextSeed(ulong seed64) => _rngService.NextSeed(seed64);
        private void GeneratorIsRunning(bool running)
        {
            Search.Enabled = !running;
            Cancel.Enabled = running;
        }

        private async void Search_Click(object sender, EventArgs e)
        {
            GeneratorIsRunning(true);

            uint seed = 0;
            ulong seed64 = 0;


            var seedList = new List<uint>();
            if (UsePreSeed.Checked)
            {
                seedList = CheckRules.PreSetSeed(rules);
                await InvokeAsync(() => MessageBox.Show($"预设种子数量:{seedList.Count}"));
                seedList = seedList.OrderBy(_ => rng.Next()).ToList();
            }

            SearchtokenSource = new();
            var token = SearchtokenSource.Token;

            try
            {
                // —— 起始种子初始化 ——
                if (rules.Method is not MethodType.Lumiose)
                {
                    seed = ZeroSeed_Check.Checked
                        ? Convert.ToUInt32(ZeroSeed_TB.Text, 16)
                        : Util.Rand32();
                }
                else
                {
                    seed64 = ZeroSeed_Check.Checked
                        ? Convert.ToUInt64(ZeroSeed_TB.Text, 16)
                        : (ulong)Random.Shared.NextInt64(long.MinValue, long.MaxValue);
                }

                // 手动准备参数并调用搜索引擎
                var initialSeed32 = seed;
                var initialSeed64 = seed64;
                // choose UI update interval:0 = no UI updates until finish (max speed), otherwise ms interval
                int uiInterval =100;
                // if a checkbox named FastModeCheckBox exists and is checked, set interval to5 minutes (300000 ms)
                try { if (this.Controls.Find("FastModeCheckBox", true).FirstOrDefault() is CheckBox cb && cb.Checked) uiInterval =300_000; } catch { }

                // target roughly50% CPU: use about half of logical processors as workers
                int workers = Math.Max(1, (int)Math.Ceiling(Environment.ProcessorCount *0.5));
                long lastDisplayedMs =0;

                // If fast mode, show initial0 minutes and initial seed immediately so user sees activity
                bool fastMode = false;
                try { if (this.Controls.Find("FastModeCheckBox", true).FirstOrDefault() is CheckBox fcb && fcb.Checked) fastMode = true; } catch { }
                if (fastMode)
                {
                    // initial seed display
                    if (rules.Method is not MethodType.Lumiose)
                        SeedTB.Text = initialSeed32.ToString("X8");
                    else
                        SeedTB.Text = initialSeed64.ToString("X16");
                    StateBox.Text = "0 分钟";
                }

                var engineResult = await RNGSearchEngine.RunSearchAsync(
 _rngService,
                    rules,
                    Editor,
                    SAV,
                    initialSeed32,
                    initialSeed64,
                    seedList,
                    ZeroSeed_Check.Checked,
                    TeamLockBox.Checked,
                    Check_Frame.Checked,
                    async (payload) => await InvokeAsync(() =>
 {
 // payload format: "<seedHex>|<elapsedMs>|<rate>"
                    StateBox.Text = "正在查找...";
                    try
                    {
                        var parts = payload.Split('|');
                        var seedHex = parts.Length >0 ? parts[0] : "0";
                        var elapsedMs = parts.Length >1 ? long.Parse(parts[1]) :0;
                        // rate = parts[2] ignored here
                        // only update display every uiInterval; engine already rate-limited
                        SeedTB.Text = seedHex;
                        // compute minutes passed rounded to nearest multiple of (uiInterval in ms)
                        if (lastDisplayedMs ==0) lastDisplayedMs = elapsedMs;
                        var delta = elapsedMs - lastDisplayedMs;
                        // show minutes incrementing by uiInterval steps converted to minutes
                        // if uiInterval is300000 (5 min), this yields0,5,10...
                        // compute minutes as (elapsedMs /60000) rounded down to nearest multiple of (uiInterval/60000)
                        long intervalMinutes =1;
                        try
                        {
                            // attempt to read uiInterval from the FastModeCheckBox logic: if FastModeCheckBox checked we used300000
                            var cb = this.Controls.Find("FastModeCheckBox", true).FirstOrDefault() as CheckBox;
                            if (cb != null && cb.Checked) intervalMinutes =5;
                            else intervalMinutes =0; //0 signals realtime; we'll display minutes as elapsed/60000
                        }
                        catch { intervalMinutes =0; }

                        if (intervalMinutes >0)
                        {
                            long mins = (elapsedMs /60000) / intervalMinutes * intervalMinutes;
                            StateBox.Text = $"{mins} 分钟";
                        }
                        else
                        {
                            long mins = elapsedMs /60000;
                            StateBox.Text = $"{mins} 分钟";
                        }
                    }
                    catch
                    {
                        SeedTB.Text = payload;
                    }
                }),
 token,
 uiInterval,
 workers);

                if (!engineResult.Found)
                {
                    await InvokeAsync(() => MessageBox.Show("没有匹配！"));
                }
                else
                {
                    await InvokeAsync(() =>
                    {
                        MessageBox.Show("Success！");
                        Editor.PopulateFields(engineResult.FoundPKM, false);
                        SAV.ReloadSlots();
                        SeedTB.Text = engineResult.SeedHex;
                    });
                }
            }
            catch (OperationCanceledException)
            {
                await InvokeAsync(() => StateBox.Text = "Stop");
            }
            finally
            {
                await InvokeAsync(() =>
                {
                    GeneratorIsRunning(false);
                    if (StateBox.Text != "Stop")
                        StateBox.Text = "无事可做";
                });
            }

            Task InvokeAsync(Action action)
            {
                if (!IsHandleCreated || !InvokeRequired)
                {
                    action();
                    return Task.CompletedTask;
                }

                var tcs = new TaskCompletionSource();
                BeginInvoke(new MethodInvoker(() =>
                {
                    try { action(); tcs.SetResult(); }
                    catch (Exception ex) { tcs.SetException(ex); }
                }));
                return tcs.Task;
            }
        }

        private async void Cancel_Click(object sender, EventArgs e)
        {
            if (SearchtokenSource is { IsCancellationRequested: false })
            {
                SearchtokenSource.Cancel();
                await Task.Delay(100);
                StateBox.Text = "Stop";
            }

            GeneratorIsRunning(false);
        }
        #endregion

        #region //剑盾Check
        private void FastCheck_BTN_Click(object sender, EventArgs e)
        {
            CheckerIsRunning(true);
            CheckFlag = true;
            SWSHSeedCheck(CheckFlag);
        }
        private void SlowCheck_BTN_Click(object sender, EventArgs e)
        {
            CheckerIsRunning(true);
            CheckFlag = false;
            SWSHSeedCheck(CheckFlag);
        }
        private void CheckerIsRunning(bool running)
        {
            FastCheck_BTN.Enabled = !running;
            SlowCheck.Enabled = !running;
        }

        private void FixLairSeed_Click(object sender, EventArgs e)
        {
            var pk = Editor.Data;
            var encounters = EncounterMovesetGenerator.GenerateEncounters(pk, SAV.SAV, pk.Moves);
            if (pk.Generation == 8)
            {
                foreach (var enc in encounters)
                {
                    if (pk.Generation == 8 && pk.MetLocation == 244)
                    {
                        FindNestPIDIV.PreSetPIDIV(pk, enc);
                        break;
                    }
                }
            }
        }
        private void SWSHSeedCheck(bool checkflag)
        {
            string T = "";
            Legal_Check_BOX1.Text = "正在检测基本合法性";
            Legal_Check_BOX2.Text = "正在反推Seed";
            Legal_Check_BOX3.Text = "正在检测PID/EC/IV";
            Legal_Check_BOX4.Text = "正在检测特性，性别";
            Legal_Check_BOX5.Text = "正在检测身高体重";
            ChecktokenSource = new();
            var la = new LegalityAnalysis(Editor.Data);
            Task.Factory.StartNew(
                () =>
                {
                    uint ec = Editor.Data.EncryptionConstant;
                    uint pid = Editor.Data.PID;
                    int[] ivs = { Editor.Data.IV_HP, Editor.Data.IV_ATK, Editor.Data.IV_DEF, Editor.Data.IV_SPA, Editor.Data.IV_SPD, Editor.Data.IV_SPE };
                    IEnumerable<ulong> seeds = Enumerable.Empty<ulong>();
                    if (checkflag)
                    {
                        seeds = Z3Search.GetSeeds(ec, pid);
                    }
                    //注意！剑盾raid seed快速逆推注意需要在根目录放置Microsoft.Z3.dll与libz3.dll
                    //https://github.com/Z3Prover/z3
                    //https://stackoverflow.com/questions/11136324/an-error-appears-when-running-z3-in-c-sharp
                    else
                        seeds = BruteForceSearch.FindSeeds(ec, pid, Editor.Data.TID16, Editor.Data.SID16);

                    if (la.Valid == true)
                    {
                        Legal_Check_BOX1.Text = "合法性检测通过！";
                        Legal_Check_BOX1.BackColor = Color.Green;
                        var t = la.EncounterOriginal;
                        int r = t.Location;
                        if (r is 162 or 244)
                        {
                            if (Gen8DenMax.FindFirstSeed(seeds, ivs) == "没找到Seed")
                            {
                                Legal_Check_BOX2.Text = "逆推失败!没找到Seed";
                                Legal_Check_BOX2.BackColor = Color.Red;
                                Legal_Check_BOX3.Text = "无法检测PID/EC/IV";
                                Legal_Check_BOX3.BackColor = Color.Red;
                                Legal_Check_BOX4.Text = "无法检测性格性别";
                                Legal_Check_BOX4.BackColor = Color.Red;
                                Legal_Check_BOX5.Text = "无法检测身高体重";
                                Legal_Check_BOX5.BackColor = Color.Red;
                            }
                            else
                            {
                                Legal_Check_BOX2.Text = "逆推成功!";
                                Legal_Check_BOX2.BackColor = Color.Green;
                                Seed_Box.Text = Gen8DenMax.FindFirstSeed(seeds, ivs);
                                T = Gen8DenMax.Raidfinder(Seed_Box.Text, Editor.Data, MinIV, AbilityValue, GanderValue);
                                var S = T.Split('\n');
                                if (S.Count() != 0)
                                {
                                    Legal_Check_BOX3.Text = S[0];
                                    if (S[1] == "Green")
                                        Legal_Check_BOX3.BackColor = Color.Green;
                                    else if (S[1] == "Orange")
                                        Legal_Check_BOX3.BackColor = Color.Orange;
                                    Legal_Check_BOX4.Text = S[2];
                                    if (S[3] == "Green")
                                        Legal_Check_BOX4.BackColor = Color.Green;
                                    else if (S[3] == "Orange")
                                        Legal_Check_BOX4.BackColor = Color.Orange;
                                    Legal_Check_BOX5.Text = S[4];
                                    if (S[5] == "Green")
                                        Legal_Check_BOX5.BackColor = Color.Green;
                                    else if (S[5] == "Orange")
                                        Legal_Check_BOX5.BackColor = Color.Orange;
                                }
                            }
                        }
                        else
                        {
                            Legal_Check_BOX1.Text = "基本合法性检测通过！";
                            Legal_Check_BOX1.BackColor = Color.Green;
                            Legal_Check_BOX2.Text = "无需寻找Seed";
                            Legal_Check_BOX2.BackColor = Color.Green;
                            Legal_Check_BOX3.Text = "无需检测PID/EC/IV";
                            Legal_Check_BOX3.BackColor = Color.Green;
                            Legal_Check_BOX4.Text = "无需检测性格性别";
                            Legal_Check_BOX4.BackColor = Color.Green;
                            Legal_Check_BOX5.Text = "无需检测身高体重";
                            Legal_Check_BOX5.BackColor = Color.Green;
                        }
                    }
                    else
                    {
                        Legal_Check_BOX1.Text = "基本合法性检测未通过！";
                        Legal_Check_BOX1.BackColor = Color.Red;
                        Legal_Check_BOX2.Text = "无事可做";
                        Legal_Check_BOX3.Text = "无事可做";
                        Legal_Check_BOX4.Text = "无事可做";
                        Legal_Check_BOX5.Text = "无事可做";
                    }
                    this.Invoke(() =>
                    { CheckerIsRunning(false); }
                );
                }, ChecktokenSource.Token);
        }
        #endregion

        #region //Reverse
        private void ReverseCheck_BTN_Click(object sender, EventArgs e)
        {
            Span<uint> Seeds = stackalloc uint[6];
            uint EC =0;
            uint PID =0;
            uint hp =0;
            uint atk =0;
            uint def =0;
            uint spa =0;
            uint spd =0;
            uint spe =0;
            Span<string> s = new();
            var PIDHEX = "0x" + PIDBox.Text;
            var IVString = IVTextBox.Text;
            if (IVString.Length !=0)
            {
                s = IVString.Split(',');
                hp = Convert.ToUInt16(s[0]);
                atk = Convert.ToUInt16(s[1]);
                def = Convert.ToUInt16(s[2]);
                spa = Convert.ToUInt16(s[3]);
                spd = Convert.ToUInt16(s[4]);
                spe = Convert.ToUInt16(s[5]);

            }
            if (PIDHEX != "0x")
                PID = Convert.ToUInt32(PIDHEX, 16);
            var ECHEX = "0x" + ECBox.Text;
            if (ECHEX != "0x")
                EC = Convert.ToUInt32(ECHEX, 16);
            uint seed =0;

            uint[] resultSeeds = Array.Empty<uint>();

            if (PIDECCheck_Box.Checked)
            {
                resultSeeds = GetSeedsByPID(EC, PID);
            }

            if (IVCheck_Box.Checked)
            {
                var ivSeeds = GetSeedsByIV(hp, atk, def, spa, spd, spe);
                // if both checks enabled, merge unique non-zero seeds
                resultSeeds = resultSeeds.Length ==0 ? ivSeeds : resultSeeds.Concat(ivSeeds).Where(v => v !=0).Distinct().ToArray();
            }

            if (resultSeeds.Length !=0)
            {
                SeedBox.Clear();
                var r = PrintSeed(resultSeeds, seed).Split('\n');
                for (int i =0; i < r.Length; i++)
                    SeedBox.AppendText($"{r[i]}" + Environment.NewLine);
            }
        }

        private uint[] GetSeedsByPID(uint EC, uint PID)
        {
            var arr = new uint[6];
            switch (MD.Value)
            {
                case "M124":
                    LCRNGReversal.GetSeeds(arr.AsSpan(), PID);
                    break;
                case "M3":
                    LCRNGReversalSkip.GetSeeds(arr.AsSpan(), PID);
                    break;
                case "M124U":
                    LCRNGReversal.GetSeeds(arr.AsSpan(), PID, true);
                    break;
                case "M3U":
                    LCRNGReversalSkip.GetSeeds(arr.AsSpan(), PID, true);
                    break;
                case "XDColo":
                    XDRNGReversal.GetSeeds(arr.AsSpan(), PID);
                    for (int i =0; i < arr.Length; i++)
                        if (arr[i] !=0)
                            arr[i] = XDRNG.Prev3(arr[i]);
                    break;
                case "Overworld8":
                    return new[] { Overworld8Reversal.GetOriginalSeed(EC, PID) };
                case "Tera9":
                    return new[] { Tera9RNGReverse.GetOriginalSeed(EC, PID) };
                default:
                    return Array.Empty<uint>();
            }

            return arr.Where(val => val !=0).ToArray();
        }

        private uint[] GetSeedsByIV(uint hp, uint atk, uint def, uint spa, uint spd, uint spe)
        {
            var arr = new uint[6];
            switch (MD.Value)
            {
                case "M1":
                    LCRNGReversal.GetSeedsIVs(arr.AsSpan(), hp, atk, def, spa, spd, spe);
                    for (int i =0; i < arr.Length; i++)
                        if (arr[i] !=0)
                            arr[i] = LCRNG.Prev2(arr[i]);
                    break;
                case "M23":
                    LCRNGReversal.GetSeedsIVs(arr.AsSpan(), hp, atk, def, spa, spd, spe);
                    for (int i =0; i < arr.Length; i++)
                        if (arr[i] !=0)
                            arr[i] = LCRNG.Prev3(arr[i]);
                    break;
                case "M4":
                    LCRNGReversalSkip.GetSeedsIVs(arr.AsSpan(), hp, atk, def, spa, spd, spe);
                    for (int i =0; i < arr.Length; i++)
                        if (arr[i] !=0)
                            arr[i] = LCRNG.Prev3(arr[i]);
                    break;
                case "XDColo":
                    XDRNGReversal.GetSeeds(arr.AsSpan(), hp, atk, def, spa, spd, spe);
                    break;
                default:
                    return Array.Empty<uint>();
            }

            return arr.Where(val => val !=0).ToArray();
        }
        private string PrintSeed(uint[] seeds, uint seed =0)
        {
            string result = "";
            if (seeds.Length !=0 && MD.Value != "Overworld8" && MD.Value != "Tera9")
            {
                for (int i =0; i < seeds.Length; i++)
                {
                    result += seeds[i].ToString("X") + '\n';
                }
            }
            else if (seed !=0 && (MD.Value is "Overworld8" or "Tera9"))
            {
                result = seed.ToString("X");
            }
            return result;
        }
        private void PIDECCheck_Box_CheckedChanged(object sender, EventArgs e)
        {
            if (PIDECCheck_Box.Checked)
            {
                CheckPID();
            }
            else
            {
                CheckPID();
            }
        }
        private void IVCheck_Box_CheckedChanged(object sender, EventArgs e)
        {
            if (IVCheck_Box.Checked)
            {
                CheckIV();
            }
            else
            {
                CheckPID();
            }

        }
        private void CheckPID()
        {
            L = RNGModClass.RNGModList(false);
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = L;
            Mod_ComboBox.DataSource = bindingSource1.DataSource;
            Mod_ComboBox.DisplayMember = "Name";
            Mod_ComboBox.ValueMember = "Value";
            // handler moved to BindingData to avoid duplicate subscriptions
            IVTextBox.Enabled = false;
            PIDBox.Enabled = true;
        }
        private void CheckIV()
        {
            L = RNGModClass.RNGModList(true);
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = L;
            Mod_ComboBox.DataSource = bindingSource1.DataSource;
            Mod_ComboBox.DisplayMember = "Name";
            Mod_ComboBox.ValueMember = "Value";
            // handler moved to BindingData to avoid duplicate subscriptions
            IVTextBox.Enabled = true;
            PIDBox.Enabled = false;
        }
        #endregion

        #region //太晶坑检测
        private void FixPidForTera_BTN_Click(object sender, EventArgs e)
        {
            var pk = Editor.Data;
            if (pk.Generation == 9)
            {
                if (pk.MetLocation == Locations.TeraCavern9)
                {
                    pk.PID = (((uint)(pk.TID16 ^ pk.SID16) ^ (pk.PID & 0xFFFF) ^ 1u) << 16) | (pk.PID & 0xFFFF);
                }
            }
            Editor.PopulateFields(pk);
        }
           private void CheckTeraSeed_BTN_Click(object sender, EventArgs e)
           {
               var pk = (PK9)Editor.Data;
               byte num5 = 0;
               switch (Gen9GanderValue)
               {
                   case 0:
                       num5 = 0;
                       break;
                   case 1:
                       num5 = 31;
                       break;
                   case 2:
                       num5 = 63;
                       break;
                   case 3:
                       num5 = 127;
                       break;
                   case 4:
                       num5 = 191;
                       break;
                   case 5:
                       num5 = 225;
                       break;
                   case 6:
                       num5 = 254;
                       break;
                   case 7:
                       num5 = 255;
                       break;
               }
               GenerateParam9 enc = new()
               {
                   Species = pk.Species,
                   GenderRatio = num5,
                   Ability = (AbilityPermission)(Gen9AbilityValue - 1),
                   Nature = (Nature)pk.Nature,
                   FlawlessIVs = (byte)Gen9MinIV,
                   ScaleType = SizeType9.RANDOM,
                   Scale = 0,
                   Weight = 0,
                   Height = 0,
                   RollCount = 1,
                   Shiny = Shiny.Random,
                   IVs = new IndividualValueSet()
                   {
                       HP = (sbyte)pk.IV_HP,
                       ATK = (sbyte)pk.IV_ATK,
                       DEF = (sbyte)pk.IV_DEF,
                       SPA = (sbyte)pk.IV_SPA,
                       SPD = (sbyte)pk.IV_SPD,
                       SPE = (sbyte)pk.IV_SPE,
                   }

               };
               var seed = Tera9RNG.GetOriginalSeed(pk);
               var value = RNG.Methods.Encounter9RNG.SeedToValue(pk, enc, EncounterCriteria.Unrestricted, seed);
               string GenderText = "";
               string AbilityText = "";
               TeraSeedBox.Text = $"{seed:X8}";
               txtEC.Text = $"{value.EncryptionConstant:X8}";
               txtPID.Text = $"{value.PID:X8}";
               cmbNature.Text = $"{((Nature)value.Nature).ToString()}";
               numHeight.Value = value.HeightScalar;
               numWeight.Value = value.WeightScalar;
               numScale.Value = value.Scale;
               Span<int> ivs = stackalloc int[6];
               value.GetIVs(ivs);
               IVstextBox.Text = $"{ivs[0]}, {ivs[1]}, {ivs[2]}, {ivs[3]}, {ivs[4]}, {ivs[5]}";
               switch (value.Gender)
               {
                   case 0:
                       GenderText = "公";
                       break;
                   case 1:
                       GenderText = "母";
                       break;
                   case 2:
                       GenderText = "无性别";
                       break;
               }
               GendertextBox.Text = $"{GenderText}";
               switch (value.Ability)
               {
                   case 1:
                       AbilityText = "特性一";
                       break;
                   case 2:
                       AbilityText = "特性二";
                       break;
                   case 4:
                       AbilityText = "梦特";
                       break;
               }
               AbilitytextBox.Text = $"{AbilityText}";
           }
        #endregion
        //Help
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SeedIntro();
            form.Show();
        }
        private void CalcBTN_Click(object sender, EventArgs e)
        {
            if (SeedCheckBox.Text == "")
                return;
            string vIn = SeedCheckBox.Text;
            uint vOut = Convert.ToUInt32(vIn, 16);
            var pkm = Editor.Data;
            GenPkm(ref pkm, vOut);
            IVCheckBox.Text = $"{pkm.IV_HP}/{pkm.IV_ATK}/{pkm.IV_DEF}/{pkm.IV_SPA}/{pkm.IV_SPD}/{pkm.IV_SPE}";
        }
        private void Start_BTN_Click(object sender, EventArgs e)
        {
            if (!Int32.TryParse(StepBox.Text, out NumOfCountsPerThread))
            {
                MessageBox.Show("步数不合法");
                return;
            }
            cancellationToken = new CancellationTokenSource(); // 重置CancellationTokenSource以便于新的运行
            int threadnumber = (int)ThreadNumber.Value;
            panelBox.Controls.Clear(); // Clear existing controls

            int numOfTextBoxes = threadnumber;
            for (int i = 0; i < numOfTextBoxes; i++)
            {
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.AutoSize = true;
                panel.FlowDirection = FlowDirection.TopDown;
                CheckedListBox newCheckedListBox = new CheckedListBox();
                newCheckedListBox.Height = 100;
                newCheckedListBox.Width = 150;
                newCheckedListBox.DisplayMember = "DisplayText";
                newCheckedListBox.ItemCheck += CheckedListBox_ItemCheck; // register handler on UI thread
                System.Windows.Forms.ProgressBar newProgressBar = new System.Windows.Forms.ProgressBar();
                newProgressBar.Minimum = 0;
                newProgressBar.Maximum = NumOfCountsPerThread;
                newProgressBar.Width = 150;
                panel.Controls.Add(newCheckedListBox);
                panel.Controls.Add(newProgressBar);

                panelBox.Controls.Add(panel);
            }


            // start tasks instead of raw threads
            for (int i = 0; i < numOfTextBoxes; i++)
            {
                int threadIndex = i;
                _ = Task.Run(() => PerformCountingAsync(threadIndex, cancellationToken.Token));
            }
        }

        private async Task PerformCountingAsync(int threadIndex, CancellationToken ct)
        {
            if (!Int32.TryParse(StepBox.Text, out NumOfCountsPerThread))
            {
                Invoke(new Action(() => MessageBox.Show("步数不合法")));
                return;
            }

            if (threadIndex < 0 || threadIndex >= panelBox.Controls.Count)
                return;

            FlowLayoutPanel panel = (FlowLayoutPanel)panelBox.Controls[threadIndex];
            System.Windows.Forms.ProgressBar progressBar = (System.Windows.Forms.ProgressBar)panel.Controls[1];
            System.Windows.Forms.CheckedListBox checkedList = (System.Windows.Forms.CheckedListBox)panel.Controls[0];

            int n = 0;
            uint start = (uint)(threadIndex * NumOfCountsPerThread + 1);
            uint end = (uint)((threadIndex + 1) * NumOfCountsPerThread);

            for (uint count = start; count <= end; count++)
            {
                ct.ThrowIfCancellationRequested();

                var seed = count; // Prepare data for this iteration

                // Run generation on threadpool to avoid UI freeze
                var ok = await Task.Run(() =>
                {
                    var pk = Editor.Data.Clone(); // Assume Clone creates a new instance
                    if (GenPkm(ref pk, seed, pk.Form))
                        return (true, pk);
                    return (false, (PKM)null);
                }, ct);

                if (ok.Item1)
                {
                    Invoke(new Action(() =>
                    {
                        PKwithName item = new PKwithName(ok.Item2);
                        checkedList.Items.Add(item); // add wrapped object
                        progressBar.Value = Math.Min(++n, progressBar.Maximum); // Update progress bar
                    }));
                }
                else
                {
                    // still update progress even if not found
                    Invoke(new Action(() => progressBar.Value = Math.Min(++n, progressBar.Maximum)));
                }

                // optional tiny yield to keep UI responsive
                await Task.Yield();
            }
        }

        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (sender is not CheckedListBox list) return;
            this.BeginInvoke((MethodInvoker)delegate
            {
                if (e.Index >= 0 && e.Index < list.Items.Count)
                {
                    if (list.Items[e.Index] is PKwithName yourObject)
                    {
                        SAV.SAV.SetBoxSlotAtIndex(yourObject.OriginalItem, 0, 0);
                        SAV.ReloadSlots();
                    }
                }
            });
        }
        private void Stop_BTN_Click(object sender, EventArgs e)
        {
            if (cancellationToken != null && !cancellationToken.IsCancellationRequested)
            {
                cancellationToken.Cancel(); //发送取消请求
            }
        }
    }
}
