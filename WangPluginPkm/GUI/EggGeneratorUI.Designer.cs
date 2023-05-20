using System.Windows.Forms;

namespace WangPluginPkm.GUI
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
            GEgg = new Button();
            Version = new TextBox();
            Number_Box = new ComboBox();
            Form_CheckBox = new CheckBox();
            Gender_CheckBox = new CheckBox();
            Ability_CheckBox = new CheckBox();
            RelearnMovcheckBox = new CheckBox();
            SuspendLayout();
            // 
            // GEgg
            // 
            GEgg.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            GEgg.Location = new System.Drawing.Point(246, 10);
            GEgg.Name = "GEgg";
            GEgg.Size = new System.Drawing.Size(104, 25);
            GEgg.TabIndex = 0;
            GEgg.Text = "生成蛋";
            GEgg.UseVisualStyleBackColor = true;
            GEgg.Click += GEgg_Click;
            // 
            // Version
            // 
            Version.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Version.Location = new System.Drawing.Point(19, 10);
            Version.Name = "Version";
            Version.Size = new System.Drawing.Size(95, 24);
            Version.TabIndex = 1;
            Version.Text = "No Save";
            // 
            // Number_Box
            // 
            Number_Box.FormattingEnabled = true;
            Number_Box.ItemHeight = 12;
            Number_Box.Location = new System.Drawing.Point(120, 12);
            Number_Box.Name = "Number_Box";
            Number_Box.Size = new System.Drawing.Size(120, 20);
            Number_Box.TabIndex = 2;
            // 
            // Form_CheckBox
            // 
            Form_CheckBox.AutoSize = true;
            Form_CheckBox.Location = new System.Drawing.Point(18, 41);
            Form_CheckBox.Name = "Form_CheckBox";
            Form_CheckBox.Size = new System.Drawing.Size(96, 16);
            Form_CheckBox.TabIndex = 3;
            Form_CheckBox.Text = "保持地区形态";
            Form_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Gender_CheckBox
            // 
            Gender_CheckBox.AutoSize = true;
            Gender_CheckBox.Location = new System.Drawing.Point(140, 41);
            Gender_CheckBox.Name = "Gender_CheckBox";
            Gender_CheckBox.Size = new System.Drawing.Size(72, 16);
            Gender_CheckBox.TabIndex = 4;
            Gender_CheckBox.Text = "保持性别";
            Gender_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Ability_CheckBox
            // 
            Ability_CheckBox.AutoSize = true;
            Ability_CheckBox.Location = new System.Drawing.Point(246, 41);
            Ability_CheckBox.Name = "Ability_CheckBox";
            Ability_CheckBox.Size = new System.Drawing.Size(72, 16);
            Ability_CheckBox.TabIndex = 5;
            Ability_CheckBox.Text = "保持特性";
            Ability_CheckBox.UseVisualStyleBackColor = true;
            // 
            // RelearnMovcheckBox
            // 
            RelearnMovcheckBox.AutoSize = true;
            RelearnMovcheckBox.Location = new System.Drawing.Point(18, 62);
            RelearnMovcheckBox.Name = "RelearnMovcheckBox";
            RelearnMovcheckBox.Size = new System.Drawing.Size(96, 16);
            RelearnMovcheckBox.TabIndex = 6;
            RelearnMovcheckBox.Text = "保持技能回忆";
            RelearnMovcheckBox.UseVisualStyleBackColor = true;
            // 
            // EggGeneratorUI
            // 
            ClientSize = new System.Drawing.Size(368, 91);
            Controls.Add(RelearnMovcheckBox);
            Controls.Add(Ability_CheckBox);
            Controls.Add(Gender_CheckBox);
            Controls.Add(Form_CheckBox);
            Controls.Add(Number_Box);
            Controls.Add(Version);
            Controls.Add(GEgg);
            Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "EggGeneratorUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Super Wang";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
