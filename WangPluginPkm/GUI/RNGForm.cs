using PKHeX.Core;
using System;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using WangPluginPkm.RNG.Methods;
using static WangPluginPkm.PluginUtil.PluginEnums.GUIEnums;
using static WangPluginPkm.PluginUtil.PluginEnums.TeraEnum;
using Overworld8RNG = WangPluginPkm.RNG.Methods.Overworld8RNG;
using Roaming8bRNG = WangPluginPkm.RNG.Methods.Roaming8bRNG;
using WangPluginPkm.WangUtil.ModifyPKM;
using static WangPluginPkm.CheckRules;

namespace WangPluginPkm.GUI
{
    internal partial class RNGForm : Form
    {

        private CancellationTokenSource SearchtokenSource = new();
        private CancellationTokenSource ChecktokenSource = new();
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
        public RNGForm(ISaveFileProvider sav, IPKMView editor)

        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
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
            CheckPID();

        }

        #region //Search
        private bool GenPkm(ref PKM pk, uint seed, byte form = 0)
        {

            return ConditionForm.rules.Method switch
            {
                MethodType.None => NoMethod.GenPkm(ref pk, ConditionForm.rules),
                MethodType.Method1 => Method1RNG.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.Method1_Unown => UnownRNG.GenPkm(ref pk, 1, seed, ConditionForm.rules, form),
                MethodType.Method2 => Method2RNG.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.Method2_Unown => UnownRNG.GenPkm(ref pk, 2, seed, ConditionForm.rules, form),
                MethodType.Method3 => Method3RNG.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.Method3_Unown => UnownRNG.GenPkm(ref pk, 3, seed, ConditionForm.rules, form),
                MethodType.Method4 => Method4RNG.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.Method4_Unown => UnownRNG.GenPkm(ref pk, 4, seed, ConditionForm.rules, form),
                MethodType.XDColo => XDColoRNG.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.Overworld8 => Overworld8RNG.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.Roaming8b => Roaming8bRNG.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.BACD_R => BACD.GenPkm(ref pk, seed & 0xFFFF, ConditionForm.rules, 0),
                MethodType.BACD_U => BACD.GenPkm(ref pk, seed, ConditionForm.rules, 1),
                MethodType.BACD_R_S => BACD.GenPkm(ref pk, seed & 0xFFFF, ConditionForm.rules, 2),
                MethodType.Method1Roaming => Method1Roaming.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.Colo => ColoRNG.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.E_Reader => E_Reader.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.ChainShiny => ChainShiny.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.G5MGShiny => G5MGShiny.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.Gen5Wild => Gen5Wild.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.PokeWalker => PokeWalker.GenPkm(ref pk, ConditionForm.rules),
                MethodType.PokeSpot => PokeSpot.GenPkm(ref pk, seed, ConditionForm.rules),
                _ => throw new NotSupportedException(),
            };
        }
        private uint NextSeed(uint seed)
        {
            return ConditionForm.rules.Method switch
            {
                MethodType.Method1 => Method1RNG.Next(seed),
                MethodType.Method1_Unown => UnownRNG.Next(seed),
                MethodType.Method2 => Method2RNG.Next(seed),
                MethodType.Method2_Unown => UnownRNG.Next(seed),
                MethodType.Method3 => Method3RNG.Next(seed),
                MethodType.Method3_Unown => UnownRNG.Next(seed),
                MethodType.Method4 => Method4RNG.Next(seed),
                MethodType.Method4_Unown => UnownRNG.Next(seed),
                MethodType.XDColo => XDColoRNG.Next(seed),
                MethodType.Overworld8 => Overworld8RNG.Next(seed),
                MethodType.Roaming8b => Roaming8bRNG.Next(seed),
                MethodType.BACD_R => BACD.Next(seed),
                MethodType.BACD_U => BACD.Next(seed),
                MethodType.BACD_R_S => BACD.Next(seed),
                MethodType.Method1Roaming => Method1Roaming.Next(seed),
                MethodType.Colo => ColoRNG.Next(seed),
                MethodType.E_Reader => E_Reader.Next(seed),
                MethodType.ChainShiny => ChainShiny.Next(seed),
                MethodType.G5MGShiny => G5MGShiny.Next(seed),
                MethodType.Gen5Wild => Gen5Wild.Next(seed),
                MethodType.PokeWalker => PokeWalker.Next(seed),
                MethodType.PokeSpot => PokeSpot.Next(seed),
                _ => throw new NotSupportedException(),
            };
        }
        private void GeneratorIsRunning(bool running)
        {
            Search.Enabled = !running;
            Cancel.Enabled = running;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            GeneratorIsRunning(true);
            ConditionForm.ConditionBox.Text = "searching...";
            uint seed = 0;
            int i = 0;
            List<uint> SeedList = new List<uint>();
            if (UsePreSeed.Checked == true)
            {
                SeedList = CheckRules.PreSetSeed(ConditionForm.rules);
                MessageBox.Show($"预设种子数量:{SeedList.Count}");
            }
            SearchtokenSource = new();
            if (UsePreSeed.Checked == true)
            {
                SeedList = SeedList.OrderBy(a => rng.Next()).ToList();
            }
            Task.Factory.StartNew(
                () =>
                {
                    seed = Util.Rand32();
                    var cloneseed = seed;
                    var pk = Editor.Data;
                    var p = Editor.Data.Clone();

                    while (true)
                    {
                        if (SearchtokenSource.IsCancellationRequested)
                        {
                            ConditionForm.ConditionBox.Text = "Stop";
                            return;
                        }

                        if (SeedList.Count != 0 && i <= SeedList.Count)
                        {
                            seed = SeedList[i];
                            i++;

                        }
                        if (TeamLockBox.Checked == true)
                        {
                            if (LockCheck.ChooseLock(pk.Species, p, ref seed) == false)
                            {
                                cloneseed = NextSeed(cloneseed);
                                seed = cloneseed;
                                continue;
                            }
                        }
                        if (GenPkm(ref pk, seed, p.Form))
                        {
                            // MessageBox.Show($"Success！");
                            this.Invoke(() =>
                                {
                                    MessageBox.Show($"Success！");
                                    Editor.PopulateFields(pk, false);
                                    SAV.ReloadSlots();
                                    ConditionForm.SeedBox.Text = $"{Convert.ToString(seed, 16)}";
                                });
                            break;
                        }
                        seed = NextSeed(seed);
                    }
                    this.Invoke(() =>
                    {
                        GeneratorIsRunning(false);
                        ConditionForm.ConditionBox.Text = "无事可做";
                    });
                },
                SearchtokenSource.Token);
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            SearchtokenSource.Cancel();
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
                    if (pk.Generation == 8 && pk.Met_Location == 244)
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
                        seeds = BruteForceSearch.FindSeeds(ec, pid, Editor.Data.TID16, Editor.Data.SID16);//慢速逆推暂时弃用了

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
            var S = Seeds.ToArray();
            uint EC = 0;
            uint PID = 0;
            uint hp = 0;
            uint atk = 0;
            uint def = 0;
            uint spa = 0;
            uint spd = 0;
            uint spe = 0;
            Span<string> s = new();
            var PIDHEX = "0x" + PIDBox.Text;
            var IVString = IVTextBox.Text;
            if (IVString.Length != 0)
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
            uint seed = 0;
            if (PIDECCheck_Box.Checked)
            {
                switch (MD.Value)
                {
                    case "M124":
                        {
                            LCRNGReversal.GetSeeds(Seeds, PID);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            break;
                        }
                    case "M3":
                        {
                            LCRNGReversalSkip.GetSeeds(Seeds, PID);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            break;
                        }
                    case "M124U":
                        {
                            LCRNGReversal.GetSeeds(Seeds, PID, true);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            break;
                        }
                    case "M3U":
                        {
                            LCRNGReversalSkip.GetSeeds(Seeds, PID, true);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            break;
                        }
                    case "XDColo":
                        {
                            XDRNGReversal.GetSeeds(Seeds, PID);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            for (int i = 0; i < S.Length; i++)
                            {
                                S[i] = XDRNG.Prev3(S[i]);
                            }
                            break;
                        }
                    case "Overworld8":
                        {
                            seed = Overworld8Reversal.GetOriginalSeed(EC, PID);
                            break;
                        }
                }

            }
            if (IVCheck_Box.Checked)
            {
                switch (MD.Value)
                {
                    case "M1":
                        {
                            LCRNGReversal.GetSeedsIVs(Seeds, hp, atk, def, spa, spd, spe);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            for (int i = 0; i < S.Length; i++)
                            {
                                S[i] = LCRNG.Prev2(S[i]);
                            }
                            break;
                        }
                    case "M23":
                        {
                            LCRNGReversal.GetSeedsIVs(Seeds, hp, atk, def, spa, spd, spe);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            for (int i = 0; i < S.Length; i++)
                            {
                                S[i] = LCRNG.Prev3(S[i]);
                            }
                            break;
                        }
                    case "M4":
                        {
                            LCRNGReversalSkip.GetSeedsIVs(Seeds, hp, atk, def, spa, spd, spe);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            for (int i = 0; i < S.Length; i++)
                            {
                                S[i] = LCRNG.Prev3(S[i]);
                            }
                            break;
                        }
                    case "XDColo":
                        {
                            XDRNGReversal.GetSeeds(Seeds, hp, atk, def, spa, spd, spe);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            break;
                        }
                }
            }
            if (Seeds.Length != 0)
            {
                SeedBox.Text = PrintSeed(S, seed);
            }
        }
        private string PrintSeed(uint[] seeds, uint seed = 0)
        {
            string result = "";
            if (seeds.Length != 0 && MD.Value != "Overworld8")
            {
                for (int i = 0; i < seeds.Length; i++)
                {
                    result += seeds[i].ToString("X") + '\n';
                }
            }
            else if (seed != 0 && MD.Value == "Overworld8")
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
            this.Mod_ComboBox.SelectedIndexChanged += (_, __) =>
            {
                MD = (RNGModClass)this.Mod_ComboBox.SelectedItem;
                if (MD.Value == "Overworld8")
                {
                    ECBox.Enabled = true;
                }
                else
                    ECBox.Enabled = false;
            };
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
            this.Mod_ComboBox.SelectedIndexChanged += (_, __) =>
            {
                MD = (RNGModClass)this.Mod_ComboBox.SelectedItem;
                ECBox.Enabled = false;
            };
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
                if (pk.Met_Location == Locations.TeraCavern9)
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
            var value = RNG.Methods.Encounter9RNG.SeedToValue(pk, enc, seed);
            string GenderText = "";
            string AbilityText = "";
            TeraSeedBox.Text = $"{seed:X8}";
            txtEC.Text = $"{value.EC:X8}";
            txtPID.Text = $"{value.PID:X8}";
            cmbNature.Text = $"{((Nature)value.nature).ToString()}";
            numHeight.Value = value.Height;
            numWeight.Value = value.Weight;
            numScale.Value = value.Size;
            IVstextBox.Text = $"{value.ivs[0]},{value.ivs[1]},{value.ivs[2]},{value.ivs[3]},{value.ivs[4]},{value.ivs[5]}";
            switch (value.gender)
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
            switch (value.ability)
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

    }
}
