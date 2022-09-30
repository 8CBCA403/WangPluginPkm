using PKHeX.Core;
using System;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using WangPlugin.RNG;
using System.Runtime.CompilerServices;

namespace WangPlugin.GUI
{
    public class RNGForm : Form
    {
        private Button Search;
        private CancellationTokenSource tokenSource1 = new();
        private CancellationTokenSource tokenSource2 = new();
        private Button Cancel;
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        public enum Gender
        {
            [Description("只能公")]
            M,
            [Description("1母:7公")]
            OFSM,
            [Description("1母:3公")]
            OFTM,
            [Description("1母:1公")]
            OFOM,
            [Description("3母:1公")]
            TFOM,
            [Description("7母:1公")]
            SFOM,
            [Description("只能母")]
            F,
            [Description("无性别")]
            None,
        }
        public enum Ability
        {
            [Description("无梦特")]
            ND,
            [Description("有梦特")]
            CD,
            [Description("只能特性一")]
            ONE,
        }
        public Gender G = Gender.None;
        public Ability A = Ability.CD;
        private CheckBox UsePreSeed;
        private Button Check_BTN;
        private GroupBox groupBox1;
        private ComboBox MinIV_Box;
        public int MinIV = 0;
        private ComboBox Gender_Box;
        private Label label2;
        private Label label3;
        private ComboBox Ability_Box;
        private Label label4;
        private GroupBox groupBox2;
        private TextBox Seed_Box;
        private TextBox Legal_Check_BOX1;
        private TextBox Legal_Check_BOX4;
        private TextBox Legal_Check_BOX3;
        private TextBox Legal_Check_BOX2;
        private TextBox Legal_Check_BOX5;
        private Button GetSeedForMaxLair_BTN;
        private PkmCondition ConditionForm;
        private CheckBox TeamLockBox;
        private static Random rng = new Random();
        private TextBox PIDBox;
        private Button ReverseCheck_BTN;
        private TextBox SeedBox;
        public int[] DIV ={ 0, 1, 2, 3, 4, 5 ,6 };
        public RNGForm(ISaveFileProvider sav, IPKMView editor)

        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            BindingData();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RNGForm));
            this.Search = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.UsePreSeed = new System.Windows.Forms.CheckBox();
            this.Check_BTN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TeamLockBox = new System.Windows.Forms.CheckBox();
            this.ConditionForm = new PkmCondition();
            this.MinIV_Box = new System.Windows.Forms.ComboBox();
            this.Gender_Box = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Ability_Box = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PIDBox = new System.Windows.Forms.TextBox();
            this.ReverseCheck_BTN = new System.Windows.Forms.Button();
            this.GetSeedForMaxLair_BTN = new System.Windows.Forms.Button();
            this.Legal_Check_BOX5 = new System.Windows.Forms.TextBox();
            this.Legal_Check_BOX4 = new System.Windows.Forms.TextBox();
            this.Legal_Check_BOX3 = new System.Windows.Forms.TextBox();
            this.Legal_Check_BOX2 = new System.Windows.Forms.TextBox();
            this.Legal_Check_BOX1 = new System.Windows.Forms.TextBox();
            this.Seed_Box = new System.Windows.Forms.TextBox();
            this.SeedBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(50, 192);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(92, 25);
            this.Search.TabIndex = 9;
            this.Search.Text = "开始查找";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(178, 192);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(92, 25);
            this.Cancel.TabIndex = 11;
            this.Cancel.Text = "停止查找";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // UsePreSeed
            // 
            this.UsePreSeed.AutoSize = true;
            this.UsePreSeed.Location = new System.Drawing.Point(6, 171);
            this.UsePreSeed.Name = "UsePreSeed";
            this.UsePreSeed.Size = new System.Drawing.Size(98, 19);
            this.UsePreSeed.TabIndex = 22;
            this.UsePreSeed.Text = "使用预设种子";
            this.UsePreSeed.UseVisualStyleBackColor = true;
            // 
            // Check_BTN
            // 
            this.Check_BTN.Location = new System.Drawing.Point(6, 147);
            this.Check_BTN.Name = "Check_BTN";
            this.Check_BTN.Size = new System.Drawing.Size(140, 25);
            this.Check_BTN.TabIndex = 23;
            this.Check_BTN.Text = "开始检测";
            this.Check_BTN.UseVisualStyleBackColor = true;
            this.Check_BTN.Click += new System.EventHandler(this.Check_BTN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Cancel);
            this.groupBox1.Controls.Add(this.TeamLockBox);
            this.groupBox1.Controls.Add(this.Search);
            this.groupBox1.Controls.Add(this.UsePreSeed);
            this.groupBox1.Controls.Add(this.ConditionForm);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 223);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查找";
            // 
            // TeamLockBox
            // 
            this.TeamLockBox.AutoSize = true;
            this.TeamLockBox.Location = new System.Drawing.Point(138, 171);
            this.TeamLockBox.Name = "TeamLockBox";
            this.TeamLockBox.Size = new System.Drawing.Size(99, 19);
            this.TeamLockBox.TabIndex = 24;
            this.TeamLockBox.Text = "CXD使用队锁";
            this.TeamLockBox.UseVisualStyleBackColor = true;
            // 
            // ConditionForm
            // 
            this.ConditionForm.Location = new System.Drawing.Point(7, 14);
            this.ConditionForm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ConditionForm.Name = "ConditionForm";
            this.ConditionForm.Size = new System.Drawing.Size(313, 186);
            this.ConditionForm.TabIndex = 23;
            // 
            // MinIV_Box
            // 
            this.MinIV_Box.FormattingEnabled = true;
            this.MinIV_Box.Location = new System.Drawing.Point(41, 55);
            this.MinIV_Box.Name = "MinIV_Box";
            this.MinIV_Box.Size = new System.Drawing.Size(105, 23);
            this.MinIV_Box.TabIndex = 25;
            // 
            // Gender_Box
            // 
            this.Gender_Box.FormattingEnabled = true;
            this.Gender_Box.Location = new System.Drawing.Point(54, 85);
            this.Gender_Box.Name = "Gender_Box";
            this.Gender_Box.Size = new System.Drawing.Size(92, 23);
            this.Gender_Box.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 27;
            this.label2.Text = "锁IV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "公母比";
            // 
            // Ability_Box
            // 
            this.Ability_Box.FormattingEnabled = true;
            this.Ability_Box.Location = new System.Drawing.Point(41, 116);
            this.Ability_Box.Name = "Ability_Box";
            this.Ability_Box.Size = new System.Drawing.Size(105, 23);
            this.Ability_Box.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "特性";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SeedBox);
            this.groupBox2.Controls.Add(this.PIDBox);
            this.groupBox2.Controls.Add(this.ReverseCheck_BTN);
            this.groupBox2.Controls.Add(this.GetSeedForMaxLair_BTN);
            this.groupBox2.Controls.Add(this.Legal_Check_BOX5);
            this.groupBox2.Controls.Add(this.Legal_Check_BOX4);
            this.groupBox2.Controls.Add(this.Legal_Check_BOX3);
            this.groupBox2.Controls.Add(this.Legal_Check_BOX2);
            this.groupBox2.Controls.Add(this.Legal_Check_BOX1);
            this.groupBox2.Controls.Add(this.Seed_Box);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Ability_Box);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Gender_Box);
            this.groupBox2.Controls.Add(this.MinIV_Box);
            this.groupBox2.Controls.Add(this.Check_BTN);
            this.groupBox2.Location = new System.Drawing.Point(337, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 242);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检测(Raid/大冒险)";
            // 
            // PIDBox
            // 
            this.PIDBox.Location = new System.Drawing.Point(6, 210);
            this.PIDBox.Name = "PIDBox";
            this.PIDBox.Size = new System.Drawing.Size(96, 21);
            this.PIDBox.TabIndex = 37;
            // 
            // ReverseCheck_BTN
            // 
            this.ReverseCheck_BTN.Location = new System.Drawing.Point(210, 208);
            this.ReverseCheck_BTN.Name = "ReverseCheck_BTN";
            this.ReverseCheck_BTN.Size = new System.Drawing.Size(66, 25);
            this.ReverseCheck_BTN.TabIndex = 25;
            this.ReverseCheck_BTN.Text = "开始查找";
            this.ReverseCheck_BTN.UseVisualStyleBackColor = true;
            this.ReverseCheck_BTN.Click += new System.EventHandler(this.ReverseCheck_BTN_Click);
            // 
            // GetSeedForMaxLair_BTN
            // 
            this.GetSeedForMaxLair_BTN.Location = new System.Drawing.Point(6, 178);
            this.GetSeedForMaxLair_BTN.Name = "GetSeedForMaxLair_BTN";
            this.GetSeedForMaxLair_BTN.Size = new System.Drawing.Size(270, 25);
            this.GetSeedForMaxLair_BTN.TabIndex = 36;
            this.GetSeedForMaxLair_BTN.Text = "为面板大冒险非闪神添加seed";
            this.GetSeedForMaxLair_BTN.UseVisualStyleBackColor = true;
            this.GetSeedForMaxLair_BTN.Click += new System.EventHandler(this.GetSeedForMaxLair_BTN_Click);
            // 
            // Legal_Check_BOX5
            // 
            this.Legal_Check_BOX5.Cursor = System.Windows.Forms.Cursors.No;
            this.Legal_Check_BOX5.Location = new System.Drawing.Point(152, 147);
            this.Legal_Check_BOX5.Multiline = true;
            this.Legal_Check_BOX5.Name = "Legal_Check_BOX5";
            this.Legal_Check_BOX5.Size = new System.Drawing.Size(124, 25);
            this.Legal_Check_BOX5.TabIndex = 35;
            this.Legal_Check_BOX5.Text = "无事可做";
            // 
            // Legal_Check_BOX4
            // 
            this.Legal_Check_BOX4.Cursor = System.Windows.Forms.Cursors.No;
            this.Legal_Check_BOX4.Location = new System.Drawing.Point(152, 116);
            this.Legal_Check_BOX4.Multiline = true;
            this.Legal_Check_BOX4.Name = "Legal_Check_BOX4";
            this.Legal_Check_BOX4.Size = new System.Drawing.Size(124, 25);
            this.Legal_Check_BOX4.TabIndex = 34;
            this.Legal_Check_BOX4.Text = "无事可做";
            // 
            // Legal_Check_BOX3
            // 
            this.Legal_Check_BOX3.Cursor = System.Windows.Forms.Cursors.No;
            this.Legal_Check_BOX3.Location = new System.Drawing.Point(152, 86);
            this.Legal_Check_BOX3.Multiline = true;
            this.Legal_Check_BOX3.Name = "Legal_Check_BOX3";
            this.Legal_Check_BOX3.Size = new System.Drawing.Size(124, 25);
            this.Legal_Check_BOX3.TabIndex = 33;
            this.Legal_Check_BOX3.Text = "无事可做";
            // 
            // Legal_Check_BOX2
            // 
            this.Legal_Check_BOX2.Cursor = System.Windows.Forms.Cursors.No;
            this.Legal_Check_BOX2.Location = new System.Drawing.Point(152, 55);
            this.Legal_Check_BOX2.Multiline = true;
            this.Legal_Check_BOX2.Name = "Legal_Check_BOX2";
            this.Legal_Check_BOX2.Size = new System.Drawing.Size(124, 25);
            this.Legal_Check_BOX2.TabIndex = 32;
            this.Legal_Check_BOX2.Text = "无事可做";
            // 
            // Legal_Check_BOX1
            // 
            this.Legal_Check_BOX1.Cursor = System.Windows.Forms.Cursors.No;
            this.Legal_Check_BOX1.Location = new System.Drawing.Point(152, 24);
            this.Legal_Check_BOX1.Multiline = true;
            this.Legal_Check_BOX1.Name = "Legal_Check_BOX1";
            this.Legal_Check_BOX1.Size = new System.Drawing.Size(124, 25);
            this.Legal_Check_BOX1.TabIndex = 31;
            this.Legal_Check_BOX1.Text = "无事可做";
            // 
            // Seed_Box
            // 
            this.Seed_Box.Location = new System.Drawing.Point(6, 24);
            this.Seed_Box.Multiline = true;
            this.Seed_Box.Name = "Seed_Box";
            this.Seed_Box.Size = new System.Drawing.Size(140, 25);
            this.Seed_Box.TabIndex = 23;
            this.Seed_Box.Text = "没有seed";
            // 
            // SeedBox
            // 
            this.SeedBox.Location = new System.Drawing.Point(108, 210);
            this.SeedBox.Name = "SeedBox";
            this.SeedBox.Size = new System.Drawing.Size(96, 21);
            this.SeedBox.TabIndex = 38;
            // 
            // RNGForm
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(634, 249);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RNGForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

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
            this.MinIV_Box.DataSource =DIV;
           
            this.MinIV_Box.SelectedIndexChanged += (_, __) =>
            {
                MinIV = int.Parse(MinIV_Box.SelectedItem.ToString());
            };
            Gender_Box.DisplayMember = "Description";
            Gender_Box.ValueMember = "Value";
            Gender_Box.DataSource = Enum.GetValues(typeof(Gender))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            this.Gender_Box.SelectedIndexChanged += (_, __) =>
            {
                G = (Gender)Enum.Parse(typeof(Gender), this.Gender_Box.SelectedValue.ToString(), false);
            };
            Ability_Box.DisplayMember = "Description";
            Ability_Box.ValueMember = "Value";
            Ability_Box.DataSource = Enum.GetValues(typeof(Ability))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            this.Ability_Box.SelectedIndexChanged += (_, __) =>
            {
                A = (Ability)Enum.Parse(typeof(Ability), this.Ability_Box.SelectedValue.ToString(), false);
            };
            Ability_Box.SelectedIndex = 0;
        }
        private bool GenPkm(ref PKM pk,uint seed,byte form=0)
        {
            return ConditionForm.rules.Method switch
            {
                PkmCondition.MethodType.None=>NoMethod.GenPkm(ref pk, ConditionForm.rules),
                PkmCondition.MethodType.Method1 => Method1RNG.GenPkm(ref pk, seed, ConditionForm.rules),
                PkmCondition.MethodType.Method1_Unown=> UnownRNG.GenPkm(ref pk,1, seed, ConditionForm.rules, form),
                PkmCondition.MethodType.Method2 => Method2RNG.GenPkm(ref pk, seed, ConditionForm.rules),
                PkmCondition.MethodType.Method2_Unown => UnownRNG.GenPkm(ref pk, 2, seed, ConditionForm.rules, form),
                PkmCondition.MethodType.Method3=>Method3RNG.GenPkm(ref pk, seed, ConditionForm.rules),
                PkmCondition.MethodType.Method3_Unown => UnownRNG.GenPkm(ref pk, 3, seed, ConditionForm.rules, form),
                PkmCondition.MethodType.Method4 => Method4RNG.GenPkm(ref pk, seed, ConditionForm.rules),
                PkmCondition.MethodType.Method4_Unown => UnownRNG.GenPkm(ref pk, 4, seed, ConditionForm.rules, form),
                PkmCondition.MethodType.XDColo => XDColoRNG.GenPkm(ref pk, seed, ConditionForm.rules),
                PkmCondition.MethodType.Overworld8 => Overworld8RNG.GenPkm(ref pk, seed, ConditionForm.rules),
                PkmCondition.MethodType.Roaming8b => Roaming8bRNG.GenPkm(ref pk, seed,  ConditionForm.rules),
                PkmCondition.MethodType.BACD_R => BACD.GenPkm(ref pk, seed & 0xFFFF, ConditionForm.rules,0),
                PkmCondition.MethodType.BACD_U => BACD.GenPkm(ref pk, seed , ConditionForm.rules,1),
                PkmCondition.MethodType.BACD_R_S => BACD.GenPkm(ref pk, seed & 0xFFFF, ConditionForm.rules, 2),
                PkmCondition.MethodType.Method1Roaming => Method1Roaming.GenPkm(ref pk, seed, ConditionForm.rules),
                PkmCondition.MethodType.Colo => ColoRNG.GenPkm(ref pk, seed, ConditionForm.rules),
                PkmCondition.MethodType.E_Reader => E_Reader.GenPkm(ref pk, seed, ConditionForm.rules),
                PkmCondition.MethodType.ChainShiny => ChainShiny.GenPkm(ref pk, seed, ConditionForm.rules),
                _ => throw new NotSupportedException(),
            };
        }
        private uint NextSeed(uint seed)
        {
            return ConditionForm.rules.Method switch
            {
                PkmCondition.MethodType.Method1 => Method1RNG.Next(seed),
                PkmCondition.MethodType.Method1_Unown=> UnownRNG.Next(seed),
                PkmCondition.MethodType.Method2 => Method2RNG.Next(seed),
                PkmCondition.MethodType.Method2_Unown => UnownRNG.Next(seed),
                PkmCondition.MethodType.Method3 => Method3RNG.Next(seed),
                PkmCondition.MethodType.Method3_Unown => UnownRNG.Next(seed),
                PkmCondition.MethodType.Method4 => Method4RNG.Next(seed),
                PkmCondition.MethodType.Method4_Unown => UnownRNG.Next(seed),
                PkmCondition.MethodType.XDColo => XDColoRNG.Next(seed),
                PkmCondition.MethodType.Overworld8 => Overworld8RNG.Next(seed),
                PkmCondition.MethodType.Roaming8b => Roaming8bRNG.Next(seed),
                PkmCondition.MethodType.BACD_R => BACD.Next(seed),
                PkmCondition.MethodType.BACD_U => BACD.Next(seed),
                PkmCondition.MethodType.BACD_R_S => BACD.Next(seed),
                PkmCondition.MethodType.Method1Roaming => Method1Roaming.Next(seed),
                PkmCondition.MethodType.Colo => ColoRNG.Next(seed),
                PkmCondition.MethodType.E_Reader =>E_Reader.Next(seed),
               PkmCondition.MethodType.ChainShiny => ChainShiny.Next(seed),
                _ => throw new NotSupportedException(),
            };
        }
        private void GeneratorIsRunning(bool running)
        {
            Search.Enabled = !running;
            Cancel.Enabled = running;
        }
        private void CheckerIsRunning(bool running)
        {
            Check_BTN.Enabled = !running;
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
            tokenSource1 = new();
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
                        if (tokenSource1.IsCancellationRequested)
                        {
                            ConditionForm.ConditionBox.Text = "Stop";
                            return;
                        }

                        if (SeedList.Count != 0&&i<= SeedList.Count)
                        {
                            seed = SeedList[i];
                            i++;
                     
                        }
                        if (TeamLockBox.Checked==true)
                        {
                            if (LockCheck.ChooseLock(pk.Species, p, ref seed)==false)
                            {
                                cloneseed = NextSeed(cloneseed);
                                seed = cloneseed;
                                continue;
                            }
                        }
                        if (GenPkm(ref pk, seed,p.Form))
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
                tokenSource1.Token);
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            tokenSource1.Cancel();
            GeneratorIsRunning(false);
        }
        private void Check_BTN_Click(object sender, EventArgs e)
        {
        string T = "";
        CheckerIsRunning(true);
        Legal_Check_BOX1.Text = "正在检测基本合法性";
        Legal_Check_BOX2.Text = "正在反推Seed";
        Legal_Check_BOX3.Text = "正在检测PID/EC/IV";
        Legal_Check_BOX4.Text = "正在检测特性，性别";
        Legal_Check_BOX5.Text = "正在检测身高体重";
        tokenSource2 = new();
        var la = new LegalityAnalysis(Editor.Data);
        Task.Factory.StartNew(
            () =>
            {
                uint ec = Editor.Data.EncryptionConstant;
                uint pid = Editor.Data.PID;
                int[] ivs = { Editor.Data.IV_HP, Editor.Data.IV_ATK, Editor.Data.IV_DEF, Editor.Data.IV_SPA, Editor.Data.IV_SPD, Editor.Data.IV_SPE };
                var seeds = Z3Search.GetSeeds(ec, pid, ivs);
                #region
                /*  if (la.Valid == true && Strong_Box.Checked==true)
                    {
                        Legal_Check_BOX1.Text = "基本合法性检测通过！";
                        Legal_Check_BOX1.BackColor = Color.Green;
                        var t = la.EncounterOriginal;
                        int r = t.Location;
                        if (r is 162 or 244)
                        {
                            P(pid, ivs, ec);
                        }
                    }*/
                #endregion//枚举
                if (la.Valid == true)
                {
                    Legal_Check_BOX1.Text = "合法性检测通过！";
                    Legal_Check_BOX1.BackColor = Color.Green;
                    var t=la.EncounterOriginal;
                    int r=t.Location;
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
                            T = Gen8DenMax.Raidfinder(Seed_Box.Text, Editor.Data, MinIV, A, G);
                            var S = T.Split('\n');
                            if(S.Count()!=0)
                            {
                                Legal_Check_BOX3.Text = S[0];
                                if (S[1]=="Green")
                                    Legal_Check_BOX3.BackColor = Color.Green;
                                else if (S[1]=="Orange")
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
                {
                    CheckerIsRunning(false);
                });
            },
            tokenSource2.Token);
        }
        private void GetSeedForMaxLair_BTN_Click(object sender, EventArgs e)
        {
            var pk=Editor.Data;
            var encounters = EncounterMovesetGenerator.GenerateEncounters(pk,SAV.SAV, pk.Moves);
            foreach (var enc in encounters)
            {
                if (pk.Generation == 8 && pk.Met_Location== 244)
                {
                    FindNestPIDIV.PreSetPIDIV(pk, enc);
                    break;
                }
            }
            Editor.PopulateFields(pk);
        }

        private void ReverseCheck_BTN_Click(object sender, EventArgs e)
        {
            Span<uint> Seeds= stackalloc uint[10];
            var HEX = "0x" + PIDBox.Text;
            var PID = Convert.ToUInt32(HEX, 16);
            XDRNGReversal.GetSeeds(Seeds,PID);
            if (Seeds.Length != 0)
            {
                for (int i = 0; i < Seeds.Length; i++)
                {
                    MessageBox.Show($"{Seeds[i]:X}");
                }
            }
        }
        #region
        /*    public void P(uint pid,int[] ivs,uint ec)
            {
                var pidH = pid >> 16;
                uint pidR = 0;

                ParallelOptions po = new ParallelOptions();
                po.MaxDegreeOfParallelism = 2;
                po.CancellationToken = cts.Token;
                CTRIsRunning(true);
                Task.Factory.StartNew(
                  () =>
                  {
                      ParallelLoopResult result = Parallel.For(0, 0xffff, po, (i, state) =>
                    {
                        pidR = pidH << 16 | (uint)i;
                        var seeds = Z3Search.GetSeeds(ec, pidR, ivs);
                        if (FindFirstSeed(seeds, ivs) != "没找到Seed")
                        {
                            MessageBox.Show($"{pidR:X2}");
                            Legal_Check_BOX2.Text = "逆推成功!";
                            Legal_Check_BOX2.BackColor = Color.Green;
                            Seed_Box.Text = FindFirstSeed(seeds, ivs);
                            Raidfinder(FindFirstSeed(seeds, ivs));
                            state.Stop();
                        }
                    });
                  });

            }


            private void Stop_Check_BTN_Click(object sender, EventArgs e)
            {
                cts.Cancel();
                Legal_Check_BOX1.Text = "无事可做";
                Legal_Check_BOX1.BackColor = Color.White;
                Legal_Check_BOX2.Text = "无事可做";
                Legal_Check_BOX2.BackColor = Color.White;
                Legal_Check_BOX3.Text = "无事可做";
                Legal_Check_BOX3.BackColor = Color.White;
                Legal_Check_BOX4.Text = "无事可做";
                Legal_Check_BOX4.BackColor = Color.White;
                Legal_Check_BOX5.Text = "无事可做";
                Legal_Check_BOX5.BackColor = Color.White;
                CTRIsRunning(false);
            }
        */
        #endregion
        //枚举
    }
}
