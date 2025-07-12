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
            TeamListBox.Location = new System.Drawing.Point(14, 13);
            TeamListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            TeamListBox.Name = "TeamListBox";
            TeamListBox.Size = new System.Drawing.Size(369, 532);
            TeamListBox.TabIndex = 1;
            TeamListBox.SelectedIndexChanged += TeamListBox_SelectedIndexChanged;
            // 
            // PSText
            // 
            PSText.Location = new System.Drawing.Point(390, 14);
            PSText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            PSText.Multiline = true;
            PSText.Name = "PSText";
            PSText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            PSText.Size = new System.Drawing.Size(367, 496);
            PSText.TabIndex = 2;
            // 
            // Import_BTN
            // 
            Import_BTN.Location = new System.Drawing.Point(581, 518);
            Import_BTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Import_BTN.Name = "Import_BTN";
            Import_BTN.Size = new System.Drawing.Size(147, 29);
            Import_BTN.TabIndex = 3;
            Import_BTN.Text = "导出PS";
            Import_BTN.UseVisualStyleBackColor = true;
            Import_BTN.Click += Import_BTN_Click;
            // 
            // Clear_BTN
            // 
            Clear_BTN.Location = new System.Drawing.Point(426, 518);
            Clear_BTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Clear_BTN.Name = "Clear_BTN";
            Clear_BTN.Size = new System.Drawing.Size(147, 29);
            Clear_BTN.TabIndex = 4;
            Clear_BTN.Text = "清屏";
            Clear_BTN.UseVisualStyleBackColor = true;
            Clear_BTN.Click += Clear_BTN_Click;
            // 
            // TeamForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(768, 561);
            Controls.Add(Clear_BTN);
            Controls.Add(Import_BTN);
            Controls.Add(PSText);
            Controls.Add(TeamListBox);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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