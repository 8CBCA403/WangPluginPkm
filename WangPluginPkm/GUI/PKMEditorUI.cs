using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WangPluginPkm.GUI
{
    public partial class PKMEditorUI : Form
    {
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        public PKMEditorUI(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new GP1Editor(SAV,Editor);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new PK9Editor(SAV, Editor);
            form.Show();
        }
    }
}
