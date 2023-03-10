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
            Seed_Label = new Label();
            SlowCheck = new Button();
            FixLairSeed = new Button();
            TeraSeedPage = new TabPage();
            AbilitytextBox = new TextBox();
            Gen9IvcomboBox = new ComboBox();
            numHeight = new NumericUpDown();
            CheckTeraSeed_BTN = new Button();
            numScale = new NumericUpDown();
            label5 = new Label();
            label2 = new Label();
            lblScale = new Label();
            txtPID = new TextBox();
            GendertextBox = new TextBox();
            lblNature = new Label();
            numWeight = new NumericUpDown();
            Gen9AbilitycomboBox = new ComboBox();
            lblHeight = new Label();
            label3 = new Label();
            lblWeight = new Label();
            Tera9genderComboBox = new ComboBox();
            label1 = new Label();
            lblPID = new Label();
            txtEC = new TextBox();
            cmbNature = new ComboBox();
            IVstextBox = new TextBox();
            label4 = new Label();
            IVlabel = new Label();
            TeraSeedBox = new TextBox();
            label = new Label();
            lblEC = new Label();
            RNGmenuStrip = new MenuStrip();
            ToolStripMenuItem = new ToolStripMenuItem();
            SearchGroupBox.SuspendLayout();
            RNGFormTabControl.SuspendLayout();
            ReverseSeedPage.SuspendLayout();
            SWSHPage.SuspendLayout();
            TeraSeedPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numScale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWeight).BeginInit();
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
            FixPidForTera_BTN.Location = new System.Drawing.Point(175, 166);
            FixPidForTera_BTN.Name = "FixPidForTera_BTN";
            FixPidForTera_BTN.Size = new System.Drawing.Size(111, 25);
            FixPidForTera_BTN.TabIndex = 36;
            FixPidForTera_BTN.Text = "修正PID";
            FixPidForTera_BTN.UseVisualStyleBackColor = true;
            FixPidForTera_BTN.Click += FixPidForTera_BTN_Click;
            // 
            // Legal_Check_BOX4
            // 
            Legal_Check_BOX4.Cursor = Cursors.No;
            Legal_Check_BOX4.Location = new System.Drawing.Point(219, 98);
            Legal_Check_BOX4.Multiline = true;
            Legal_Check_BOX4.Name = "Legal_Check_BOX4";
            Legal_Check_BOX4.Size = new System.Drawing.Size(125, 25);
            Legal_Check_BOX4.TabIndex = 34;
            Legal_Check_BOX4.Text = "无事可做";
            // 
            // Legal_Check_BOX3
            // 
            Legal_Check_BOX3.Cursor = Cursors.No;
            Legal_Check_BOX3.Location = new System.Drawing.Point(219, 67);
            Legal_Check_BOX3.Multiline = true;
            Legal_Check_BOX3.Name = "Legal_Check_BOX3";
            Legal_Check_BOX3.Size = new System.Drawing.Size(125, 25);
            Legal_Check_BOX3.TabIndex = 33;
            Legal_Check_BOX3.Text = "无事可做";
            // 
            // Legal_Check_BOX2
            // 
            Legal_Check_BOX2.Cursor = Cursors.No;
            Legal_Check_BOX2.Location = new System.Drawing.Point(219, 36);
            Legal_Check_BOX2.Multiline = true;
            Legal_Check_BOX2.Name = "Legal_Check_BOX2";
            Legal_Check_BOX2.Size = new System.Drawing.Size(125, 25);
            Legal_Check_BOX2.TabIndex = 32;
            Legal_Check_BOX2.Text = "无事可做";
            // 
            // Legal_Check_BOX1
            // 
            Legal_Check_BOX1.Cursor = Cursors.No;
            Legal_Check_BOX1.Location = new System.Drawing.Point(219, 6);
            Legal_Check_BOX1.Multiline = true;
            Legal_Check_BOX1.Name = "Legal_Check_BOX1";
            Legal_Check_BOX1.Size = new System.Drawing.Size(125, 25);
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
            Legal_Check_BOX5.Location = new System.Drawing.Point(219, 129);
            Legal_Check_BOX5.Multiline = true;
            Legal_Check_BOX5.Name = "Legal_Check_BOX5";
            Legal_Check_BOX5.Size = new System.Drawing.Size(125, 25);
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
            ReverseCheck_BTN.Location = new System.Drawing.Point(46, 139);
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
            IVCheck_Box.Location = new System.Drawing.Point(46, 111);
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
            PIDECCheck_Box.Location = new System.Drawing.Point(46, 85);
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
            IVBox.Location = new System.Drawing.Point(43, 54);
            IVBox.Name = "IVBox";
            IVBox.Size = new System.Drawing.Size(20, 17);
            IVBox.TabIndex = 43;
            IVBox.Text = "IV";
            // 
            // IVTextBox
            // 
            IVTextBox.Enabled = false;
            IVTextBox.Location = new System.Drawing.Point(69, 51);
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
            Mlabel.Location = new System.Drawing.Point(7, 22);
            Mlabel.Name = "Mlabel";
            Mlabel.Size = new System.Drawing.Size(64, 17);
            Mlabel.TabIndex = 37;
            Mlabel.Text = "模式选择";
            // 
            // Mod_ComboBox
            // 
            Mod_ComboBox.FormattingEnabled = true;
            Mod_ComboBox.Location = new System.Drawing.Point(68, 17);
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
            RNGFormTabControl.Size = new System.Drawing.Size(381, 232);
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
            ReverseSeedPage.Size = new System.Drawing.Size(373, 202);
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
            SWSHPage.Location = new System.Drawing.Point(4, 29);
            SWSHPage.Name = "SWSHPage";
            SWSHPage.Padding = new Padding(3);
            SWSHPage.Size = new System.Drawing.Size(373, 199);
            SWSHPage.TabIndex = 1;
            SWSHPage.Text = "剑盾Raid检测";
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
            // SlowCheck
            // 
            SlowCheck.Location = new System.Drawing.Point(219, 160);
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
            TeraSeedPage.Controls.Add(AbilitytextBox);
            TeraSeedPage.Controls.Add(Gen9IvcomboBox);
            TeraSeedPage.Controls.Add(numHeight);
            TeraSeedPage.Controls.Add(CheckTeraSeed_BTN);
            TeraSeedPage.Controls.Add(FixPidForTera_BTN);
            TeraSeedPage.Controls.Add(numScale);
            TeraSeedPage.Controls.Add(label5);
            TeraSeedPage.Controls.Add(label2);
            TeraSeedPage.Controls.Add(lblScale);
            TeraSeedPage.Controls.Add(txtPID);
            TeraSeedPage.Controls.Add(GendertextBox);
            TeraSeedPage.Controls.Add(lblNature);
            TeraSeedPage.Controls.Add(numWeight);
            TeraSeedPage.Controls.Add(Gen9AbilitycomboBox);
            TeraSeedPage.Controls.Add(lblHeight);
            TeraSeedPage.Controls.Add(label3);
            TeraSeedPage.Controls.Add(lblWeight);
            TeraSeedPage.Controls.Add(Tera9genderComboBox);
            TeraSeedPage.Controls.Add(label1);
            TeraSeedPage.Controls.Add(lblPID);
            TeraSeedPage.Controls.Add(txtEC);
            TeraSeedPage.Controls.Add(cmbNature);
            TeraSeedPage.Controls.Add(IVstextBox);
            TeraSeedPage.Controls.Add(label4);
            TeraSeedPage.Controls.Add(IVlabel);
            TeraSeedPage.Controls.Add(TeraSeedBox);
            TeraSeedPage.Controls.Add(label);
            TeraSeedPage.Controls.Add(lblEC);
            TeraSeedPage.Location = new System.Drawing.Point(4, 26);
            TeraSeedPage.Name = "TeraSeedPage";
            TeraSeedPage.Padding = new Padding(3);
            TeraSeedPage.Size = new System.Drawing.Size(373, 202);
            TeraSeedPage.TabIndex = 2;
            TeraSeedPage.Text = "朱紫太晶坑检测";
            // 
            // AbilitytextBox
            // 
            AbilitytextBox.Location = new System.Drawing.Point(292, 38);
            AbilitytextBox.MaxLength = 8;
            AbilitytextBox.Name = "AbilitytextBox";
            AbilitytextBox.Size = new System.Drawing.Size(63, 25);
            AbilitytextBox.TabIndex = 90;
            // 
            // Gen9IvcomboBox
            // 
            Gen9IvcomboBox.FormattingEnabled = true;
            Gen9IvcomboBox.Location = new System.Drawing.Point(158, 10);
            Gen9IvcomboBox.Name = "Gen9IvcomboBox";
            Gen9IvcomboBox.Size = new System.Drawing.Size(34, 25);
            Gen9IvcomboBox.TabIndex = 80;
            // 
            // numHeight
            // 
            numHeight.Location = new System.Drawing.Point(210, 72);
            numHeight.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numHeight.Name = "numHeight";
            numHeight.Size = new System.Drawing.Size(47, 25);
            numHeight.TabIndex = 63;
            // 
            // CheckTeraSeed_BTN
            // 
            CheckTeraSeed_BTN.Location = new System.Drawing.Point(175, 133);
            CheckTeraSeed_BTN.Name = "CheckTeraSeed_BTN";
            CheckTeraSeed_BTN.Size = new System.Drawing.Size(111, 25);
            CheckTeraSeed_BTN.TabIndex = 78;
            CheckTeraSeed_BTN.Text = "检测";
            CheckTeraSeed_BTN.UseVisualStyleBackColor = true;
            CheckTeraSeed_BTN.Click += CheckTeraSeed_BTN_Click;
            // 
            // numScale
            // 
            numScale.Location = new System.Drawing.Point(210, 103);
            numScale.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numScale.Name = "numScale";
            numScale.Size = new System.Drawing.Size(47, 25);
            numScale.TabIndex = 60;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(263, 44);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(36, 17);
            label5.TabIndex = 89;
            label5.Text = "特性";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(123, 13);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 17);
            label2.TabIndex = 81;
            label2.Text = "锁IV";
            // 
            // lblScale
            // 
            lblScale.AutoSize = true;
            lblScale.Location = new System.Drawing.Point(169, 106);
            lblScale.Name = "lblScale";
            lblScale.Size = new System.Drawing.Size(40, 17);
            lblScale.TabIndex = 48;
            lblScale.Text = "大小:";
            // 
            // txtPID
            // 
            txtPID.Location = new System.Drawing.Point(67, 72);
            txtPID.MaxLength = 8;
            txtPID.Name = "txtPID";
            txtPID.Size = new System.Drawing.Size(100, 25);
            txtPID.TabIndex = 59;
            // 
            // GendertextBox
            // 
            GendertextBox.Location = new System.Drawing.Point(210, 38);
            GendertextBox.MaxLength = 8;
            GendertextBox.Name = "GendertextBox";
            GendertextBox.Size = new System.Drawing.Size(47, 25);
            GendertextBox.TabIndex = 88;
            // 
            // lblNature
            // 
            lblNature.AutoSize = true;
            lblNature.Location = new System.Drawing.Point(27, 137);
            lblNature.Name = "lblNature";
            lblNature.Size = new System.Drawing.Size(40, 17);
            lblNature.TabIndex = 71;
            lblNature.Text = "性格:";
            // 
            // numWeight
            // 
            numWeight.Location = new System.Drawing.Point(308, 72);
            numWeight.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numWeight.Name = "numWeight";
            numWeight.Size = new System.Drawing.Size(47, 25);
            numWeight.TabIndex = 62;
            // 
            // Gen9AbilitycomboBox
            // 
            Gen9AbilitycomboBox.FormattingEnabled = true;
            Gen9AbilitycomboBox.Location = new System.Drawing.Point(49, 10);
            Gen9AbilitycomboBox.Name = "Gen9AbilitycomboBox";
            Gen9AbilitycomboBox.Size = new System.Drawing.Size(70, 25);
            Gen9AbilitycomboBox.TabIndex = 82;
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Location = new System.Drawing.Point(169, 75);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new System.Drawing.Size(40, 17);
            lblHeight.TabIndex = 52;
            lblHeight.Text = "身高:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(15, 13);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(36, 17);
            label3.TabIndex = 83;
            label3.Text = "特性";
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.Location = new System.Drawing.Point(263, 75);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new System.Drawing.Size(40, 17);
            lblWeight.TabIndex = 51;
            lblWeight.Text = "体重:";
            // 
            // Tera9genderComboBox
            // 
            Tera9genderComboBox.FormattingEnabled = true;
            Tera9genderComboBox.Location = new System.Drawing.Point(232, 10);
            Tera9genderComboBox.Name = "Tera9genderComboBox";
            Tera9genderComboBox.Size = new System.Drawing.Size(70, 25);
            Tera9genderComboBox.TabIndex = 80;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(195, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(36, 17);
            label1.TabIndex = 81;
            label1.Text = "公母";
            // 
            // lblPID
            // 
            lblPID.AutoSize = true;
            lblPID.Location = new System.Drawing.Point(34, 75);
            lblPID.Name = "lblPID";
            lblPID.Size = new System.Drawing.Size(36, 17);
            lblPID.TabIndex = 49;
            lblPID.Text = "PID:";
            // 
            // txtEC
            // 
            txtEC.Location = new System.Drawing.Point(67, 103);
            txtEC.MaxLength = 8;
            txtEC.Name = "txtEC";
            txtEC.Size = new System.Drawing.Size(100, 25);
            txtEC.TabIndex = 58;
            // 
            // cmbNature
            // 
            cmbNature.FormattingEnabled = true;
            cmbNature.Items.AddRange(new object[] { "Hardy", "Lonely", "Brave", "Adamant", "Naughty", "Bold", "Docile", "Relaxed", "Impish", "Lax", "Timid", "Hasty", "Serious", "Jolly", "Naive", "Modest", "Mild", "Quiet", "Bashful", "Rash", "Calm", "Gentle", "Sassy", "Careful", "Quirky" });
            cmbNature.Location = new System.Drawing.Point(67, 134);
            cmbNature.Name = "cmbNature";
            cmbNature.Size = new System.Drawing.Size(102, 25);
            cmbNature.TabIndex = 72;
            // 
            // IVstextBox
            // 
            IVstextBox.Location = new System.Drawing.Point(49, 165);
            IVstextBox.MaxLength = 8;
            IVstextBox.Name = "IVstextBox";
            IVstextBox.Size = new System.Drawing.Size(120, 25);
            IVstextBox.TabIndex = 84;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(176, 44);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(33, 17);
            label4.TabIndex = 87;
            label4.Text = "性别";
            // 
            // IVlabel
            // 
            IVlabel.AutoSize = true;
            IVlabel.Location = new System.Drawing.Point(6, 168);
            IVlabel.Name = "IVlabel";
            IVlabel.Size = new System.Drawing.Size(40, 17);
            IVlabel.TabIndex = 85;
            IVlabel.Text = "个体:";
            // 
            // TeraSeedBox
            // 
            TeraSeedBox.Location = new System.Drawing.Point(67, 41);
            TeraSeedBox.MaxLength = 8;
            TeraSeedBox.Name = "TeraSeedBox";
            TeraSeedBox.Size = new System.Drawing.Size(100, 25);
            TeraSeedBox.TabIndex = 79;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(21, 46);
            label.Name = "label";
            label.Size = new System.Drawing.Size(46, 17);
            label.TabIndex = 86;
            label.Text = "Seed:";
            // 
            // lblEC
            // 
            lblEC.AutoSize = true;
            lblEC.Location = new System.Drawing.Point(34, 106);
            lblEC.Name = "lblEC";
            lblEC.Size = new System.Drawing.Size(33, 17);
            lblEC.TabIndex = 47;
            lblEC.Text = "EC:";
            // 
            // RNGmenuStrip
            // 
            RNGmenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            RNGmenuStrip.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem });
            RNGmenuStrip.Location = new System.Drawing.Point(0, 0);
            RNGmenuStrip.Name = "RNGmenuStrip";
            RNGmenuStrip.Size = new System.Drawing.Size(737, 28);
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
            // RNGForm
            // 
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(737, 271);
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
            TeraSeedPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numScale).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWeight).EndInit();
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
        private TextBox txtPID;
        private Label lblEC;
        private Label lblScale;
        private ComboBox cmbNature;
        private Label lblPID;
        private Label lblNature;
        private Label lblWeight;
        private Label lblHeight;
        private NumericUpDown numHeight;
        private TextBox txtEC;
        private NumericUpDown numWeight;
        private NumericUpDown numScale;
        private Button CheckTeraSeed_BTN;
        private TextBox TeraSeedBox;
        private ComboBox Tera9genderComboBox;
        private Label label1;
        private ComboBox Gen9IvcomboBox;
        private Label label2;
        private ComboBox Gen9AbilitycomboBox;
        private Label label3;
        private Label label;
        private Label IVlabel;
        private TextBox IVstextBox;
        private TextBox AbilitytextBox;
        private Label label5;
        private TextBox GendertextBox;
        private Label label4;
    }
}
