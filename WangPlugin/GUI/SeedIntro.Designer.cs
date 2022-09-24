using System.Windows.Forms;

namespace WangPlugin.GUI
{
    partial class SeedIntro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeedIntro));
            this.SeedInstroList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // SeedInstroList
            // 
            this.SeedInstroList.HideSelection = false;
            this.SeedInstroList.Location = new System.Drawing.Point(12, 12);
            this.SeedInstroList.Name = "SeedInstroList";
            this.SeedInstroList.Size = new System.Drawing.Size(660, 270);
            this.SeedInstroList.TabIndex = 0;
            this.SeedInstroList.UseCompatibleStateImageBehavior = false;
            // 
            // SeedIntro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 293);
            this.Controls.Add(this.SeedInstroList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SeedIntro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeedInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView SeedInstroList;
    }
}