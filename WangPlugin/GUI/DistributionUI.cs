using System;
using System.Collections.Generic;
using System.Linq;
using PKHeX.Core.Searching;
using System.IO;
using PKHeX.Core;
using System.Windows.Forms;
using System.ComponentModel;

namespace WangPlugin.GUI
{
    internal class DistributionUI:Form
    {
        private OpenFileDialog OpenFile_Dialog;
        private TextBox BOX_TextBox;
        private Label BOX_Label;
        private Button Clone_BTN;
        private Button LoadEH1_BTN;
        private const string TrainerFilter = "Trainer Info |*.txt|All Files|*.*";
        private IVEVN V = IVEVN.ATK;
        private CLONE C = CLONE.BOX;
        private TRAINER T = TRAINER.BOX;
  
        public enum Nature
        {
            Hardy,Lonely,Brave,Adamant,Naughty,Bold,Docile,Relaxed,
            Impish,Lax,Timid,Hasty,Serious,Jolly,Naive,Modest,
            Mild,Quiet,Bashful,Rash,Calm,Gentle,Sassy,Careful,Quirky,
        }
        public enum Ball : int
        {
            None = 0,
            Master = 1,
            Ultra = 2,
            Great = 3,
            Poke = 4,
            Safari = 5,
            Net = 6,
            Dive = 7,
            Nest = 8,
            Repeat = 9,
            Timer = 10,
            Luxury = 11,
            Premier = 12,
            Dusk = 13,
            Heal = 14,
            Quick = 15,
            Cherish = 16,
            Fast = 17,
            Level = 18,
            Lure = 19,
            Heavy = 20,
            Love = 21,
            Friend = 22,
            Moon = 23,
            Sport = 24,
            Dream = 25,
            Beast = 26,
        }
        public enum IVEVN:int
        {
            [Description("物攻")]
            ATK,
            [Description("特攻")]
            SPA,
            [Description("0速物攻")]
            Z_ATK,
            [Description("0速特攻")]
            Z_SPA,
            [Description("肉盾")]
            TANK,

        }
        public enum CLONE : int
        {
            [Description("复制一箱")]
            BOX,
            [Description("竖向复制5只")]
            FIVE,
        }
        public enum TRAINER : int
        {
            [Description("覆盖一箱")]
            BOX,
            [Description("覆盖面板")]
            EDITER,
        }

        public Nature Ntype = Nature.Hardy;
        public Ball TBall = Ball.Poke;
        public Trainer Trainer;
        private CheckBox ShinyBox;
        private Button Gift_BTN;
        private CheckBox SetTrainer_Box;
        private Button AllRibbon_BTN;
        private Button LoadTrainer_BTN;
        private static Random rand = new();
        private ComboBox BallBox;
        private ComboBox Trainer_Box;
        private Button Use_Trainer_BTN;
        public int number=0;
        private CheckBox RandPID_Box;
        private Button IVEVN_BTN;
        private Button Move_Shop;
        private Button LevelMax_BTN;
        private CheckBox Ball_Box;
        private ComboBox Edit_EVIVN_Box;
        private ComboBox Clone_Select_Box;
        private ComboBox Trainer_Select_Box;
        private CheckBox Random_Trainer_Box;
        private CheckBox Random_Name_Box;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        public BindingList<Trainer> Tr=new();
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        public DistributionUI(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            BindingData();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistributionUI));
            this.LoadEH1_BTN = new System.Windows.Forms.Button();
            this.OpenFile_Dialog = new System.Windows.Forms.OpenFileDialog();
            this.BOX_TextBox = new System.Windows.Forms.TextBox();
            this.BOX_Label = new System.Windows.Forms.Label();
            this.Clone_BTN = new System.Windows.Forms.Button();
            this.ShinyBox = new System.Windows.Forms.CheckBox();
            this.Gift_BTN = new System.Windows.Forms.Button();
            this.SetTrainer_Box = new System.Windows.Forms.CheckBox();
            this.AllRibbon_BTN = new System.Windows.Forms.Button();
            this.LoadTrainer_BTN = new System.Windows.Forms.Button();
            this.BallBox = new System.Windows.Forms.ComboBox();
            this.Trainer_Box = new System.Windows.Forms.ComboBox();
            this.Use_Trainer_BTN = new System.Windows.Forms.Button();
            this.RandPID_Box = new System.Windows.Forms.CheckBox();
            this.IVEVN_BTN = new System.Windows.Forms.Button();
            this.Move_Shop = new System.Windows.Forms.Button();
            this.LevelMax_BTN = new System.Windows.Forms.Button();
            this.Ball_Box = new System.Windows.Forms.CheckBox();
            this.Edit_EVIVN_Box = new System.Windows.Forms.ComboBox();
            this.Clone_Select_Box = new System.Windows.Forms.ComboBox();
            this.Trainer_Select_Box = new System.Windows.Forms.ComboBox();
            this.Random_Trainer_Box = new System.Windows.Forms.CheckBox();
            this.Random_Name_Box = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadEH1_BTN
            // 
            this.LoadEH1_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.LoadEH1_BTN.Location = new System.Drawing.Point(151, 16);
            this.LoadEH1_BTN.Name = "LoadEH1_BTN";
            this.LoadEH1_BTN.Size = new System.Drawing.Size(100, 25);
            this.LoadEH1_BTN.TabIndex = 0;
            this.LoadEH1_BTN.Text = "读取EH1";
            this.LoadEH1_BTN.UseVisualStyleBackColor = true;
            this.LoadEH1_BTN.Click += new System.EventHandler(this.LoadEH1_BTN_Click);
            // 
            // OpenFile_Dialog
            // 
            this.OpenFile_Dialog.Filter = "PokemonHomefile (*.eh1)|*.eh1|All files (*.*)|*.*";
            this.OpenFile_Dialog.Multiselect = true;
            // 
            // BOX_TextBox
            // 
            this.BOX_TextBox.Location = new System.Drawing.Point(44, 17);
            this.BOX_TextBox.Name = "BOX_TextBox";
            this.BOX_TextBox.Size = new System.Drawing.Size(100, 25);
            this.BOX_TextBox.TabIndex = 1;
            this.BOX_TextBox.Text = "1";
            // 
            // BOX_Label
            // 
            this.BOX_Label.AutoSize = true;
            this.BOX_Label.Font = new System.Drawing.Font("黑体", 9F);
            this.BOX_Label.Location = new System.Drawing.Point(6, 21);
            this.BOX_Label.Name = "BOX_Label";
            this.BOX_Label.Size = new System.Drawing.Size(39, 15);
            this.BOX_Label.TabIndex = 2;
            this.BOX_Label.Text = "箱子";
            // 
            // Clone_BTN
            // 
            this.Clone_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.Clone_BTN.Location = new System.Drawing.Point(287, 49);
            this.Clone_BTN.Name = "Clone_BTN";
            this.Clone_BTN.Size = new System.Drawing.Size(100, 25);
            this.Clone_BTN.TabIndex = 20;
            this.Clone_BTN.Text = "开始复制";
            this.Clone_BTN.UseVisualStyleBackColor = true;
            this.Clone_BTN.Click += new System.EventHandler(this.Clone_BTN_Click);
            // 
            // ShinyBox
            // 
            this.ShinyBox.AutoSize = true;
            this.ShinyBox.Font = new System.Drawing.Font("黑体", 9F);
            this.ShinyBox.Location = new System.Drawing.Point(8, 24);
            this.ShinyBox.Name = "ShinyBox";
            this.ShinyBox.Size = new System.Drawing.Size(61, 19);
            this.ShinyBox.TabIndex = 28;
            this.ShinyBox.Text = "闪光";
            this.ShinyBox.UseVisualStyleBackColor = true;
            // 
            // Gift_BTN
            // 
            this.Gift_BTN.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Gift_BTN.Location = new System.Drawing.Point(393, 49);
            this.Gift_BTN.Name = "Gift_BTN";
            this.Gift_BTN.Size = new System.Drawing.Size(100, 25);
            this.Gift_BTN.TabIndex = 35;
            this.Gift_BTN.Text = "一箱神兽";
            this.Gift_BTN.UseVisualStyleBackColor = true;
            this.Gift_BTN.Click += new System.EventHandler(this.Gift_BTN_Click);
            // 
            // SetTrainer_Box
            // 
            this.SetTrainer_Box.AutoSize = true;
            this.SetTrainer_Box.Font = new System.Drawing.Font("黑体", 9F);
            this.SetTrainer_Box.Location = new System.Drawing.Point(72, 24);
            this.SetTrainer_Box.Name = "SetTrainer_Box";
            this.SetTrainer_Box.Size = new System.Drawing.Size(93, 19);
            this.SetTrainer_Box.TabIndex = 36;
            this.SetTrainer_Box.Text = "指定群友";
            this.SetTrainer_Box.UseVisualStyleBackColor = true;
            // 
            // AllRibbon_BTN
            // 
            this.AllRibbon_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.AllRibbon_BTN.Location = new System.Drawing.Point(130, 18);
            this.AllRibbon_BTN.Name = "AllRibbon_BTN";
            this.AllRibbon_BTN.Size = new System.Drawing.Size(100, 25);
            this.AllRibbon_BTN.TabIndex = 37;
            this.AllRibbon_BTN.Text = "全段带";
            this.AllRibbon_BTN.UseVisualStyleBackColor = true;
            this.AllRibbon_BTN.Click += new System.EventHandler(this.AllRibbon_BTN_Click);
            // 
            // LoadTrainer_BTN
            // 
            this.LoadTrainer_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.LoadTrainer_BTN.Location = new System.Drawing.Point(114, 15);
            this.LoadTrainer_BTN.Name = "LoadTrainer_BTN";
            this.LoadTrainer_BTN.Size = new System.Drawing.Size(100, 25);
            this.LoadTrainer_BTN.TabIndex = 39;
            this.LoadTrainer_BTN.Text = "导入训练家";
            this.LoadTrainer_BTN.UseVisualStyleBackColor = true;
            this.LoadTrainer_BTN.Click += new System.EventHandler(this.LoadTrainer_BTN_Click);
            // 
            // BallBox
            // 
            this.BallBox.FormattingEnabled = true;
            this.BallBox.Location = new System.Drawing.Point(8, 49);
            this.BallBox.Name = "BallBox";
            this.BallBox.Size = new System.Drawing.Size(100, 23);
            this.BallBox.TabIndex = 48;
            // 
            // Trainer_Box
            // 
            this.Trainer_Box.FormattingEnabled = true;
            this.Trainer_Box.Location = new System.Drawing.Point(8, 17);
            this.Trainer_Box.Name = "Trainer_Box";
            this.Trainer_Box.Size = new System.Drawing.Size(100, 23);
            this.Trainer_Box.TabIndex = 49;
            // 
            // Use_Trainer_BTN
            // 
            this.Use_Trainer_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.Use_Trainer_BTN.Location = new System.Drawing.Point(114, 49);
            this.Use_Trainer_BTN.Name = "Use_Trainer_BTN";
            this.Use_Trainer_BTN.Size = new System.Drawing.Size(100, 25);
            this.Use_Trainer_BTN.TabIndex = 50;
            this.Use_Trainer_BTN.Text = "应用训练家";
            this.Use_Trainer_BTN.UseVisualStyleBackColor = true;
            this.Use_Trainer_BTN.Click += new System.EventHandler(this.Use_Trainer_BTN_Click);
            // 
            // RandPID_Box
            // 
            this.RandPID_Box.AutoSize = true;
            this.RandPID_Box.Font = new System.Drawing.Font("黑体", 9F);
            this.RandPID_Box.Location = new System.Drawing.Point(384, 22);
            this.RandPID_Box.Name = "RandPID_Box";
            this.RandPID_Box.Size = new System.Drawing.Size(109, 19);
            this.RandPID_Box.TabIndex = 52;
            this.RandPID_Box.Text = "随机PID/EC";
            this.RandPID_Box.UseVisualStyleBackColor = true;
            // 
            // IVEVN_BTN
            // 
            this.IVEVN_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.IVEVN_BTN.Location = new System.Drawing.Point(118, 16);
            this.IVEVN_BTN.Name = "IVEVN_BTN";
            this.IVEVN_BTN.Size = new System.Drawing.Size(100, 25);
            this.IVEVN_BTN.TabIndex = 53;
            this.IVEVN_BTN.Text = "覆盖三维";
            this.IVEVN_BTN.UseVisualStyleBackColor = true;
            this.IVEVN_BTN.Click += new System.EventHandler(this.IVEVN_BTN_Click);
            // 
            // Move_Shop
            // 
            this.Move_Shop.Font = new System.Drawing.Font("黑体", 9F);
            this.Move_Shop.Location = new System.Drawing.Point(23, 18);
            this.Move_Shop.Name = "Move_Shop";
            this.Move_Shop.Size = new System.Drawing.Size(100, 25);
            this.Move_Shop.TabIndex = 58;
            this.Move_Shop.Text = "全部技能";
            this.Move_Shop.UseVisualStyleBackColor = true;
            this.Move_Shop.Click += new System.EventHandler(this.Move_Shop_Click);
            // 
            // LevelMax_BTN
            // 
            this.LevelMax_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.LevelMax_BTN.Location = new System.Drawing.Point(78, 49);
            this.LevelMax_BTN.Name = "LevelMax_BTN";
            this.LevelMax_BTN.Size = new System.Drawing.Size(100, 25);
            this.LevelMax_BTN.TabIndex = 59;
            this.LevelMax_BTN.Text = "等级最大";
            this.LevelMax_BTN.UseVisualStyleBackColor = true;
            this.LevelMax_BTN.Click += new System.EventHandler(this.LevelMax_BTN_Click);
            // 
            // Ball_Box
            // 
            this.Ball_Box.AutoSize = true;
            this.Ball_Box.Font = new System.Drawing.Font("黑体", 9F);
            this.Ball_Box.Location = new System.Drawing.Point(114, 51);
            this.Ball_Box.Name = "Ball_Box";
            this.Ball_Box.Size = new System.Drawing.Size(61, 19);
            this.Ball_Box.TabIndex = 61;
            this.Ball_Box.Text = "球种";
            this.Ball_Box.UseVisualStyleBackColor = true;
            // 
            // Edit_EVIVN_Box
            // 
            this.Edit_EVIVN_Box.FormattingEnabled = true;
            this.Edit_EVIVN_Box.Location = new System.Drawing.Point(6, 18);
            this.Edit_EVIVN_Box.Name = "Edit_EVIVN_Box";
            this.Edit_EVIVN_Box.Size = new System.Drawing.Size(100, 23);
            this.Edit_EVIVN_Box.TabIndex = 62;
            // 
            // Clone_Select_Box
            // 
            this.Clone_Select_Box.FormattingEnabled = true;
            this.Clone_Select_Box.Location = new System.Drawing.Point(181, 49);
            this.Clone_Select_Box.Name = "Clone_Select_Box";
            this.Clone_Select_Box.Size = new System.Drawing.Size(100, 23);
            this.Clone_Select_Box.TabIndex = 63;
            // 
            // Trainer_Select_Box
            // 
            this.Trainer_Select_Box.FormattingEnabled = true;
            this.Trainer_Select_Box.Location = new System.Drawing.Point(8, 51);
            this.Trainer_Select_Box.Name = "Trainer_Select_Box";
            this.Trainer_Select_Box.Size = new System.Drawing.Size(100, 23);
            this.Trainer_Select_Box.TabIndex = 64;
            // 
            // Random_Trainer_Box
            // 
            this.Random_Trainer_Box.AutoSize = true;
            this.Random_Trainer_Box.Font = new System.Drawing.Font("黑体", 9F);
            this.Random_Trainer_Box.Location = new System.Drawing.Point(171, 24);
            this.Random_Trainer_Box.Name = "Random_Trainer_Box";
            this.Random_Trainer_Box.Size = new System.Drawing.Size(93, 19);
            this.Random_Trainer_Box.TabIndex = 65;
            this.Random_Trainer_Box.Text = "随机群友";
            this.Random_Trainer_Box.UseVisualStyleBackColor = true;
            // 
            // Random_Name_Box
            // 
            this.Random_Name_Box.AutoSize = true;
            this.Random_Name_Box.Font = new System.Drawing.Font("黑体", 9F);
            this.Random_Name_Box.Location = new System.Drawing.Point(270, 22);
            this.Random_Name_Box.Name = "Random_Name_Box";
            this.Random_Name_Box.Size = new System.Drawing.Size(93, 19);
            this.Random_Name_Box.TabIndex = 66;
            this.Random_Name_Box.Text = "随机名字";
            this.Random_Name_Box.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Random_Name_Box);
            this.groupBox1.Controls.Add(this.Random_Trainer_Box);
            this.groupBox1.Controls.Add(this.Clone_Select_Box);
            this.groupBox1.Controls.Add(this.Ball_Box);
            this.groupBox1.Controls.Add(this.RandPID_Box);
            this.groupBox1.Controls.Add(this.BallBox);
            this.groupBox1.Controls.Add(this.SetTrainer_Box);
            this.groupBox1.Controls.Add(this.Gift_BTN);
            this.groupBox1.Controls.Add(this.ShinyBox);
            this.groupBox1.Controls.Add(this.Clone_BTN);
            this.groupBox1.Location = new System.Drawing.Point(18, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 83);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "复制器（复制面板）";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Trainer_Select_Box);
            this.groupBox2.Controls.Add(this.Use_Trainer_BTN);
            this.groupBox2.Controls.Add(this.Trainer_Box);
            this.groupBox2.Controls.Add(this.LoadTrainer_BTN);
            this.groupBox2.Location = new System.Drawing.Point(19, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 80);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "训练家";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LevelMax_BTN);
            this.groupBox3.Controls.Add(this.Move_Shop);
            this.groupBox3.Controls.Add(this.AllRibbon_BTN);
            this.groupBox3.Location = new System.Drawing.Point(272, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(247, 80);
            this.groupBox3.TabIndex = 69;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "编辑当前箱子";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BOX_TextBox);
            this.groupBox4.Controls.Add(this.LoadEH1_BTN);
            this.groupBox4.Controls.Add(this.BOX_Label);
            this.groupBox4.Location = new System.Drawing.Point(18, 192);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(257, 50);
            this.groupBox4.TabIndex = 70;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "EH1查看器";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Edit_EVIVN_Box);
            this.groupBox5.Controls.Add(this.IVEVN_BTN);
            this.groupBox5.Location = new System.Drawing.Point(282, 192);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(237, 49);
            this.groupBox5.TabIndex = 71;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "编辑面板";
            // 
            // DistributionUI
            // 
            this.ClientSize = new System.Drawing.Size(528, 251);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DistributionUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuperWang";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private void BindingData()
        {
            string[] lines = Properties.Resources.Trainers.Split('\n') ;
            foreach (string line in lines)
            {
                Tr.Add(Trainer.ConvertToTrainer(line));
            }
            if (Tr.Count != 0)
                Trainer = Tr[0];
            BallBox.DataSource = Enum.GetNames(typeof(Ball));
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = Tr;
            Trainer_Box.DataSource = bindingSource1.DataSource;
            Trainer_Box.DisplayMember = "OT_Name";
            Trainer_Box.ValueMember = "Tid";
       
            BallBox.SelectedIndexChanged += (_, __) =>
            {
                TBall = (Ball)Enum.Parse(typeof(Ball), this.BallBox.SelectedItem.ToString(), false);
            };
            Trainer_Box.SelectedIndexChanged += (_, __) =>
            {
                Trainer =(Trainer) this.Trainer_Box.SelectedItem;
            };
            BallBox.SelectedIndex = 0;
            Edit_EVIVN_Box.DisplayMember = "Description";
            Edit_EVIVN_Box.ValueMember = "Value";
            Edit_EVIVN_Box.DataSource = Enum.GetValues(typeof(IVEVN))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            this.Edit_EVIVN_Box.SelectedIndexChanged += (_, __) =>
            {
                V = (IVEVN)Enum.Parse(typeof(IVEVN), this.Edit_EVIVN_Box.SelectedValue.ToString(), false);
            };
            this.Edit_EVIVN_Box.SelectedIndex = 0;

            this.Clone_Select_Box.DisplayMember = "Description";
            this.Clone_Select_Box.ValueMember = "Value";
            this.Clone_Select_Box.DataSource = Enum.GetValues(typeof(CLONE))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            this.Clone_Select_Box.SelectedIndexChanged += (_, __) =>
            {
                C = (CLONE)Enum.Parse(typeof(CLONE), this.Clone_Select_Box.SelectedValue.ToString(), false);
            };
            this.Clone_Select_Box.SelectedIndex = 0;

            this.Trainer_Select_Box.DisplayMember = "Description";
            this.Trainer_Select_Box.ValueMember = "Value";
            this.Trainer_Select_Box.DataSource = Enum.GetValues(typeof(TRAINER))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            this.Trainer_Select_Box.SelectedIndexChanged += (_, __) =>
            {
                T = (TRAINER)Enum.Parse(typeof(TRAINER), this.Trainer_Select_Box.SelectedValue.ToString(), false);
            };
            this.Trainer_Select_Box.SelectedIndex = 0;
            SetTrainer_Box.CheckedChanged+= (_, __) =>
            {
               
                    Random_Trainer_Box.Enabled = !SetTrainer_Box.Checked;
                
            };
            Random_Trainer_Box.CheckedChanged += (_, __) =>
            {
                
                    SetTrainer_Box.Enabled = !Random_Trainer_Box.Checked;
                
            };
        }
        private void LoadEH1_BTN_Click(object sender, EventArgs e)
        {
            List<PKM> PK = new();
            var i = 0;
            DialogResult dr = this.OpenFile_Dialog.ShowDialog();
            int BOX=Int16.Parse(BOX_TextBox.Text)-1;
            if (dr == DialogResult.OK)
            {
                foreach (String file in OpenFile_Dialog.FileNames)
                {
                    ConvertPKM(file, OpenFile_Dialog.FileNames.Length, ref PK);
                    i++;
                    if (i == OpenFile_Dialog.SafeFileNames.Length)
                    {
                        break;
                    }
                }
                MessageBox.Show($"选取了{PK.Count}只宝可梦");
                for (i = 0; i < PK.Count; i++)
                {
                    SAV.SAV.SetBoxSlotAtIndex(PK[i], BOX, i);
                    SAV.ReloadSlots();
                }
            }
        }
        private void ConvertPKM(string file,int n,ref List<PKM> p)
        {
            var data = File.ReadAllBytes(file);
            PKM pk;
           
            var pkh = DecryptEH1(data);
            if (SAV.SAV.Version is GameVersion.SH or GameVersion.SW)
            {
                pk = pkh.ConvertToPK8();
                p.Add(pk);
                
            }
            else if (SAV.SAV.Version is GameVersion.PLA)
            {
                pk = pkh.ConvertToPA8();
                p.Add(pk);
            }
            else if (SAV.SAV.Version is GameVersion.BD or GameVersion.SP)
            {
                pk = pkh.ConvertToPB8();
                p.Add(pk);
            }
            else
                MessageBox.Show("ERROR");

        }
        private PKH DecryptEH1(byte[] ek1)
        {
            if (ek1 != null)
            {
                if (HomeCrypto.GetIsEncrypted1(ek1))
                    return new PKH(ek1);
            }
            return null;
        }
        public static string RandomString(int length)
        {
            const string chars = "赵钱孙李周吴正旺小鱼儿新子颜缘分振哥毅力建国云宗光辉老查丽鱼安娜牛";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }
        public void SetPkm(ISaveFileProvider SaveFileEditor)
        {
            List<PKM> PKL = new();
            for (int i = 0; i <30; i++)
            {
                var pk = Editor.Data.Clone();
                if (SetTrainer_Box.Checked)
                {
                    pk.OT_Name = Trainer.OT_Name;
                    pk.OT_Gender = Trainer.Gender;
                    pk.TID = Trainer.Tid;
                    pk.SID = Trainer.Sid;
                    pk.Language = Trainer.Language;
                    pk.ClearNickname();
                }
                else if(Random_Trainer_Box.Checked)
                {
                    var T = RandomT(Tr,i);
                    pk.OT_Name = T.OT_Name;
                    pk.OT_Gender = T.Gender;
                    pk.TrainerID7 = T.Tid;
                    pk.TrainerSID7 = T.Sid;
                    pk.Language = T.Language;
                    pk.ClearNickname();

                }
                else if(Random_Name_Box.Checked)
                {
                    pk.OT_Name = RandomString(3);
                    pk.OT_Gender = rand.Next(0, 2);
                    pk.TID = rand.Next(65535);
                    pk.SID = rand.Next(65535);
                    pk.Language = 9;
                    pk.ClearNickname();
                }
                pk.StatNature = pk.Nature;
                if (Ball_Box.Checked)
                {
                    pk.Ball = (int)TBall;
                }
                if (RandPID_Box.Checked)
                {
                    pk.PID = rand.Rand32();
                    pk.SetRandomEC();
                }
                if (ShinyBox.Checked)
                    pk.PID = Shiny(pk);
          
                PKL.Add(pk);
            }
            var BoxData = SAV.SAV.BoxData;
            IList<PKM> arr2 = BoxData;
            List<int> list = FindAllEmptySlots(arr2, 0);
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    int index = list[i];
                    SAV.SAV.SetBoxSlotAtIndex(PKL[i], index);
                }
            }
            SaveFileEditor.ReloadSlots();
        }
        private void SetFivePKM(ISaveFileProvider SaveFileEditor)
        {

            List<PKM> PKL = new();
            for (int i = 0; i < 5; i++)
            {
                var pk = Editor.Data.Clone();
                if (SetTrainer_Box.Checked)
                {
                    pk.OT_Name = Trainer.OT_Name;
                    pk.OT_Gender = Trainer.Gender;
                    pk.TID = Trainer.Tid;
                    pk.SID = Trainer.Sid;
                    pk.Language = Trainer.Language;
                    pk.ClearNickname();
                }
                else if (Random_Trainer_Box.Checked)
                {
                    var T = RandomT(Tr, i);
                    pk.OT_Name = T.OT_Name;
                    pk.OT_Gender = T.Gender;
                    pk.TrainerID7 = T.Tid;
                    pk.TrainerSID7 = T.Sid;
                    pk.Language = T.Language;
                    pk.ClearNickname();

                }
                else if (Random_Name_Box.Checked)
                {
                    pk.OT_Name = RandomString(3);
                    pk.OT_Gender = rand.Next(0, 2);
                    pk.TID = rand.Next(65535);
                    pk.SID = rand.Next(65535);
                    pk.Language = 9;
                    pk.ClearNickname();
                }
                if (RandPID_Box.Checked)
                {
                    pk.SetRandomEC();
                    pk.PID = Util.Rand32();
                }
                if (Editor.Data.IsShiny)
                {
                    pk.SetShiny();
                }
                PKL.Add(pk);
            }
            if (number > 5)
                number = 0;
            int n = SAV.CurrentBox;
            for (int i = 0; i < 5; i++)
            {
                SAV.SAV.SetBoxSlotAtIndex(PKL[i], n, i * 6 + number);
            }
            number++;
            SaveFileEditor.ReloadSlots();
        }
        public void SetGodPokemon(ISaveFileProvider SaveFileEditor)
        {
            List<PKM> PKL = new();
            List<SWSHGod> c = new(SWSHGod.CreateList());
            for (int i = 0; i < 30; i++)
            {
                int j = rand.Next(0, c.Count());
                var pk = GetGodPkm(c[j].Species);
                if (SetTrainer_Box.Checked)
                {
                    pk.OT_Name = Trainer.OT_Name;
                    pk.OT_Gender = Trainer.Gender;
                    pk.TID = Trainer.Tid;
                    pk.SID = Trainer.Sid;
                    pk.Language = Trainer.Language;
                    pk.ClearNickname();

                }

                else if(Random_Trainer_Box.Checked)
                {
                    var T = RandomT(Tr,j);
                    pk.OT_Name = T.OT_Name;
                    pk.OT_Gender = T.Gender;
                    pk.TrainerID7 = T.Tid;
                    pk.TrainerSID7 = T.Sid;
                    pk.Language = T.Language;
                    pk.ClearNickname();

                }
                else if (Random_Name_Box.Checked)
                {
                    pk.OT_Name = RandomString(3);
                    pk.OT_Gender = rand.Next(0, 2);
                    pk.TID = rand.Next(65535);
                    pk.SID = rand.Next(65535);
                    pk.Language = 9;
                    pk.ClearNickname();
                }
                
                pk.IVs = c[j].IVs;
                pk.SetEVs(c[j].EVs);
                pk.Nature = c[j].Nature;
                pk.StatNature = pk.Nature;
                pk.Move1_PPUps = 3;
                pk.Move2_PPUps = 3;
                pk.Move3_PPUps = 3;
                pk.Move4_PPUps = 3;
                pk.HealPP();
                if (Ball_Box.Checked)
                {
                    pk.Ball = (int)TBall;
                }
                if (RandPID_Box.Checked)
                {
                    pk.PID = rand.Rand32();
                    pk.SetRandomEC();
                }
                if (ShinyBox.Checked)
                    pk.PID = Shiny(pk);
                c.RemoveAt(j);
                PKL.Add(pk);
            }
            var BoxData = SAV.SAV.BoxData;
            IList<PKM> arr2 = BoxData;
            List<int> list = FindAllEmptySlots(arr2, 0);
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    int index = list[i];
                    SAV.SAV.SetBoxSlotAtIndex(PKL[i], index);
                }
            }
            SaveFileEditor.ReloadSlots();
        }
        public PKM GetGodPkm(int s)
        {
            List<IEncounterInfo> Results;
            IEncounterInfo enc;
            var setting = new SearchSettings
            {
                Species = s,
                SearchEgg = false,
                Version = (int)SAV.SAV.Version,
            };
            var search = EncounterUtil.SearchDatabase(setting, SAV.SAV);
            var results = search.ToList();
            PKM pk = Editor.Data ;
            if (results.Count != 0)
            {
                for (int i = 0;; i++)
                {
                    Results = results;
                    enc = Results[i];
                    pk = enc.ConvertToPKM(SAV.SAV);
                    if (pk.Met_Location==244)
                        break;
                }
            }
            return pk;
        }
        private static List<int> FindAllEmptySlots(IList<PKM> data, int start)
        {
            List<int> list = new List<int>();
            for (int i = start; i < data.Count; i++)
            {
                if (data[i].Species < 1)
                {
                    list.Add(i);
                }
            }
            return list;
        }
        private static uint Shiny(PKM pk)
        {
            return (((uint)(pk.TID ^ pk.SID) ^ (pk.PID & 0xFFFF) ^ 1) << 16) | (pk.PID & 0xFFFF);
        }
        private static Trainer RandomT(IList<Trainer> T,int i)
        {
            Random ra = new(unchecked((int)Util.Rand32())+i);
            int randIndex = ra.Next(0,T.Count);
            var RandomTrainer = T[randIndex];
            return RandomTrainer;
        }
        private void UseTrainer(PKM pk)
        {
            pk.OT_Name = Trainer.OT_Name;
            pk.TrainerID7 = Trainer.Tid;
            pk.TrainerSID7 = Trainer.Sid;
            pk.Language = Trainer.Language;
            pk.OT_Gender = Trainer.Gender;
            Editor.PopulateFields(pk);
        }
        private void Handle_MoveShop(PKM pk)
        {
            LegalityAnalysis la;

            for (int q = 0; q < 100; q++)
            {
                ((PK8)pk).SetMoveRecordFlag(q, true);
                la = new LegalityAnalysis(pk);
                if (!la.Valid)
                    ((PK8)pk).SetMoveRecordFlag(q, false);
            }
            SAV.ReloadSlots();
        }
        private void Level(PKM pk)
        {
            ((PK8)pk).DynamaxLevel = 10;
            pk.CurrentLevel = 100;
        }
        private void Allribbon(PKM pk)
        {
            RibbonApplicator.SetAllValidRibbons(pk);
        }
        private void Clone_BTN_Click(object sender, EventArgs e)
        {
            switch (C)
            {
               case CLONE.BOX:
                    SetPkm(SAV);
                    SAV.ReloadSlots();
                    break;
               case CLONE.FIVE:
                    SetFivePKM(SAV);
                    SAV.ReloadSlots();
                    break;
            }
        }
        private void Gift_BTN_Click(object sender, EventArgs e)
        {
            SetGodPokemon(SAV);
            SAV.ReloadSlots();
        }
        private void AllRibbon_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(Allribbon);
        }
        private void LoadTrainer_BTN_Click(object sender, EventArgs e)
        {
            Tr.Clear();
            using var sfd = new OpenFileDialog
            {
                Filter = TrainerFilter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            string path = sfd.FileName;
            string[] lines = File.ReadAllLines(path);
            foreach(string line in lines)
            {
               Tr.Add(Trainer.ConvertToTrainer(line));
            }
            if (Tr.Count != 0)
                Trainer = Tr[0];
         
        }
        private void Use_Trainer_BTN_Click(object sender, EventArgs e)
        {
            switch (T)
            {
                case TRAINER.BOX:
                    PKM[] p;
                    int i = SAV.CurrentBox;
                    p = SAV.SAV.GetBoxData(i);
                    if (p.Count() != 0)
                    {
                        foreach (PKM pk in p)
                        {
                            pk.OT_Name = Trainer.OT_Name;
                            pk.TrainerID7 = Trainer.Tid;
                            pk.TrainerSID7 = Trainer.Sid;
                            pk.Language = Trainer.Language;
                            pk.OT_Gender = Trainer.Gender;
                            pk.ClearNickname();
                        }
                    }
                    SAV.SAV.SetBoxData(p, i);
                    break;
                case TRAINER.EDITER:
                    UseTrainer(Editor.Data);
                    break;
            }
        }
        private void IVEVN_BTN_Click(object sender, EventArgs e)
        {
            switch (V)
            {
                case IVEVN.ATK:
                    CommonIVEVSetting.ATKIVEV(Editor.Data, Editor);
                    break;
                case IVEVN.SPA:
                    CommonIVEVSetting.SPAIVEV(Editor.Data, Editor);
                    break;
                case IVEVN.Z_ATK:
                    CommonIVEVSetting.ATK_0SPEIVEV(Editor.Data, Editor);
                    break;
                case IVEVN.Z_SPA:
                    CommonIVEVSetting.SPA_0SPEIVEV(Editor.Data, Editor);
                    break;
                case IVEVN.TANK:
                    CommonIVEVSetting.TANKIVEV(Editor.Data, Editor);
                    break;
            }
        }
        private void Move_Shop_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(Handle_MoveShop);
        }
        private void LevelMax_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(Level);
        }
        #region
        /* public void MytheryPK(PKM pk)
         {
             var db = EncounterEvent.GetAllEvents();
             var RawDB = new List<MysteryGift>(db);
             int i = 0;
             PKM pkc;
             List<PKM> p = new();
             int species = pk.Species;
             IEnumerable<MysteryGift> res = RawDB;
             if (species != -1) res = res.Where(pkm => pkm.Species == species);
             res = res.Where(pkm => pkm.IsShiny == true);
             // res = res.Where(pkm => pkm.Form == 1);
             var results = res.ToArray();
             if (results.Count() != 0)
             {
                 foreach (MysteryGift gift in results)
                 {

                     pkc = gift.ConvertToPKM(SAV.SAV);
                     EntityConverter.TryMakePKMCompatible(pkc, pk, out var c, out pkc);
                       if (UseIVNature_BOX.Checked)
                       {
                           pkc.IV_HP = Convert.ToInt32(IVHPBox.Text);
                           pkc.IV_ATK = Convert.ToInt32(IVATKBox.Text);
                           pkc.IV_DEF = Convert.ToInt32(IVDEFBox.Text);
                           pkc.IV_SPA = Convert.ToInt32(IVSPABox.Text);
                           pkc.IV_SPD = Convert.ToInt32(IVSPDBox.Text);
                           pkc.IV_SPE = Convert.ToInt32(IVSPEBox.Text);
                           pkc.EV_HP = Convert.ToInt32(EVHPBox.Text);
                           pkc.EV_ATK = Convert.ToInt32(EVATKBox.Text);
                           pkc.EV_DEF = Convert.ToInt32(EVDEFBox.Text);
                           pkc.EV_SPA = Convert.ToInt32(EVSPABox.Text);
                           pkc.EV_SPD = Convert.ToInt32(EVSPDBox.Text);
                           pkc.EV_SPE = Convert.ToInt32(EVSPEBox.Text);
                           switch (Ntype)
                           {
                               case Nature.Hardy:
                                   pk.Nature = 0;
                                   break;
                               case Nature.Lonely:
                                   pk.Nature = 1;
                                   break;
                               case Nature.Brave:
                                   pk.Nature = 2;
                                   break;
                               case Nature.Adamant:
                                   pk.Nature = 3;
                                   break;
                               case Nature.Naughty:
                                   pk.Nature = 4;
                                   break;
                               case Nature.Bold:
                                   pk.Nature = 5;
                                   break;
                               case Nature.Docile:
                                   pk.Nature = 6;
                                   break;
                               case Nature.Relaxed:
                                   pk.Nature = 7;
                                   break;
                               case Nature.Impish:
                                   pk.Nature = 8;
                                   break;
                               case Nature.Lax:
                                   pk.Nature = 9;
                                   break;
                               case Nature.Timid:
                                   pk.Nature = 10;
                                   break;
                               case Nature.Hasty:
                                   pk.Nature = 11;
                                   break;
                               case Nature.Serious:
                                   pk.Nature = 12;
                                   break;
                               case Nature.Jolly:
                                   pk.Nature = 13;
                                   break;
                               case Nature.Naive:
                                   pk.Nature = 14;
                                   break;
                               case Nature.Modest:
                                   pk.Nature = 15;
                                   break;
                               case Nature.Mild:
                                   pk.Nature = 16;
                                   break;
                               case Nature.Quiet:
                                   pk.Nature = 17;
                                   break;
                               case Nature.Bashful:
                                   pk.Nature = 18;
                                   break;
                               case Nature.Rash:
                                   pk.Nature = 19;
                                   break;
                               case Nature.Calm:
                                   pk.Nature = 20;
                                   break;
                               case Nature.Gentle:
                                   pk.Nature = 21;
                                   break;
                               case Nature.Sassy:
                                   pk.Nature = 22;
                                   break;
                               case Nature.Careful:
                                   pk.Nature = 23;
                                   break;
                               case Nature.Quirky:
                                   pk.Nature = 24;
                                   break;
                           }
                           switch (Ntype)
                           {
                               case Nature.Hardy:
                                   pkc.Nature = 0;
                                   break;
                               case Nature.Lonely:
                                   pkc.Nature = 1;
                                   break;
                               case Nature.Brave:
                                   pkc.Nature = 2;
                                   break;
                               case Nature.Adamant:
                                   pkc.Nature = 3;
                                   break;
                               case Nature.Naughty:
                                   pkc.Nature = 4;
                                   break;
                               case Nature.Bold:
                                   pkc.Nature = 5;
                                   break;
                               case Nature.Docile:
                                   pkc.Nature = 6;
                                   break;
                               case Nature.Relaxed:
                                   pkc.Nature = 7;
                                   break;
                               case Nature.Impish:
                                   pkc.Nature = 8;
                                   break;
                               case Nature.Lax:
                                   pkc.Nature = 9;
                                   break;
                               case Nature.Timid:
                                   pkc.Nature = 10;
                                   break;
                               case Nature.Hasty:
                                   pkc.Nature = 11;
                                   break;
                               case Nature.Serious:
                                   pkc.Nature = 12;
                                   break;
                               case Nature.Jolly:
                                   pkc.Nature = 13;
                                   break;
                               case Nature.Naive:
                                   pkc.Nature = 14;
                                   break;
                               case Nature.Modest:
                                   pk.Nature = 15;
                                   break;
                               case Nature.Mild:
                                   pkc.Nature = 16;
                                   break;
                               case Nature.Quiet:
                                   pkc.Nature = 17;
                                   break;
                               case Nature.Bashful:
                                   pkc.Nature = 18;
                                   break;
                               case Nature.Rash:
                                   pkc.Nature = 19;
                                   break;
                               case Nature.Calm:
                                   pkc.Nature = 20;
                                   break;
                               case Nature.Gentle:
                                   pkc.Nature = 21;
                                   break;
                               case Nature.Sassy:
                                   pkc.Nature = 22;
                                   break;
                               case Nature.Careful:
                                   pkc.Nature = 23;
                                   break;
                               case Nature.Quirky:
                                   pkc.Nature = 24;
                                   break;
                           }

                     pkc.StatNature = pkc.Nature;

                     if (SetTrainer_Box.Checked)
                     {
                         i++;
                         var T = RandomT(Tr, i);
                         pkc.OT_Name = T.OT_Name;
                         pkc.OT_Gender = T.Gender;
                         pkc.TrainerID7 = T.Tid;
                         pkc.TrainerSID7 = T.Sid;
                         pkc.Language = T.Language;

                     }
                     p.Add(pkc);
                 }
             }
             MessageBox.Show($"{p.Count()}");
             var BoxData = SAV.SAV.BoxData;
             IList<PKM> arr2 = BoxData;
             List<int> list = FindAllEmptySlots(arr2, 0);
             for (int j = 0; j < p.Count; j++)
             {
                 int index = list[j];
                 SAV.SAV.SetBoxSlotAtIndex(p[j], index);

             }

         }*/
        #endregion
    }
}
