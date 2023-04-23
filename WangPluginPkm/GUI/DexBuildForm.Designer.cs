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
            OT_Name = new TextBox();
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
            Insertion_BTN = new Button();
            Solt_Label = new Label();
            Box_Label = new Label();
            SoltnumericUpDown = new NumericUpDown();
            BoxnumericUpDown = new NumericUpDown();
            Home_Page = new TabPage();
            SubcomboBox = new ComboBox();
            MaincomboBox = new ComboBox();
            Run_BTN = new Button();
            DexTabControl.SuspendLayout();
            IDPage.SuspendLayout();
            DexBuilder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SoltnumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BoxnumericUpDown).BeginInit();
            Home_Page.SuspendLayout();
            SuspendLayout();
            // 
            // BuildDex_BTN
            // 
            BuildDex_BTN.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BuildDex_BTN.Location = new System.Drawing.Point(113, 77);
            BuildDex_BTN.Name = "BuildDex_BTN";
            BuildDex_BTN.Size = new System.Drawing.Size(102, 26);
            BuildDex_BTN.TabIndex = 0;
            BuildDex_BTN.Text = "补齐图鉴";
            BuildDex_BTN.UseVisualStyleBackColor = true;
            BuildDex_BTN.Click += BuildDex_BTN_Click;
            // 
            // Gen_BTN
            // 
            Gen_BTN.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            TID16Box.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TID16Box.Location = new System.Drawing.Point(58, 6);
            TID16Box.Name = "TID16Box";
            TID16Box.Size = new System.Drawing.Size(57, 28);
            TID16Box.TabIndex = 2;
            TID16Box.Text = "101010";
            // 
            // SID16Box
            // 
            SID16Box.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            SID16Box.Location = new System.Drawing.Point(56, 39);
            SID16Box.Name = "SID16Box";
            SID16Box.Size = new System.Drawing.Size(59, 28);
            SID16Box.TabIndex = 3;
            SID16Box.Text = "1111";
            // 
            // OT_Name
            // 
            OT_Name.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            OT_Name.Location = new System.Drawing.Point(182, 6);
            OT_Name.Name = "OT_Name";
            OT_Name.Size = new System.Drawing.Size(151, 28);
            OT_Name.TabIndex = 4;
            OT_Name.Text = "Wang";
            // 
            // LanguageBox
            // 
            LanguageBox.FormattingEnabled = true;
            LanguageBox.Location = new System.Drawing.Point(188, 40);
            LanguageBox.Name = "LanguageBox";
            LanguageBox.Size = new System.Drawing.Size(53, 26);
            LanguageBox.TabIndex = 5;
            // 
            // GenderBox
            // 
            GenderBox.FormattingEnabled = true;
            GenderBox.Location = new System.Drawing.Point(247, 39);
            GenderBox.Name = "GenderBox";
            GenderBox.Size = new System.Drawing.Size(86, 26);
            GenderBox.TabIndex = 6;
            // 
            // TID16Label
            // 
            TID16Label.AutoSize = true;
            TID16Label.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TID16Label.Location = new System.Drawing.Point(13, 11);
            TID16Label.Name = "TID16Label";
            TID16Label.Size = new System.Drawing.Size(44, 18);
            TID16Label.TabIndex = 7;
            TID16Label.Text = "表ID";
            // 
            // SID16Label
            // 
            SID16Label.AutoSize = true;
            SID16Label.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            SID16Label.Location = new System.Drawing.Point(13, 44);
            SID16Label.Name = "SID16Label";
            SID16Label.RightToLeft = RightToLeft.No;
            SID16Label.Size = new System.Drawing.Size(44, 18);
            SID16Label.TabIndex = 8;
            SID16Label.Text = "里ID";
            // 
            // OTLabel
            // 
            OTLabel.AutoSize = true;
            OTLabel.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            OTLabel.Location = new System.Drawing.Point(123, 11);
            OTLabel.Name = "OTLabel";
            OTLabel.Size = new System.Drawing.Size(62, 18);
            OTLabel.TabIndex = 9;
            OTLabel.Text = "初训家";
            // 
            // LGLabel
            // 
            LGLabel.AutoSize = true;
            LGLabel.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LGLabel.Location = new System.Drawing.Point(123, 44);
            LGLabel.Name = "LGLabel";
            LGLabel.Size = new System.Drawing.Size(89, 18);
            LGLabel.TabIndex = 10;
            LGLabel.Text = "语言/性别";
            // 
            // LivingDex_BTN
            // 
            LivingDex_BTN.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LivingDex_BTN.Location = new System.Drawing.Point(5, 78);
            LivingDex_BTN.Name = "LivingDex_BTN";
            LivingDex_BTN.Size = new System.Drawing.Size(102, 25);
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
            SortBox.Size = new System.Drawing.Size(210, 26);
            SortBox.TabIndex = 12;
            // 
            // Legal_BTN
            // 
            Legal_BTN.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Legal_BTN.Location = new System.Drawing.Point(220, 78);
            Legal_BTN.Name = "Legal_BTN";
            Legal_BTN.Size = new System.Drawing.Size(103, 25);
            Legal_BTN.TabIndex = 13;
            Legal_BTN.Text = "合法化箱子";
            Legal_BTN.UseVisualStyleBackColor = true;
            Legal_BTN.Click += Legal_BTN_Click;
            // 
            // LegalAll_BTN
            // 
            LegalAll_BTN.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LegalAll_BTN.Location = new System.Drawing.Point(221, 42);
            LegalAll_BTN.Name = "LegalAll_BTN";
            LegalAll_BTN.Size = new System.Drawing.Size(102, 25);
            LegalAll_BTN.TabIndex = 14;
            LegalAll_BTN.Text = "合法化全部";
            LegalAll_BTN.UseVisualStyleBackColor = true;
            LegalAll_BTN.Click += LegalAll_BTN_Click;
            // 
            // RandomPID_BTN
            // 
            RandomPID_BTN.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            Sort_BTN.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Sort_BTN.Location = new System.Drawing.Point(221, 6);
            Sort_BTN.Name = "Sort_BTN";
            Sort_BTN.Size = new System.Drawing.Size(102, 25);
            Sort_BTN.TabIndex = 17;
            Sort_BTN.Text = "开始排序";
            Sort_BTN.UseVisualStyleBackColor = true;
            Sort_BTN.Click += Sort_BTN_Click;
            // 
            // RandomEC_BTN
            // 
            RandomEC_BTN.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            Mod_Select_Box.Size = new System.Drawing.Size(121, 26);
            Mod_Select_Box.TabIndex = 68;
            // 
            // FormAndSubDex_BTN
            // 
            FormAndSubDex_BTN.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormAndSubDex_BTN.Location = new System.Drawing.Point(132, 42);
            FormAndSubDex_BTN.Name = "FormAndSubDex_BTN";
            FormAndSubDex_BTN.Size = new System.Drawing.Size(83, 25);
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
            DexTabControl.Location = new System.Drawing.Point(12, 12);
            DexTabControl.Name = "DexTabControl";
            DexTabControl.SelectedIndex = 0;
            DexTabControl.Size = new System.Drawing.Size(340, 184);
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
            IDPage.Controls.Add(OT_Name);
            IDPage.Controls.Add(RandomPID_BTN);
            IDPage.Controls.Add(LanguageBox);
            IDPage.Controls.Add(GenderBox);
            IDPage.Controls.Add(LGLabel);
            IDPage.Controls.Add(TID16Label);
            IDPage.Controls.Add(SID16Label);
            IDPage.Controls.Add(OTLabel);
            IDPage.Location = new System.Drawing.Point(4, 28);
            IDPage.Name = "IDPage";
            IDPage.Padding = new Padding(3);
            IDPage.Size = new System.Drawing.Size(332, 152);
            IDPage.TabIndex = 0;
            IDPage.Text = "ID编辑器";
            // 
            // DeleteBox_BTN
            // 
            DeleteBox_BTN.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            ClearAll_BTN.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            DexBuilder.Location = new System.Drawing.Point(4, 33);
            DexBuilder.Name = "DexBuilder";
            DexBuilder.Padding = new Padding(3);
            DexBuilder.Size = new System.Drawing.Size(332, 147);
            DexBuilder.TabIndex = 1;
            DexBuilder.Text = "图鉴制作器";
            // 
            // Insertion_BTN
            // 
            Insertion_BTN.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Insertion_BTN.Location = new System.Drawing.Point(220, 114);
            Insertion_BTN.Name = "Insertion_BTN";
            Insertion_BTN.Size = new System.Drawing.Size(103, 22);
            Insertion_BTN.TabIndex = 74;
            Insertion_BTN.Text = "开始插空";
            Insertion_BTN.UseVisualStyleBackColor = true;
            Insertion_BTN.Click += Insertion_BTN_Click;
            // 
            // Solt_Label
            // 
            Solt_Label.AutoSize = true;
            Solt_Label.Location = new System.Drawing.Point(113, 121);
            Solt_Label.Name = "Solt_Label";
            Solt_Label.Size = new System.Drawing.Size(44, 18);
            Solt_Label.TabIndex = 73;
            Solt_Label.Text = "槽位";
            // 
            // Box_Label
            // 
            Box_Label.AutoSize = true;
            Box_Label.Location = new System.Drawing.Point(9, 121);
            Box_Label.Name = "Box_Label";
            Box_Label.Size = new System.Drawing.Size(44, 18);
            Box_Label.TabIndex = 72;
            Box_Label.Text = "箱子";
            // 
            // SoltnumericUpDown
            // 
            SoltnumericUpDown.Location = new System.Drawing.Point(148, 116);
            SoltnumericUpDown.Name = "SoltnumericUpDown";
            SoltnumericUpDown.Size = new System.Drawing.Size(50, 28);
            SoltnumericUpDown.TabIndex = 71;
            SoltnumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // BoxnumericUpDown
            // 
            BoxnumericUpDown.Location = new System.Drawing.Point(44, 116);
            BoxnumericUpDown.Name = "BoxnumericUpDown";
            BoxnumericUpDown.Size = new System.Drawing.Size(50, 28);
            BoxnumericUpDown.TabIndex = 70;
            BoxnumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Home_Page
            // 
            Home_Page.BackColor = System.Drawing.Color.WhiteSmoke;
            Home_Page.Controls.Add(SubcomboBox);
            Home_Page.Controls.Add(MaincomboBox);
            Home_Page.Controls.Add(Run_BTN);
            Home_Page.Location = new System.Drawing.Point(4, 28);
            Home_Page.Name = "Home_Page";
            Home_Page.Padding = new Padding(3);
            Home_Page.Size = new System.Drawing.Size(332, 152);
            Home_Page.TabIndex = 2;
            Home_Page.Text = "Home成就制作器";
            // 
            // SubcomboBox
            // 
            SubcomboBox.FormattingEnabled = true;
            SubcomboBox.Location = new System.Drawing.Point(6, 38);
            SubcomboBox.Name = "SubcomboBox";
            SubcomboBox.Size = new System.Drawing.Size(320, 26);
            SubcomboBox.TabIndex = 4;
            // 
            // MaincomboBox
            // 
            MaincomboBox.FormattingEnabled = true;
            MaincomboBox.Location = new System.Drawing.Point(6, 6);
            MaincomboBox.Name = "MaincomboBox";
            MaincomboBox.Size = new System.Drawing.Size(182, 26);
            MaincomboBox.TabIndex = 3;
            // 
            // Run_BTN
            // 
            Run_BTN.Location = new System.Drawing.Point(194, 3);
            Run_BTN.Name = "Run_BTN";
            Run_BTN.Size = new System.Drawing.Size(132, 32);
            Run_BTN.TabIndex = 2;
            Run_BTN.Text = "制作";
            Run_BTN.UseVisualStyleBackColor = true;
            Run_BTN.Click += Run_BTN_Click;
            // 
            // DexBuildForm
            // 
            ClientSize = new System.Drawing.Size(360, 204);
            Controls.Add(DexTabControl);
            Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            ResumeLayout(false);
        }

        private ComboBox Mod_Select_Box;
        private Button FormAndSubDex_BTN;
        private Button BuildDex_BTN;
        private Button Gen_BTN;
        private TextBox TID16Box;
        private TextBox SID16Box;
        private ComboBox LanguageBox;
        private TextBox OT_Name;
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
        private Button Run_BTN;
        private ComboBox SubcomboBox;
        private ComboBox MaincomboBox;
    }
}
