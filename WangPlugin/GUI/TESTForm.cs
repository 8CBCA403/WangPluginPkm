using System.Windows.Forms;
using PKHeX.Core;
namespace WangPlugin.GUI
{
    internal class TESTForm : Form
    {
        private Button SetAll_BTN;

        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        public  TESTForm(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TESTForm));
            this.SetAll_BTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SetAll_BTN
            // 
            this.SetAll_BTN.Location = new System.Drawing.Point(76, 34);
            this.SetAll_BTN.Name = "SetAll_BTN";
            this.SetAll_BTN.Size = new System.Drawing.Size(96, 30);
            this.SetAll_BTN.TabIndex = 0;
            this.SetAll_BTN.Text = "RandomPID";
            this.SetAll_BTN.UseVisualStyleBackColor = true;
            this.SetAll_BTN.Click += new System.EventHandler(this.SetAll_BTN_Click);
            // 
            // TESTForm
            // 
            this.ClientSize = new System.Drawing.Size(258, 98);
            this.Controls.Add(this.SetAll_BTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TESTForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);

        }
        public void SetPkm(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.ModifyBoxes(GetPkm);
            SaveFileEditor.ReloadSlots();
        }
        public void GetPkm(PKM pk)
        {
            pk.PID = Util.Rand32();
        }
        private void SetAll_BTN_Click(object sender, System.EventArgs e)
        {
            SetPkm(SAV);
        }
    }
}
