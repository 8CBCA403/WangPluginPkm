using System.Windows.Forms;

namespace WangPluginPkm.GUI
{
    partial class RNGForm
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RNGForm));
            FastCheck_BTN = new Button();
            SearchGroupBox = new GroupBox();
            Check_Tab = new TabControl();
            R_TabPage = new TabPage();
            MaxSpeNUD = new NumericUpDown();
            MaxSpdNUD = new NumericUpDown();
            MaxSpaNUD = new NumericUpDown();
            MaxDefNUD = new NumericUpDown();
            MaxAtkNUD = new NumericUpDown();
            MaxHpNUD = new NumericUpDown();
            MinSpeNUD = new NumericUpDown();
            MinSpdNUD = new NumericUpDown();
            MinSpaNUD = new NumericUpDown();
            MinDefNUD = new NumericUpDown();
            MinAtkNUD = new NumericUpDown();
            MinHpNUD = new NumericUpDown();
            SeedTB = new TextBox();
            StateBox = new TextBox();
            RNGType_BOX = new ComboBox();
            ShinyType_BOX = new ComboBox();
            SPE_LB = new Label();
            SPD_LB = new Label();
            SPA_LB = new Label();
            DEF_LB = new Label();
            ATK_LB = new Label();
            HP_LB = new Label();
            MAX_LB = new Label();
            Min_LB = new Label();
            Seed_LB = new Label();
            Shiny_LB = new Label();
            State_LB = new Label();
            RNG_LB = new Label();
            ZeroSeed_TB = new TextBox();
            ZeroSeed_Check = new CheckBox();
            Check_Frame = new CheckBox();
            Search = new Button();
            UsePreSeed = new CheckBox();
            TeamLockBox = new CheckBox();
            Cancel = new Button();
            MutiSearchTab = new TabPage();
            Stop_BTN = new Button();
            label8 = new Label();
            StepBox = new TextBox();
            ThreadLB = new Label();
            panelBox = new FlowLayoutPanel();
            Start_BTN = new Button();
            ThreadNumber = new NumericUpDown();
            CalcBTN = new Button();
            label7 = new Label();
            label6 = new Label();
            IVCheckBox = new TextBox();
            SeedCheckBox = new TextBox();
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
            Check_GB = new GroupBox();
            label9 = new Label();
            SearchGroupBox.SuspendLayout();
            Check_Tab.SuspendLayout();
            R_TabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MaxSpeNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaxSpdNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaxSpaNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaxDefNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaxAtkNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaxHpNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinSpeNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinSpdNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinSpaNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinDefNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinAtkNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinHpNUD).BeginInit();
            MutiSearchTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ThreadNumber).BeginInit();
            RNGFormTabControl.SuspendLayout();
            ReverseSeedPage.SuspendLayout();
            SWSHPage.SuspendLayout();
            TeraSeedPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numScale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWeight).BeginInit();
            RNGmenuStrip.SuspendLayout();
            Check_GB.SuspendLayout();
            SuspendLayout();
            // 
            // FastCheck_BTN
            // 
            FastCheck_BTN.Location = new System.Drawing.Point(60, 221);
            FastCheck_BTN.Name = "FastCheck_BTN";
            FastCheck_BTN.Size = new System.Drawing.Size(124, 30);
            FastCheck_BTN.TabIndex = 23;
            FastCheck_BTN.Text = "快速检测(依赖Z3)";
            FastCheck_BTN.UseVisualStyleBackColor = true;
            FastCheck_BTN.Click += FastCheck_BTN_Click;
            // 
            // SearchGroupBox
            // 
            SearchGroupBox.Controls.Add(Check_Tab);
            SearchGroupBox.Location = new System.Drawing.Point(12, 31);
            SearchGroupBox.Name = "SearchGroupBox";
            SearchGroupBox.Size = new System.Drawing.Size(367, 319);
            SearchGroupBox.TabIndex = 24;
            SearchGroupBox.TabStop = false;
            SearchGroupBox.Text = "查找";
            // 
            // Check_Tab
            // 
            Check_Tab.Controls.Add(R_TabPage);
            Check_Tab.Controls.Add(MutiSearchTab);
            Check_Tab.Location = new System.Drawing.Point(6, 20);
            Check_Tab.Name = "Check_Tab";
            Check_Tab.SelectedIndex = 0;
            Check_Tab.Size = new System.Drawing.Size(353, 293);
            Check_Tab.TabIndex = 45;
            // 
            // R_TabPage
            // 
            R_TabPage.Controls.Add(MaxSpeNUD);
            R_TabPage.Controls.Add(MaxSpdNUD);
            R_TabPage.Controls.Add(MaxSpaNUD);
            R_TabPage.Controls.Add(MaxDefNUD);
            R_TabPage.Controls.Add(MaxAtkNUD);
            R_TabPage.Controls.Add(MaxHpNUD);
            R_TabPage.Controls.Add(MinSpeNUD);
            R_TabPage.Controls.Add(MinSpdNUD);
            R_TabPage.Controls.Add(MinSpaNUD);
            R_TabPage.Controls.Add(MinDefNUD);
            R_TabPage.Controls.Add(MinAtkNUD);
            R_TabPage.Controls.Add(MinHpNUD);
            R_TabPage.Controls.Add(SeedTB);
            R_TabPage.Controls.Add(StateBox);
            R_TabPage.Controls.Add(RNGType_BOX);
            R_TabPage.Controls.Add(ShinyType_BOX);
            R_TabPage.Controls.Add(SPE_LB);
            R_TabPage.Controls.Add(SPD_LB);
            R_TabPage.Controls.Add(SPA_LB);
            R_TabPage.Controls.Add(DEF_LB);
            R_TabPage.Controls.Add(ATK_LB);
            R_TabPage.Controls.Add(HP_LB);
            R_TabPage.Controls.Add(MAX_LB);
            R_TabPage.Controls.Add(Min_LB);
            R_TabPage.Controls.Add(Seed_LB);
            R_TabPage.Controls.Add(Shiny_LB);
            R_TabPage.Controls.Add(State_LB);
            R_TabPage.Controls.Add(RNG_LB);
            R_TabPage.Controls.Add(ZeroSeed_TB);
            R_TabPage.Controls.Add(ZeroSeed_Check);
            R_TabPage.Controls.Add(Check_Frame);
            R_TabPage.Controls.Add(Search);
            R_TabPage.Controls.Add(UsePreSeed);
            R_TabPage.Controls.Add(TeamLockBox);
            R_TabPage.Controls.Add(Cancel);
            R_TabPage.Location = new System.Drawing.Point(4, 22);
            R_TabPage.Name = "R_TabPage";
            R_TabPage.Padding = new Padding(3);
            R_TabPage.Size = new System.Drawing.Size(345, 267);
            R_TabPage.TabIndex = 0;
            R_TabPage.Text = "常规查找";
            R_TabPage.UseVisualStyleBackColor = true;
            // 
            // MaxSpeNUD
            // 
            MaxSpeNUD.Location = new System.Drawing.Point(283, 134);
            MaxSpeNUD.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            MaxSpeNUD.Name = "MaxSpeNUD";
            MaxSpeNUD.Size = new System.Drawing.Size(32, 21);
            MaxSpeNUD.TabIndex = 55;
            MaxSpeNUD.Value = new decimal(new int[] { 31, 0, 0, 0 });
            MaxSpeNUD.ValueChanged += MaxSpeNUD_ValueChanged;
            // 
            // MaxSpdNUD
            // 
            MaxSpdNUD.Location = new System.Drawing.Point(241, 134);
            MaxSpdNUD.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            MaxSpdNUD.Name = "MaxSpdNUD";
            MaxSpdNUD.Size = new System.Drawing.Size(32, 21);
            MaxSpdNUD.TabIndex = 54;
            MaxSpdNUD.Value = new decimal(new int[] { 31, 0, 0, 0 });
            MaxSpdNUD.ValueChanged += MaxSpeNUD_ValueChanged;
            // 
            // MaxSpaNUD
            // 
            MaxSpaNUD.Location = new System.Drawing.Point(199, 134);
            MaxSpaNUD.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            MaxSpaNUD.Name = "MaxSpaNUD";
            MaxSpaNUD.Size = new System.Drawing.Size(32, 21);
            MaxSpaNUD.TabIndex = 53;
            MaxSpaNUD.Value = new decimal(new int[] { 31, 0, 0, 0 });
            MaxSpaNUD.ValueChanged += MaxSpeNUD_ValueChanged;
            // 
            // MaxDefNUD
            // 
            MaxDefNUD.Location = new System.Drawing.Point(157, 134);
            MaxDefNUD.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            MaxDefNUD.Name = "MaxDefNUD";
            MaxDefNUD.Size = new System.Drawing.Size(32, 21);
            MaxDefNUD.TabIndex = 52;
            MaxDefNUD.Value = new decimal(new int[] { 31, 0, 0, 0 });
            MaxDefNUD.ValueChanged += MaxSpeNUD_ValueChanged;
            // 
            // MaxAtkNUD
            // 
            MaxAtkNUD.Location = new System.Drawing.Point(115, 134);
            MaxAtkNUD.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            MaxAtkNUD.Name = "MaxAtkNUD";
            MaxAtkNUD.Size = new System.Drawing.Size(32, 21);
            MaxAtkNUD.TabIndex = 51;
            MaxAtkNUD.Value = new decimal(new int[] { 31, 0, 0, 0 });
            MaxAtkNUD.ValueChanged += MaxSpeNUD_ValueChanged;
            // 
            // MaxHpNUD
            // 
            MaxHpNUD.Location = new System.Drawing.Point(73, 134);
            MaxHpNUD.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            MaxHpNUD.Name = "MaxHpNUD";
            MaxHpNUD.Size = new System.Drawing.Size(32, 21);
            MaxHpNUD.TabIndex = 50;
            MaxHpNUD.Value = new decimal(new int[] { 31, 0, 0, 0 });
            MaxHpNUD.ValueChanged += MaxSpeNUD_ValueChanged;
            // 
            // MinSpeNUD
            // 
            MinSpeNUD.Location = new System.Drawing.Point(283, 104);
            MinSpeNUD.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            MinSpeNUD.Name = "MinSpeNUD";
            MinSpeNUD.Size = new System.Drawing.Size(32, 21);
            MinSpeNUD.TabIndex = 49;
            MinSpeNUD.ValueChanged += MaxSpeNUD_ValueChanged;
            // 
            // MinSpdNUD
            // 
            MinSpdNUD.Location = new System.Drawing.Point(241, 104);
            MinSpdNUD.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            MinSpdNUD.Name = "MinSpdNUD";
            MinSpdNUD.Size = new System.Drawing.Size(32, 21);
            MinSpdNUD.TabIndex = 48;
            MinSpdNUD.ValueChanged += MaxSpeNUD_ValueChanged;
            // 
            // MinSpaNUD
            // 
            MinSpaNUD.Location = new System.Drawing.Point(199, 104);
            MinSpaNUD.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            MinSpaNUD.Name = "MinSpaNUD";
            MinSpaNUD.Size = new System.Drawing.Size(32, 21);
            MinSpaNUD.TabIndex = 47;
            MinSpaNUD.ValueChanged += MaxSpeNUD_ValueChanged;
            // 
            // MinDefNUD
            // 
            MinDefNUD.Location = new System.Drawing.Point(157, 103);
            MinDefNUD.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            MinDefNUD.Name = "MinDefNUD";
            MinDefNUD.Size = new System.Drawing.Size(32, 21);
            MinDefNUD.TabIndex = 46;
            MinDefNUD.ValueChanged += MaxSpeNUD_ValueChanged;
            // 
            // MinAtkNUD
            // 
            MinAtkNUD.Location = new System.Drawing.Point(115, 103);
            MinAtkNUD.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            MinAtkNUD.Name = "MinAtkNUD";
            MinAtkNUD.Size = new System.Drawing.Size(32, 21);
            MinAtkNUD.TabIndex = 45;
            MinAtkNUD.ValueChanged += MaxSpeNUD_ValueChanged;
            // 
            // MinHpNUD
            // 
            MinHpNUD.Location = new System.Drawing.Point(73, 103);
            MinHpNUD.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            MinHpNUD.Name = "MinHpNUD";
            MinHpNUD.Size = new System.Drawing.Size(32, 21);
            MinHpNUD.TabIndex = 44;
            MinHpNUD.ValueChanged += MaxSpeNUD_ValueChanged;
            // 
            // SeedTB
            // 
            SeedTB.Location = new System.Drawing.Point(211, 45);
            SeedTB.Name = "SeedTB";
            SeedTB.Size = new System.Drawing.Size(97, 21);
            SeedTB.TabIndex = 43;
            // 
            // StateBox
            // 
            StateBox.Location = new System.Drawing.Point(211, 19);
            StateBox.Name = "StateBox";
            StateBox.Size = new System.Drawing.Size(97, 21);
            StateBox.TabIndex = 42;
            // 
            // RNGType_BOX
            // 
            RNGType_BOX.FormattingEnabled = true;
            RNGType_BOX.Location = new System.Drawing.Point(79, 20);
            RNGType_BOX.Name = "RNGType_BOX";
            RNGType_BOX.Size = new System.Drawing.Size(91, 20);
            RNGType_BOX.TabIndex = 41;
            // 
            // ShinyType_BOX
            // 
            ShinyType_BOX.FormattingEnabled = true;
            ShinyType_BOX.Location = new System.Drawing.Point(79, 46);
            ShinyType_BOX.Name = "ShinyType_BOX";
            ShinyType_BOX.Size = new System.Drawing.Size(91, 20);
            ShinyType_BOX.TabIndex = 40;
            // 
            // SPE_LB
            // 
            SPE_LB.AutoSize = true;
            SPE_LB.Location = new System.Drawing.Point(281, 80);
            SPE_LB.Name = "SPE_LB";
            SPE_LB.Size = new System.Drawing.Size(29, 12);
            SPE_LB.TabIndex = 39;
            SPE_LB.Text = "速度";
            // 
            // SPD_LB
            // 
            SPD_LB.AutoSize = true;
            SPD_LB.Location = new System.Drawing.Point(240, 80);
            SPD_LB.Name = "SPD_LB";
            SPD_LB.Size = new System.Drawing.Size(29, 12);
            SPD_LB.TabIndex = 38;
            SPD_LB.Text = "特防";
            // 
            // SPA_LB
            // 
            SPA_LB.AutoSize = true;
            SPA_LB.Location = new System.Drawing.Point(199, 80);
            SPA_LB.Name = "SPA_LB";
            SPA_LB.Size = new System.Drawing.Size(29, 12);
            SPA_LB.TabIndex = 37;
            SPA_LB.Text = "特攻";
            // 
            // DEF_LB
            // 
            DEF_LB.AutoSize = true;
            DEF_LB.Location = new System.Drawing.Point(158, 80);
            DEF_LB.Name = "DEF_LB";
            DEF_LB.Size = new System.Drawing.Size(29, 12);
            DEF_LB.TabIndex = 36;
            DEF_LB.Text = "物防";
            // 
            // ATK_LB
            // 
            ATK_LB.AutoSize = true;
            ATK_LB.Location = new System.Drawing.Point(117, 80);
            ATK_LB.Name = "ATK_LB";
            ATK_LB.Size = new System.Drawing.Size(29, 12);
            ATK_LB.TabIndex = 35;
            ATK_LB.Text = "物攻";
            // 
            // HP_LB
            // 
            HP_LB.AutoSize = true;
            HP_LB.Location = new System.Drawing.Point(76, 80);
            HP_LB.Name = "HP_LB";
            HP_LB.Size = new System.Drawing.Size(29, 12);
            HP_LB.TabIndex = 34;
            HP_LB.Text = "血量";
            // 
            // MAX_LB
            // 
            MAX_LB.AutoSize = true;
            MAX_LB.Location = new System.Drawing.Point(26, 136);
            MAX_LB.Name = "MAX_LB";
            MAX_LB.Size = new System.Drawing.Size(41, 12);
            MAX_LB.TabIndex = 33;
            MAX_LB.Text = "最大值";
            // 
            // Min_LB
            // 
            Min_LB.AutoSize = true;
            Min_LB.Location = new System.Drawing.Point(26, 105);
            Min_LB.Name = "Min_LB";
            Min_LB.Size = new System.Drawing.Size(41, 12);
            Min_LB.TabIndex = 32;
            Min_LB.Text = "最小值";
            // 
            // Seed_LB
            // 
            Seed_LB.AutoSize = true;
            Seed_LB.Location = new System.Drawing.Point(176, 49);
            Seed_LB.Name = "Seed_LB";
            Seed_LB.Size = new System.Drawing.Size(29, 12);
            Seed_LB.TabIndex = 31;
            Seed_LB.Text = "Seed";
            // 
            // Shiny_LB
            // 
            Shiny_LB.AutoSize = true;
            Shiny_LB.Location = new System.Drawing.Point(20, 49);
            Shiny_LB.Name = "Shiny_LB";
            Shiny_LB.Size = new System.Drawing.Size(53, 12);
            Shiny_LB.TabIndex = 30;
            Shiny_LB.Text = "闪光种类";
            // 
            // State_LB
            // 
            State_LB.AutoSize = true;
            State_LB.Location = new System.Drawing.Point(176, 24);
            State_LB.Name = "State_LB";
            State_LB.Size = new System.Drawing.Size(29, 12);
            State_LB.TabIndex = 29;
            State_LB.Text = "状态";
            // 
            // RNG_LB
            // 
            RNG_LB.AutoSize = true;
            RNG_LB.Location = new System.Drawing.Point(26, 22);
            RNG_LB.Name = "RNG_LB";
            RNG_LB.Size = new System.Drawing.Size(47, 12);
            RNG_LB.TabIndex = 28;
            RNG_LB.Text = "RNG类型";
            // 
            // ZeroSeed_TB
            // 
            ZeroSeed_TB.Location = new System.Drawing.Point(140, 190);
            ZeroSeed_TB.Name = "ZeroSeed_TB";
            ZeroSeed_TB.Size = new System.Drawing.Size(100, 21);
            ZeroSeed_TB.TabIndex = 27;
            ZeroSeed_TB.Text = "0";
            // 
            // ZeroSeed_Check
            // 
            ZeroSeed_Check.AutoSize = true;
            ZeroSeed_Check.Checked = true;
            ZeroSeed_Check.CheckState = CheckState.Checked;
            ZeroSeed_Check.Location = new System.Drawing.Point(26, 192);
            ZeroSeed_Check.Name = "ZeroSeed_Check";
            ZeroSeed_Check.Size = new System.Drawing.Size(108, 16);
            ZeroSeed_Check.TabIndex = 26;
            ZeroSeed_Check.Text = "从指定Seed开始";
            ZeroSeed_Check.UseVisualStyleBackColor = true;
            // 
            // Check_Frame
            // 
            Check_Frame.AutoSize = true;
            Check_Frame.Location = new System.Drawing.Point(124, 170);
            Check_Frame.Name = "Check_Frame";
            Check_Frame.Size = new System.Drawing.Size(108, 16);
            Check_Frame.TabIndex = 25;
            Check_Frame.Text = "严格帧合法检测";
            Check_Frame.UseVisualStyleBackColor = true;
            // 
            // Search
            // 
            Search.Location = new System.Drawing.Point(73, 226);
            Search.Name = "Search";
            Search.Size = new System.Drawing.Size(92, 25);
            Search.TabIndex = 9;
            Search.Text = "开始查找";
            Search.UseVisualStyleBackColor = true;
            Search.Click += Search_Click;
            // 
            // UsePreSeed
            // 
            UsePreSeed.AutoSize = true;
            UsePreSeed.Location = new System.Drawing.Point(26, 170);
            UsePreSeed.Name = "UsePreSeed";
            UsePreSeed.Size = new System.Drawing.Size(96, 16);
            UsePreSeed.TabIndex = 22;
            UsePreSeed.Text = "使用预设种子";
            UsePreSeed.UseVisualStyleBackColor = true;
            // 
            // TeamLockBox
            // 
            TeamLockBox.AutoSize = true;
            TeamLockBox.Location = new System.Drawing.Point(238, 170);
            TeamLockBox.Name = "TeamLockBox";
            TeamLockBox.Size = new System.Drawing.Size(90, 16);
            TeamLockBox.TabIndex = 24;
            TeamLockBox.Text = "CXD使用队锁";
            TeamLockBox.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            Cancel.Location = new System.Drawing.Point(199, 226);
            Cancel.Name = "Cancel";
            Cancel.Size = new System.Drawing.Size(92, 25);
            Cancel.TabIndex = 11;
            Cancel.Text = "停止查找";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // MutiSearchTab
            // 
            MutiSearchTab.Controls.Add(Stop_BTN);
            MutiSearchTab.Controls.Add(label8);
            MutiSearchTab.Controls.Add(StepBox);
            MutiSearchTab.Controls.Add(ThreadLB);
            MutiSearchTab.Controls.Add(panelBox);
            MutiSearchTab.Controls.Add(Start_BTN);
            MutiSearchTab.Controls.Add(ThreadNumber);
            MutiSearchTab.Location = new System.Drawing.Point(4, 26);
            MutiSearchTab.Name = "MutiSearchTab";
            MutiSearchTab.Padding = new Padding(3);
            MutiSearchTab.Size = new System.Drawing.Size(345, 263);
            MutiSearchTab.TabIndex = 1;
            MutiSearchTab.Text = "多线程";
            MutiSearchTab.UseVisualStyleBackColor = true;
            // 
            // Stop_BTN
            // 
            Stop_BTN.Location = new System.Drawing.Point(317, 225);
            Stop_BTN.Name = "Stop_BTN";
            Stop_BTN.Size = new System.Drawing.Size(22, 23);
            Stop_BTN.TabIndex = 6;
            Stop_BTN.Text = "S";
            Stop_BTN.UseVisualStyleBackColor = true;
            Stop_BTN.Click += Stop_BTN_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(128, 227);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(29, 12);
            label8.TabIndex = 5;
            label8.Text = "步数";
            // 
            // StepBox
            // 
            StepBox.Location = new System.Drawing.Point(163, 224);
            StepBox.Name = "StepBox";
            StepBox.Size = new System.Drawing.Size(58, 21);
            StepBox.TabIndex = 4;
            StepBox.Text = "0";
            // 
            // ThreadLB
            // 
            ThreadLB.AutoSize = true;
            ThreadLB.Location = new System.Drawing.Point(8, 227);
            ThreadLB.Name = "ThreadLB";
            ThreadLB.Size = new System.Drawing.Size(53, 12);
            ThreadLB.TabIndex = 3;
            ThreadLB.Text = "线程数量";
            // 
            // panelBox
            // 
            panelBox.AutoScroll = true;
            panelBox.Location = new System.Drawing.Point(6, 6);
            panelBox.Name = "panelBox";
            panelBox.Size = new System.Drawing.Size(333, 205);
            panelBox.TabIndex = 2;
            // 
            // Start_BTN
            // 
            Start_BTN.Location = new System.Drawing.Point(227, 224);
            Start_BTN.Name = "Start_BTN";
            Start_BTN.Size = new System.Drawing.Size(90, 23);
            Start_BTN.TabIndex = 1;
            Start_BTN.Text = "开始";
            Start_BTN.UseVisualStyleBackColor = true;
            Start_BTN.Click += Start_BTN_Click;
            // 
            // ThreadNumber
            // 
            ThreadNumber.Location = new System.Drawing.Point(67, 225);
            ThreadNumber.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            ThreadNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ThreadNumber.Name = "ThreadNumber";
            ThreadNumber.Size = new System.Drawing.Size(52, 21);
            ThreadNumber.TabIndex = 0;
            ThreadNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // CalcBTN
            // 
            CalcBTN.Location = new System.Drawing.Point(64, 217);
            CalcBTN.Name = "CalcBTN";
            CalcBTN.Size = new System.Drawing.Size(114, 25);
            CalcBTN.TabIndex = 49;
            CalcBTN.Text = "Seed计算IV";
            CalcBTN.UseVisualStyleBackColor = true;
            CalcBTN.Click += CalcBTN_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(184, 193);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(17, 12);
            label7.TabIndex = 48;
            label7.Text = "IV";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(122, 623);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(29, 12);
            label6.TabIndex = 47;
            label6.Text = "Seed";
            // 
            // IVCheckBox
            // 
            IVCheckBox.Location = new System.Drawing.Point(207, 190);
            IVCheckBox.Name = "IVCheckBox";
            IVCheckBox.Size = new System.Drawing.Size(124, 21);
            IVCheckBox.TabIndex = 46;
            // 
            // SeedCheckBox
            // 
            SeedCheckBox.Location = new System.Drawing.Point(64, 190);
            SeedCheckBox.Name = "SeedCheckBox";
            SeedCheckBox.Size = new System.Drawing.Size(114, 21);
            SeedCheckBox.TabIndex = 45;
            // 
            // MinIV_Box
            // 
            MinIV_Box.FormattingEnabled = true;
            MinIV_Box.Location = new System.Drawing.Point(47, 73);
            MinIV_Box.Name = "MinIV_Box";
            MinIV_Box.Size = new System.Drawing.Size(151, 20);
            MinIV_Box.TabIndex = 25;
            // 
            // Gender_Box
            // 
            Gender_Box.FormattingEnabled = true;
            Gender_Box.Location = new System.Drawing.Point(60, 108);
            Gender_Box.Name = "Gender_Box";
            Gender_Box.Size = new System.Drawing.Size(138, 20);
            Gender_Box.TabIndex = 26;
            // 
            // FlawlessIV
            // 
            FlawlessIV.AutoSize = true;
            FlawlessIV.Location = new System.Drawing.Point(13, 76);
            FlawlessIV.Name = "FlawlessIV";
            FlawlessIV.Size = new System.Drawing.Size(29, 12);
            FlawlessIV.TabIndex = 27;
            FlawlessIV.Text = "锁IV";
            // 
            // genderlabel
            // 
            genderlabel.AutoSize = true;
            genderlabel.Location = new System.Drawing.Point(13, 111);
            genderlabel.Name = "genderlabel";
            genderlabel.Size = new System.Drawing.Size(41, 12);
            genderlabel.TabIndex = 28;
            genderlabel.Text = "公母比";
            // 
            // Ability_Box
            // 
            Ability_Box.FormattingEnabled = true;
            Ability_Box.Location = new System.Drawing.Point(47, 143);
            Ability_Box.Name = "Ability_Box";
            Ability_Box.Size = new System.Drawing.Size(151, 20);
            Ability_Box.TabIndex = 29;
            // 
            // AbilityLabel
            // 
            AbilityLabel.AutoSize = true;
            AbilityLabel.Location = new System.Drawing.Point(12, 148);
            AbilityLabel.Name = "AbilityLabel";
            AbilityLabel.Size = new System.Drawing.Size(29, 12);
            AbilityLabel.TabIndex = 30;
            AbilityLabel.Text = "特性";
            // 
            // FixPidForTera_BTN
            // 
            FixPidForTera_BTN.Location = new System.Drawing.Point(212, 189);
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
            Legal_Check_BOX4.Location = new System.Drawing.Point(225, 151);
            Legal_Check_BOX4.Multiline = true;
            Legal_Check_BOX4.Name = "Legal_Check_BOX4";
            Legal_Check_BOX4.Size = new System.Drawing.Size(125, 25);
            Legal_Check_BOX4.TabIndex = 34;
            Legal_Check_BOX4.Text = "无事可做";
            // 
            // Legal_Check_BOX3
            // 
            Legal_Check_BOX3.Cursor = Cursors.No;
            Legal_Check_BOX3.Location = new System.Drawing.Point(226, 112);
            Legal_Check_BOX3.Multiline = true;
            Legal_Check_BOX3.Name = "Legal_Check_BOX3";
            Legal_Check_BOX3.Size = new System.Drawing.Size(125, 25);
            Legal_Check_BOX3.TabIndex = 33;
            Legal_Check_BOX3.Text = "无事可做";
            // 
            // Legal_Check_BOX2
            // 
            Legal_Check_BOX2.Cursor = Cursors.No;
            Legal_Check_BOX2.Location = new System.Drawing.Point(226, 73);
            Legal_Check_BOX2.Multiline = true;
            Legal_Check_BOX2.Name = "Legal_Check_BOX2";
            Legal_Check_BOX2.Size = new System.Drawing.Size(125, 25);
            Legal_Check_BOX2.TabIndex = 32;
            Legal_Check_BOX2.Text = "无事可做";
            // 
            // Legal_Check_BOX1
            // 
            Legal_Check_BOX1.Cursor = Cursors.No;
            Legal_Check_BOX1.Location = new System.Drawing.Point(225, 34);
            Legal_Check_BOX1.Multiline = true;
            Legal_Check_BOX1.Name = "Legal_Check_BOX1";
            Legal_Check_BOX1.Size = new System.Drawing.Size(125, 25);
            Legal_Check_BOX1.TabIndex = 31;
            Legal_Check_BOX1.Text = "无事可做";
            // 
            // Seed_Box
            // 
            Seed_Box.Location = new System.Drawing.Point(58, 34);
            Seed_Box.Multiline = true;
            Seed_Box.Name = "Seed_Box";
            Seed_Box.Size = new System.Drawing.Size(140, 22);
            Seed_Box.TabIndex = 23;
            Seed_Box.Text = "没有seed";
            // 
            // Legal_Check_BOX5
            // 
            Legal_Check_BOX5.Cursor = Cursors.No;
            Legal_Check_BOX5.Location = new System.Drawing.Point(226, 190);
            Legal_Check_BOX5.Multiline = true;
            Legal_Check_BOX5.Name = "Legal_Check_BOX5";
            Legal_Check_BOX5.Size = new System.Drawing.Size(125, 25);
            Legal_Check_BOX5.TabIndex = 35;
            Legal_Check_BOX5.Text = "无事可做";
            // 
            // SeedBox
            // 
            SeedBox.Location = new System.Drawing.Point(232, 100);
            SeedBox.Multiline = true;
            SeedBox.Name = "SeedBox";
            SeedBox.ScrollBars = ScrollBars.Vertical;
            SeedBox.Size = new System.Drawing.Size(124, 79);
            SeedBox.TabIndex = 38;
            // 
            // PIDBox
            // 
            PIDBox.Location = new System.Drawing.Point(232, 35);
            PIDBox.Name = "PIDBox";
            PIDBox.Size = new System.Drawing.Size(124, 21);
            PIDBox.TabIndex = 37;
            // 
            // ReverseCheck_BTN
            // 
            ReverseCheck_BTN.Location = new System.Drawing.Point(64, 154);
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
            IVCheck_Box.Location = new System.Drawing.Point(42, 129);
            IVCheck_Box.Name = "IVCheck_Box";
            IVCheck_Box.Size = new System.Drawing.Size(84, 16);
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
            PIDECCheck_Box.Location = new System.Drawing.Point(42, 103);
            PIDECCheck_Box.Name = "PIDECCheck_Box";
            PIDECCheck_Box.Size = new System.Drawing.Size(90, 16);
            PIDECCheck_Box.TabIndex = 25;
            PIDECCheck_Box.Text = "使用PID反推";
            PIDECCheck_Box.UseVisualStyleBackColor = true;
            PIDECCheck_Box.CheckedChanged += PIDECCheck_Box_CheckedChanged;
            // 
            // IVBox
            // 
            IVBox.AutoSize = true;
            IVBox.Location = new System.Drawing.Point(39, 72);
            IVBox.Name = "IVBox";
            IVBox.Size = new System.Drawing.Size(17, 12);
            IVBox.TabIndex = 43;
            IVBox.Text = "IV";
            // 
            // IVTextBox
            // 
            IVTextBox.Enabled = false;
            IVTextBox.Location = new System.Drawing.Point(65, 69);
            IVTextBox.Name = "IVTextBox";
            IVTextBox.Size = new System.Drawing.Size(124, 21);
            IVTextBox.TabIndex = 42;
            // 
            // ECLabel
            // 
            ECLabel.AutoSize = true;
            ECLabel.Location = new System.Drawing.Point(206, 72);
            ECLabel.Name = "ECLabel";
            ECLabel.Size = new System.Drawing.Size(17, 12);
            ECLabel.TabIndex = 41;
            ECLabel.Text = "EC";
            // 
            // ECBox
            // 
            ECBox.Enabled = false;
            ECBox.Location = new System.Drawing.Point(232, 69);
            ECBox.Name = "ECBox";
            ECBox.Size = new System.Drawing.Size(124, 21);
            ECBox.TabIndex = 40;
            // 
            // Seedlabel
            // 
            Seedlabel.AutoSize = true;
            Seedlabel.Location = new System.Drawing.Point(193, 103);
            Seedlabel.Name = "Seedlabel";
            Seedlabel.Size = new System.Drawing.Size(29, 12);
            Seedlabel.TabIndex = 39;
            Seedlabel.Text = "Seed";
            // 
            // PIDlabel
            // 
            PIDlabel.AutoSize = true;
            PIDlabel.Location = new System.Drawing.Point(203, 40);
            PIDlabel.Name = "PIDlabel";
            PIDlabel.Size = new System.Drawing.Size(23, 12);
            PIDlabel.TabIndex = 37;
            PIDlabel.Text = "PID";
            // 
            // Mlabel
            // 
            Mlabel.AutoSize = true;
            Mlabel.Location = new System.Drawing.Point(3, 40);
            Mlabel.Name = "Mlabel";
            Mlabel.Size = new System.Drawing.Size(53, 12);
            Mlabel.TabIndex = 37;
            Mlabel.Text = "模式选择";
            // 
            // Mod_ComboBox
            // 
            Mod_ComboBox.FormattingEnabled = true;
            Mod_ComboBox.Location = new System.Drawing.Point(64, 35);
            Mod_ComboBox.Name = "Mod_ComboBox";
            Mod_ComboBox.Size = new System.Drawing.Size(124, 20);
            Mod_ComboBox.TabIndex = 37;
            // 
            // RNGFormTabControl
            // 
            RNGFormTabControl.Controls.Add(ReverseSeedPage);
            RNGFormTabControl.Controls.Add(SWSHPage);
            RNGFormTabControl.Controls.Add(TeraSeedPage);
            RNGFormTabControl.Location = new System.Drawing.Point(6, 20);
            RNGFormTabControl.Name = "RNGFormTabControl";
            RNGFormTabControl.SelectedIndex = 0;
            RNGFormTabControl.Size = new System.Drawing.Size(381, 289);
            RNGFormTabControl.TabIndex = 45;
            // 
            // ReverseSeedPage
            // 
            ReverseSeedPage.BackColor = System.Drawing.Color.WhiteSmoke;
            ReverseSeedPage.Controls.Add(label9);
            ReverseSeedPage.Controls.Add(CalcBTN);
            ReverseSeedPage.Controls.Add(IVCheck_Box);
            ReverseSeedPage.Controls.Add(SeedBox);
            ReverseSeedPage.Controls.Add(label7);
            ReverseSeedPage.Controls.Add(PIDECCheck_Box);
            ReverseSeedPage.Controls.Add(PIDBox);
            ReverseSeedPage.Controls.Add(IVBox);
            ReverseSeedPage.Controls.Add(ReverseCheck_BTN);
            ReverseSeedPage.Controls.Add(IVCheckBox);
            ReverseSeedPage.Controls.Add(IVTextBox);
            ReverseSeedPage.Controls.Add(SeedCheckBox);
            ReverseSeedPage.Controls.Add(Mod_ComboBox);
            ReverseSeedPage.Controls.Add(ECLabel);
            ReverseSeedPage.Controls.Add(Mlabel);
            ReverseSeedPage.Controls.Add(ECBox);
            ReverseSeedPage.Controls.Add(PIDlabel);
            ReverseSeedPage.Controls.Add(Seedlabel);
            ReverseSeedPage.Location = new System.Drawing.Point(4, 22);
            ReverseSeedPage.Name = "ReverseSeedPage";
            ReverseSeedPage.Padding = new Padding(3);
            ReverseSeedPage.Size = new System.Drawing.Size(373, 263);
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
            SWSHPage.Size = new System.Drawing.Size(373, 259);
            SWSHPage.TabIndex = 1;
            SWSHPage.Text = "剑盾Raid检测";
            // 
            // Seed_Label
            // 
            Seed_Label.AutoSize = true;
            Seed_Label.Location = new System.Drawing.Point(12, 37);
            Seed_Label.Name = "Seed_Label";
            Seed_Label.Size = new System.Drawing.Size(29, 12);
            Seed_Label.TabIndex = 47;
            Seed_Label.Text = "Seed";
            // 
            // SlowCheck
            // 
            SlowCheck.Location = new System.Drawing.Point(225, 221);
            SlowCheck.Name = "SlowCheck";
            SlowCheck.Size = new System.Drawing.Size(124, 30);
            SlowCheck.TabIndex = 48;
            SlowCheck.Text = "慢速检测";
            SlowCheck.UseVisualStyleBackColor = true;
            SlowCheck.Click += SlowCheck_BTN_Click;
            // 
            // FixLairSeed
            // 
            FixLairSeed.Location = new System.Drawing.Point(60, 181);
            FixLairSeed.Name = "FixLairSeed";
            FixLairSeed.Size = new System.Drawing.Size(124, 30);
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
            TeraSeedPage.Size = new System.Drawing.Size(373, 259);
            TeraSeedPage.TabIndex = 2;
            TeraSeedPage.Text = "朱紫太晶坑检测";
            // 
            // AbilitytextBox
            // 
            AbilitytextBox.Location = new System.Drawing.Point(294, 65);
            AbilitytextBox.MaxLength = 8;
            AbilitytextBox.Name = "AbilitytextBox";
            AbilitytextBox.Size = new System.Drawing.Size(63, 21);
            AbilitytextBox.TabIndex = 90;
            // 
            // Gen9IvcomboBox
            // 
            Gen9IvcomboBox.FormattingEnabled = true;
            Gen9IvcomboBox.Location = new System.Drawing.Point(160, 37);
            Gen9IvcomboBox.Name = "Gen9IvcomboBox";
            Gen9IvcomboBox.Size = new System.Drawing.Size(34, 20);
            Gen9IvcomboBox.TabIndex = 80;
            // 
            // numHeight
            // 
            numHeight.Location = new System.Drawing.Point(212, 99);
            numHeight.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numHeight.Name = "numHeight";
            numHeight.Size = new System.Drawing.Size(47, 21);
            numHeight.TabIndex = 63;
            // 
            // CheckTeraSeed_BTN
            // 
            CheckTeraSeed_BTN.Location = new System.Drawing.Point(212, 157);
            CheckTeraSeed_BTN.Name = "CheckTeraSeed_BTN";
            CheckTeraSeed_BTN.Size = new System.Drawing.Size(111, 25);
            CheckTeraSeed_BTN.TabIndex = 78;
            CheckTeraSeed_BTN.Text = "检测";
            CheckTeraSeed_BTN.UseVisualStyleBackColor = true;
           // CheckTeraSeed_BTN.Click += CheckTeraSeed_BTN_Click;
            // 
            // numScale
            // 
            numScale.Location = new System.Drawing.Point(212, 130);
            numScale.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numScale.Name = "numScale";
            numScale.Size = new System.Drawing.Size(47, 21);
            numScale.TabIndex = 60;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("黑体", 9F);
            label5.Location = new System.Drawing.Point(265, 71);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(29, 12);
            label5.TabIndex = 89;
            label5.Text = "特性";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("黑体", 9F);
            label2.Location = new System.Drawing.Point(125, 40);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(29, 12);
            label2.TabIndex = 81;
            label2.Text = "锁IV";
            // 
            // lblScale
            // 
            lblScale.AutoSize = true;
            lblScale.Font = new System.Drawing.Font("黑体", 9F);
            lblScale.Location = new System.Drawing.Point(171, 133);
            lblScale.Name = "lblScale";
            lblScale.Size = new System.Drawing.Size(35, 12);
            lblScale.TabIndex = 48;
            lblScale.Text = "大小:";
            // 
            // txtPID
            // 
            txtPID.Location = new System.Drawing.Point(69, 114);
            txtPID.MaxLength = 8;
            txtPID.Name = "txtPID";
            txtPID.Size = new System.Drawing.Size(100, 21);
            txtPID.TabIndex = 59;
            // 
            // GendertextBox
            // 
            GendertextBox.Location = new System.Drawing.Point(212, 65);
            GendertextBox.MaxLength = 8;
            GendertextBox.Name = "GendertextBox";
            GendertextBox.Size = new System.Drawing.Size(47, 21);
            GendertextBox.TabIndex = 88;
            // 
            // lblNature
            // 
            lblNature.AutoSize = true;
            lblNature.Font = new System.Drawing.Font("黑体", 9F);
            lblNature.Location = new System.Drawing.Point(28, 195);
            lblNature.Name = "lblNature";
            lblNature.Size = new System.Drawing.Size(35, 12);
            lblNature.TabIndex = 71;
            lblNature.Text = "性格:";
            // 
            // numWeight
            // 
            numWeight.Location = new System.Drawing.Point(310, 99);
            numWeight.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numWeight.Name = "numWeight";
            numWeight.Size = new System.Drawing.Size(47, 21);
            numWeight.TabIndex = 62;
            // 
            // Gen9AbilitycomboBox
            // 
            Gen9AbilitycomboBox.FormattingEnabled = true;
            Gen9AbilitycomboBox.Location = new System.Drawing.Point(51, 37);
            Gen9AbilitycomboBox.Name = "Gen9AbilitycomboBox";
            Gen9AbilitycomboBox.Size = new System.Drawing.Size(70, 20);
            Gen9AbilitycomboBox.TabIndex = 82;
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Font = new System.Drawing.Font("黑体", 9F);
            lblHeight.Location = new System.Drawing.Point(171, 102);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new System.Drawing.Size(35, 12);
            lblHeight.TabIndex = 52;
            lblHeight.Text = "身高:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("黑体", 9F);
            label3.Location = new System.Drawing.Point(17, 40);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(29, 12);
            label3.TabIndex = 83;
            label3.Text = "特性";
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.Font = new System.Drawing.Font("黑体", 9F);
            lblWeight.Location = new System.Drawing.Point(265, 102);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new System.Drawing.Size(35, 12);
            lblWeight.TabIndex = 51;
            lblWeight.Text = "体重:";
            // 
            // Tera9genderComboBox
            // 
            Tera9genderComboBox.FormattingEnabled = true;
            Tera9genderComboBox.Location = new System.Drawing.Point(234, 37);
            Tera9genderComboBox.Name = "Tera9genderComboBox";
            Tera9genderComboBox.Size = new System.Drawing.Size(70, 20);
            Tera9genderComboBox.TabIndex = 80;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("黑体", 9F);
            label1.Location = new System.Drawing.Point(197, 40);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(29, 12);
            label1.TabIndex = 81;
            label1.Text = "公母";
            // 
            // lblPID
            // 
            lblPID.AutoSize = true;
            lblPID.Location = new System.Drawing.Point(34, 117);
            lblPID.Name = "lblPID";
            lblPID.Size = new System.Drawing.Size(29, 12);
            lblPID.TabIndex = 49;
            lblPID.Text = "PID:";
            // 
            // txtEC
            // 
            txtEC.Location = new System.Drawing.Point(69, 153);
            txtEC.MaxLength = 8;
            txtEC.Name = "txtEC";
            txtEC.Size = new System.Drawing.Size(100, 21);
            txtEC.TabIndex = 58;
            // 
            // cmbNature
            // 
            cmbNature.FormattingEnabled = true;
            cmbNature.Items.AddRange(new object[] { "Hardy", "Lonely", "Brave", "Adamant", "Naughty", "Bold", "Docile", "Relaxed", "Impish", "Lax", "Timid", "Hasty", "Serious", "Jolly", "Naive", "Modest", "Mild", "Quiet", "Bashful", "Rash", "Calm", "Gentle", "Sassy", "Careful", "Quirky" });
            cmbNature.Location = new System.Drawing.Point(69, 192);
            cmbNature.Name = "cmbNature";
            cmbNature.Size = new System.Drawing.Size(102, 20);
            cmbNature.TabIndex = 72;
            // 
            // IVstextBox
            // 
            IVstextBox.Location = new System.Drawing.Point(49, 230);
            IVstextBox.MaxLength = 8;
            IVstextBox.Name = "IVstextBox";
            IVstextBox.Size = new System.Drawing.Size(120, 21);
            IVstextBox.TabIndex = 84;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("黑体", 9F);
            label4.Location = new System.Drawing.Point(178, 71);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(29, 12);
            label4.TabIndex = 87;
            label4.Text = "性别";
            // 
            // IVlabel
            // 
            IVlabel.AutoSize = true;
            IVlabel.Font = new System.Drawing.Font("黑体", 9F);
            IVlabel.Location = new System.Drawing.Point(6, 237);
            IVlabel.Name = "IVlabel";
            IVlabel.Size = new System.Drawing.Size(35, 12);
            IVlabel.TabIndex = 85;
            IVlabel.Text = "个体:";
            // 
            // TeraSeedBox
            // 
            TeraSeedBox.Location = new System.Drawing.Point(69, 75);
            TeraSeedBox.MaxLength = 8;
            TeraSeedBox.Name = "TeraSeedBox";
            TeraSeedBox.Size = new System.Drawing.Size(100, 21);
            TeraSeedBox.TabIndex = 79;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(24, 78);
            label.Name = "label";
            label.Size = new System.Drawing.Size(35, 12);
            label.TabIndex = 86;
            label.Text = "Seed:";
            // 
            // lblEC
            // 
            lblEC.AutoSize = true;
            lblEC.Location = new System.Drawing.Point(36, 160);
            lblEC.Name = "lblEC";
            lblEC.Size = new System.Drawing.Size(23, 12);
            lblEC.TabIndex = 47;
            lblEC.Text = "EC:";
            // 
            // RNGmenuStrip
            // 
            RNGmenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            RNGmenuStrip.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem });
            RNGmenuStrip.Location = new System.Drawing.Point(0, 0);
            RNGmenuStrip.Name = "RNGmenuStrip";
            RNGmenuStrip.Size = new System.Drawing.Size(789, 25);
            RNGmenuStrip.TabIndex = 46;
            RNGmenuStrip.Text = "menuStrip1";
            // 
            // ToolStripMenuItem
            // 
            ToolStripMenuItem.Name = "ToolStripMenuItem";
            ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            ToolStripMenuItem.Text = "使用说明";
            ToolStripMenuItem.Click += ToolStripMenuItem_Click;
            // 
            // Check_GB
            // 
            Check_GB.Controls.Add(RNGFormTabControl);
            Check_GB.Location = new System.Drawing.Point(385, 31);
            Check_GB.Name = "Check_GB";
            Check_GB.Size = new System.Drawing.Size(392, 319);
            Check_GB.TabIndex = 48;
            Check_GB.TabStop = false;
            Check_GB.Text = "检测";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(29, 193);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(29, 12);
            label9.TabIndex = 50;
            label9.Text = "Seed";
            // 
            // RNGForm
            // 
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(789, 362);
            Controls.Add(Check_GB);
            Controls.Add(SearchGroupBox);
            Controls.Add(RNGmenuStrip);
            Controls.Add(label6);
            Font = new System.Drawing.Font("黑体", 9F);
            ForeColor = System.Drawing.SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "RNGForm";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Super Wang";
            SearchGroupBox.ResumeLayout(false);
            Check_Tab.ResumeLayout(false);
            R_TabPage.ResumeLayout(false);
            R_TabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MaxSpeNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaxSpdNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaxSpaNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaxDefNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaxAtkNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaxHpNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinSpeNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinSpdNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinSpaNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinDefNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinAtkNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinHpNUD).EndInit();
            MutiSearchTab.ResumeLayout(false);
            MutiSearchTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ThreadNumber).EndInit();
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
            Check_GB.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

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
        private Label label6;
        private TextBox IVCheckBox;
        private TextBox SeedCheckBox;
        private Label label7;
        private Button CalcBTN;
        private TabControl Check_Tab;
        private TabPage R_TabPage;
        private TextBox ZeroSeed_TB;
        private CheckBox ZeroSeed_Check;
        private CheckBox Check_Frame;
        private Button Search;
        private CheckBox UsePreSeed;
        private CheckBox TeamLockBox;
        private Button Cancel;
        private TabPage MutiSearchTab;
        private Button Start_BTN;
        private NumericUpDown ThreadNumber;
        private FlowLayoutPanel panelBox;
        private Label label8;
        private TextBox StepBox;
        private Label ThreadLB;
        private Label SPD_LB;
        private Label SPA_LB;
        private Label DEF_LB;
        private Label ATK_LB;
        private Label HP_LB;
        private Label MAX_LB;
        private Label Min_LB;
        private Label Seed_LB;
        private Label Shiny_LB;
        private Label State_LB;
        private Label RNG_LB;
        private NumericUpDown MaxSpeNUD;
        private NumericUpDown MaxSpdNUD;
        private NumericUpDown MaxSpaNUD;
        private NumericUpDown MaxDefNUD;
        private NumericUpDown MaxAtkNUD;
        private NumericUpDown MaxHpNUD;
        private NumericUpDown MinSpeNUD;
        private NumericUpDown MinSpdNUD;
        private NumericUpDown MinSpaNUD;
        private NumericUpDown MinDefNUD;
        private NumericUpDown MinAtkNUD;
        private NumericUpDown MinHpNUD;
        private TextBox SeedTB;
        private TextBox StateBox;
        private ComboBox RNGType_BOX;
        private ComboBox ShinyType_BOX;
        private Label SPE_LB;
        private GroupBox Check_GB;
        private Button Stop_BTN;
        private Label label9;
    }
}
