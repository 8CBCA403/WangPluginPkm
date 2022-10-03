using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace WangPlugin.GUI
{
    partial class AboutUI: Form
    {
        
        public AboutUI()
        {
            InitializeComponent();
            CreateBox();
        }
       
        private void CreateBox()
        {
            AboutTextBox.Text =Properties.Resources.About;
            PictureBox.Image = Properties.Resources.Wanghaoran;
        }
    }
}
