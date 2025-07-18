﻿using System.Windows.Forms;

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
            Pic_TB = new TextBox();
            Pic_Label = new Label();
            HC_TB = new TextBox();
            HC_LB = new Label();
            HA_TB = new TextBox();
            HA_LB = new Label();
            ApplicationNameLB = new Label();
            ApiKeyLB = new Label();
            APP_TB = new TextBox();
            API_TB = new TextBox();
            Sav_Config_BTN = new Button();
            SoundCheck = new CheckBox();
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
            PictureBox.Location = new System.Drawing.Point(3, 126);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new System.Drawing.Size(500, 500);
            PictureBox.TabIndex = 1;
            PictureBox.TabStop = false;
            // 
            // PluginSetting
            // 
            PluginSetting.Controls.Add(Pic_TB);
            PluginSetting.Controls.Add(Pic_Label);
            PluginSetting.Controls.Add(HC_TB);
            PluginSetting.Controls.Add(HC_LB);
            PluginSetting.Controls.Add(HA_TB);
            PluginSetting.Controls.Add(HA_LB);
            PluginSetting.Controls.Add(ApplicationNameLB);
            PluginSetting.Controls.Add(ApiKeyLB);
            PluginSetting.Controls.Add(APP_TB);
            PluginSetting.Controls.Add(API_TB);
            PluginSetting.Controls.Add(Sav_Config_BTN);
            PluginSetting.Controls.Add(SoundCheck);
            PluginSetting.Location = new System.Drawing.Point(3, 12);
            PluginSetting.Name = "PluginSetting";
            PluginSetting.Size = new System.Drawing.Size(500, 104);
            PluginSetting.TabIndex = 2;
            PluginSetting.TabStop = false;
            PluginSetting.Text = "插键设置";
            // 
            // Pic_TB
            // 
            Pic_TB.Location = new System.Drawing.Point(132, 78);
            Pic_TB.Name = "Pic_TB";
            Pic_TB.Size = new System.Drawing.Size(269, 27);
            Pic_TB.TabIndex = 11;
            // 
            // Pic_Label
            // 
            Pic_Label.AutoSize = true;
            Pic_Label.Location = new System.Drawing.Point(42, 81);
            Pic_Label.Name = "Pic_Label";
            Pic_Label.Size = new System.Drawing.Size(89, 20);
            Pic_Label.TabIndex = 10;
            Pic_Label.Text = "PokemonPic";
            // 
            // HC_TB
            // 
            HC_TB.Location = new System.Drawing.Point(337, 49);
            HC_TB.Name = "HC_TB";
            HC_TB.Size = new System.Drawing.Size(145, 27);
            HC_TB.TabIndex = 9;
            // 
            // HC_LB
            // 
            HC_LB.AutoSize = true;
            HC_LB.Location = new System.Drawing.Point(247, 52);
            HC_LB.Name = "HC_LB";
            HC_LB.Size = new System.Drawing.Size(96, 20);
            HC_LB.TabIndex = 8;
            HC_LB.Text = "HomeCookie";
            // 
            // HA_TB
            // 
            HA_TB.Location = new System.Drawing.Point(132, 49);
            HA_TB.Name = "HA_TB";
            HA_TB.Size = new System.Drawing.Size(105, 27);
            HA_TB.TabIndex = 7;
            // 
            // HA_LB
            // 
            HA_LB.AutoSize = true;
            HA_LB.Location = new System.Drawing.Point(6, 52);
            HA_LB.Name = "HA_LB";
            HA_LB.Size = new System.Drawing.Size(140, 20);
            HA_LB.TabIndex = 6;
            HA_LB.Text = "HomeAuthorization";
            // 
            // ApplicationNameLB
            // 
            ApplicationNameLB.AutoSize = true;
            ApplicationNameLB.Location = new System.Drawing.Point(323, 23);
            ApplicationNameLB.Name = "ApplicationNameLB";
            ApplicationNameLB.Size = new System.Drawing.Size(77, 20);
            ApplicationNameLB.TabIndex = 5;
            ApplicationNameLB.Text = "AppName";
            // 
            // ApiKeyLB
            // 
            ApiKeyLB.AutoSize = true;
            ApiKeyLB.Location = new System.Drawing.Point(138, 23);
            ApiKeyLB.Name = "ApiKeyLB";
            ApiKeyLB.Size = new System.Drawing.Size(56, 20);
            ApiKeyLB.TabIndex = 4;
            ApiKeyLB.Text = "ApiKey";
            // 
            // APP_TB
            // 
            APP_TB.Location = new System.Drawing.Point(396, 20);
            APP_TB.Name = "APP_TB";
            APP_TB.Size = new System.Drawing.Size(86, 27);
            APP_TB.TabIndex = 3;
            // 
            // API_TB
            // 
            API_TB.Location = new System.Drawing.Point(192, 20);
            API_TB.Name = "API_TB";
            API_TB.Size = new System.Drawing.Size(125, 27);
            API_TB.TabIndex = 2;
            // 
            // Sav_Config_BTN
            // 
            Sav_Config_BTN.Location = new System.Drawing.Point(407, 75);
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
            SoundCheck.Size = new System.Drawing.Size(159, 24);
            SoundCheck.TabIndex = 0;
            SoundCheck.Text = "是否播放启动声音";
            SoundCheck.UseVisualStyleBackColor = true;
            // 
            // AboutandSettingUI
            // 
            ClientSize = new System.Drawing.Size(506, 634);
            Controls.Add(PluginSetting);
            Controls.Add(PictureBox);
            Controls.Add(AboutTextBox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AboutandSettingUI";
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
        private Label HA_LB;
        private Label HC_LB;
        private TextBox HA_TB;
        private TextBox HC_TB;
        private TextBox Pic_TB;
        private Label Pic_Label;
    }
}
