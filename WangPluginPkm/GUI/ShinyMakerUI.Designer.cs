using System.Windows.Forms;

namespace WangPluginPkm.GUI
{
    partial class ShinyMakerUI
    {
        private Button ShinySID_BTN;
        private Button RandomStar_BTN;
        private Button ForceSquare_BTN;
        private ComboBox XorBox;
        private Button Xor_BTN;
        private Button ForceStar;
        private Label XorValue_Label;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShinyMakerUI));
            this.ShinySID_BTN = new System.Windows.Forms.Button();
            this.RandomStar_BTN = new System.Windows.Forms.Button();
            this.ForceSquare_BTN = new System.Windows.Forms.Button();
            this.XorBox = new System.Windows.Forms.ComboBox();
            this.Xor_BTN = new System.Windows.Forms.Button();
            this.ForceStar = new System.Windows.Forms.Button();
            this.XorValue_Label = new System.Windows.Forms.Label();
            this.RangeBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ShinySID_BTN
            // 
            this.ShinySID_BTN.Font = new System.Drawing.Font("SimHei", 9F);
            this.ShinySID_BTN.Location = new System.Drawing.Point(130, 45);
            this.ShinySID_BTN.Name = "ShinySID_BTN";
            this.ShinySID_BTN.Size = new System.Drawing.Size(120, 30);
            this.ShinySID_BTN.TabIndex = 0;
            this.ShinySID_BTN.Text = "随机SID闪光";
            this.ShinySID_BTN.UseVisualStyleBackColor = true;
            this.ShinySID_BTN.Click += new System.EventHandler(this.ShinySID_BTN_Click);
            // 
            // RandomStar_BTN
            // 
            this.RandomStar_BTN.Font = new System.Drawing.Font("SimHei", 9F);
            this.RandomStar_BTN.Location = new System.Drawing.Point(130, 12);
            this.RandomStar_BTN.Name = "RandomStar_BTN";
            this.RandomStar_BTN.Size = new System.Drawing.Size(120, 30);
            this.RandomStar_BTN.TabIndex = 1;
            this.RandomStar_BTN.Text = "一键闪光";
            this.RandomStar_BTN.UseVisualStyleBackColor = true;
            this.RandomStar_BTN.Click += new System.EventHandler(this.Shiny_BTN_Click);
            // 
            // ForceSquare_BTN
            // 
            this.ForceSquare_BTN.Font = new System.Drawing.Font("SimHei", 9F);
            this.ForceSquare_BTN.Location = new System.Drawing.Point(400, 12);
            this.ForceSquare_BTN.Name = "ForceSquare_BTN";
            this.ForceSquare_BTN.Size = new System.Drawing.Size(120, 30);
            this.ForceSquare_BTN.TabIndex = 2;
            this.ForceSquare_BTN.Text = "强制方块";
            this.ForceSquare_BTN.UseVisualStyleBackColor = true;
            this.ForceSquare_BTN.Click += new System.EventHandler(this.ForceSquare_BTN_Click);
            // 
            // XorBox
            // 
            this.XorBox.FormattingEnabled = true;
            this.XorBox.Location = new System.Drawing.Point(312, 48);
            this.XorBox.Name = "XorBox";
            this.XorBox.Size = new System.Drawing.Size(73, 24);
            this.XorBox.TabIndex = 3;
            // 
            // Xor_BTN
            // 
            this.Xor_BTN.Font = new System.Drawing.Font("SimHei", 9F);
            this.Xor_BTN.Location = new System.Drawing.Point(400, 45);
            this.Xor_BTN.Name = "Xor_BTN";
            this.Xor_BTN.Size = new System.Drawing.Size(120, 30);
            this.Xor_BTN.TabIndex = 4;
            this.Xor_BTN.Text = "指定Xor闪光";
            this.Xor_BTN.UseVisualStyleBackColor = true;
            this.Xor_BTN.Click += new System.EventHandler(this.Xor_BTN_Click);
            // 
            // ForceStar
            // 
            this.ForceStar.Font = new System.Drawing.Font("SimHei", 9F);
            this.ForceStar.Location = new System.Drawing.Point(265, 12);
            this.ForceStar.Name = "ForceStar";
            this.ForceStar.Size = new System.Drawing.Size(120, 30);
            this.ForceStar.TabIndex = 5;
            this.ForceStar.Text = "强制星星";
            this.ForceStar.UseVisualStyleBackColor = true;
            this.ForceStar.Click += new System.EventHandler(this.ForceStar_Click);
            // 
            // XorValue_Label
            // 
            this.XorValue_Label.AutoSize = true;
            this.XorValue_Label.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XorValue_Label.Location = new System.Drawing.Point(261, 49);
            this.XorValue_Label.Name = "XorValue_Label";
            this.XorValue_Label.Size = new System.Drawing.Size(45, 19);
            this.XorValue_Label.TabIndex = 6;
            this.XorValue_Label.Text = "Xor=";
            // 
            // RangeBox
            // 
            this.RangeBox.FormattingEnabled = true;
            this.RangeBox.Location = new System.Drawing.Point(12, 12);
            this.RangeBox.Name = "RangeBox";
            this.RangeBox.Size = new System.Drawing.Size(112, 24);
            this.RangeBox.TabIndex = 7;
            // 
            // ShinyMakerUI
            // 
            this.AllowDrop = true;
            this.ClientSize = new System.Drawing.Size(549, 82);
            this.Controls.Add(this.RangeBox);
            this.Controls.Add(this.XorValue_Label);
            this.Controls.Add(this.ForceStar);
            this.Controls.Add(this.Xor_BTN);
            this.Controls.Add(this.XorBox);
            this.Controls.Add(this.ForceSquare_BTN);
            this.Controls.Add(this.RandomStar_BTN);
            this.Controls.Add(this.ShinySID_BTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ShinyMakerUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ComboBox RangeBox;
    }
}
