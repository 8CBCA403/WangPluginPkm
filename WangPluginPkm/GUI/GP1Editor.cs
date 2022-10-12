using PKHeX.Core;
using System;
using System.Windows.Forms;
using System.IO;

namespace WangPluginPkm.GUI
{
    partial class GP1Editor:Form
    {
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }

        private GP1M gp = new();
        private GP1 gpm = new();
        
        private const string GoFilter = "Go Park Entity |*.gp1|All Files|*.*";
        private const string PK8Filter = "SWSH/PLA pokemon file |*.pb8|*.pa8|All Files|*.*";
       
        private GenderType Gtype = GenderType.None;
        enum GenderType
        {
            NULL,
            Male,
            Female,
            None,
        }
        public GP1Editor(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            BindingData();
        }
       
        private void BindingData()
        {
            this.GenderBox.DataSource = Enum.GetNames(typeof(GenderType));
            this.GenderBox.SelectedIndexChanged += (_, __) =>
            {
                Gtype = (GenderType)Enum.Parse(typeof(GenderType), this.GenderBox.SelectedItem.ToString(), false);
            };
            this.GenderBox.SelectedIndex = 0;
        }
            private void ImportGP1From(string path)
        {
            var data = File.ReadAllBytes(path);
            if (data.Length != GP1.SIZE)
            {
                MessageBox.Show(MessageStrings.MsgFileLoadIncompatible);
                return;
            }
            var gp1 = new GP1M();          
            data.CopyTo(gp1.Data, 0);
            data.CopyTo(gpm.Data, 0);
            gp = gp1;
        }
        private void EditGP(GP1M pk)
        {
            byte a = 0;
            byte b = 0;
            pk.Species= (ushort)SpeciesName.GetSpeciesID(SpeciesBox.Text, 9);
            gp.Username1 = OT_Name.Text;
            ushort Move1 = (ushort)Array.IndexOf(GameInfo.Strings.movelist,Move1_TextBox.Text);
            ushort Move2 = (ushort)Array.IndexOf(GameInfo.Strings.movelist,Move2_TextBox.Text);
          //gp.Username2 = OName.Text;
            gp.Nickname = NickNameBox.Text;
            gp.IV_HP =Convert.ToInt16(HP_TextBox.Text);
            gp.IV_ATK = Convert.ToInt16(Atk_TextBox.Text);
            gp.IV_DEF = Convert.ToInt16(Def_TextBox.Text);
            gp.Gender = GenderBox.SelectedIndex;
            gp.Move1= Move1;
            gp.Move2= Move2;
            gp.CP = Convert.ToInt16(CP_TextBox.Text);
            gp.Date = Convert.ToInt32(MetDate_TextBox.Text);
            if (ShinyCheck.Checked)
                a = 1;
            gp.IsShiny = a;
            if (AlolaForm_Check.Checked)
                b = 1;
            gp.Form = b;
            gp = pk;
            
        }
        private void ImportGP_BTN_Click(object sender, EventArgs e)
        {
         
            using var sfd = new OpenFileDialog
            {
                Filter = GoFilter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };
         // Export
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            string path = sfd.FileName;
            ImportGP1From(path);
            var Name = SpeciesName.GetSpeciesName(gp.Species, 9);
            var Move1 = ParseSettings.GetMoveName(gp.Move1);
            var Move2 = ParseSettings.GetMoveName(gp.Move2);
            SpeciesBox.Text = Name;
            NickNameBox.Text = gp.Nickname;
            OT_Name.Text = gp.Username1;
          //OName.Text = gp.Username2;
            HP_TextBox.Text = gp.IV_HP.ToString();
            Atk_TextBox.Text = gp.IV_ATK.ToString();
            Def_TextBox.Text = gp.IV_DEF.ToString();
            Move1_TextBox.Text = Move1;
            Move2_TextBox.Text = Move2;
            CP_TextBox.Text = gp.CP.ToString();
            GenderBox.SelectedIndex = gp.Gender%4;
            MetDate_TextBox.Text = gp.Date.ToString();
            GeoName_TextBox.Text = gp.GeoCityName;
            if (gp.IsShiny == 1)
                ShinyCheck.Checked = true;
            else
                ShinyCheck.Checked = false;
            if (gp.Form == 1)
                AlolaForm_Check.Checked = true;
            else
                AlolaForm_Check.Checked = false;
        }

        private void ExportGP_BTN_Click(object sender, EventArgs e)
        {
            var data = gp;
            using var sfd = new SaveFileDialog
            {
                FileName = data.FileName,
                Filter = GoFilter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            File.WriteAllBytes(sfd.FileName, data.Data);
        }

        private void Edit_GP_Click(object sender, EventArgs e)
        {
            EditGP(gp);
        }

        private void CovertToPB7_Click(object sender, EventArgs e)
        {
            PB7 pkm ;
            pkm=gpm.ConvertToPB7(SAV.SAV);
            Editor.PopulateFields(pkm, false);
            SAV.ReloadSlots();
        }

        private void CovertToPK8_Click(object sender, EventArgs e)
        {
            using var sfd = new OpenFileDialog
            {
                Filter = PK8Filter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            string path = sfd.FileName;
            var pk = ImportPKFrom(path);
            Editor.PopulateFields(pk, false);
            SAV.ReloadSlots();
        }
        private PKM ImportPKFrom(string path)
        {
            PKM pkm=Editor.Data;
            var data = File.ReadAllBytes(path);
            string extension = Path.GetExtension(path);
            if (data.Length != 344|| data.Length != 376)
            {
                MessageBox.Show(MessageStrings.MsgFileLoadIncompatible);
               
            }
           switch(extension)
            {
                case "pk8":
                    pkm = new PK8(data);
                    break;
                case "pb8":
                    pkm = new PB8(data);
                    break;
                case "pa8":
                    pkm = new PA8(data);
                    break;
            }
            return pkm;
        }
    }
}
