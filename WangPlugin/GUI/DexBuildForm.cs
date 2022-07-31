using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using PKHeX.Core;
using PKHeX.Core.AutoMod;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using WangPlugin.SortBase;
using PKHeX.Core.Searching;

namespace WangPlugin.GUI
{
    internal class DexBuildForm : Form
    {
        private Button BuildDex_BTN;
        private Button Gen_BTN;
        private TextBox TIDBox;
        private TextBox SIDBox;
        private ComboBox LanguageBox;
        private TextBox OT_Name;
        private ComboBox GenderBox;
        private Label TIDLabel;
        private Label SIDLabel;
        private Label OTLabel;
        private Label LGLabel;
        private Button LivingDex_BTN;
        private ComboBox SortBox;
        private Button Legal_BTN;
        private Button LegalAll_BTN;
        private Button ClearAll_BTN;
        private Button RandomPID_BTN;
        private Button Sort_BTN;
        private Button DeleteBox_BTN;
        private Button Clone_BTN;
        private static Random rand = new Random();
        public static Stopwatch sw = new();
        private Sort version = Sort.National;
        private LanguageBoxSelect7 type7 = LanguageBoxSelect7.ENG;
        private LanguageBoxSelect type = LanguageBoxSelect.ENG;
        private Button GODex_BTN;
        private OT_Gender typeG = OT_Gender.Male;
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        enum LanguageBoxSelect
        {
            JPN,
            ENG,
            FRE,
            ITA,
            GRE,
            ESP,
        }
        enum LanguageBoxSelect7
        {
            JPN,
            ENG,
            FRE,
            ITA,
            GRE,
            ESP,
            KOR,
            CHS,
            CHT,
        }
        enum OT_Gender
        {
            Male,
            Female,
        }
        enum Sort
        {
            [Description("按照全国图鉴顺序")]
            National,
            [Description("Gen 1 关东图鉴（蓝，绿，红，黄）顺序")]
            RYBG,
            [Description("Gen 2 城都图鉴（金，银，水晶）顺序")]
            GS,
            [Description("Gen 3 丰缘图鉴（红，绿，蓝宝石）顺序")]
            E,
            [Description("Gen 3 关东图鉴（火红，叶绿）顺序")]
            FRGL,
            [Description("Gen 4 神奥图鉴（钻石，珍珠）顺序")]
            DP,
            [Description("Gen 4 神奥图鉴（白金）顺序")]
            Platinum,
            [Description("Gen 4 城都图鉴（心金，魂银）顺序")]
            GHSS,
            [Description("Gen 5 合众图鉴（黑，白）顺序")]
            BW,
            [Description("Gen 5 合众图鉴（黑2，白2）顺序")]
            B2W2,
            [Description("Gen 6 卡洛斯图鉴（X，Y）顺序")]
            XY,
            [Description("Gen 6 丰缘图鉴（始源红宝石，蓝宝石）顺序")]
            ORAS,
            [Description("Gen 7 阿罗拉图鉴（日，月）顺序")]
            SM,
            [Description("Gen 7 阿罗拉图鉴（究极日，月）顺序")]
            USUM,
            [Description("Gen 7 关东图鉴（去皮，去伊）顺序")]
            LPLE,
            [Description("Gen 8 伽勒尔图鉴（剑，盾）顺序")]
            SWSH,
            [Description("Gen 8 伽勒尔铠岛图鉴（剑盾DLC1）顺序")]
            SWSH1,
            [Description("Gen 8 伽勒尔冰冠图鉴（剑盾DLC2）顺序")]
            SWSH2,
            [Description("Gen 8 伽勒尔完整图鉴顺序")]
            SWSH3,
            [Description("Gen 8 神奥图鉴（明亮珍珠，晶灿钻石）顺序")]
            BDSP,
            [Description("Gen 8 洗翠图鉴（传说阿尔宙斯）顺序")]
            PLA,    
         }
        public DexBuildForm(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            BindingData(SAV);
        }
        private void BindingData(ISaveFileProvider sav)
        {
            if (sav.SAV.Version is GameVersion.SN or GameVersion.MN or GameVersion.US or GameVersion.UM or
                GameVersion.GP or GameVersion.GE or GameVersion.SW or GameVersion.SH or GameVersion.PLA or GameVersion.BD or GameVersion.SP)
            {
                this.LanguageBox.DataSource = Enum.GetNames(typeof(LanguageBoxSelect7));
                this.GenderBox.DataSource = Enum.GetNames(typeof(OT_Gender));
                this.LanguageBox.SelectedIndexChanged += (_, __) =>
                {
                    type7 = (LanguageBoxSelect7)Enum.Parse(typeof(LanguageBoxSelect7), this.LanguageBox.SelectedItem.ToString(), false);
                };
            }
            else
            {
                this.LanguageBox.DataSource = Enum.GetNames(typeof(LanguageBoxSelect));
                this.GenderBox.DataSource = Enum.GetNames(typeof(OT_Gender));
                this.LanguageBox.SelectedIndexChanged += (_, __) =>
                {
                    type = (LanguageBoxSelect)Enum.Parse(typeof(LanguageBoxSelect), this.LanguageBox.SelectedItem.ToString(), false);
                };
                
            }
            this.GenderBox.SelectedIndexChanged += (_, __) =>
            {
                typeG = (OT_Gender)Enum.Parse(typeof(OT_Gender), this.GenderBox.SelectedItem.ToString(), false);
            };
            this.LanguageBox.SelectedIndex = 0;
            this.GenderBox.SelectedIndex = 0;
            this.SortBox.DisplayMember = "Description";
            this.SortBox.ValueMember = "Value";
            this.SortBox.DataSource = Enum.GetValues(typeof(Sort))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
           
            this.SortBox.SelectedIndexChanged += (_, __) =>
            {
                version = (Sort)Enum.Parse(typeof(Sort), this.SortBox.SelectedValue.ToString(), false);
            };
            this.SortBox.SelectedIndex = 0;
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DexBuildForm));
            this.BuildDex_BTN = new System.Windows.Forms.Button();
            this.Gen_BTN = new System.Windows.Forms.Button();
            this.TIDBox = new System.Windows.Forms.TextBox();
            this.SIDBox = new System.Windows.Forms.TextBox();
            this.OT_Name = new System.Windows.Forms.TextBox();
            this.LanguageBox = new System.Windows.Forms.ComboBox();
            this.GenderBox = new System.Windows.Forms.ComboBox();
            this.TIDLabel = new System.Windows.Forms.Label();
            this.SIDLabel = new System.Windows.Forms.Label();
            this.OTLabel = new System.Windows.Forms.Label();
            this.LGLabel = new System.Windows.Forms.Label();
            this.LivingDex_BTN = new System.Windows.Forms.Button();
            this.SortBox = new System.Windows.Forms.ComboBox();
            this.Legal_BTN = new System.Windows.Forms.Button();
            this.LegalAll_BTN = new System.Windows.Forms.Button();
            this.ClearAll_BTN = new System.Windows.Forms.Button();
            this.RandomPID_BTN = new System.Windows.Forms.Button();
            this.Sort_BTN = new System.Windows.Forms.Button();
            this.DeleteBox_BTN = new System.Windows.Forms.Button();
            this.Clone_BTN = new System.Windows.Forms.Button();
            this.GODex_BTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BuildDex_BTN
            // 
            this.BuildDex_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.BuildDex_BTN.Location = new System.Drawing.Point(623, 11);
            this.BuildDex_BTN.Name = "BuildDex_BTN";
            this.BuildDex_BTN.Size = new System.Drawing.Size(102, 26);
            this.BuildDex_BTN.TabIndex = 0;
            this.BuildDex_BTN.Text = "补齐图鉴";
            this.BuildDex_BTN.UseVisualStyleBackColor = true;
            this.BuildDex_BTN.Click += new System.EventHandler(this.BuildDex_BTN_Click);
            // 
            // Gen_BTN
            // 
            this.Gen_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.Gen_BTN.Location = new System.Drawing.Point(404, 12);
            this.Gen_BTN.Name = "Gen_BTN";
            this.Gen_BTN.Size = new System.Drawing.Size(102, 25);
            this.Gen_BTN.TabIndex = 1;
            this.Gen_BTN.Text = "开始覆盖ID";
            this.Gen_BTN.UseVisualStyleBackColor = true;
            this.Gen_BTN.Click += new System.EventHandler(this.Gen_BTN_Click);
            // 
            // TIDBox
            // 
            this.TIDBox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TIDBox.Location = new System.Drawing.Point(68, 12);
            this.TIDBox.Name = "TIDBox";
            this.TIDBox.Size = new System.Drawing.Size(100, 27);
            this.TIDBox.TabIndex = 2;
            this.TIDBox.Text = "10101";
            // 
            // SIDBox
            // 
            this.SIDBox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SIDBox.Location = new System.Drawing.Point(68, 45);
            this.SIDBox.Name = "SIDBox";
            this.SIDBox.Size = new System.Drawing.Size(100, 27);
            this.SIDBox.TabIndex = 3;
            this.SIDBox.Text = "01010";
            // 
            // OT_Name
            // 
            this.OT_Name.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OT_Name.Location = new System.Drawing.Point(249, 12);
            this.OT_Name.Name = "OT_Name";
            this.OT_Name.Size = new System.Drawing.Size(149, 27);
            this.OT_Name.TabIndex = 4;
            this.OT_Name.Text = "Wang";
            // 
            // LanguageBox
            // 
            this.LanguageBox.FormattingEnabled = true;
            this.LanguageBox.Location = new System.Drawing.Point(279, 43);
            this.LanguageBox.Name = "LanguageBox";
            this.LanguageBox.Size = new System.Drawing.Size(57, 25);
            this.LanguageBox.TabIndex = 5;
            // 
            // GenderBox
            // 
            this.GenderBox.FormattingEnabled = true;
            this.GenderBox.Location = new System.Drawing.Point(342, 43);
            this.GenderBox.Name = "GenderBox";
            this.GenderBox.Size = new System.Drawing.Size(56, 25);
            this.GenderBox.TabIndex = 6;
            // 
            // TIDLabel
            // 
            this.TIDLabel.AutoSize = true;
            this.TIDLabel.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TIDLabel.Location = new System.Drawing.Point(12, 13);
            this.TIDLabel.Name = "TIDLabel";
            this.TIDLabel.Size = new System.Drawing.Size(49, 20);
            this.TIDLabel.TabIndex = 7;
            this.TIDLabel.Text = "表ID";
            // 
            // SIDLabel
            // 
            this.SIDLabel.AutoSize = true;
            this.SIDLabel.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SIDLabel.Location = new System.Drawing.Point(12, 46);
            this.SIDLabel.Name = "SIDLabel";
            this.SIDLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SIDLabel.Size = new System.Drawing.Size(49, 20);
            this.SIDLabel.TabIndex = 8;
            this.SIDLabel.Text = "里ID";
            // 
            // OTLabel
            // 
            this.OTLabel.AutoSize = true;
            this.OTLabel.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OTLabel.Location = new System.Drawing.Point(174, 13);
            this.OTLabel.Name = "OTLabel";
            this.OTLabel.Size = new System.Drawing.Size(69, 20);
            this.OTLabel.TabIndex = 9;
            this.OTLabel.Text = "初训家";
            // 
            // LGLabel
            // 
            this.LGLabel.AutoSize = true;
            this.LGLabel.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LGLabel.Location = new System.Drawing.Point(174, 46);
            this.LGLabel.Name = "LGLabel";
            this.LGLabel.Size = new System.Drawing.Size(99, 20);
            this.LGLabel.TabIndex = 10;
            this.LGLabel.Text = "性别/语言";
            // 
            // LivingDex_BTN
            // 
            this.LivingDex_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.LivingDex_BTN.Location = new System.Drawing.Point(515, 12);
            this.LivingDex_BTN.Name = "LivingDex_BTN";
            this.LivingDex_BTN.Size = new System.Drawing.Size(102, 25);
            this.LivingDex_BTN.TabIndex = 11;
            this.LivingDex_BTN.Text = "生成全图鉴";
            this.LivingDex_BTN.UseVisualStyleBackColor = true;
            this.LivingDex_BTN.Click += new System.EventHandler(this.LivingDex_BTN_Click);
            // 
            // SortBox
            // 
            this.SortBox.FormattingEnabled = true;
            this.SortBox.Location = new System.Drawing.Point(17, 75);
            this.SortBox.Name = "SortBox";
            this.SortBox.Size = new System.Drawing.Size(273, 25);
            this.SortBox.TabIndex = 12;
            // 
            // Legal_BTN
            // 
            this.Legal_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.Legal_BTN.Location = new System.Drawing.Point(515, 43);
            this.Legal_BTN.Name = "Legal_BTN";
            this.Legal_BTN.Size = new System.Drawing.Size(102, 25);
            this.Legal_BTN.TabIndex = 13;
            this.Legal_BTN.Text = "合法化箱子";
            this.Legal_BTN.UseVisualStyleBackColor = true;
            this.Legal_BTN.Click += new System.EventHandler(this.Legal_BTN_Click);
            // 
            // LegalAll_BTN
            // 
            this.LegalAll_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.LegalAll_BTN.Location = new System.Drawing.Point(623, 43);
            this.LegalAll_BTN.Name = "LegalAll_BTN";
            this.LegalAll_BTN.Size = new System.Drawing.Size(102, 25);
            this.LegalAll_BTN.TabIndex = 14;
            this.LegalAll_BTN.Text = "合法化全部";
            this.LegalAll_BTN.UseVisualStyleBackColor = true;
            this.LegalAll_BTN.Click += new System.EventHandler(this.LegalAll_BTN_Click);
            // 
            // ClearAll_BTN
            // 
            this.ClearAll_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.ClearAll_BTN.Location = new System.Drawing.Point(623, 74);
            this.ClearAll_BTN.Name = "ClearAll_BTN";
            this.ClearAll_BTN.Size = new System.Drawing.Size(102, 25);
            this.ClearAll_BTN.TabIndex = 15;
            this.ClearAll_BTN.Text = "删除全部";
            this.ClearAll_BTN.UseVisualStyleBackColor = true;
            this.ClearAll_BTN.Click += new System.EventHandler(this.ClearAll_BTN_Click);
            // 
            // RandomPID_BTN
            // 
            this.RandomPID_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.RandomPID_BTN.Location = new System.Drawing.Point(404, 43);
            this.RandomPID_BTN.Name = "RandomPID_BTN";
            this.RandomPID_BTN.Size = new System.Drawing.Size(102, 25);
            this.RandomPID_BTN.TabIndex = 16;
            this.RandomPID_BTN.Text = "随机PID/EC";
            this.RandomPID_BTN.UseVisualStyleBackColor = true;
            this.RandomPID_BTN.Click += new System.EventHandler(this.RandomPID_BTN_Click);
            // 
            // Sort_BTN
            // 
            this.Sort_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.Sort_BTN.Location = new System.Drawing.Point(296, 75);
            this.Sort_BTN.Name = "Sort_BTN";
            this.Sort_BTN.Size = new System.Drawing.Size(102, 25);
            this.Sort_BTN.TabIndex = 17;
            this.Sort_BTN.Text = "开始排序";
            this.Sort_BTN.UseVisualStyleBackColor = true;
            this.Sort_BTN.Click += new System.EventHandler(this.Sort_BTN_Click);
            // 
            // DeleteBox_BTN
            // 
            this.DeleteBox_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.DeleteBox_BTN.Location = new System.Drawing.Point(515, 74);
            this.DeleteBox_BTN.Name = "DeleteBox_BTN";
            this.DeleteBox_BTN.Size = new System.Drawing.Size(102, 25);
            this.DeleteBox_BTN.TabIndex = 18;
            this.DeleteBox_BTN.Text = "删除箱子";
            this.DeleteBox_BTN.UseVisualStyleBackColor = true;
            this.DeleteBox_BTN.Click += new System.EventHandler(this.DeleteBox_BTN_Click);
            // 
            // Clone_BTN
            // 
            this.Clone_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.Clone_BTN.Location = new System.Drawing.Point(404, 75);
            this.Clone_BTN.Name = "Clone_BTN";
            this.Clone_BTN.Size = new System.Drawing.Size(102, 25);
            this.Clone_BTN.TabIndex = 19;
            this.Clone_BTN.Text = "复制编辑器";
            this.Clone_BTN.UseVisualStyleBackColor = true;
            this.Clone_BTN.Click += new System.EventHandler(this.Clone_BTN_Click);
            // 
            // GODex_BTN
            // 
            this.GODex_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.GODex_BTN.Location = new System.Drawing.Point(731, 11);
            this.GODex_BTN.Name = "GODex_BTN";
            this.GODex_BTN.Size = new System.Drawing.Size(102, 26);
            this.GODex_BTN.TabIndex = 20;
            this.GODex_BTN.Text = "生成GO图鉴";
            this.GODex_BTN.UseVisualStyleBackColor = true;
            this.GODex_BTN.Click += new System.EventHandler(this.GODex_BTN_Click);
            // 
            // DexBuildForm
            // 
            this.ClientSize = new System.Drawing.Size(837, 105);
            this.Controls.Add(this.GODex_BTN);
            this.Controls.Add(this.Clone_BTN);
            this.Controls.Add(this.DeleteBox_BTN);
            this.Controls.Add(this.Sort_BTN);
            this.Controls.Add(this.RandomPID_BTN);
            this.Controls.Add(this.ClearAll_BTN);
            this.Controls.Add(this.LegalAll_BTN);
            this.Controls.Add(this.Legal_BTN);
            this.Controls.Add(this.SortBox);
            this.Controls.Add(this.LivingDex_BTN);
            this.Controls.Add(this.LGLabel);
            this.Controls.Add(this.OTLabel);
            this.Controls.Add(this.SIDLabel);
            this.Controls.Add(this.TIDLabel);
            this.Controls.Add(this.GenderBox);
            this.Controls.Add(this.LanguageBox);
            this.Controls.Add(this.OT_Name);
            this.Controls.Add(this.SIDBox);
            this.Controls.Add(this.TIDBox);
            this.Controls.Add(this.Gen_BTN);
            this.Controls.Add(this.BuildDex_BTN);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DexBuildForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private int GetLanguageBox7()
        {
            var T = 1;
            switch (type7)
            {
                case LanguageBoxSelect7.JPN:
                    T=1;
                    break;
                case LanguageBoxSelect7.ENG:
                    T = 2;
                    break;
                case LanguageBoxSelect7.FRE:
                    T = 3;
                    break;
                case LanguageBoxSelect7.ITA:
                    T = 4;
                    break;
                case LanguageBoxSelect7.GRE:
                    T = 5;
                    break;
                case LanguageBoxSelect7.ESP:
                    T = 7;
                    break;
                case LanguageBoxSelect7.KOR:
                    T = 8;
                    break;
                case LanguageBoxSelect7.CHS:
                    T = 9;
                    break;
                case LanguageBoxSelect7.CHT:
                    T = 10;
                    break;
            }
            return T;
        }
        private int GetLanguageBox()
        {
            var T = 1;
            switch (type)
            {
                case LanguageBoxSelect.JPN:
                    T = 1;
                    break;
                case LanguageBoxSelect.ENG:
                    T = 2;
                    break;
                case LanguageBoxSelect.FRE:
                    T = 3;
                    break;
                case LanguageBoxSelect.ITA:
                    T = 4;
                    break;
                case LanguageBoxSelect.GRE:
                    T = 5;
                    break;
                case LanguageBoxSelect.ESP:
                    T = 7;
                    break;
            }
            return T;
        }
        private int GetGender()
        {
            var T = 0;
            switch (typeG)
            {
                case OT_Gender.Male:
                    T = 0;
                    break;
                case OT_Gender.Female:
                    T = 1;
                    break;
            }
            return T;
        }
        public void Gen(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.ModifyBoxes(SetID);
            SaveFileEditor.ReloadSlots();
        }
        public void SetID(PKM pkm)
        {
            var TID = Int32.Parse(TIDBox.Text);
            var SID = Int32.Parse(SIDBox.Text);
            var Name = OT_Name.Text;
            
            if (SAV.SAV.Version is GameVersion.SN or GameVersion.MN or GameVersion.US or GameVersion.UM or
                 GameVersion.GP or GameVersion.GE or GameVersion.SW or GameVersion.SH or GameVersion.PLA or GameVersion.BD or GameVersion.SP)
                pkm.Language=GetLanguageBox7();
            else
                pkm.Language = GetLanguageBox();
            pkm.OT_Name = Name;
            if (SAV.SAV.Version is GameVersion.SN or GameVersion.MN or GameVersion.US or GameVersion.UM or
               GameVersion.GP or GameVersion.GE or GameVersion.SW or GameVersion.SH or GameVersion.PLA or GameVersion.BD or GameVersion.SP)
            {
                pkm.TrainerID7 = TID;
                pkm.TrainerSID7 = SID;
            }
            else
            {
                pkm.TID = TID;
                pkm.SID = SID;
                
            }
            pkm.OT_Gender = GetGender();
            pkm.ClearNickname();
        }
        public void UnionPKM(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            var a = sav.GetAllPKM();
            var pkms = sav.GenerateLivingDex(out int attempts).ToList();
            foreach (var item in a)
            {
                var pk=pkms.Find(x => x.Species==item.Species);
                pkms.Remove(pk);
            }
            var o = a.Union(pkms);
            o=o.OrderBySpecies();
            var bd = sav.BoxData;
            o.CopyTo(bd);
            sav.BoxData = bd;
            SaveFileEditor.ReloadSlots();
        }
        public void LivingDex(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            var pkms = sav.GenerateLivingDex(out int attempts);
            var bd = sav.BoxData;
            pkms.CopyTo(bd);
            sav.BoxData = bd;
            SaveFileEditor.ReloadSlots();
        }
        public static void LegalBox(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.LegalizeBox(sav.CurrentBox);
        }
        public static void LegalAll(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.LegalizeBoxes();
        }
        public static void ClearPKM(PKM pkm)
        {
            pkm.Species = 0;
        }
        public static void RandomPKM(PKM pkm)
        {
            pkm.PID=Util.Rand32();
            if (pkm.Generation >= 6)
            {
                pkm.SetRandomEC();
            }
        }
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
        private void SortByRegionalDex(Func<PKM, IComparable>[] sortFunctions)
        {
            IEnumerable<PKM> sortMethod(IEnumerable<PKM> pkms, int i) => pkms.OrderByCustom(sortFunctions);
            SAV.SAV.SortBoxes(0, -1, sortMethod);
            SAV.ReloadSlots();
        }
        private void SortByNationalDex()
        {
            SAV.SAV.SortBoxes();
            SAV.ReloadSlots();
        }
        public void SetPkm(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            List<PKM> PKL = new();
            for (int i = 0; i < 30; i++)
            {
                var pk = GetPkm(Editor.Data);
                pk.Language = Editor.Data.Language;
                pk.ClearNickname();
                pk.OT_Name = RandomString(6);
                pk.TID = rand.Next(65535);
                pk.SID = rand.Next(65535);
                PKL.Add(pk);
            }
            if (PKL.Count != 0)
                sav.SetBoxData(PKL, sav.CurrentBox);
            SaveFileEditor.ReloadSlots();
        }
        public PKM GetPkm(PKM pk)
        {
            List<IEncounterInfo> Results;
            IEncounterInfo enc;
            var setting = new SearchSettings
            {
                Species = pk.Species,
                SearchEgg = false,
                Version = (int)SAV.SAV.Version,

            };
            var search = EncounterUtil.SearchDatabase(setting, SAV.SAV);
            var results = search.ToList();
            if (results.Count != 0)
            {
                Results = results;
                enc = Results[0];
                var criteria = EncounterUtil.GetCriteria(enc, pk);
                pk = enc.ConvertToPKM(SAV.SAV, criteria);
            }
            return pk;
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }
        private void Gen_BTN_Click(object sender, EventArgs e)
        {
            Gen(SAV);
            MessageBox.Show("搞定了！");
        }
        private void BuildDex_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            UnionPKM(SAV);
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
            sw.Reset();
        }
        private void LivingDex_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            LivingDex(SAV);
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
            sw.Reset();
        }
        private void Legal_BTN_Click(object sender, EventArgs e)
        {
            LegalBox(SAV);
            SAV.ReloadSlots();
            MessageBox.Show("搞定啦");
        }
        private void LegalAll_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            LegalAll(SAV);
            SAV.ReloadSlots();
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
            sw.Reset();
        }
        private void ClearAll_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(ClearPKM);
            SAV.ReloadSlots();
        }
        private void RandomPID_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(RandomPKM);
            SAV.ReloadSlots();
        }
        private void Sort_BTN_Click(object sender, EventArgs e)
        {
            switch (version)
            {
                case Sort.National:
                    {
                        SortByNationalDex();
                        break;
                    }
                case Sort.RYBG:
                    {
                        SortByRegionalDex(Gen1_Kanto.GetSortFunctions());
                        break;
                    }
                case Sort.GS:
                    {
                        SortByRegionalDex(Gen2_Johto.GetSortFunctions());
                        break;
                    }
                case Sort.E:
                    {
                        SortByRegionalDex(Gen3_Hoenn.GetSortFunctions());
                        break;
                    }
                case Sort.FRGL:
                    {
                        SortByRegionalDex(Gen3_Kanto.GetSortFunctions());
                        break;
                    }
                case Sort.DP:
                    {
                        SortByRegionalDex(Gen4_Sinnoh.GetDPSortFunctions());
                        break;
                    }
                case Sort.Platinum:
                    {
                        SortByRegionalDex(Gen4_Sinnoh.GetPtSortFunctions());
                        break;
                    }
                case Sort.GHSS:
                    {
                        SortByRegionalDex(Gen4_Johto.GetSortFunctions());
                        break;
                    }
                case Sort.BW:
                    {
                        SortByRegionalDex(Gen5_Unova.GetBWSortFunctions());
                        break;
                    }
                case Sort.B2W2:
                    {
                        SortByRegionalDex(Gen5_Unova.GetB2W2SortFunctions());
                        break;
                    }
                case Sort.XY:
                    {
                        SortByRegionalDex(Gen6_Kalos.GetSortFunctions());
                        break;
                    }
                case Sort.ORAS:
                    {
                        SortByRegionalDex(Gen6_Hoenn.GetSortFunctions());
                        break;
                    }
                case Sort.SM:
                    {
                        SortByRegionalDex(Gen7_Alola.GetFullSMSortFunctions());
                        break;
                    }
                case Sort.USUM:
                    {
                        SortByRegionalDex(Gen7_Alola.GetFullUSUMSortFunctions());
                        break;
                    }
                case Sort.LPLE:
                    {
                        SortByRegionalDex(Gen7_Kanto.GetSortFunctions());
                        break;
                    }
                case Sort.SWSH:
                    {
                        SortByRegionalDex(Gen8_Galar.GetGalarDexSortFunctions());
                        break;
                    }
                case Sort.SWSH1:
                    {
                        SortByRegionalDex(Gen8_Galar.GetIoADexSortFunctions());
                        break;
                    }
                case Sort.SWSH2:
                    {
                        SortByRegionalDex(Gen8_Galar.GetCTDexSortFunction());
                        break;
                    }
                case Sort.SWSH3:
                    {
                        SortByRegionalDex(Gen8_Galar.GetFullGalarDexSortFunctions());
                        break;
                    }
                case Sort.BDSP:
                    {
                        SortByRegionalDex(Gen8_Sinnoh.GetSortFunctions());
                        break;
                    }
                case Sort.PLA:
                    {
                        SortByRegionalDex(Gen8_Hisui.GetSortFunctions());
                        break;
                    }




            }
            MessageBox.Show("顺序完成", "SuperWang");
        }
        private void DeleteBox_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(ClearPKM,SAV.CurrentBox,SAV.CurrentBox);
            SAV.ReloadSlots();
        }
        private void Clone_BTN_Click(object sender, EventArgs e)
        {
            SetPkm(SAV);
        }

        private void GODex_BTN_Click(object sender, EventArgs e)
        {
            GODex(SAV);
        }
        private void GODex(ISaveFileProvider SaveFileEditor)
        {
            List<IEncounterInfo> Results;
            IEncounterInfo enc;
            PKM pk ;
            int j;
            List<PKM> pkMList;
            List<PKM> p=new();
            pkMList = (List<PKM>)SaveFileEditor.SAV.GetAllPKM();
            MessageBox.Show($"{pkMList.Count()}");
            for (int i = 0; i < pkMList.Count(); i++)
            {
                pk = pkMList[i];
                var pkc = pk.Clone();
                j = pk.Species;
                var setting = new SearchSettings
                {
                    Species = pk.Species,
                    SearchEgg = false,
                    Version = 34,
                };
                var search = EncounterUtil.SearchDatabase(setting, SaveFileEditor.SAV);
                var results = search.ToList();
               // MessageBox.Show($"{results.Count}");

                if (results.Count != 0)
                {
                    Results = results;
                    enc = Results[0];
                    var criteria = EncounterUtil.GetCriteria(enc, pk);
                    EntityConverter.TryMakePKMCompatible(enc.ConvertToPKM(SaveFileEditor.SAV, criteria), pk, out var c, out pk);
                    pk.Species = j;
                    pk.ClearNickname();
                    pk.Ability = pkc.Ability;
                    pk.OT_Name = RandomString(6);
                    pk.SetSuggestedMoves();
                    if( pk.Move1 != 0)
                        pk.SetSuggestedMovePP(0);
                    if (pk.Move2 != 0)
                        pk.SetSuggestedMovePP(1);
                    if (pk.Move3 != 0)
                        pk.SetSuggestedMovePP(2);
                    if (pk.Move4 != 0)
                        pk.SetSuggestedMovePP(3);
                    pk.RefreshChecksum();
                    p.Add(pk);
                }
                else
                    p.Add(pkc);
            }
            for (int i = 0; i < SaveFileEditor.SAV.BoxCount; i++)
            {
                for (j = 0; j < 30; j++)
                {
                    if (pkMList.Count >(i * 30 + j))
                        SaveFileEditor.SAV.SetBoxSlotAtIndex(p[i * 30 + j], i, j);
                    else
                        break;
                }
            }
            SaveFileEditor.ReloadSlots();
        }
        
    }
}
