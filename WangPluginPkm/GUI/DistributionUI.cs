using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using PKHeX.Core;
using System.Windows.Forms;
using System.ComponentModel;
namespace WangPluginPkm.GUI
{
    partial class DistributionUI:Form
    {
        private const string TrainerFilter = "Trainer Info |*.txt|All Files|*.*";
        private IVEVN V = IVEVN.ATK;
        private CLONE C = CLONE.BOX;
        private TRAINER T = TRAINER.BOX;
        public enum Nature
        {
            Hardy,Lonely,Brave,Adamant,Naughty,Bold,Docile,Relaxed,
            Impish,Lax,Timid,Hasty,Serious,Jolly,Naive,Modest,
            Mild,Quiet,Bashful,Rash,Calm,Gentle,Sassy,Careful,Quirky,
        }
        public enum Ball
        {
            None = 0,
            Master = 1,
            Ultra = 2,
            Great = 3,
            Poke = 4,
            Safari = 5,
            Net = 6,
            Dive = 7,
            Nest = 8,
            Repeat = 9,
            Timer = 10,
            Luxury = 11,
            Premier = 12,
            Dusk = 13,
            Heal = 14,
            Quick = 15,
            Cherish = 16,
            Fast = 17,
            Level = 18,
            Lure = 19,
            Heavy = 20,
            Love = 21,
            Friend = 22,
            Moon = 23,
            Sport = 24,
            Dream = 25,
            Beast = 26,
        }
        public enum IVEVN
        {
            [Description("物攻")]
            ATK,
            [Description("特攻")]
            SPA,
            [Description("0速物攻")]
            Z_ATK,
            [Description("0速特攻")]
            Z_SPA,
            [Description("肉盾")]
            TANK,

        }
        public enum CLONE 
        {
            [Description("复制一箱")]
            BOX,
            [Description("竖向复制5只")]
            FIVE,
        }
        public enum TRAINER 
        {
            [Description("覆盖一箱")]
            BOX,
            [Description("覆盖面板")]
            EDITER,
        }
        public Nature Ntype = Nature.Hardy;
        public Ball TBall = Ball.Poke;
        public Trainer Trainer;
        private static Random rand = new();
        public int number=0;

        public BindingList<Trainer> Tr=new();
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        public DistributionUI(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            BindingData();
        }
        
        private void BindingData()
        {
            string[] lines = Properties.Resources.Trainers.Split('\n') ;
            foreach (string line in lines)
            {
                Tr.Add(Trainer.ConvertToTrainer(line));
            }
            if (Tr.Count != 0)
                Trainer = Tr[0];
            BallBox.DataSource = Enum.GetNames(typeof(Ball));
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = Tr;
            Trainer_Box.DataSource = bindingSource1.DataSource;
            Trainer_Box.DisplayMember = "OT_Name";
            Trainer_Box.ValueMember = "Tid";
       
            BallBox.SelectedIndexChanged += (_, __) =>
            {
                TBall = (Ball)Enum.Parse(typeof(Ball), this.BallBox.SelectedItem.ToString(), false);
            };
            Trainer_Box.SelectedIndexChanged += (_, __) =>
            {
                Trainer =(Trainer) this.Trainer_Box.SelectedItem;
            };
            BallBox.SelectedIndex = 0;
            Edit_EVIVN_Box.DisplayMember = "Description";
            Edit_EVIVN_Box.ValueMember = "Value";
            Edit_EVIVN_Box.DataSource = Enum.GetValues(typeof(IVEVN))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            this.Edit_EVIVN_Box.SelectedIndexChanged += (_, __) =>
            {
                V = (IVEVN)Enum.Parse(typeof(IVEVN), this.Edit_EVIVN_Box.SelectedValue.ToString(), false);
            };
            this.Edit_EVIVN_Box.SelectedIndex = 0;

            this.Clone_Select_Box.DisplayMember = "Description";
            this.Clone_Select_Box.ValueMember = "Value";
            this.Clone_Select_Box.DataSource = Enum.GetValues(typeof(CLONE))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            this.Clone_Select_Box.SelectedIndexChanged += (_, __) =>
            {
                C = (CLONE)Enum.Parse(typeof(CLONE), this.Clone_Select_Box.SelectedValue.ToString(), false);
            };
            this.Clone_Select_Box.SelectedIndex = 0;

            this.Trainer_Select_Box.DisplayMember = "Description";
            this.Trainer_Select_Box.ValueMember = "Value";
            this.Trainer_Select_Box.DataSource = Enum.GetValues(typeof(TRAINER))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            this.Trainer_Select_Box.SelectedIndexChanged += (_, __) =>
            {
                T = (TRAINER)Enum.Parse(typeof(TRAINER), this.Trainer_Select_Box.SelectedValue.ToString(), false);
            };
            this.Trainer_Select_Box.SelectedIndex = 0;
            SetTrainer_Box.CheckedChanged+= (_, __) =>
            {
               
                    Random_Trainer_Box.Enabled = !SetTrainer_Box.Checked;
                
            };
            Random_Trainer_Box.CheckedChanged += (_, __) =>
            {
                
                    SetTrainer_Box.Enabled = !Random_Trainer_Box.Checked;
                
            };
           
        }
        private void LoadEH1_BTN_Click(object sender, EventArgs e)
        {
            List<PKM> PK = new();
            var i = 0;
            DialogResult dr = this.OpenFile_Dialog.ShowDialog();
            int BOX=Int16.Parse(BOX_TextBox.Text)-1;
            if (dr == DialogResult.OK)
            {
                foreach (String file in OpenFile_Dialog.FileNames)
                {
                    ConvertPKM(file, OpenFile_Dialog.FileNames.Length, ref PK);
                    i++;
                    if (i == OpenFile_Dialog.SafeFileNames.Length)
                    {
                        break;
                    }
                }
                MessageBox.Show($"选取了{PK.Count}只宝可梦");
                for (i = 0; i < PK.Count; i++)
                {
                    SAV.SAV.SetBoxSlotAtIndex(PK[i], BOX, i);
                    SAV.ReloadSlots();
                }
            }
        }
        private void ConvertPKM(string file,int n,ref List<PKM> p)
        {
            var data = File.ReadAllBytes(file);
            PKM pk;
           
            var pkh = DecryptEH1(data);
            if (SAV.SAV.Version is GameVersion.SH or GameVersion.SW)
            {
                pk = pkh.ConvertToPK8();
                p.Add(pk);
                
            }
            else if (SAV.SAV.Version is GameVersion.PLA)
            {
                pk = pkh.ConvertToPA8();
                p.Add(pk);
            }
            else if (SAV.SAV.Version is GameVersion.BD or GameVersion.SP)
            {
                pk = pkh.ConvertToPB8();
                p.Add(pk);
            }
            else
                MessageBox.Show("ERROR");

        }
        private PKH DecryptEH1(byte[] ek1)
        {
            if (ek1 != null)
            {
                if (HomeCrypto.GetIsEncrypted1(ek1))
                    return new PKH(ek1);
            }
            return null;
        }
        public static string RandomString(int length)
        {
            const string chars = "赵钱孙李周吴正旺小鱼儿新子颜缘分振哥毅力建国云宗光辉老查丽鱼安娜牛";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }
        public void SetPkm(ISaveFileProvider SaveFileEditor)
        {
            List<PKM> PKL = new();
            for (int i = 0; i <30; i++)
            {
                var pk = Editor.Data.Clone();
                pk.StatNature = Editor.Data.StatNature;
                pk.Move1_PPUps = Editor.Data.Move1_PPUps;
                pk.Move2_PPUps = Editor.Data.Move2_PPUps;
                pk.Move3_PPUps = Editor.Data.Move3_PPUps;
                pk.Move4_PPUps = Editor.Data.Move4_PPUps;
                if (SetTrainer_Box.Checked)
                {
                    pk.OT_Name = Trainer.OT_Name;
                    pk.OT_Gender = Trainer.Gender;
                    pk.TrainerID7 = Trainer.Tid;
                    pk.TrainerSID7 = Trainer.Sid;
                    pk.Language = Trainer.Language;
                    pk.ClearNickname();
                }
                else if(Random_Trainer_Box.Checked)
                {
                    var T = RandomT(Tr,i);
                    pk.OT_Name = T.OT_Name;
                    pk.OT_Gender = T.Gender;
                    pk.TrainerID7 = T.Tid;
                    pk.TrainerSID7 = T.Sid;
                    pk.Language = T.Language;
                    pk.ClearNickname();

                }
               else if(Random_Name_Box.Checked)
                {
                    pk.OT_Name = RandomString(3);
                    pk.OT_Gender = rand.Next(0, 2);
                    pk.TID = rand.Next(65535);
                    pk.SID = rand.Next(65535);
                    pk.Language = 9;
                    pk.ClearNickname();
                }
                pk.StatNature = pk.Nature;
                if (Ball_Box.Checked)
                {
                    pk.Ball = (int)TBall;
                }
                if (RandPID_Box.Checked)
                {
                    pk.PID = rand.Rand32();
                    
                }
                if(RandEC_Box.Checked)
                {
                    pk.SetRandomEC();
                }
                if (ShinyBox.Checked)
                    pk.PID = Shiny(pk);
          
                PKL.Add(pk);
            }
            var BoxData = SAV.SAV.BoxData;
            IList<PKM> arr2 = BoxData;
            List<int> list = FindAllEmptySlots(arr2, 0);
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    int index = list[i];
                    SAV.SAV.SetBoxSlotAtIndex(PKL[i], index);
                }
            }
            SaveFileEditor.ReloadSlots();
        }
        private void SetFivePKM(ISaveFileProvider SaveFileEditor)
        {

            List<PKM> PKL = new();
            for (int i = 0; i < 5; i++)
            {
                var pk = Editor.Data.Clone();
                pk.StatNature = Editor.Data.StatNature;
                pk.Move1_PPUps = Editor.Data.Move1_PPUps;
                pk.Move2_PPUps = Editor.Data.Move2_PPUps;
                pk.Move3_PPUps = Editor.Data.Move3_PPUps;
                pk.Move4_PPUps = Editor.Data.Move4_PPUps;
                if (SetTrainer_Box.Checked)
                {
                    pk.OT_Name = Trainer.OT_Name;
                    pk.OT_Gender = Trainer.Gender;
                    pk.TrainerID7 = Trainer.Tid;
                    pk.TrainerSID7 = Trainer.Sid;
                    pk.Language = Trainer.Language;
                    pk.ClearNickname();
                }
                else if (Random_Trainer_Box.Checked)
                {
                    var T = RandomT(Tr, i);
                    pk.OT_Name = T.OT_Name;
                    pk.OT_Gender = T.Gender;
                    pk.TrainerID7 = T.Tid;
                    pk.TrainerSID7 = T.Sid;
                    pk.Language = T.Language;
                    pk.ClearNickname();

                }
             /*   else if (Random_Name_Box.Checked)
                {
                    pk.OT_Name = RandomString(3);
                    pk.OT_Gender = rand.Next(0, 2);
                    pk.TID = rand.Next(65535);
                    pk.SID = rand.Next(65535);
                    pk.Language = 9;
                    pk.ClearNickname();
                }*/
                if (RandPID_Box.Checked)
                {
                    pk.PID = Util.Rand32();
                }
                if (RandEC_Box.Checked)
                {
                    pk.SetRandomEC();
                }
                if (Editor.Data.IsShiny)
                {
                    pk.SetShiny();
                }
                PKL.Add(pk);
            }
            if (number > 5)
                number = 0;
            int n = SAV.CurrentBox;
            for (int i = 0; i < 5; i++)
            {
                SAV.SAV.SetBoxSlotAtIndex(PKL[i], n, i * 6 + number);
            }
            number++;
            SaveFileEditor.ReloadSlots();
        }
        public void SetGodPokemon(ISaveFileProvider SaveFileEditor)
        {
            List<PKM> PKL = new();
            List<SWSHGod> c = new(SWSHGod.CreateList());
            for (int i = 0; i < 30; i++)
            {
                int j = rand.Next(0, c.Count());
                var pk = SearchDatabase.GetGodPkm(SAV,Editor,c[j].Species);
                if (SetTrainer_Box.Checked)
                {
                    pk.OT_Name = Trainer.OT_Name;
                    pk.OT_Gender = Trainer.Gender;
                    pk.TrainerID7 = Trainer.Tid;
                    pk.TrainerSID7 = Trainer.Sid;
                    pk.Language = Trainer.Language;
                    pk.ClearNickname();

                }

                else if(Random_Trainer_Box.Checked)
                {
                    var T = RandomT(Tr,j);
                    pk.OT_Name = T.OT_Name;
                    pk.OT_Gender = T.Gender;
                    pk.TrainerID7 = T.Tid;
                    pk.TrainerSID7 = T.Sid;
                    pk.Language = T.Language;
                    pk.ClearNickname();

                }
             else if (Random_Name_Box.Checked)
                {
                    pk.OT_Name = RandomString(3);
                    pk.OT_Gender = rand.Next(0, 2);
                    pk.TID = rand.Next(65535);
                    pk.SID = rand.Next(65535);
                    pk.Language = 9;
                    pk.ClearNickname();
                }
                
                pk.IVs = c[j].IVs;
                pk.SetEVs(c[j].EVs);
                pk.Nature = c[j].Nature;
                pk.StatNature = pk.Nature;
                pk.Move1_PPUps = 3;
                pk.Move2_PPUps = 3;
                pk.Move3_PPUps = 3;
                pk.Move4_PPUps = 3;
                pk.HealPP();
                if (Ball_Box.Checked)
                {
                    pk.Ball = (int)TBall;
                }
                if (RandPID_Box.Checked)
                {
                    pk.PID = rand.Rand32();
                    pk.SetRandomEC();
                }
                if (ShinyBox.Checked)
                    pk.PID = Shiny(pk);
                c.RemoveAt(j);
                PKL.Add(pk);
            }
            var BoxData = SAV.SAV.BoxData;
            IList<PKM> arr2 = BoxData;
            List<int> list = FindAllEmptySlots(arr2, 0);
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    int index = list[i];
                    SAV.SAV.SetBoxSlotAtIndex(PKL[i], index);
                }
            }
            SaveFileEditor.ReloadSlots();
        }
        private static List<int> FindAllEmptySlots(IList<PKM> data, int start)
        {
            List<int> list = new List<int>();
            for (int i = start; i < data.Count; i++)
            {
                if (data[i].Species < 1)
                {
                    list.Add(i);
                }
            }
            return list;
        }
        private static uint Shiny(PKM pk)
        {
            return (((uint)(pk.TID ^ pk.SID) ^ (pk.PID & 0xFFFF) ^ 1) << 16) | (pk.PID & 0xFFFF);
        }
        private static Trainer RandomT(IList<Trainer> T,int i)
        {
            Random ra = new(unchecked((int)Util.Rand32())+i);
            int randIndex = ra.Next(0,T.Count);
            var RandomTrainer = T[randIndex];
            return RandomTrainer;
        }
        private void UseTrainer(PKM pk)
        {
            pk.OT_Name = Trainer.OT_Name;
            pk.TrainerID7 = Trainer.Tid;
            pk.TrainerSID7 = Trainer.Sid;
            pk.Language = Trainer.Language;
            pk.OT_Gender = Trainer.Gender;
            Editor.PopulateFields(pk);
        }
        private void Handle_MoveShop(PKM pk)
        {
            LegalityAnalysis la;

            for (int q = 0; q < 100; q++)
            {
                ((PK8)pk).SetMoveRecordFlag(q, true);
                la = new LegalityAnalysis(pk);
                if (!la.Valid)
                    ((PK8)pk).SetMoveRecordFlag(q, false);
            }
            SAV.ReloadSlots();
        }
        private void Level(PKM pk)
        {
            ((PK8)pk).DynamaxLevel = 10;
            pk.CurrentLevel = 100;
        }
        private void Allribbon(PKM pk)
        {
            RibbonApplicator.SetAllValidRibbons(pk);
        }
        private void Clone_BTN_Click(object sender, EventArgs e)
        {
            switch (C)
            {
               case CLONE.BOX:
                    SetPkm(SAV);
                    SAV.ReloadSlots();
                    break;
               case CLONE.FIVE:
                    SetFivePKM(SAV);
                    SAV.ReloadSlots();
                    break;
            }
        }
        private void Gift_BTN_Click(object sender, EventArgs e)
        {
            SetGodPokemon(SAV);
            SAV.ReloadSlots();
        }
        private void AllRibbon_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(Allribbon);
        }
        private void LoadTrainer_BTN_Click(object sender, EventArgs e)
        {
            Tr.Clear();
            using var sfd = new OpenFileDialog
            {
                Filter = TrainerFilter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            string path = sfd.FileName;
            string[] lines = File.ReadAllLines(path);
            foreach(string line in lines)
            {
               Tr.Add(Trainer.ConvertToTrainer(line));
            }
            if (Tr.Count != 0)
                Trainer = Tr[0];
         
        }
        private void Use_Trainer_BTN_Click(object sender, EventArgs e)
        {
            switch (T)
            {
            case TRAINER.BOX:
                PKM[] p;
                int i = SAV.CurrentBox;
                p = SAV.SAV.GetBoxData(i);
                if (p.Count() != 0)
                {
                    foreach (PKM pk in p)
                    {
                        pk.OT_Name = Trainer.OT_Name;
                        pk.TrainerID7 = Trainer.Tid;
                        pk.TrainerSID7 = Trainer.Sid;
                        pk.Language = Trainer.Language;
                        pk.OT_Gender = Trainer.Gender;
                        pk.ClearNickname();
                    }
                }
                SAV.SAV.SetBoxData(p, i);
                break;
            case TRAINER.EDITER:
                UseTrainer(Editor.Data);
                break;
            }
        }
        private void IVEVN_BTN_Click(object sender, EventArgs e)
        {
            switch (V)
            {
                case IVEVN.ATK:
                    CommonIVEVSetting.ATKIVEV(Editor.Data, Editor);
                    break;
                case IVEVN.SPA:
                    CommonIVEVSetting.SPAIVEV(Editor.Data, Editor);
                    break;
                case IVEVN.Z_ATK:
                    CommonIVEVSetting.ATK_0SPEIVEV(Editor.Data, Editor);
                    break;
                case IVEVN.Z_SPA:
                    CommonIVEVSetting.SPA_0SPEIVEV(Editor.Data, Editor);
                    break;
                case IVEVN.TANK:
                    CommonIVEVSetting.TANKIVEV(Editor.Data, Editor);
                    break;
            }
        }
        private void Move_Shop_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(Handle_MoveShop);
        }
        private void LevelMax_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(Level);
        }
        private void Language_BTN_Click(object sender, EventArgs e)
        {
            PKM pk;
            List<PKM> L = new();
            for (int i = 1; i < 6; i++)
            {
                pk = SearchDatabase.MytheryLanguage(SAV, Editor.Data.Species, Editor.Data.Generation , 0, i);
                L.Add(pk);
            }
           for(int i=7;i<11;i++)
            {
                pk = SearchDatabase.MytheryLanguage(SAV, Editor.Data.Species, Editor.Data.Generation, 0, i);
                L.Add(pk);
            }
            var BoxData = SAV.SAV.BoxData;
            IList<PKM> arr2 = BoxData;
            List<int> list = FindAllEmptySlots(arr2, 0);
            if (L.Count != 0)
            {
                for (int i = 0; i < L.Count; i++)
                {
                    int index = list[i];
                    SAV.SAV.SetBoxSlotAtIndex(L[i], index);
                }
            }
            SAV.ReloadSlots();
        }
        
        #region
        /* public void MytheryPK(PKM pk)
         {
             var db = EncounterEvent.GetAllEvents();
             var RawDB = new List<MysteryGift>(db);
             int i = 0;
             PKM pkc;
             List<PKM> p = new();
             int species = pk.Species;
             IEnumerable<MysteryGift> res = RawDB;
             if (species != -1) res = res.Where(pkm => pkm.Species == species);
             res = res.Where(pkm => pkm.IsShiny == true);
             // res = res.Where(pkm => pkm.Form == 1);
             var results = res.ToArray();
             if (results.Count() != 0)
             {
                 foreach (MysteryGift gift in results)
                 {

                     pkc = gift.ConvertToPKM(SAV.SAV);
                     EntityConverter.TryMakePKMCompatible(pkc, pk, out var c, out pkc);
                       if (UseIVNature_BOX.Checked)
                       {
                           pkc.IV_HP = Convert.ToInt32(IVHPBox.Text);
                           pkc.IV_ATK = Convert.ToInt32(IVATKBox.Text);
                           pkc.IV_DEF = Convert.ToInt32(IVDEFBox.Text);
                           pkc.IV_SPA = Convert.ToInt32(IVSPABox.Text);
                           pkc.IV_SPD = Convert.ToInt32(IVSPDBox.Text);
                           pkc.IV_SPE = Convert.ToInt32(IVSPEBox.Text);
                           pkc.EV_HP = Convert.ToInt32(EVHPBox.Text);
                           pkc.EV_ATK = Convert.ToInt32(EVATKBox.Text);
                           pkc.EV_DEF = Convert.ToInt32(EVDEFBox.Text);
                           pkc.EV_SPA = Convert.ToInt32(EVSPABox.Text);
                           pkc.EV_SPD = Convert.ToInt32(EVSPDBox.Text);
                           pkc.EV_SPE = Convert.ToInt32(EVSPEBox.Text);
                           switch (Ntype)
                           {
                               case Nature.Hardy:
                                   pk.Nature = 0;
                                   break;
                               case Nature.Lonely:
                                   pk.Nature = 1;
                                   break;
                               case Nature.Brave:
                                   pk.Nature = 2;
                                   break;
                               case Nature.Adamant:
                                   pk.Nature = 3;
                                   break;
                               case Nature.Naughty:
                                   pk.Nature = 4;
                                   break;
                               case Nature.Bold:
                                   pk.Nature = 5;
                                   break;
                               case Nature.Docile:
                                   pk.Nature = 6;
                                   break;
                               case Nature.Relaxed:
                                   pk.Nature = 7;
                                   break;
                               case Nature.Impish:
                                   pk.Nature = 8;
                                   break;
                               case Nature.Lax:
                                   pk.Nature = 9;
                                   break;
                               case Nature.Timid:
                                   pk.Nature = 10;
                                   break;
                               case Nature.Hasty:
                                   pk.Nature = 11;
                                   break;
                               case Nature.Serious:
                                   pk.Nature = 12;
                                   break;
                               case Nature.Jolly:
                                   pk.Nature = 13;
                                   break;
                               case Nature.Naive:
                                   pk.Nature = 14;
                                   break;
                               case Nature.Modest:
                                   pk.Nature = 15;
                                   break;
                               case Nature.Mild:
                                   pk.Nature = 16;
                                   break;
                               case Nature.Quiet:
                                   pk.Nature = 17;
                                   break;
                               case Nature.Bashful:
                                   pk.Nature = 18;
                                   break;
                               case Nature.Rash:
                                   pk.Nature = 19;
                                   break;
                               case Nature.Calm:
                                   pk.Nature = 20;
                                   break;
                               case Nature.Gentle:
                                   pk.Nature = 21;
                                   break;
                               case Nature.Sassy:
                                   pk.Nature = 22;
                                   break;
                               case Nature.Careful:
                                   pk.Nature = 23;
                                   break;
                               case Nature.Quirky:
                                   pk.Nature = 24;
                                   break;
                           }
                           switch (Ntype)
                           {
                               case Nature.Hardy:
                                   pkc.Nature = 0;
                                   break;
                               case Nature.Lonely:
                                   pkc.Nature = 1;
                                   break;
                               case Nature.Brave:
                                   pkc.Nature = 2;
                                   break;
                               case Nature.Adamant:
                                   pkc.Nature = 3;
                                   break;
                               case Nature.Naughty:
                                   pkc.Nature = 4;
                                   break;
                               case Nature.Bold:
                                   pkc.Nature = 5;
                                   break;
                               case Nature.Docile:
                                   pkc.Nature = 6;
                                   break;
                               case Nature.Relaxed:
                                   pkc.Nature = 7;
                                   break;
                               case Nature.Impish:
                                   pkc.Nature = 8;
                                   break;
                               case Nature.Lax:
                                   pkc.Nature = 9;
                                   break;
                               case Nature.Timid:
                                   pkc.Nature = 10;
                                   break;
                               case Nature.Hasty:
                                   pkc.Nature = 11;
                                   break;
                               case Nature.Serious:
                                   pkc.Nature = 12;
                                   break;
                               case Nature.Jolly:
                                   pkc.Nature = 13;
                                   break;
                               case Nature.Naive:
                                   pkc.Nature = 14;
                                   break;
                               case Nature.Modest:
                                   pk.Nature = 15;
                                   break;
                               case Nature.Mild:
                                   pkc.Nature = 16;
                                   break;
                               case Nature.Quiet:
                                   pkc.Nature = 17;
                                   break;
                               case Nature.Bashful:
                                   pkc.Nature = 18;
                                   break;
                               case Nature.Rash:
                                   pkc.Nature = 19;
                                   break;
                               case Nature.Calm:
                                   pkc.Nature = 20;
                                   break;
                               case Nature.Gentle:
                                   pkc.Nature = 21;
                                   break;
                               case Nature.Sassy:
                                   pkc.Nature = 22;
                                   break;
                               case Nature.Careful:
                                   pkc.Nature = 23;
                                   break;
                               case Nature.Quirky:
                                   pkc.Nature = 24;
                                   break;
                           }

                     pkc.StatNature = pkc.Nature;

                     if (SetTrainer_Box.Checked)
                     {
                         i++;
                         var T = RandomT(Tr, i);
                         pkc.OT_Name = T.OT_Name;
                         pkc.OT_Gender = T.Gender;
                         pkc.TrainerID7 = T.Tid;
                         pkc.TrainerSID7 = T.Sid;
                         pkc.Language = T.Language;

                     }
                     p.Add(pkc);
                 }
             }
             MessageBox.Show($"{p.Count()}");
             var BoxData = SAV.SAV.BoxData;
             IList<PKM> arr2 = BoxData;
             List<int> list = FindAllEmptySlots(arr2, 0);
             for (int j = 0; j < p.Count; j++)
             {
                 int index = list[j];
                 SAV.SAV.SetBoxSlotAtIndex(p[j], index);

             }

         }*/
        #endregion


    }
}
