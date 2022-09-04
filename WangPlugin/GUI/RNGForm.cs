using PKHeX.Core;
using System;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
namespace WangPlugin.GUI
{
    internal class RNGForm : Form
    {
        private ComboBox methodTypeBox;
        private Button Search;
        private CancellationTokenSource tokenSource1 = new();
        private CancellationTokenSource tokenSource2 = new();
        private TextBox Condition;
        private Button Cancel;
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        enum MethodType
        {
            None,
            Method1,
            H1_BACD_R,
            Method1Roaming,
            Method2,
            Method4,
            ChainShiny,
            XDColo,
            Colo,
            Overworld8,
            Roaming8b,
        }
        enum ShinyType
        {
            None,
            Shiny,
            Star,
            Sqaure,
            ForceStar,
        }
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
        private MethodType RNGMethod = MethodType.None;
        private ComboBox ShinyTypeBox;
        private Label ShinyTypeLabel;
        private TextBox SeedText;
        private CheckBox AtkCheck;
        private CheckBox SpeCheck;
        private CheckBox VCheck;
        private CheckBox LockIV;
        private Label label1;
        private CheckBox SpaCheck;
        private CheckBox UsePreSeed;
        private Button Check_BTN;
        private GroupBox groupBox1;
        private ComboBox MinIV_Box;
        private ShinyType Stype = ShinyType.None;
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
            this.methodTypeBox = new System.Windows.Forms.ComboBox();
            this.Search = new System.Windows.Forms.Button();
            this.Condition = new System.Windows.Forms.TextBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.ShinyTypeBox = new System.Windows.Forms.ComboBox();
            this.ShinyTypeLabel = new System.Windows.Forms.Label();
            this.SeedText = new System.Windows.Forms.TextBox();
            this.AtkCheck = new System.Windows.Forms.CheckBox();
            this.SpeCheck = new System.Windows.Forms.CheckBox();
            this.VCheck = new System.Windows.Forms.CheckBox();
            this.LockIV = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SpaCheck = new System.Windows.Forms.CheckBox();
            this.UsePreSeed = new System.Windows.Forms.CheckBox();
            this.Check_BTN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MinIV_Box = new System.Windows.Forms.ComboBox();
            this.Gender_Box = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Ability_Box = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Legal_Check_BOX5 = new System.Windows.Forms.TextBox();
            this.Legal_Check_BOX4 = new System.Windows.Forms.TextBox();
            this.Legal_Check_BOX3 = new System.Windows.Forms.TextBox();
            this.Legal_Check_BOX2 = new System.Windows.Forms.TextBox();
            this.Legal_Check_BOX1 = new System.Windows.Forms.TextBox();
            this.Seed_Box = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // methodTypeBox
            // 
            this.methodTypeBox.FormattingEnabled = true;
            this.methodTypeBox.Location = new System.Drawing.Point(86, 24);
            this.methodTypeBox.Name = "methodTypeBox";
            this.methodTypeBox.Size = new System.Drawing.Size(124, 25);
            this.methodTypeBox.TabIndex = 8;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(53, 146);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(124, 25);
            this.Search.TabIndex = 9;
            this.Search.Text = "开始查找";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Condition
            // 
            this.Condition.Cursor = System.Windows.Forms.Cursors.No;
            this.Condition.Location = new System.Drawing.Point(216, 24);
            this.Condition.Name = "Condition";
            this.Condition.Size = new System.Drawing.Size(124, 25);
            this.Condition.TabIndex = 10;
            this.Condition.Text = "无事可做";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(183, 146);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(124, 25);
            this.Cancel.TabIndex = 11;
            this.Cancel.Text = "停止查找";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // ShinyTypeBox
            // 
            this.ShinyTypeBox.FormattingEnabled = true;
            this.ShinyTypeBox.Location = new System.Drawing.Point(86, 57);
            this.ShinyTypeBox.Name = "ShinyTypeBox";
            this.ShinyTypeBox.Size = new System.Drawing.Size(124, 25);
            this.ShinyTypeBox.TabIndex = 13;
            // 
            // ShinyTypeLabel
            // 
            this.ShinyTypeLabel.AutoSize = true;
            this.ShinyTypeLabel.Location = new System.Drawing.Point(8, 60);
            this.ShinyTypeLabel.Name = "ShinyTypeLabel";
            this.ShinyTypeLabel.Size = new System.Drawing.Size(72, 17);
            this.ShinyTypeLabel.TabIndex = 14;
            this.ShinyTypeLabel.Text = "闪光种类";
            // 
            // SeedText
            // 
            this.SeedText.Cursor = System.Windows.Forms.Cursors.No;
            this.SeedText.Location = new System.Drawing.Point(216, 57);
            this.SeedText.Name = "SeedText";
            this.SeedText.Size = new System.Drawing.Size(124, 25);
            this.SeedText.TabIndex = 15;
            this.SeedText.Text = "没有seed";
            // 
            // AtkCheck
            // 
            this.AtkCheck.AutoSize = true;
            this.AtkCheck.Location = new System.Drawing.Point(9, 93);
            this.AtkCheck.Name = "AtkCheck";
            this.AtkCheck.Size = new System.Drawing.Size(70, 21);
            this.AtkCheck.TabIndex = 16;
            this.AtkCheck.Text = "0物攻";
            this.AtkCheck.UseVisualStyleBackColor = true;
            // 
            // SpeCheck
            // 
            this.SpeCheck.AutoSize = true;
            this.SpeCheck.Location = new System.Drawing.Point(74, 93);
            this.SpeCheck.Name = "SpeCheck";
            this.SpeCheck.Size = new System.Drawing.Size(70, 21);
            this.SpeCheck.TabIndex = 17;
            this.SpeCheck.Text = "0速度";
            this.SpeCheck.UseVisualStyleBackColor = true;
            // 
            // VCheck
            // 
            this.VCheck.AutoSize = true;
            this.VCheck.Enabled = false;
            this.VCheck.Location = new System.Drawing.Point(225, 93);
            this.VCheck.Name = "VCheck";
            this.VCheck.Size = new System.Drawing.Size(47, 21);
            this.VCheck.TabIndex = 18;
            this.VCheck.Text = "6V";
            this.VCheck.UseVisualStyleBackColor = true;
            // 
            // LockIV
            // 
            this.LockIV.AutoSize = true;
            this.LockIV.Enabled = false;
            this.LockIV.Location = new System.Drawing.Point(268, 93);
            this.LockIV.Name = "LockIV";
            this.LockIV.Size = new System.Drawing.Size(63, 21);
            this.LockIV.TabIndex = 19;
            this.LockIV.Text = "锁3V";
            this.LockIV.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "RNG类型";
            // 
            // SpaCheck
            // 
            this.SpaCheck.AutoSize = true;
            this.SpaCheck.Location = new System.Drawing.Point(138, 93);
            this.SpaCheck.Name = "SpaCheck";
            this.SpaCheck.Size = new System.Drawing.Size(94, 21);
            this.SpaCheck.TabIndex = 21;
            this.SpaCheck.Text = "随机特攻";
            this.SpaCheck.UseVisualStyleBackColor = true;
            // 
            // UsePreSeed
            // 
            this.UsePreSeed.AutoSize = true;
            this.UsePreSeed.Location = new System.Drawing.Point(9, 120);
            this.UsePreSeed.Name = "UsePreSeed";
            this.UsePreSeed.Size = new System.Drawing.Size(126, 21);
            this.UsePreSeed.TabIndex = 22;
            this.UsePreSeed.Text = "使用预设种子";
            this.UsePreSeed.UseVisualStyleBackColor = true;
            // 
            // Check_BTN
            // 
            this.Check_BTN.Location = new System.Drawing.Point(22, 147);
            this.Check_BTN.Name = "Check_BTN";
            this.Check_BTN.Size = new System.Drawing.Size(124, 25);
            this.Check_BTN.TabIndex = 23;
            this.Check_BTN.Text = "开始检测";
            this.Check_BTN.UseVisualStyleBackColor = true;
            this.Check_BTN.Click += new System.EventHandler(this.Check_BTN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UsePreSeed);
            this.groupBox1.Controls.Add(this.SpaCheck);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LockIV);
            this.groupBox1.Controls.Add(this.VCheck);
            this.groupBox1.Controls.Add(this.SpeCheck);
            this.groupBox1.Controls.Add(this.AtkCheck);
            this.groupBox1.Controls.Add(this.SeedText);
            this.groupBox1.Controls.Add(this.ShinyTypeLabel);
            this.groupBox1.Controls.Add(this.ShinyTypeBox);
            this.groupBox1.Controls.Add(this.Cancel);
            this.groupBox1.Controls.Add(this.Condition);
            this.groupBox1.Controls.Add(this.Search);
            this.groupBox1.Controls.Add(this.methodTypeBox);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 182);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查找";
            // 
            // MinIV_Box
            // 
            this.MinIV_Box.FormattingEnabled = true;
            this.MinIV_Box.Location = new System.Drawing.Point(54, 55);
            this.MinIV_Box.Name = "MinIV_Box";
            this.MinIV_Box.Size = new System.Drawing.Size(92, 25);
            this.MinIV_Box.TabIndex = 25;
            // 
            // Gender_Box
            // 
            this.Gender_Box.FormattingEnabled = true;
            this.Gender_Box.Location = new System.Drawing.Point(67, 85);
            this.Gender_Box.Name = "Gender_Box";
            this.Gender_Box.Size = new System.Drawing.Size(79, 25);
            this.Gender_Box.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "锁IV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "公母比";
            // 
            // Ability_Box
            // 
            this.Ability_Box.FormattingEnabled = true;
            this.Ability_Box.Location = new System.Drawing.Point(54, 116);
            this.Ability_Box.Name = "Ability_Box";
            this.Ability_Box.Size = new System.Drawing.Size(92, 25);
            this.Ability_Box.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "特性";
            // 
            // groupBox2
            // 
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
            this.groupBox2.Location = new System.Drawing.Point(372, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 182);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检测(Raid/大冒险)";
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
            // RNGForm
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(675, 198);
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
            this.methodTypeBox.DataSource = Enum.GetNames(typeof(MethodType));
            this.ShinyTypeBox.DataSource = Enum.GetNames(typeof(ShinyType));
            this.MinIV_Box.DataSource =DIV;
            this.methodTypeBox.SelectedIndexChanged += (_, __) =>
            {
                if (methodTypeBox.SelectedItem == methodTypeBox.Items[9]|| 
                methodTypeBox.SelectedItem == methodTypeBox.Items[1]|| 
                methodTypeBox.SelectedItem == methodTypeBox.Items[7])
                {
                    LockIV.Enabled = true;
                    LockIV.Checked = false;
                    VCheck.Enabled = false;
                }
                else if (methodTypeBox.SelectedItem == methodTypeBox.Items[10])
                {
                    LockIV.Enabled = false;
                    LockIV.Checked = true;
                    VCheck.Enabled = true;
                    this.VCheck.CheckedChanged += (_, __) =>
                    {
                        if (VCheck.Checked == true)
                        {
                            AtkCheck.Enabled = false;
                            SpeCheck.Enabled = false;
                            AtkCheck.Checked = false;
                            SpeCheck.Checked = false;
                        }
                        else
                        {
                            AtkCheck.Enabled = true;
                            SpeCheck.Enabled = true;
                        }

                    };
                    this.AtkCheck.CheckedChanged += (_, __) =>
                    {
                        if (AtkCheck.Checked == true)
                        {
                            VCheck.Checked = false;
                            VCheck.Enabled = false;
                        }
                        else
                        {
                            VCheck.Enabled = true;
                        }
                    };
                    this.SpeCheck.CheckedChanged += (_, __) =>
                    {
                        if (SpeCheck.Checked == true)
                        {
                            VCheck.Checked = false;
                            VCheck.Enabled = false;
                        }
                        else
                        {
                            VCheck.Enabled = true;
                        }
                    };
                }
                else
                {
                    LockIV.Enabled = false;
                    LockIV.Checked = false;
                    VCheck.Enabled = false;
                }
                RNGMethod = (MethodType)Enum.Parse(typeof(MethodType), this.methodTypeBox.SelectedItem.ToString(), false);
            };        
            this.methodTypeBox.SelectedIndex = 0;
            this.ShinyTypeBox.SelectedIndexChanged += (_, __) =>
            {
                Stype = (ShinyType)Enum.Parse(typeof(ShinyType), this.ShinyTypeBox.SelectedItem.ToString(), false);
            };
            this.MinIV_Box.SelectedIndexChanged += (_, __) =>
            {
                MinIV = int.Parse(MinIV_Box.SelectedItem.ToString());
            };
            this.ShinyTypeBox.SelectedIndex = 0;

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
        private bool[] GetShinyType()
        {
            var shinytype = new bool[6] { false, false, false, false, false,false };
            switch (Stype)
            {
                case ShinyType.None:
                    shinytype[0] = true;
                    break;
                case ShinyType.Shiny:
                    shinytype[1] = true;
                    break;
                case ShinyType.Star:
                    shinytype[2] = true;
                    break;
                case ShinyType.Sqaure:
                    shinytype[3] = true;
                    break;
                case ShinyType.ForceStar:
                    shinytype[4] = true;
                    break;
            }
            return shinytype;
        }
        private bool[] CheckIV()
        {
            var IV = new bool[3] { false, false,false};
            if (AtkCheck.Checked)
                IV[0] = true;
            if (SpeCheck.Checked)
                IV[1] = true;
            if (LockIV.Checked)
            {
                IV[2] = true;
            }
            return IV;
        }
        private bool GenPkm(ref PKM pk,uint seed)
        {
            return RNGMethod switch
            {
                MethodType.None=>NoMethod.GenPkm(ref pk, GetShinyType(), CheckIV()),
                MethodType.Method1 => Method1RNG.GenPkm(ref pk, seed, GetShinyType(), CheckIV()),
                MethodType.Method2 => Method2RNG.GenPkm(ref pk, seed, GetShinyType(), CheckIV()),
                MethodType.Method4 => Method4RNG.GenPkm(ref pk, seed, GetShinyType(), CheckIV()),
                MethodType.XDColo => XDColoRNG.GenPkm(ref pk, seed, GetShinyType(), CheckIV()),
                MethodType.Overworld8 => Overworld8RNG.GenPkm(ref pk, seed, GetShinyType(), CheckIV()),
                MethodType.Roaming8b => Roaming8bRNG.GenPkm(ref pk, seed, Editor.Data.TID, Editor.Data.SID, GetShinyType(), CheckIV()),
                MethodType.H1_BACD_R => H1_BACD_R.GenPkm(ref pk, seed & 0xFFFF, Editor.Data.SID, Editor.Data.TID, GetShinyType(), CheckIV()),
                MethodType.Method1Roaming => Method1Roaming.GenPkm(ref pk, seed, GetShinyType(), CheckIV()),
                MethodType.Colo => ColoRNG.GenPkm(ref pk, seed, GetShinyType(), CheckIV()),
                MethodType.ChainShiny => ChainShiny.GenPkm(ref pk, seed, CheckIV()),
                _ => throw new NotSupportedException(),
            };
        }
        private uint NextSeed(uint seed)
        {
            return RNGMethod switch
            {
                MethodType.Method1 => Method1RNG.Next(seed),
                MethodType.Method2 => Method2RNG.Next(seed),
                MethodType.Method4 => Method4RNG.Next(seed),
                MethodType.XDColo => XDColoRNG.Next(seed),
                MethodType.Overworld8 => Overworld8RNG.Next(seed),
                MethodType.Roaming8b => Roaming8bRNG.Next(seed),
                MethodType.H1_BACD_R => H1_BACD_R.Next(seed),
                MethodType.Method1Roaming => Method1Roaming.Next(seed),
                MethodType.Colo => ColoRNG.Next(seed),
                MethodType.ChainShiny => ChainShiny.Next(seed),
                _ => throw new NotSupportedException(),
            };
        }
        private Queue<uint> PreSetSeed()
        {

            Queue<uint> Getqeueu = new Queue<uint>();
            if (RNGMethod == MethodType.Roaming8b &&
                VCheck.Checked &&
                Stype != ShinyType.None)
            {
                Getqeueu = SeedList.EnqueueSeed(1);
            }
            else if (RNGMethod == MethodType.Roaming8b&& 
                AtkCheck.Checked&&
                SpeCheck.Checked&&
                Stype!=ShinyType.None)
            {
                Getqeueu = SeedList.EnqueueSeed(2);
            }
            else if (RNGMethod == MethodType.Roaming8b &&
                AtkCheck.Checked &&
                !SpeCheck.Checked &&
                Stype != ShinyType.None)
                {
                Getqeueu = SeedList.EnqueueSeed(3);
            }
            else if(RNGMethod==MethodType.Roaming8b&&
                !AtkCheck.Checked&&
                SpeCheck.Checked &&
                (Stype != ShinyType.None&&Stype!=ShinyType.Sqaure))
            {
                Getqeueu = SeedList.EnqueueSeed(4);
            }
            else if (RNGMethod == MethodType.Overworld8 &&
               AtkCheck.Checked &&
               !SpeCheck.Checked &&
               Stype == ShinyType.Sqaure)
            {
                Getqeueu = SeedList.EnqueueSeed(5);
            }
            else if (RNGMethod == MethodType.Overworld8 &&
              !AtkCheck.Checked &&
              SpeCheck.Checked &&
              Stype == ShinyType.Sqaure)
            {
                Getqeueu = SeedList.EnqueueSeed(6);
            }
            else if (RNGMethod == MethodType.Overworld8 &&
             AtkCheck.Checked &&
             SpeCheck.Checked &&
             Stype == ShinyType.Sqaure)
            {
                Getqeueu = SeedList.EnqueueSeed(7);
            }
            else if (RNGMethod == MethodType.Overworld8 &&
             !AtkCheck.Checked &&
             !SpeCheck.Checked &&
             SpaCheck.Checked &&
             Stype == ShinyType.Sqaure)
            {
                Getqeueu = SeedList.EnqueueSeed(8);
            }
            return Getqeueu;
        }
        private void GeneratorIsRunning(bool running)
        {
            Search.Enabled = !running;
            Cancel.Enabled = running;
        }
        private void CheckerIsRunning(bool running)
        {
            Check_BTN.Enabled = !running;
          //  Stop_Check_BTN.Enabled = running;
        }
        private void Search_Click(object sender, EventArgs e)
        {
            GeneratorIsRunning(true);
            Condition.Text = "searching...";
            uint seed = 0;
            Queue<uint> SeedQueue = new Queue<uint>();
            var j = 0;
            if (UsePreSeed.Checked == true)
            {
                SeedQueue = PreSetSeed();
                MessageBox.Show($"预设种子数量:{SeedQueue.Count}");
            }
            tokenSource1 = new();
            if (UsePreSeed.Checked == true)
            {
                Random rd = new Random();
                if (SeedQueue.Count >1)
                    j = rd.Next(0, SeedQueue.Count);
                else
                    j = 1;
            }
            Task.Factory.StartNew(
                () =>
                {
                    seed = Util.Rand32();
                    var pk = Editor.Data;
                    while (true)
                    {
                        if (tokenSource1.IsCancellationRequested)
                        {
                            Condition.Text = "Stop";
                            return;
                        }
                        for (int i = 0; i < j; i++)
                        {
                            if (SeedQueue.Count != 0)
                            {
                                seed = SeedQueue.Dequeue();
                            }
                            else
                                break;
                        }
                       
                        if (GenPkm(ref pk, seed))
                            {
                           
                            this.Invoke(() =>
                                {
                                    MessageBox.Show($"Success！");
                                    Editor.PopulateFields(pk, false);
                                    SAV.ReloadSlots();
                                    SeedText.Text = $"{Convert.ToString(seed, 16)}";
                                });
                               
                                break;
                            }

               
                        seed = NextSeed(seed);
                    }
                    this.Invoke(() =>
                    {
                        GeneratorIsRunning(false);
                        Condition.Text = "Nothing to check";
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
