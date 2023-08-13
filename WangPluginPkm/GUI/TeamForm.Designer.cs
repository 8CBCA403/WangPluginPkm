namespace WangPluginPkm.GUI
{
    partial class TeamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamForm));
            TeamListBox = new System.Windows.Forms.CheckedListBox();
            PSText = new System.Windows.Forms.TextBox();
            Import_BTN = new System.Windows.Forms.Button();
            Clear_BTN = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // TeamListBox
            // 
            TeamListBox.FormattingEnabled = true;
            TeamListBox.Location = new System.Drawing.Point(12, 11);
            TeamListBox.Name = "TeamListBox";
            TeamListBox.Size = new System.Drawing.Size(323, 454);
            TeamListBox.TabIndex = 1;
            TeamListBox.SelectedIndexChanged += TeamListBox_SelectedIndexChanged;
            // 
            // PSText
            // 
            PSText.Location = new System.Drawing.Point(341, 12);
            PSText.Multiline = true;
            PSText.Name = "PSText";
            PSText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            PSText.Size = new System.Drawing.Size(322, 422);
            PSText.TabIndex = 2;
            // 
            // Import_BTN
            // 
            Import_BTN.Location = new System.Drawing.Point(508, 440);
            Import_BTN.Name = "Import_BTN";
            Import_BTN.Size = new System.Drawing.Size(129, 25);
            Import_BTN.TabIndex = 3;
            Import_BTN.Text = "导出PS";
            Import_BTN.UseVisualStyleBackColor = true;
            Import_BTN.Click += Import_BTN_Click;
            // 
            // Clear_BTN
            // 
            Clear_BTN.Location = new System.Drawing.Point(373, 440);
            Clear_BTN.Name = "Clear_BTN";
            Clear_BTN.Size = new System.Drawing.Size(129, 25);
            Clear_BTN.TabIndex = 4;
            Clear_BTN.Text = "清屏";
            Clear_BTN.UseVisualStyleBackColor = true;
            Clear_BTN.Click += Clear_BTN_Click;
            // 
            // TeamForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(672, 477);
            Controls.Add(Clear_BTN);
            Controls.Add(Import_BTN);
            Controls.Add(PSText);
            Controls.Add(TeamListBox);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "TeamForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "TeamForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public System.Windows.Forms.CheckedListBox TeamListBox;
        private System.Windows.Forms.TextBox PSText;
        public  System.Windows.Forms.Button Import_BTN;
        private System.Windows.Forms.Button Clear_BTN;
    }
}