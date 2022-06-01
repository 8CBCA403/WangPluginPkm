using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace WangPlugin.GUI
{
    internal class AboutUI: Form
    {
        private PictureBox PictureBox;
        private RichTextBox AboutTextBox;
        public AboutUI()
        {
            InitializeComponent();
            CreateBox();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutUI));
            this.AboutTextBox = new System.Windows.Forms.RichTextBox();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AboutTextBox
            // 
            this.AboutTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutTextBox.Location = new System.Drawing.Point(12, 12);
            this.AboutTextBox.Name = "AboutTextBox";
            this.AboutTextBox.ReadOnly = true;
            this.AboutTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.AboutTextBox.Size = new System.Drawing.Size(493, 255);
            this.AboutTextBox.TabIndex = 0;
            this.AboutTextBox.Text = "";
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(511, 12);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(255, 255);
            this.PictureBox.TabIndex = 1;
            this.PictureBox.TabStop = false;
            // 
            // AboutUI
            // 
            this.ClientSize = new System.Drawing.Size(778, 281);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.AboutTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);

        }
        private void CreateBox()
        {
            AboutTextBox.Text =Properties.Resources.About;
            PictureBox.Image = Properties.Resources.Wanghaoran;
        }
    }
}
