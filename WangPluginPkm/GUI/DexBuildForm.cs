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
using static WangPluginPkm.PluginUtil.Functions.DexBuildFunctions;
using static WangPluginPkm.PluginUtil.PluginEnums.GUIEnums;

namespace WangPluginPkm.GUI
{
    partial class DexBuildForm : Form
    {
        public static GameStrings GameStringsZh = GameInfo.GetStrings("zh-Hans");
        private static readonly Random rand = new();
        public static readonly Stopwatch sw = new();
        private readonly SoundPlayer Player = new();
        public VersionClass version = new()
        {
            Name = "按照全国图鉴顺序",
            Version = "National",
        };
        public DexModClass mod = new()
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
                    type7 = (DexFormLanguage7)Enum.Parse(typeof(DexFormLanguage7), this.LanguageBox.SelectedItem!.ToString()!, false);
                };
            }
            else
            {
                this.LanguageBox.DataSource = Enum.GetNames(typeof(DexFormLanguage5));
                this.GenderBox.DataSource = Enum.GetNames(typeof(DexFormOTGender));
                this.LanguageBox.SelectedIndexChanged += (_, __) =>
                {
                    type5 = (DexFormLanguage5)Enum.Parse(typeof(DexFormLanguage5), this.LanguageBox.SelectedItem!.ToString()!, false);
                };

            }
            this.GenderBox.SelectedIndexChanged += (_, __) =>
            {
                typeG = (DexFormOTGender)Enum.Parse(typeof(DexFormOTGender), this.GenderBox.SelectedItem!.ToString()!, false);
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
                version = (VersionClass)this.SortBox.SelectedItem!;
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
                mod = (DexModClass)this.Mod_Select_Box.SelectedItem!;
                FormAndSubDex_BTN.Enabled = mod.Value != "None";
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
            // Preserve original in case we need to revert
            var original = new
            {
                pkm.TID16,
                pkm.SID16,
                pkm.TrainerTID7,
                pkm.TrainerSID7,
                pkm.OriginalTrainerName,
                pkm.Language,
                pkm.OriginalTrainerGender
            };

            uint tidParsed = 0, sidParsed = 0;
            _ = uint.TryParse(TID16Box.Text, out tidParsed);
            _ = uint.TryParse(SID16Box.Text, out sidParsed);
            var name = OriginalTrainerName.Text ?? string.Empty;

            if (VersionFlag.ID7Flag(SAV.SAV.Version))
                pkm.Language = GetLanguageBox7(type7);
            else
                pkm.Language = GetLanguageBox5(type5);

            pkm.OriginalTrainerName = name;

            if (VersionFlag.ID7Flag(SAV.SAV.Version))
            {
                pkm.TrainerTID7 = tidParsed;
                pkm.TrainerSID7 = sidParsed;
            }
            else
            {
                pkm.TID16 = (ushort)tidParsed;
                pkm.SID16 = (ushort)sidParsed;
            }

            var la = new LegalityAnalysis(pkm);
            if (la.Valid)
            {
                pkm.OriginalTrainerGender = (byte)GetGender(typeG);
            }
            else
            {
                // Revert all changes
                if (VersionFlag.ID7Flag(SAV.SAV.Version))
                {
                    pkm.TrainerTID7 = original.TrainerTID7;
                    pkm.TrainerSID7 = original.TrainerSID7;
                }
                else
                {
                    pkm.TID16 = original.TID16;
                    pkm.SID16 = original.SID16;
                }
                pkm.OriginalTrainerName = original.OriginalTrainerName;
                pkm.Language = original.Language;
                pkm.OriginalTrainerGender = (byte)original.OriginalTrainerGender;
            }

            pkm.ClearNickname();
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

        private int FillIntoFirstEmptySlots(IEnumerable<PKM> pks)
        {
            var boxData = SAV.SAV.BoxData;
            List<int> empty = FindAllEmptySlots(boxData, 0);
            int placed = 0;
            using var e1 = pks.GetEnumerator();
            using var e2 = empty.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext())
            {
                SAV.SAV.SetBoxSlotAtIndex(e1.Current, e2.Current);
                placed++;
            }
            return placed;
        }

        private void OverwriteFromStart(IList<PKM> pks)
        {
            SAV.SAV.ModifyBoxes(ClearPKM);
            for (int i = 0; i < pks.Count; i++)
                SAV.SAV.SetBoxSlotAtIndex(pks[i], i);
            SAV.ReloadSlots();
        }

        private static Func<PKM, IComparable>[]? GetSortFunctionsByVersion(string v) => v switch
        {
            "RYBG" => Gen1_Kanto.GetSortFunctions(),
            "GS" => Gen2_Johto.GetSortFunctions(),
            "E" => Gen3_Hoenn.GetSortFunctions(),
            "FRGL" => Gen3_Kanto.GetSortFunctions(),
            "DP" => Gen4_Sinnoh.GetDPSortFunctions(),
            "Platinum" => Gen4_Sinnoh.GetPtSortFunctions(),
            "GHSS" => Gen4_Johto.GetSortFunctions(),
            "BW" => Gen5_Unova.GetBWSortFunctions(),
            "B2W2" => Gen5_Unova.GetB2W2SortFunctions(),
            "XY" => Gen6_Kalos.GetSortFunctions(),
            "ORAS" => Gen6_Hoenn.GetSortFunctions(),
            "SM" => Gen7_Alola.GetFullSMSortFunctions(),
            "USUM" => Gen7_Alola.GetFullUSUMSortFunctions(),
            "LPLE" => Gen7_Kanto.GetSortFunctions(),
            "SWSH" => Gen8_Galar.GetGalarDexSortFunctions(),
            "SWSH1" => Gen8_Galar.GetIoADexSortFunctions(),
            "SWSH2" => Gen8_Galar.GetCTDexSortFunction(),
            "SWSH3" => Gen8_Galar.GetFullGalarDexSortFunctions(),
            "BDSP" => Gen8_Sinnoh.GetSortFunctions(),
            "PLA" => Gen8_Hisui.GetSortFunctions(),
            "SV" => Gen9__Paldea.GetSortFunctions(),
            _ => null
        };

        private static void RunTimed(string label, Action action)
        {
            sw.Start();
            action();
            sw.Stop();
            MessageBox.Show($"搞定啦！用时：{sw.ElapsedMilliseconds}毫秒", label);
            sw.Reset();
        }

        private void Gen_BTN_Click(object sender, EventArgs e)
        {
            Gen(SAV);
            SAV.ReloadSlots();
            MessageBox.Show("搞定了！");

        }
        private void BuildDex_BTN_Click(object sender, EventArgs e)
        {
            RunTimed("SuperWang", () => UnionPKM(SAV));
        }
        private void LivingDex_BTN_Click(object sender, EventArgs e)
        {
            RunTimed("SuperWang", () => LivingDex(SAV));
        }
        private void Legal_BTN_Click(object sender, EventArgs e)
        {
            LegalBox(SAV);
            SAV.ReloadSlots();
            MessageBox.Show("搞定啦");
        }
        private void LegalAll_BTN_Click(object sender, EventArgs e)
        {
            RunTimed("SuperWang", () =>
            {
                LegalAll(SAV);
                SAV.ReloadSlots();
            });
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
            if (version.Version == "National")
                SortByNationalDex();
            else
            {
                var fns = GetSortFunctionsByVersion(version.Version);
                if (fns != null)
                    SortByRegionalDex(fns);
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

            if (PKL.Count > 0)
                FillIntoFirstEmptySlots(PKL);
            SAV.ReloadSlots();
        }
        private void RandomEC_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(RandomPKMEC);
            SAV.ReloadSlots();
        }

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
                    SAV.SAV.SetBoxSlotAtIndex(prevMon, boxIndex, EntityImportSettings.None);
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
                                RunTimed("SuperWang", () => LivingDexHome(SAV));
                            }
                            else
                            {
                                MessageBox.Show("版本不对！");
                            }
                            break;
                        case 1:
                            if (SAV.SAV.Version == GameVersion.SW || SAV.SAV.Version == GameVersion.SH)
                            {
                                RunTimed("SuperWang", () =>
                                {
                                    LivingDexHome(SAV);
                                    IEnumerable<PKM> sortMethod(IEnumerable<PKM> pkms, int i) => pkms.OrderByCustom(Gen8_Galar.GetGalarDexSortFunctions());
                                    SAV.SAV.SortBoxes(0, -1, sortMethod);
                                    var list = SAV.SAV.GetAllPKM().ToList().Take(400).ToList();
                                    OverwriteFromStart(list);
                                });
                            }
                            else
                            {
                                MessageBox.Show("版本不对！");
                            }
                            break;
                        case 2:
                            if (SAV.SAV.Version == GameVersion.SW || SAV.SAV.Version == GameVersion.SH)
                            {
                                RunTimed("SuperWang", () =>
                                {
                                    LivingDexHome(SAV);
                                    IEnumerable<PKM> sortMethod(IEnumerable<PKM> pkms, int i) => pkms.OrderByCustom(Gen8_Galar.GetIoADexSortFunctions());
                                    SAV.SAV.SortBoxes(0, -1, sortMethod);
                                    var list = SAV.SAV.GetAllPKM().ToList().Take(211).ToList();
                                    OverwriteFromStart(list);
                                });
                            }
                            else
                            {
                                MessageBox.Show("版本不对！");
                            }
                            break;
                        case 3:
                            if (SAV.SAV.Version == GameVersion.SW || SAV.SAV.Version == GameVersion.SH)
                            {
                                RunTimed("SuperWang", () =>
                                {
                                    LivingDexHome(SAV);
                                    IEnumerable<PKM> sortMethod(IEnumerable<PKM> pkms, int i) => pkms.OrderByCustom(Gen8_Galar.GetCTDexSortFunction());
                                    SAV.SAV.SortBoxes(0, -1, sortMethod);
                                    var list = SAV.SAV.GetAllPKM().ToList().Take(210).ToList();
                                    OverwriteFromStart(list);
                                });
                            }
                            else
                            {
                                MessageBox.Show("版本不对！");
                            }
                            break;
                        case 4:
                            if (SAV.SAV.Version == GameVersion.BD || SAV.SAV.Version == GameVersion.SP)
                            {
                                RunTimed("SuperWang", () => LivingDexHome(SAV));
                            }
                            else
                            {
                                MessageBox.Show("版本不对！");
                            }
                            break;
                        case 5:
                            if (SAV.SAV.Version == GameVersion.PLA)
                            {
                                RunTimed("SuperWang", () => LivingDexHome(SAV));
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

            if (PKL.Count != 0)
                FillIntoFirstEmptySlots(PKL);
            SAV.ReloadSlots();
        }
        private void GenDex_BTN_Click(object sender, EventArgs e)
        {
            if (SAV.SAV.Version != GameVersion.US && SAV.SAV.Version != GameVersion.UM)
            {
                MessageBox.Show("本功能只适用于究极日月！");
                return;
            }
            RunTimed("SuperWang", () =>
            {
                var PKL = MutiGenDex.SetAll(SAV, Editor, false);
                FillIntoFirstEmptySlots(PKL);
                SAV.ReloadSlots();
                Player.Stream = Properties.Resources.dex;
                Player.Play();
            });
        }
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
                                var dis = aL.Distinct();
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
                                var Pdis = aL.Distinct();
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
                                var Sdis = aL.Distinct();
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
                                var Cdis = aL.Distinct();
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

