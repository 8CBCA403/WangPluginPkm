using System.Windows.Forms;

namespace WangPluginPkm.GUI
{
    partial class AboutandSettingUI
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutandSettingUI));
            AboutTextBox = new RichTextBox();
            PictureBox = new PictureBox();
            PluginSetting = new GroupBox();
            Sav_Config_BTN = new Button();
            SoundCheck = new CheckBox();
            API_TB = new TextBox();
            APP_TB = new TextBox();
            ApiKeyLB = new Label();
            ApplicationNameLB = new Label();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            PluginSetting.SuspendLayout();
            SuspendLayout();
            // 
            // AboutTextBox
            // 
            AboutTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            AboutTextBox.Location = new System.Drawing.Point(3, 126);
            AboutTextBox.Name = "AboutTextBox";
            AboutTextBox.ReadOnly = true;
            AboutTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            AboutTextBox.Size = new System.Drawing.Size(493, 255);
            AboutTextBox.TabIndex = 0;
            AboutTextBox.Text = "";
            // 
            // PictureBox
            // 
            PictureBox.Location = new System.Drawing.Point(502, 126);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new System.Drawing.Size(255, 255);
            PictureBox.TabIndex = 1;
            PictureBox.TabStop = false;
            // 
            // PluginSetting
            // 
            PluginSetting.Controls.Add(ApplicationNameLB);
            PluginSetting.Controls.Add(ApiKeyLB);
            PluginSetting.Controls.Add(APP_TB);
            PluginSetting.Controls.Add(API_TB);
            PluginSetting.Controls.Add(Sav_Config_BTN);
            PluginSetting.Controls.Add(SoundCheck);
            PluginSetting.Location = new System.Drawing.Point(3, 12);
            PluginSetting.Name = "PluginSetting";
            PluginSetting.Size = new System.Drawing.Size(754, 104);
            PluginSetting.TabIndex = 2;
            PluginSetting.TabStop = false;
            PluginSetting.Text = "插键设置";
            // 
            // Sav_Config_BTN
            // 
            Sav_Config_BTN.Location = new System.Drawing.Point(662, 75);
            Sav_Config_BTN.Name = "Sav_Config_BTN";
            Sav_Config_BTN.Size = new System.Drawing.Size(75, 23);
            Sav_Config_BTN.TabIndex = 1;
            Sav_Config_BTN.Text = "保存设置";
            Sav_Config_BTN.UseVisualStyleBackColor = true;
            Sav_Config_BTN.Click += Sav_Config_BTN_Click;
            // 
            // SoundCheck
            // 
            SoundCheck.AutoSize = true;
            SoundCheck.Checked = true;
            SoundCheck.CheckState = CheckState.Checked;
            SoundCheck.Location = new System.Drawing.Point(9, 22);
            SoundCheck.Name = "SoundCheck";
            SoundCheck.Size = new System.Drawing.Size(123, 21);
            SoundCheck.TabIndex = 0;
            SoundCheck.Text = "是否播放启动声音";
            SoundCheck.UseVisualStyleBackColor = true;
            // 
            // API_TB
            // 
            API_TB.Location = new System.Drawing.Point(192, 20);
            API_TB.Name = "API_TB";
            API_TB.Size = new System.Drawing.Size(227, 23);
            API_TB.TabIndex = 2;
            // 
            // APP_TB
            // 
            APP_TB.Location = new System.Drawing.Point(510, 20);
            APP_TB.Name = "APP_TB";
            APP_TB.Size = new System.Drawing.Size(227, 23);
            APP_TB.TabIndex = 3;
            // 
            // ApiKeyLB
            // 
            ApiKeyLB.AutoSize = true;
            ApiKeyLB.Location = new System.Drawing.Point(138, 23);
            ApiKeyLB.Name = "ApiKeyLB";
            ApiKeyLB.Size = new System.Drawing.Size(48, 17);
            ApiKeyLB.TabIndex = 4;
            ApiKeyLB.Text = "ApiKey";
            // 
            // ApplicationNameLB
            // 
            ApplicationNameLB.AutoSize = true;
            ApplicationNameLB.Location = new System.Drawing.Point(437, 23);
            ApplicationNameLB.Name = "ApplicationNameLB";
            ApplicationNameLB.Size = new System.Drawing.Size(67, 17);
            ApplicationNameLB.TabIndex = 5;
            ApplicationNameLB.Text = "AppName";
            // 
            // AboutUI
            // 
            ClientSize = new System.Drawing.Size(765, 383);
            Controls.Add(PluginSetting);
            Controls.Add(PictureBox);
            Controls.Add(AboutTextBox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AboutUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Super Wang";
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            PluginSetting.ResumeLayout(false);
            PluginSetting.PerformLayout();
            ResumeLayout(false);
        }

        private PictureBox PictureBox;
        private RichTextBox AboutTextBox;
        private GroupBox PluginSetting;
        private CheckBox SoundCheck;
        private Button Sav_Config_BTN;
        private TextBox APP_TB;
        private TextBox API_TB;
        private Label ApiKeyLB;
        private Label ApplicationNameLB;
    }
}
