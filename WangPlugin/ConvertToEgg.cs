using System;
using PKHeX.Core.Searching;
using PKHeX.Core;
using PKHeX.Core.AutoMod;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace WangPlugin
{
    internal class ConvertToEgg: Form
    {
        private TextBox Version;
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        private Button GEgg;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConvertToEgg));
            this.GEgg = new System.Windows.Forms.Button();
            this.Version = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // GEgg
            // 
            this.GEgg.Location = new System.Drawing.Point(135, 12);
            this.GEgg.Name = "GEgg";
            this.GEgg.Size = new System.Drawing.Size(104, 28);
            this.GEgg.TabIndex = 0;
            this.GEgg.Text = "GenEgg";
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
            // ConvertToEgg
            // 
            this.ClientSize = new System.Drawing.Size(251, 57);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.GEgg);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConvertToEgg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void GEgg_Click(object sender, EventArgs e)
        {
            if(Egg(Editor.Data, Editor, SAV))
                MessageBox.Show($"Success!", "SuperWang");
            else
                MessageBox.Show($"Can't Convert to Egg!", "SuperWang");
        }
        public ConvertToEgg(ISaveFileProvider sav, IPKMView editor)
        {
            InitializeComponent();
            SAV = sav;
            Editor = editor;
            Version.Text = $"Version:{SAV.SAV.Version}";
        }
        public static bool Egg(PKM pk, IPKMView PKMEditor, ISaveFileProvider SaveFileEditor)
        {
            List<IEncounterInfo> Results ;
            IEncounterInfo enc;
            PKM pkm = PKMEditor.Data;
            PKM pko = PKMEditor.Data;
            var tree = EvolutionTree.GetEvolutionTree(PKMEditor.Data.Context);
            var PE = tree.GetPreEvolutions(PKMEditor.Data.Species, PKMEditor.Data.Form);
            if (PE.Count() != 0)
            {
                int PreSpecies = PE.First();
                pk.Species = PreSpecies;

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
                pk.Gender = pko.Gender;
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
                    pk.Ability = pko.Ability;
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
                    pk.Ability = pko.Ability;
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
                PKMEditor.Data.SetBoxForm();
                PKMEditor.PopulateFields(pk, false);
                SaveFileEditor.ReloadSlots();
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
