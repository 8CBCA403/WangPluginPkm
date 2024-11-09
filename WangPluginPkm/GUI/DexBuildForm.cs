using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Utilities;
using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using WangPluginPkm.PluginUtil.AchieveBase;
using WangPluginPkm.PluginUtil.AchieveBase.PostGameAchieve;
using WangPluginPkm.PluginUtil.AchieveBase.SpecificForm;
using WangPluginPkm.PluginUtil.DexBase;
using WangPluginPkm.PluginUtil.MeerkatBase;
using WangPluginPkm.SortBase;
using static System.Resources.ResXFileRef;
using static WangPluginPkm.PluginUtil.Functions.DexBuildFunctions;
using static WangPluginPkm.PluginUtil.PluginEnums.GUIEnums;

namespace WangPluginPkm.GUI
{
    partial class DexBuildForm : Form
    {
        public static GameStrings GameStringsZh = GameInfo.GetStrings("zh-Hans");
        private static Random rand = new Random();
        public static Stopwatch sw = new();
        private SoundPlayer Player = new SoundPlayer();
        public VersionClass version = new VersionClass
        {
            Name = "按照全国图鉴顺序",
            Version = "National",
        };
        public DexModClass mod = new DexModClass
        {
            Name = "无",
            Value = "None",
        };
        private DexFormLanguage7 type7 = DexFormLanguage7.ENG;
        private DexFormLanguage5 type5 = DexFormLanguage5.ENG;
        private DexFormOTGender typeG = DexFormOTGender.Male;
        private int mainHomeAchieve = 0;
        private int subHomeAchieve = 0;
        public List<VersionClass> L = new();
        public List<DexModClass> ML = new();
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        public DexBuildForm(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            BindingData(SAV);
        }
        private void BindingData(ISaveFileProvider sav)
        {
            if (VersionFlag.ID7Flag(SAV.SAV.Version))
            {
                this.LanguageBox.DataSource = Enum.GetNames(typeof(DexFormLanguage7));
                this.GenderBox.DataSource = Enum.GetNames(typeof(DexFormOTGender));
                this.LanguageBox.SelectedIndexChanged += (_, __) =>
                {
                    type7 = (DexFormLanguage7)Enum.Parse(typeof(DexFormLanguage7), this.LanguageBox.SelectedItem.ToString(), false);
                };
            }
            else
            {
                this.LanguageBox.DataSource = Enum.GetNames(typeof(DexFormLanguage5));
                this.GenderBox.DataSource = Enum.GetNames(typeof(DexFormOTGender));
                this.LanguageBox.SelectedIndexChanged += (_, __) =>
                {
                    type5 = (DexFormLanguage5)Enum.Parse(typeof(DexFormLanguage5), this.LanguageBox.SelectedItem.ToString(), false);
                };

            }
            this.GenderBox.SelectedIndexChanged += (_, __) =>
            {
                typeG = (DexFormOTGender)Enum.Parse(typeof(DexFormOTGender), this.GenderBox.SelectedItem.ToString(), false);
            };
            this.LanguageBox.SelectedIndex = 0;
            this.GenderBox.SelectedIndex = 0;
            L = VersionClass.VersionList(sav);
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = L;
            SortBox.DataSource = bindingSource1.DataSource;
            SortBox.DisplayMember = "Name";
            SortBox.ValueMember = "Version";
            this.SortBox.SelectedIndexChanged += (_, __) =>
            {
                version = (VersionClass)this.SortBox.SelectedItem;
            };

            ML = DexModClass.DexModList(sav);
            var bindingSource2 = new BindingSource();
            bindingSource2.DataSource = ML;
            mod = ML[0];
            Mod_Select_Box.DataSource = bindingSource2.DataSource;
            Mod_Select_Box.DisplayMember = "Name";
            Mod_Select_Box.ValueMember = "Value";
            Mod_Select_Box.SelectedIndex = 0;
            FormAndSubDex_BTN.Enabled = false;
            this.Mod_Select_Box.SelectedIndexChanged += (_, __) =>
            {
                mod = (DexModClass)this.Mod_Select_Box.SelectedItem;
                if (mod.Value == "None")
                {
                    FormAndSubDex_BTN.Enabled = false;
                }
                else
                {
                    FormAndSubDex_BTN.Enabled = true;
                }
            };
            this.AchieveGen_BTN.Enabled = true;
            this.AchieveCheck_BTN.Enabled = false;
            this.MaincomboBox.DataSource = Enum.GetNames(typeof(MainHomeAchieve));
            this.SubcomboBox.DataSource = Enum.GetNames(typeof(RegionDex));
            this.MaincomboBox.SelectedIndexChanged += (_, __) =>
            {
                mainHomeAchieve = this.MaincomboBox.SelectedIndex;
                switch (mainHomeAchieve)
                {
                    case 0:
                        this.SubcomboBox.DataSource = Enum.GetNames(typeof(RegionDex));
                        this.AchieveGen_BTN.Enabled = true;
                        this.AchieveCheck_BTN.Enabled = false;
                        break;
                    case 1:
                        this.SubcomboBox.DataSource = Enum.GetNames(typeof(HomeType));
                        this.AchieveGen_BTN.Enabled = false;
                        this.AchieveCheck_BTN.Enabled = true;
                        break;
                    case 2:
                        this.SubcomboBox.DataSource = Enum.GetNames(typeof(HomeBall));
                        this.AchieveGen_BTN.Enabled = false;
                        this.AchieveCheck_BTN.Enabled = true;
                        break;
                    case 3:
                        this.SubcomboBox.DataSource = Enum.GetNames(typeof(HomeNature));
                        this.AchieveGen_BTN.Enabled = false;
                        this.AchieveCheck_BTN.Enabled = true;
                        break;
                    case 4:
                        this.SubcomboBox.DataSource = Enum.GetNames(typeof(Firstpartner));
                        this.AchieveGen_BTN.Enabled = true;
                        this.AchieveCheck_BTN.Enabled = false;
                        break;
                    case 5:
                        this.SubcomboBox.DataSource = Enum.GetNames(typeof(PostGenAchieve));
                        this.AchieveGen_BTN.Enabled = true;
                        this.AchieveCheck_BTN.Enabled = false;
                        break;
                    case 6:
                        this.SubcomboBox.DataSource = Enum.GetNames(typeof(SpecificForm));
                        this.AchieveGen_BTN.Enabled = true;
                        this.AchieveCheck_BTN.Enabled = false;
                        break;
                    case 7:
                        this.SubcomboBox.DataSource = Enum.GetNames(typeof(OtherPokemonachievements));
                        this.AchieveGen_BTN.Enabled = false;
                        this.AchieveCheck_BTN.Enabled = true;
                        break;

                }
            };
            this.SubcomboBox.SelectedIndexChanged += (_, __) =>
            {
                subHomeAchieve = this.SubcomboBox.SelectedIndex;
                if (this.MaincomboBox.SelectedIndex == 7)
                {
                    switch (subHomeAchieve)
                    {
                        case 15:
                            this.AchieveGen_BTN.Enabled = true;
                            this.AchieveCheck_BTN.Enabled = false;
                            break;
                        default:
                            this.AchieveGen_BTN.Enabled = false;
                            this.AchieveCheck_BTN.Enabled = true;
                            break;
                    }
                }
            };

        }
        public void Gen(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.ModifyBoxes(SetID);
            SaveFileEditor.ReloadSlots();
        }
        public void SetID(PKM pkm)
        {
            var T = pkm.TID16;
            var S = pkm.SID16;
            var N = pkm.OriginalTrainerName;
            var TID16 = uint.Parse(TID16Box.Text);
            var SID16 = uint.Parse(SID16Box.Text);
            var Name = OriginalTrainerName.Text;
            if (VersionFlag.ID7Flag(SAV.SAV.Version))
                pkm.Language = GetLanguageBox7(type7);

            else
                pkm.Language = GetLanguageBox5(type5);
            pkm.OriginalTrainerName = Name;
            pkm.ClearNickname();
            if (VersionFlag.ID7Flag(SAV.SAV.Version))
            {
                pkm.TrainerTID7 = TID16;
                pkm.TrainerSID7 = SID16;
                pkm.ClearNickname();
            }
            else
            {
                pkm.TID16 = (ushort)TID16;
                pkm.SID16 = (ushort)SID16;
                pkm.ClearNickname();

            }
            var la = new LegalityAnalysis(pkm);
            if (la.Valid)
            {
                pkm.OriginalTrainerGender = (byte)GetGender(typeG);
                pkm.ClearNickname();
            }
            else
            {
                pkm.TID16 = T;
                pkm.SID16 = S;
                pkm.OriginalTrainerName = N;
                pkm.ClearNickname();
            }
        }
        private void SortByRegionalDex(Func<PKM, IComparable>[] sortFunctions)
        {
            IEnumerable<PKM> sortMethod(IEnumerable<PKM> pkms, int i) => pkms.OrderByCustom(sortFunctions);
            SAV.SAV.SortBoxes(0, -1, sortMethod);
            SAV.ReloadSlots();
        }
        private void SortByNationalDex()
        {
            SAV.SAV.SortBoxes();
            SAV.ReloadSlots();
        }
        private static List<int> FindAllEmptySlots(IList<PKM> data, int start)
        {
            List<int> list = new();
            for (int i = start; i < data.Count; i++)
            {
                if (data[i].Species < 1)
                {
                    list.Add(i);
                }
            }
            return list;
        }
        private void Gen_BTN_Click(object sender, EventArgs e)
        {
            Gen(SAV);
            SAV.ReloadSlots();
            MessageBox.Show("搞定了！");

        }
        private void BuildDex_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            UnionPKM(SAV);
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
            sw.Reset();
        }
        private void LivingDex_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            LivingDex(SAV);
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
            sw.Reset();
        }
        private void Legal_BTN_Click(object sender, EventArgs e)
        {
            LegalBox(SAV);
            SAV.ReloadSlots();
            MessageBox.Show("搞定啦");
        }
        private void LegalAll_BTN_Click(object sender, EventArgs e)
        {
            sw.Start();
            LegalAll(SAV);
            SAV.ReloadSlots();
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
            sw.Reset();
        }
        private void ClearAll_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(ClearPKM);
            SAV.ReloadSlots();
        }
        private void RandomPID_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(RandomPKMPID);
            SAV.ReloadSlots();
        }
        private void Sort_BTN_Click(object sender, EventArgs e)
        {
            switch (version.Version)
            {
                case "National":
                    {
                        SortByNationalDex();
                        break;
                    }
                case "RYBG":
                    {
                        SortByRegionalDex(Gen1_Kanto.GetSortFunctions());
                        break;
                    }
                case "GS":
                    {
                        SortByRegionalDex(Gen2_Johto.GetSortFunctions());
                        break;
                    }
                case "E":
                    {
                        SortByRegionalDex(Gen3_Hoenn.GetSortFunctions());
                        break;
                    }
                case "FRGL":
                    {
                        SortByRegionalDex(Gen3_Kanto.GetSortFunctions());
                        break;
                    }
                case "DP":
                    {
                        SortByRegionalDex(Gen4_Sinnoh.GetDPSortFunctions());
                        break;
                    }
                case "Platinum":
                    {
                        SortByRegionalDex(Gen4_Sinnoh.GetPtSortFunctions());
                        break;
                    }
                case "GHSS":
                    {
                        SortByRegionalDex(Gen4_Johto.GetSortFunctions());
                        break;
                    }
                case "BW":
                    {
                        SortByRegionalDex(Gen5_Unova.GetBWSortFunctions());
                        break;
                    }
                case "B2W2":
                    {
                        SortByRegionalDex(Gen5_Unova.GetB2W2SortFunctions());
                        break;
                    }
                case "XY":
                    {
                        SortByRegionalDex(Gen6_Kalos.GetSortFunctions());
                        break;
                    }
                case "ORAS":
                    {
                        SortByRegionalDex(Gen6_Hoenn.GetSortFunctions());
                        break;
                    }
                case "SM":
                    {
                        SortByRegionalDex(Gen7_Alola.GetFullSMSortFunctions());
                        break;
                    }
                case "USUM":
                    {
                        SortByRegionalDex(Gen7_Alola.GetFullUSUMSortFunctions());
                        break;
                    }
                case "LPLE":
                    {
                        SortByRegionalDex(Gen7_Kanto.GetSortFunctions());
                        break;
                    }
                case "SWSH":
                    {
                        SortByRegionalDex(Gen8_Galar.GetGalarDexSortFunctions());
                        break;
                    }
                case "SWSH1":
                    {
                        SortByRegionalDex(Gen8_Galar.GetIoADexSortFunctions());
                        break;
                    }
                case "SWSH2":
                    {
                        SortByRegionalDex(Gen8_Galar.GetCTDexSortFunction());
                        break;
                    }
                case "SWSH3":
                    {
                        SortByRegionalDex(Gen8_Galar.GetFullGalarDexSortFunctions());
                        break;
                    }
                case "BDSP":
                    {
                        SortByRegionalDex(Gen8_Sinnoh.GetSortFunctions());
                        break;
                    }
                case "PLA":
                    {
                        SortByRegionalDex(Gen8_Hisui.GetSortFunctions());
                        break;
                    }
                case "SV":
                    {
                        SortByRegionalDex(Gen9__Paldea.GetSortFunctions());
                        break;
                    }
            }
            MessageBox.Show("排序完成", "SuperWang");
        }
        private void DeleteBox_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(ClearPKM, SAV.CurrentBox, SAV.CurrentBox);
            SAV.ReloadSlots();
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }
        private void FormAndSubDex_Click(object sender, EventArgs e)
        {
            var PKL = new List<PKM>();

            switch (mod.Value)
            {
                case "CapPikachu":
                    PKL = CapPikachuDex.CapPikachuSets(SAV, Editor);
                    break;
                case "Unown":
                    if (SAV.SAV.Version is GameVersion.SW or GameVersion.SH or GameVersion.SWSH)
                        PKL = GastrodonDex.GastrodonSets(SAV, Editor);
                    else
                    {
                        PKL = UnownDex.UnownSets(SAV, Editor);
                    }
                    break;
                case "Deoxys":
                    PKL = DeoxysDex.DeoxysSets(SAV, Editor);
                    break;
                case "Burmy":
                    PKL = BurmyDex.BurmySets(SAV, Editor);
                    break;
                case "Gastrodon":
                    PKL = GastrodonDex.GastrodonSets(SAV, Editor);
                    break;
                case "Rotom":
                    PKL = RotomDex.RotomSets(SAV, Editor);
                    break;
                case "Arceus":
                    PKL = ArceusDex.ArceusSets(SAV, Editor);
                    break;
                case "Deerling":
                    PKL = DeerlingDex.DeerlingSets(SAV, Editor);
                    break;
                case "Incarnate":
                    PKL = IncarnateDex.IncarnateSets(SAV, Editor);
                    break;
                case "Genesect":
                    PKL = GenesectDex.GenesectSets(SAV, Editor);
                    break;
                case "DreamRadar":
                    PKL = DreamRadarDex.DreamRadarSets(SAV, Editor);
                    break;
                case "Vivillon":
                    PKL = VivillonDex.VivillonSets(SAV, Editor);
                    break;
                case "Flabébé":
                    PKL = FlabébéDex.FlabébéSets(SAV, Editor);
                    break;
                case "Furfrou":
                    PKL = FurfrouDex.FurfrouSets(SAV, Editor);
                    break;
                case "Pumpkaboo":
                    PKL = PumpkabooDex.PumpkabooSets(SAV, Editor);
                    break;
                case "CosplayPikachu":
                    PKL = CosplayPikachuDex.CosplayPikachuSets(SAV, Editor);
                    break;
                case "Zygarde":
                    PKL = ZygardeDex.ZygardeSets(SAV, Editor);
                    break;
                case "Rockruffy":
                    PKL = RockruffyDex.RockruffySets(SAV, Editor);
                    break;
                case "Oricorio":
                    PKL = OricorioDex.OricorioSets(SAV, Editor);
                    break;
                case "Minior":
                    PKL = MiniorDex.MiniorSets(SAV, Editor);
                    break;
                case "Alcremie":
                    PKL = AlcremieDex.AlcremieSets(SAV, Editor);
                    break;
                case "Silvally":
                    PKL = SilvallyDex.SilvallySets(SAV, Editor);
                    break;
                case "Mega":
                    PKL = MegaDex.MegaSets(SAV, Editor);
                    break;
                case "Alola":
                    PKL = AlolaformDex.AlolaSets(SAV, Editor);
                    break;
                case "Galar":
                    PKL = GalarformDex.GalarSets(SAV, Editor);
                    break;
                case "Gigamax":
                    PKL = GigamaxDex.GigamaxSets(SAV, Editor);
                    break;
                case "Hisui":
                    PKL = HisuiformDex.HisuiSets(SAV, Editor);
                    break;
                case "Paradox":
                    PKL = ParadoxDex.ParadoxSets(SAV, Editor);
                    break;
                case "Squawkabilly":
                    PKL = SquawkabillyDex.SquawkabillySets(SAV, Editor);
                    break;
                case "Tatsugiri":
                    PKL = TatsugiriDex.TatsugiriSets(SAV, Editor);
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
            //  LegalBox(SAV);
            SAV.ReloadSlots();
        }
        private void RandomEC_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(RandomPKMEC);
            SAV.ReloadSlots();
        }
        #region
        /*
          private void GODex_BTN_Click(object sender, EventArgs e)
        {
            GODex(SAV);
        }
        private void GODex(ISaveFileProvider SaveFileEditor)
        {
            List<IEncounterInfo> Results;
            IEncounterInfo enc;
            PKM pk ;
            ushort j;
            List<PKM> pkMList;
            List<PKM> p=new();
            pkMList = (List<PKM>)SaveFileEditor.SAV.GetAllPKM();
           // MessageBox.Show($"{pkMList.Count()}");
            for (int i = 0; i < pkMList.Count(); i++)
            {
                pk = pkMList[i];
                var pkc = pk.Clone();
                j = pk.Species;
                var setting = new SearchSettings
                {
                    Species = pk.Species,
                    SearchEgg = false,
                    Version = 34,
                };
                var search = EncounterUtil.SearchDatabase(setting, SaveFileEditor.SAV);
                var results = search.ToList();
               // MessageBox.Show($"{results.Count}");

                if (results.Count != 0)
                {
                    Results = results;
                    enc = Results[0];
                    var criteria = EncounterUtil.GetCriteria(enc, pk);
                    EntityConverter.TryMakePKMCompatible(enc.ConvertToPKM(SaveFileEditor.SAV, criteria), pk, out var c, out pk);
                    pk.Species = j;
                    pk.ClearNickname();
                    pk.Ability = pkc.Ability;
                    pk.OriginalTrainerName = RandomString(6);
                    pk.SetSuggestedMoves();
                    if( pk.Move1 != 0)
                        pk.SetSuggestedMovePP(0);
                    if (pk.Move2 != 0)
                        pk.SetSuggestedMovePP(1);
                    if (pk.Move3 != 0)
                        pk.SetSuggestedMovePP(2);
                    if (pk.Move4 != 0)
                        pk.SetSuggestedMovePP(3);
                    pk.RefreshChecksum();
                    p.Add(pk);
                }
                else
                    p.Add(pkc);
            }
            for (int i = 0; i < SaveFileEditor.SAV.BoxCount; i++)
            {
                for (j = 0; j < 30; j++)
                {
                    if (pkMList.Count >(i * 30 + j))
                        SaveFileEditor.SAV.SetBoxSlotAtIndex(p[i * 30 + j], i, j);
                    else
                        break;
                }
            }
            SaveFileEditor.ReloadSlots();
        }*/
        #endregion

        //https://github.com/foohyfooh/PKHeXInsertionPlugin
        private void Insertion_BTN_Click(object sender, EventArgs e)
        {
            int boxNum = (int)BoxnumericUpDown.Value;
            int slotNum = (int)SoltnumericUpDown.Value;
            var MAXBox = SAV.SAV.BoxCount;
            var MAXBoxSlot = SAV.SAV.BoxSlotCount;
            var MAXSlot = SAV.SAV.SlotCount;
            bool hadError = false;
            string errorText = string.Empty;
            if (boxNum < 1 || boxNum > MAXBox)
            {
                errorText = $"Box Number should be between 1 and {MAXBox}";
                hadError = true;
            }

            if (slotNum < 1 || slotNum > MAXBoxSlot)
            {
                if (errorText.Length > 0) errorText += "\n";
                errorText += $"Slot Number should be between 1 and {MAXBoxSlot}";
                hadError = true;
            }

            if (hadError)
            {
                MessageBox.Show(errorText);
                return;
            }

            int boxIndex = (boxNum - 1) * MAXBoxSlot + (slotNum - 1);
            PKM prevMon = SAV.SAV.GetBoxSlotAtIndex(boxIndex), currMon = SAV.SAV.BlankPKM;
            if (prevMon.Species != (int)Species.None)
            {
                SAV.SAV.SetBoxSlotAtIndex(SAV.SAV.BlankPKM, boxIndex);
                boxIndex++;
                while (boxIndex < MAXSlot)
                {
                    currMon = SAV.SAV.GetBoxSlotAtIndex(boxIndex);
                    SAV.SAV.SetBoxSlotAtIndex(prevMon, boxIndex, PKMImportSetting.UseDefault, PKMImportSetting.Skip);
                    if (currMon.Species == (int)Species.None) break;
                    prevMon = currMon;
                    boxIndex++;
                }
                if (currMon.Species != (int)Species.None)
                {
                    MessageBox.Show($"Box {MAXBox} Slot {MAXSlot} was erased");
                }
                SAV.ReloadSlots();

            }
            else
            {
                MessageBox.Show($"Box {boxNum} Slot {slotNum} is already empty");
            }
        }

        private void Run_BTN_Click(object sender, EventArgs e)
        {
            var PKL = new List<PKM>();
            switch (mainHomeAchieve)
            {
                case 0:
                    switch (subHomeAchieve)
                    {
                        case 0:
                            if (SAV.SAV.Version == GameVersion.GE || SAV.SAV.Version == GameVersion.GP)
                            {
                                sw.Start();
                                LivingDexHome(SAV);
                                sw.Stop();
                                MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
                                sw.Reset();
                            }
                            else
                            {
                                MessageBox.Show("版本不对！");
                            }
                            break;
                        case 1:
                            if (SAV.SAV.Version == GameVersion.SW || SAV.SAV.Version == GameVersion.SH)
                            {
                                sw.Start();
                                LivingDexHome(SAV);
                                IEnumerable<PKM> sortMethod(IEnumerable<PKM> pkms, int i) => pkms.OrderByCustom(Gen8_Galar.GetGalarDexSortFunctions());
                                SAV.SAV.SortBoxes(0, -1, sortMethod);
                                List<PKM> L = (List<PKM>)SAV.SAV.GetAllPKM();
                                var n = L.Count;
                                SAV.SAV.ModifyBoxes(ClearPKM);
                                for (int i = 400; i < n; i++)
                                {
                                    L.RemoveAt(400);
                                }
                                if (L.Count != 0)
                                {
                                    for (int i = 0; i < L.Count; i++)
                                    {

                                        SAV.SAV.SetBoxSlotAtIndex(L[i], i);
                                    }
                                }
                                SAV.ReloadSlots();
                                sw.Stop();
                                MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
                                sw.Reset();
                            }
                            else
                            {
                                MessageBox.Show("版本不对！");
                            }
                            break;
                        case 2:
                            if (SAV.SAV.Version == GameVersion.SW || SAV.SAV.Version == GameVersion.SH)
                            {
                                sw.Start();
                                LivingDexHome(SAV);
                                IEnumerable<PKM> sortMethod(IEnumerable<PKM> pkms, int i) => pkms.OrderByCustom(Gen8_Galar.GetIoADexSortFunctions());
                                SAV.SAV.SortBoxes(0, -1, sortMethod);
                                List<PKM> L = (List<PKM>)SAV.SAV.GetAllPKM();
                                var n = L.Count;
                                SAV.SAV.ModifyBoxes(ClearPKM);
                                for (int i = 211; i < n; i++)
                                {
                                    L.RemoveAt(211);
                                }
                                if (L.Count != 0)
                                {
                                    for (int i = 0; i < L.Count; i++)
                                    {

                                        SAV.SAV.SetBoxSlotAtIndex(L[i], i);
                                    }
                                }
                                SAV.ReloadSlots();
                                sw.Stop();
                                MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
                                sw.Reset();
                            }
                            else
                            {
                                MessageBox.Show("版本不对！");
                            }
                            break;
                        case 3:
                            if (SAV.SAV.Version == GameVersion.SW || SAV.SAV.Version == GameVersion.SH)
                            {
                                sw.Start();
                                LivingDexHome(SAV);
                                IEnumerable<PKM> sortMethod(IEnumerable<PKM> pkms, int i) => pkms.OrderByCustom(Gen8_Galar.GetCTDexSortFunction());
                                SAV.SAV.SortBoxes(0, -1, sortMethod);
                                List<PKM> L = (List<PKM>)SAV.SAV.GetAllPKM();
                                var n = L.Count;
                                SAV.SAV.ModifyBoxes(ClearPKM);
                                for (int i = 210; i < n; i++)
                                {
                                    L.RemoveAt(210);
                                }
                                if (L.Count != 0)
                                {
                                    for (int i = 0; i < L.Count; i++)
                                    {

                                        SAV.SAV.SetBoxSlotAtIndex(L[i], i);
                                    }
                                }
                                SAV.ReloadSlots();
                                sw.Stop();
                                MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
                                sw.Reset();
                            }
                            else
                            {
                                MessageBox.Show("版本不对！");
                            }
                            break;
                        case 4:
                            if (SAV.SAV.Version == GameVersion.BD || SAV.SAV.Version == GameVersion.SP)
                            {
                                sw.Start();
                                LivingDexHome(SAV);
                                sw.Stop();
                                MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
                                sw.Reset();
                            }
                            else
                            {
                                MessageBox.Show("版本不对！");
                            }
                            break;
                        case 5:
                            if (SAV.SAV.Version == GameVersion.PLA)
                            {
                                sw.Start();
                                LivingDexHome(SAV);
                                sw.Stop();
                                MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
                                sw.Reset();
                            }
                            else
                            {
                                MessageBox.Show("版本不对！");
                            }
                            break;
                    }
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    {
                        switch (subHomeAchieve)
                        {
                            case 0:
                                PKL = FirstPartner.FRLGSets(SAV, Editor).Concat(FirstPartner.HGSSSets(SAV, Editor)).
                                    Concat(FirstPartner.RSESets(SAV, Editor)).Concat(FirstPartner.DPPTSets(SAV, Editor)).
                                    Concat(FirstPartner.BWSets(SAV, Editor)).Concat(FirstPartner.XYSets(SAV, Editor)).
                                    Concat(FirstPartner.SMSets(SAV, Editor)).ToList();

                                break;
                            case 1:
                                PKL = FirstPartner.FRLGSets(SAV, Editor);
                                break;
                            case 2:
                                PKL = FirstPartner.HGSSSets(SAV, Editor);
                                break;
                            case 3:
                                PKL = FirstPartner.RSESets(SAV, Editor);
                                break;
                            case 4:
                                PKL = FirstPartner.DPPTSets(SAV, Editor);
                                break;
                            case 5:
                                PKL = FirstPartner.BWSets(SAV, Editor);
                                break;
                            case 6:
                                PKL = FirstPartner.XYSets(SAV, Editor);
                                break;
                            case 7:
                                PKL = FirstPartner.SMSets(SAV, Editor);
                                break;
                        }
                    }
                    break;
                case 5:
                    {
                        switch (subHomeAchieve)
                        {
                            case 0:
                                PKL = RSE.RSESets(SAV, Editor).Concat(FRLG.FRLGSets(SAV, Editor)).Concat(DPPT.DPPTSets(SAV, Editor)).
                                    Concat(HGSS.HGSSSets(SAV, Editor)).Concat(BW.BWSets(SAV, Editor)).
                                    Concat(XY.XYSets(SAV, Editor)).Concat(ORAS.ORASSets(SAV, Editor)).
                                     Concat(SM.SMSets(SAV, Editor)).Concat(RBY.RBYSets(SAV, Editor)).
                                     Concat(GDSI.GDSISets(SAV, Editor)).ToList(); ;
                                break;
                            case 1:
                                PKL = RSE.RSESets(SAV, Editor);
                                break;
                            case 2:
                                PKL = FRLG.FRLGSets(SAV, Editor);
                                break;
                            case 3:
                                PKL = DPPT.DPPTSets(SAV, Editor);
                                break;
                            case 4:
                                PKL = HGSS.HGSSSets(SAV, Editor);
                                break;
                            case 5:
                                PKL = BW.BWSets(SAV, Editor);
                                break;
                            case 6:
                                PKL = XY.XYSets(SAV, Editor);
                                break;
                            case 7:
                                PKL = ORAS.ORASSets(SAV, Editor);
                                break;
                            case 8:
                                PKL = SM.SMSets(SAV, Editor);
                                break;
                            case 9:
                                PKL = RBY.RBYSets(SAV, Editor);
                                break;
                            case 10:
                                PKL = GDSI.GDSISets(SAV, Editor);
                                break;
                        }
                    }
                    break;
                case 6:
                    {
                        switch (subHomeAchieve)
                        {
                            case 0:
                                PKL = VivillonDex.VivillonSets(SAV, Editor).Concat(Alola.AlolaSets(SAV, Editor)).
                                    Concat(AlolaformDex.AlolaSets(SAV, Editor)).Concat(Fossil.FossilSets(SAV, Editor)).
                                    Concat(UnownDex.UnownSets(SAV, Editor)).Concat(OricorioDex.OricorioSets(SAV, Editor)).
                                    Concat(UltraBeast.UltraSets(SAV, Editor)).Concat(RotomDex.RotomSets(SAV, Editor)).
                                    Concat(MiniorDex.MiniorSets(SAV, Editor)).Concat(Eevee.EeveeSets(SAV, Editor)).
                                    Concat(Deerling.SpringSets(SAV, Editor)).Concat(Deerling.SummerSets(SAV, Editor)).
                                    Concat(Deerling.AutumnSets(SAV, Editor)).Concat(Deerling.WinterSets(SAV, Editor)).
                                    Concat(Misc.SnorlaxSets(SAV, Editor)).Concat(Misc.MetagrossSets(SAV, Editor)).
                                    Concat(Misc.ShayminSets(SAV, Editor)).Concat(Misc.MeloettaSets(SAV, Editor)).
                                    Concat(Misc.GenesectSets(SAV, Editor)).Concat(GuardianDeity.GSets(SAV, Editor)).
                                    Concat(CapPikachuDex.CapPikachuSets(SAV, Editor)).Concat(Pika.PikaSets(SAV, Editor)).Concat(Ditto.DittoSets(SAV, Editor)).
                                    ToList();

                                break;
                            case 1:
                                PKL = VivillonDex.VivillonSets(SAV, Editor);
                                break;
                            case 2:
                                PKL = Alola.AlolaSets(SAV, Editor).Concat(AlolaformDex.AlolaSets(SAV, Editor)).ToList();
                                break;
                            case 3:
                                PKL = Fossil.FossilSets(SAV, Editor);
                                break;
                            case 4:
                                PKL = UnownDex.UnownSets(SAV, Editor);
                                break;
                            case 5:
                                PKL = OricorioDex.OricorioSets(SAV, Editor);
                                break;
                            case 6:
                                PKL = UltraBeast.UltraSets(SAV, Editor);
                                break;
                            case 7:
                                PKL = RotomDex.RotomSets(SAV, Editor);
                                break;
                            case 8:
                                PKL = MiniorDex.MiniorSets(SAV, Editor);
                                break;
                            case 9:
                                PKL = Eevee.EeveeSets(SAV, Editor);
                                break;
                            case 10:
                                PKL = Deerling.SpringSets(SAV, Editor);
                                break;
                            case 11:
                                PKL = Deerling.SummerSets(SAV, Editor);
                                break;
                            case 12:
                                PKL = Deerling.AutumnSets(SAV, Editor);
                                break;
                            case 13:
                                PKL = Deerling.WinterSets(SAV, Editor);
                                break;
                            case 14:
                                PKL = Misc.SnorlaxSets(SAV, Editor);
                                break;
                            case 15:
                                PKL = Misc.MetagrossSets(SAV, Editor);
                                break;
                            case 16:
                                PKL = Misc.ShayminSets(SAV, Editor);
                                break;
                            case 17:
                                PKL = Misc.MeloettaSets(SAV, Editor);
                                break;
                            case 18:
                                PKL = Misc.GenesectSets(SAV, Editor);
                                break;
                            case 19:
                                PKL = GuardianDeity.GSets(SAV, Editor);
                                break;
                            case 20:
                                PKL = CapPikachuDex.CapPikachuSets(SAV, Editor);
                                break;
                            case 21:
                                PKL = Pika.PikaSets(SAV, Editor);
                                break;
                            case 22:
                                PKL = Ditto.DittoSets(SAV, Editor);
                                break;

                        }
                    }
                    break;
                case 7:
                    {
                        switch (subHomeAchieve)
                        {
                            case 15:
                                PKL = AlcremieDex.AlcremieSets(SAV, Editor);
                                break;
                        }
                        break;
                    }
                default: break;
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

        private void GenDex_BTN_Click(object sender, EventArgs e)
        {
            if (SAV.SAV.Version != GameVersion.US && SAV.SAV.Version != GameVersion.UM)
            {
                MessageBox.Show("本功能只适用于究极日月！");
                return;
            }
            sw.Start();
            var PKL = MutiGenDex.SetAll(SAV, Editor, false);
            var BoxData = SAV.SAV.BoxData;
            IList<PKM> arr2 = BoxData;
            List<int> list = FindAllEmptySlots(arr2, 0);
            for (int i = 0; i < PKL.Count; i++)
            {
                int index = list[i];
                SAV.SAV.SetBoxSlotAtIndex(PKL[i], index);
            }
            SAV.ReloadSlots();
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
            sw.Reset();
            Player.Stream = Properties.Resources.dex;
            Player.Play();
        }
        #region meerkat
        /*
        private void RunMarkeet_BTN_Click(object sender, EventArgs e)
        {
            var PKL = new List<PKM>();
            var PKLB = new List<PKM>();
            switch (Markeet)
            {
                case 0:
                    PKL = SAV.SAV.GenerateLivingDex(true, ShinycheckBox.Checked, false, false).ToList();
                    PKL.RemoveAt(22);
                    PKL.RemoveAt(130);
                    PKL.RemoveAt(883);
                    PKL.RemoveAt(886);
                    PKL.RemoveAt(894);
                    PKL.RemoveAt(905);
                    PKL.RemoveAt(907);
                    PKL.RemoveAt(911);
                    PKL.RemoveAt(953);
                    PKL.RemoveAt(954);
                    MessageBox.Show($"{PKL.Count}");
                    break;
                case 1:
                    sw.Start();
                    PKL = SAV.SAV.GenerateLivingDex(true, ShinycheckBox.Checked, false, false).ToList();
                    PKL.RemoveAt(22);
                    PKL.RemoveAt(130);
                    PKL.RemoveAt(883);
                    PKL.RemoveAt(886);
                    PKL.RemoveAt(894);
                    PKL.RemoveAt(905);
                    PKL.RemoveAt(907);
                    PKL.RemoveAt(911);
                    PKL.RemoveAt(953);
                    PKL.RemoveAt(954);
                    PKL.RemoveAt(960);
                    for (int i = 0; i < 23; i++)
                    {
                        PKLB.Add(PKL[960 + i]);
                    }
                    PKLB = PKLB.Concat(TaoBaoCombo1One.Sets(SAV, Editor)).ToList();
                    sw.Stop();
                    MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", "SuperWang");
                    sw.Reset();
                    break;
            }

            var BoxData = SAV.SAV.BoxData;
            IList<PKM> arr2 = BoxData;
            List<int> list = FindAllEmptySlots(arr2, 0);
            if (PKL.Count != 0)
            {
                if (Markeet == 0)
                {
                    for (int i = 0; i < 960; i++)
                    {
                        int index = list[i];
                        SAV.SAV.SetBoxSlotAtIndex(PKL[i], index);
                    }
                    MessageBox.Show($"注意这个存档满了换下一个");
                }
                else if (Markeet == 1)
                {
                    for (int i = 0; i < PKLB.Count; i++)
                    {
                        int index = list[i];
                        SAV.SAV.SetBoxSlotAtIndex(PKLB[i], index);
                    }
                }
                else
                {
                    for (int i = 0; i < PKL.Count; i++)
                    {
                        int index = list[i];
                        SAV.SAV.SetBoxSlotAtIndex(PKL[i], index);
                    }
                }
            }
            SAV.ReloadSlots();

        }
        */
        #endregion

        private void AchieveCheck_BTN_Click(object sender, EventArgs e)
        {
            var PL = SAV.SAV.GetAllPKM();
            int i = 0;
            List<int> aL = new();
            switch (mainHomeAchieve)
            {
                case 1:
                    {
                        foreach (var pk in PL)
                        {
                            if (CheckAchieve.pokemonIsType(pk, CheckAchieve.T(subHomeAchieve)))
                            {
                                i++;
                            }
                        }
                        Result.Text = $"当前存档中有{i}只属性为{GameStringsZh.Types[(int)CheckAchieve.T(subHomeAchieve)]}属性的宝可梦";
                    }
                    break;
                case 2:
                    {
                        foreach (var pk in PL)
                        {
                            if (CheckAchieve.pokemonIsBall(pk, CheckAchieve.B(subHomeAchieve)))
                            {
                                i++;
                            }
                        }
                        Result.Text = $"当前存档中有{i}只球种为{CheckAchieve.B(subHomeAchieve)}的宝可梦";
                    }
                    break;
                case 3:
                    {
                        foreach (var pk in PL)
                        {
                            if (CheckAchieve.pokemonIsNature(pk, CheckAchieve.N(subHomeAchieve)))
                            {
                                i++;
                            }
                        }
                        Result.Text = $"当前存档中有{i}只性格为{GameStringsZh.Natures[(int)CheckAchieve.N(subHomeAchieve)]}的宝可梦";
                    }
                    break;
                case 7:
                    {
                        switch (subHomeAchieve)
                        {
                            case 0:
                                foreach (var pk in PL)
                                {
                                    if (CheckAchieve.Ispokemon(pk))
                                    {
                                        i++;
                                    }
                                }
                                Result.Text = $"当前存档中有{i}只宝可梦";
                                break;
                            case 1:
                                foreach (var pk in PL)
                                {
                                    if (CheckAchieve.Isshiny(pk))
                                    {
                                        i++;
                                    }
                                }
                                Result.Text = $"当前存档中有{i}只异色宝可梦";
                                break;
                            case 2:
                                foreach (var pk in PL)
                                {
                                    aL.Add(pk.Ability);
                                }
                                var dis = aL.DistinctBy(i => i);
                                Result.Text = $"当前存档中有{dis.Count()}种特性";
                                break;
                            case 3:
                                foreach (var pk in PL)
                                {
                                    aL.Add(pk.Move1);
                                    aL.Add(pk.Move2);
                                    aL.Add(pk.Move3);
                                    aL.Add(pk.Move4);
                                }
                                var Pdis = aL.DistinctBy(i => i);
                                Result.Text = $"当前存档中有{Pdis.Count() - 1}种技能";
                                break;
                            case 4:
                                foreach (var pk in PL)
                                {
                                    aL.Add(pk.Move1);
                                    aL.Add(pk.Move2);
                                    aL.Add(pk.Move3);
                                    aL.Add(pk.Move4);
                                }
                                var Sdis = aL.DistinctBy(i => i);
                                Result.Text = $"当前存档中有{Sdis.Count() - 1}种技能";
                                break;
                            case 5:
                                foreach (var pk in PL)
                                {
                                    aL.Add(pk.Move1);
                                    aL.Add(pk.Move2);
                                    aL.Add(pk.Move3);
                                    aL.Add(pk.Move4);
                                }
                                var Cdis = aL.DistinctBy(i => i);
                                Result.Text = $"当前存档中有{Cdis.Count() - 1}种技能";
                                break;
                            case 6:
                                if (SAV.SAV.Version == GameVersion.PLA)
                                {
                                    foreach (var pk in PL)
                                    {
                                        if (CheckAchieve.IsGMax((PA8)pk))
                                        {
                                            i++;
                                        }
                                    }
                                    Result.Text = $"当前存档中有{i}只奋斗等级最高宝可梦";
                                }
                                else
                                {
                                    MessageBox.Show("版本不对！");
                                }
                                break;
                            case 7:
                                if (SAV.SAV.Version == GameVersion.PLA)
                                {
                                    foreach (var pk in PL)
                                    {
                                        if (CheckAchieve.IsAlpha((PA8)pk))
                                        {
                                            i++;
                                        }
                                    }
                                    Result.Text = $"当前存档中有{i}只头目宝可梦";
                                }
                                else
                                {
                                    MessageBox.Show("版本不对！");
                                }
                                break;
                            case 8:
                                if (SAV.SAV.Version is GameVersion.BD or GameVersion.SP)
                                {
                                    foreach (var pk in PL)
                                    {
                                        if (CheckAchieve.IsSheen((PB8)pk))
                                        {
                                            i++;
                                        }
                                    }

                                    Result.Text = $"当前存档中有{i}只光泽达到最棒的宝可梦";
                                }
                                else
                                {
                                    MessageBox.Show("版本不对！");
                                }
                                break;
                            case 9:
                                if (SAV.SAV.Version is GameVersion.BD or GameVersion.SP)
                                {
                                    foreach (var pk in PL)
                                    {
                                        if (CheckAchieve.IsCool((PB8)pk))
                                        {
                                            i++;
                                        }
                                    }
                                    Result.Text = $"当前存档中有{i}只帅气达到最棒的宝可梦";
                                }
                                else
                                {
                                    MessageBox.Show("版本不对！");
                                }
                                break;
                            case 10:
                                if (SAV.SAV.Version is GameVersion.BD or GameVersion.SP)
                                {
                                    foreach (var pk in PL)
                                    {
                                        if (CheckAchieve.IsBeauty((PB8)pk))
                                        {
                                            i++;
                                        }
                                    }
                                    Result.Text = $"当前存档中有{i}只美丽达到最棒的宝可梦";
                                }
                                else
                                {
                                    MessageBox.Show("版本不对！");
                                }
                                break;
                            case 11:
                                if (SAV.SAV.Version is GameVersion.BD or GameVersion.SP)
                                {
                                    foreach (var pk in PL)
                                    {
                                        if (CheckAchieve.IsCute((PB8)pk))
                                        {
                                            i++;
                                        }
                                    }
                                    Result.Text = $"当前存档中有{i}只可爱达到最棒的宝可梦";
                                }
                                else
                                {
                                    MessageBox.Show("版本不对！");
                                }
                                break;
                            case 12:
                                if (SAV.SAV.Version is GameVersion.BD or GameVersion.SP)
                                {
                                    foreach (var pk in PL)
                                    {
                                        if (CheckAchieve.IsSmart((PB8)pk))
                                        {
                                            i++;
                                        }
                                    }
                                    Result.Text = $"当前存档中有{i}只聪明达到最棒的宝可梦";
                                }
                                else
                                {
                                    MessageBox.Show("版本不对！请使用晶灿钻石或明亮珍珠版本");
                                }
                                break;
                            case 13:
                                if (SAV.SAV.Version is GameVersion.BD or GameVersion.SP)
                                {
                                    foreach (var pk in PL)
                                    {
                                        if (CheckAchieve.IsTough((PB8)pk))
                                        {
                                            i++;
                                        }
                                    }
                                    Result.Text = $"当前存档中有{i}只强壮达到最棒的宝可梦";
                                }
                                else
                                {
                                    MessageBox.Show("版本不对！请使用晶灿钻石或明亮珍珠版本");
                                }
                                break;
                            case 14:
                                if (SAV.SAV.Version is GameVersion.BD or GameVersion.SP)
                                {
                                    foreach (var pk in PL)
                                    {
                                        IRibbonIndex M = (PB8)pk;
                                        if (M.GetRibbonIndex(RibbonIndex.TwinklingStar))
                                        {
                                            i++;
                                        }
                                    }
                                    Result.Text = $"当前存档中有{i}只携带闪亮之星奖章的宝可梦";
                                }
                                else
                                {
                                    MessageBox.Show("版本不对！请使用晶灿钻石或明亮珍珠版本");
                                }
                                break;
                        }
                    }
                    break;
            }

        }

        private void Check_BTN_Click(object sender, EventArgs e)
        {
            SAV.ReloadSlots();
            int TID = (TIDCheck_BOX.Text != string.Empty ? int.Parse(TIDCheck_BOX.Text) : 0);
            int SID = (SIDCheck_Box.Text != string.Empty ? int.Parse(SIDCheck_Box.Text) : 0);
            Int32 TS = TID * 1000 + SID;
            var p = SAV.SAV.GetAllPKM();
            int i = 0;
            int n = 0;
            foreach (var pk in p)
            {
                int TS1 = (int)pk.TrainerTID7 * 1000 + (int)pk.TrainerSID7;
                i++;
                if (TS != TS1 && pk.Species != 0 && pk.PID != 0)
                {
                    R_BOX.AppendText($"第{i / 30 + 1}箱第{i % 30 + 1}只ID不同\n" + Environment.NewLine);
                    n++;
                }

            }
            if (n == 0)
            {
                MessageBox.Show("太棒啦全对！");
            }
        }

       

        private void Clear_Trash_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(ClearTrash);
            SAV.ReloadSlots();
        }
        private void ClearTrash(PKM pk)
        {
            string temp = pk.OriginalTrainerName;
            pk.OriginalTrainerTrash.Clear();
            pk.OriginalTrainerName = temp;
            temp = pk.HandlingTrainerName;
            pk.HandlingTrainerTrash.Clear();
            pk.HandlingTrainerName = temp;
            temp = pk.Nickname;
            pk.NicknameTrash.Clear();

            ; pk.Nickname = temp;
        }

    
    }
}

