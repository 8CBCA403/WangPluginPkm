using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WangPlugin
{
    internal class RNGForm : Form
    {
        private Button Overworld8;
        private Button Method1;
        private CancellationTokenSource tokenSource = new();
        public ISaveFileProvider SaveFileEditor { get; private set; } = null!;
        public IPKMView PKMEditor { get; private set; } = null!;
        public RNGForm()
        {  
        InitializeComponent(); 
        }
        private void InitializeComponent()
        {
            this.Method1 = new System.Windows.Forms.Button();
            this.Overworld8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Method1
            // 
            this.Method1.Location = new System.Drawing.Point(24, 31);
            this.Method1.Name = "Method1";
            this.Method1.Size = new System.Drawing.Size(97, 38);
            this.Method1.TabIndex = 0;
            this.Method1.Text = "Method1RNG";
            this.Method1.UseVisualStyleBackColor = true;
            this.Method1.Click += new System.EventHandler(this.Method1_Click);
            // 
            // Overworld8
            // 
            this.Overworld8.Location = new System.Drawing.Point(24, 93);
            this.Overworld8.Name = "Overworld8";
            this.Overworld8.Size = new System.Drawing.Size(97, 38);
            this.Overworld8.TabIndex = 1;
            this.Overworld8.Text = "Overworld8RNG";
            this.Overworld8.UseVisualStyleBackColor = true;
            this.Overworld8.Click += new System.EventHandler(this.Overworld8_Click);
            // 
            // RNGForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.Overworld8);
            this.Controls.Add(this.Method1);
            this.Name = "RNGForm";
            this.ResumeLayout(false);

        }
      
        private void IsRunning(bool running)
        {
            Method1.Enabled = !running;
            Overworld8.Enabled = !running;
        }

        private void Method1_Click(object sender, EventArgs e)
        {
            var seed = Util.Rand32();
            while (true)
            {
                var pkm = Method1RNG.GenPkm(PKMEditor.Data, seed, PKMEditor.Data.TID, PKMEditor.Data.SID);
                if (GetShinyXor(pkm.PID, pkm.TID, pkm.SID) < 8)
                {
                    pkm.RefreshChecksum();
                    MessageBox.Show($"过啦！");
                    PKMEditor.PopulateFields(pkm, false);
                    SaveFileEditor.ReloadSlots();
                }
                seed = Method1RNG.Next(seed);
            }
        }

        private void Overworld8_Click(object sender, EventArgs e)
        {

        }
        private static uint GetShinyXor(uint pid, int TID, int SID)
        {
            return ((uint)(TID ^ SID) ^ ((pid >> 16) ^ (pid & 0xFFFF)));
        }
    }
}
