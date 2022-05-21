using System;
using System.Windows.Forms;
using PKHeX.Core;
using System.Collections.Generic;
using System.Diagnostics;

namespace WangPlugin
{
    internal class SetAllShiny : Form
    {
        private Button ForceShiny_BTN;
        private Button ForceStar_BTN;
        private Button ForceSquare_BTN;
        private ComboBox XorBox;
        private Button Xor_BTN;
        public  static uint XorNumber;
        public Stopwatch sw = new();
        public enum shinytype
        {
            Star,
            Square,
            RandomStar,
            Xor,
        }
        public static shinytype shiny=shinytype.Star;
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        
        public SetAllShiny(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            BindingData();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetAllShiny));
            this.ForceShiny_BTN = new System.Windows.Forms.Button();
            this.ForceStar_BTN = new System.Windows.Forms.Button();
            this.ForceSquare_BTN = new System.Windows.Forms.Button();
            this.XorBox = new System.Windows.Forms.ComboBox();
            this.Xor_BTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ForceShiny_BTN
            // 
            this.ForceShiny_BTN.Location = new System.Drawing.Point(25, 12);
            this.ForceShiny_BTN.Name = "ForceShiny_BTN";
            this.ForceShiny_BTN.Size = new System.Drawing.Size(103, 29);
            this.ForceShiny_BTN.TabIndex = 0;
            this.ForceShiny_BTN.Text = "ForceShiny";
            this.ForceShiny_BTN.UseVisualStyleBackColor = true;
            this.ForceShiny_BTN.Click += new System.EventHandler(this.ForceShiny_BTN_Click);
            // 
            // ForceStar_BTN
            // 
            this.ForceStar_BTN.Location = new System.Drawing.Point(134, 12);
            this.ForceStar_BTN.Name = "ForceStar_BTN";
            this.ForceStar_BTN.Size = new System.Drawing.Size(107, 29);
            this.ForceStar_BTN.TabIndex = 1;
            this.ForceStar_BTN.Text = "ForceStar";
            this.ForceStar_BTN.UseVisualStyleBackColor = true;
            this.ForceStar_BTN.Click += new System.EventHandler(this.ForceStar_BTN_Click);
            // 
            // ForceSquare_BTN
            // 
            this.ForceSquare_BTN.Location = new System.Drawing.Point(247, 12);
            this.ForceSquare_BTN.Name = "ForceSquare_BTN";
            this.ForceSquare_BTN.Size = new System.Drawing.Size(103, 29);
            this.ForceSquare_BTN.TabIndex = 2;
            this.ForceSquare_BTN.Text = "ForceSqaure";
            this.ForceSquare_BTN.UseVisualStyleBackColor = true;
            this.ForceSquare_BTN.Click += new System.EventHandler(this.ForceSquare_BTN_Click);
            // 
            // XorBox
            // 
            this.XorBox.FormattingEnabled = true;
            this.XorBox.Location = new System.Drawing.Point(88, 47);
            this.XorBox.Name = "XorBox";
            this.XorBox.Size = new System.Drawing.Size(81, 23);
            this.XorBox.TabIndex = 3;
            // 
            // Xor_BTN
            // 
            this.Xor_BTN.Location = new System.Drawing.Point(197, 43);
            this.Xor_BTN.Name = "Xor_BTN";
            this.Xor_BTN.Size = new System.Drawing.Size(94, 29);
            this.Xor_BTN.TabIndex = 4;
            this.Xor_BTN.Text = "XorShiny";
            this.Xor_BTN.UseVisualStyleBackColor = true;
            this.Xor_BTN.Click += new System.EventHandler(this.Xor_BTN_Click);
            // 
            // SetAllShiny
            // 
            this.ClientSize = new System.Drawing.Size(392, 84);
            this.Controls.Add(this.Xor_BTN);
            this.Controls.Add(this.XorBox);
            this.Controls.Add(this.ForceSquare_BTN);
            this.Controls.Add(this.ForceStar_BTN);
            this.Controls.Add(this.ForceShiny_BTN);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetAllShiny";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);

        }
        private void BindingData()
        {
            int[] shiny8 = new int[16] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
            int[] shiny = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
            if (Editor.Data.Format < 8)
                this.XorBox.DataSource = shiny;
            else
                this.XorBox.DataSource = shiny8;
            this.XorBox.SelectedIndexChanged += (_, __) =>
            {
                XorNumber=Convert.ToUInt16(this.XorBox.SelectedItem.ToString());
            };
            this.XorBox.SelectedIndex = 0;
        }
        public static void SetStar(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.ModifyBoxes(ShinyFunction);
            SaveFileEditor.ReloadSlots();
        }
        public static void SetShiny(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.ModifyBoxes(ForceShiny);
            SaveFileEditor.ReloadSlots();
        }
        public static void SetSquare(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.ModifyBoxes(ShinyFunction);
            SaveFileEditor.ReloadSlots();
        }
        public static void SetXor(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.ModifyBoxes(ShinyFunction);
            SaveFileEditor.ReloadSlots();
        }
        public static void ForceShiny(PKM pkm)
        {
            pkm.SetShinySID();
        }
        public static void ShinyFunction(PKM pkm)
        {
            PKM val = pkm.Clone();
            if (val.Format is 3 or 4  && val.Version != 15)
            {
                List<uint[]> list = new List<uint[]>();
                do
                {
                    val.SetPIDGender(val.GetSaneGender());
                    if(shiny==shinytype.RandomStar)
                        val.PID = RandomStar(val);
                    else if(shiny==shinytype.Square)
                        val.PID = (((uint)(val.TID ^ val.SID) ^ (val.PID & 0xFFFF) ^ 0u) << 16) | (val.PID & 0xFFFF);
                    else if(shiny==shinytype.Xor)
                        val.PID = (((uint)(val.TID ^ val.SID) ^ (val.PID & 0xFFFF) ^ XorNumber) << 16) | (val.PID & 0xFFFF);
                    list = RecoverLower16BitsPID.CalcPIDIVsByLCRNG(val.PID);
                }
                while (!val.IsShiny || list == null);
                uint[] iVs = RecoverLower16BitsPID.GetIVs(val, list);
                RecoverLower16BitsPID.SetIVsFromList(val, iVs);
                pkm.PID=val.PID;
                pkm.RefreshAbility((int)(pkm.PID & 1));
                pkm.IVs=val.IVs;
            }
            else if(val.Format is  6 or 7)
            {
                pkm.PID = RandomStar(pkm);
                CommonEdits.SetRandomEC(pkm);
            }
            else if(val.Format==8)
            {
                bool[] shiny = new bool[] { false, false, true, false, false };
                bool[] iv = new bool[] { false, false, false };
                for(; ;)
                {
                    uint seed = Util.Rand32();
                    if (Overworld8RNG.GenPkm(ref pkm, seed, shiny, iv))
                        break;
                    else
                        Overworld8RNG.Next(seed);
                } 
            }

        }
        private static uint RandomStar(PKM pk)
        {
            Random myObject = new Random();
            var r = (uint)myObject.Next(1, 8);
            if (pk.Gen8 == true)
                r = (uint)myObject.Next(1, 16);
            return (((uint)(pk.TID ^ pk.SID) ^ (pk.PID & 0xFFFF) ^ r) << 16) | (pk.PID & 0xFFFF);
        }

        private void ForceShiny_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            SetShiny(SAV);
            sw.Stop();
            MessageBox.Show($"{sw.ElapsedMilliseconds}");
        }

        private void ForceStar_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            shiny = shinytype.RandomStar;
            SetStar(SAV);
            sw.Stop();
            MessageBox.Show($"{sw.ElapsedMilliseconds}");
        }

        private void ForceSquare_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            shiny = shinytype.Square;
            SetSquare(SAV);
            sw.Stop();
            MessageBox.Show($"{sw.ElapsedMilliseconds}");
        }

        private void Xor_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            shiny = shinytype.Xor;
            SetXor(SAV);
            sw.Stop();
            MessageBox.Show($"{sw.ElapsedMilliseconds}");
        }
    }
}
