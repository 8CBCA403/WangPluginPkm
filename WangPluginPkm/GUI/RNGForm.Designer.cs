using System.Windows.Forms;

namespace WangPluginPkm.GUI
{
    partial class RNGForm
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RNGForm));
            Search = new Button();
            Cancel = new Button();
            UsePreSeed = new CheckBox();
            FastCheck_BTN = new Button();
            SearchGroupBox = new GroupBox();
            TeamLockBox = new CheckBox();
            ConditionForm = new WangPluginPkm.PkmCondition();
            MinIV_Box = new ComboBox();
            Gender_Box = new ComboBox();
            FlawlessIV = new Label();
            genderlabel = new Label();
            Ability_Box = new ComboBox();
            AbilityLabel = new Label();
            FixPidForTera_BTN = new Button();
            Legal_Check_BOX4 = new TextBox();
            Legal_Check_BOX3 = new TextBox();
            Legal_Check_BOX2 = new TextBox();
            Legal_Check_BOX1 = new TextBox();
            Seed_Box = new TextBox();
            Legal_Check_BOX5 = new TextBox();
            SeedBox = new TextBox();
            PIDBox = new TextBox();
            ReverseCheck_BTN = new Button();
            IVCheck_Box = new CheckBox();
            PIDECCheck_Box = new CheckBox();
            IVBox = new Label();
            IVTextBox = new TextBox();
            ECLabel = new Label();
            ECBox = new TextBox();
            Seedlabel = new Label();
            PIDlabel = new Label();
            Mlabel = new Label();
            Mod_ComboBox = new ComboBox();
            RNGFormTabControl = new TabControl();
            ReverseSeedPage = new TabPage();
            SWSHPage = new TabPage();
            SlowCheck = new Button();
            FixLairSeed = new Button();
            TeraSeedPage = new TabPage();
            RNGmenuStrip = new MenuStrip();
            ToolStripMenuItem = new ToolStripMenuItem();
            Seed_Label = new Label();
            SearchGroupBox.SuspendLayout();
            RNGFormTabControl.SuspendLayout();
            ReverseSeedPage.SuspendLayout();
            SWSHPage.SuspendLayout();
            TeraSeedPage.SuspendLayout();
            RNGmenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // Search
            // 
            Search.Location = new System.Drawing.Point(50, 192);
            Search.Name = "Search";
            Search.Size = new System.Drawing.Size(92, 25);
            Search.TabIndex = 9;
            Search.Text = "开始查找";
            Search.UseVisualStyleBackColor = true;
            Search.Click += Search_Click;
            // 
            // Cancel
            // 
            Cancel.Location = new System.Drawing.Point(178, 192);
            Cancel.Name = "Cancel";
            Cancel.Size = new System.Drawing.Size(92, 25);
            Cancel.TabIndex = 11;
            Cancel.Text = "停止查找";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // UsePreSeed
            // 
            UsePreSeed.AutoSize = true;
            UsePreSeed.Location = new System.Drawing.Point(6, 171);
            UsePreSeed.Name = "UsePreSeed";
            UsePreSeed.Size = new System.Drawing.Size(114, 21);
            UsePreSeed.TabIndex = 22;
            UsePreSeed.Text = "使用预设种子";
            UsePreSeed.UseVisualStyleBackColor = true;
            // 
            // FastCheck_BTN
            // 
            FastCheck_BTN.Location = new System.Drawing.Point(68, 160);
            FastCheck_BTN.Name = "FastCheck_BTN";
            FastCheck_BTN.Size = new System.Drawing.Size(124, 25);
            FastCheck_BTN.TabIndex = 23;
            FastCheck_BTN.Text = "快速检测(依赖Z3)";
            FastCheck_BTN.UseVisualStyleBackColor = true;
            FastCheck_BTN.Click += FastCheck_BTN_Click;
            // 
            // SearchGroupBox
            // 
            SearchGroupBox.Controls.Add(Cancel);
            SearchGroupBox.Controls.Add(TeamLockBox);
            SearchGroupBox.Controls.Add(Search);
            SearchGroupBox.Controls.Add(UsePreSeed);
            SearchGroupBox.Controls.Add(ConditionForm);
            SearchGroupBox.Location = new System.Drawing.Point(12, 31);
            SearchGroupBox.Name = "SearchGroupBox";
            SearchGroupBox.Size = new System.Drawing.Size(326, 223);
            SearchGroupBox.TabIndex = 24;
            SearchGroupBox.TabStop = false;
            SearchGroupBox.Text = "查找";
            // 
            // TeamLockBox
            // 
            TeamLockBox.AutoSize = true;
            TeamLockBox.Location = new System.Drawing.Point(138, 171);
            TeamLockBox.Name = "TeamLockBox";
            TeamLockBox.Size = new System.Drawing.Size(117, 21);
            TeamLockBox.TabIndex = 24;
            TeamLockBox.Text = "CXD使用队锁";
            TeamLockBox.UseVisualStyleBackColor = true;
            // 
            // ConditionForm
            // 
            ConditionForm.Location = new System.Drawing.Point(7, 14);
            ConditionForm.Margin = new Padding(2);
            ConditionForm.Name = "ConditionForm";
            ConditionForm.Size = new System.Drawing.Size(313, 186);
            ConditionForm.TabIndex = 23;
            // 
            // MinIV_Box
            // 
            MinIV_Box.FormattingEnabled = true;
            MinIV_Box.Location = new System.Drawing.Point(87, 37);
            MinIV_Box.Name = "MinIV_Box";
            MinIV_Box.Size = new System.Drawing.Size(105, 25);
            MinIV_Box.TabIndex = 25;
            // 
            // Gender_Box
            // 
            Gender_Box.FormattingEnabled = true;
            Gender_Box.Location = new System.Drawing.Point(100, 67);
            Gender_Box.Name = "Gender_Box";
            Gender_Box.Size = new System.Drawing.Size(92, 25);
            Gender_Box.TabIndex = 26;
            // 
            // FlawlessIV
            // 
            FlawlessIV.AutoSize = true;
            FlawlessIV.Location = new System.Drawing.Point(52, 40);
            FlawlessIV.Name = "FlawlessIV";
            FlawlessIV.Size = new System.Drawing.Size(34, 17);
            FlawlessIV.TabIndex = 27;
            FlawlessIV.Text = "锁IV";
            // 
            // genderlabel
            // 
            genderlabel.AutoSize = true;
            genderlabel.Location = new System.Drawing.Point(53, 71);
            genderlabel.Name = "genderlabel";
            genderlabel.Size = new System.Drawing.Size(50, 17);
            genderlabel.TabIndex = 28;
            genderlabel.Text = "公母比";
            // 
            // Ability_Box
            // 
            Ability_Box.FormattingEnabled = true;
            Ability_Box.Location = new System.Drawing.Point(87, 98);
            Ability_Box.Name = "Ability_Box";
            Ability_Box.Size = new System.Drawing.Size(105, 25);
            Ability_Box.TabIndex = 29;
            // 
            // AbilityLabel
            // 
            AbilityLabel.AutoSize = true;
            AbilityLabel.Location = new System.Drawing.Point(53, 101);
            AbilityLabel.Name = "AbilityLabel";
            AbilityLabel.Size = new System.Drawing.Size(36, 17);
            AbilityLabel.TabIndex = 30;
            AbilityLabel.Text = "特性";
            // 
            // FixPidForTera_BTN
            // 
            FixPidForTera_BTN.Location = new System.Drawing.Point(113, 149);
            FixPidForTera_BTN.Name = "FixPidForTera_BTN";
            FixPidForTera_BTN.Size = new System.Drawing.Size(159, 25);
            FixPidForTera_BTN.TabIndex = 36;
            FixPidForTera_BTN.Text = "修正太晶坑闪光PID";
            FixPidForTera_BTN.UseVisualStyleBackColor = true;
            FixPidForTera_BTN.Click += GetSeedForMaxLair_BTN_Click;
            // 
            // Legal_Check_BOX4
            // 
            Legal_Check_BOX4.Cursor = Cursors.No;
            Legal_Check_BOX4.Location = new System.Drawing.Point(198, 98);
            Legal_Check_BOX4.Multiline = true;
            Legal_Check_BOX4.Name = "Legal_Check_BOX4";
            Legal_Check_BOX4.Size = new System.Drawing.Size(124, 25);
            Legal_Check_BOX4.TabIndex = 34;
            Legal_Check_BOX4.Text = "无事可做";
            // 
            // Legal_Check_BOX3
            // 
            Legal_Check_BOX3.Cursor = Cursors.No;
            Legal_Check_BOX3.Location = new System.Drawing.Point(198, 67);
            Legal_Check_BOX3.Multiline = true;
            Legal_Check_BOX3.Name = "Legal_Check_BOX3";
            Legal_Check_BOX3.Size = new System.Drawing.Size(124, 25);
            Legal_Check_BOX3.TabIndex = 33;
            Legal_Check_BOX3.Text = "无事可做";
            // 
            // Legal_Check_BOX2
            // 
            Legal_Check_BOX2.Cursor = Cursors.No;
            Legal_Check_BOX2.Location = new System.Drawing.Point(198, 36);
            Legal_Check_BOX2.Multiline = true;
            Legal_Check_BOX2.Name = "Legal_Check_BOX2";
            Legal_Check_BOX2.Size = new System.Drawing.Size(124, 25);
            Legal_Check_BOX2.TabIndex = 32;
            Legal_Check_BOX2.Text = "无事可做";
            // 
            // Legal_Check_BOX1
            // 
            Legal_Check_BOX1.Cursor = Cursors.No;
            Legal_Check_BOX1.Location = new System.Drawing.Point(198, 6);
            Legal_Check_BOX1.Multiline = true;
            Legal_Check_BOX1.Name = "Legal_Check_BOX1";
            Legal_Check_BOX1.Size = new System.Drawing.Size(124, 25);
            Legal_Check_BOX1.TabIndex = 31;
            Legal_Check_BOX1.Text = "无事可做";
            // 
            // Seed_Box
            // 
            Seed_Box.Location = new System.Drawing.Point(52, 6);
            Seed_Box.Multiline = true;
            Seed_Box.Name = "Seed_Box";
            Seed_Box.Size = new System.Drawing.Size(140, 25);
            Seed_Box.TabIndex = 23;
            Seed_Box.Text = "没有seed";
            // 
            // Legal_Check_BOX5
            // 
            Legal_Check_BOX5.Cursor = Cursors.No;
            Legal_Check_BOX5.Location = new System.Drawing.Point(198, 129);
            Legal_Check_BOX5.Multiline = true;
            Legal_Check_BOX5.Name = "Legal_Check_BOX5";
            Legal_Check_BOX5.Size = new System.Drawing.Size(124, 25);
            Legal_Check_BOX5.TabIndex = 35;
            Legal_Check_BOX5.Text = "无事可做";
            // 
            // SeedBox
            // 
            SeedBox.Location = new System.Drawing.Point(236, 82);
            SeedBox.Multiline = true;
            SeedBox.Name = "SeedBox";
            SeedBox.ScrollBars = ScrollBars.Vertical;
            SeedBox.Size = new System.Drawing.Size(124, 83);
            SeedBox.TabIndex = 38;
            // 
            // PIDBox
            // 
            PIDBox.Location = new System.Drawing.Point(236, 17);
            PIDBox.Name = "PIDBox";
            PIDBox.Size = new System.Drawing.Size(124, 25);
            PIDBox.TabIndex = 37;
            // 
            // ReverseCheck_BTN
            // 
            ReverseCheck_BTN.Location = new System.Drawing.Point(58, 139);
            ReverseCheck_BTN.Name = "ReverseCheck_BTN";
            ReverseCheck_BTN.Size = new System.Drawing.Size(124, 25);
            ReverseCheck_BTN.TabIndex = 25;
            ReverseCheck_BTN.Text = "开始查找";
            ReverseCheck_BTN.UseVisualStyleBackColor = true;
            ReverseCheck_BTN.Click += ReverseCheck_BTN_Click;
            // 
            // IVCheck_Box
            // 
            IVCheck_Box.AutoSize = true;
            IVCheck_Box.Enabled = false;
            IVCheck_Box.Location = new System.Drawing.Point(58, 111);
            IVCheck_Box.Name = "IVCheck_Box";
            IVCheck_Box.Size = new System.Drawing.Size(98, 21);
            IVCheck_Box.TabIndex = 44;
            IVCheck_Box.Text = "使用IV反推";
            IVCheck_Box.UseVisualStyleBackColor = true;
            IVCheck_Box.CheckedChanged += IVCheck_Box_CheckedChanged;
            // 
            // PIDECCheck_Box
            // 
            PIDECCheck_Box.AutoSize = true;
            PIDECCheck_Box.Checked = true;
            PIDECCheck_Box.CheckState = CheckState.Checked;
            PIDECCheck_Box.Location = new System.Drawing.Point(58, 85);
            PIDECCheck_Box.Name = "PIDECCheck_Box";
            PIDECCheck_Box.Size = new System.Drawing.Size(110, 21);
            PIDECCheck_Box.TabIndex = 25;
            PIDECCheck_Box.Text = "使用PID反推";
            PIDECCheck_Box.UseVisualStyleBackColor = true;
            PIDECCheck_Box.CheckedChanged += PIDECCheck_Box_CheckedChanged;
            // 
            // IVBox
            // 
            IVBox.AutoSize = true;
            IVBox.Location = new System.Drawing.Point(55, 54);
            IVBox.Name = "IVBox";
            IVBox.Size = new System.Drawing.Size(20, 17);
            IVBox.TabIndex = 43;
            IVBox.Text = "IV";
            // 
            // IVTextBox
            // 
            IVTextBox.Enabled = false;
            IVTextBox.Location = new System.Drawing.Point(81, 51);
            IVTextBox.Name = "IVTextBox";
            IVTextBox.Size = new System.Drawing.Size(124, 25);
            IVTextBox.TabIndex = 42;
            // 
            // ECLabel
            // 
            ECLabel.AutoSize = true;
            ECLabel.Location = new System.Drawing.Point(210, 54);
            ECLabel.Name = "ECLabel";
            ECLabel.Size = new System.Drawing.Size(29, 17);
            ECLabel.TabIndex = 41;
            ECLabel.Text = "EC";
            // 
            // ECBox
            // 
            ECBox.Enabled = false;
            ECBox.Location = new System.Drawing.Point(236, 51);
            ECBox.Name = "ECBox";
            ECBox.Size = new System.Drawing.Size(124, 25);
            ECBox.TabIndex = 40;
            // 
            // Seedlabel
            // 
            Seedlabel.AutoSize = true;
            Seedlabel.Location = new System.Drawing.Point(197, 85);
            Seedlabel.Name = "Seedlabel";
            Seedlabel.Size = new System.Drawing.Size(42, 17);
            Seedlabel.TabIndex = 39;
            Seedlabel.Text = "Seed";
            // 
            // PIDlabel
            // 
            PIDlabel.AutoSize = true;
            PIDlabel.Location = new System.Drawing.Point(207, 22);
            PIDlabel.Name = "PIDlabel";
            PIDlabel.Size = new System.Drawing.Size(32, 17);
            PIDlabel.TabIndex = 37;
            PIDlabel.Text = "PID";
            // 
            // Mlabel
            // 
            Mlabel.AutoSize = true;
            Mlabel.Location = new System.Drawing.Point(19, 22);
            Mlabel.Name = "Mlabel";
            Mlabel.Size = new System.Drawing.Size(64, 17);
            Mlabel.TabIndex = 37;
            Mlabel.Text = "模式选择";
            // 
            // Mod_ComboBox
            // 
            Mod_ComboBox.FormattingEnabled = true;
            Mod_ComboBox.Location = new System.Drawing.Point(80, 17);
            Mod_ComboBox.Name = "Mod_ComboBox";
            Mod_ComboBox.Size = new System.Drawing.Size(124, 25);
            Mod_ComboBox.TabIndex = 37;
            // 
            // RNGFormTabControl
            // 
            RNGFormTabControl.Controls.Add(ReverseSeedPage);
            RNGFormTabControl.Controls.Add(SWSHPage);
            RNGFormTabControl.Controls.Add(TeraSeedPage);
            RNGFormTabControl.Location = new System.Drawing.Point(344, 31);
            RNGFormTabControl.Name = "RNGFormTabControl";
            RNGFormTabControl.SelectedIndex = 0;
            RNGFormTabControl.Size = new System.Drawing.Size(393, 223);
            RNGFormTabControl.TabIndex = 45;
            // 
            // ReverseSeedPage
            // 
            ReverseSeedPage.BackColor = System.Drawing.Color.WhiteSmoke;
            ReverseSeedPage.Controls.Add(IVCheck_Box);
            ReverseSeedPage.Controls.Add(SeedBox);
            ReverseSeedPage.Controls.Add(PIDECCheck_Box);
            ReverseSeedPage.Controls.Add(PIDBox);
            ReverseSeedPage.Controls.Add(IVBox);
            ReverseSeedPage.Controls.Add(ReverseCheck_BTN);
            ReverseSeedPage.Controls.Add(IVTextBox);
            ReverseSeedPage.Controls.Add(Mod_ComboBox);
            ReverseSeedPage.Controls.Add(ECLabel);
            ReverseSeedPage.Controls.Add(Mlabel);
            ReverseSeedPage.Controls.Add(ECBox);
            ReverseSeedPage.Controls.Add(PIDlabel);
            ReverseSeedPage.Controls.Add(Seedlabel);
            ReverseSeedPage.Location = new System.Drawing.Point(4, 26);
            ReverseSeedPage.Name = "ReverseSeedPage";
            ReverseSeedPage.Padding = new Padding(3);
            ReverseSeedPage.Size = new System.Drawing.Size(385, 193);
            ReverseSeedPage.TabIndex = 0;
            ReverseSeedPage.Text = "Seed逆推";
            // 
            // SWSHPage
            // 
            SWSHPage.BackColor = System.Drawing.Color.WhiteSmoke;
            SWSHPage.Controls.Add(Seed_Label);
            SWSHPage.Controls.Add(SlowCheck);
            SWSHPage.Controls.Add(FixLairSeed);
            SWSHPage.Controls.Add(FastCheck_BTN);
            SWSHPage.Controls.Add(Legal_Check_BOX5);
            SWSHPage.Controls.Add(Legal_Check_BOX4);
            SWSHPage.Controls.Add(MinIV_Box);
            SWSHPage.Controls.Add(Legal_Check_BOX3);
            SWSHPage.Controls.Add(Gender_Box);
            SWSHPage.Controls.Add(Legal_Check_BOX2);
            SWSHPage.Controls.Add(FlawlessIV);
            SWSHPage.Controls.Add(Legal_Check_BOX1);
            SWSHPage.Controls.Add(genderlabel);
            SWSHPage.Controls.Add(Seed_Box);
            SWSHPage.Controls.Add(Ability_Box);
            SWSHPage.Controls.Add(AbilityLabel);
            SWSHPage.Location = new System.Drawing.Point(4, 26);
            SWSHPage.Name = "SWSHPage";
            SWSHPage.Padding = new Padding(3);
            SWSHPage.Size = new System.Drawing.Size(385, 193);
            SWSHPage.TabIndex = 1;
            SWSHPage.Text = "剑盾Raid检测";
            // 
            // SlowCheck
            // 
            SlowCheck.Location = new System.Drawing.Point(198, 160);
            SlowCheck.Name = "SlowCheck";
            SlowCheck.Size = new System.Drawing.Size(124, 25);
            SlowCheck.TabIndex = 48;
            SlowCheck.Text = "慢速检测";
            SlowCheck.UseVisualStyleBackColor = true;
            SlowCheck.Click += SlowCheck_BTN_Click;
            // 
            // FixLairSeed
            // 
            FixLairSeed.Location = new System.Drawing.Point(68, 129);
            FixLairSeed.Name = "FixLairSeed";
            FixLairSeed.Size = new System.Drawing.Size(124, 25);
            FixLairSeed.TabIndex = 47;
            FixLairSeed.Text = "修正大冒险seed";
            FixLairSeed.UseVisualStyleBackColor = true;
            FixLairSeed.Click += FixLairSeed_Click;
            // 
            // TeraSeedPage
            // 
            TeraSeedPage.BackColor = System.Drawing.Color.WhiteSmoke;
            TeraSeedPage.Controls.Add(FixPidForTera_BTN);
            TeraSeedPage.Location = new System.Drawing.Point(4, 29);
            TeraSeedPage.Name = "TeraSeedPage";
            TeraSeedPage.Padding = new Padding(3);
            TeraSeedPage.Size = new System.Drawing.Size(385, 190);
            TeraSeedPage.TabIndex = 2;
            TeraSeedPage.Text = "朱紫太晶坑Seed";
            // 
            // RNGmenuStrip
            // 
            RNGmenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            RNGmenuStrip.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem });
            RNGmenuStrip.Location = new System.Drawing.Point(0, 0);
            RNGmenuStrip.Name = "RNGmenuStrip";
            RNGmenuStrip.Size = new System.Drawing.Size(752, 28);
            RNGmenuStrip.TabIndex = 46;
            RNGmenuStrip.Text = "menuStrip1";
            // 
            // ToolStripMenuItem
            // 
            ToolStripMenuItem.Name = "ToolStripMenuItem";
            ToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            ToolStripMenuItem.Text = "使用说明";
            ToolStripMenuItem.Click += ToolStripMenuItem_Click;
            // 
            // Seed_Label
            // 
            Seed_Label.AutoSize = true;
            Seed_Label.Location = new System.Drawing.Point(6, 9);
            Seed_Label.Name = "Seed_Label";
            Seed_Label.Size = new System.Drawing.Size(42, 17);
            Seed_Label.TabIndex = 47;
            Seed_Label.Text = "Seed";
            // 
            // RNGForm
            // 
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(752, 264);
            Controls.Add(RNGFormTabControl);
            Controls.Add(SearchGroupBox);
            Controls.Add(RNGmenuStrip);
            Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "RNGForm";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Super Wang";
            SearchGroupBox.ResumeLayout(false);
            SearchGroupBox.PerformLayout();
            RNGFormTabControl.ResumeLayout(false);
            ReverseSeedPage.ResumeLayout(false);
            ReverseSeedPage.PerformLayout();
            SWSHPage.ResumeLayout(false);
            SWSHPage.PerformLayout();
            TeraSeedPage.ResumeLayout(false);
            RNGmenuStrip.ResumeLayout(false);
            RNGmenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button Search;
        private Button Cancel;
        private CheckBox UsePreSeed;
        private Button FastCheck_BTN;
        private GroupBox SearchGroupBox;
        private ComboBox MinIV_Box;
        private ComboBox Gender_Box;
        private Label FlawlessIV;
        private Label genderlabel;
        private ComboBox Ability_Box;
        private Label AbilityLabel;
        private TextBox Seed_Box;
        private TextBox Legal_Check_BOX1;
        private TextBox Legal_Check_BOX4;
        private TextBox Legal_Check_BOX3;
        private TextBox Legal_Check_BOX2;
        private TextBox Legal_Check_BOX5;
        private Button FixPidForTera_BTN;
        private CheckBox TeamLockBox;
        private TextBox PIDBox;
        private Button ReverseCheck_BTN;
        private TextBox SeedBox;
        private ComboBox Mod_ComboBox;
        private Label Seedlabel;
        private Label PIDlabel;
        private Label Mlabel;
        private Label ECLabel;
        private TextBox ECBox;
        private CheckBox IVCheck_Box;
        private CheckBox PIDECCheck_Box;
        private Label IVBox;
        private TextBox IVTextBox;
        private WangPluginPkm.PkmCondition ConditionForm;
        private TabControl RNGFormTabControl;
        private TabPage ReverseSeedPage;
        private TabPage SWSHPage;
        private MenuStrip RNGmenuStrip;
        private ToolStripMenuItem ToolStripMenuItem;
        private TabPage TeraSeedPage;
        private Button FixLairSeed;
        private Button SlowCheck;
        private Label Seed_Label;
    }
}
