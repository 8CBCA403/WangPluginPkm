using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WangPluginPkm.PluginUtil.DisBase;
using static WangPluginPkm.PluginUtil.Functions.DistributionFunctions;
using static WangPluginPkm.PluginUtil.PluginEnums.GUIEnums;

namespace WangPluginPkm.GUI
{
    partial class DistributionUI : Form
    {
        private const string TrainerFilter = "Trainer Info |*.txt|All Files|*.*";
        private int Counter = 0;
        private int IVEVValue = 0;
        private int CloneValue = 0;
        private int TrainerValue = 0;
        private int Dis = 0;
        public Nature type = Nature.Hardy;
        public Ball ball = Ball.Poke;
        public Trainer Trainer;
        private static Random rand = new();
        public int number = 0;
        public BindingList<Trainer> Tr = new();
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
            string[] lines = Properties.Resources.Trainers.Split('\n');
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
            Trainer_Box.DisplayMember = "OriginalTrainerName";
            Trainer_Box.ValueMember = "TID16";

            BallBox.SelectedIndexChanged += (_, __) =>
            {
                ball = (Ball)Enum.Parse(typeof(Ball), this.BallBox.SelectedItem.ToString(), false);
            };
            Trainer_Box.SelectedIndexChanged += (_, __) =>
            {
                Trainer = (Trainer)this.Trainer_Box.SelectedItem;
            };

            Edit_EVIVN_Box.DataSource = Enum.GetValues(typeof(DisFormIVEV));
            Edit_EVIVN_Box.SelectedIndexChanged += (_, __) =>
            {
                IVEVValue = Edit_EVIVN_Box.SelectedIndex;
            };
            Clone_Select_Box.DataSource = Enum.GetValues(typeof(DisFormClone));
            Clone_Select_Box.SelectedIndexChanged += (_, __) =>
            {
                CloneValue = Clone_Select_Box.SelectedIndex;
            };
            Trainer_Select_Box.DataSource = Enum.GetValues(typeof(DisFormTrainer));

            Trainer_Select_Box.SelectedIndexChanged += (_, __) =>
            {
                TrainerValue = Trainer_Select_Box.SelectedIndex;
            };
            SetTrainer_Box.CheckedChanged += (_, __) =>
            {
                Random_Trainer_Box.Enabled = !SetTrainer_Box.Checked;
            };
            Random_Trainer_Box.CheckedChanged += (_, __) =>
            {
                SetTrainer_Box.Enabled = !Random_Trainer_Box.Checked;
            };
            DiscomboBox.DataSource = Enum.GetValues(typeof(DisCombo));
            DiscomboBox.SelectedIndexChanged += (_, __) =>
            {
                Dis = DiscomboBox.SelectedIndex;
            };

        }
        public void SetPkm()
        {
            List<PKM> PKL = new();
            for (int i = 0; i < 30; i++)
            {
                var pk = Editor.Data.Clone();
                pk.StatNature = Editor.Data.StatNature;
                pk.Move1_PPUps = Editor.Data.Move1_PPUps;
                pk.Move2_PPUps = Editor.Data.Move2_PPUps;
                pk.Move3_PPUps = Editor.Data.Move3_PPUps;
                pk.Move4_PPUps = Editor.Data.Move4_PPUps;
                if (SetTrainer_Box.Checked)
                {
                    pk.OriginalTrainerName = Trainer.OriginalTrainerName;
                    pk.OriginalTrainerGender = (byte)Trainer.Gender;
                    pk.DisplayTID = Trainer.TID16;
                    pk.DisplaySID = Trainer.SID16;
                    pk.Language = Trainer.Language;
                    pk.ClearNickname();
                }
                else if (Random_Trainer_Box.Checked)
                {
                    var T = RandomT(Tr, i);
                    pk.OriginalTrainerName = T.OriginalTrainerName;
                    pk.OriginalTrainerGender = (byte)T.Gender;
                    pk.DisplayTID = T.TID16;
                    pk.DisplaySID = T.SID16;
                    pk.Language = T.Language;
                    pk.ClearNickname();

                }
                else if (Random_Name_Box.Checked)
                {
                    pk.OriginalTrainerName = RandomString(3);
                    pk.OriginalTrainerGender = (byte)rand.Next(0, 2);
                    pk.TID16 = (ushort)rand.Next(1 << 16);
                    pk.SID16 = (ushort)rand.Next(1 << 16);
                    pk.Language = 9;
                    pk.ClearNickname();
                }
                pk.StatNature = pk.Nature;
                if (Ball_Box.Checked)
                {
                    pk.Ball = (byte)(int)ball;
                }
                if (RandPID_Box.Checked)
                {
                    pk.PID = rand.Rand32();

                }
                if (RandEC_Box.Checked)
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
            SAV.ReloadSlots();
        }
        private void SetFivePKM()
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
                    pk.OriginalTrainerName = Trainer.OriginalTrainerName;
                    pk.OriginalTrainerGender = (byte)Trainer.Gender;
                    pk.DisplayTID = Trainer.TID16;
                    pk.DisplaySID = Trainer.SID16;
                    pk.Language = Trainer.Language;
                    pk.ClearNickname();
                }
                else if (Random_Trainer_Box.Checked)
                {
                    var T = RandomT(Tr, i);
                    pk.OriginalTrainerName = T.OriginalTrainerName;
                    pk.OriginalTrainerGender = (byte)T.Gender;
                    pk.DisplayTID = T.TID16;
                    pk.DisplaySID = T.SID16;
                    pk.Language = T.Language;
                    pk.ClearNickname();

                }
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
            SAV.ReloadSlots();
        }
        public void SetGodPokemon()
        {
            List<PKM> PKL = new();
            List<SWSHGod> c = new(SWSHGod.CreateList());
            for (int i = 0; i < 30; i++)
            {
                int j = rand.Next(0, c.Count());
                var pk = SearchDatabase.GetGodPkm(SAV, Editor, c[j].Species);
                if (SetTrainer_Box.Checked)
                {
                    pk.OriginalTrainerName = Trainer.OriginalTrainerName;
                    pk.OriginalTrainerGender = (byte)Trainer.Gender;
                    pk.DisplayTID = Trainer.TID16;
                    pk.DisplaySID = Trainer.SID16;
                    pk.Language = Trainer.Language;
                    pk.ClearNickname();

                }

                else if (Random_Trainer_Box.Checked)
                {
                    var T = RandomT(Tr, j);
                    pk.OriginalTrainerName = T.OriginalTrainerName;
                    pk.OriginalTrainerGender = (byte)T.Gender;
                    pk.DisplayTID = T.TID16;
                    pk.DisplaySID = T.SID16;
                    pk.Language = T.Language;
                    pk.ClearNickname();

                }
                else if (Random_Name_Box.Checked)
                {
                    pk.OriginalTrainerName = RandomString(3);
                    pk.OriginalTrainerGender = (byte)rand.Next(0, 2);
                    pk.TID16 = (ushort)rand.Next(1 << 16);
                    pk.SID16 = (ushort)rand.Next(1 << 16);
                    pk.Language = 9;
                    pk.ClearNickname();
                }
                if (ShinyBox.Checked)
                {
                    pk.IVs = c[j].IVs;
                    pk.Nature = (Nature)c[j].Nature;
                    pk.StatNature = pk.Nature;
                }
                pk.StatNature = (Nature)c[j].Nature;
                pk.SetEVs(c[j].EVs);

                pk.Move1_PPUps = 3;
                pk.Move2_PPUps = 3;
                pk.Move3_PPUps = 3;
                pk.Move4_PPUps = 3;
                pk.HealPP();
                if (Ball_Box.Checked)
                {
                    pk.Ball = (byte)ball;
                }
                if (RandPID_Box.Checked && ShinyBox.Checked)
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
            SAV.ReloadSlots();
        }
        private static Trainer RandomT(IList<Trainer> T, int i)
        {
            Random ra = new(unchecked((int)Util.Rand32()) + i);
            int randIndex = ra.Next(0, T.Count);
            var RandomTrainer = T[randIndex];
            return RandomTrainer;
        }
        private void UseTrainer(PKM pk)
        {
            pk.OriginalTrainerName = Trainer.OriginalTrainerName;
            pk.DisplayTID = Trainer.TID16;
            pk.DisplaySID = Trainer.SID16;
            pk.Language = Trainer.Language;
            pk.OriginalTrainerGender = (byte)Trainer.Gender;
            Editor.PopulateFields(pk);
        }
        private void Handle_MoveShop(PKM pk)
        {
            LegalityAnalysis la;
            if (SAV.SAV.Generation == 8)
            {

                for (int q = 0; q < 100; q++)
                {
                    ((PK8)pk).SetMoveRecordFlag(q, true);
                    la = new LegalityAnalysis(pk);
                    if (!la.Valid)
                        ((PK8)pk).SetMoveRecordFlag(q, false);
                }
            }
            else if (SAV.SAV.Generation == 9)
            {
                if (pk is ITechRecord t)
                {
                    t.SetRecordFlagsAll();
                }
            }
            SAV.ReloadSlots();
        }
        private void Level(PKM pk)
        {
            if (SAV.SAV.Version is GameVersion.SH or GameVersion.SW or GameVersion.SWSH)
            {
                ((PK8)pk).DynamaxLevel = 10;
            }
            pk.CurrentLevel = 100;
        }
        private void EC(PKM pk)
        {
            if (pk.Species is not 946 or 917 or 998 or 999 or 996 or 997 or 995 or 997)
            {
                if (pk.MetLocation != 30024)
                    pk.SetRandomEC();
            }

        }
        private void Allribbon(PKM pk)
        {
            RibbonApplicator.SetAllValidRibbons(pk);
        }
        private void Clone_BTN_Click(object sender, EventArgs e)
        {
            switch (CloneValue)
            {
                case 0:
                    SetPkm();
                    SAV.ReloadSlots();
                    break;
                case 1:
                    SetFivePKM();
                    SAV.ReloadSlots();
                    break;
            }
        }
        private void Gift_BTN_Click(object sender, EventArgs e)
        {
            if (SAV.SAV.Version is GameVersion.SW or GameVersion.SH or GameVersion.SWSH)
            {
                SetGodPokemon();
            }
            else
            {
                MessageBox.Show("目前只支持剑盾！");
            }
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
            foreach (string line in lines)
            {
                Tr.Add(Trainer.ConvertToTrainer(line));
            }
            if (Tr.Count != 0)
                Trainer = Tr[0];

        }
        private void Use_Trainer_BTN_Click(object sender, EventArgs e)
        {
            switch (TrainerValue)
            {
                case 0:
                    PKM[] p;
                    int i = SAV.CurrentBox;
                    p = SAV.SAV.GetBoxData(i);
                    if (p.Count() != 0)
                    {
                        foreach (PKM pk in p)
                        {
                            pk.OriginalTrainerName = Trainer.OriginalTrainerName;
                            pk.DisplayTID = Trainer.TID16;
                            pk.DisplaySID = Trainer.SID16;
                            pk.Language = Trainer.Language;
                            pk.OriginalTrainerGender = (byte)Trainer.Gender;
                            pk.ClearNickname();
                        }
                    }
                    SAV.SAV.SetBoxData(p, i);
                    break;
                case 1:
                    UseTrainer(Editor.Data);
                    break;
            }
        }
        private void IVEVN_BTN_Click(object sender, EventArgs e)
        {
            switch (IVEVValue)
            {
                case 0:
                    Editor.PopulateFields(CommonIVEVSetting.ATKIVEV((PK9)Editor.Data));
                    break;
                case 1:
                    Editor.PopulateFields(CommonIVEVSetting.SPAIVEV((PK9)Editor.Data));
                    break;
                case 2:
                    Editor.PopulateFields(CommonIVEVSetting.ATK_0SPEIVEV((PK9)Editor.Data));
                    break;
                case 3:
                    Editor.PopulateFields(CommonIVEVSetting.SPA_0SPEIVEV((PK9)Editor.Data));
                    break;
                case 4:
                    Editor.PopulateFields(CommonIVEVSetting.TANKIVEV((PK9)Editor.Data));
                    break;
            }
        }
        private void Move_Shop_Click(object sender, EventArgs e)
        {
            int i = SAV.CurrentBox;
            SAV.SAV.ModifyBoxes(Handle_MoveShop, i, i);
        }
        private void LevelMax_BTN_Click(object sender, EventArgs e)
        {
            int i = SAV.CurrentBox;
            SAV.SAV.ModifyBoxes(Level, i, i);
        }
        private void Language_BTN_Click(object sender, EventArgs e)
        {
            PKM pk;
            List<PKM> L = new();
            for (int i = 1; i < 6; i++)
            {
                pk = SearchDatabase.MytheryLanguage(SAV, Editor.Data.Species, Editor.Data.Generation, 0, i);
                L.Add(pk);
            }
            for (int i = 7; i < 11; i++)
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
        private void RandEC_BTN_Click(object sender, EventArgs e)
        {

            SAV.SAV.ModifyBoxes(EC);
        }
        public void MAXSize(PKM pkm)
        {
            if (SAV.SAV.Generation == 9)
            {
                if (pkm.MetLocation != 30024 && pkm.Species != 998
                    && pkm.Species != 999 && pkm.Species != 996
                    && pkm.Species != 995 && pkm.Species != 994
                    && pkm.Species != 997)
                {
                    ((PK9)pkm).HeightScalar = 255;
                    ((PK9)pkm).WeightScalar = 255;
                    ((PK9)pkm).Scale = 255;
                    ((PK9)pkm).RibbonMarkMini = false;
                    ((PK9)pkm).RibbonMarkJumbo = true;
                }
            }
        }
        public void MINSize(PKM pkm)
        {
            if (SAV.SAV.Generation == 9)
            {
                if (pkm.MetLocation != 30024 && pkm.Species != 998
                    && pkm.Species != 999 && pkm.Species != 996
                    && pkm.Species != 995 && pkm.Species != 994
                    && pkm.Species != 997)
                {
                    if ((!(pkm.Species == 944 && pkm.MetLocation == 32)) &&
                        (!(pkm.Species == 952 && pkm.MetLocation == 40)) &&
                        (!(pkm.Species == 959 && pkm.MetLocation == 22)) &&
                        (!(pkm.Species == 962 && pkm.MetLocation == 20)) &&
                        (!(pkm.Species == 978 && pkm.MetLocation == 24)) &&
                        (!(pkm.Species == 986 && pkm.MetLocation == 24)))
                    {
                        ((PK9)pkm).HeightScalar = 1;
                        ((PK9)pkm).WeightScalar = 1;
                        ((PK9)pkm).Scale = 0;
                        ((PK9)pkm).RibbonMarkMini = true;
                        ((PK9)pkm).RibbonMarkJumbo = false;
                    }
                }
            }
        }
        private void MAXSize_BTN_Click(object sender, EventArgs e)
        {
            int i = SAV.CurrentBox;
            SAV.SAV.ModifyBoxes(MAXSize, i, i);
            SAV.ReloadSlots();
        }
        private void MINSize_BTN_Click(object sender, EventArgs e)
        {
            int i = SAV.CurrentBox;
            SAV.SAV.ModifyBoxes(MINSize, i, i);
            SAV.ReloadSlots();
        }
        private void ThreeFinder_BTN_Click(object sender, EventArgs e)
        {
            int i = SAV.CurrentBox;
            SAV.SAV.ModifyBoxes(FindThree, i, i);
            SAV.ReloadSlots();
        }
        public void FindThree(PKM pk)
        {
            if (pk.Species == 946)
            {
                pk.Form = 1;
                pk.SetRandomEC();
            }
            else if (pk.Species == 917)
            {
                pk.Form = 1;
                pk.SetRandomEC();
            }
        }
        private void Random_EncBTN_Click(object sender, EventArgs e)
        {
            Counter = 0;
            ProcessBox(SAV.CurrentBox, false);
        }
        private void Random_EggBTN_Click(object sender, EventArgs e)
        {
            Counter = 0;
            ProcessBox(SAV.CurrentBox, true);
        }
        private void ProcessBox(int box, bool mod)
        {
            if ((uint)box >= SAV.SAV.BoxCount)
                throw new ArgumentOutOfRangeException(nameof(box), "Value was more than BoxCount");
            var data = SAV.SAV.GetBoxData(box);
            if (mod == false)
            {
                ProcessPokemon(data);
            }
            else
            {
                ProcessEGG(data);
            }
            if (Counter > 0) SAV.SAV.SetBoxData(data, box);
        }
        private void ProcessEGG(IEnumerable<PKM> data)
        {
            var rand = new Random();

            foreach (var pokemon in data)
            {
                if (pokemon.Species <= 0 || pokemon is { WasEgg: false, IsEgg: false }) continue;
                var releaseDate = new ReleaseDate(SAV.SAV.Version);
                var baseDate = releaseDate.Date;
                var days = (DateTime.Today - baseDate).Days;
                var newEggMetDate = baseDate.AddDays(rand.Next(days));
                pokemon.EggDay = (byte)newEggMetDate.Day;
                pokemon.EggYear = (byte)(newEggMetDate.Year - 2000);
                pokemon.EggMonth = (byte)newEggMetDate.Month;
                Counter++;
            }
        }
        private void ProcessPokemon(IEnumerable<PKM> data)
        {
            var rand = new Random();

            foreach (var pokemon in data)
            {
                if (pokemon.Species <= 0)
                    continue;
                var releaseDate = new ReleaseDate(SAV.SAV.Version);
                var baseDate = PokemonEggCheck(pokemon, releaseDate.Date);
                var days = (DateTime.Today - baseDate).Days;
                var newMetDate = baseDate.AddDays(rand.Next(days));
                pokemon.MetDay = (byte)newMetDate.Day;
                pokemon.MetYear = (byte)(newMetDate.Year - 2000);
                pokemon.MetMonth = (byte)newMetDate.Month;
                Counter++;
            }
        }
        private DateTime PokemonEggCheck(PKM pokemon, DateTime gameReleaseDate)
#pragma warning restore CA1822
        {
            if (pokemon.EggMetDate is not null)
            {
                DateOnly dateTime = (DateOnly)pokemon.EggMetDate;
                var Time = dateTime.ToDateTime(TimeOnly.Parse("00:00 PM"));
                return Time;
            }
            return gameReleaseDate;
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
                         pkc.OriginalTrainerName = T.OriginalTrainerName;
                         pkc.OT_Gender = T.Gender;
                         pkc.DisplayTID= T.TID16;
                         pkc.DisplaySID = T.SID16;
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


        private void GenDIs_BTN_Click(object sender, EventArgs e)
        {
            var PKL = new List<PKM>();
            switch (Dis)
            {
                case 0:
                    PKL = PerfectDitto.SearchDitto(SAV, Editor);
                    break;
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
            SAV.ReloadSlots();
        }
    }
}
