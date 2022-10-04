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
            this.TextBox = new System.Windows.Forms.TextBox();
            this.TeamLockTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SeedInstroList
            // 
            this.SeedInstroList.HideSelection = false;
            this.SeedInstroList.Location = new System.Drawing.Point(10, 229);
            this.SeedInstroList.Name = "SeedInstroList";
            this.SeedInstroList.Size = new System.Drawing.Size(660, 249);
            this.SeedInstroList.TabIndex = 0;
            this.SeedInstroList.UseCompatibleStateImageBehavior = false;
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(10, 19);
            this.TextBox.Multiline = true;
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(662, 100);
            this.TextBox.TabIndex = 1;
            this.TextBox.Text = "RNG面板使用说明\r\n1.本工具查找功能对象为PKHeX左侧面板精灵，使用前先将需要查找的精灵拖拽至左侧面板\r\n2.请使用本世代存档进行操作（如：现需要查找Met" +
    "hod1类型Gen3小火龙则需要打开火红/叶绿存档进行操作，而不应打开如日月存档跨世代操作，可能出现卡死）\r\n3.如需特殊IV请使用预制种子，详情见下表。\r\n4.XDColo队锁只限于XDColo部分精灵," +
    "详情见下表";
            // 
            // TeamLockTextBox
            // 
            this.TeamLockTextBox.Location = new System.Drawing.Point(10, 125);
            this.TeamLockTextBox.Multiline = true;
            this.TeamLockTextBox.Name = "TeamLockTextBox";
            this.TeamLockTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TeamLockTextBox.Size = new System.Drawing.Size(660, 98);
            this.TeamLockTextBox.TabIndex = 2;
            this.TeamLockTextBox.Text = resources.GetString("TeamLockTextBox.Text");
            // 
            // SeedIntro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 497);
            this.Controls.Add(this.TeamLockTextBox);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.SeedInstroList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SeedIntro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeedInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView SeedInstroList;
        private TextBox TextBox;
        private TextBox TeamLockTextBox;
    }
}