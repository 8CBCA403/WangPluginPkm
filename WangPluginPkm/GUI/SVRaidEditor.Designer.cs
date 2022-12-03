namespace WangPluginPkm.GUI
{
    partial class SVRaidEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SVRaidEditor));
            this.IPBox = new System.Windows.Forms.TextBox();
            this.IPLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.Connect_BTN = new System.Windows.Forms.Button();
            this.ReadRaid_BTN = new System.Windows.Forms.Button();
            this.SeedGenBTN = new System.Windows.Forms.Button();
            this.SeedBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(44, 21);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(149, 22);
            this.IPBox.TabIndex = 0;
            this.IPBox.TextChanged += new System.EventHandler(this.IPBox_Changed);
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(19, 24);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(19, 16);
            this.IPLabel.TabIndex = 1;
            this.IPLabel.Text = "IP";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(7, 53);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(31, 16);
            this.PortLabel.TabIndex = 2;
            this.PortLabel.Text = "Port";
            // 
            // PortBox
            // 
            this.PortBox.Location = new System.Drawing.Point(44, 50);
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(56, 22);
            this.PortBox.TabIndex = 3;
            // 
            // Connect_BTN
            // 
            this.Connect_BTN.Location = new System.Drawing.Point(106, 50);
            this.Connect_BTN.Name = "Connect_BTN";
            this.Connect_BTN.Size = new System.Drawing.Size(87, 23);
            this.Connect_BTN.TabIndex = 4;
            this.Connect_BTN.Text = "Connect";
            this.Connect_BTN.UseVisualStyleBackColor = true;
            this.Connect_BTN.Click += new System.EventHandler(this.Connect_BTN_Click);
            // 
            // ReadRaid_BTN
            // 
            this.ReadRaid_BTN.Location = new System.Drawing.Point(13, 78);
            this.ReadRaid_BTN.Name = "ReadRaid_BTN";
            this.ReadRaid_BTN.Size = new System.Drawing.Size(87, 23);
            this.ReadRaid_BTN.TabIndex = 5;
            this.ReadRaid_BTN.Text = "Read";
            this.ReadRaid_BTN.UseVisualStyleBackColor = true;
            this.ReadRaid_BTN.Click += new System.EventHandler(this.ReadRaid_BTN_Click);
            // 
            // SeedGenBTN
            // 
            this.SeedGenBTN.Location = new System.Drawing.Point(352, 24);
            this.SeedGenBTN.Name = "SeedGenBTN";
            this.SeedGenBTN.Size = new System.Drawing.Size(114, 33);
            this.SeedGenBTN.TabIndex = 6;
            this.SeedGenBTN.Text = "生成闪Seed";
            this.SeedGenBTN.UseVisualStyleBackColor = true;
            this.SeedGenBTN.Click += new System.EventHandler(this.SeedGenBTN_Click);
            // 
            // SeedBox
            // 
            this.SeedBox.Location = new System.Drawing.Point(246, 29);
            this.SeedBox.Name = "SeedBox";
            this.SeedBox.Size = new System.Drawing.Size(100, 22);
            this.SeedBox.TabIndex = 7;
            // 
            // SVRaidEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 214);
            this.Controls.Add(this.SeedBox);
            this.Controls.Add(this.SeedGenBTN);
            this.Controls.Add(this.ReadRaid_BTN);
            this.Controls.Add(this.Connect_BTN);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.IPLabel);
            this.Controls.Add(this.IPBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SVRaidEditor";
            this.Text = "SVRaidEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.TextBox PortBox;
        private System.Windows.Forms.Button Connect_BTN;
        private System.Windows.Forms.Button ReadRaid_BTN;
        private System.Windows.Forms.Button SeedGenBTN;
        private System.Windows.Forms.TextBox SeedBox;
    }
}