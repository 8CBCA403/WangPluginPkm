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
            DexTabControl.SuspendLayout();
            IDPage.SuspendLayout();
            DexBuilder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SoltnumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BoxnumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // BuildDex_BTN
            // 
            BuildDex_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BuildDex_BTN.Location = new System.Drawing.Point(113, 67);
            BuildDex_BTN.Name = "BuildDex_BTN";
            BuildDex_BTN.Size = new System.Drawing.Size(102, 26);
            BuildDex_BTN.TabIndex = 0;
            BuildDex_BTN.Text = "补齐图鉴";
            BuildDex_BTN.UseVisualStyleBackColor = true;
            BuildDex_BTN.Click += BuildDex_BTN_Click;
            // 
            // Gen_BTN
            // 
            Gen_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Gen_BTN.Location = new System.Drawing.Point(229, 70);
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
            TID16Box.Size = new System.Drawing.Size(57, 25);
            TID16Box.TabIndex = 2;
            TID16Box.Text = "101010";
            // 
            // SID16Box
            // 
            SID16Box.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            SID16Box.Location = new System.Drawing.Point(58, 39);
            SID16Box.Name = "SID16Box";
            SID16Box.Size = new System.Drawing.Size(57, 25);
            SID16Box.TabIndex = 3;
            SID16Box.Text = "1111";
            // 
            // OT_Name
            // 
            OT_Name.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            OT_Name.Location = new System.Drawing.Point(182, 6);
            OT_Name.Name = "OT_Name";
            OT_Name.Size = new System.Drawing.Size(151, 25);
            OT_Name.TabIndex = 4;
            OT_Name.Text = "Wang";
            // 
            // LanguageBox
            // 
            LanguageBox.FormattingEnabled = true;
            LanguageBox.Location = new System.Drawing.Point(198, 38);
            LanguageBox.Name = "LanguageBox";
            LanguageBox.Size = new System.Drawing.Size(53, 25);
            LanguageBox.TabIndex = 5;
            // 
            // GenderBox
            // 
            GenderBox.FormattingEnabled = true;
            GenderBox.Location = new System.Drawing.Point(257, 38);
            GenderBox.Name = "GenderBox";
            GenderBox.Size = new System.Drawing.Size(74, 25);
            GenderBox.TabIndex = 6;
            // 
            // TID16Label
            // 
            TID16Label.AutoSize = true;
            TID16Label.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TID16Label.Location = new System.Drawing.Point(13, 10);
            TID16Label.Name = "TID16Label";
            TID16Label.Size = new System.Drawing.Size(39, 15);
            TID16Label.TabIndex = 7;
            TID16Label.Text = "表ID";
            // 
            // SID16Label
            // 
            SID16Label.AutoSize = true;
            SID16Label.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            SID16Label.Location = new System.Drawing.Point(13, 43);
            SID16Label.Name = "SID16Label";
            SID16Label.RightToLeft = RightToLeft.No;
            SID16Label.Size = new System.Drawing.Size(39, 15);
            SID16Label.TabIndex = 8;
            SID16Label.Text = "里ID";
            // 
            // OTLabel
            // 
            OTLabel.AutoSize = true;
            OTLabel.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            OTLabel.Location = new System.Drawing.Point(121, 10);
            OTLabel.Name = "OTLabel";
            OTLabel.Size = new System.Drawing.Size(55, 15);
            OTLabel.TabIndex = 9;
            OTLabel.Text = "初训家";
            // 
            // LGLabel
            // 
            LGLabel.AutoSize = true;
            LGLabel.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LGLabel.Location = new System.Drawing.Point(121, 42);
            LGLabel.Name = "LGLabel";
            LGLabel.Size = new System.Drawing.Size(79, 15);
            LGLabel.TabIndex = 10;
            LGLabel.Text = "语言/性别";
            // 
            // LivingDex_BTN
            // 
            LivingDex_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LivingDex_BTN.Location = new System.Drawing.Point(5, 68);
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
            SortBox.Size = new System.Drawing.Size(210, 25);
            SortBox.TabIndex = 12;
            // 
            // Legal_BTN
            // 
            Legal_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Legal_BTN.Location = new System.Drawing.Point(221, 68);
            Legal_BTN.Name = "Legal_BTN";
            Legal_BTN.Size = new System.Drawing.Size(103, 25);
            Legal_BTN.TabIndex = 13;
            Legal_BTN.Text = "合法化箱子";
            Legal_BTN.UseVisualStyleBackColor = true;
            Legal_BTN.Click += Legal_BTN_Click;
            // 
            // LegalAll_BTN
            // 
            LegalAll_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LegalAll_BTN.Location = new System.Drawing.Point(222, 37);
            LegalAll_BTN.Name = "LegalAll_BTN";
            LegalAll_BTN.Size = new System.Drawing.Size(102, 25);
            LegalAll_BTN.TabIndex = 14;
            LegalAll_BTN.Text = "合法化全部";
            LegalAll_BTN.UseVisualStyleBackColor = true;
            LegalAll_BTN.Click += LegalAll_BTN_Click;
            // 
            // RandomPID_BTN
            // 
            RandomPID_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            RandomPID_BTN.Location = new System.Drawing.Point(13, 70);
            RandomPID_BTN.Name = "RandomPID_BTN";
            RandomPID_BTN.Size = new System.Drawing.Size(102, 25);
            RandomPID_BTN.TabIndex = 16;
            RandomPID_BTN.Text = "随机PID";
            RandomPID_BTN.UseVisualStyleBackColor = true;
            RandomPID_BTN.Click += RandomPID_BTN_Click;
            // 
            // Sort_BTN
            // 
            Sort_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            RandomEC_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            RandomEC_BTN.Location = new System.Drawing.Point(121, 70);
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
            Mod_Select_Box.Location = new System.Drawing.Point(5, 37);
            Mod_Select_Box.Name = "Mod_Select_Box";
            Mod_Select_Box.Size = new System.Drawing.Size(121, 25);
            Mod_Select_Box.TabIndex = 68;
            // 
            // FormAndSubDex_BTN
            // 
            FormAndSubDex_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormAndSubDex_BTN.Location = new System.Drawing.Point(132, 38);
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
            DexTabControl.Location = new System.Drawing.Point(12, 12);
            DexTabControl.Name = "DexTabControl";
            DexTabControl.SelectedIndex = 0;
            DexTabControl.Size = new System.Drawing.Size(347, 176);
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
            IDPage.Location = new System.Drawing.Point(4, 26);
            IDPage.Name = "IDPage";
            IDPage.Padding = new Padding(3);
            IDPage.Size = new System.Drawing.Size(339, 146);
            IDPage.TabIndex = 0;
            IDPage.Text = "ID编辑器";
            // 
            // DeleteBox_BTN
            // 
            DeleteBox_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            DeleteBox_BTN.Location = new System.Drawing.Point(13, 101);
            DeleteBox_BTN.Name = "DeleteBox_BTN";
            DeleteBox_BTN.Size = new System.Drawing.Size(102, 25);
            DeleteBox_BTN.TabIndex = 20;
            DeleteBox_BTN.Text = "删除箱子";
            DeleteBox_BTN.UseVisualStyleBackColor = true;
            DeleteBox_BTN.Click += DeleteBox_BTN_Click;
            // 
            // ClearAll_BTN
            // 
            ClearAll_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ClearAll_BTN.Location = new System.Drawing.Point(121, 101);
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
            DexBuilder.Location = new System.Drawing.Point(4, 26);
            DexBuilder.Name = "DexBuilder";
            DexBuilder.Padding = new Padding(3);
            DexBuilder.Size = new System.Drawing.Size(339, 146);
            DexBuilder.TabIndex = 1;
            DexBuilder.Text = "图鉴制作器";
            // 
            // Insertion_BTN
            // 
            Insertion_BTN.Font = new System.Drawing.Font("SimHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Insertion_BTN.Location = new System.Drawing.Point(220, 99);
            Insertion_BTN.Name = "Insertion_BTN";
            Insertion_BTN.Size = new System.Drawing.Size(103, 25);
            Insertion_BTN.TabIndex = 74;
            Insertion_BTN.Text = "开始插空";
            Insertion_BTN.UseVisualStyleBackColor = true;
            Insertion_BTN.Click += Insertion_BTN_Click;
            // 
            // Solt_Label
            // 
            Solt_Label.AutoSize = true;
            Solt_Label.Location = new System.Drawing.Point(115, 101);
            Solt_Label.Name = "Solt_Label";
            Solt_Label.Size = new System.Drawing.Size(36, 17);
            Solt_Label.TabIndex = 73;
            Solt_Label.Text = "槽位";
            // 
            // Box_Label
            // 
            Box_Label.AutoSize = true;
            Box_Label.Location = new System.Drawing.Point(7, 101);
            Box_Label.Name = "Box_Label";
            Box_Label.Size = new System.Drawing.Size(36, 17);
            Box_Label.TabIndex = 72;
            Box_Label.Text = "箱子";
            // 
            // SoltnumericUpDown
            // 
            SoltnumericUpDown.Location = new System.Drawing.Point(157, 99);
            SoltnumericUpDown.Name = "SoltnumericUpDown";
            SoltnumericUpDown.Size = new System.Drawing.Size(58, 25);
            SoltnumericUpDown.TabIndex = 71;
            SoltnumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // BoxnumericUpDown
            // 
            BoxnumericUpDown.Location = new System.Drawing.Point(49, 99);
            BoxnumericUpDown.Name = "BoxnumericUpDown";
            BoxnumericUpDown.Size = new System.Drawing.Size(58, 25);
            BoxnumericUpDown.TabIndex = 70;
            BoxnumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // DexBuildForm
            // 
            ClientSize = new System.Drawing.Size(368, 199);
            Controls.Add(DexTabControl);
            Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
    }
}
