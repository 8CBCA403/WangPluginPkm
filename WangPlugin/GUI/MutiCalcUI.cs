using System.Windows.Forms;
using System;
namespace WangPlugin.GUI
{
    public partial class MutiCalcUI : Form
    {
       
        private Button CalcNature;
        private Label PID;
        private TextBox Nature;
        private Button CloseBTN;
        private TextBox Hex1;
        private TextBox Dec1;
        private TextBox Dec2;
        private TextBox Hex2;
        private Button CalcHTD;
        private Button CalcDTH;
        private TextBox TID;
        private TextBox SID;
        private Button CalcID;
        private Label HTC;
        private Label CTH;
        private TextBox TIDResult;
        private TextBox SIDResult;
        private CheckBox IDCheck;
        private CheckBox IDsCheck;
        private TextBox BoxInput_TextBox;
        private TextBox PriceOutPut_TextBox;
        private Button PriceCalc_BTN;
        private Label Price;
        private TextBox PIDHex;
        private TextBox PricePerBox_TextBox;
        private TextBox PricePerPKM_TextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        public const double E = 2.7182818284590451;
        public MutiCalcUI()
        {
            InitializeComponent();
            BindingData();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MutiCalcUI));
            this.CalcNature = new System.Windows.Forms.Button();
            this.PIDHex = new System.Windows.Forms.TextBox();
            this.PID = new System.Windows.Forms.Label();
            this.Nature = new System.Windows.Forms.TextBox();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.Hex1 = new System.Windows.Forms.TextBox();
            this.Dec1 = new System.Windows.Forms.TextBox();
            this.Dec2 = new System.Windows.Forms.TextBox();
            this.Hex2 = new System.Windows.Forms.TextBox();
            this.CalcHTD = new System.Windows.Forms.Button();
            this.CalcDTH = new System.Windows.Forms.Button();
            this.TID = new System.Windows.Forms.TextBox();
            this.SID = new System.Windows.Forms.TextBox();
            this.CalcID = new System.Windows.Forms.Button();
            this.HTC = new System.Windows.Forms.Label();
            this.CTH = new System.Windows.Forms.Label();
            this.TIDResult = new System.Windows.Forms.TextBox();
            this.SIDResult = new System.Windows.Forms.TextBox();
            this.IDCheck = new System.Windows.Forms.CheckBox();
            this.IDsCheck = new System.Windows.Forms.CheckBox();
            this.BoxInput_TextBox = new System.Windows.Forms.TextBox();
            this.PriceOutPut_TextBox = new System.Windows.Forms.TextBox();
            this.PriceCalc_BTN = new System.Windows.Forms.Button();
            this.Price = new System.Windows.Forms.Label();
            this.PricePerBox_TextBox = new System.Windows.Forms.TextBox();
            this.PricePerPKM_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CalcNature
            // 
            this.CalcNature.Location = new System.Drawing.Point(266, 22);
            this.CalcNature.Name = "CalcNature";
            this.CalcNature.Size = new System.Drawing.Size(100, 25);
            this.CalcNature.TabIndex = 0;
            this.CalcNature.Text = "Calculate";
            this.CalcNature.UseVisualStyleBackColor = true;
            this.CalcNature.Click += new System.EventHandler(this.CalcStart_Click);
            // 
            // PIDHex
            // 
            this.PIDHex.Location = new System.Drawing.Point(54, 22);
            this.PIDHex.Name = "PIDHex";
            this.PIDHex.Size = new System.Drawing.Size(100, 25);
            this.PIDHex.TabIndex = 2;
            // 
            // PID
            // 
            this.PID.AutoSize = true;
            this.PID.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PID.Location = new System.Drawing.Point(6, 22);
            this.PID.Name = "PID";
            this.PID.Size = new System.Drawing.Size(45, 26);
            this.PID.TabIndex = 3;
            this.PID.Text = "PID";
            // 
            // Nature
            // 
            this.Nature.Enabled = false;
            this.Nature.Location = new System.Drawing.Point(160, 22);
            this.Nature.Name = "Nature";
            this.Nature.Size = new System.Drawing.Size(100, 25);
            this.Nature.TabIndex = 4;
            // 
            // CloseBTN
            // 
            this.CloseBTN.Location = new System.Drawing.Point(610, 53);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(100, 25);
            this.CloseBTN.TabIndex = 5;
            this.CloseBTN.Text = "Close";
            this.CloseBTN.UseVisualStyleBackColor = true;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // Hex1
            // 
            this.Hex1.Location = new System.Drawing.Point(54, 53);
            this.Hex1.Name = "Hex1";
            this.Hex1.Size = new System.Drawing.Size(100, 25);
            this.Hex1.TabIndex = 6;
            // 
            // Dec1
            // 
            this.Dec1.Enabled = false;
            this.Dec1.Location = new System.Drawing.Point(160, 53);
            this.Dec1.Name = "Dec1";
            this.Dec1.Size = new System.Drawing.Size(100, 25);
            this.Dec1.TabIndex = 7;
            // 
            // Dec2
            // 
            this.Dec2.Location = new System.Drawing.Point(54, 84);
            this.Dec2.Name = "Dec2";
            this.Dec2.Size = new System.Drawing.Size(100, 25);
            this.Dec2.TabIndex = 8;
            // 
            // Hex2
            // 
            this.Hex2.Enabled = false;
            this.Hex2.Location = new System.Drawing.Point(160, 84);
            this.Hex2.Name = "Hex2";
            this.Hex2.Size = new System.Drawing.Size(100, 25);
            this.Hex2.TabIndex = 9;
            // 
            // CalcHTD
            // 
            this.CalcHTD.Location = new System.Drawing.Point(266, 53);
            this.CalcHTD.Name = "CalcHTD";
            this.CalcHTD.Size = new System.Drawing.Size(100, 25);
            this.CalcHTD.TabIndex = 10;
            this.CalcHTD.Text = "Calculate";
            this.CalcHTD.UseVisualStyleBackColor = true;
            this.CalcHTD.Click += new System.EventHandler(this.CalcHTD_Click);
            // 
            // CalcDTH
            // 
            this.CalcDTH.Location = new System.Drawing.Point(266, 83);
            this.CalcDTH.Name = "CalcDTH";
            this.CalcDTH.Size = new System.Drawing.Size(100, 26);
            this.CalcDTH.TabIndex = 11;
            this.CalcDTH.Text = "Calculate";
            this.CalcDTH.UseVisualStyleBackColor = true;
            this.CalcDTH.Click += new System.EventHandler(this.CalcDTH_Click);
            // 
            // TID
            // 
            this.TID.Location = new System.Drawing.Point(398, 23);
            this.TID.Name = "TID";
            this.TID.Size = new System.Drawing.Size(100, 25);
            this.TID.TabIndex = 12;
            // 
            // SID
            // 
            this.SID.Location = new System.Drawing.Point(398, 52);
            this.SID.Name = "SID";
            this.SID.Size = new System.Drawing.Size(100, 25);
            this.SID.TabIndex = 13;
            // 
            // CalcID
            // 
            this.CalcID.Location = new System.Drawing.Point(610, 23);
            this.CalcID.Name = "CalcID";
            this.CalcID.Size = new System.Drawing.Size(100, 26);
            this.CalcID.TabIndex = 14;
            this.CalcID.Text = "Convert";
            this.CalcID.UseVisualStyleBackColor = true;
            this.CalcID.Click += new System.EventHandler(this.CalcID_Click);
            // 
            // HTC
            // 
            this.HTC.AutoSize = true;
            this.HTC.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HTC.Location = new System.Drawing.Point(-1, 52);
            this.HTC.Name = "HTC";
            this.HTC.Size = new System.Drawing.Size(52, 26);
            this.HTC.TabIndex = 15;
            this.HTC.Text = "HTC";
            // 
            // CTH
            // 
            this.CTH.AutoSize = true;
            this.CTH.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CTH.Location = new System.Drawing.Point(-1, 83);
            this.CTH.Name = "CTH";
            this.CTH.Size = new System.Drawing.Size(52, 26);
            this.CTH.TabIndex = 16;
            this.CTH.Text = "CTH";
            // 
            // TIDResult
            // 
            this.TIDResult.Enabled = false;
            this.TIDResult.Location = new System.Drawing.Point(504, 23);
            this.TIDResult.Name = "TIDResult";
            this.TIDResult.Size = new System.Drawing.Size(100, 25);
            this.TIDResult.TabIndex = 17;
            // 
            // SIDResult
            // 
            this.SIDResult.Enabled = false;
            this.SIDResult.Location = new System.Drawing.Point(504, 52);
            this.SIDResult.Name = "SIDResult";
            this.SIDResult.Size = new System.Drawing.Size(100, 25);
            this.SIDResult.TabIndex = 18;
            // 
            // IDCheck
            // 
            this.IDCheck.AutoSize = true;
            this.IDCheck.Location = new System.Drawing.Point(398, 83);
            this.IDCheck.Name = "IDCheck";
            this.IDCheck.Size = new System.Drawing.Size(67, 21);
            this.IDCheck.TabIndex = 19;
            this.IDCheck.Text = "5TO7";
            this.IDCheck.UseVisualStyleBackColor = true;
            // 
            // IDsCheck
            // 
            this.IDsCheck.AutoSize = true;
            this.IDsCheck.Location = new System.Drawing.Point(504, 83);
            this.IDsCheck.Name = "IDsCheck";
            this.IDsCheck.Size = new System.Drawing.Size(67, 21);
            this.IDsCheck.TabIndex = 20;
            this.IDsCheck.Text = "7TO5";
            this.IDsCheck.UseVisualStyleBackColor = true;
            // 
            // BoxInput_TextBox
            // 
            this.BoxInput_TextBox.Location = new System.Drawing.Point(131, 162);
            this.BoxInput_TextBox.Name = "BoxInput_TextBox";
            this.BoxInput_TextBox.Size = new System.Drawing.Size(42, 25);
            this.BoxInput_TextBox.TabIndex = 21;
            // 
            // PriceOutPut_TextBox
            // 
            this.PriceOutPut_TextBox.Location = new System.Drawing.Point(430, 196);
            this.PriceOutPut_TextBox.Name = "PriceOutPut_TextBox";
            this.PriceOutPut_TextBox.Size = new System.Drawing.Size(174, 25);
            this.PriceOutPut_TextBox.TabIndex = 22;
            // 
            // PriceCalc_BTN
            // 
            this.PriceCalc_BTN.Location = new System.Drawing.Point(610, 194);
            this.PriceCalc_BTN.Name = "PriceCalc_BTN";
            this.PriceCalc_BTN.Size = new System.Drawing.Size(100, 26);
            this.PriceCalc_BTN.TabIndex = 23;
            this.PriceCalc_BTN.Text = "Calculate";
            this.PriceCalc_BTN.UseVisualStyleBackColor = true;
            this.PriceCalc_BTN.Click += new System.EventHandler(this.PriceCalc_BTN_Click);
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Font = new System.Drawing.Font("MV Boli", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price.Location = new System.Drawing.Point(259, 122);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(240, 40);
            this.Price.TabIndex = 24;
            this.Price.Text = "Price Calculator";
            // 
            // PricePerBox_TextBox
            // 
            this.PricePerBox_TextBox.Location = new System.Drawing.Point(131, 196);
            this.PricePerBox_TextBox.Name = "PricePerBox_TextBox";
            this.PricePerBox_TextBox.Size = new System.Drawing.Size(179, 25);
            this.PricePerBox_TextBox.TabIndex = 25;
            // 
            // PricePerPKM_TextBox
            // 
            this.PricePerPKM_TextBox.Location = new System.Drawing.Point(430, 162);
            this.PricePerPKM_TextBox.Name = "PricePerPKM_TextBox";
            this.PricePerPKM_TextBox.Size = new System.Drawing.Size(174, 25);
            this.PricePerPKM_TextBox.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 26);
            this.label1.TabIndex = 27;
            this.label1.Text = "PricePerBox";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MV Boli", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(302, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 23);
            this.label2.TabIndex = 28;
            this.label2.Text = "PricePerPKM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(316, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 26);
            this.label3.TabIndex = 29;
            this.label3.Text = "TotalPrice";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 26);
            this.label4.TabIndex = 30;
            this.label4.Text = "BoxNumber";
            // 
            // MutiCalcUI
            // 
            this.ClientSize = new System.Drawing.Size(715, 249);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PricePerPKM_TextBox);
            this.Controls.Add(this.PricePerBox_TextBox);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.PriceCalc_BTN);
            this.Controls.Add(this.PriceOutPut_TextBox);
            this.Controls.Add(this.BoxInput_TextBox);
            this.Controls.Add(this.IDsCheck);
            this.Controls.Add(this.IDCheck);
            this.Controls.Add(this.SIDResult);
            this.Controls.Add(this.TIDResult);
            this.Controls.Add(this.CTH);
            this.Controls.Add(this.HTC);
            this.Controls.Add(this.CalcID);
            this.Controls.Add(this.SID);
            this.Controls.Add(this.TID);
            this.Controls.Add(this.CalcDTH);
            this.Controls.Add(this.CalcHTD);
            this.Controls.Add(this.Hex2);
            this.Controls.Add(this.Dec2);
            this.Controls.Add(this.Dec1);
            this.Controls.Add(this.Hex1);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.Nature);
            this.Controls.Add(this.PID);
            this.Controls.Add(this.PIDHex);
            this.Controls.Add(this.CalcNature);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MutiCalcUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void BindingData()
        {
            this.IDCheck.CheckedChanged += (_, __) =>
            {
                IDsCheck.Enabled=!IDCheck.Checked;
            };
            this.IDsCheck.CheckedChanged += (_, __) =>
            {
                IDCheck.Enabled = !IDsCheck.Checked;
            };
         }
            private void CalcStart_Click(object sender, System.EventArgs e)
        {
            var PID=uint.Parse(PIDHex.Text, System.Globalization.NumberStyles.HexNumber);
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
        private void CloseBTN_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CalcHTD_Click(object sender, EventArgs e)
        {
            var HEX= "0x"+Hex1.Text;
            var DEC = Convert.ToUInt64(HEX, 16);
            Dec1.Text = DEC.ToString();
        }

        private void CalcDTH_Click(object sender, EventArgs e)
        {
            var DEC = Int64.Parse(Dec2.Text);
            var HEX= DEC.ToString("X");
            Hex2.Text = HEX;
        }

        private void CalcID_Click(object sender, EventArgs e)
        {
            uint TIDSID;
            uint TID5;
            uint SID5;
            uint TID7;
            uint SID7;
            if (IDCheck.Checked == true)
            {
                TIDSID = UInt32.Parse(TID.Text) + UInt32.Parse(SID.Text) * 65536;
                TID7 = TIDSID % 1_000_000;
                SID7 = TIDSID / 1_000_000;
                TIDResult.Text = TID7.ToString();
                SIDResult.Text = SID7.ToString();
            }
            else if(IDsCheck.Checked == true)
            {
                TIDSID = UInt32.Parse(TID.Text) + UInt32.Parse(SID.Text) * 1_000_000;
                TID5 = TIDSID % 65536;
                SID5 = TIDSID / 65536;
                TIDResult.Text = TID5.ToString();
                SIDResult.Text = SID5.ToString();
            }
        }

        private void PriceCalc_BTN_Click(object sender, EventArgs e)
        {
            var Box = Int16.Parse(BoxInput_TextBox.Text);
            var a0 = 9.39116979028421;
            var a1 = 9.07347629645924;
            double PricePerBox = 0;
            if (Box < 9||Box==9)
            {
                PricePerBox = PriceFunction(Box);
            }
            else
            {
                for (int i = 0; i < Box - 9; i++)
                {
                    PricePerBox = a1 + (a1 - a0) / 10;
                    a0 = a1;
                    a1 = PricePerBox;
                }
            }
            double Price = PricePerBox*Box; 
            var PricePerPKM= (Price / Box/30);
            PriceOutPut_TextBox.Text = Price.ToString();
            PricePerBox_TextBox.Text = PricePerBox.ToString();
            PricePerPKM_TextBox.Text = PricePerPKM.ToString();
        }
        private double PriceFunction(int Box)
        {
            double Price;
                Price = (15 + (-2.69727717624839005266) * Math.Log(Box));
            return Price;
        }
    }
}