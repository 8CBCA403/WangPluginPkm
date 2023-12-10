namespace WangPluginPkm
{
    partial class PkmCondition
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            HP_Label = new System.Windows.Forms.Label();
            Atk_Label = new System.Windows.Forms.Label();
            Def_Label = new System.Windows.Forms.Label();
            Spa_Label = new System.Windows.Forms.Label();
            Spd_Label = new System.Windows.Forms.Label();
            Spe_Label = new System.Windows.Forms.Label();
            HpMin = new System.Windows.Forms.TextBox();
            Min_Label = new System.Windows.Forms.Label();
            HpMax = new System.Windows.Forms.TextBox();
            Max_Label = new System.Windows.Forms.Label();
            AtkMin = new System.Windows.Forms.TextBox();
            AtkMax = new System.Windows.Forms.TextBox();
            DefMax = new System.Windows.Forms.TextBox();
            DefMin = new System.Windows.Forms.TextBox();
            SpaMin = new System.Windows.Forms.TextBox();
            SpaMax = new System.Windows.Forms.TextBox();
            SpdMin = new System.Windows.Forms.TextBox();
            SpdMax = new System.Windows.Forms.TextBox();
            SpeMin = new System.Windows.Forms.TextBox();
            SpeMax = new System.Windows.Forms.TextBox();
            ShinyTypeLabel1 = new System.Windows.Forms.Label();
            ShinyTypeBox1 = new System.Windows.Forms.ComboBox();
            SeedBox = new System.Windows.Forms.TextBox();
            MethodBox = new System.Windows.Forms.ComboBox();
            ConditionBox = new System.Windows.Forms.TextBox();
            RNGLabel = new System.Windows.Forms.Label();
            Condition_Lb = new System.Windows.Forms.Label();
            SeedLB = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // HP_Label
            // 
            HP_Label.AutoSize = true;
            HP_Label.Location = new System.Drawing.Point(73, 80);
            HP_Label.Name = "HP_Label";
            HP_Label.Size = new System.Drawing.Size(32, 17);
            HP_Label.TabIndex = 6;
            HP_Label.Text = "血量";
            // 
            // Atk_Label
            // 
            Atk_Label.AutoSize = true;
            Atk_Label.Location = new System.Drawing.Point(111, 80);
            Atk_Label.Name = "Atk_Label";
            Atk_Label.Size = new System.Drawing.Size(32, 17);
            Atk_Label.TabIndex = 7;
            Atk_Label.Text = "物攻";
            // 
            // Def_Label
            // 
            Def_Label.AutoSize = true;
            Def_Label.Location = new System.Drawing.Point(148, 80);
            Def_Label.Name = "Def_Label";
            Def_Label.Size = new System.Drawing.Size(32, 17);
            Def_Label.TabIndex = 8;
            Def_Label.Text = "物防";
            // 
            // Spa_Label
            // 
            Spa_Label.AutoSize = true;
            Spa_Label.Location = new System.Drawing.Point(186, 80);
            Spa_Label.Name = "Spa_Label";
            Spa_Label.Size = new System.Drawing.Size(32, 17);
            Spa_Label.TabIndex = 9;
            Spa_Label.Text = "特攻";
            // 
            // Spd_Label
            // 
            Spd_Label.AutoSize = true;
            Spd_Label.Location = new System.Drawing.Point(223, 80);
            Spd_Label.Name = "Spd_Label";
            Spd_Label.Size = new System.Drawing.Size(32, 17);
            Spd_Label.TabIndex = 10;
            Spd_Label.Text = "特防";
            // 
            // Spe_Label
            // 
            Spe_Label.AutoSize = true;
            Spe_Label.Location = new System.Drawing.Point(261, 80);
            Spe_Label.Name = "Spe_Label";
            Spe_Label.Size = new System.Drawing.Size(32, 17);
            Spe_Label.TabIndex = 11;
            Spe_Label.Text = "速度";
            // 
            // HpMin
            // 
            HpMin.Location = new System.Drawing.Point(75, 111);
            HpMin.Name = "HpMin";
            HpMin.Size = new System.Drawing.Size(30, 23);
            HpMin.TabIndex = 12;
            HpMin.Text = "0";
            HpMin.TextChanged += IVS_TextChanged;
            // 
            // Min_Label
            // 
            Min_Label.AutoSize = true;
            Min_Label.Location = new System.Drawing.Point(19, 114);
            Min_Label.Name = "Min_Label";
            Min_Label.Size = new System.Drawing.Size(44, 17);
            Min_Label.TabIndex = 13;
            Min_Label.Text = "最小值";
            // 
            // HpMax
            // 
            HpMax.Location = new System.Drawing.Point(75, 148);
            HpMax.Name = "HpMax";
            HpMax.Size = new System.Drawing.Size(30, 23);
            HpMax.TabIndex = 14;
            HpMax.Text = "31";
            HpMax.TextChanged += IVS_TextChanged;
            // 
            // Max_Label
            // 
            Max_Label.AutoSize = true;
            Max_Label.Location = new System.Drawing.Point(19, 151);
            Max_Label.Name = "Max_Label";
            Max_Label.Size = new System.Drawing.Size(44, 17);
            Max_Label.TabIndex = 15;
            Max_Label.Text = "最大值";
            // 
            // AtkMin
            // 
            AtkMin.Location = new System.Drawing.Point(113, 111);
            AtkMin.Name = "AtkMin";
            AtkMin.Size = new System.Drawing.Size(30, 23);
            AtkMin.TabIndex = 16;
            AtkMin.Text = "0";
            AtkMin.TextChanged += IVS_TextChanged;
            // 
            // AtkMax
            // 
            AtkMax.Location = new System.Drawing.Point(113, 148);
            AtkMax.Name = "AtkMax";
            AtkMax.Size = new System.Drawing.Size(30, 23);
            AtkMax.TabIndex = 17;
            AtkMax.Text = "31";
            AtkMax.TextChanged += IVS_TextChanged;
            // 
            // DefMax
            // 
            DefMax.Location = new System.Drawing.Point(151, 148);
            DefMax.Name = "DefMax";
            DefMax.Size = new System.Drawing.Size(30, 23);
            DefMax.TabIndex = 18;
            DefMax.Text = "31";
            DefMax.TextChanged += IVS_TextChanged;
            // 
            // DefMin
            // 
            DefMin.Location = new System.Drawing.Point(151, 111);
            DefMin.Name = "DefMin";
            DefMin.Size = new System.Drawing.Size(30, 23);
            DefMin.TabIndex = 19;
            DefMin.Text = "0";
            DefMin.TextChanged += IVS_TextChanged;
            // 
            // SpaMin
            // 
            SpaMin.Location = new System.Drawing.Point(188, 111);
            SpaMin.Name = "SpaMin";
            SpaMin.Size = new System.Drawing.Size(30, 23);
            SpaMin.TabIndex = 20;
            SpaMin.Text = "0";
            SpaMin.TextChanged += IVS_TextChanged;
            // 
            // SpaMax
            // 
            SpaMax.Location = new System.Drawing.Point(188, 148);
            SpaMax.Name = "SpaMax";
            SpaMax.Size = new System.Drawing.Size(30, 23);
            SpaMax.TabIndex = 21;
            SpaMax.Text = "31";
            SpaMax.TextChanged += IVS_TextChanged;
            // 
            // SpdMin
            // 
            SpdMin.Location = new System.Drawing.Point(226, 111);
            SpdMin.Name = "SpdMin";
            SpdMin.Size = new System.Drawing.Size(30, 23);
            SpdMin.TabIndex = 22;
            SpdMin.Text = "0";
            SpdMin.TextChanged += IVS_TextChanged;
            // 
            // SpdMax
            // 
            SpdMax.Location = new System.Drawing.Point(226, 148);
            SpdMax.Name = "SpdMax";
            SpdMax.Size = new System.Drawing.Size(30, 23);
            SpdMax.TabIndex = 23;
            SpdMax.Text = "31";
            SpdMax.TextChanged += IVS_TextChanged;
            // 
            // SpeMin
            // 
            SpeMin.Location = new System.Drawing.Point(264, 111);
            SpeMin.Name = "SpeMin";
            SpeMin.Size = new System.Drawing.Size(30, 23);
            SpeMin.TabIndex = 24;
            SpeMin.Text = "0";
            SpeMin.TextChanged += IVS_TextChanged;
            // 
            // SpeMax
            // 
            SpeMax.Location = new System.Drawing.Point(264, 148);
            SpeMax.Name = "SpeMax";
            SpeMax.Size = new System.Drawing.Size(30, 23);
            SpeMax.TabIndex = 25;
            SpeMax.Text = "31";
            SpeMax.TextChanged += IVS_TextChanged;
            // 
            // ShinyTypeLabel1
            // 
            ShinyTypeLabel1.AutoSize = true;
            ShinyTypeLabel1.Location = new System.Drawing.Point(3, 48);
            ShinyTypeLabel1.Name = "ShinyTypeLabel1";
            ShinyTypeLabel1.Size = new System.Drawing.Size(56, 17);
            ShinyTypeLabel1.TabIndex = 26;
            ShinyTypeLabel1.Text = "闪光种类";
            // 
            // ShinyTypeBox1
            // 
            ShinyTypeBox1.FormattingEnabled = true;
            ShinyTypeBox1.Location = new System.Drawing.Point(66, 44);
            ShinyTypeBox1.Name = "ShinyTypeBox1";
            ShinyTypeBox1.Size = new System.Drawing.Size(106, 25);
            ShinyTypeBox1.TabIndex = 27;
            // 
            // SeedBox
            // 
            SeedBox.Location = new System.Drawing.Point(214, 45);
            SeedBox.Name = "SeedBox";
            SeedBox.Size = new System.Drawing.Size(94, 23);
            SeedBox.TabIndex = 28;
            SeedBox.Text = "没有seed";
            // 
            // MethodBox
            // 
            MethodBox.FormattingEnabled = true;
            MethodBox.Location = new System.Drawing.Point(66, 11);
            MethodBox.Name = "MethodBox";
            MethodBox.Size = new System.Drawing.Size(105, 25);
            MethodBox.TabIndex = 29;
            // 
            // ConditionBox
            // 
            ConditionBox.Location = new System.Drawing.Point(214, 12);
            ConditionBox.Name = "ConditionBox";
            ConditionBox.Size = new System.Drawing.Size(94, 23);
            ConditionBox.TabIndex = 30;
            ConditionBox.Text = "无事可做";
            // 
            // RNGLabel
            // 
            RNGLabel.AutoSize = true;
            RNGLabel.Location = new System.Drawing.Point(3, 15);
            RNGLabel.Name = "RNGLabel";
            RNGLabel.Size = new System.Drawing.Size(59, 17);
            RNGLabel.TabIndex = 31;
            RNGLabel.Text = "RNG类型";
            // 
            // Condition_Lb
            // 
            Condition_Lb.AutoSize = true;
            Condition_Lb.Location = new System.Drawing.Point(177, 15);
            Condition_Lb.Name = "Condition_Lb";
            Condition_Lb.Size = new System.Drawing.Size(32, 17);
            Condition_Lb.TabIndex = 32;
            Condition_Lb.Text = "状态";
            // 
            // SeedLB
            // 
            SeedLB.AutoSize = true;
            SeedLB.Location = new System.Drawing.Point(176, 48);
            SeedLB.Name = "SeedLB";
            SeedLB.Size = new System.Drawing.Size(37, 17);
            SeedLB.TabIndex = 33;
            SeedLB.Text = "Seed";
            // 
            // PkmCondition
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(SeedLB);
            Controls.Add(Condition_Lb);
            Controls.Add(RNGLabel);
            Controls.Add(ConditionBox);
            Controls.Add(MethodBox);
            Controls.Add(SeedBox);
            Controls.Add(ShinyTypeBox1);
            Controls.Add(ShinyTypeLabel1);
            Controls.Add(SpeMax);
            Controls.Add(SpeMin);
            Controls.Add(SpdMax);
            Controls.Add(SpdMin);
            Controls.Add(SpaMax);
            Controls.Add(SpaMin);
            Controls.Add(DefMin);
            Controls.Add(DefMax);
            Controls.Add(AtkMax);
            Controls.Add(AtkMin);
            Controls.Add(Max_Label);
            Controls.Add(HpMax);
            Controls.Add(Min_Label);
            Controls.Add(HpMin);
            Controls.Add(Spe_Label);
            Controls.Add(Spd_Label);
            Controls.Add(Spa_Label);
            Controls.Add(Def_Label);
            Controls.Add(Atk_Label);
            Controls.Add(HP_Label);
            Name = "PkmCondition";
            Size = new System.Drawing.Size(329, 184);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label HP_Label;
        private System.Windows.Forms.Label Atk_Label;
        private System.Windows.Forms.Label Def_Label;
        private System.Windows.Forms.Label Spa_Label;
        private System.Windows.Forms.Label Spd_Label;
        private System.Windows.Forms.Label Spe_Label;
        private System.Windows.Forms.TextBox HpMin;
        private System.Windows.Forms.Label Min_Label;
        private System.Windows.Forms.TextBox HpMax;
        private System.Windows.Forms.Label Max_Label;
        private System.Windows.Forms.TextBox AtkMin;
        private System.Windows.Forms.TextBox AtkMax;
        private System.Windows.Forms.TextBox DefMax;
        private System.Windows.Forms.TextBox DefMin;
        private System.Windows.Forms.TextBox SpaMin;
        private System.Windows.Forms.TextBox SpaMax;
        private System.Windows.Forms.TextBox SpdMin;
        private System.Windows.Forms.TextBox SpdMax;
        private System.Windows.Forms.TextBox SpeMin;
        private System.Windows.Forms.TextBox SpeMax;
        private System.Windows.Forms.Label ShinyTypeLabel1;
        private System.Windows.Forms.ComboBox ShinyTypeBox1;
        public System.Windows.Forms.TextBox SeedBox;
        private System.Windows.Forms.ComboBox MethodBox;
        public System.Windows.Forms.TextBox ConditionBox;
        private System.Windows.Forms.Label RNGLabel;
        private System.Windows.Forms.Label Condition_Lb;
        private System.Windows.Forms.Label SeedLB;
    }
}