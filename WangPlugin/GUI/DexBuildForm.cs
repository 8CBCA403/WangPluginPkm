using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using PKHeX.Core;
using PKHeX.Core.AutoMod;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using WangPlugin.SortBase;
using WangPlugin.WangUtil.DexBase;

namespace WangPlugin.GUI
{
    partial class DexBuildForm : Form
    {
       
        private static Random rand = new Random();
        public static Stopwatch sw = new();
        public VersionClass version = new VersionClass
        {
            Name = "按照全国图鉴顺序",
            Version = "National",
        };
        public DexModClass mod = new DexModClass
        {
            Name = "一组未知图腾",
            Value = "Unown",
        };
        private LanguageBoxSelect7 type7 = LanguageBoxSelect7.ENG;
        private LanguageBoxSelect type = LanguageBoxSelect.ENG;

        public List<VersionClass> L = new();
        public List<DexModClass> ML = new();
       
        private OT_Gender typeG = OT_Gender.Male;
        private  ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        enum LanguageBoxSelect
        {
            JPN,
            ENG,
            FRE,
            ITA,
            GRE,
            ESP,
        }
        enum LanguageBoxSelect7
        {
            JPN,
            ENG,
            FRE,
            ITA,
            GRE,
            ESP,
            KOR,
            CHS,
            CHT,
        }
        enum OT_Gender
        {
            Male,
            Female,
        }
      
        public DexBuildForm(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            BindingData(SAV);
        }
        private void BindingData(ISaveFileProvider sav)
        {
            if (sav.SAV.Version is GameVersion.SN or GameVersion.MN or GameVersion.US or GameVersion.UM or
                GameVersion.GP or GameVersion.GE or GameVersion.SW or GameVersion.SH or GameVersion.PLA or GameVersion.BD or GameVersion.SP)
            {
                this.LanguageBox.DataSource = Enum.GetNames(typeof(LanguageBoxSelect7));
                this.GenderBox.DataSource = Enum.GetNames(typeof(OT_Gender));
                this.LanguageBox.SelectedIndexChanged += (_, __) =>
                {
                    type7 = (LanguageBoxSelect7)Enum.Parse(typeof(LanguageBoxSelect7), this.LanguageBox.SelectedItem.ToString(), false);
                };
            }
            else
            {
                this.LanguageBox.DataSource = Enum.GetNames(typeof(LanguageBoxSelect));
                this.GenderBox.DataSource = Enum.GetNames(typeof(OT_Gender));
                this.LanguageBox.SelectedIndexChanged += (_, __) =>
                {
                    type = (LanguageBoxSelect)Enum.Parse(typeof(LanguageBoxSelect), this.LanguageBox.SelectedItem.ToString(), false);
                };

            }
            this.GenderBox.SelectedIndexChanged += (_, __) =>
            {
                typeG = (OT_Gender)Enum.Parse(typeof(OT_Gender), this.GenderBox.SelectedItem.ToString(), false);
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
                version =(VersionClass) this.SortBox.SelectedItem;
            };

            ML = DexModClass.DexModList(sav);
            var bindingSource2 = new BindingSource();
            bindingSource2.DataSource = ML;
            Mod_Select_Box.DataSource = bindingSource2.DataSource;
            Mod_Select_Box.DisplayMember = "Name";
            Mod_Select_Box.ValueMember = "Value";
            this.Mod_Select_Box.SelectedIndexChanged += (_, __) =>
            {
                mod = (DexModClass)this.Mod_Select_Box.SelectedItem;
            };
        }
       
        private int GetLanguageBox7()
        {
            var T = 1;
            switch (type7)
            {
                case LanguageBoxSelect7.JPN:
                    T = 1;
                    break;
                case LanguageBoxSelect7.ENG:
                    T = 2;
                    break;
                case LanguageBoxSelect7.FRE:
                    T = 3;
                    break;
                case LanguageBoxSelect7.ITA:
                    T = 4;
                    break;
                case LanguageBoxSelect7.GRE:
                    T = 5;
                    break;
                case LanguageBoxSelect7.ESP:
                    T = 7;
                    break;
                case LanguageBoxSelect7.KOR:
                    T = 8;
                    break;
                case LanguageBoxSelect7.CHS:
                    T = 9;
                    break;
                case LanguageBoxSelect7.CHT:
                    T = 10;
                    break;
            }
            return T;
        }
        private int GetLanguageBox()
        {
            var T = 1;
            switch (type)
            {
                case LanguageBoxSelect.JPN:
                    T = 1;
                    break;
                case LanguageBoxSelect.ENG:
                    T = 2;
                    break;
                case LanguageBoxSelect.FRE:
                    T = 3;
                    break;
                case LanguageBoxSelect.ITA:
                    T = 4;
                    break;
                case LanguageBoxSelect.GRE:
                    T = 5;
                    break;
                case LanguageBoxSelect.ESP:
                    T = 7;
                    break;
            }
            return T;
        }
        private int GetGender()
        {
            var T = 0;
            switch (typeG)
            {
                case OT_Gender.Male:
                    T = 0;
                    break;
                case OT_Gender.Female:
                    T = 1;
                    break;
            }
            return T;
        }
        public void Gen(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.ModifyBoxes(SetID);
            SaveFileEditor.ReloadSlots();
        }
        public void SetID(PKM pkm)
        {
            var TID = Int32.Parse(TIDBox.Text);
            var SID = Int32.Parse(SIDBox.Text);
            var Name = OT_Name.Text;
            
            if (SAV.SAV.Version is GameVersion.SN or GameVersion.MN or GameVersion.US or GameVersion.UM or
                 GameVersion.GP or GameVersion.GE or GameVersion.SW or GameVersion.SH or GameVersion.PLA or GameVersion.BD or GameVersion.SP)
                pkm.Language=GetLanguageBox7();
            else
                pkm.Language = GetLanguageBox();
            pkm.OT_Name = Name;
            if (SAV.SAV.Version is GameVersion.SN or GameVersion.MN or GameVersion.US or GameVersion.UM or
               GameVersion.GP or GameVersion.GE or GameVersion.SW or GameVersion.SH or GameVersion.PLA or GameVersion.BD or GameVersion.SP)
            {
                pkm.TrainerID7 = TID;
                pkm.TrainerSID7 = SID;
            }
            else
            {
                pkm.TID = TID;
                pkm.SID = SID;
                
            }
            pkm.OT_Gender = GetGender();
            pkm.ClearNickname();
        }
        public void UnionPKM(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            var a = sav.GetAllPKM();
            var pkms = sav.GenerateLivingDex(out int attempts).ToList();
            foreach (var item in a)
            {
                var pk=pkms.Find(x => x.Species==item.Species);
                pkms.Remove(pk);
            }
            var o = a.Union(pkms);
            o=o.OrderBySpecies();
            var bd = sav.BoxData;
            o.CopyTo(bd);
            sav.BoxData = bd;
            SaveFileEditor.ReloadSlots();
        }
        public void LivingDex(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            var pkms = sav.GenerateLivingDex(out int attempts);
            var bd = sav.BoxData;
            pkms.CopyTo(bd);
            sav.BoxData = bd;
            SaveFileEditor.ReloadSlots();
        }
        public static void LegalBox(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.LegalizeBox(sav.CurrentBox);
        }
        public static void LegalAll(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.LegalizeBoxes();
        }
        public static void ClearPKM(PKM pkm)
        {
            pkm.Species = 0;
        }
        public  void RandomPKMPID(PKM pkm)
        {
            pkm.PID=Util.Rand32();
           
        }
        public void RandomPKMEC(PKM pkm)
        {
            pkm.SetRandomEC();
        }
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
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
            }
            MessageBox.Show("排序完成", "SuperWang");
        }
        private void DeleteBox_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(ClearPKM,SAV.CurrentBox,SAV.CurrentBox);
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
                    PKL=GastrodonDex.GastrodonSets(SAV, Editor);
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
            LegalBox(SAV);
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
                    pk.OT_Name = RandomString(6);
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

        private void RandomEC_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(RandomPKMEC);
            SAV.ReloadSlots();
        }
    }
}
