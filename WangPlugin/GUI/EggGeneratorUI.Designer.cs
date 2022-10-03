using System.Windows.Forms;

namespace WangPlugin.GUI
{
    partial class EggGeneratorUI
    {
        private TextBox Version;
        private ComboBox Number_Box;
        private CheckBox Form_CheckBox;
        private CheckBox Gender_CheckBox;
        private CheckBox Ability_CheckBox;
        private CheckBox RelearnMovcheckBox;
        private Button GEgg;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EggGeneratorUI));
            this.GEgg = new System.Windows.Forms.Button();
            this.Version = new System.Windows.Forms.TextBox();
            this.Number_Box = new System.Windows.Forms.ComboBox();
            this.Form_CheckBox = new System.Windows.Forms.CheckBox();
            this.Gender_CheckBox = new System.Windows.Forms.CheckBox();
            this.Ability_CheckBox = new System.Windows.Forms.CheckBox();
            this.RelearnMovcheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // GEgg
            // 
            this.GEgg.Font = new System.Drawing.Font("黑体", 9F);
            this.GEgg.Location = new System.Drawing.Point(248, 10);
            this.GEgg.Name = "GEgg";
            this.GEgg.Size = new System.Drawing.Size(104, 25);
            this.GEgg.TabIndex = 0;
            this.GEgg.Text = "生成蛋";
            this.GEgg.UseVisualStyleBackColor = true;
            this.GEgg.Click += new System.EventHandler(this.GEgg_Click);
            // 
            // Version
            // 
            this.Version.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Version.Location = new System.Drawing.Point(21, 10);
            this.Version.Multiline = true;
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(95, 25);
            this.Version.TabIndex = 1;
            this.Version.Text = "No Save";
            // 
            // Number_Box
            // 
            this.Number_Box.FormattingEnabled = true;
            this.Number_Box.ItemHeight = 17;
            this.Number_Box.Location = new System.Drawing.Point(122, 10);
            this.Number_Box.Name = "Number_Box";
            this.Number_Box.Size = new System.Drawing.Size(120, 25);
            this.Number_Box.TabIndex = 2;
            // 
            // Form_CheckBox
            // 
            this.Form_CheckBox.AutoSize = true;
            this.Form_CheckBox.Location = new System.Drawing.Point(21, 41);
            this.Form_CheckBox.Name = "Form_CheckBox";
            this.Form_CheckBox.Size = new System.Drawing.Size(126, 21);
            this.Form_CheckBox.TabIndex = 3;
            this.Form_CheckBox.Text = "保持地区形态";
            this.Form_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Gender_CheckBox
            // 
            this.Gender_CheckBox.AutoSize = true;
            this.Gender_CheckBox.Location = new System.Drawing.Point(142, 41);
            this.Gender_CheckBox.Name = "Gender_CheckBox";
            this.Gender_CheckBox.Size = new System.Drawing.Size(94, 21);
            this.Gender_CheckBox.TabIndex = 4;
            this.Gender_CheckBox.Text = "保持性别";
            this.Gender_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Ability_CheckBox
            // 
            this.Ability_CheckBox.AutoSize = true;
            this.Ability_CheckBox.Location = new System.Drawing.Point(242, 41);
            this.Ability_CheckBox.Name = "Ability_CheckBox";
            this.Ability_CheckBox.Size = new System.Drawing.Size(94, 21);
            this.Ability_CheckBox.TabIndex = 5;
            this.Ability_CheckBox.Text = "保持特性";
            this.Ability_CheckBox.UseVisualStyleBackColor = true;
            // 
            // RelearnMovcheckBox
            // 
            this.RelearnMovcheckBox.AutoSize = true;
            this.RelearnMovcheckBox.Location = new System.Drawing.Point(21, 62);
            this.RelearnMovcheckBox.Name = "RelearnMovcheckBox";
            this.RelearnMovcheckBox.Size = new System.Drawing.Size(126, 21);
            this.RelearnMovcheckBox.TabIndex = 6;
            this.RelearnMovcheckBox.Text = "保持技能回忆";
            this.RelearnMovcheckBox.UseVisualStyleBackColor = true;
            // 
            // EggGeneratorUI
            // 
            this.ClientSize = new System.Drawing.Size(373, 95);
            this.Controls.Add(this.RelearnMovcheckBox);
            this.Controls.Add(this.Ability_CheckBox);
            this.Controls.Add(this.Gender_CheckBox);
            this.Controls.Add(this.Form_CheckBox);
            this.Controls.Add(this.Number_Box);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.GEgg);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EggGeneratorUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
