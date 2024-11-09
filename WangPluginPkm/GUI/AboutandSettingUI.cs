using System.Windows.Forms;

namespace WangPluginPkm.GUI
{
    partial class AboutandSettingUI : Form
    {

        public AboutandSettingUI()
        {
            InitializeComponent();
            CreateBox();
            var config = PluginConfig.LoadConfig();
            SoundCheck.Checked = config.OpenSound;
            API_TB.Text = config.GoogleapiKey;
            APP_TB.Text = config.GoogleApplicationName;
            HA_TB.Text = config.HomeAuthorization;
            HC_TB.Text = config.HomeCookie;
            Pic_TB.Text = config.PokemonPicUrl;
        }
        private void Setting()
        {
            var plugin = new PluginConfig();
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
            Setting();
        }
    }
}
