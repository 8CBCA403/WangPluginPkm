using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WangPluginPkm.GUI
{
    partial class DistributionUI
    {
        private OpenFileDialog OpenFile_Dialog;
        private TextBox BOX_TextBox;
        private Label BOX_Label;
        private Button Clone_BTN;
        private Button LoadEH1_BTN;
        private CheckBox ShinyBox;
        private Button Gift_BTN;
        private CheckBox SetTrainer_Box;
        private Button AllRibbon_BTN;
        private Button LoadTrainer_BTN;
        private ComboBox BallBox;
        private ComboBox Trainer_Box;
        private Button Use_Trainer_BTN;
        private Button IVEVN_BTN;
        private Button Move_Shop;
        private Button LevelMax_BTN;
        private CheckBox Ball_Box;
        private ComboBox Edit_EVIVN_Box;
        private ComboBox Clone_Select_Box;
        private ComboBox Trainer_Select_Box;
        private CheckBox Random_Trainer_Box;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private CheckBox Random_Name_Box;
        private CheckBox RandEC_Box;
        private CheckBox RandPID_Box;
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RandEC_Box = new System.Windows.Forms.CheckBox();
            this.Random_Name_Box = new System.Windows.Forms.CheckBox();
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
            this.Clone_BTN.Location = new System.Drawing.Point(115, 49);
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
            this.Gift_BTN.Location = new System.Drawing.Point(221, 49);
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
            this.SetTrainer_Box.Location = new System.Drawing.Point(59, 24);
            this.SetTrainer_Box.Name = "SetTrainer_Box";
            this.SetTrainer_Box.Size = new System.Drawing.Size(109, 19);
            this.SetTrainer_Box.TabIndex = 36;
            this.SetTrainer_Box.Text = "指定训练家";
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
            this.BallBox.Location = new System.Drawing.Point(332, 49);
            this.BallBox.Name = "BallBox";
            this.BallBox.Size = new System.Drawing.Size(62, 23);
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
            this.RandPID_Box.Location = new System.Drawing.Point(298, 24);
            this.RandPID_Box.Name = "RandPID_Box";
            this.RandPID_Box.Size = new System.Drawing.Size(85, 19);
            this.RandPID_Box.TabIndex = 52;
            this.RandPID_Box.Text = "随机PID";
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
            this.Ball_Box.Location = new System.Drawing.Point(400, 51);
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
            this.Clone_Select_Box.Location = new System.Drawing.Point(9, 51);
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
            this.Random_Trainer_Box.Location = new System.Drawing.Point(142, 24);
            this.Random_Trainer_Box.Name = "Random_Trainer_Box";
            this.Random_Trainer_Box.Size = new System.Drawing.Size(109, 19);
            this.Random_Trainer_Box.TabIndex = 65;
            this.Random_Trainer_Box.Text = "随机训练家";
            this.Random_Trainer_Box.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RandEC_Box);
            this.groupBox1.Controls.Add(this.RandPID_Box);
            this.groupBox1.Controls.Add(this.Random_Name_Box);
            this.groupBox1.Controls.Add(this.Random_Trainer_Box);
            this.groupBox1.Controls.Add(this.Clone_Select_Box);
            this.groupBox1.Controls.Add(this.Ball_Box);
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
            // RandEC_Box
            // 
            this.RandEC_Box.AutoSize = true;
            this.RandEC_Box.Font = new System.Drawing.Font("黑体", 9F);
            this.RandEC_Box.Location = new System.Drawing.Point(369, 24);
            this.RandEC_Box.Name = "RandEC_Box";
            this.RandEC_Box.Size = new System.Drawing.Size(77, 19);
            this.RandEC_Box.TabIndex = 69;
            this.RandEC_Box.Text = "随机EC";
            this.RandEC_Box.UseVisualStyleBackColor = true;
            // 
            // Random_Name_Box
            // 
            this.Random_Name_Box.AutoSize = true;
            this.Random_Name_Box.Font = new System.Drawing.Font("黑体", 9F);
            this.Random_Name_Box.Location = new System.Drawing.Point(226, 24);
            this.Random_Name_Box.Name = "Random_Name_Box";
            this.Random_Name_Box.Size = new System.Drawing.Size(93, 19);
            this.Random_Name_Box.TabIndex = 68;
            this.Random_Name_Box.Text = "随机名字";
            this.Random_Name_Box.UseVisualStyleBackColor = true;
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
    }
}
