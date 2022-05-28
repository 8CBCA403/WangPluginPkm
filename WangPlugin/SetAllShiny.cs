using System;
using System.Windows.Forms;
using PKHeX.Core;
using System.Collections.Generic;
using System.Diagnostics;


namespace WangPlugin
{
    internal class SetAllShiny : Form
    {
        private Button ShinySID_BTN;
        private Button RandomStar_BTN;
        private Button ForceSquare_BTN;
        private ComboBox XorBox;
        private Button Xor_BTN;
        public  static uint XorNumber;
        public static Stopwatch sw = new();
        private Button ForceStar;
        private Label XorValue_Label;

        public enum Shinytype
        {
            Sid,
            Star,
            Square,
            RandomStar,
            Xor,
        }
        public static Shinytype shinyflag=Shinytype.Star;
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
            this.ShinySID_BTN = new System.Windows.Forms.Button();
            this.RandomStar_BTN = new System.Windows.Forms.Button();
            this.ForceSquare_BTN = new System.Windows.Forms.Button();
            this.XorBox = new System.Windows.Forms.ComboBox();
            this.Xor_BTN = new System.Windows.Forms.Button();
            this.ForceStar = new System.Windows.Forms.Button();
            this.XorValue_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ShinySID_BTN
            // 
            this.ShinySID_BTN.Location = new System.Drawing.Point(21, 43);
            this.ShinySID_BTN.Name = "ShinySID_BTN";
            this.ShinySID_BTN.Size = new System.Drawing.Size(107, 27);
            this.ShinySID_BTN.TabIndex = 0;
            this.ShinySID_BTN.Text = "ShinySID";
            this.ShinySID_BTN.UseVisualStyleBackColor = true;
            this.ShinySID_BTN.Click += new System.EventHandler(this.ShinySID_BTN_Click);
            // 
            // RandomStar_BTN
            // 
            this.RandomStar_BTN.Location = new System.Drawing.Point(21, 12);
            this.RandomStar_BTN.Name = "RandomStar_BTN";
            this.RandomStar_BTN.Size = new System.Drawing.Size(107, 29);
            this.RandomStar_BTN.TabIndex = 1;
            this.RandomStar_BTN.Text = "RandomShiny";
            this.RandomStar_BTN.UseVisualStyleBackColor = true;
            this.RandomStar_BTN.Click += new System.EventHandler(this.ForceStar_BTN_Click);
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
            this.XorBox.Location = new System.Drawing.Point(187, 47);
            this.XorBox.Name = "XorBox";
            this.XorBox.Size = new System.Drawing.Size(54, 23);
            this.XorBox.TabIndex = 3;
            // 
            // Xor_BTN
            // 
            this.Xor_BTN.Location = new System.Drawing.Point(247, 43);
            this.Xor_BTN.Name = "Xor_BTN";
            this.Xor_BTN.Size = new System.Drawing.Size(103, 27);
            this.Xor_BTN.TabIndex = 4;
            this.Xor_BTN.Text = "XorShiny";
            this.Xor_BTN.UseVisualStyleBackColor = true;
            this.Xor_BTN.Click += new System.EventHandler(this.Xor_BTN_Click);
            // 
            // ForceStar
            // 
            this.ForceStar.Location = new System.Drawing.Point(134, 12);
            this.ForceStar.Name = "ForceStar";
            this.ForceStar.Size = new System.Drawing.Size(107, 29);
            this.ForceStar.TabIndex = 5;
            this.ForceStar.Text = "ForceStar";
            this.ForceStar.UseVisualStyleBackColor = true;
            this.ForceStar.Click += new System.EventHandler(this.ForceStar_Click);
            // 
            // XorValue_Label
            // 
            this.XorValue_Label.AutoSize = true;
            this.XorValue_Label.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XorValue_Label.Location = new System.Drawing.Point(134, 48);
            this.XorValue_Label.Name = "XorValue_Label";
            this.XorValue_Label.Size = new System.Drawing.Size(45, 19);
            this.XorValue_Label.TabIndex = 6;
            this.XorValue_Label.Text = "Xor=";
            // 
            // SetAllShiny
            // 
            this.ClientSize = new System.Drawing.Size(392, 84);
            this.Controls.Add(this.XorValue_Label);
            this.Controls.Add(this.ForceStar);
            this.Controls.Add(this.Xor_BTN);
            this.Controls.Add(this.XorBox);
            this.Controls.Add(this.ForceSquare_BTN);
            this.Controls.Add(this.RandomStar_BTN);
            this.Controls.Add(this.ShinySID_BTN);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetAllShiny";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);
            this.PerformLayout();

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
       
        public static void SetShiny(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.ModifyBoxes(ShinyFunction);
            
            SaveFileEditor.ReloadSlots();
        }
        public static void ShinySID(PKM pkm)
        {
            if (!MythicalPool.MythicalFlag(pkm.Species))
            {
                pkm.SetShinySID();
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
        private static uint ShinyPID(PKM val,int f=0)
        {
            if (shinyflag == Shinytype.RandomStar&&f==0)
                val.PID = RandomStar(val);
            else if (shinyflag == Shinytype.Star && f == 0)
                val.PID = (((uint)(val.TID ^ val.SID) ^ (val.PID & 0xFFFF) ^ 1u) << 16) | (val.PID & 0xFFFF);
            else if (shinyflag == Shinytype.Square && f == 0)
                val.PID = (((uint)(val.TID ^ val.SID) ^ (val.PID & 0xFFFF) ^ 0u) << 16) | (val.PID & 0xFFFF);
            else if (shinyflag == Shinytype.Xor && f == 0)
                val.PID = (((uint)(val.TID ^ val.SID) ^ (val.PID & 0xFFFF) ^ XorNumber) << 16) | (val.PID & 0xFFFF);
            else if(f==1)
                val.PID = (((uint)(val.TID ^ val.SID) ^ (val.PID & 0xFFFF) ^ 1u) << 16) | (val.PID & 0xFFFF);
            return val.PID;
        }
        public static void ShinyFunction(PKM pkm)
        {
            PKM val = pkm.Clone();
            PKM va = pkm.Clone();
            if (!MythicalPool.MythicalFlag(pkm.Species))
            {
                bool EggFlag = val.IsEgg || val.WasEgg || val.IsTradedEgg || val.WasTradedEgg || val.Met_Level <= 1;
                if (Version.Gen1VCFlag(val.Version) || Version.Gen2VCFlag(val.Version))
                {
                    pkm.PID = ShinyPID(val);
                }
                if (Version.Gen3Flag(val.Version) ||
                    Version.Gen4Flag(val.Version) ||
                    Version.Gen5Flag(val.Version) ||
                    Version.CXDFlag(val.Version))
                {
                    if (EggFlag)
                    {

                        pkm.PID = ShinyPID(val);
                        if (pkm.Format != 3)
                        {
                            pkm.Ball = 4;
                        }
                        pkm.RefreshAbility((int)(pkm.PID & 1));
                        var abilityarray = pkm.PersonalInfo.Abilities;
                        if (abilityarray[0] == abilityarray[1])
                        {
                            pkm.AbilityNumber = 1;
                        }
                        pkm.Nature = (int)(pkm.PID % 25);
                        pkm.Gender = EntityGender.GetFromPID(pkm.Species, pkm.PID);
                        pkm.StatNature = pkm.Nature;
                        pkm.EncryptionConstant = pkm.PID;
                        pkm.RefreshChecksum();

                    }
                    if ((!EggFlag) && (!Version.CXDFlag(val.Version)))
                    {
                        List<uint[]> list;
                        do
                        {
                            val.PID = ShinyPID(val);

                            list = RecoverLower16BitsPID.CalcPIDIVsByLCRNG(val.PID);
                        }
                        while (!val.IsShiny || list == null);
                        uint[] iVs = RecoverLower16BitsPID.GetIVs(val, list);
                        RecoverLower16BitsPID.SetIVsFromList(val, iVs);
                        pkm.PID = val.PID;
                        pkm.IVs = val.IVs;
                        pkm.Gender = EntityGender.GetFromPID(pkm.Species, pkm.PID);
                        pkm.Nature = (int)(pkm.PID % 25);
                        pkm.StatNature = pkm.Nature;
                        pkm.EncryptionConstant = pkm.PID;
                        pkm.RefreshAbility((int)(pkm.PID & 1));
                        var abilityarray = pkm.PersonalInfo.Abilities;
                        if (abilityarray[0] == abilityarray[1])
                        {
                            pkm.AbilityNumber = 1;
                        }
                        pkm.RefreshChecksum();
                    }
                    if (Version.CXDFlag(val.Version) && !GiftAndStarter.XDCGFFlag(val.Species))
                    {

                        List<uint[]> list;
                        do
                        {
                            val.PID = ShinyPID(val);

                            list = RecoverLower16BitsEuclid16.CalcPIDIVsByXDRNG(val.PID);
                        }
                        while (!val.IsShiny || list == null);

                        uint[] iVs = RecoverLower16BitsEuclid16.GetIVs(val, list);
                        RecoverLower16BitsEuclid16.SetIVsFromList(val, iVs);
                        pkm.PID = val.PID;
                        pkm.IVs = val.IVs;
                        pkm.Gender = EntityGender.GetFromPID(pkm.Species, pkm.PID);
                        pkm.Nature = (int)(pkm.PID % 25);
                        pkm.EncryptionConstant = pkm.PID;
                        pkm.RefreshChecksum();
                    }

                }
                if (Version.Gen6Flag(val.Version) ||
                    Version.Gen7Flag(val.Version))
                {
                    pkm.PID = ShinyPID(val);
                    CommonEdits.SetRandomEC(pkm);
                }
                if (Version.Gen8SWSHFlag(val.Version))
                {
                    pkm.PID = Util.Rand32();
                    if (EggFlag)
                    {
                        pkm.PID = ShinyPID(val);
                        CommonEdits.SetRandomEC(pkm);
                    }
                    else if (Gen8MaxLairGodPool.MaxLairGodFlag(pkm.Species))
                    {
                        pkm.PID = ShinyPID(val, 1);
                        CommonEdits.SetRandomEC(pkm);
                    }
                    else
                    {
                        bool[] iv = new bool[] { false, false, false };
                        for (; ; )
                        {
                            uint seed = Util.Rand32();
                            if (shinyflag != Shinytype.Xor && Overworld8RNG.GenPkm(ref pkm, seed, ShinyArray(), iv))
                            {
                                pkm.RefreshChecksum();
                                break;
                            }
                            else if (shinyflag == Shinytype.Xor && Overworld8RNG.GenPkm(ref pkm, seed, ShinyArray(), iv, XorNumber))
                            {
                                pkm.RefreshChecksum();
                                break;
                            }
                            else
                                Overworld8RNG.Next(seed);
                        }
                    }
                }
                if(Version.Gen8PLAFlag(val.Version))
                {
                    pkm.PID = ShinyPID(val);
                    CommonEdits.SetRandomEC(pkm);
                }
                if(Version.Gen8BDSPFlag(val.Version))
                {
                    pkm.PID = ShinyPID(val);
                    CommonEdits.SetRandomEC(pkm);
                }
            }
            var la = new LegalityAnalysis(pkm);
            if (!la.Valid)
            {
                pkm.PID = va.PID;
                pkm.IVs = va.IVs;
                pkm.Ability = va.Ability;
                pkm.AbilityNumber = va.AbilityNumber;
                pkm.Nature = va.Nature;
                pkm.StatNature = va.StatNature;
                pkm.Gender = va.Gender;
                pkm.EncryptionConstant = va.EncryptionConstant;
                if (pkm is IScaledSize s&& va is IScaledSize p)
                {
                 s.HeightScalar = p.HeightScalar;
                 s.WeightScalar = p.WeightScalar;
                }
            }
        }
        private void ShinySID_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            SAV.SAV.ModifyBoxes(ShinySID);
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒","SuperWang");
        }

        private void ForceStar_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            shinyflag = Shinytype.RandomStar;
            SetShiny(SAV);
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
        }
        private static bool[] ShinyArray()
        {
            bool[] shiny = new bool[6] { false, false, false, false, false, false };
            
            if (shinyflag == Shinytype.RandomStar)
            {
                shiny = new bool[6] { false, false, true, false, false, false };
            }
            else if (shinyflag == Shinytype.Star)
            {
                shiny = new bool[6] { false, false, false, false, true, false };
            }
            else if (shinyflag == Shinytype.Square)
            {
                shiny = new bool[6] { false, false, false, true, false, false };
            }
            else if (shinyflag == Shinytype.Xor)
            {
                shiny = new bool[6] { false, false, false, false, false, true };
            }
            return shiny;
        }
        private void ForceSquare_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            shinyflag = Shinytype.Square;
            SetShiny(SAV);
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
        }

        private void Xor_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            shinyflag = Shinytype.Xor;
            SetShiny(SAV);
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
        }

        private void ForceStar_Click(object sender, EventArgs e)
        {
            sw.Start();
            shinyflag = Shinytype.Star;
            SetShiny(SAV);
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
        }
    }
}
