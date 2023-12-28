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

        private void CreateBox()
        {
            AboutTextBox.Text = Properties.Resources.About;
            PictureBox.Image = Properties.Resources.Wanghaoran;
        }
    }
}
