using PKHeX.Core;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
namespace WangPlugin
{
    public partial class calc : Form
    {
        private Button CalcStart;
        private Button Exit;
        private Label PID;
        private TextBox Nature;
        private TextBox PIDHex;
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }

        private CancellationTokenSource tokenSource = new();

#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        public calc()
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(calc));
            this.CalcStart = new Button();
            this.Exit = new Button();
            this.PIDHex = new TextBox();
            this.PID = new Label();
            this.Nature = new TextBox();
            this.SuspendLayout();
            // 
            // CalcStart
            // 
            this.CalcStart.Location = new System.Drawing.Point(67, 85);
            this.CalcStart.Name = "CalcStart";
            this.CalcStart.Size = new System.Drawing.Size(75, 40);
            this.CalcStart.TabIndex = 0;
            this.CalcStart.Text = "计算性格";
            this.CalcStart.UseVisualStyleBackColor = true;
            this.CalcStart.Click += new EventHandler(this.CalcStart_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(172, 85);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 40);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "退出";
            this.Exit.UseVisualStyleBackColor = true;
            // 
            // PIDHex
            // 
            this.PIDHex.Location = new System.Drawing.Point(54, 47);
            this.PIDHex.Name = "PIDHex";
            this.PIDHex.Size = new System.Drawing.Size(100, 25);
            this.PIDHex.TabIndex = 2;
            // 
            // PID
            // 
            this.PID.AutoSize = true;
            this.PID.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PID.Location = new System.Drawing.Point(2, 47);
            this.PID.Name = "PID";
            this.PID.Size = new System.Drawing.Size(46, 23);
            this.PID.TabIndex = 3;
            this.PID.Text = "PID";
            // 
            // Nature
            // 
            this.Nature.Location = new System.Drawing.Point(160, 47);
            this.Nature.Name = "Nature";
            this.Nature.Size = new System.Drawing.Size(100, 25);
            this.Nature.TabIndex = 4;
            // 
            // calc
            // 
            this.ClientSize = new System.Drawing.Size(291, 143);
            this.Controls.Add(this.Nature);
            this.Controls.Add(this.PID);
            this.Controls.Add(this.PIDHex);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.CalcStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "calc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private void CalcStart_Click(object sender, System.EventArgs e)
        {
            var PID=uint.Parse(PIDHex.Text, System.Globalization.NumberStyles.HexNumber);
            var NatureID = PID % 25;
            
            Nature.Text = ShowNature(NatureID);

        }
        private string ShowNature(uint ID)
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
    }
}