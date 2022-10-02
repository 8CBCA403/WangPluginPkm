using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPlugin.GUI
{
    partial class RNGForm
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RNGForm));
            this.Search = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.UsePreSeed = new System.Windows.Forms.CheckBox();
            this.Check_BTN = new System.Windows.Forms.Button();
            this.SearchGroupBox = new System.Windows.Forms.GroupBox();
            this.TeamLockBox = new System.Windows.Forms.CheckBox();
            this.ConditionForm = new PkmCondition();
            this.MinIV_Box = new System.Windows.Forms.ComboBox();
            this.Gender_Box = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Ability_Box = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CheckGroup_RaidBox = new System.Windows.Forms.GroupBox();
            this.GetSeedForMaxLair_BTN = new System.Windows.Forms.Button();
            this.Legal_Check_BOX5 = new System.Windows.Forms.TextBox();
            this.Legal_Check_BOX4 = new System.Windows.Forms.TextBox();
            this.Legal_Check_BOX3 = new System.Windows.Forms.TextBox();
            this.Legal_Check_BOX2 = new System.Windows.Forms.TextBox();
            this.Legal_Check_BOX1 = new System.Windows.Forms.TextBox();
            this.Seed_Box = new System.Windows.Forms.TextBox();
            this.SeedBox = new System.Windows.Forms.TextBox();
            this.PIDBox = new System.Windows.Forms.TextBox();
            this.ReverseCheck_BTN = new System.Windows.Forms.Button();
            this.CheckGroup_ModBox = new System.Windows.Forms.GroupBox();
            this.IVCheck_Box = new System.Windows.Forms.CheckBox();
            this.PIDECCheck_Box = new System.Windows.Forms.CheckBox();
            this.IVBox = new System.Windows.Forms.Label();
            this.IVTextBox = new System.Windows.Forms.TextBox();
            this.ECLabel = new System.Windows.Forms.Label();
            this.ECBox = new System.Windows.Forms.TextBox();
            this.Seedlabel = new System.Windows.Forms.Label();
            this.PIDlabel = new System.Windows.Forms.Label();
            this.Mlabel = new System.Windows.Forms.Label();
            this.Mod_ComboBox = new System.Windows.Forms.ComboBox();
            this.SearchGroupBox.SuspendLayout();
            this.CheckGroup_RaidBox.SuspendLayout();
            this.CheckGroup_ModBox.SuspendLayout();
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
            this.UsePreSeed.Size = new System.Drawing.Size(126, 21);
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
            // SearchGroupBox
            // 
            this.SearchGroupBox.Controls.Add(this.Cancel);
            this.SearchGroupBox.Controls.Add(this.TeamLockBox);
            this.SearchGroupBox.Controls.Add(this.Search);
            this.SearchGroupBox.Controls.Add(this.UsePreSeed);
            this.SearchGroupBox.Controls.Add(this.ConditionForm);
            this.SearchGroupBox.Location = new System.Drawing.Point(5, 4);
            this.SearchGroupBox.Name = "SearchGroupBox";
            this.SearchGroupBox.Size = new System.Drawing.Size(326, 223);
            this.SearchGroupBox.TabIndex = 24;
            this.SearchGroupBox.TabStop = false;
            this.SearchGroupBox.Text = "查找";
            // 
            // TeamLockBox
            // 
            this.TeamLockBox.AutoSize = true;
            this.TeamLockBox.Location = new System.Drawing.Point(138, 171);
            this.TeamLockBox.Name = "TeamLockBox";
            this.TeamLockBox.Size = new System.Drawing.Size(125, 21);
            this.TeamLockBox.TabIndex = 24;
            this.TeamLockBox.Text = "CXD使用队锁";
            this.TeamLockBox.UseVisualStyleBackColor = true;
            // 
            // ConditionForm
            // 
            this.ConditionForm.Location = new System.Drawing.Point(7, 14);
            this.ConditionForm.Margin = new System.Windows.Forms.Padding(2);
            this.ConditionForm.Name = "ConditionForm";
            this.ConditionForm.Size = new System.Drawing.Size(313, 186);
            this.ConditionForm.TabIndex = 23;
            // 
            // MinIV_Box
            // 
            this.MinIV_Box.FormattingEnabled = true;
            this.MinIV_Box.Location = new System.Drawing.Point(41, 55);
            this.MinIV_Box.Name = "MinIV_Box";
            this.MinIV_Box.Size = new System.Drawing.Size(105, 25);
            this.MinIV_Box.TabIndex = 25;
            // 
            // Gender_Box
            // 
            this.Gender_Box.FormattingEnabled = true;
            this.Gender_Box.Location = new System.Drawing.Point(54, 85);
            this.Gender_Box.Name = "Gender_Box";
            this.Gender_Box.Size = new System.Drawing.Size(92, 25);
            this.Gender_Box.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "锁IV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "公母比";
            // 
            // Ability_Box
            // 
            this.Ability_Box.FormattingEnabled = true;
            this.Ability_Box.Location = new System.Drawing.Point(41, 116);
            this.Ability_Box.Name = "Ability_Box";
            this.Ability_Box.Size = new System.Drawing.Size(105, 25);
            this.Ability_Box.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "特性";
            // 
            // CheckGroup_RaidBox
            // 
            this.CheckGroup_RaidBox.Controls.Add(this.GetSeedForMaxLair_BTN);
            this.CheckGroup_RaidBox.Controls.Add(this.Legal_Check_BOX5);
            this.CheckGroup_RaidBox.Controls.Add(this.Legal_Check_BOX4);
            this.CheckGroup_RaidBox.Controls.Add(this.Legal_Check_BOX3);
            this.CheckGroup_RaidBox.Controls.Add(this.Legal_Check_BOX2);
            this.CheckGroup_RaidBox.Controls.Add(this.Legal_Check_BOX1);
            this.CheckGroup_RaidBox.Controls.Add(this.Seed_Box);
            this.CheckGroup_RaidBox.Controls.Add(this.label4);
            this.CheckGroup_RaidBox.Controls.Add(this.Ability_Box);
            this.CheckGroup_RaidBox.Controls.Add(this.label3);
            this.CheckGroup_RaidBox.Controls.Add(this.label2);
            this.CheckGroup_RaidBox.Controls.Add(this.Gender_Box);
            this.CheckGroup_RaidBox.Controls.Add(this.MinIV_Box);
            this.CheckGroup_RaidBox.Controls.Add(this.Check_BTN);
            this.CheckGroup_RaidBox.Location = new System.Drawing.Point(337, 4);
            this.CheckGroup_RaidBox.Name = "CheckGroup_RaidBox";
            this.CheckGroup_RaidBox.Size = new System.Drawing.Size(286, 223);
            this.CheckGroup_RaidBox.TabIndex = 31;
            this.CheckGroup_RaidBox.TabStop = false;
            this.CheckGroup_RaidBox.Text = "检测(Raid/大冒险)";
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
            this.SeedBox.Location = new System.Drawing.Point(223, 89);
            this.SeedBox.Multiline = true;
            this.SeedBox.Name = "SeedBox";
            this.SeedBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SeedBox.Size = new System.Drawing.Size(124, 95);
            this.SeedBox.TabIndex = 38;
            // 
            // PIDBox
            // 
            this.PIDBox.Location = new System.Drawing.Point(223, 24);
            this.PIDBox.Name = "PIDBox";
            this.PIDBox.Size = new System.Drawing.Size(124, 25);
            this.PIDBox.TabIndex = 37;
            // 
            // ReverseCheck_BTN
            // 
            this.ReverseCheck_BTN.Location = new System.Drawing.Point(68, 159);
            this.ReverseCheck_BTN.Name = "ReverseCheck_BTN";
            this.ReverseCheck_BTN.Size = new System.Drawing.Size(124, 25);
            this.ReverseCheck_BTN.TabIndex = 25;
            this.ReverseCheck_BTN.Text = "开始查找";
            this.ReverseCheck_BTN.UseVisualStyleBackColor = true;
            this.ReverseCheck_BTN.Click += new System.EventHandler(this.ReverseCheck_BTN_Click);
            // 
            // CheckGroup_ModBox
            // 
            this.CheckGroup_ModBox.Controls.Add(this.IVCheck_Box);
            this.CheckGroup_ModBox.Controls.Add(this.PIDECCheck_Box);
            this.CheckGroup_ModBox.Controls.Add(this.IVBox);
            this.CheckGroup_ModBox.Controls.Add(this.IVTextBox);
            this.CheckGroup_ModBox.Controls.Add(this.ECLabel);
            this.CheckGroup_ModBox.Controls.Add(this.ECBox);
            this.CheckGroup_ModBox.Controls.Add(this.Seedlabel);
            this.CheckGroup_ModBox.Controls.Add(this.PIDlabel);
            this.CheckGroup_ModBox.Controls.Add(this.Mlabel);
            this.CheckGroup_ModBox.Controls.Add(this.Mod_ComboBox);
            this.CheckGroup_ModBox.Controls.Add(this.SeedBox);
            this.CheckGroup_ModBox.Controls.Add(this.ReverseCheck_BTN);
            this.CheckGroup_ModBox.Controls.Add(this.PIDBox);
            this.CheckGroup_ModBox.Location = new System.Drawing.Point(629, 4);
            this.CheckGroup_ModBox.Name = "CheckGroup_ModBox";
            this.CheckGroup_ModBox.Size = new System.Drawing.Size(368, 223);
            this.CheckGroup_ModBox.TabIndex = 39;
            this.CheckGroup_ModBox.TabStop = false;
            this.CheckGroup_ModBox.Text = "逆推Seed";
            // 
            // IVCheck_Box
            // 
            this.IVCheck_Box.AutoSize = true;
            this.IVCheck_Box.Enabled = false;
            this.IVCheck_Box.Location = new System.Drawing.Point(45, 120);
            this.IVCheck_Box.Name = "IVCheck_Box";
            this.IVCheck_Box.Size = new System.Drawing.Size(106, 21);
            this.IVCheck_Box.TabIndex = 44;
            this.IVCheck_Box.Text = "使用IV反推";
            this.IVCheck_Box.UseVisualStyleBackColor = true;
            this.IVCheck_Box.CheckedChanged += new System.EventHandler(this.IVCheck_Box_CheckedChanged);
            // 
            // PIDECCheck_Box
            // 
            this.PIDECCheck_Box.AutoSize = true;
            this.PIDECCheck_Box.Checked = true;
            this.PIDECCheck_Box.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PIDECCheck_Box.Location = new System.Drawing.Point(45, 93);
            this.PIDECCheck_Box.Name = "PIDECCheck_Box";
            this.PIDECCheck_Box.Size = new System.Drawing.Size(118, 21);
            this.PIDECCheck_Box.TabIndex = 25;
            this.PIDECCheck_Box.Text = "使用PID反推";
            this.PIDECCheck_Box.UseVisualStyleBackColor = true;
            this.PIDECCheck_Box.CheckedChanged += new System.EventHandler(this.PIDECCheck_Box_CheckedChanged);
            // 
            // IVBox
            // 
            this.IVBox.AutoSize = true;
            this.IVBox.Location = new System.Drawing.Point(42, 61);
            this.IVBox.Name = "IVBox";
            this.IVBox.Size = new System.Drawing.Size(20, 17);
            this.IVBox.TabIndex = 43;
            this.IVBox.Text = "IV";
            // 
            // IVTextBox
            // 
            this.IVTextBox.Location = new System.Drawing.Point(68, 58);
            this.IVTextBox.Name = "IVTextBox";
            this.IVTextBox.Size = new System.Drawing.Size(124, 25);
            this.IVTextBox.TabIndex = 42;
            // 
            // ECLabel
            // 
            this.ECLabel.AutoSize = true;
            this.ECLabel.Location = new System.Drawing.Point(197, 61);
            this.ECLabel.Name = "ECLabel";
            this.ECLabel.Size = new System.Drawing.Size(29, 17);
            this.ECLabel.TabIndex = 41;
            this.ECLabel.Text = "EC";
            // 
            // ECBox
            // 
            this.ECBox.Enabled = false;
            this.ECBox.Location = new System.Drawing.Point(223, 58);
            this.ECBox.Name = "ECBox";
            this.ECBox.Size = new System.Drawing.Size(124, 25);
            this.ECBox.TabIndex = 40;
            // 
            // Seedlabel
            // 
            this.Seedlabel.AutoSize = true;
            this.Seedlabel.Location = new System.Drawing.Point(184, 93);
            this.Seedlabel.Name = "Seedlabel";
            this.Seedlabel.Size = new System.Drawing.Size(42, 17);
            this.Seedlabel.TabIndex = 39;
            this.Seedlabel.Text = "Seed";
            // 
            // PIDlabel
            // 
            this.PIDlabel.AutoSize = true;
            this.PIDlabel.Location = new System.Drawing.Point(194, 29);
            this.PIDlabel.Name = "PIDlabel";
            this.PIDlabel.Size = new System.Drawing.Size(32, 17);
            this.PIDlabel.TabIndex = 37;
            this.PIDlabel.Text = "PID";
            // 
            // Mlabel
            // 
            this.Mlabel.AutoSize = true;
            this.Mlabel.Location = new System.Drawing.Point(6, 29);
            this.Mlabel.Name = "Mlabel";
            this.Mlabel.Size = new System.Drawing.Size(72, 17);
            this.Mlabel.TabIndex = 37;
            this.Mlabel.Text = "模式选择";
            // 
            // Mod_ComboBox
            // 
            this.Mod_ComboBox.FormattingEnabled = true;
            this.Mod_ComboBox.Location = new System.Drawing.Point(67, 24);
            this.Mod_ComboBox.Name = "Mod_ComboBox";
            this.Mod_ComboBox.Size = new System.Drawing.Size(124, 25);
            this.Mod_ComboBox.TabIndex = 37;
            // 
            // RNGForm
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1009, 231);
            this.Controls.Add(this.CheckGroup_ModBox);
            this.Controls.Add(this.CheckGroup_RaidBox);
            this.Controls.Add(this.SearchGroupBox);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RNGForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.SearchGroupBox.ResumeLayout(false);
            this.SearchGroupBox.PerformLayout();
            this.CheckGroup_RaidBox.ResumeLayout(false);
            this.CheckGroup_RaidBox.PerformLayout();
            this.CheckGroup_ModBox.ResumeLayout(false);
            this.CheckGroup_ModBox.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
