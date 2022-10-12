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
            this.LoadBattleTeam_BTN = new System.Windows.Forms.Button();
            this.UrlBox = new System.Windows.Forms.RichTextBox();
            this.PSBox = new System.Windows.Forms.RichTextBox();
            this.LoadTeamFromPSCode_BTN = new System.Windows.Forms.Button();
            this.ImportPKM_BTN = new System.Windows.Forms.Button();
            this.ConditionBox = new System.Windows.Forms.TextBox();
            this.ClearAllBox_BTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadBattleTeam_BTN
            // 
            this.LoadBattleTeam_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.LoadBattleTeam_BTN.Location = new System.Drawing.Point(423, 194);
            this.LoadBattleTeam_BTN.Name = "LoadBattleTeam_BTN";
            this.LoadBattleTeam_BTN.Size = new System.Drawing.Size(149, 32);
            this.LoadBattleTeam_BTN.TabIndex = 0;
            this.LoadBattleTeam_BTN.Text = "从网址批量导入";
            this.LoadBattleTeam_BTN.UseVisualStyleBackColor = true;
            this.LoadBattleTeam_BTN.Click += new System.EventHandler(this.LoadBattleTeam_BTN_Click);
            // 
            // UrlBox
            // 
            this.UrlBox.Location = new System.Drawing.Point(350, 12);
            this.UrlBox.Name = "UrlBox";
            this.UrlBox.Size = new System.Drawing.Size(283, 176);
            this.UrlBox.TabIndex = 2;
            this.UrlBox.Text = "";
            // 
            // PSBox
            // 
            this.PSBox.Location = new System.Drawing.Point(12, 12);
            this.PSBox.Name = "PSBox";
            this.PSBox.Size = new System.Drawing.Size(332, 176);
            this.PSBox.TabIndex = 3;
            this.PSBox.Text = "";
            // 
            // LoadTeamFromPSCode_BTN
            // 
            this.LoadTeamFromPSCode_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.LoadTeamFromPSCode_BTN.Location = new System.Drawing.Point(78, 194);
            this.LoadTeamFromPSCode_BTN.Name = "LoadTeamFromPSCode_BTN";
            this.LoadTeamFromPSCode_BTN.Size = new System.Drawing.Size(197, 32);
            this.LoadTeamFromPSCode_BTN.TabIndex = 4;
            this.LoadTeamFromPSCode_BTN.Text = "从Showdown批量导入";
            this.LoadTeamFromPSCode_BTN.UseVisualStyleBackColor = true;
            this.LoadTeamFromPSCode_BTN.Click += new System.EventHandler(this.LoadTeamFromPSCode_BTN_Click);
            // 
            // ImportPKM_BTN
            // 
            this.ImportPKM_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.ImportPKM_BTN.Location = new System.Drawing.Point(639, 83);
            this.ImportPKM_BTN.Name = "ImportPKM_BTN";
            this.ImportPKM_BTN.Size = new System.Drawing.Size(206, 30);
            this.ImportPKM_BTN.TabIndex = 5;
            this.ImportPKM_BTN.TabStop = false;
            this.ImportPKM_BTN.Text = "从文件导入smogon策略";
            this.ImportPKM_BTN.UseVisualStyleBackColor = true;
            this.ImportPKM_BTN.Click += new System.EventHandler(this.ImportPKM_BTN_Click);
            // 
            // ConditionBox
            // 
            this.ConditionBox.Location = new System.Drawing.Point(639, 40);
            this.ConditionBox.Name = "ConditionBox";
            this.ConditionBox.Size = new System.Drawing.Size(206, 27);
            this.ConditionBox.TabIndex = 6;
            this.ConditionBox.Text = "Nothing to check";
            // 
            // ClearAllBox_BTN
            // 
            this.ClearAllBox_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.ClearAllBox_BTN.Location = new System.Drawing.Point(639, 129);
            this.ClearAllBox_BTN.Name = "ClearAllBox_BTN";
            this.ClearAllBox_BTN.Size = new System.Drawing.Size(206, 29);
            this.ClearAllBox_BTN.TabIndex = 7;
            this.ClearAllBox_BTN.Text = "清除全部盒子";
            this.ClearAllBox_BTN.UseVisualStyleBackColor = true;
            this.ClearAllBox_BTN.Click += new System.EventHandler(this.ClearAllBox_BTN_Click);
            // 
            // BattleKingUI
            // 
            this.ClientSize = new System.Drawing.Size(856, 231);
            this.Controls.Add(this.ClearAllBox_BTN);
            this.Controls.Add(this.ConditionBox);
            this.Controls.Add(this.ImportPKM_BTN);
            this.Controls.Add(this.LoadTeamFromPSCode_BTN);
            this.Controls.Add(this.PSBox);
            this.Controls.Add(this.UrlBox);
            this.Controls.Add(this.LoadBattleTeam_BTN);
            this.Font = new System.Drawing.Font("Arial", 10.2F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BattleKingUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private RichTextBox UrlBox;
        private RichTextBox PSBox;
        private Button LoadTeamFromPSCode_BTN;
        private Button ImportPKM_BTN;
        private TextBox ConditionBox;
        private Button ClearAllBox_BTN;
        private Button LoadBattleTeam_BTN;
    }
}
