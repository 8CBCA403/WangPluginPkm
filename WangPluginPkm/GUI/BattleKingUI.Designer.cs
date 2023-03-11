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
            BattleKingtabControl = new TabControl();
            PStabPage = new TabPage();
            WebtabPage = new TabPage();
            SmogontabPage = new TabPage();
            BattleKingtabControl.SuspendLayout();
            PStabPage.SuspendLayout();
            WebtabPage.SuspendLayout();
            SmogontabPage.SuspendLayout();
            SuspendLayout();
            // 
            // LoadBattleTeam_BTN
            // 
            LoadBattleTeam_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LoadBattleTeam_BTN.Location = new System.Drawing.Point(180, 308);
            LoadBattleTeam_BTN.Name = "LoadBattleTeam_BTN";
            LoadBattleTeam_BTN.Size = new System.Drawing.Size(149, 32);
            LoadBattleTeam_BTN.TabIndex = 0;
            LoadBattleTeam_BTN.Text = "从网址批量导入";
            LoadBattleTeam_BTN.UseVisualStyleBackColor = true;
            LoadBattleTeam_BTN.Click += LoadBattleTeam_BTN_Click;
            // 
            // UrlBox
            // 
            UrlBox.Location = new System.Drawing.Point(3, 3);
            UrlBox.Name = "UrlBox";
            UrlBox.Size = new System.Drawing.Size(519, 299);
            UrlBox.TabIndex = 2;
            UrlBox.Text = "";
            // 
            // PSBox
            // 
            PSBox.Location = new System.Drawing.Point(6, 6);
            PSBox.Name = "PSBox";
            PSBox.Size = new System.Drawing.Size(516, 287);
            PSBox.TabIndex = 3;
            PSBox.Text = "";
            // 
            // LoadTeamFromPSCode_BTN
            // 
            LoadTeamFromPSCode_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LoadTeamFromPSCode_BTN.Location = new System.Drawing.Point(215, 299);
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
            ImportPKM_BTN.Location = new System.Drawing.Point(161, 150);
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
            ConditionBox.Location = new System.Drawing.Point(161, 107);
            ConditionBox.Name = "ConditionBox";
            ConditionBox.Size = new System.Drawing.Size(206, 25);
            ConditionBox.TabIndex = 6;
            ConditionBox.Text = "Nothing to check";
            // 
            // ClearAllBox_BTN
            // 
            ClearAllBox_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ClearAllBox_BTN.Location = new System.Drawing.Point(161, 196);
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
            ChineseCheckBox.Location = new System.Drawing.Point(105, 305);
            ChineseCheckBox.Name = "ChineseCheckBox";
            ChineseCheckBox.Size = new System.Drawing.Size(93, 19);
            ChineseCheckBox.TabIndex = 8;
            ChineseCheckBox.Text = "中文指令";
            ChineseCheckBox.UseVisualStyleBackColor = true;
            // 
            // BattleKingtabControl
            // 
            BattleKingtabControl.Controls.Add(PStabPage);
            BattleKingtabControl.Controls.Add(WebtabPage);
            BattleKingtabControl.Controls.Add(SmogontabPage);
            BattleKingtabControl.Location = new System.Drawing.Point(12, 12);
            BattleKingtabControl.Name = "BattleKingtabControl";
            BattleKingtabControl.SelectedIndex = 0;
            BattleKingtabControl.Size = new System.Drawing.Size(536, 377);
            BattleKingtabControl.TabIndex = 9;
            // 
            // PStabPage
            // 
            PStabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            PStabPage.Controls.Add(PSBox);
            PStabPage.Controls.Add(ChineseCheckBox);
            PStabPage.Controls.Add(LoadTeamFromPSCode_BTN);
            PStabPage.Location = new System.Drawing.Point(4, 25);
            PStabPage.Name = "PStabPage";
            PStabPage.Padding = new Padding(3);
            PStabPage.Size = new System.Drawing.Size(528, 348);
            PStabPage.TabIndex = 0;
            PStabPage.Text = "PS指令模式";
            // 
            // WebtabPage
            // 
            WebtabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            WebtabPage.Controls.Add(UrlBox);
            WebtabPage.Controls.Add(LoadBattleTeam_BTN);
            WebtabPage.Location = new System.Drawing.Point(4, 25);
            WebtabPage.Name = "WebtabPage";
            WebtabPage.Padding = new Padding(3);
            WebtabPage.Size = new System.Drawing.Size(528, 348);
            WebtabPage.TabIndex = 1;
            WebtabPage.Text = "网址模式";
            // 
            // SmogontabPage
            // 
            SmogontabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            SmogontabPage.Controls.Add(ConditionBox);
            SmogontabPage.Controls.Add(ClearAllBox_BTN);
            SmogontabPage.Controls.Add(ImportPKM_BTN);
            SmogontabPage.Location = new System.Drawing.Point(4, 25);
            SmogontabPage.Name = "SmogontabPage";
            SmogontabPage.Padding = new Padding(3);
            SmogontabPage.Size = new System.Drawing.Size(528, 348);
            SmogontabPage.TabIndex = 2;
            SmogontabPage.Text = "Smogon策略模式";
            // 
            // BattleKingUI
            // 
            ClientSize = new System.Drawing.Size(565, 402);
            Controls.Add(BattleKingtabControl);
            Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "BattleKingUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Super Wang";
            BattleKingtabControl.ResumeLayout(false);
            PStabPage.ResumeLayout(false);
            PStabPage.PerformLayout();
            WebtabPage.ResumeLayout(false);
            SmogontabPage.ResumeLayout(false);
            SmogontabPage.PerformLayout();
            ResumeLayout(false);
        }

        private RichTextBox UrlBox;
        private RichTextBox PSBox;
        private Button LoadTeamFromPSCode_BTN;
        private Button ImportPKM_BTN;
        private TextBox ConditionBox;
        private Button ClearAllBox_BTN;
        private Button LoadBattleTeam_BTN;
        private CheckBox ChineseCheckBox;
        private TabControl BattleKingtabControl;
        private TabPage PStabPage;
        private TabPage WebtabPage;
        private TabPage SmogontabPage;
    }
}
