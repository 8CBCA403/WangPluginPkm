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
            STtabPage = new TabPage();
            VGCPaste_GB = new GroupBox();
            CVGC_BTN = new Button();
            VGCExcel_CB = new ComboBox();
            ApplicationName_LB = new Label();
            GoogleApiKeyLB = new Label();
            GoogleApiKey_TB = new TextBox();
            VGCPaste_TB = new TextBox();
            ApplicationName_TB = new TextBox();
            VGCPastes_BTN = new Button();
            MT_Box = new GroupBox();
            Web_CB = new ComboBox();
            ImportURL_text = new TextBox();
            C_BTN = new Button();
            MT_BTN = new Button();
            CB = new ComboBox();
            SmogonGroup = new GroupBox();
            VGC_Check = new TabPage();
            Helper_TB = new TextBox();
            ResultBox = new TextBox();
            TEST_BTN = new Button();
            TeamList_BOX = new CheckedListBox();
            BattleKingtabControl.SuspendLayout();
            PStabPage.SuspendLayout();
            WebtabPage.SuspendLayout();
            STtabPage.SuspendLayout();
            VGCPaste_GB.SuspendLayout();
            MT_Box.SuspendLayout();
            SmogonGroup.SuspendLayout();
            VGC_Check.SuspendLayout();
            SuspendLayout();
            // 
            // LoadBattleTeam_BTN
            // 
            LoadBattleTeam_BTN.Font = new System.Drawing.Font("黑体", 9F);
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
            LoadTeamFromPSCode_BTN.Font = new System.Drawing.Font("黑体", 9F);
            LoadTeamFromPSCode_BTN.Location = new System.Drawing.Point(172, 299);
            LoadTeamFromPSCode_BTN.Name = "LoadTeamFromPSCode_BTN";
            LoadTeamFromPSCode_BTN.Size = new System.Drawing.Size(197, 32);
            LoadTeamFromPSCode_BTN.TabIndex = 4;
            LoadTeamFromPSCode_BTN.Text = "从Showdown批量导入";
            LoadTeamFromPSCode_BTN.UseVisualStyleBackColor = true;
            LoadTeamFromPSCode_BTN.Click += LoadTeamFromPSCode_BTN_Click;
            // 
            // ImportPKM_BTN
            // 
            ImportPKM_BTN.Font = new System.Drawing.Font("黑体", 9F);
            ImportPKM_BTN.Location = new System.Drawing.Point(6, 53);
            ImportPKM_BTN.Name = "ImportPKM_BTN";
            ImportPKM_BTN.Size = new System.Drawing.Size(170, 24);
            ImportPKM_BTN.TabIndex = 5;
            ImportPKM_BTN.TabStop = false;
            ImportPKM_BTN.Text = "从文件导入smogon策略";
            ImportPKM_BTN.UseVisualStyleBackColor = true;
            ImportPKM_BTN.Click += ImportPKM_BTN_Click;
            // 
            // ConditionBox
            // 
            ConditionBox.Location = new System.Drawing.Point(6, 20);
            ConditionBox.Name = "ConditionBox";
            ConditionBox.Size = new System.Drawing.Size(171, 21);
            ConditionBox.TabIndex = 6;
            ConditionBox.Text = "Nothing to check";
            // 
            // ClearAllBox_BTN
            // 
            ClearAllBox_BTN.Font = new System.Drawing.Font("黑体", 9F);
            ClearAllBox_BTN.Location = new System.Drawing.Point(6, 87);
            ClearAllBox_BTN.Name = "ClearAllBox_BTN";
            ClearAllBox_BTN.Size = new System.Drawing.Size(170, 24);
            ClearAllBox_BTN.TabIndex = 7;
            ClearAllBox_BTN.Text = "清除全部盒子";
            ClearAllBox_BTN.UseVisualStyleBackColor = true;
            ClearAllBox_BTN.Click += ClearAllBox_BTN_Click;
            // 
            // ChineseCheckBox
            // 
            ChineseCheckBox.AutoSize = true;
            ChineseCheckBox.Location = new System.Drawing.Point(71, 308);
            ChineseCheckBox.Name = "ChineseCheckBox";
            ChineseCheckBox.Size = new System.Drawing.Size(72, 16);
            ChineseCheckBox.TabIndex = 8;
            ChineseCheckBox.Text = "中文指令";
            ChineseCheckBox.UseVisualStyleBackColor = true;
            // 
            // BattleKingtabControl
            // 
            BattleKingtabControl.Controls.Add(PStabPage);
            BattleKingtabControl.Controls.Add(WebtabPage);
            BattleKingtabControl.Controls.Add(STtabPage);
            BattleKingtabControl.Controls.Add(VGC_Check);
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
            PStabPage.Location = new System.Drawing.Point(4, 22);
            PStabPage.Name = "PStabPage";
            PStabPage.Padding = new Padding(3);
            PStabPage.Size = new System.Drawing.Size(528, 351);
            PStabPage.TabIndex = 0;
            PStabPage.Text = "PS指令模式";
            // 
            // WebtabPage
            // 
            WebtabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            WebtabPage.Controls.Add(UrlBox);
            WebtabPage.Controls.Add(LoadBattleTeam_BTN);
            WebtabPage.Location = new System.Drawing.Point(4, 26);
            WebtabPage.Name = "WebtabPage";
            WebtabPage.Padding = new Padding(3);
            WebtabPage.Size = new System.Drawing.Size(528, 347);
            WebtabPage.TabIndex = 1;
            WebtabPage.Text = "网址模式";
            // 
            // STtabPage
            // 
            STtabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            STtabPage.Controls.Add(VGCPaste_GB);
            STtabPage.Controls.Add(MT_Box);
            STtabPage.Controls.Add(SmogonGroup);
            STtabPage.Location = new System.Drawing.Point(4, 22);
            STtabPage.Name = "STtabPage";
            STtabPage.Padding = new Padding(3);
            STtabPage.Size = new System.Drawing.Size(528, 351);
            STtabPage.TabIndex = 2;
            STtabPage.Text = "策略爬取";
            // 
            // VGCPaste_GB
            // 
            VGCPaste_GB.Controls.Add(CVGC_BTN);
            VGCPaste_GB.Controls.Add(VGCExcel_CB);
            VGCPaste_GB.Controls.Add(ApplicationName_LB);
            VGCPaste_GB.Controls.Add(GoogleApiKeyLB);
            VGCPaste_GB.Controls.Add(GoogleApiKey_TB);
            VGCPaste_GB.Controls.Add(VGCPaste_TB);
            VGCPaste_GB.Controls.Add(ApplicationName_TB);
            VGCPaste_GB.Controls.Add(VGCPastes_BTN);
            VGCPaste_GB.Location = new System.Drawing.Point(6, 137);
            VGCPaste_GB.Name = "VGCPaste_GB";
            VGCPaste_GB.Size = new System.Drawing.Size(516, 208);
            VGCPaste_GB.TabIndex = 19;
            VGCPaste_GB.TabStop = false;
            VGCPaste_GB.Text = "神偷-VGCPaste";
            // 
            // CVGC_BTN
            // 
            CVGC_BTN.Location = new System.Drawing.Point(6, 104);
            CVGC_BTN.Name = "CVGC_BTN";
            CVGC_BTN.Size = new System.Drawing.Size(95, 23);
            CVGC_BTN.TabIndex = 21;
            CVGC_BTN.Text = "同步表格信息";
            CVGC_BTN.UseVisualStyleBackColor = true;
            CVGC_BTN.Click += CVGC_BTN_Click;
            // 
            // VGCExcel_CB
            // 
            VGCExcel_CB.FormattingEnabled = true;
            VGCExcel_CB.Location = new System.Drawing.Point(6, 78);
            VGCExcel_CB.Name = "VGCExcel_CB";
            VGCExcel_CB.Size = new System.Drawing.Size(194, 20);
            VGCExcel_CB.TabIndex = 15;
            // 
            // ApplicationName_LB
            // 
            ApplicationName_LB.AutoSize = true;
            ApplicationName_LB.Location = new System.Drawing.Point(6, 50);
            ApplicationName_LB.Name = "ApplicationName_LB";
            ApplicationName_LB.Size = new System.Drawing.Size(95, 12);
            ApplicationName_LB.TabIndex = 20;
            ApplicationName_LB.Text = "ApplicationName";
            // 
            // GoogleApiKeyLB
            // 
            GoogleApiKeyLB.AutoSize = true;
            GoogleApiKeyLB.Location = new System.Drawing.Point(6, 23);
            GoogleApiKeyLB.Name = "GoogleApiKeyLB";
            GoogleApiKeyLB.Size = new System.Drawing.Size(77, 12);
            GoogleApiKeyLB.TabIndex = 19;
            GoogleApiKeyLB.Text = "GoogleApiKey";
            // 
            // GoogleApiKey_TB
            // 
            GoogleApiKey_TB.Location = new System.Drawing.Point(89, 20);
            GoogleApiKey_TB.Name = "GoogleApiKey_TB";
            GoogleApiKey_TB.Size = new System.Drawing.Size(111, 21);
            GoogleApiKey_TB.TabIndex = 17;
            GoogleApiKey_TB.Text = "AIzaSyBMFP7HlaUt9ZMr7NhapA0X1NBYy4vqcJY";
            // 
            // VGCPaste_TB
            // 
            VGCPaste_TB.Location = new System.Drawing.Point(206, 20);
            VGCPaste_TB.Multiline = true;
            VGCPaste_TB.Name = "VGCPaste_TB";
            VGCPaste_TB.ScrollBars = ScrollBars.Vertical;
            VGCPaste_TB.Size = new System.Drawing.Size(304, 182);
            VGCPaste_TB.TabIndex = 15;
            // 
            // ApplicationName_TB
            // 
            ApplicationName_TB.Location = new System.Drawing.Point(107, 47);
            ApplicationName_TB.Name = "ApplicationName_TB";
            ApplicationName_TB.Size = new System.Drawing.Size(93, 21);
            ApplicationName_TB.TabIndex = 18;
            ApplicationName_TB.Text = "silicon-park-409723";
            // 
            // VGCPastes_BTN
            // 
            VGCPastes_BTN.Location = new System.Drawing.Point(107, 104);
            VGCPastes_BTN.Name = "VGCPastes_BTN";
            VGCPastes_BTN.Size = new System.Drawing.Size(93, 23);
            VGCPastes_BTN.TabIndex = 16;
            VGCPastes_BTN.Text = "启动VGCPastes";
            VGCPastes_BTN.UseVisualStyleBackColor = true;
            VGCPastes_BTN.Click += VGCPastes_Click;
            // 
            // MT_Box
            // 
            MT_Box.Controls.Add(Web_CB);
            MT_Box.Controls.Add(ImportURL_text);
            MT_Box.Controls.Add(C_BTN);
            MT_Box.Controls.Add(MT_BTN);
            MT_Box.Controls.Add(CB);
            MT_Box.Location = new System.Drawing.Point(199, 6);
            MT_Box.Name = "MT_Box";
            MT_Box.Size = new System.Drawing.Size(323, 125);
            MT_Box.TabIndex = 9;
            MT_Box.TabStop = false;
            MT_Box.Text = "神偷-阵列兵";
            // 
            // Web_CB
            // 
            Web_CB.FormattingEnabled = true;
            Web_CB.Location = new System.Drawing.Point(6, 20);
            Web_CB.Name = "Web_CB";
            Web_CB.Size = new System.Drawing.Size(85, 20);
            Web_CB.TabIndex = 14;
            // 
            // ImportURL_text
            // 
            ImportURL_text.Location = new System.Drawing.Point(97, 20);
            ImportURL_text.Name = "ImportURL_text";
            ImportURL_text.Size = new System.Drawing.Size(220, 21);
            ImportURL_text.TabIndex = 13;
            ImportURL_text.Text = "https://www.falinks-teambuilder.com/";
            // 
            // C_BTN
            // 
            C_BTN.Font = new System.Drawing.Font("黑体", 9F);
            C_BTN.Location = new System.Drawing.Point(29, 87);
            C_BTN.Name = "C_BTN";
            C_BTN.Size = new System.Drawing.Size(134, 24);
            C_BTN.TabIndex = 11;
            C_BTN.Text = "同步网页信息";
            C_BTN.UseVisualStyleBackColor = true;
            C_BTN.Click += C_BTN_Click;
            // 
            // MT_BTN
            // 
            MT_BTN.Font = new System.Drawing.Font("黑体", 9F);
            MT_BTN.Location = new System.Drawing.Point(169, 87);
            MT_BTN.Name = "MT_BTN";
            MT_BTN.Size = new System.Drawing.Size(134, 24);
            MT_BTN.TabIndex = 8;
            MT_BTN.Text = "开偷！";
            MT_BTN.UseVisualStyleBackColor = true;
            MT_BTN.Click += MT_BTN_ClickAsync;
            // 
            // CB
            // 
            CB.FormattingEnabled = true;
            CB.Location = new System.Drawing.Point(6, 53);
            CB.Name = "CB";
            CB.Size = new System.Drawing.Size(311, 20);
            CB.TabIndex = 12;
            // 
            // SmogonGroup
            // 
            SmogonGroup.Controls.Add(ConditionBox);
            SmogonGroup.Controls.Add(ImportPKM_BTN);
            SmogonGroup.Controls.Add(ClearAllBox_BTN);
            SmogonGroup.Location = new System.Drawing.Point(6, 6);
            SmogonGroup.Name = "SmogonGroup";
            SmogonGroup.Size = new System.Drawing.Size(187, 125);
            SmogonGroup.TabIndex = 8;
            SmogonGroup.TabStop = false;
            SmogonGroup.Text = "Smogon";
            // 
            // VGC_Check
            // 
            VGC_Check.BackColor = System.Drawing.Color.WhiteSmoke;
            VGC_Check.Controls.Add(Helper_TB);
            VGC_Check.Controls.Add(ResultBox);
            VGC_Check.Controls.Add(TEST_BTN);
            VGC_Check.Controls.Add(TeamList_BOX);
            VGC_Check.Location = new System.Drawing.Point(4, 26);
            VGC_Check.Name = "VGC_Check";
            VGC_Check.Padding = new Padding(3);
            VGC_Check.Size = new System.Drawing.Size(528, 347);
            VGC_Check.TabIndex = 3;
            VGC_Check.Text = "VGC队伍检测";
            // 
            // Helper_TB
            // 
            Helper_TB.Font = new System.Drawing.Font("黑体", 9F);
            Helper_TB.Location = new System.Drawing.Point(6, 6);
            Helper_TB.Name = "Helper_TB";
            Helper_TB.Size = new System.Drawing.Size(192, 21);
            Helper_TB.TabIndex = 3;
            Helper_TB.Text = "请将有6只精灵的bin文件拖入下方";
            // 
            // ResultBox
            // 
            ResultBox.Location = new System.Drawing.Point(204, 6);
            ResultBox.Multiline = true;
            ResultBox.Name = "ResultBox";
            ResultBox.Size = new System.Drawing.Size(318, 336);
            ResultBox.TabIndex = 2;
            // 
            // TEST_BTN
            // 
            TEST_BTN.Location = new System.Drawing.Point(6, 311);
            TEST_BTN.Name = "TEST_BTN";
            TEST_BTN.Size = new System.Drawing.Size(192, 34);
            TEST_BTN.TabIndex = 1;
            TEST_BTN.Text = "检测";
            TEST_BTN.UseVisualStyleBackColor = true;
            TEST_BTN.Click += TEST_BTN_Click;
            // 
            // TeamList_BOX
            // 
            TeamList_BOX.AllowDrop = true;
            TeamList_BOX.BackColor = System.Drawing.SystemColors.Window;
            TeamList_BOX.FormattingEnabled = true;
            TeamList_BOX.Location = new System.Drawing.Point(6, 33);
            TeamList_BOX.Name = "TeamList_BOX";
            TeamList_BOX.Size = new System.Drawing.Size(192, 276);
            TeamList_BOX.TabIndex = 0;
            TeamList_BOX.DragDrop += PKM_DragDrop;
            TeamList_BOX.DragEnter += PKM_DragEnter;
            // 
            // BattleKingUI
            // 
            ClientSize = new System.Drawing.Size(559, 402);
            Controls.Add(BattleKingtabControl);
            Font = new System.Drawing.Font("黑体", 9F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "BattleKingUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Super Wang";
            BattleKingtabControl.ResumeLayout(false);
            PStabPage.ResumeLayout(false);
            PStabPage.PerformLayout();
            WebtabPage.ResumeLayout(false);
            STtabPage.ResumeLayout(false);
            VGCPaste_GB.ResumeLayout(false);
            VGCPaste_GB.PerformLayout();
            MT_Box.ResumeLayout(false);
            MT_Box.PerformLayout();
            SmogonGroup.ResumeLayout(false);
            SmogonGroup.PerformLayout();
            VGC_Check.ResumeLayout(false);
            VGC_Check.PerformLayout();
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
        private TabPage STtabPage;
        private TabPage VGC_Check;
        private CheckedListBox TeamList_BOX;
        private Button TEST_BTN;
        private TextBox ResultBox;
        private TextBox Helper_TB;
        private GroupBox MT_Box;
        private Button MT_BTN;
        private GroupBox SmogonGroup;
        private Button C_BTN;
        private ComboBox CB;
        private TextBox ImportURL_text;
        private ComboBox Web_CB;
        private TextBox VGCPaste_TB;
        private Button VGCPastes_BTN;
        private GroupBox VGCPaste_GB;
        private TextBox GoogleApiKey_TB;
        private TextBox ApplicationName_TB;
        private Label GoogleApiKeyLB;
        private Label ApplicationName_LB;
        private ComboBox VGCExcel_CB;
        private Button CVGC_BTN;
    }
}
