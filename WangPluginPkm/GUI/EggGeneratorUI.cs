using System;
using PKHeX.Core.Searching;
using PKHeX.Core;
using PKHeX.Core.AutoMod;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
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
        else if(B==BOX.BOX)
            SetBox();
        }
        public  PKM Egg(PKM pk, ISaveFileProvider SaveFileEditor)
        {
            List<IEncounterInfo> Results;
            IEncounterInfo enc;
            PKM pkm = pk.Clone();
            PKM pko = pk.Clone();
            var tree = EvolutionTree.GetEvolutionTree(pk.Context);
            var PE = tree.GetPreEvolutions(pk.Species,pk.Form);
            if (PE.Count() != 0)
            {
                var PreSpecies =PE.First();
                pk.Species = PreSpecies.Species;
            }
            var setting = new SearchSettings
            {
                Species = pk.Species,
                SearchEgg = true,
                Version = (int)SaveFileEditor.SAV.Version,
            };
            var search = EncounterUtil.SearchDatabase(setting, SaveFileEditor.SAV);
            var results = search.ToList();
            if (results.Count != 0)
            {
                Results = results;
                enc = Results[0];
                var criteria = EncounterUtil.GetCriteria(enc, pkm);
                pkm = enc.ConvertToPKM(SaveFileEditor.SAV, criteria);
                pk = pkm;
                pk.IsEgg = true;
                pk.DisplayTID = SaveFileEditor.SAV.DisplayTID;
                pk.DisplaySID = SaveFileEditor.SAV.DisplaySID;
                pk.OT_Gender = SaveFileEditor.SAV.Gender;
                if (Gender_CheckBox.Checked)
                    pk.Gender = pko.Gender;
                if(Form_CheckBox.Checked)
                    pk.Form = pko.Form;
                if (RelearnMovcheckBox.Checked)
                {
                    pk.RelearnMoves = pko.RelearnMoves;
                    pk.Moves = pko.RelearnMoves;
                    pk.HealPP();
                }
                pk.CurrentHandler = 0;
                pk.Nature = pko.Nature;
                pk.IVs = pko.IVs;
                if (pk.Gen2 == true)
                {
                    if (pko.IsShiny == true)
                        pk.SetShiny();
                    pk.Nickname = "EGG";
                    pk.Met_Location = 0;
                }
                else if (pk.Gen3 == true)
                {
                    if (pko.IsShiny == true)
                        pk.SetShiny();
                    pk.IsNicknamed = true;
                    pk.Nickname = "タマゴ";
                    pk.RefreshAbility((int)(pk.PID & 1));
                    if (pko.Ball is 7 or 11 or 8 or 6 or 12 or 9 or 10 or 5)
                    {
                        pk.Ball = 4;
                    }
                    if (pk.Version == 4 || pk.Version == 5)
                    {
                        pk.Met_Location = 146;
                    }
                    else
                    {
                        pk.Met_Location = 32;
                    }
                }
                else if (pk.Gen4 == true)
                {
                    if (pko.Ball is 17 or 18 or 19 or 20 or 21 or 22 or 23)
                    {
                        pk.Ball = pko.Ball;
                    }
                    pk.OT_Name = SaveFileEditor.SAV.OT;
                    pk.Language = pko.Language;
                    if (pko.IsShiny == true)
                        pk.SetShiny();
                    if (pk.Language == 1)
                    {
                        pk.Nickname = "タマゴ";
                    }
                    if (pk.Language == 2)
                    {
                        pk.Nickname = "Egg";
                    }
                    pk.RefreshAbility((int)(pk.PID & 1));
                    pk.Egg_Location = 2000;
                    pk.Met_Location = 0;
                }
                else if (pk.Gen5 == true)
                {
                    pk.OT_Name = SaveFileEditor.SAV.OT;
                    pk.Language = pko.Language;
                    pk.PID = pko.PID;
                    pk.IsNicknamed = true;
                    if (pk.Language == 1)
                    {
                        pk.Nickname = "タマゴ";
                    }
                    if (pk.Language == 2)
                    {
                        pk.Nickname = "Egg";
                    }
                    pk.Egg_Location = 60002;
                    pk.Met_Location = 0;
                    pk.RefreshAbility((int)(pk.PID >> 16 & 1));
                }
                else if (pk.Gen6 == true)
                {
                    pk.Ability = pko.Ability;
                    pk.OT_Name = SaveFileEditor.SAV.OT;
                    pk.Language = pko.Language;
                    pk.PID = pko.PID;
                    pk.Ball = pko.Ball;
                    pk.IsNicknamed = true;
                    if (pko.Ball is 16 or 25 or 17 or 18 or 19 or 20 or 21 or 22 or 23 or 24)
                    {
                        pk.Ball = 4;
                    }
                    if (pk.Language == 2)
                    {
                        pk.Nickname = "Egg";
                    }
                    pk.Egg_Location = 60002;
                    pk.Met_Location = 0;
                }
                else if (pk.Gen7 == true)
                {
                    if (Ability_CheckBox.Checked)
                    {
                        pk.Ability = pko.Ability;
                    }
                    pk.OT_Name = SaveFileEditor.SAV.OT;
                    pk.Language = pko.Language;
                    pk.PID = pko.PID;
                    pk.Ball = pko.Ball;
                    if (pko.Ball is 16 or 24)
                        pk.Ball = 4;
                    pk.IsNicknamed = true;
                    if (pk.Language == 10 || pk.Language == 9)
                    {
                        pk.Nickname = "蛋";
                    }
                    if (pk.Language == 2)
                    {
                        pk.Nickname = "Egg";
                    }
                    pk.Egg_Location = 60002;
                    pk.Met_Location = 0;

                }
                else if (pk.Gen8 == true)
                {
                if (Ability_CheckBox.Checked)
                {
                pk.Ability = pko.Ability;
                }
                pk.OT_Name = SaveFileEditor.SAV.OT;
                pk.Language = pko.Language;
                pk.PID = pko.PID;
                pk.Ball = pko.Ball;
                if (pko.Ball is 16 or 24)
                    pk.Ball = 4;
                pk.IsNicknamed = true;
                if (pk.Language == 10 || pk.Language == 9)
                {
                    pk.Nickname = "蛋";
                }
                if (pk.Language == 2)
                {
                    pk.Nickname = "Egg";
                }
                pk.Egg_Location = 60002;
                if (pk.Version == 49 || pk.Version == 48)
                {
                    pk.Egg_Location = 60010;
                }
                pk.Met_Location = 0;
                if (pk.Version == 49 || pk.Version == 48)
                {
                    pk.Met_Location = 65535;
                }
                }
                else if(pk.Gen9==true)
                {
                    pk.IsNicknamed=true;
                    if (pk.Language == 10 || pk.Language == 9)
                    {
                        pk.Nickname = "蛋";
                    }
                    if (pk.Language == 2)
                    {
                        pk.Nickname = "Egg";
                    }
                    pk.Version = 0;
                    pk.Met_Location = 0;
                    pk.StatNature = pk.Nature;
                }
                pk.OT_Friendship = 1;
                pk.RefreshChecksum();
                pk.SetBoxForm();
              
                return pk;
            }
            else
            {
                return pk;
            }
        }
        public void SetBox()
        {
        int n = SAV.CurrentBox;
        PKM[] PKL = SAV.SAV.GetBoxData(n);
        for (int i = 0; i < PKL.Count(); i++)
        {
        var pk = PKL[i];
        PKL[i] = Egg(pk, SAV); 
        }
        if (PKL.Count() != 0)
        {
           SAV.SAV.SetBoxData(PKL, n);
        }
           SAV.ReloadSlots();
        }
        public void SetOne()
        {
            var pk = Editor.Data;
            pk = Egg(pk, SAV);
            Editor.PopulateFields(pk);
        }
    }
}
