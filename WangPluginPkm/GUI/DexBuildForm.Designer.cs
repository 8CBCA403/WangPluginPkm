using System.Windows.Forms;
namespace WangPluginPkm.GUI
{
    partial class DexBuildForm
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DexBuildForm));
            BuildDex_BTN = new Button();
            Gen_BTN = new Button();
            TID16Box = new TextBox();
            SID16Box = new TextBox();
            OriginalTrainerName = new TextBox();
            LanguageBox = new ComboBox();
            GenderBox = new ComboBox();
            TID16Label = new Label();
            SID16Label = new Label();
            OTLabel = new Label();
            LGLabel = new Label();
            LivingDex_BTN = new Button();
            SortBox = new ComboBox();
            Legal_BTN = new Button();
            LegalAll_BTN = new Button();
            RandomPID_BTN = new Button();
            Sort_BTN = new Button();
            RandomEC_BTN = new Button();
            Mod_Select_Box = new ComboBox();
            FormAndSubDex_BTN = new Button();
            DexTabControl = new TabControl();
            IDPage = new TabPage();
            DeleteBox_BTN = new Button();
            ClearAll_BTN = new Button();
            DexBuilder = new TabPage();
            GenDex_BTN = new Button();
            Insertion_BTN = new Button();
            Solt_Label = new Label();
            Box_Label = new Label();
            SoltnumericUpDown = new NumericUpDown();
            BoxnumericUpDown = new NumericUpDown();
            Home_Page = new TabPage();
            Result = new TextBox();
            AchieveCheck_BTN = new Button();
            SubcomboBox = new ComboBox();
            MaincomboBox = new ComboBox();
            AchieveGen_BTN = new Button();
            ID_Cheak = new TabPage();
            label2 = new Label();
            label1 = new Label();
            R_BOX = new TextBox();
            Check_BTN = new Button();
            SIDCheck_Box = new TextBox();
            TIDCheck_BOX = new TextBox();
            Quick_Edit = new TabPage();
            Quick_EV_BTN = new Button();
            DexTabControl.SuspendLayout();
            IDPage.SuspendLayout();
            DexBuilder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SoltnumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BoxnumericUpDown).BeginInit();
            Home_Page.SuspendLayout();
            ID_Cheak.SuspendLayout();
            Quick_Edit.SuspendLayout();
            SuspendLayout();
            // 
            // BuildDex_BTN
            // 
            BuildDex_BTN.Font = new System.Drawing.Font("黑体", 9F);
            BuildDex_BTN.Location = new System.Drawing.Point(132, 78);
            BuildDex_BTN.Name = "BuildDex_BTN";
            BuildDex_BTN.Size = new System.Drawing.Size(102, 25);
            BuildDex_BTN.TabIndex = 0;
            BuildDex_BTN.Text = "补齐图鉴";
            BuildDex_BTN.UseVisualStyleBackColor = true;
            BuildDex_BTN.Click += BuildDex_BTN_Click;
            // 
            // Gen_BTN
            // 
            Gen_BTN.Font = new System.Drawing.Font("黑体", 9F);
            Gen_BTN.Location = new System.Drawing.Point(231, 73);
            Gen_BTN.Name = "Gen_BTN";
            Gen_BTN.Size = new System.Drawing.Size(102, 25);
            Gen_BTN.TabIndex = 1;
            Gen_BTN.Text = "开始覆盖ID";
            Gen_BTN.UseVisualStyleBackColor = true;
            Gen_BTN.Click += Gen_BTN_Click;
            // 
            // TID16Box
            // 
            TID16Box.Font = new System.Drawing.Font("Arial", 9F);
            TID16Box.Location = new System.Drawing.Point(58, 6);
            TID16Box.Name = "TID16Box";
            TID16Box.Size = new System.Drawing.Size(57, 21);
            TID16Box.TabIndex = 2;
            TID16Box.Text = "101010";
            // 
            // SID16Box
            // 
            SID16Box.Font = new System.Drawing.Font("Arial", 9F);
            SID16Box.Location = new System.Drawing.Point(56, 39);
            SID16Box.Name = "SID16Box";
            SID16Box.Size = new System.Drawing.Size(59, 21);
            SID16Box.TabIndex = 3;
            SID16Box.Text = "1111";
            // 
            // OriginalTrainerName
            // 
            OriginalTrainerName.Font = new System.Drawing.Font("Arial", 9F);
            OriginalTrainerName.Location = new System.Drawing.Point(182, 6);
            OriginalTrainerName.Name = "OriginalTrainerName";
            OriginalTrainerName.Size = new System.Drawing.Size(151, 21);
            OriginalTrainerName.TabIndex = 4;
            OriginalTrainerName.Text = "Wang";
            // 
            // LanguageBox
            // 
            LanguageBox.FormattingEnabled = true;
            LanguageBox.Location = new System.Drawing.Point(188, 40);
            LanguageBox.Name = "LanguageBox";
            LanguageBox.Size = new System.Drawing.Size(53, 20);
            LanguageBox.TabIndex = 5;
            // 
            // GenderBox
            // 
            GenderBox.FormattingEnabled = true;
            GenderBox.Location = new System.Drawing.Point(247, 39);
            GenderBox.Name = "GenderBox";
            GenderBox.Size = new System.Drawing.Size(86, 20);
            GenderBox.TabIndex = 6;
            // 
            // TID16Label
            // 
            TID16Label.AutoSize = true;
            TID16Label.Font = new System.Drawing.Font("黑体", 9F);
            TID16Label.Location = new System.Drawing.Point(13, 11);
            TID16Label.Name = "TID16Label";
            TID16Label.Size = new System.Drawing.Size(29, 12);
            TID16Label.TabIndex = 7;
            TID16Label.Text = "表ID";
            // 
            // SID16Label
            // 
            SID16Label.AutoSize = true;
            SID16Label.Font = new System.Drawing.Font("黑体", 9F);
            SID16Label.Location = new System.Drawing.Point(13, 44);
            SID16Label.Name = "SID16Label";
            SID16Label.RightToLeft = RightToLeft.No;
            SID16Label.Size = new System.Drawing.Size(29, 12);
            SID16Label.TabIndex = 8;
            SID16Label.Text = "里ID";
            // 
            // OTLabel
            // 
            OTLabel.AutoSize = true;
            OTLabel.Font = new System.Drawing.Font("黑体", 9F);
            OTLabel.Location = new System.Drawing.Point(123, 11);
            OTLabel.Name = "OTLabel";
            OTLabel.Size = new System.Drawing.Size(41, 12);
            OTLabel.TabIndex = 9;
            OTLabel.Text = "初训家";
            // 
            // LGLabel
            // 
            LGLabel.AutoSize = true;
            LGLabel.Font = new System.Drawing.Font("黑体", 9F);
            LGLabel.Location = new System.Drawing.Point(123, 44);
            LGLabel.Name = "LGLabel";
            LGLabel.Size = new System.Drawing.Size(59, 12);
            LGLabel.TabIndex = 10;
            LGLabel.Text = "语言/性别";
            // 
            // LivingDex_BTN
            // 
            LivingDex_BTN.Font = new System.Drawing.Font("黑体", 9F);
            LivingDex_BTN.Location = new System.Drawing.Point(5, 78);
            LivingDex_BTN.Name = "LivingDex_BTN";
            LivingDex_BTN.Size = new System.Drawing.Size(119, 25);
            LivingDex_BTN.TabIndex = 11;
            LivingDex_BTN.Text = "生成全图鉴";
            LivingDex_BTN.UseVisualStyleBackColor = true;
            LivingDex_BTN.Click += LivingDex_BTN_Click;
            // 
            // SortBox
            // 
            SortBox.FormattingEnabled = true;
            SortBox.Location = new System.Drawing.Point(5, 7);
            SortBox.Name = "SortBox";
            SortBox.Size = new System.Drawing.Size(229, 20);
            SortBox.TabIndex = 12;
            // 
            // Legal_BTN
            // 
            Legal_BTN.Font = new System.Drawing.Font("黑体", 9F);
            Legal_BTN.Location = new System.Drawing.Point(239, 78);
            Legal_BTN.Name = "Legal_BTN";
            Legal_BTN.Size = new System.Drawing.Size(103, 25);
            Legal_BTN.TabIndex = 13;
            Legal_BTN.Text = "合法化箱子";
            Legal_BTN.UseVisualStyleBackColor = true;
            Legal_BTN.Click += Legal_BTN_Click;
            // 
            // LegalAll_BTN
            // 
            LegalAll_BTN.Font = new System.Drawing.Font("黑体", 9F);
            LegalAll_BTN.Location = new System.Drawing.Point(240, 43);
            LegalAll_BTN.Name = "LegalAll_BTN";
            LegalAll_BTN.Size = new System.Drawing.Size(102, 25);
            LegalAll_BTN.TabIndex = 14;
            LegalAll_BTN.Text = "合法化全部";
            LegalAll_BTN.UseVisualStyleBackColor = true;
            LegalAll_BTN.Click += LegalAll_BTN_Click;
            // 
            // RandomPID_BTN
            // 
            RandomPID_BTN.Font = new System.Drawing.Font("黑体", 9F);
            RandomPID_BTN.Location = new System.Drawing.Point(13, 73);
            RandomPID_BTN.Name = "RandomPID_BTN";
            RandomPID_BTN.Size = new System.Drawing.Size(102, 25);
            RandomPID_BTN.TabIndex = 16;
            RandomPID_BTN.Text = "随机PID";
            RandomPID_BTN.UseVisualStyleBackColor = true;
            RandomPID_BTN.Click += RandomPID_BTN_Click;
            // 
            // Sort_BTN
            // 
            Sort_BTN.Font = new System.Drawing.Font("黑体", 9F);
            Sort_BTN.Location = new System.Drawing.Point(240, 7);
            Sort_BTN.Name = "Sort_BTN";
            Sort_BTN.Size = new System.Drawing.Size(102, 25);
            Sort_BTN.TabIndex = 17;
            Sort_BTN.Text = "开始排序";
            Sort_BTN.UseVisualStyleBackColor = true;
            Sort_BTN.Click += Sort_BTN_Click;
            // 
            // RandomEC_BTN
            // 
            RandomEC_BTN.Font = new System.Drawing.Font("黑体", 9F);
            RandomEC_BTN.Location = new System.Drawing.Point(121, 73);
            RandomEC_BTN.Name = "RandomEC_BTN";
            RandomEC_BTN.Size = new System.Drawing.Size(102, 25);
            RandomEC_BTN.TabIndex = 18;
            RandomEC_BTN.Text = "随机EC";
            RandomEC_BTN.UseVisualStyleBackColor = true;
            RandomEC_BTN.Click += RandomEC_BTN_Click;
            // 
            // Mod_Select_Box
            // 
            Mod_Select_Box.FormattingEnabled = true;
            Mod_Select_Box.Location = new System.Drawing.Point(3, 43);
            Mod_Select_Box.Name = "Mod_Select_Box";
            Mod_Select_Box.Size = new System.Drawing.Size(121, 20);
            Mod_Select_Box.TabIndex = 68;
            // 
            // FormAndSubDex_BTN
            // 
            FormAndSubDex_BTN.Font = new System.Drawing.Font("黑体", 9F);
            FormAndSubDex_BTN.Location = new System.Drawing.Point(132, 42);
            FormAndSubDex_BTN.Name = "FormAndSubDex_BTN";
            FormAndSubDex_BTN.Size = new System.Drawing.Size(102, 25);
            FormAndSubDex_BTN.TabIndex = 69;
            FormAndSubDex_BTN.Text = "生成形态";
            FormAndSubDex_BTN.UseVisualStyleBackColor = true;
            FormAndSubDex_BTN.Click += FormAndSubDex_Click;
            // 
            // DexTabControl
            // 
            DexTabControl.Controls.Add(IDPage);
            DexTabControl.Controls.Add(DexBuilder);
            DexTabControl.Controls.Add(Home_Page);
            DexTabControl.Controls.Add(ID_Cheak);
            DexTabControl.Controls.Add(Quick_Edit);
            DexTabControl.Location = new System.Drawing.Point(11, 12);
            DexTabControl.Name = "DexTabControl";
            DexTabControl.SelectedIndex = 0;
            DexTabControl.Size = new System.Drawing.Size(356, 184);
            DexTabControl.TabIndex = 70;
            // 
            // IDPage
            // 
            IDPage.BackColor = System.Drawing.Color.WhiteSmoke;
            IDPage.Controls.Add(DeleteBox_BTN);
            IDPage.Controls.Add(ClearAll_BTN);
            IDPage.Controls.Add(Gen_BTN);
            IDPage.Controls.Add(RandomEC_BTN);
            IDPage.Controls.Add(TID16Box);
            IDPage.Controls.Add(SID16Box);
            IDPage.Controls.Add(OriginalTrainerName);
            IDPage.Controls.Add(RandomPID_BTN);
            IDPage.Controls.Add(LanguageBox);
            IDPage.Controls.Add(GenderBox);
            IDPage.Controls.Add(LGLabel);
            IDPage.Controls.Add(TID16Label);
            IDPage.Controls.Add(SID16Label);
            IDPage.Controls.Add(OTLabel);
            IDPage.Location = new System.Drawing.Point(4, 22);
            IDPage.Name = "IDPage";
            IDPage.Padding = new Padding(3);
            IDPage.Size = new System.Drawing.Size(348, 158);
            IDPage.TabIndex = 0;
            IDPage.Text = "ID编辑器";
            // 
            // DeleteBox_BTN
            // 
            DeleteBox_BTN.Font = new System.Drawing.Font("黑体", 9F);
            DeleteBox_BTN.Location = new System.Drawing.Point(13, 111);
            DeleteBox_BTN.Name = "DeleteBox_BTN";
            DeleteBox_BTN.Size = new System.Drawing.Size(102, 25);
            DeleteBox_BTN.TabIndex = 20;
            DeleteBox_BTN.Text = "删除箱子";
            DeleteBox_BTN.UseVisualStyleBackColor = true;
            DeleteBox_BTN.Click += DeleteBox_BTN_Click;
            // 
            // ClearAll_BTN
            // 
            ClearAll_BTN.Font = new System.Drawing.Font("黑体", 9F);
            ClearAll_BTN.Location = new System.Drawing.Point(121, 111);
            ClearAll_BTN.Name = "ClearAll_BTN";
            ClearAll_BTN.Size = new System.Drawing.Size(102, 25);
            ClearAll_BTN.TabIndex = 19;
            ClearAll_BTN.Text = "删除全部";
            ClearAll_BTN.UseVisualStyleBackColor = true;
            ClearAll_BTN.Click += ClearAll_BTN_Click;
            // 
            // DexBuilder
            // 
            DexBuilder.BackColor = System.Drawing.Color.WhiteSmoke;
            DexBuilder.Controls.Add(GenDex_BTN);
            DexBuilder.Controls.Add(Insertion_BTN);
            DexBuilder.Controls.Add(Solt_Label);
            DexBuilder.Controls.Add(Box_Label);
            DexBuilder.Controls.Add(SoltnumericUpDown);
            DexBuilder.Controls.Add(BoxnumericUpDown);
            DexBuilder.Controls.Add(LegalAll_BTN);
            DexBuilder.Controls.Add(FormAndSubDex_BTN);
            DexBuilder.Controls.Add(Legal_BTN);
            DexBuilder.Controls.Add(Mod_Select_Box);
            DexBuilder.Controls.Add(SortBox);
            DexBuilder.Controls.Add(Sort_BTN);
            DexBuilder.Controls.Add(LivingDex_BTN);
            DexBuilder.Controls.Add(BuildDex_BTN);
            DexBuilder.Location = new System.Drawing.Point(4, 26);
            DexBuilder.Name = "DexBuilder";
            DexBuilder.Padding = new Padding(3);
            DexBuilder.Size = new System.Drawing.Size(348, 154);
            DexBuilder.TabIndex = 1;
            DexBuilder.Text = "图鉴制作器";
            // 
            // GenDex_BTN
            // 
            GenDex_BTN.Location = new System.Drawing.Point(240, 116);
            GenDex_BTN.Name = "GenDex_BTN";
            GenDex_BTN.Size = new System.Drawing.Size(102, 26);
            GenDex_BTN.TabIndex = 75;
            GenDex_BTN.Text = "生成逼真图鉴";
            GenDex_BTN.UseVisualStyleBackColor = true;
            GenDex_BTN.Click += GenDex_BTN_Click;
            // 
            // Insertion_BTN
            // 
            Insertion_BTN.Font = new System.Drawing.Font("黑体", 9F);
            Insertion_BTN.Location = new System.Drawing.Point(162, 116);
            Insertion_BTN.Name = "Insertion_BTN";
            Insertion_BTN.Size = new System.Drawing.Size(72, 26);
            Insertion_BTN.TabIndex = 74;
            Insertion_BTN.Text = "插空";
            Insertion_BTN.UseVisualStyleBackColor = true;
            Insertion_BTN.Click += Insertion_BTN_Click;
            // 
            // Solt_Label
            // 
            Solt_Label.AutoSize = true;
            Solt_Label.Font = new System.Drawing.Font("黑体", 10.5F);
            Solt_Label.Location = new System.Drawing.Point(84, 118);
            Solt_Label.Name = "Solt_Label";
            Solt_Label.Size = new System.Drawing.Size(35, 14);
            Solt_Label.TabIndex = 73;
            Solt_Label.Text = "槽位";
            // 
            // Box_Label
            // 
            Box_Label.AutoSize = true;
            Box_Label.Font = new System.Drawing.Font("黑体", 10.5F);
            Box_Label.Location = new System.Drawing.Point(6, 118);
            Box_Label.Name = "Box_Label";
            Box_Label.Size = new System.Drawing.Size(35, 14);
            Box_Label.TabIndex = 72;
            Box_Label.Text = "箱子";
            // 
            // SoltnumericUpDown
            // 
            SoltnumericUpDown.Location = new System.Drawing.Point(120, 116);
            SoltnumericUpDown.Name = "SoltnumericUpDown";
            SoltnumericUpDown.Size = new System.Drawing.Size(36, 21);
            SoltnumericUpDown.TabIndex = 71;
            SoltnumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // BoxnumericUpDown
            // 
            BoxnumericUpDown.Location = new System.Drawing.Point(42, 116);
            BoxnumericUpDown.Name = "BoxnumericUpDown";
            BoxnumericUpDown.Size = new System.Drawing.Size(36, 21);
            BoxnumericUpDown.TabIndex = 70;
            BoxnumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Home_Page
            // 
            Home_Page.BackColor = System.Drawing.Color.WhiteSmoke;
            Home_Page.Controls.Add(Result);
            Home_Page.Controls.Add(AchieveCheck_BTN);
            Home_Page.Controls.Add(SubcomboBox);
            Home_Page.Controls.Add(MaincomboBox);
            Home_Page.Controls.Add(AchieveGen_BTN);
            Home_Page.Location = new System.Drawing.Point(4, 26);
            Home_Page.Name = "Home_Page";
            Home_Page.Padding = new Padding(3);
            Home_Page.Size = new System.Drawing.Size(348, 154);
            Home_Page.TabIndex = 2;
            Home_Page.Text = "Home成就制作器";
            // 
            // Result
            // 
            Result.Location = new System.Drawing.Point(6, 99);
            Result.Multiline = true;
            Result.Name = "Result";
            Result.Size = new System.Drawing.Size(336, 50);
            Result.TabIndex = 6;
            // 
            // AchieveCheck_BTN
            // 
            AchieveCheck_BTN.Location = new System.Drawing.Point(194, 67);
            AchieveCheck_BTN.Name = "AchieveCheck_BTN";
            AchieveCheck_BTN.Size = new System.Drawing.Size(148, 26);
            AchieveCheck_BTN.TabIndex = 5;
            AchieveCheck_BTN.Text = "统计";
            AchieveCheck_BTN.UseVisualStyleBackColor = true;
            AchieveCheck_BTN.Click += AchieveCheck_BTN_Click;
            // 
            // SubcomboBox
            // 
            SubcomboBox.FormattingEnabled = true;
            SubcomboBox.Location = new System.Drawing.Point(6, 38);
            SubcomboBox.Name = "SubcomboBox";
            SubcomboBox.Size = new System.Drawing.Size(336, 20);
            SubcomboBox.TabIndex = 4;
            // 
            // MaincomboBox
            // 
            MaincomboBox.FormattingEnabled = true;
            MaincomboBox.Location = new System.Drawing.Point(6, 6);
            MaincomboBox.Name = "MaincomboBox";
            MaincomboBox.Size = new System.Drawing.Size(336, 20);
            MaincomboBox.TabIndex = 3;
            // 
            // AchieveGen_BTN
            // 
            AchieveGen_BTN.Location = new System.Drawing.Point(6, 67);
            AchieveGen_BTN.Name = "AchieveGen_BTN";
            AchieveGen_BTN.Size = new System.Drawing.Size(148, 26);
            AchieveGen_BTN.TabIndex = 2;
            AchieveGen_BTN.Text = "制作";
            AchieveGen_BTN.UseVisualStyleBackColor = true;
            AchieveGen_BTN.Click += Run_BTN_Click;
            // 
            // ID_Cheak
            // 
            ID_Cheak.AutoScroll = true;
            ID_Cheak.BackColor = System.Drawing.Color.WhiteSmoke;
            ID_Cheak.Controls.Add(label2);
            ID_Cheak.Controls.Add(label1);
            ID_Cheak.Controls.Add(R_BOX);
            ID_Cheak.Controls.Add(Check_BTN);
            ID_Cheak.Controls.Add(SIDCheck_Box);
            ID_Cheak.Controls.Add(TIDCheck_BOX);
            ID_Cheak.Location = new System.Drawing.Point(4, 26);
            ID_Cheak.Name = "ID_Cheak";
            ID_Cheak.Padding = new Padding(3);
            ID_Cheak.Size = new System.Drawing.Size(348, 154);
            ID_Cheak.TabIndex = 3;
            ID_Cheak.Text = "ID检索器";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(112, 10);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(17, 12);
            label2.TabIndex = 5;
            label2.Text = "里";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(17, 12);
            label1.TabIndex = 4;
            label1.Text = "表";
            // 
            // R_BOX
            // 
            R_BOX.Location = new System.Drawing.Point(3, 33);
            R_BOX.Multiline = true;
            R_BOX.Name = "R_BOX";
            R_BOX.ScrollBars = ScrollBars.Vertical;
            R_BOX.Size = new System.Drawing.Size(339, 119);
            R_BOX.TabIndex = 3;
            // 
            // Check_BTN
            // 
            Check_BTN.Location = new System.Drawing.Point(218, 6);
            Check_BTN.Name = "Check_BTN";
            Check_BTN.Size = new System.Drawing.Size(124, 21);
            Check_BTN.TabIndex = 2;
            Check_BTN.Text = "检查ID";
            Check_BTN.UseVisualStyleBackColor = true;
            Check_BTN.Click += Check_BTN_Click;
            // 
            // SIDCheck_Box
            // 
            SIDCheck_Box.Location = new System.Drawing.Point(135, 6);
            SIDCheck_Box.Name = "SIDCheck_Box";
            SIDCheck_Box.Size = new System.Drawing.Size(77, 21);
            SIDCheck_Box.TabIndex = 1;
            // 
            // TIDCheck_BOX
            // 
            TIDCheck_BOX.Location = new System.Drawing.Point(30, 6);
            TIDCheck_BOX.Name = "TIDCheck_BOX";
            TIDCheck_BOX.Size = new System.Drawing.Size(76, 21);
            TIDCheck_BOX.TabIndex = 0;
            // 
            // Quick_Edit
            // 
            Quick_Edit.Controls.Add(Quick_EV_BTN);
            Quick_Edit.Location = new System.Drawing.Point(4, 22);
            Quick_Edit.Name = "Quick_Edit";
            Quick_Edit.Padding = new Padding(3);
            Quick_Edit.Size = new System.Drawing.Size(348, 158);
            Quick_Edit.TabIndex = 4;
            Quick_Edit.Text = "速配";
            Quick_Edit.UseVisualStyleBackColor = true;
            // 
            // Quick_EV_BTN
            // 
            Quick_EV_BTN.Location = new System.Drawing.Point(136, 66);
            Quick_EV_BTN.Name = "Quick_EV_BTN";
            Quick_EV_BTN.Size = new System.Drawing.Size(75, 23);
            Quick_EV_BTN.TabIndex = 0;
            Quick_EV_BTN.Text = "速配努力值";
            Quick_EV_BTN.UseVisualStyleBackColor = true;
            Quick_EV_BTN.Click += Quick_EV_BTN_Click;
            // 
            // DexBuildForm
            // 
            ClientSize = new System.Drawing.Size(373, 204);
            Controls.Add(DexTabControl);
            Font = new System.Drawing.Font("黑体", 9F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "DexBuildForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Super Wang";
            DexTabControl.ResumeLayout(false);
            IDPage.ResumeLayout(false);
            IDPage.PerformLayout();
            DexBuilder.ResumeLayout(false);
            DexBuilder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SoltnumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)BoxnumericUpDown).EndInit();
            Home_Page.ResumeLayout(false);
            Home_Page.PerformLayout();
            ID_Cheak.ResumeLayout(false);
            ID_Cheak.PerformLayout();
            Quick_Edit.ResumeLayout(false);
            ResumeLayout(false);
        }

        private ComboBox Mod_Select_Box;
        private Button FormAndSubDex_BTN;
        private Button BuildDex_BTN;
        private Button Gen_BTN;
        private TextBox TID16Box;
        private TextBox SID16Box;
        private ComboBox LanguageBox;
        private TextBox OriginalTrainerName;
        private ComboBox GenderBox;
        private Label TID16Label;
        private Label SID16Label;
        private Label OTLabel;
        private Label LGLabel;
        private Button LivingDex_BTN;
        private ComboBox SortBox;
        private Button Legal_BTN;
        private Button LegalAll_BTN;
        private Button RandomPID_BTN;
        private Button Sort_BTN;
        private Button RandomEC_BTN;
        private TabControl DexTabControl;
        private TabPage IDPage;
        private Button DeleteBox_BTN;
        private Button ClearAll_BTN;
        private TabPage DexBuilder;
        private Button Insertion_BTN;
        private Label Solt_Label;
        private Label Box_Label;
        private NumericUpDown SoltnumericUpDown;
        private NumericUpDown BoxnumericUpDown;
        private TabPage Home_Page;
        private Button AchieveGen_BTN;
        private ComboBox SubcomboBox;
        private ComboBox MaincomboBox;
        private Button GenDex_BTN;
        private Button AchieveCheck_BTN;
        private TextBox Result;
        private TabPage ID_Cheak;
        private TextBox R_BOX;
        private Button Check_BTN;
        private TextBox SIDCheck_Box;
        private TextBox TIDCheck_BOX;
        private Label label2;
        private Label label1;
        private TabPage Quick_Edit;
        private Button Quick_EV_BTN;
    }
}
