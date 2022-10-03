using PKHeX.Core;
using System;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using WangPlugin.RNG;

namespace WangPlugin.GUI
{
    public partial class RNGForm : Form
    {
        
        private CancellationTokenSource tokenSource1 = new();
        private CancellationTokenSource tokenSource2 = new();
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        public enum Gender
        {
            [Description("只能公")]
            M,
            [Description("1母:7公")]
            OFSM,
            [Description("1母:3公")]
            OFTM,
            [Description("1母:1公")]
            OFOM,
            [Description("3母:1公")]
            TFOM,
            [Description("7母:1公")]
            SFOM,
            [Description("只能母")]
            F,
            [Description("无性别")]
            None,
        }
        public enum Ability
        {
            [Description("无梦特")]
            ND,
            [Description("有梦特")]
            CD,
            [Description("只能特性一")]
            ONE,
        }
       
        public Gender G = Gender.None;
        public Ability A = Ability.CD;
        public List<RNGModClass> L = new ();
        public RNGModClass MD = new RNGModClass
        {
            Name = "Mothed1,2,4",
            Value = "M124",
        };
        
        public int MinIV = 0;
        private static Random rng = new Random();
      
        public int[] DIV ={ 0, 1, 2, 3, 4, 5 ,6 };
        public RNGForm(ISaveFileProvider sav, IPKMView editor)

        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
            if (SAV.SAV.Version is GameVersion.XD or GameVersion.COLO or GameVersion.CXD)
            {
                this.TeamLockBox.Enabled = true;
            }
            else
            {
                this.TeamLockBox.Enabled = false;
                this.TeamLockBox.Checked = false;
            }
            PIDECCheck_Box.CheckedChanged += (_, __) =>
            {
                IVCheck_Box.Enabled = !PIDECCheck_Box.Checked;
            };
            IVCheck_Box.CheckedChanged += (_, __) =>
            {
                PIDECCheck_Box.Enabled = !IVCheck_Box.Checked;
            };
            this.MinIV_Box.DataSource =DIV;
           
            this.MinIV_Box.SelectedIndexChanged += (_, __) =>
            {
                MinIV = int.Parse(MinIV_Box.SelectedItem.ToString());
            };
            Gender_Box.DisplayMember = "Description";
            Gender_Box.ValueMember = "Value";
            Gender_Box.DataSource = Enum.GetValues(typeof(Gender))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            this.Gender_Box.SelectedIndexChanged += (_, __) =>
            {
                G = (Gender)Enum.Parse(typeof(Gender), this.Gender_Box.SelectedValue.ToString(), false);
            };
            Ability_Box.DisplayMember = "Description";
            Ability_Box.ValueMember = "Value";
            Ability_Box.DataSource = Enum.GetValues(typeof(Ability))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            this.Ability_Box.SelectedIndexChanged += (_, __) =>
            {
                A = (Ability)Enum.Parse(typeof(Ability), this.Ability_Box.SelectedValue.ToString(), false);
            };
            CheckPID();
            Mod_ComboBox.SelectedIndex = 0;
        }
        private bool GenPkm(ref PKM pk,uint seed,byte form=0)
        {
            return ConditionForm.rules.Method switch
            {
                MethodType.None=>NoMethod.GenPkm(ref pk, ConditionForm.rules),
                MethodType.Method1 => Method1RNG.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.Method1_Unown=> UnownRNG.GenPkm(ref pk,1, seed, ConditionForm.rules, form),
                MethodType.Method2 => Method2RNG.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.Method2_Unown => UnownRNG.GenPkm(ref pk, 2, seed, ConditionForm.rules, form),
                MethodType.Method3=>Method3RNG.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.Method3_Unown => UnownRNG.GenPkm(ref pk, 3, seed, ConditionForm.rules, form),
                MethodType.Method4 => Method4RNG.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.Method4_Unown => UnownRNG.GenPkm(ref pk, 4, seed, ConditionForm.rules, form),
                MethodType.XDColo => XDColoRNG.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.Overworld8 => Overworld8RNG.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.Roaming8b => Roaming8bRNG.GenPkm(ref pk, seed,  ConditionForm.rules),
                MethodType.BACD_R => BACD.GenPkm(ref pk, seed & 0xFFFF, ConditionForm.rules,0),
                MethodType.BACD_U => BACD.GenPkm(ref pk, seed , ConditionForm.rules,1),
                MethodType.BACD_R_S => BACD.GenPkm(ref pk, seed & 0xFFFF, ConditionForm.rules, 2),
                MethodType.Method1Roaming => Method1Roaming.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.Colo => ColoRNG.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.E_Reader => E_Reader.GenPkm(ref pk, seed, ConditionForm.rules),
                MethodType.ChainShiny => ChainShiny.GenPkm(ref pk, seed, ConditionForm.rules),
                _ => throw new NotSupportedException(),
            };
        }
        private uint NextSeed(uint seed)
        {
            return ConditionForm.rules.Method switch
            {
                MethodType.Method1 => Method1RNG.Next(seed),
                MethodType.Method1_Unown=> UnownRNG.Next(seed),
                MethodType.Method2 => Method2RNG.Next(seed),
                MethodType.Method2_Unown => UnownRNG.Next(seed),
                MethodType.Method3 => Method3RNG.Next(seed),
                MethodType.Method3_Unown => UnownRNG.Next(seed),
                MethodType.Method4 => Method4RNG.Next(seed),
                MethodType.Method4_Unown => UnownRNG.Next(seed),
                MethodType.XDColo => XDColoRNG.Next(seed),
                MethodType.Overworld8 => Overworld8RNG.Next(seed),
                MethodType.Roaming8b => Roaming8bRNG.Next(seed),
                MethodType.BACD_R => BACD.Next(seed),
                MethodType.BACD_U => BACD.Next(seed),
                MethodType.BACD_R_S => BACD.Next(seed),
                MethodType.Method1Roaming => Method1Roaming.Next(seed),
                MethodType.Colo => ColoRNG.Next(seed),
                MethodType.E_Reader =>E_Reader.Next(seed),
                MethodType.ChainShiny => ChainShiny.Next(seed),
                _ => throw new NotSupportedException(),
            };
        }
        private void GeneratorIsRunning(bool running)
        {
            Search.Enabled = !running;
            Cancel.Enabled = running;
        }
        private void CheckerIsRunning(bool running)
        {
            Check_BTN.Enabled = !running;
        }
        private void Search_Click(object sender, EventArgs e)
        {
            GeneratorIsRunning(true);
            ConditionForm.ConditionBox.Text = "searching...";
            uint seed = 0;
            int i = 0;
            List<uint> SeedList = new List<uint>();
            if (UsePreSeed.Checked == true)
            {
                SeedList = CheckRules.PreSetSeed(ConditionForm.rules);
                MessageBox.Show($"预设种子数量:{SeedList.Count}");
            }
            tokenSource1 = new();
            if (UsePreSeed.Checked == true)
            {
                SeedList = SeedList.OrderBy(a => rng.Next()).ToList();
            }
            Task.Factory.StartNew(
                () =>
                {
                    seed = Util.Rand32();
                    var cloneseed = seed;
                    var pk = Editor.Data;
                    var p = Editor.Data.Clone();
                 
                    while (true)
                    {
                        if (tokenSource1.IsCancellationRequested)
                        {
                            ConditionForm.ConditionBox.Text = "Stop";
                            return;
                        }

                        if (SeedList.Count != 0&&i<= SeedList.Count)
                        {
                            seed = SeedList[i];
                            i++;
                     
                        }
                        if (TeamLockBox.Checked==true)
                        {
                            if (LockCheck.ChooseLock(pk.Species, p, ref seed)==false)
                            {
                                cloneseed = NextSeed(cloneseed);
                                seed = cloneseed;
                                continue;
                            }
                        }
                        if (GenPkm(ref pk, seed,p.Form))
                            {
                           // MessageBox.Show($"Success！");
                            this.Invoke(() =>
                                {
                                    MessageBox.Show($"Success！");
                                    Editor.PopulateFields(pk, false);
                                    SAV.ReloadSlots();
                                    ConditionForm.SeedBox.Text = $"{Convert.ToString(seed, 16)}";
                                });
                                break;
                            }
                        seed = NextSeed(seed);
                    }
                    this.Invoke(() =>
                    {
                        GeneratorIsRunning(false);
                        ConditionForm.ConditionBox.Text = "无事可做";
                    });
                },
                tokenSource1.Token);
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            tokenSource1.Cancel();
            GeneratorIsRunning(false);
        }
        private void Check_BTN_Click(object sender, EventArgs e)
        {
        string T = "";
        CheckerIsRunning(true);
        Legal_Check_BOX1.Text = "正在检测基本合法性";
        Legal_Check_BOX2.Text = "正在反推Seed";
        Legal_Check_BOX3.Text = "正在检测PID/EC/IV";
        Legal_Check_BOX4.Text = "正在检测特性，性别";
        Legal_Check_BOX5.Text = "正在检测身高体重";
        tokenSource2 = new();
        var la = new LegalityAnalysis(Editor.Data);
        Task.Factory.StartNew(
            () =>
            {
                uint ec = Editor.Data.EncryptionConstant;
                uint pid = Editor.Data.PID;
                int[] ivs = { Editor.Data.IV_HP, Editor.Data.IV_ATK, Editor.Data.IV_DEF, Editor.Data.IV_SPA, Editor.Data.IV_SPD, Editor.Data.IV_SPE };
                var seeds = Z3Search.GetSeeds(ec, pid, ivs);
                #region
                /*  if (la.Valid == true && Strong_Box.Checked==true)
                    {
                        Legal_Check_BOX1.Text = "基本合法性检测通过！";
                        Legal_Check_BOX1.BackColor = Color.Green;
                        var t = la.EncounterOriginal;
                        int r = t.Location;
                        if (r is 162 or 244)
                        {
                            P(pid, ivs, ec);
                        }
                    }*/
                #endregion//枚举
                if (la.Valid == true)
                {
                    Legal_Check_BOX1.Text = "合法性检测通过！";
                    Legal_Check_BOX1.BackColor = Color.Green;
                    var t=la.EncounterOriginal;
                    int r=t.Location;
                    if (r is 162 or 244)
                    {
                        if (Gen8DenMax.FindFirstSeed(seeds, ivs) == "没找到Seed")
                        {
                            Legal_Check_BOX2.Text = "逆推失败!没找到Seed";
                            Legal_Check_BOX2.BackColor = Color.Red;
                            Legal_Check_BOX3.Text = "无法检测PID/EC/IV";
                            Legal_Check_BOX3.BackColor = Color.Red;
                            Legal_Check_BOX4.Text = "无法检测性格性别";
                            Legal_Check_BOX4.BackColor = Color.Red;
                            Legal_Check_BOX5.Text = "无法检测身高体重";
                            Legal_Check_BOX5.BackColor = Color.Red;
                        }
                        else
                        {
                            Legal_Check_BOX2.Text = "逆推成功!";
                            Legal_Check_BOX2.BackColor = Color.Green;
                            Seed_Box.Text = Gen8DenMax.FindFirstSeed(seeds, ivs);
                            T = Gen8DenMax.Raidfinder(Seed_Box.Text, Editor.Data, MinIV, A, G);
                            var S = T.Split('\n');
                            if(S.Count()!=0)
                            {
                                Legal_Check_BOX3.Text = S[0];
                                if (S[1]=="Green")
                                    Legal_Check_BOX3.BackColor = Color.Green;
                                else if (S[1]=="Orange")
                                    Legal_Check_BOX3.BackColor = Color.Orange;
                                Legal_Check_BOX4.Text = S[2];
                                if (S[3] == "Green")
                                    Legal_Check_BOX4.BackColor = Color.Green;
                                else if (S[3] == "Orange")
                                    Legal_Check_BOX4.BackColor = Color.Orange;
                                Legal_Check_BOX5.Text = S[4];
                                if (S[5] == "Green")
                                    Legal_Check_BOX5.BackColor = Color.Green;
                                else if (S[5] == "Orange")
                                    Legal_Check_BOX5.BackColor = Color.Orange;
                            }
                        }
                    }
                    else
                    {
                        Legal_Check_BOX1.Text = "基本合法性检测通过！";
                        Legal_Check_BOX1.BackColor = Color.Green;
                        Legal_Check_BOX2.Text = "无需寻找Seed";
                        Legal_Check_BOX2.BackColor = Color.Green;
                        Legal_Check_BOX3.Text = "无需检测PID/EC/IV";
                        Legal_Check_BOX3.BackColor = Color.Green;
                        Legal_Check_BOX4.Text = "无需检测性格性别";
                        Legal_Check_BOX4.BackColor = Color.Green;
                        Legal_Check_BOX5.Text = "无需检测身高体重";
                        Legal_Check_BOX5.BackColor = Color.Green;
                    }
                }
                else 
                {
                    Legal_Check_BOX1.Text = "基本合法性检测未通过！";
                    Legal_Check_BOX1.BackColor = Color.Red;
                    Legal_Check_BOX2.Text = "无事可做";
                    Legal_Check_BOX3.Text = "无事可做";
                    Legal_Check_BOX4.Text = "无事可做";
                    Legal_Check_BOX5.Text = "无事可做";
                }
                this.Invoke(() =>
                {
                    CheckerIsRunning(false);
                });
            },
            tokenSource2.Token);
        }
        private void GetSeedForMaxLair_BTN_Click(object sender, EventArgs e)
        {
            var pk=Editor.Data;
            var encounters = EncounterMovesetGenerator.GenerateEncounters(pk,SAV.SAV, pk.Moves);
            foreach (var enc in encounters)
            {
                if (pk.Generation == 8 && pk.Met_Location== 244)
                {
                    FindNestPIDIV.PreSetPIDIV(pk, enc);
                    break;
                }
            }
            Editor.PopulateFields(pk);
        }
        private void ReverseCheck_BTN_Click(object sender, EventArgs e)
        {
            Span<uint> Seeds= stackalloc uint[6];
            var S = Seeds.ToArray();
            uint EC = 0;
            uint PID = 0;
            uint hp=0;
            uint atk=0;
            uint def=0;
            uint spa=0;
            uint spd=0;
            uint spe=0;
            Span<string> s = new();
            var PIDHEX = "0x" + PIDBox.Text;
            var IVString = IVTextBox.Text;
            if (IVString.Length != 0)
            {
                s = IVString.Split(',');
                hp = Convert.ToUInt16(s[0]);
                atk = Convert.ToUInt16(s[1]);
                def = Convert.ToUInt16(s[2]);
                spa = Convert.ToUInt16(s[3]);
                spd = Convert.ToUInt16(s[4]);
                spe = Convert.ToUInt16(s[5]);

            }
            if (PIDHEX != "0x")
                PID = Convert.ToUInt32(PIDHEX, 16);
            var ECHEX = "0x" + ECBox.Text;
            if(ECHEX!="0x")
            EC = Convert.ToUInt32(ECHEX, 16);
            uint seed = 0;
            if (PIDECCheck_Box.Checked)
            {
                switch (MD.Value)
                {
                    case "M124":
                        {
                            LCRNGReversal.GetSeeds(Seeds, PID);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            break;
                        }
                    case "M3":
                        {
                            LCRNGReversalSkip.GetSeeds(Seeds, PID);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            break;
                        }
                    case "M124U":
                        {
                            LCRNGReversal.GetSeeds(Seeds, PID,true);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            break;
                        }
                    case "M3U":
                        {
                            LCRNGReversalSkip.GetSeeds(Seeds, PID, true);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            break;
                        }
                    case "XDColo":
                        {
                            XDRNGReversal.GetSeeds(Seeds, PID);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            for (int i = 0; i < S.Length; i++)
                            {
                                S[i] = XDRNG.Prev3(S[i]);
                            }
                            break;
                        }
                    case "Overworld8":
                        {
                            seed = Overworld8Reversal.GetOriginalSeed(EC, PID);   
                            break;
                        }
                }
                
            }
            if (IVCheck_Box.Checked)
            {
                switch (MD.Value)
                {
                    case "M1":
                        {
                            LCRNGReversal.GetSeedsIVs(Seeds, hp, atk, def, spa, spd, spe);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            for(int i=0;i< S.Length;i++)
                            {
                                S[i]= LCRNG.Prev2(S[i]);
                            }
                            break;
                        }
                    case "M23":
                        {
                            LCRNGReversal.GetSeedsIVs(Seeds, hp, atk, def, spa, spd, spe);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            for (int i = 0; i < S.Length; i++)
                            {
                                S[i] = LCRNG.Prev3(S[i]);
                            }
                            break;
                        }
                    case "M4":
                        {
                            LCRNGReversalSkip.GetSeedsIVs(Seeds, hp, atk, def, spa, spd, spe);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            for (int i = 0; i < S.Length; i++)
                            {
                                S[i] = LCRNG.Prev3(S[i]);
                            }
                            break;
                        }
                    case "XDColo":
                        {
                            XDRNGReversal.GetSeeds(Seeds, hp, atk, def, spa, spd, spe);
                            S = Seeds.ToArray();
                            S = S.Where(val => val != 0).ToArray();
                            break;
                        }
                }
            }
            if (Seeds.Length != 0){
                SeedBox.Text = PrintSeed(S,seed);
            }
        }
        private string PrintSeed(uint[] seeds,uint seed=0)
        {
            string result="";
            if (seeds.Length != 0&&MD.Value!="Overworld8")
            {
                for (int i = 0; i < seeds.Length; i++)
                {
                    result += seeds[i].ToString("X")+'\n';
                }
            }
            else if(seed!=0&&MD.Value == "Overworld8")
            {
                result = seed.ToString("X");
            }
            return result;
        }
        private void PIDECCheck_Box_CheckedChanged(object sender, EventArgs e)
        {
            if (PIDECCheck_Box.Checked){
                CheckPID();
            }
            else{
                CheckPID();
            }
         }
        private void IVCheck_Box_CheckedChanged(object sender, EventArgs e)
        {
            if (IVCheck_Box.Checked){
                CheckIV();
            }
            else{
                CheckPID();
            }
            
        }
        public void CheckPID()
        {
            L = RNGModClass.RNGModList(false);
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = L;
            Mod_ComboBox.DataSource = bindingSource1.DataSource;
            Mod_ComboBox.DisplayMember = "Name";
            Mod_ComboBox.ValueMember = "Value";
            this.Mod_ComboBox.SelectedIndexChanged += (_, __) =>
            {
                MD = (RNGModClass)this.Mod_ComboBox.SelectedItem;
                if(MD.Value=="Overworld8")
                {
                    ECBox.Enabled = true;
                }
                else
                    ECBox.Enabled = false;
            };
            IVTextBox.Enabled = false;
            PIDBox.Enabled = true;
        }
        public void CheckIV()
        {
            L = RNGModClass.RNGModList(true);
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = L;
            Mod_ComboBox.DataSource = bindingSource1.DataSource;
            Mod_ComboBox.DisplayMember = "Name";
            Mod_ComboBox.ValueMember = "Value";
            this.Mod_ComboBox.SelectedIndexChanged += (_, __) =>
            {
                MD = (RNGModClass)this.Mod_ComboBox.SelectedItem;
                ECBox.Enabled = false;
            };
            IVTextBox.Enabled = true;
            PIDBox.Enabled = false;
        }   
            #region
            /*    public void P(uint pid,int[] ivs,uint ec)
                {
                    var pidH = pid >> 16;
                    uint pidR = 0;

                    ParallelOptions po = new ParallelOptions();
                    po.MaxDegreeOfParallelism = 2;
                    po.CancellationToken = cts.Token;
                    CTRIsRunning(true);
                    Task.Factory.StartNew(
                      () =>
                      {
                          ParallelLoopResult result = Parallel.For(0, 0xffff, po, (i, state) =>
                        {
                            pidR = pidH << 16 | (uint)i;
                            var seeds = Z3Search.GetSeeds(ec, pidR, ivs);
                            if (FindFirstSeed(seeds, ivs) != "没找到Seed")
                            {
                                MessageBox.Show($"{pidR:X2}");
                                Legal_Check_BOX2.Text = "逆推成功!";
                                Legal_Check_BOX2.BackColor = Color.Green;
                                Seed_Box.Text = FindFirstSeed(seeds, ivs);
                                Raidfinder(FindFirstSeed(seeds, ivs));
                                state.Stop();
                            }
                        });
                      });

                }


                private void Stop_Check_BTN_Click(object sender, EventArgs e)
                {
                    cts.Cancel();
                    Legal_Check_BOX1.Text = "无事可做";
                    Legal_Check_BOX1.BackColor = Color.White;
                    Legal_Check_BOX2.Text = "无事可做";
                    Legal_Check_BOX2.BackColor = Color.White;
                    Legal_Check_BOX3.Text = "无事可做";
                    Legal_Check_BOX3.BackColor = Color.White;
                    Legal_Check_BOX4.Text = "无事可做";
                    Legal_Check_BOX4.BackColor = Color.White;
                    Legal_Check_BOX5.Text = "无事可做";
                    Legal_Check_BOX5.BackColor = Color.White;
                    CTRIsRunning(false);
                }
            */
            #endregion
            //枚举
        }
}
