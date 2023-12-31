using System.Windows.Forms;

namespace WangPluginPkm.GUI
{
    partial class AboutUI : Form
    {

        public AboutUI()
        {
            InitializeComponent();
            CreateBox();
        }
        private void Setting()
        {
            var plugin = new PluginConfig();
            plugin.OpenSound = SoundCheck.Checked;
            plugin.SaveConfig(plugin);
        }
        private void CreateBox()
        {
            AboutTextBox.Text = Properties.Resources.About;
            PictureBox.Image = Properties.Resources.Wanghaoran;
        }

        private void Sav_Config_BTN_Click(object sender, System.EventArgs e)
        {
            Setting();
        }
    }
}
