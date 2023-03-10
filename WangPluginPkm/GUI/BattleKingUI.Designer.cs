using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WangPluginPkm.GUI
{
    partial class BattleKingUI
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleKingUI));
            LoadBattleTeam_BTN = new Button();
            UrlBox = new RichTextBox();
            PSBox = new RichTextBox();
            LoadTeamFromPSCode_BTN = new Button();
            ImportPKM_BTN = new Button();
            ConditionBox = new TextBox();
            ClearAllBox_BTN = new Button();
            ChineseCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // LoadBattleTeam_BTN
            // 
            LoadBattleTeam_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LoadBattleTeam_BTN.Location = new System.Drawing.Point(423, 194);
            LoadBattleTeam_BTN.Name = "LoadBattleTeam_BTN";
            LoadBattleTeam_BTN.Size = new System.Drawing.Size(149, 32);
            LoadBattleTeam_BTN.TabIndex = 0;
            LoadBattleTeam_BTN.Text = "从网址批量导入";
            LoadBattleTeam_BTN.UseVisualStyleBackColor = true;
            LoadBattleTeam_BTN.Click += LoadBattleTeam_BTN_Click;
            // 
            // UrlBox
            // 
            UrlBox.Location = new System.Drawing.Point(350, 12);
            UrlBox.Name = "UrlBox";
            UrlBox.Size = new System.Drawing.Size(283, 176);
            UrlBox.TabIndex = 2;
            UrlBox.Text = "";
            // 
            // PSBox
            // 
            PSBox.Location = new System.Drawing.Point(12, 12);
            PSBox.Name = "PSBox";
            PSBox.Size = new System.Drawing.Size(332, 176);
            PSBox.TabIndex = 3;
            PSBox.Text = "";
            // 
            // LoadTeamFromPSCode_BTN
            // 
            LoadTeamFromPSCode_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LoadTeamFromPSCode_BTN.Location = new System.Drawing.Point(122, 194);
            LoadTeamFromPSCode_BTN.Name = "LoadTeamFromPSCode_BTN";
            LoadTeamFromPSCode_BTN.Size = new System.Drawing.Size(197, 32);
            LoadTeamFromPSCode_BTN.TabIndex = 4;
            LoadTeamFromPSCode_BTN.Text = "从Showdown批量导入";
            LoadTeamFromPSCode_BTN.UseVisualStyleBackColor = true;
            LoadTeamFromPSCode_BTN.Click += LoadTeamFromPSCode_BTN_Click;
            // 
            // ImportPKM_BTN
            // 
            ImportPKM_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ImportPKM_BTN.Location = new System.Drawing.Point(639, 83);
            ImportPKM_BTN.Name = "ImportPKM_BTN";
            ImportPKM_BTN.Size = new System.Drawing.Size(206, 30);
            ImportPKM_BTN.TabIndex = 5;
            ImportPKM_BTN.TabStop = false;
            ImportPKM_BTN.Text = "从文件导入smogon策略";
            ImportPKM_BTN.UseVisualStyleBackColor = true;
            ImportPKM_BTN.Click += ImportPKM_BTN_Click;
            // 
            // ConditionBox
            // 
            ConditionBox.Location = new System.Drawing.Point(639, 40);
            ConditionBox.Name = "ConditionBox";
            ConditionBox.Size = new System.Drawing.Size(206, 25);
            ConditionBox.TabIndex = 6;
            ConditionBox.Text = "Nothing to check";
            // 
            // ClearAllBox_BTN
            // 
            ClearAllBox_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ClearAllBox_BTN.Location = new System.Drawing.Point(639, 129);
            ClearAllBox_BTN.Name = "ClearAllBox_BTN";
            ClearAllBox_BTN.Size = new System.Drawing.Size(206, 29);
            ClearAllBox_BTN.TabIndex = 7;
            ClearAllBox_BTN.Text = "清除全部盒子";
            ClearAllBox_BTN.UseVisualStyleBackColor = true;
            ClearAllBox_BTN.Click += ClearAllBox_BTN_Click;
            // 
            // ChineseCheckBox
            // 
            ChineseCheckBox.AutoSize = true;
            ChineseCheckBox.Location = new System.Drawing.Point(12, 200);
            ChineseCheckBox.Name = "ChineseCheckBox";
            ChineseCheckBox.Size = new System.Drawing.Size(93, 19);
            ChineseCheckBox.TabIndex = 8;
            ChineseCheckBox.Text = "中文指令";
            ChineseCheckBox.UseVisualStyleBackColor = true;
            // 
            // BattleKingUI
            // 
            ClientSize = new System.Drawing.Size(856, 231);
            Controls.Add(ChineseCheckBox);
            Controls.Add(ClearAllBox_BTN);
            Controls.Add(ConditionBox);
            Controls.Add(ImportPKM_BTN);
            Controls.Add(LoadTeamFromPSCode_BTN);
            Controls.Add(PSBox);
            Controls.Add(UrlBox);
            Controls.Add(LoadBattleTeam_BTN);
            Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "BattleKingUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Super Wang";
            ResumeLayout(false);
            PerformLayout();
        }

        private RichTextBox UrlBox;
        private RichTextBox PSBox;
        private Button LoadTeamFromPSCode_BTN;
        private Button ImportPKM_BTN;
        private TextBox ConditionBox;
        private Button ClearAllBox_BTN;
        private Button LoadBattleTeam_BTN;
        private CheckBox ChineseCheckBox;
    }
}
