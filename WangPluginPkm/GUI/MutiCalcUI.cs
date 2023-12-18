using System;
using System.Windows.Forms;
namespace WangPluginPkm.GUI
{
    public partial class MutiCalcUI : Form
    {
        public const double E = 2.7182818284590451;
        public MutiCalcUI()
        {
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
            this.IDCheck.CheckedChanged += (_, __) =>
            {
                IDsCheck.Enabled = !IDCheck.Checked;
            };
            this.IDsCheck.CheckedChanged += (_, __) =>
            {
                IDCheck.Enabled = !IDsCheck.Checked;
            };
        }
        private void CalcStart_Click(object sender, System.EventArgs e)
        {
            var PID = uint.Parse(PIDHex.Text, System.Globalization.NumberStyles.HexNumber);
            var NatureID = PID % 25;
            Nature.Text = ShowNature(NatureID);
        }
        private static string ShowNature(uint ID)
        {
            string Nature = "Hardy";
            switch (ID)
            {
                case 0:
                    Nature = "0,Hardy";
                    break;
                case 1:
                    Nature = "1,Lonely";
                    break;
                case 2:
                    Nature = "2,Brave";
                    break;
                case 3:
                    Nature = "3,Adamant";
                    break;
                case 4:
                    Nature = "4,Naughty";
                    break;
                case 5:
                    Nature = "5,Bold";
                    break;
                case 6:
                    Nature = "6,Docile";
                    break;
                case 7:
                    Nature = "7,Relaxed";
                    break;
                case 8:
                    Nature = "8,Impish";
                    break;
                case 9:
                    Nature = "9,Lax";
                    break;
                case 10:
                    Nature = "10,Timid";
                    break;
                case 11:
                    Nature = "11,Hasty";
                    break;
                case 12:
                    Nature = "12,Serious";
                    break;
                case 13:
                    Nature = "13,Jolly";
                    break;
                case 14:
                    Nature = "14,Naive";
                    break;
                case 15:
                    Nature = "15,Modest";
                    break;
                case 16:
                    Nature = "16,Mild";
                    break;
                case 17:
                    Nature = "17,Quiet";
                    break;
                case 18:
                    Nature = "18,Bashful";
                    break;
                case 19:
                    Nature = "19,Rash";
                    break;
                case 20:
                    Nature = "20,Calm";
                    break;
                case 21:
                    Nature = "21,Gentle";
                    break;
                case 22:
                    Nature = "22,Sassy";
                    break;
                case 23:
                    Nature = "23,Careful";
                    break;
                case 24:
                    Nature = "24,Quirky";
                    break;
            }

            return Nature;
        }
        private static string ShowForm(byte v)
        {
            string Form = "A";
            switch (v)
            {
                case 0:
                    Form = "A";
                    break;
                case 1:
                    Form = "B";
                    break;
                case 2:
                    Form = "C";
                    break;
                case 3:
                    Form = "D";
                    break;
                case 4:
                    Form = "E";
                    break;
                case 5:
                    Form = "F";
                    break;
                case 6:
                    Form = "G";
                    break;
                case 7:
                    Form = "H";
                    break;
                case 8:
                    Form = "I";
                    break;
                case 9:
                    Form = "J";
                    break;
                case 10:
                    Form = "K";
                    break;
                case 11:
                    Form = "L";
                    break;
                case 12:
                    Form = "M";
                    break;
                case 13:
                    Form = "N";
                    break;
                case 14:
                    Form = "O";
                    break;
                case 15:
                    Form = "P";
                    break;
                case 16:
                    Form = "Q";
                    break;
                case 17:
                    Form = "R";
                    break;
                case 18:
                    Form = "S";
                    break;
                case 19:
                    Form = "T";
                    break;
                case 20:
                    Form = "U";
                    break;
                case 21:
                    Form = "V";
                    break;
                case 22:
                    Form = "W";
                    break;
                case 23:
                    Form = "X";
                    break;
                case 24:
                    Form = "Y";
                    break;
                case 25:
                    Form = "Z";
                    break;
                case 26:
                    Form = "!";
                    break;
                case 27:
                    Form = "?";
                    break;
            }
            return Form;
        }
        private void CloseBTN_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CalcHTD_Click(object sender, EventArgs e)
        {
            var HEX = "0x" + Hex1.Text;
            var DEC = Convert.ToUInt64(HEX, 16);
            Dec1.Text = DEC.ToString();
        }
        private void CalcDTH_Click(object sender, EventArgs e)
        {
            var DEC = Int64.Parse(Dec2.Text);
            var HEX = DEC.ToString("X");
            Hex2.Text = HEX;
        }
        private void CalcID_Click(object sender, EventArgs e)
        {
            uint TID16SID16;
            uint TID165;
            uint SID165;
            uint TID167;
            uint SID167;
            if (IDCheck.Checked == true)
            {
                TID16SID16 = UInt32.Parse(TID16.Text) + UInt32.Parse(SID16.Text) * 65536;
                TID167 = TID16SID16 % 1_000_000;
                SID167 = TID16SID16 / 1_000_000;
                TID16Result.Text = TID167.ToString();
                SID16Result.Text = SID167.ToString();
            }
            else if (IDsCheck.Checked == true)
            {
                TID16SID16 = UInt32.Parse(TID16.Text) + UInt32.Parse(SID16.Text) * 1_000_000;
                TID165 = TID16SID16 % 65536;
                SID165 = TID16SID16 / 65536;
                TID16Result.Text = TID165.ToString();
                SID16Result.Text = SID165.ToString();
            }
        }

        private void FormCalc_Click(object sender, EventArgs e)
        {
            var PID = uint.Parse(UnownPidTextBox.Text, System.Globalization.NumberStyles.HexNumber);
            var value = ((PID & 0x3000000) >> 18) | ((PID & 0x30000) >> 12) | ((PID & 0x300) >> 6) | (PID & 0x3);
            var s = (byte)(value % 28);
            UnownFormBox.Text = ShowForm(s);
        }

    }
}
