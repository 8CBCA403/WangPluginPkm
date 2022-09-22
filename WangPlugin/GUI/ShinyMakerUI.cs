using System;
using System.Windows.Forms;
using PKHeX.Core;
using System.Collections.Generic;
using System.Diagnostics;
namespace WangPlugin.GUI
{
    internal class ShinyMakerUI : Form
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
        public ShinyMakerUI(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            BindingData();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShinyMakerUI));
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
            this.ShinySID_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.ShinySID_BTN.Location = new System.Drawing.Point(12, 45);
            this.ShinySID_BTN.Name = "ShinySID_BTN";
            this.ShinySID_BTN.Size = new System.Drawing.Size(120, 30);
            this.ShinySID_BTN.TabIndex = 0;
            this.ShinySID_BTN.Text = "随机SID闪光";
            this.ShinySID_BTN.UseVisualStyleBackColor = true;
            this.ShinySID_BTN.Click += new System.EventHandler(this.ShinySID_BTN_Click);
            // 
            // RandomStar_BTN
            // 
            this.RandomStar_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.RandomStar_BTN.Location = new System.Drawing.Point(12, 12);
            this.RandomStar_BTN.Name = "RandomStar_BTN";
            this.RandomStar_BTN.Size = new System.Drawing.Size(120, 30);
            this.RandomStar_BTN.TabIndex = 1;
            this.RandomStar_BTN.Text = "随机闪光";
            this.RandomStar_BTN.UseVisualStyleBackColor = true;
            this.RandomStar_BTN.Click += new System.EventHandler(this.ForceStar_BTN_Click);
            // 
            // ForceSquare_BTN
            // 
            this.ForceSquare_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.ForceSquare_BTN.Location = new System.Drawing.Point(282, 12);
            this.ForceSquare_BTN.Name = "ForceSquare_BTN";
            this.ForceSquare_BTN.Size = new System.Drawing.Size(120, 30);
            this.ForceSquare_BTN.TabIndex = 2;
            this.ForceSquare_BTN.Text = "强制方块";
            this.ForceSquare_BTN.UseVisualStyleBackColor = true;
            this.ForceSquare_BTN.Click += new System.EventHandler(this.ForceSquare_BTN_Click);
            // 
            // XorBox
            // 
            this.XorBox.FormattingEnabled = true;
            this.XorBox.Location = new System.Drawing.Point(194, 48);
            this.XorBox.Name = "XorBox";
            this.XorBox.Size = new System.Drawing.Size(73, 23);
            this.XorBox.TabIndex = 3;
            // 
            // Xor_BTN
            // 
            this.Xor_BTN.Font = new System.Drawing.Font("黑体", 9F);
            this.Xor_BTN.Location = new System.Drawing.Point(282, 45);
            this.Xor_BTN.Name = "Xor_BTN";
            this.Xor_BTN.Size = new System.Drawing.Size(120, 30);
            this.Xor_BTN.TabIndex = 4;
            this.Xor_BTN.Text = "指定Xor闪光";
            this.Xor_BTN.UseVisualStyleBackColor = true;
            this.Xor_BTN.Click += new System.EventHandler(this.Xor_BTN_Click);
            // 
            // ForceStar
            // 
            this.ForceStar.Font = new System.Drawing.Font("黑体", 9F);
            this.ForceStar.Location = new System.Drawing.Point(147, 12);
            this.ForceStar.Name = "ForceStar";
            this.ForceStar.Size = new System.Drawing.Size(120, 30);
            this.ForceStar.TabIndex = 5;
            this.ForceStar.Text = "强制星星";
            this.ForceStar.UseVisualStyleBackColor = true;
            this.ForceStar.Click += new System.EventHandler(this.ForceStar_Click);
            // 
            // XorValue_Label
            // 
            this.XorValue_Label.AutoSize = true;
            this.XorValue_Label.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XorValue_Label.Location = new System.Drawing.Point(143, 49);
            this.XorValue_Label.Name = "XorValue_Label";
            this.XorValue_Label.Size = new System.Drawing.Size(45, 19);
            this.XorValue_Label.TabIndex = 6;
            this.XorValue_Label.Text = "Xor=";
            // 
            // ShinyMakerUI
            // 
            this.AllowDrop = true;
            this.ClientSize = new System.Drawing.Size(414, 80);
            this.Controls.Add(this.XorValue_Label);
            this.Controls.Add(this.ForceStar);
            this.Controls.Add(this.Xor_BTN);
            this.Controls.Add(this.XorBox);
            this.Controls.Add(this.ForceSquare_BTN);
            this.Controls.Add(this.RandomStar_BTN);
            this.Controls.Add(this.ShinySID_BTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ShinyMakerUI";
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
            if (!MythicalFlag.MFlag(pkm.Species))
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
        private static int ShinySIDLite(PKM val, int f = 0)
        {
            if (shinyflag == Shinytype.Star && f == 0)
                val.SID = SetShinySID(val.TID, val.PID, Shinytype.Star);
            else if (shinyflag == Shinytype.Square && f == 0)
                val.SID = SetShinySID(val.TID, val.PID, Shinytype.Square);
            else if (shinyflag == Shinytype.Xor && f == 0)
                val.SID = SetShinySID(val.TID, val.PID, Shinytype.Xor); ;
            return val.SID;
        }
        private static uint ShinyPIDLite(PKM val, int f = 0)
        {
            if (shinyflag == Shinytype.RandomStar && f == 0)
                val.PID = RandomStar(val);
             return val.PID;
        }
        public static void ShinyFunction(PKM pkm)
        {
            PKM val = pkm.Clone();
            PKM va = pkm.Clone();
            if (!MythicalFlag.MFlag(pkm.Species))
            {
                bool EggFlag = val.IsEgg || val.WasEgg || val.IsTradedEgg || val.WasTradedEgg || val.Met_Level <= 1;
                if (VersionFlag.Gen1VCFlag(val.Version) || VersionFlag.Gen2VCFlag(val.Version))
                {
                    pkm.PID = ShinyPID(val);
                }
                if (VersionFlag.Gen3Flag(val.Version) ||
                    VersionFlag.Gen4Flag(val.Version) ||
                    VersionFlag.Gen5Flag(val.Version) ||
                    VersionFlag.CXDFlag(val.Version))
                {
                    if (EggFlag)
                    {

                        pkm.PID = ShinyPID(val);
                        if (pkm.Format != 3)
                        {
                            pkm.Ball = 4;
                        }
                        pkm.RefreshAbility((int)(pkm.PID & 1));
                        Span<int> abilityarray = stackalloc int[10]; ;
                        pkm.PersonalInfo.GetAbilities(abilityarray);
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
                    if ((!EggFlag) && (!VersionFlag.CXDFlag(val.Version)))
                    {
                        const int maxResults = LCRNG.MaxCountSeedsIV;
                        Span<uint> seeds = stackalloc uint[maxResults];
                        int count = 0;
                        if (shinyflag == Shinytype.RandomStar)
                        {
                            for (int i = 0; ; i++)
                            {
                                val.PID = ShinyPIDLite(val);
                                count = LCRNGReversal.GetSeeds(seeds, val.PID);
                                if (count == 0)
                                    val.PID = Util.Rand32();
                                else
                                    break;
                            }
                            var reg = seeds[..count];
                            int[] iv;
                            foreach (var seed in reg)
                            {
                                iv= LCRNGReversal.SetValuesFromSeedLCRNG(val, seed);
                                if (val.IsShiny)
                                    val.IVs = iv;
                            }
                        }
                        else
                        {
                            pkm.SID = ShinySIDLite(val);
                        }
                        pkm.PID = val.PID;
                        pkm.IVs = val.IVs;
                        pkm.Gender = EntityGender.GetFromPID(pkm.Species, pkm.PID);
                        pkm.Nature = (int)(pkm.PID % 25);
                        pkm.StatNature = pkm.Nature;
                        pkm.EncryptionConstant = pkm.PID;
                        pkm.RefreshAbility((int)(pkm.PID & 1));
                        Span<int> abilityarray = stackalloc int[10]; ;
                        pkm.PersonalInfo.GetAbilities(abilityarray);
                        if (abilityarray[0] == abilityarray[1])
                        {
                            pkm.AbilityNumber = 1;
                        }
                        pkm.RefreshChecksum();
                    }
                    if (VersionFlag.CXDFlag(val.Version) && !GiftAndStarter.XDCGFFlag(val.Species))
                    {

                        const int maxResults = XDRNG.MaxCountSeedsIV;
                        Span<uint> seeds = stackalloc uint[maxResults];
                        int count = 0;
                        if (shinyflag == Shinytype.RandomStar)
                        {
                            for (int i = 0; ; i++)
                            {
                                val.PID = ShinyPIDLite(val);
                                count = XDRNGReversal.GetSeeds(seeds, val.PID);
                                if (count == 0)
                                    val.PID = Util.Rand32();
                                var reg = seeds[..count];
                                int[] iv;
                                foreach (var seed in reg)
                                {
                                    iv = XDRNGReversal.SetValuesFromSeedXDRNG(val, seed);
                                    if (val.IsShiny)
                                        val.IVs = iv;
                                }
                                if (!val.IsShiny)
                                {
                                    continue;
                                }
                                else
                                    break;
                            }
                        }
                        else
                        {
                            pkm.SID = ShinySIDLite(val);
                        }
                        pkm.PID = val.PID;
                        pkm.IVs = val.IVs;
                        pkm.Gender = EntityGender.GetFromPID(pkm.Species, pkm.PID);
                        pkm.Nature = (int)(pkm.PID % 25);
                        pkm.EncryptionConstant = pkm.PID;
                        pkm.RefreshChecksum();
                    }

                }
                if (VersionFlag.Gen6Flag(val.Version) ||
                    VersionFlag.Gen7Flag(val.Version))
                {
                    pkm.PID = ShinyPID(val);
                    CommonEdits.SetRandomEC(pkm);
                }
                if (VersionFlag.Gen8SWSHFlag(val.Version))
                {
                    pkm.PID = Util.Rand32();
                    if (EggFlag||pkm.Met_Location==162)
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
                            if (shinyflag != Shinytype.Xor && Overworld8RNG.GenPkmQ(ref pkm, seed, ShinyArray(), iv))
                            {
                                pkm.RefreshChecksum();
                                break;
                            }
                            else if (shinyflag == Shinytype.Xor && Overworld8RNG.GenPkmQ(ref pkm, seed, ShinyArray(), iv, XorNumber))
                            {
                               
                                pkm.RefreshChecksum();
                                break;
                            }
                            else
                                Overworld8RNG.Next(seed);
                        }
                    }
                }
                if(VersionFlag.Gen8PLAFlag(val.Version))
                {
                    pkm.PID = ShinyPID(val);
                    CommonEdits.SetRandomEC(pkm);
                }
                if(VersionFlag.Gen8BDSPFlag(val.Version))
                {
                    pkm.PID = ShinyPID(val);
                    CommonEdits.SetRandomEC(pkm);
                }
            }
            var la = new LegalityAnalysis(pkm);
            if (!la.Valid)
            {
                pkm.TID = va.TID;
                pkm.SID = va.SID;
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
        public static int SetShinySID(int TID,uint PID,Shinytype shiny=Shinytype.Square)
        {
 
            var xor = TID ^ (PID >> 16) ^ (PID & 0xFFFF);
            uint bits = shiny switch
            {
                Shinytype.Square => 0,
                Shinytype.Star => 1,
                Shinytype.Xor=> XorNumber,
               _=>0,
            };
            int SID = (int)xor ^ (int)bits;
            return SID; 
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
            sw.Reset();
        }

        private void Xor_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            shinyflag = Shinytype.Xor;
            SetShiny(SAV);
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
            sw.Reset();
        }

        private void ForceStar_Click(object sender, EventArgs e)
        {
            sw.Start();
            shinyflag = Shinytype.Star;
            SetShiny(SAV);
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
            sw.Reset();
        }

     
    }
}
