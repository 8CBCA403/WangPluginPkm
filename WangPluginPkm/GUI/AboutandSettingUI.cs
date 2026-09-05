using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WangPluginPkm.GUI
{
    partial class AboutandSettingUI : PluginForm
    {

        public AboutandSettingUI()
        {
            InitializeComponent();
            ConfigureLayout();
            CreateBox();
            var config = PluginConfig.LoadConfig();
            SoundCheck.Checked = config.OpenSound;
            API_TB.Text = config.GoogleapiKey;
            APP_TB.Text = config.GoogleApplicationName;
            HA_TB.Text = config.HomeAuthorization;
            HC_TB.Text = config.HomeCookie;
            Pic_TB.Text = config.PokemonPicUrl;
        }
        private void ConfigureLayout()
        {
            SuspendLayout();
            Text = "超王插件 · 设置与关于";
            AutoScaleDimensions = new SizeF(96, 96);
            AutoScaleMode = AutoScaleMode.Dpi;
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimumSize = new Size(520, 480);
            ClientSize = new Size(640, 540);
            Padding = new Padding(12);

            var tabs = new TabControl { Dock = DockStyle.Fill };
            var settings = new TabPage("设置") { AutoScroll = true, Padding = new Padding(12) };
            var about = new TabPage("关于") { Padding = new Padding(12) };
            tabs.TabPages.AddRange(new[] { settings, about });
            var fields = new TableLayoutPanel
            {
                Dock = DockStyle.Top, AutoSize = true, ColumnCount = 2, RowCount = 8,
            };
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            for (int row = 0; row < 8; row++)
                fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            SoundCheck.Text = "播放启动声音";
            SoundCheck.Margin = new Padding(3, 6, 3, 12);
            fields.Controls.Add(SoundCheck, 0, 0);
            fields.SetColumnSpan(SoundCheck, 2);
            var labels = new[] { ApiKeyLB, ApplicationNameLB, HA_LB, HC_LB, Pic_Label };
            var inputs = new[] { API_TB, APP_TB, HA_TB, HC_TB, Pic_TB };
            var captions = new[] { "Google API Key", "Google 应用名称", "HOME Authorization", "HOME Cookie", "宝可梦图片地址前缀" };
            for (int i = 0; i < inputs.Length; i++)
            {
                labels[i].Text = captions[i];
                labels[i].Anchor = AnchorStyles.Left;
                labels[i].Margin = new Padding(3, 8, 12, 8);
                inputs[i].Dock = DockStyle.Fill;
                inputs[i].Margin = new Padding(3, 6, 3, 6);
                inputs[i].TabIndex = i + 1;
                fields.Controls.Add(labels[i], 0, i + 1);
                fields.Controls.Add(inputs[i], 1, i + 1);
            }
            var themeHint = new Label
            {
                Text = "界面颜色跟随 PKHeX 的深色／浅色模式。", AutoSize = true,
                Margin = new Padding(3, 12, 3, 12),
            };
            fields.Controls.Add(themeHint, 0, 6);
            fields.SetColumnSpan(themeHint, 2);
            Sav_Config_BTN.AutoSize = true;
            Sav_Config_BTN.Padding = new Padding(12, 6, 12, 6);
            Sav_Config_BTN.Anchor = AnchorStyles.Right;
            Sav_Config_BTN.TabIndex = 6;
            fields.Controls.Add(Sav_Config_BTN, 1, 7);
            settings.Controls.Add(fields);

            var aboutLayout = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1 };
            aboutLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
            aboutLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            PictureBox.Dock = DockStyle.Fill;
            PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            AboutTextBox.Dock = DockStyle.Fill;
            AboutTextBox.Font = Font;
            aboutLayout.Controls.Add(PictureBox, 0, 0);
            aboutLayout.Controls.Add(AboutTextBox, 0, 1);
            about.Controls.Add(aboutLayout);
            Controls.Clear();
            PluginSetting.Dispose();
            Controls.Add(tabs);
            ResumeLayout(true);
        }
        private void Setting()
        {
            var plugin = PluginConfig.LoadConfig();
            plugin.OpenSound = SoundCheck.Checked;
            plugin.GoogleapiKey = API_TB.Text;
            plugin.GoogleApplicationName = APP_TB.Text;
            plugin.HomeAuthorization = HA_TB.Text;
            plugin.HomeCookie = HC_TB.Text;
            plugin.PokemonPicUrl = Pic_TB.Text;

            PluginConfig.SaveConfig(plugin);
        }
        private void CreateBox()
        {
            AboutTextBox.Text = Properties.Resources.About;
            PictureBox.Image = Properties.Resources.SuperWang;
        }

        private void Sav_Config_BTN_Click(object sender, System.EventArgs e)
        {
            try
            {
                Setting();
                global::WangPluginPkm.PluginMessageBox.Show(this, "设置已保存。", "超王插件");
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                global::WangPluginPkm.PluginMessageBox.Show(this, $"设置保存失败：{ex.Message}", "超王插件", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
