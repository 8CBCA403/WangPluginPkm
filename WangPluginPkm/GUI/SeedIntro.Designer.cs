using System.Windows.Forms;

namespace WangPluginPkm.GUI
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
            SeedInstroList = new ListView();
            TextBox = new TextBox();
            TeamLockTextBox = new TextBox();
            SuspendLayout();
            // 
            // SeedInstroList
            // 
            SeedInstroList.Location = new System.Drawing.Point(10, 305);
            SeedInstroList.Margin = new Padding(3, 4, 3, 4);
            SeedInstroList.Name = "SeedInstroList";
            SeedInstroList.Size = new System.Drawing.Size(660, 331);
            SeedInstroList.TabIndex = 0;
            SeedInstroList.UseCompatibleStateImageBehavior = false;
            // 
            // TextBox
            // 
            TextBox.Location = new System.Drawing.Point(10, 25);
            TextBox.Margin = new Padding(3, 4, 3, 4);
            TextBox.Multiline = true;
            TextBox.Name = "TextBox";
            TextBox.Size = new System.Drawing.Size(662, 132);
            TextBox.TabIndex = 1;
            TextBox.Text = "RNG面板使用说明\r\n1.本工具查找功能对象为PKHeX左侧面板精灵，使用前先将需要查找的精灵拖拽至左侧面板\r\n2.请使用本世代存档进行操作（如：现需要查找Method1类型Gen3小火龙则需要打开火红/叶绿存档进行操作，而不应打开如日月存档跨世代操作，可能出现卡死）\r\n3.如需特殊IV请使用预制种子，详情见下表。\r\n4.XDColo队锁只限于XDColo部分精灵,详情见下表";
            // 
            // TeamLockTextBox
            // 
            TeamLockTextBox.Location = new System.Drawing.Point(10, 167);
            TeamLockTextBox.Margin = new Padding(3, 4, 3, 4);
            TeamLockTextBox.Multiline = true;
            TeamLockTextBox.Name = "TeamLockTextBox";
            TeamLockTextBox.ScrollBars = ScrollBars.Vertical;
            TeamLockTextBox.Size = new System.Drawing.Size(660, 129);
            TeamLockTextBox.TabIndex = 2;
            TeamLockTextBox.Text = resources.GetString("TeamLockTextBox.Text");
            // 
            // SeedIntro
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(683, 663);
            Controls.Add(TeamLockTextBox);
            Controls.Add(TextBox);
            Controls.Add(SeedInstroList);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "SeedIntro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SeedInfo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListView SeedInstroList;
        private TextBox TextBox;
        private TextBox TeamLockTextBox;
    }
}