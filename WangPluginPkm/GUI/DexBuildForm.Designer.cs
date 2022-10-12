using System.Windows.Forms;
namespace WangPluginPkm.GUI
{
    partial class DexBuildForm
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DexBuildForm));
            this.BuildDex_BTN = new System.Windows.Forms.Button();
            this.Gen_BTN = new System.Windows.Forms.Button();
            this.TIDBox = new System.Windows.Forms.TextBox();
            this.SIDBox = new System.Windows.Forms.TextBox();
            this.OT_Name = new System.Windows.Forms.TextBox();
            this.LanguageBox = new System.Windows.Forms.ComboBox();
            this.GenderBox = new System.Windows.Forms.ComboBox();
            this.TIDLabel = new System.Windows.Forms.Label();
            this.SIDLabel = new System.Windows.Forms.Label();
            this.OTLabel = new System.Windows.Forms.Label();
            this.LGLabel = new System.Windows.Forms.Label();
            this.LivingDex_BTN = new System.Windows.Forms.Button();
            this.SortBox = new System.Windows.Forms.ComboBox();
            this.Legal_BTN = new System.Windows.Forms.Button();
            this.LegalAll_BTN = new System.Windows.Forms.Button();
            this.ClearAll_BTN = new System.Windows.Forms.Button();
            this.RandomPID_BTN = new System.Windows.Forms.Button();
            this.Sort_BTN = new System.Windows.Forms.Button();
            this.DeleteBox_BTN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Mod_Select_Box = new System.Windows.Forms.ComboBox();
            this.FormAndSubDex_BTN = new System.Windows.Forms.Button();
            this.RandomEC_BTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BuildDex_BTN
            // 
            this.BuildDex_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.BuildDex_BTN.Location = new System.Drawing.Point(120, 133);
            this.BuildDex_BTN.Name = "BuildDex_BTN";
            this.BuildDex_BTN.Size = new System.Drawing.Size(102, 26);
            this.BuildDex_BTN.TabIndex = 0;
            this.BuildDex_BTN.Text = "补齐图鉴";
            this.BuildDex_BTN.UseVisualStyleBackColor = true;
            this.BuildDex_BTN.Click += new System.EventHandler(this.BuildDex_BTN_Click);
            // 
            // Gen_BTN
            // 
            this.Gen_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.Gen_BTN.Location = new System.Drawing.Point(330, 22);
            this.Gen_BTN.Name = "Gen_BTN";
            this.Gen_BTN.Size = new System.Drawing.Size(102, 25);
            this.Gen_BTN.TabIndex = 1;
            this.Gen_BTN.Text = "开始覆盖ID";
            this.Gen_BTN.UseVisualStyleBackColor = true;
            this.Gen_BTN.Click += new System.EventHandler(this.Gen_BTN_Click);
            // 
            // TIDBox
            // 
            this.TIDBox.Font = new System.Drawing.Font("Arial", 9F);
            this.TIDBox.Location = new System.Drawing.Point(52, 21);
            this.TIDBox.Name = "TIDBox";
            this.TIDBox.Size = new System.Drawing.Size(73, 25);
            this.TIDBox.TabIndex = 2;
            this.TIDBox.Text = "10101";
            // 
            // SIDBox
            // 
            this.SIDBox.Font = new System.Drawing.Font("Arial", 9F);
            this.SIDBox.Location = new System.Drawing.Point(52, 54);
            this.SIDBox.Name = "SIDBox";
            this.SIDBox.Size = new System.Drawing.Size(73, 25);
            this.SIDBox.TabIndex = 3;
            this.SIDBox.Text = "01010";
            // 
            // OT_Name
            // 
            this.OT_Name.Font = new System.Drawing.Font("Arial", 9F);
            this.OT_Name.Location = new System.Drawing.Point(192, 22);
            this.OT_Name.Name = "OT_Name";
            this.OT_Name.Size = new System.Drawing.Size(133, 25);
            this.OT_Name.TabIndex = 4;
            this.OT_Name.Text = "Wang";
            // 
            // LanguageBox
            // 
            this.LanguageBox.FormattingEnabled = true;
            this.LanguageBox.Location = new System.Drawing.Point(210, 53);
            this.LanguageBox.Name = "LanguageBox";
            this.LanguageBox.Size = new System.Drawing.Size(53, 25);
            this.LanguageBox.TabIndex = 5;
            // 
            // GenderBox
            // 
            this.GenderBox.FormattingEnabled = true;
            this.GenderBox.Location = new System.Drawing.Point(269, 53);
            this.GenderBox.Name = "GenderBox";
            this.GenderBox.Size = new System.Drawing.Size(56, 25);
            this.GenderBox.TabIndex = 6;
            // 
            // TIDLabel
            // 
            this.TIDLabel.AutoSize = true;
            this.TIDLabel.Font = new System.Drawing.Font("黑体", 9F);
            this.TIDLabel.Location = new System.Drawing.Point(7, 25);
            this.TIDLabel.Name = "TIDLabel";
            this.TIDLabel.Size = new System.Drawing.Size(39, 15);
            this.TIDLabel.TabIndex = 7;
            this.TIDLabel.Text = "表ID";
            // 
            // SIDLabel
            // 
            this.SIDLabel.AutoSize = true;
            this.SIDLabel.Font = new System.Drawing.Font("黑体", 9F);
            this.SIDLabel.Location = new System.Drawing.Point(7, 58);
            this.SIDLabel.Name = "SIDLabel";
            this.SIDLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SIDLabel.Size = new System.Drawing.Size(39, 15);
            this.SIDLabel.TabIndex = 8;
            this.SIDLabel.Text = "里ID";
            // 
            // OTLabel
            // 
            this.OTLabel.AutoSize = true;
            this.OTLabel.Font = new System.Drawing.Font("黑体", 9F);
            this.OTLabel.Location = new System.Drawing.Point(131, 26);
            this.OTLabel.Name = "OTLabel";
            this.OTLabel.Size = new System.Drawing.Size(55, 15);
            this.OTLabel.TabIndex = 9;
            this.OTLabel.Text = "初训家";
            // 
            // LGLabel
            // 
            this.LGLabel.AutoSize = true;
            this.LGLabel.Font = new System.Drawing.Font("黑体", 9F);
            this.LGLabel.Location = new System.Drawing.Point(131, 58);
            this.LGLabel.Name = "LGLabel";
            this.LGLabel.Size = new System.Drawing.Size(79, 15);
            this.LGLabel.TabIndex = 10;
            this.LGLabel.Text = "性别/语言";
            // 
            // LivingDex_BTN
            // 
            this.LivingDex_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.LivingDex_BTN.Location = new System.Drawing.Point(12, 133);
            this.LivingDex_BTN.Name = "LivingDex_BTN";
            this.LivingDex_BTN.Size = new System.Drawing.Size(102, 25);
            this.LivingDex_BTN.TabIndex = 11;
            this.LivingDex_BTN.Text = "生成全图鉴";
            this.LivingDex_BTN.UseVisualStyleBackColor = true;
            this.LivingDex_BTN.Click += new System.EventHandler(this.LivingDex_BTN_Click);
            // 
            // SortBox
            // 
            this.SortBox.FormattingEnabled = true;
            this.SortBox.Location = new System.Drawing.Point(12, 102);
            this.SortBox.Name = "SortBox";
            this.SortBox.Size = new System.Drawing.Size(318, 25);
            this.SortBox.TabIndex = 12;
            // 
            // Legal_BTN
            // 
            this.Legal_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.Legal_BTN.Location = new System.Drawing.Point(444, 132);
            this.Legal_BTN.Name = "Legal_BTN";
            this.Legal_BTN.Size = new System.Drawing.Size(125, 25);
            this.Legal_BTN.TabIndex = 13;
            this.Legal_BTN.Text = "合法化箱子";
            this.Legal_BTN.UseVisualStyleBackColor = true;
            this.Legal_BTN.Click += new System.EventHandler(this.Legal_BTN_Click);
            // 
            // LegalAll_BTN
            // 
            this.LegalAll_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.LegalAll_BTN.Location = new System.Drawing.Point(445, 101);
            this.LegalAll_BTN.Name = "LegalAll_BTN";
            this.LegalAll_BTN.Size = new System.Drawing.Size(124, 25);
            this.LegalAll_BTN.TabIndex = 14;
            this.LegalAll_BTN.Text = "合法化全部";
            this.LegalAll_BTN.UseVisualStyleBackColor = true;
            this.LegalAll_BTN.Click += new System.EventHandler(this.LegalAll_BTN_Click);
            // 
            // ClearAll_BTN
            // 
            this.ClearAll_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.ClearAll_BTN.Location = new System.Drawing.Point(336, 133);
            this.ClearAll_BTN.Name = "ClearAll_BTN";
            this.ClearAll_BTN.Size = new System.Drawing.Size(102, 25);
            this.ClearAll_BTN.TabIndex = 15;
            this.ClearAll_BTN.Text = "删除全部";
            this.ClearAll_BTN.UseVisualStyleBackColor = true;
            this.ClearAll_BTN.Click += new System.EventHandler(this.ClearAll_BTN_Click);
            // 
            // RandomPID_BTN
            // 
            this.RandomPID_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.RandomPID_BTN.Location = new System.Drawing.Point(330, 54);
            this.RandomPID_BTN.Name = "RandomPID_BTN";
            this.RandomPID_BTN.Size = new System.Drawing.Size(102, 25);
            this.RandomPID_BTN.TabIndex = 16;
            this.RandomPID_BTN.Text = "随机PID";
            this.RandomPID_BTN.UseVisualStyleBackColor = true;
            this.RandomPID_BTN.Click += new System.EventHandler(this.RandomPID_BTN_Click);
            // 
            // Sort_BTN
            // 
            this.Sort_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.Sort_BTN.Location = new System.Drawing.Point(336, 101);
            this.Sort_BTN.Name = "Sort_BTN";
            this.Sort_BTN.Size = new System.Drawing.Size(102, 25);
            this.Sort_BTN.TabIndex = 17;
            this.Sort_BTN.Text = "开始排序";
            this.Sort_BTN.UseVisualStyleBackColor = true;
            this.Sort_BTN.Click += new System.EventHandler(this.Sort_BTN_Click);
            // 
            // DeleteBox_BTN
            // 
            this.DeleteBox_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.DeleteBox_BTN.Location = new System.Drawing.Point(228, 133);
            this.DeleteBox_BTN.Name = "DeleteBox_BTN";
            this.DeleteBox_BTN.Size = new System.Drawing.Size(102, 25);
            this.DeleteBox_BTN.TabIndex = 18;
            this.DeleteBox_BTN.Text = "删除箱子";
            this.DeleteBox_BTN.UseVisualStyleBackColor = true;
            this.DeleteBox_BTN.Click += new System.EventHandler(this.DeleteBox_BTN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RandomEC_BTN);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.RandomPID_BTN);
            this.groupBox1.Controls.Add(this.LGLabel);
            this.groupBox1.Controls.Add(this.OTLabel);
            this.groupBox1.Controls.Add(this.SIDLabel);
            this.groupBox1.Controls.Add(this.TIDLabel);
            this.groupBox1.Controls.Add(this.GenderBox);
            this.groupBox1.Controls.Add(this.LanguageBox);
            this.groupBox1.Controls.Add(this.OT_Name);
            this.groupBox1.Controls.Add(this.SIDBox);
            this.groupBox1.Controls.Add(this.TIDBox);
            this.groupBox1.Controls.Add(this.Gen_BTN);
            this.groupBox1.Location = new System.Drawing.Point(5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 90);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "编辑全部箱子";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("黑体", 9F);
            this.button1.Location = new System.Drawing.Point(439, 662);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 25);
            this.button1.TabIndex = 17;
            this.button1.Text = "随机PID/EC";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Mod_Select_Box
            // 
            this.Mod_Select_Box.FormattingEnabled = true;
            this.Mod_Select_Box.Location = new System.Drawing.Point(560, 29);
            this.Mod_Select_Box.Name = "Mod_Select_Box";
            this.Mod_Select_Box.Size = new System.Drawing.Size(121, 25);
            this.Mod_Select_Box.TabIndex = 68;
            // 
            // FormAndSubDex_BTN
            // 
            this.FormAndSubDex_BTN.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormAndSubDex_BTN.Location = new System.Drawing.Point(560, 60);
            this.FormAndSubDex_BTN.Name = "FormAndSubDex_BTN";
            this.FormAndSubDex_BTN.Size = new System.Drawing.Size(121, 25);
            this.FormAndSubDex_BTN.TabIndex = 69;
            this.FormAndSubDex_BTN.Text = "生成形态";
            this.FormAndSubDex_BTN.UseVisualStyleBackColor = true;
            this.FormAndSubDex_BTN.Click += new System.EventHandler(this.FormAndSubDex_Click);
            // 
            // RandomEC_BTN
            // 
            this.RandomEC_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.RandomEC_BTN.Location = new System.Drawing.Point(440, 54);
            this.RandomEC_BTN.Name = "RandomEC_BTN";
            this.RandomEC_BTN.Size = new System.Drawing.Size(102, 25);
            this.RandomEC_BTN.TabIndex = 18;
            this.RandomEC_BTN.Text = "随机EC";
            this.RandomEC_BTN.UseVisualStyleBackColor = true;
            this.RandomEC_BTN.Click += new System.EventHandler(this.RandomEC_BTN_Click);
            // 
            // DexBuildForm
            // 
            this.ClientSize = new System.Drawing.Size(687, 171);
            this.Controls.Add(this.FormAndSubDex_BTN);
            this.Controls.Add(this.Mod_Select_Box);
            this.Controls.Add(this.Sort_BTN);
            this.Controls.Add(this.LivingDex_BTN);
            this.Controls.Add(this.BuildDex_BTN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ClearAll_BTN);
            this.Controls.Add(this.DeleteBox_BTN);
            this.Controls.Add(this.SortBox);
            this.Controls.Add(this.LegalAll_BTN);
            this.Controls.Add(this.Legal_BTN);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DexBuildForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        private GroupBox groupBox1;
        private ComboBox Mod_Select_Box;
        private Button FormAndSubDex_BTN;
        private Button BuildDex_BTN;
        private Button Gen_BTN;
        private TextBox TIDBox;
        private TextBox SIDBox;
        private ComboBox LanguageBox;
        private TextBox OT_Name;
        private ComboBox GenderBox;
        private Label TIDLabel;
        private Label SIDLabel;
        private Label OTLabel;
        private Label LGLabel;
        private Button LivingDex_BTN;
        private ComboBox SortBox;
        private Button Legal_BTN;
        private Button LegalAll_BTN;
        private Button ClearAll_BTN;
        private Button RandomPID_BTN;
        private Button Sort_BTN;
        private Button DeleteBox_BTN;
        private Button button1;
        private Button RandomEC_BTN;
    }
}
