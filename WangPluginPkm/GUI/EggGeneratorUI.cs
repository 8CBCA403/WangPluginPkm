using PKHeX.Core;
using PKHeX.Core.AutoMod;
using PKHeX.Core.Searching;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
namespace WangPluginPkm.GUI
{
    partial class EggGeneratorUI : Form
    {

        public enum BOX
        {
            [Description("生成面板")]
            ONE,
            [Description("生成一箱")]
            BOX,
        }
        public BOX B = BOX.ONE;


        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }

        public EggGeneratorUI(ISaveFileProvider sav, IPKMView editor)
        {
            InitializeComponent();
            BindingData();
            SAV = sav;
            Editor = editor;
            Version.Text = $"Version:{SAV.SAV.Version}";
        }

        private void BindingData()
        {
            Number_Box.DisplayMember = "Description";
            Number_Box.ValueMember = "Value";
            Number_Box.DataSource = Enum.GetValues(typeof(BOX))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            this.Number_Box.SelectedIndexChanged += (_, __) =>
            {
                B = (BOX)Enum.Parse(typeof(BOX), this.Number_Box.SelectedValue.ToString(), false);
            };
            // this.Number_Box.SelectedIndex = 0;
        }
        private void GEgg_Click(object sender, EventArgs e)
        {
            if (B == BOX.ONE)
                SetOne();
            else if (B == BOX.BOX)
                SetBox();
        }

        private static void SetEggNicknameByLanguage(PKM pk)
        {
            // 1: 日文, 2: 英文, 9: 繁中, 10: 简中
            switch (pk.Language)
            {
                case 1:
                    pk.Nickname = "タマゴ";
                    break;
                case 2:
                    pk.Nickname = "Egg";
                    break;
                case 9:
                case 10:
                    pk.Nickname = "蛋";
                    break;
                default:
                    // fallback 英文
                    pk.Nickname = "Egg";
                    break;
            }
        }

        private static void CopyIVsAndNature(PKM dest, PKM src)
        {
            dest.Nature = src.Nature;
            Span<int> ivs = stackalloc int[6];
            src.GetIVs(ivs);
            dest.SetIVs(ivs);
        }

        private static void SetOTAndTrainerProps(PKM pk, ISaveFileProvider sav)
        {
            pk.OriginalTrainerName = sav.SAV.OT;
            pk.DisplayTID = (ushort)sav.SAV.DisplayTID;
            pk.DisplaySID = (ushort)sav.SAV.DisplaySID;
            pk.OriginalTrainerGender = (byte)sav.SAV.Gender;
        }

        public PKM Egg(PKM pk, ISaveFileProvider SaveFileEditor)
        {
            if (pk == null || pk.Species < 1)
                return pk;

            // Preserve a copy for attribute reuse
            PKM pko = pk.Clone();

            // Use pre-evolution if exists
            var tree = EvolutionTree.GetEvolutionTree(pk.Context);
            var PE = tree.GetEvolutionsAndPreEvolutions(pk.Species, pk.Form);
            if (PE.Any())
            {
                var pre = PE.First();
                pk.Species = pre.Species;
            }

            var setting = new SearchSettings
            {
                Species = pk.Species,
                SearchEgg = true,
                Version = SaveFileEditor.SAV.Version,
            };
            var results = EncounterUtil.SearchDatabase(setting, SaveFileEditor.SAV).ToList();
            if (results.Count == 0)
                return pko; // 无法生成蛋，返回原 Pokémon

            var enc = results[0];
            var criteria = EncounterUtil.GetCriteria(enc, pk);
            var pkm = enc.ConvertToPKM(SaveFileEditor.SAV, criteria);

            // Common egg setup
            pkm.IsEgg = true;
            SetOTAndTrainerProps(pkm, SaveFileEditor);

            // Optional carries from original
            if (Gender_CheckBox.Checked)
                pkm.Gender = pko.Gender;
            if (Form_CheckBox.Checked)
                pkm.Form = pko.Form;
            if (RelearnMovcheckBox.Checked)
            {
                pkm.RelearnMoves = pko.RelearnMoves;
                pkm.Moves = pko.RelearnMoves;
                pkm.HealPP();
            }
            if (Ability_CheckBox.Checked && (pkm.Gen7 || pkm.Gen8 || pkm.Gen6))
            {
                pkm.Ability = pko.Ability;
            }

            pkm.CurrentHandler = 0;
            CopyIVsAndNature(pkm, pko);

            // Per-generation specifics
            if (pkm.Generation == 2)
            {
                ((PK2)pkm).OriginalTrainerName = "1"; // keeps legacy behavior
                pkm.MetLevel = 1;
                ((PK2)pkm).MetTimeOfDay = 1;
                if (pko.IsShiny)
                    pkm.SetShiny();
                pkm.IsNicknamed = true;
                SetEggNicknameByLanguage(pkm);
                pkm.MetLocation = 0;
            }
            else if (pkm.Gen3)
            {
                if (pko.IsShiny)
                    pkm.SetShiny();
                pkm.IsNicknamed = true;
                pkm.Nickname = "タマゴ"; // keep old behavior for Gen3
                pkm.RefreshAbility((int)(pkm.PID & 1));
                // Illegal balls fallback -> Poké Ball
                if (pko.Ball is 7 or 11 or 8 or 6 or 12 or 9 or 10 or 5)
                    pkm.Ball = 4;
                pkm.MetLocation = (ushort)((pkm.Version is (GameVersion)4 or (GameVersion)5) ? 146 : 32);
            }
            else if (pkm.Gen4)
            {
                if (pko.Ball is 17 or 18 or 19 or 20 or 21 or 22 or 23)
                    pkm.Ball = pko.Ball;
                pkm.Language = pko.Language;
                if (pko.IsShiny)
                    pkm.SetShiny();
                pkm.IsNicknamed = true;
                SetEggNicknameByLanguage(pkm);
                pkm.RefreshAbility((int)(pkm.PID & 1));
                pkm.EggLocation = (ushort)2000;
                pkm.MetLocation = 0;
            }
            else if (pkm.Gen5)
            {
                pkm.Language = pko.Language;
                pkm.PID = pko.PID;
                pkm.IsNicknamed = true;
                SetEggNicknameByLanguage(pkm);
                pkm.EggLocation = (ushort)60002;
                pkm.MetLocation = 0;
                pkm.RefreshAbility((int)((pkm.PID >> 16) & 1));
            }
            else if (pkm.Gen6)
            {
                pkm.OriginalTrainerName = SaveFileEditor.SAV.OT;
                pkm.Language = pko.Language;
                pkm.PID = pko.PID;
                pkm.Ball = pko.Ball;
                if (pko.Ball is 16 or 25 or 17 or 18 or 19 or 20 or 21 or 22 or 23 or 24)
                    pkm.Ball = 4;
                pkm.IsNicknamed = true;
                SetEggNicknameByLanguage(pkm);
                ((PK6)pkm).FixMemories();
                ((PK6)pkm).RefreshAbility(pkm.AbilityNumber);
                pkm.EggLocation = (ushort)60002;
                pkm.MetLocation = 0;
            }
            else if (pkm.Gen7)
            {
                pkm.Language = pko.Language;
                pkm.PID = pko.PID;
                pkm.Ball = pko.Ball;
                if (pko.Ball is 16 or 24)
                    pkm.Ball = 4;
                pkm.IsNicknamed = true;
                SetEggNicknameByLanguage(pkm);
                pkm.EggLocation = (ushort)60002;
                pkm.MetLocation = 0;
            }
            else if (pkm.Gen8 && pkm.Version != GameVersion.PLA)
            {
                pkm.Language = pko.Language;
                pkm.PID = pko.PID;
                pkm.Ball = pko.Ball;
                if (pko.Ball is 16 or 24)
                    pkm.Ball = 4;
                pkm.IsNicknamed = true;
                SetEggNicknameByLanguage(pkm);
                pkm.EggLocation = (ushort)((pkm.Version is (GameVersion)49 or (GameVersion)48) ? 60010 : 60002);
                pkm.MetLocation = (ushort)((pkm.Version is (GameVersion)49 or (GameVersion)48) ? 65535 : 0);
            }
            else if (pkm.Gen9 && SAV.SAV.Version != GameVersion.ZA)
            {
                pkm.IsNicknamed = true;
                SetEggNicknameByLanguage(pkm);
                pkm.Version = 0;
                pkm.MetLocation = 0;
                pkm.StatNature = pkm.Nature;
            }

            pkm.OriginalTrainerFriendship = 1;
            pkm.RefreshChecksum();
            pkm.SetBoxForm();

            return pkm;
        }
        public void SetBox()
        {
            int n = SAV.CurrentBox;
            PKM[] PKL = SAV.SAV.GetBoxData(n);
            for (int i = 0; i < PKL.Length; i++)
            {
                var pk = PKL[i];
                if (pk == null || pk.Species < 1)
                    continue;
                PKL[i] = Egg(pk, SAV);
            }
            if (PKL.Length != 0)
            {
                SAV.SAV.SetBoxData(PKL, n);
            }
            SAV.ReloadSlots();
        }
        public void SetOne()
        {
            var pk = Editor?.Data;
            if (pk == null)
                return;
            pk = Egg(pk, SAV);
            Editor.PopulateFields(pk);
        }
    }
}
