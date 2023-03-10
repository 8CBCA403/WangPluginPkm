using System.Windows.Forms;
using PKHeX.Core;
using System.Collections.Generic;
using PKHeX.Core.Searching;
using System.Linq;
namespace WangPluginPkm.GUI
{
    internal class TESTForm : Form
    {
        private Button SetAll_BTN;

        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        public TESTForm(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TESTForm));
            SetAll_BTN = new Button();
            SuspendLayout();
            // 
            // SetAll_BTN
            // 
            SetAll_BTN.Location = new System.Drawing.Point(80, 34);
            SetAll_BTN.Name = "SetAll_BTN";
            SetAll_BTN.Size = new System.Drawing.Size(96, 30);
            SetAll_BTN.TabIndex = 0;
            SetAll_BTN.Text = "RandomPID";
            SetAll_BTN.UseVisualStyleBackColor = true;
            SetAll_BTN.Click += SetAll_BTN_Click;
            // 
            // TESTForm
            // 
            ClientSize = new System.Drawing.Size(258, 98);
            Controls.Add(SetAll_BTN);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "TESTForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Super Wang";
            ResumeLayout(false);
        }

        public void SetPkm(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            List<PKM> PKL = new();
            for (int i = 0; i < 30; i++)
            {
                var pk = GetPkm(Editor.Data);
                pk.Language = Editor.Data.Language;
                pk.ClearNickname();
                pk.OT_Name = "Homelander";
                pk.DisplayTID = 074074;
                pk.DisplaySID = 0007;
                PKL.Add(pk);
            }
            if (PKL.Count != 0)
                sav.SetBoxData(PKL, sav.CurrentBox);
            SaveFileEditor.ReloadSlots();
        }
        public PKM GetPkm(PKM pk)
        {
            // pk = Editor.Data;
            List<IEncounterInfo> Results;
            IEncounterInfo enc;
            var setting = new SearchSettings
            {
                Species = pk.Species,
                SearchEgg = false,
                Version = (int)SAV.SAV.Version,

            };
            var search = EncounterUtil.SearchDatabase(setting, SAV.SAV);
            var results = search.ToList();
            if (results.Count != 0)
            {
                Results = results;
                enc = Results[0];
                var criteria = EncounterUtil.GetCriteria(enc, pk);
                pk = enc.ConvertToPKM(SAV.SAV, criteria);

            }
            return pk;
        }
        private void SetAll_BTN_Click(object sender, System.EventArgs e)
        {
            SetPkm(SAV);
        }
    }
}
