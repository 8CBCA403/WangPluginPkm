using System.Windows.Forms;

namespace WangPluginPkm.GUI
{
    partial class AboutUI
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutUI));
            AboutTextBox = new RichTextBox();
            PictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            SuspendLayout();
            // 
            // AboutTextBox
            // 
            AboutTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            AboutTextBox.Location = new System.Drawing.Point(12, 12);
            AboutTextBox.Name = "AboutTextBox";
            AboutTextBox.ReadOnly = true;
            AboutTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            AboutTextBox.Size = new System.Drawing.Size(493, 255);
            AboutTextBox.TabIndex = 0;
            AboutTextBox.Text = "";
            // 
            // PictureBox
            // 
            PictureBox.Location = new System.Drawing.Point(511, 12);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new System.Drawing.Size(255, 255);
            PictureBox.TabIndex = 1;
            PictureBox.TabStop = false;
            // 
            // AboutUI
            // 
            ClientSize = new System.Drawing.Size(778, 281);
            Controls.Add(PictureBox);
            Controls.Add(AboutTextBox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AboutUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Super Wang";
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            ResumeLayout(false);
        }

        private PictureBox PictureBox;
        private RichTextBox AboutTextBox;
    }
}
