using System;
using PKHeX.Core.Searching;
using PKHeX.Core;
using PKHeX.Core.AutoMod;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
namespace WangPlugin.GUI
{
    internal class EggGeneratorUI : Form
    {
        private TextBox Version;
        private ComboBox Number_Box;
        public enum BOX
        {
            [Description("生成面板")]
            ONE,
            [Description("生成一箱")]
            BOX,
        }
        public BOX B = BOX.ONE;
        private CheckBox Form_CheckBox;
        private CheckBox Gender_CheckBox;
        private CheckBox Ability_CheckBox;

        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        private Button GEgg;
        public EggGeneratorUI(ISaveFileProvider sav, IPKMView editor)
        {
            InitializeComponent();
            BindingData();
            SAV = sav;
            Editor = editor;
            Version.Text = $"Version:{SAV.SAV.Version}";
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EggGeneratorUI));
            this.GEgg = new System.Windows.Forms.Button();
            this.Version = new System.Windows.Forms.TextBox();
            this.Number_Box = new System.Windows.Forms.ComboBox();
            this.Form_CheckBox = new System.Windows.Forms.CheckBox();
            this.Gender_CheckBox = new System.Windows.Forms.CheckBox();
            this.Ability_CheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // GEgg
            // 
            this.GEgg.Font = new System.Drawing.Font("黑体", 9F);
            this.GEgg.Location = new System.Drawing.Point(249, 12);
            this.GEgg.Name = "GEgg";
            this.GEgg.Size = new System.Drawing.Size(104, 28);
            this.GEgg.TabIndex = 0;
            this.GEgg.Text = "生成蛋";
            this.GEgg.UseVisualStyleBackColor = true;
            this.GEgg.Click += new System.EventHandler(this.GEgg_Click);
            // 
            // Version
            // 
            this.Version.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Version.Location = new System.Drawing.Point(21, 12);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(95, 28);
            this.Version.TabIndex = 1;
            this.Version.Text = "No Save";
            // 
            // Number_Box
            // 
            this.Number_Box.FormattingEnabled = true;
            this.Number_Box.Location = new System.Drawing.Point(122, 13);
            this.Number_Box.Name = "Number_Box";
            this.Number_Box.Size = new System.Drawing.Size(121, 25);
            this.Number_Box.TabIndex = 2;
            // 
            // Form_CheckBox
            // 
            this.Form_CheckBox.AutoSize = true;
            this.Form_CheckBox.Location = new System.Drawing.Point(21, 47);
            this.Form_CheckBox.Name = "Form_CheckBox";
            this.Form_CheckBox.Size = new System.Drawing.Size(126, 21);
            this.Form_CheckBox.TabIndex = 3;
            this.Form_CheckBox.Text = "保持地区形态";
            this.Form_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Gender_CheckBox
            // 
            this.Gender_CheckBox.AutoSize = true;
            this.Gender_CheckBox.Location = new System.Drawing.Point(142, 47);
            this.Gender_CheckBox.Name = "Gender_CheckBox";
            this.Gender_CheckBox.Size = new System.Drawing.Size(94, 21);
            this.Gender_CheckBox.TabIndex = 4;
            this.Gender_CheckBox.Text = "保持性别";
            this.Gender_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Ability_CheckBox
            // 
            this.Ability_CheckBox.AutoSize = true;
            this.Ability_CheckBox.Location = new System.Drawing.Point(242, 47);
            this.Ability_CheckBox.Name = "Ability_CheckBox";
            this.Ability_CheckBox.Size = new System.Drawing.Size(94, 21);
            this.Ability_CheckBox.TabIndex = 5;
            this.Ability_CheckBox.Text = "保持特性";
            this.Ability_CheckBox.UseVisualStyleBackColor = true;
            // 
            // EggGeneratorUI
            // 
            this.ClientSize = new System.Drawing.Size(373, 74);
            this.Controls.Add(this.Ability_CheckBox);
            this.Controls.Add(this.Gender_CheckBox);
            this.Controls.Add(this.Form_CheckBox);
            this.Controls.Add(this.Number_Box);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.GEgg);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EggGeneratorUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);
            this.PerformLayout();

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
           // if (Egg(Editor.Data, Editor, SAV))
           //   MessageBox.Show($"Success!", "SuperWang");
           // else
           //   MessageBox.Show($"Can't Convert to Egg!", "SuperWang");
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
                pk.TrainerID7 = SaveFileEditor.SAV.TrainerID7;
                pk.TrainerSID7 = SaveFileEditor.SAV.TrainerSID7;
                pk.OT_Gender = SaveFileEditor.SAV.Gender;
                if (Gender_CheckBox.Checked)
                    pk.Gender = pko.Gender;
                if(Form_CheckBox.Checked)
                    pk.Form = pko.Form;
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
        //    MessageBox.Show( $"{PKL.Count()}");
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
