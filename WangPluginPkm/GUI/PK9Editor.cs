using PKHeX.Core;
using System.Windows.Forms;
using System.IO;
using System;
using WangPluginPkm.WangUtil;
using SysBotBase;

namespace WangPluginPkm.GUI
{
    public partial class PK9Editor : Form
    {
        private SysBotMini sysbot=new SysBotMini() 
        { 
            IP="192.168.3.10",
            Port=6000,
        };
        public PK9Editor(ISaveFileProvider sav, IPKMView editor)
        {
            InitializeComponent();
        }
        private PK9 pk = new();
        private const string ptr = "[[[main+42FD510]+A90]+9B0]";
        private byte[] data1;
        private const string Pk9Filter = "PK9 Entity |*.pk9|All Files|*.*";
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
            var HEX = "0x" + PIDtextBox.Text;
            pk.PID = Convert.ToUInt32(HEX, 16);
            pk.Ball = Convert.ToInt16(BallTextBox.Text);
            pk.OT_Friendship = Convert.ToInt16(OTFtextBox.Text);
            pk.Gender = Convert.ToSByte(GanderTextBox.Text);
            pk.Language = Convert.ToSByte(languagetextBox.Text);
            pk.StatTera = Convert.ToSByte(TeratextBox.Text);
        }
        private void LoadPK9()
        {
            ECtextBox.Text = pk.EncryptionConstant.ToString("X");
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
            GanderTextBox.Text = pk.Gender.ToString();
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
            PIDtextBox.Text = pk.PID.ToString("X");
            BallTextBox.Text = pk.Ball.ToString();
            OTFtextBox.Text = pk.OT_Friendship.ToString();
            languagetextBox.Text = pk.Language.ToString();
            TeratextBox.Text = pk.StatTera.ToString();
            XortextBox.Text = ((pk.TID ^ pk.SID) ^ pk.PID >> 16 ^pk.PID & 0xFFFF).ToString();
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
            var da=PokeCrypto.EncryptArray8(data.Data);
            File.WriteAllBytes(sfd.FileName, da);
        }

        private void ConnectBTN_Click(object sender, EventArgs e)
        {
            var ip = ipTextBox.Text;
            var port = Convert.ToInt32(portTextBox.Text);
            try
            {
                sysbot.IP = ip;
                sysbot.Port = port;
                sysbot.Connect();
                MessageBox.Show("连上了！");
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.Cancel;
                WinFormsUtil.Error(ex.Message);
            }
        }
        private void Disconnect_BTN_Click(object sender, EventArgs e)
        {
            sysbot.Disconnect();
        }
        private void Read_BTN_Click(object sender, EventArgs e)
        {
            data1 = sysbot.ReadSlot((int)BOX_NUD.Value - 1, (int)SLOT_NUD.Value - 1, ptr);
            var Dedata = PokeCrypto.DecryptArray8(data1);
            Dedata[6] = data1[6];
            Dedata[7] = data1[7];
            Dedata.CopyTo(pk.Data, 0);
            LoadPK9();
        }

        private void Write_BTN_Click(object sender, EventArgs e)
        {
            EditPK9();
            var data = pk;
            var chk = PokeCrypto.GetCHK(data.Data, 328);
            var chkh = (byte)(chk / 256);
            var chkl = (byte)(chk & (0xFF));
            data.Data[7] = chkh;
            data.Data[6] = chkl;
            var endata = PokeCrypto.EncryptArray8(data.Data);
            sysbot.SendSlot(endata,(int)BOX_NUD.Value - 1, (int)SLOT_NUD.Value - 1, ptr);
            // sysbot.WriteBytesAbsolute(endata, ad);
        }
        private void RandomPID_BTN_Click(object sender, EventArgs e)
        {
            PIDtextBox.Text = Util.Rand32().ToString("X");
        }

        private void ShinyPID_BTN_Click(object sender, EventArgs e)
        {
            uint pid = Util.Rand32();
            pid = ((uint)(pk.TID ^ pk.SID) ^ pid & 0xFFFF ^ 1) << 16 | pid & 0xFFFF;
            PIDtextBox.Text= pid.ToString("X");
        }
       

    }
}
