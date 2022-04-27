using PKHeX.Core;
using System.Threading;
using System.Windows.Forms;
using System;
namespace WangPlugin
{
    public partial class Calc : Form
    {
        private Button CalcStart;
        private Label PID;
        private TextBox Nature;
        private Button CloseBTN;
        private TextBox PIDHex;
        public Calc()

        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calc));
            this.CalcStart = new System.Windows.Forms.Button();
            this.PIDHex = new System.Windows.Forms.TextBox();
            this.PID = new System.Windows.Forms.Label();
            this.Nature = new System.Windows.Forms.TextBox();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CalcStart
            // 
            this.CalcStart.Location = new System.Drawing.Point(54, 53);
            this.CalcStart.Name = "CalcStart";
            this.CalcStart.Size = new System.Drawing.Size(100, 28);
            this.CalcStart.TabIndex = 0;
            this.CalcStart.Text = "Calculate";
            this.CalcStart.UseVisualStyleBackColor = true;
            this.CalcStart.Click += new System.EventHandler(this.CalcStart_Click);
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
            this.Nature.Location = new System.Drawing.Point(160, 22);
            this.Nature.Name = "Nature";
            this.Nature.Size = new System.Drawing.Size(100, 25);
            this.Nature.TabIndex = 4;
            // 
            // CloseBTN
            // 
            this.CloseBTN.Location = new System.Drawing.Point(160, 53);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(100, 28);
            this.CloseBTN.TabIndex = 5;
            this.CloseBTN.Text = "Close";
            this.CloseBTN.UseVisualStyleBackColor = true;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // Calc
            // 
            this.ClientSize = new System.Drawing.Size(292, 89);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.Nature);
            this.Controls.Add(this.PID);
            this.Controls.Add(this.PIDHex);
            this.Controls.Add(this.CalcStart);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Calc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);
            this.PerformLayout();

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
                    Nature = "Hardy";
                    break;
                case 1:
                    Nature = "Lonely";
                    break;
                case 2:
                    Nature = "Brave";
                    break;
                case 3:
                    Nature = "Adamant";
                    break;
                case 4:
                    Nature = "Naughty";
                    break;
                case 5:
                    Nature = "Bold";
                    break;
                case 6:
                    Nature = "Docile";
                    break;
                case 7:
                    Nature = "Relaxed";
                    break;
                case 8:
                    Nature = "Impish";
                    break;
                case 9:
                    Nature = "Lax";
                    break;
                case 10:
                    Nature = "Timid";
                    break;
                case 11:
                    Nature = "Hasty";
                    break;
                case 12:
                    Nature = "Serious";
                    break;
                case 13:
                    Nature = "Jolly";
                    break;
                case 14:
                    Nature = "Naive";
                    break;
                case 15:
                    Nature = "Modest";
                    break;
                case 16:
                    Nature = "Mild";
                    break;
                case 17:
                    Nature = "Quiet";
                    break;
                case 18:
                    Nature = "Bashful";
                    break;
                case 19:
                    Nature = "Rash";
                    break;
                case 20:
                    Nature = "Calm";
                    break;
                case 21:
                    Nature = "Gentle";
                    break;
                case 22:
                    Nature = "Sassy";
                    break;
                case 23:
                    Nature = "Careful";
                    break;
                case 24:
                    Nature = "Quirky";
                    break;
            }
           
            return Nature;
        }
        private void CloseBTN_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}