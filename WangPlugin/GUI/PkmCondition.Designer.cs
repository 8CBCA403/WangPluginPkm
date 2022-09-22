namespace WangPlugin.GUI
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
            this.HP_Label = new System.Windows.Forms.Label();
            this.Atk_Label = new System.Windows.Forms.Label();
            this.Def_Label = new System.Windows.Forms.Label();
            this.Spa_Label = new System.Windows.Forms.Label();
            this.Spd_Label = new System.Windows.Forms.Label();
            this.Spe_Label = new System.Windows.Forms.Label();
            this.HpMin = new System.Windows.Forms.TextBox();
            this.Min_Label = new System.Windows.Forms.Label();
            this.HpMax = new System.Windows.Forms.TextBox();
            this.Max_Label = new System.Windows.Forms.Label();
            this.AtkMin = new System.Windows.Forms.TextBox();
            this.AtkMax = new System.Windows.Forms.TextBox();
            this.DefMax = new System.Windows.Forms.TextBox();
            this.DefMin = new System.Windows.Forms.TextBox();
            this.SpaMin = new System.Windows.Forms.TextBox();
            this.SpaMax = new System.Windows.Forms.TextBox();
            this.SpdMin = new System.Windows.Forms.TextBox();
            this.SpdMax = new System.Windows.Forms.TextBox();
            this.SpeMin = new System.Windows.Forms.TextBox();
            this.SpeMax = new System.Windows.Forms.TextBox();
            this.ShinyTypeLabel1 = new System.Windows.Forms.Label();
            this.ShinyTypeBox1 = new System.Windows.Forms.ComboBox();
            this.SeedBox = new System.Windows.Forms.TextBox();
            this.MethodBox = new System.Windows.Forms.ComboBox();
            this.ConditionBox = new System.Windows.Forms.TextBox();
            this.RNGLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HP_Label
            // 
            this.HP_Label.AutoSize = true;
            this.HP_Label.Location = new System.Drawing.Point(73, 68);
            this.HP_Label.Name = "HP_Label";
            this.HP_Label.Size = new System.Drawing.Size(37, 15);
            this.HP_Label.TabIndex = 6;
            this.HP_Label.Text = "血量";
            // 
            // Atk_Label
            // 
            this.Atk_Label.AutoSize = true;
            this.Atk_Label.Location = new System.Drawing.Point(116, 68);
            this.Atk_Label.Name = "Atk_Label";
            this.Atk_Label.Size = new System.Drawing.Size(37, 15);
            this.Atk_Label.TabIndex = 7;
            this.Atk_Label.Text = "物攻";
            // 
            // Def_Label
            // 
            this.Def_Label.AutoSize = true;
            this.Def_Label.Location = new System.Drawing.Point(159, 68);
            this.Def_Label.Name = "Def_Label";
            this.Def_Label.Size = new System.Drawing.Size(37, 15);
            this.Def_Label.TabIndex = 8;
            this.Def_Label.Text = "物防";
            // 
            // Spa_Label
            // 
            this.Spa_Label.AutoSize = true;
            this.Spa_Label.Location = new System.Drawing.Point(202, 68);
            this.Spa_Label.Name = "Spa_Label";
            this.Spa_Label.Size = new System.Drawing.Size(37, 15);
            this.Spa_Label.TabIndex = 9;
            this.Spa_Label.Text = "特攻";
            // 
            // Spd_Label
            // 
            this.Spd_Label.AutoSize = true;
            this.Spd_Label.Location = new System.Drawing.Point(245, 68);
            this.Spd_Label.Name = "Spd_Label";
            this.Spd_Label.Size = new System.Drawing.Size(37, 15);
            this.Spd_Label.TabIndex = 10;
            this.Spd_Label.Text = "特防";
            // 
            // Spe_Label
            // 
            this.Spe_Label.AutoSize = true;
            this.Spe_Label.Location = new System.Drawing.Point(288, 68);
            this.Spe_Label.Name = "Spe_Label";
            this.Spe_Label.Size = new System.Drawing.Size(37, 15);
            this.Spe_Label.TabIndex = 11;
            this.Spe_Label.Text = "速度";
            // 
            // HpMin
            // 
            this.HpMin.Location = new System.Drawing.Point(76, 95);
            this.HpMin.Name = "HpMin";
            this.HpMin.Size = new System.Drawing.Size(34, 25);
            this.HpMin.TabIndex = 12;
            this.HpMin.Text = "0";
            this.HpMin.TextChanged += new System.EventHandler(this.IVS_TextChanged);
            // 
            // Min_Label
            // 
            this.Min_Label.AutoSize = true;
            this.Min_Label.Location = new System.Drawing.Point(12, 98);
            this.Min_Label.Name = "Min_Label";
            this.Min_Label.Size = new System.Drawing.Size(52, 15);
            this.Min_Label.TabIndex = 13;
            this.Min_Label.Text = "最小值";
            // 
            // HpMax
            // 
            this.HpMax.Location = new System.Drawing.Point(76, 128);
            this.HpMax.Name = "HpMax";
            this.HpMax.Size = new System.Drawing.Size(34, 25);
            this.HpMax.TabIndex = 14;
            this.HpMax.Text = "31";
            this.HpMax.TextChanged += new System.EventHandler(this.IVS_TextChanged);
            // 
            // Max_Label
            // 
            this.Max_Label.AutoSize = true;
            this.Max_Label.Location = new System.Drawing.Point(12, 131);
            this.Max_Label.Name = "Max_Label";
            this.Max_Label.Size = new System.Drawing.Size(52, 15);
            this.Max_Label.TabIndex = 15;
            this.Max_Label.Text = "最大值";
            // 
            // AtkMin
            // 
            this.AtkMin.Location = new System.Drawing.Point(119, 95);
            this.AtkMin.Name = "AtkMin";
            this.AtkMin.Size = new System.Drawing.Size(34, 25);
            this.AtkMin.TabIndex = 16;
            this.AtkMin.Text = "0";
            this.AtkMin.TextChanged += new System.EventHandler(this.IVS_TextChanged);
            // 
            // AtkMax
            // 
            this.AtkMax.Location = new System.Drawing.Point(119, 128);
            this.AtkMax.Name = "AtkMax";
            this.AtkMax.Size = new System.Drawing.Size(34, 25);
            this.AtkMax.TabIndex = 17;
            this.AtkMax.Text = "31";
            this.AtkMax.TextChanged += new System.EventHandler(this.IVS_TextChanged);
            // 
            // DefMax
            // 
            this.DefMax.Location = new System.Drawing.Point(162, 128);
            this.DefMax.Name = "DefMax";
            this.DefMax.Size = new System.Drawing.Size(34, 25);
            this.DefMax.TabIndex = 18;
            this.DefMax.Text = "31";
            this.DefMax.TextChanged += new System.EventHandler(this.IVS_TextChanged);
            // 
            // DefMin
            // 
            this.DefMin.Location = new System.Drawing.Point(162, 95);
            this.DefMin.Name = "DefMin";
            this.DefMin.Size = new System.Drawing.Size(34, 25);
            this.DefMin.TabIndex = 19;
            this.DefMin.Text = "0";
            this.DefMin.TextChanged += new System.EventHandler(this.IVS_TextChanged);
            // 
            // SpaMin
            // 
            this.SpaMin.Location = new System.Drawing.Point(205, 95);
            this.SpaMin.Name = "SpaMin";
            this.SpaMin.Size = new System.Drawing.Size(34, 25);
            this.SpaMin.TabIndex = 20;
            this.SpaMin.Text = "0";
            this.SpaMin.TextChanged += new System.EventHandler(this.IVS_TextChanged);
            // 
            // SpaMax
            // 
            this.SpaMax.Location = new System.Drawing.Point(205, 128);
            this.SpaMax.Name = "SpaMax";
            this.SpaMax.Size = new System.Drawing.Size(34, 25);
            this.SpaMax.TabIndex = 21;
            this.SpaMax.Text = "31";
            this.SpaMax.TextChanged += new System.EventHandler(this.IVS_TextChanged);
            // 
            // SpdMin
            // 
            this.SpdMin.Location = new System.Drawing.Point(248, 95);
            this.SpdMin.Name = "SpdMin";
            this.SpdMin.Size = new System.Drawing.Size(34, 25);
            this.SpdMin.TabIndex = 22;
            this.SpdMin.Text = "0";
            this.SpdMin.TextChanged += new System.EventHandler(this.IVS_TextChanged);
            // 
            // SpdMax
            // 
            this.SpdMax.Location = new System.Drawing.Point(248, 128);
            this.SpdMax.Name = "SpdMax";
            this.SpdMax.Size = new System.Drawing.Size(34, 25);
            this.SpdMax.TabIndex = 23;
            this.SpdMax.Text = "31";
            this.SpdMax.TextChanged += new System.EventHandler(this.IVS_TextChanged);
            // 
            // SpeMin
            // 
            this.SpeMin.Location = new System.Drawing.Point(291, 95);
            this.SpeMin.Name = "SpeMin";
            this.SpeMin.Size = new System.Drawing.Size(34, 25);
            this.SpeMin.TabIndex = 24;
            this.SpeMin.Text = "0";
            this.SpeMin.TextChanged += new System.EventHandler(this.IVS_TextChanged);
            // 
            // SpeMax
            // 
            this.SpeMax.Location = new System.Drawing.Point(291, 128);
            this.SpeMax.Name = "SpeMax";
            this.SpeMax.Size = new System.Drawing.Size(34, 25);
            this.SpeMax.TabIndex = 25;
            this.SpeMax.Text = "31";
            this.SpeMax.TextChanged += new System.EventHandler(this.IVS_TextChanged);
            // 
            // ShinyTypeLabel1
            // 
            this.ShinyTypeLabel1.AutoSize = true;
            this.ShinyTypeLabel1.Location = new System.Drawing.Point(3, 42);
            this.ShinyTypeLabel1.Name = "ShinyTypeLabel1";
            this.ShinyTypeLabel1.Size = new System.Drawing.Size(67, 15);
            this.ShinyTypeLabel1.TabIndex = 26;
            this.ShinyTypeLabel1.Text = "闪光种类";
            // 
            // ShinyTypeBox1
            // 
            this.ShinyTypeBox1.FormattingEnabled = true;
            this.ShinyTypeBox1.Location = new System.Drawing.Point(76, 39);
            this.ShinyTypeBox1.Name = "ShinyTypeBox1";
            this.ShinyTypeBox1.Size = new System.Drawing.Size(136, 23);
            this.ShinyTypeBox1.TabIndex = 27;
            // 
            // SeedBox
            // 
            this.SeedBox.Location = new System.Drawing.Point(218, 39);
            this.SeedBox.Multiline = true;
            this.SeedBox.Name = "SeedBox";
            this.SeedBox.Size = new System.Drawing.Size(107, 23);
            this.SeedBox.TabIndex = 28;
            this.SeedBox.Text = "没有seed";
            // 
            // MethodBox
            // 
            this.MethodBox.FormattingEnabled = true;
            this.MethodBox.Location = new System.Drawing.Point(76, 10);
            this.MethodBox.Name = "MethodBox";
            this.MethodBox.Size = new System.Drawing.Size(136, 23);
            this.MethodBox.TabIndex = 29;
            // 
            // ConditionBox
            // 
            this.ConditionBox.Location = new System.Drawing.Point(218, 10);
            this.ConditionBox.Multiline = true;
            this.ConditionBox.Name = "ConditionBox";
            this.ConditionBox.Size = new System.Drawing.Size(107, 23);
            this.ConditionBox.TabIndex = 30;
            this.ConditionBox.Text = "无事可做";
            // 
            // RNGLabel
            // 
            this.RNGLabel.AutoSize = true;
            this.RNGLabel.Location = new System.Drawing.Point(3, 13);
            this.RNGLabel.Name = "RNGLabel";
            this.RNGLabel.Size = new System.Drawing.Size(61, 15);
            this.RNGLabel.TabIndex = 31;
            this.RNGLabel.Text = "RNG类型";
            // 
            // PkmCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RNGLabel);
            this.Controls.Add(this.ConditionBox);
            this.Controls.Add(this.MethodBox);
            this.Controls.Add(this.SeedBox);
            this.Controls.Add(this.ShinyTypeBox1);
            this.Controls.Add(this.ShinyTypeLabel1);
            this.Controls.Add(this.SpeMax);
            this.Controls.Add(this.SpeMin);
            this.Controls.Add(this.SpdMax);
            this.Controls.Add(this.SpdMin);
            this.Controls.Add(this.SpaMax);
            this.Controls.Add(this.SpaMin);
            this.Controls.Add(this.DefMin);
            this.Controls.Add(this.DefMax);
            this.Controls.Add(this.AtkMax);
            this.Controls.Add(this.AtkMin);
            this.Controls.Add(this.Max_Label);
            this.Controls.Add(this.HpMax);
            this.Controls.Add(this.Min_Label);
            this.Controls.Add(this.HpMin);
            this.Controls.Add(this.Spe_Label);
            this.Controls.Add(this.Spd_Label);
            this.Controls.Add(this.Spa_Label);
            this.Controls.Add(this.Def_Label);
            this.Controls.Add(this.Atk_Label);
            this.Controls.Add(this.HP_Label);
            this.Name = "PkmCondition";
            this.Size = new System.Drawing.Size(347, 162);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}