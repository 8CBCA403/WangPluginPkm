using PKHeX.Core;
using System.Windows.Forms;
using System.IO;
using System;
using WangPluginPkm.WangUtil;
using SysBotBase;
using WangPluginPkm.WangUtil.PluginEnums;
using WangPluginPkm.Properties;
using System.Diagnostics;

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
            BindingData();
        }
        private PK9 pk = new();
      
        public enum Mod
        {
            Box,
            Party,
        }
       
        public Mod mod=Mod.Box;
    
        private void BindingData()
        {
            BallBox.DataSource = Enum.GetNames(typeof(PKBall));
            NatureBox.DataSource = Enum.GetNames(typeof(PKNature));
            StatNatureBox.DataSource = Enum.GetNames(typeof(PKNature));
            ModBox.DataSource=Enum.GetNames(typeof(Mod));
            AbilityBox.DataSource=Enum.GetNames(typeof(PKAbility));
            SpeciesBox.DataSource=Enum.GetNames(typeof(PKSpecies));
            languageBox.DataSource = Enum.GetNames(typeof(PKLanguageID));
            FirstMoveBox.DataSource = Enum.GetNames(typeof(PKMoves));
            SecondMoveBox.DataSource = Enum.GetNames(typeof(PKMoves));
            ThirdMoveBox.DataSource = Enum.GetNames(typeof(PKMoves));
            ForthMoveBox.DataSource = Enum.GetNames(typeof(PKMoves));
            OTGanderBox.DataSource = Enum.GetValues(typeof(OTGender));
            TeraBox.DataSource = Enum.GetValues(typeof(MoveType));
            ModBox.SelectedIndexChanged += (_, __) =>
            {
                mod = (Mod)Enum.Parse(typeof(Mod), this.ModBox.SelectedItem.ToString(), false);
            };
        }
        private const string ptr = "[[[main+43A7778]+A90]+9B0]";
        private const string pt1 = "[[[[main+43A77B8]+08]+30]+30]";
        private const string pt2 = "[[[[main+43A77B8]+08]+38]+30]";
        private const string pt3 = "[[[[main+43A77B8]+08]+40]+30]";
        private const string pt4 = "[[[[main+43A77B8]+08]+50]+30]";
        private const string pt5 = "[[[[main+43A77B8]+08]+58]+30]";
        private const string pt6 = "[[[[main+43A77B8]+08]+60]+30]";
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
            pk.Species = Convert.ToUInt16(SpeciesBox.SelectedIndex);
            pk.Nature = NatureBox.SelectedIndex;
            pk.StatNature = StatNatureBox.SelectedIndex;
            pk.Ability = AbilityBox.SelectedIndex;
            pk.AbilityNumber = Convert.ToInt16(AbilityNumberBox.Text);
            pk.HeldItem = Convert.ToInt16(HeldItemBox.Text);
            pk.Move1 = Convert.ToUInt16(FirstMoveBox.SelectedIndex);
            pk.Move2 = Convert.ToUInt16(SecondMoveBox.SelectedIndex);
            pk.Move3 = Convert.ToUInt16(ThirdMoveBox.SelectedIndex);
            pk.Move4 = Convert.ToUInt16(ForthMoveBox.SelectedIndex);
            pk.EXP = Convert.ToUInt32(ExpBox.Text);
            var HEX = "0x" + PIDtextBox.Text;
            pk.PID = Convert.ToUInt32(HEX, 16);
            var ECHEX = "0x" + ECtextBox.Text;
            pk.EncryptionConstant= Convert.ToUInt32(ECHEX, 16);
            pk.Ball =BallBox.SelectedIndex;
            IDConvert5();
            pk.OT_Friendship = Convert.ToInt16(OTFtextBox.Text);
            pk.Gender = Convert.ToSByte(GanderTextBox.Text);
            pk.Language = Convert.ToSByte(languageBox.SelectedIndex);
            pk.TeraTypeOverride =(MoveType) Convert.ToSByte(TeraBox.SelectedIndex);
            pk.OT_Gender = OTGanderBox.SelectedIndex;
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
            SpeciesBox.SelectedIndex = pk.Species;
            GanderTextBox.Text = pk.Gender.ToString();
            NatureBox.SelectedIndex = pk.Nature;
            StatNatureBox.SelectedIndex = pk.StatNature;
            AbilityBox.SelectedIndex = pk.Ability;
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
            IDConvert7();
            NametextBox.Text = pk.OT_Name.ToString();
            PIDtextBox.Text = pk.PID.ToString("X");
            BallBox.SelectedIndex = pk.Ball;
            FirstMoveBox.SelectedIndex = pk.Move1;
            SecondMoveBox.SelectedIndex = pk.Move2;
            ThirdMoveBox.SelectedIndex = pk.Move3;
            ForthMoveBox.SelectedIndex = pk.Move4;
            OTFtextBox.Text = pk.OT_Friendship.ToString();
            languageBox.SelectedIndex = pk.Language;
            TeraBox.Text = pk.TeraTypeOverride.ToString();
            OTGanderBox.SelectedIndex=pk.OT_Gender;
            XortextBox.Text = ((pk.TID16 ^ pk.SID16) ^ pk.PID >> 16 ^pk.PID & 0xFFFF).ToString();
            MetDateBox.Text = $"{pk.Met_Day}/{pk.Met_Month}/{pk.Met_Year}";
            ExpBox.Text = pk.EXP.ToString();
        }
        public void IDConvert7()
        {
           var TID16SID16 =(uint)( pk.TID16 + pk.SID16* 65536);
           var TID167 = TID16SID16 % 1_000_000;
           var  SID167 = TID16SID16 / 1_000_000;
            TID16textBox.Text = TID167.ToString();
            SID16textBox.Text = SID167.ToString();
        }
        public void IDConvert5()
        {
           var TID16SID16 = ushort.Parse(TID16textBox.Text) + ushort.Parse(SID16textBox.Text) * 1_000_000;
           var TID16 =(ushort)(TID16SID16 % 65536);
           var  SID16 = (ushort)(TID16SID16 / 65536);
           pk.TID16 = TID16;
           pk.SID16 = SID16;
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
            data.CopyTo(pk.Data, 0); 
            LoadPK9();
    
            var card = new Picture($"WangPluginPkm.Resources.PMico.pm"+ pk.Species.ToString().PadLeft(4, '0') + "_00_00_00_big.png");
            PokeIco.Image = card.Image;
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
           
            File.WriteAllBytes(sfd.FileName, pk.Data);
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
                MessageBox.Show("Success！");
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
            if (mod == Mod.Box)
                data1 = sysbot.ReadSlot((int)BOX_NUD.Value - 1, (int)SLOT_NUD.Value - 1, ptr);
            else
            {
                switch (Party_NUD.Value)
                {
                    case 1:
                        data1 = sysbot.ReadPSlot(pt1);
                        break;
                    case 2:
                        data1 = sysbot.ReadPSlot(pt2);
                        break;
                    case 3:
                        data1 = sysbot.ReadPSlot(pt3);
                        break;
                    case 4:
                        data1 = sysbot.ReadPSlot(pt4);
                        break;
                    case 5:
                        data1 = sysbot.ReadPSlot(pt3);
                        break;
                    case 6:
                        data1 = sysbot.ReadPSlot(pt4);
                        break;
                }
            }
            var Dedata = PokeCrypto.DecryptArray9(data1);
            Dedata[6] = data1[6];
            Dedata[7] = data1[7];
            Dedata.CopyTo(pk.Data, 0);
            LoadPK9();
            var card = new Picture($"WangPluginPkm.Resources.PMico.pm" + pk.Species.ToString().PadLeft(4, '0') + "_00_00_00_big.png");
            PokeIco.Image = card.Image;
        }

        private void Write_BTN_Click(object sender, EventArgs e)
        {
            EditPK9();
            var data = pk;
            var chk = PokeCrypto.GetCHK(data.Data);
            var chkh = (byte)(chk / 256);
            var chkl = (byte)(chk & (0xFF));
            data.Data[7] = chkh;
            data.Data[6] = chkl;
            var endata = PokeCrypto.EncryptArray9(data.Data);
            if (mod == Mod.Box)
                sysbot.SendSlot(endata,(int)BOX_NUD.Value - 1, (int)SLOT_NUD.Value - 1, ptr);
            else
            {
                switch (Party_NUD.Value)
                {
                    case 1:
                        sysbot.SendPSlot(endata, pt1);
                        break;
                    case 2:
                        sysbot.SendPSlot(endata, pt2);
                        break;
                    case 3:
                        sysbot.SendPSlot(endata, pt3);
                        break;
                    case 4:
                        sysbot.SendPSlot(endata, pt4);
                        break;
                    case 5:
                        sysbot.SendPSlot(endata, pt5);
                        break;
                    case 6:
                        sysbot.SendPSlot(endata, pt6);
                        break;
                }
            }


        }
        private void RandomPID_BTN_Click(object sender, EventArgs e)
        {
            PIDtextBox.Text = Util.Rand32().ToString("X");
        }

        private void ShinyPID_BTN_Click(object sender, EventArgs e)
        {
            uint pid = Util.Rand32();
            pid = ((uint)(pk.TID16 ^ pk.SID16) ^ pid & 0xFFFF ^ 1) << 16 | pid & 0xFFFF;
            PIDtextBox.Text= pid.ToString("X");
        }

        private void RandomEC_BTN_Click(object sender, EventArgs e)
        {
            ECtextBox.Text = Util.Rand32().ToString("X");
        }

        private void WriteBox_Click(object sender, EventArgs e)
        {
            EditPK9();
            for (int i = 1; i < 31; i++)
            {
                uint pid = Util.Rand32();
                pk.PID = ((uint)(pk.TID16 ^ pk.SID16) ^ pid & 0xFFFF ^ 1) << 16 | pid & 0xFFFF;
                pk.EncryptionConstant = Util.Rand32();
                var data = pk;
                var chk = PokeCrypto.GetCHK(data.Data);
                var chkh = (byte)(chk / 256);
                var chkl = (byte)(chk & (0xFF));
                data.Data[7] = chkh;
                data.Data[6] = chkl;
                var endata = PokeCrypto.EncryptArray8(data.Data);
                sysbot.SendSlot(endata, (int)BOX_NUD.Value - 1, i, ptr);
            }
        }

      /*  private void RaidSeedBTN_Click(object sender, EventArgs e)
        {
           var a= SVXoro.ComputeShinySeed(Util.Rand32());
            SeedBox.Text = a;
        }*/
    }
}
