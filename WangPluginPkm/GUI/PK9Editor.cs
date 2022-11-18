using PKHeX.Core;
using System.Windows.Forms;
using System.IO;
using System;
using USP.Core;
using WangPluginPkm.WangUtil;
using System.Security.Cryptography;

namespace WangPluginPkm.GUI
{
    public partial class PK9Editor : Form
    {
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        private NoexsBot test;
        public PK9Editor(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
        }
        private PK9 pk = new();
        private byte[] data1;
        private const string Pk9Filter = "Go Park Entity |*.pk9|All Files|*.*";
        private void EditPK9()
        {
            pk.IV_HP = Convert.ToInt16(IV_HPBox.Text);
            pk.IV_ATK = Convert.ToInt16(IV_ATKBox.Text);
            pk.IV_DEF = Convert.ToInt16(IV_DEFBox.Text);
            pk.IV_SPA = Convert.ToInt16(IV_SPABox.Text);
            pk.IV_SPE = Convert.ToInt16(IV_SPEBox.Text);
            pk.IV_SPD = Convert.ToInt16(IV_SPDBox.Text);
            pk.EV_HP = Convert.ToInt16(EV_HPBox.Text);
            pk.EV_ATK = Convert.ToInt16(EV_ATKBox.Text);
            pk.EV_DEF = Convert.ToInt16(EV_DEFBox.Text);
            pk.EV_SPA = Convert.ToInt16(EV_SPABox.Text);
            pk.EV_SPE = Convert.ToInt16(EV_SPEBox.Text);
            pk.EV_SPD = Convert.ToInt16(EV_SPDBox.Text);
            pk.Species = Convert.ToUInt16(SpeciesBox.Text);
            pk.Nature = Convert.ToInt16(NatureBox.Text);
            pk.StatNature = Convert.ToInt16(StatNatureBox.Text);
            pk.Ability = Convert.ToInt16(AbilityBox.Text);
            pk.AbilityNumber = Convert.ToInt16(AbilityNumberBox.Text);
            pk.HeldItem = Convert.ToInt16(HeldItemBox.Text);
            pk.PID = Convert.ToUInt32(PIDtextBox.Text);
        }
        private void LoadPK9()
        {
            IV_HPBox.Text = pk.IV_HP.ToString();
            IV_ATKBox.Text = pk.IV_ATK.ToString();
            IV_DEFBox.Text = pk.IV_DEF.ToString();
            IV_SPABox.Text = pk.IV_SPA.ToString();
            IV_SPEBox.Text = pk.IV_SPE.ToString();
            IV_SPDBox.Text = pk.IV_SPD.ToString();
            EV_HPBox.Text = pk.EV_HP.ToString();
            EV_ATKBox.Text = pk.EV_ATK.ToString();
            EV_DEFBox.Text = pk.EV_DEF.ToString();
            EV_SPABox.Text = pk.EV_SPA.ToString();
            EV_SPEBox.Text = pk.EV_SPE.ToString();
            EV_SPDBox.Text = pk.EV_SPD.ToString();
            SpeciesBox.Text = pk.Species.ToString();
            NatureBox.Text = pk.Nature.ToString();
            StatNatureBox.Text = pk.StatNature.ToString();
            AbilityBox.Text = pk.Ability.ToString();
            AbilityNumberBox.Text = pk.AbilityNumber.ToString();
            HeldItemBox.Text = pk.HeldItem.ToString();
            Move1Box.Text = pk.Move1.ToString();
            Move2Box.Text = pk.Move2.ToString();
            Move3Box.Text = pk.Move3.ToString();
            Move4Box.Text = pk.Move4.ToString();
            PP1Box.Text = pk.Move1_PP.ToString();
            PP2Box.Text = pk.Move2_PP.ToString();
            PP3Box.Text = pk.Move3_PP.ToString();
            PP4Box.Text = pk.Move4_PP.ToString();
            PP1TextBox.Text = pk.Move1_PPUps.ToString();
            PP2TextBox.Text = pk.Move2_PPUps.ToString();
            PP3TextBox.Text = pk.Move3_PPUps.ToString();
            PP4TextBox.Text = pk.Move4_PPUps.ToString();
            TidtextBox.Text = pk.TID.ToString();
            SidtextBox.Text = pk.SID.ToString();
            NametextBox.Text = pk.OT_Name.ToString();
            PIDtextBox.Text = pk.PID.ToString();
        }
        private void ImportBTN_Click(object sender, System.EventArgs e)
        {
            using var sfd = new OpenFileDialog
            {
                Filter = Pk9Filter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            string path = sfd.FileName;
            var data = File.ReadAllBytes(path);
            if (data.Length != 344)
            {
                MessageBox.Show(MessageStrings.MsgFileLoadIncompatible);
                return;
            }
            var Dedata = PokeCrypto.DecryptArray8(data);
            Dedata[6] = data[6];
            Dedata[7] = data[7];
            Dedata.CopyTo(pk.Data, 0);
            LoadPK9();
        }
        private void ExportBTN_Click(object sender, EventArgs e)
        {
            EditPK9();
            var data = pk;
            using var sfd = new SaveFileDialog
            {
                FileName = "test",
                Filter = Pk9Filter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            var chk = PokeCrypto.GetCHK(data.Data, 328);
            var chkh =(byte)(chk / 256);
            var chkl = (byte)(chk & (0xFF));
            data.Data[7] = chkh;
            data.Data[6] = chkl;
            File.WriteAllBytes(sfd.FileName, data.Data);
        }

        private void ConnectBTN_Click(object sender, EventArgs e)
        {
            var ip = ipTextBox.Text;
            var port = Convert.ToInt32(portTextBox.Text);
            try
            {
                test = CoreUtil.GetNoexsBot(ip, port);
                LB_pids.Items.Clear();
                foreach (var p in test.ListPids())
                {
                    LB_pids.Items.Add(p);
                }
                LB_pids.SelectedIndexChanged += (_, __) =>
                {
                    TIDLabel.Text = $"[tid]{test.TitleIdPid((ulong)LB_pids.SelectedItem):X}";
                };
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.Cancel;
                WinFormsUtil.Error(ex.Message);
            }
        }

        private void Attach_BTN_Click(object sender, EventArgs e)
        {
            if (LB_pids.SelectedIndex != -1)
            {
                try
                {
                    if (test == null)
                    {
                        var ip = ipTextBox.Text;
                        var port = Convert.ToInt32(portTextBox.Text);
                        test = CoreUtil.GetNoexsBot(ip, port);
                    }

                    test.Attach((ulong)LB_pids.SelectedItem);
                    DialogResult = DialogResult.OK;
                 
                }
                catch (Exception ex)
                {
                    DialogResult = DialogResult.Cancel;
                    WinFormsUtil.Error(ex.Message);
                }
            }
        }
        private void Disconnect_BTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (test != null)
                {
                    test.Detach();
                }
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.Cancel;
                WinFormsUtil.Error(ex.Message);
            }

        }
        private void Read_BTN_Click(object sender, EventArgs e)
        {
            var Address = AddressBox.Text;
            var Addr = ulong.Parse(Address, System.Globalization.NumberStyles.HexNumber);
            data1=test.ReadAbsolute(Addr, 344);
            var da = data1;
            var Dedata=PokeCrypto.DecryptArray8(data1);
            Dedata[6] = data1[6];
            Dedata[7] = data1[7];
            var chk=PokeCrypto.GetCHK(Dedata, 344);
            Dedata.CopyTo(pk.Data, 0);
            LoadPK9();

        }

        private void Write_BTN_Click(object sender, EventArgs e)
        {
            var Address = AddressBox.Text;
            var Addr = ulong.Parse(Address, System.Globalization.NumberStyles.HexNumber);
            EditPK9();
            var data = pk;
            var chk = PokeCrypto.GetCHK(data.Data, 328);
            var chkh = (byte)(chk / 256);
            var chkl = (byte)(chk & (0xFF));
            data.Data[7] = chkh;
            data.Data[6] = chkl;
            var endata = PokeCrypto.EncryptArray8(data.Data);
            using var sfd = new SaveFileDialog
            {
                FileName = "test",
                Filter = Pk9Filter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            File.WriteAllBytes(sfd.FileName, endata);
            test.WriteAbsolute(endata, Addr);
        }
        private void RandomPID_BTN_Click(object sender, EventArgs e)
        {
            PIDtextBox.Text = Util.Rand32().ToString();
        }

        private void ShinyPID_BTN_Click(object sender, EventArgs e)
        {
            uint pid = Util.Rand32();
            pid = ((uint)(pk.TID ^ pk.SID) ^ pid & 0xFFFF ^ 1) << 16 | pid & 0xFFFF;
            PIDtextBox.Text= pid.ToString();
        }

      
    }
}
