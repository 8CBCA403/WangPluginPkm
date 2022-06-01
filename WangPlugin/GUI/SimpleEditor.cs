using System;
using PKHeX.Core;
using System.Windows.Forms;
using System.Collections.Generic;
using PKHeX.Core.Searching;
using PKHeX.Core.AutoMod;
using System.Linq;

namespace WangPlugin.GUI
{
    internal class SimpleEditor : Form
    {
        private IPKMView Editor { get; }
        private ISaveFileProvider SAV { get; }
        private Button AllRibbon;
        private Button LegalizeReport;
        private Button Master;
        private Button Legal_BTN;
        private Button LegalALL_BTN;
        private Button ClearRecord;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleEditor));
            this.AllRibbon = new System.Windows.Forms.Button();
            this.ClearRecord = new System.Windows.Forms.Button();
            this.LegalizeReport = new System.Windows.Forms.Button();
            this.Master = new System.Windows.Forms.Button();
            this.Legal_BTN = new System.Windows.Forms.Button();
            this.LegalALL_BTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AllRibbon
            // 
            this.AllRibbon.Location = new System.Drawing.Point(25, 26);
            this.AllRibbon.Name = "AllRibbon";
            this.AllRibbon.Size = new System.Drawing.Size(110, 30);
            this.AllRibbon.TabIndex = 0;
            this.AllRibbon.Text = "AllRibbon";
            this.AllRibbon.UseVisualStyleBackColor = true;
            this.AllRibbon.Click += new System.EventHandler(this.AllRibbon_Click);
            // 
            // ClearRecord
            // 
            this.ClearRecord.Location = new System.Drawing.Point(156, 26);
            this.ClearRecord.Name = "ClearRecord";
            this.ClearRecord.Size = new System.Drawing.Size(110, 30);
            this.ClearRecord.TabIndex = 1;
            this.ClearRecord.Text = "ClearRecord";
            this.ClearRecord.UseVisualStyleBackColor = true;
            this.ClearRecord.Click += new System.EventHandler(this.ClearRecord_Click);
            // 
            // LegalizeReport
            // 
            this.LegalizeReport.Location = new System.Drawing.Point(25, 71);
            this.LegalizeReport.Name = "LegalizeReport";
            this.LegalizeReport.Size = new System.Drawing.Size(110, 28);
            this.LegalizeReport.TabIndex = 2;
            this.LegalizeReport.Text = "Report";
            this.LegalizeReport.UseVisualStyleBackColor = true;
            this.LegalizeReport.Click += new System.EventHandler(this.LegalizeReport_Click);
            // 
            // Master
            // 
            this.Master.Location = new System.Drawing.Point(157, 71);
            this.Master.Name = "Master";
            this.Master.Size = new System.Drawing.Size(108, 28);
            this.Master.TabIndex = 3;
            this.Master.Text = "Master";
            this.Master.UseVisualStyleBackColor = true;
            this.Master.Click += new System.EventHandler(this.Master_Click);
            // 
            // Legal_BTN
            // 
            this.Legal_BTN.Location = new System.Drawing.Point(25, 117);
            this.Legal_BTN.Name = "Legal_BTN";
            this.Legal_BTN.Size = new System.Drawing.Size(110, 28);
            this.Legal_BTN.TabIndex = 4;
            this.Legal_BTN.Text = "LegalBox";
            this.Legal_BTN.UseVisualStyleBackColor = true;
            this.Legal_BTN.Click += new System.EventHandler(this.Legal_BTN_Click);
            // 
            // LegalALL_BTN
            // 
            this.LegalALL_BTN.Location = new System.Drawing.Point(156, 117);
            this.LegalALL_BTN.Name = "LegalALL_BTN";
            this.LegalALL_BTN.Size = new System.Drawing.Size(110, 28);
            this.LegalALL_BTN.TabIndex = 5;
            this.LegalALL_BTN.Text = "LegalAll";
            this.LegalALL_BTN.UseVisualStyleBackColor = true;
            this.LegalALL_BTN.Click += new System.EventHandler(this.LegalALL_BTN_Click);
            // 
            // SimpleEditor
            // 
            this.ClientSize = new System.Drawing.Size(287, 157);
            this.Controls.Add(this.LegalALL_BTN);
            this.Controls.Add(this.Legal_BTN);
            this.Controls.Add(this.Master);
            this.Controls.Add(this.LegalizeReport);
            this.Controls.Add(this.ClearRecord);
            this.Controls.Add(this.AllRibbon);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SimpleEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);

        }
        public SimpleEditor(ISaveFileProvider sav, IPKMView editor)
        {
            Editor = editor;
            SAV = sav;
            InitializeComponent();
        }
        private void AllRibbon_Click(object sender, EventArgs e)
        {
            RibbonApplicator.SetAllValidRibbons(Editor.Data);
        }
        private void ClearRecord_Click(object sender, EventArgs e)
        {
            ITechRecord8 techRecord = Editor.Data as ITechRecord8;
            TechnicalRecordApplicator.SetRecordFlags(techRecord, false, 112);
        }
        private void LegalizeReport_Click(object sender, EventArgs e)
        {
            var la = new LegalityAnalysis(Editor.Data);
            MessageBox.Show($"{la.Report(true)}");
        }
        private void Master_Click(object sender, EventArgs e)
        {
            if (SAV.SAV.Version != GameVersion.PLA)
                MessageBox.Show("只适用于阿尔宙斯！","SuperWang");
            else
            {
                Handle_MoveShop();
                MessageBox.Show("搞定了！", "SuperWang");
            }
        }
        private void Handle_MoveShop()
        {
            LegalityAnalysis la;
            PKM pkm = Editor.Data;
            var pk = (PA8)pkm;
            if (pk.Species != 0)
            pk = GetMoveFromDataBase(pkm);
            IMoveShop8Mastery shop = pk;
            for (int q = 0; q < 62; q++)
            {
              shop.SetPurchasedRecordFlag(q, true);
              la = new LegalityAnalysis(pk);
              if (!la.Valid)
                  shop.SetPurchasedRecordFlag(q, false);
             }
            for (int j = 0; j < 62; j++)
             {
               shop.SetMasteredRecordFlag(j, true);
               la = new LegalityAnalysis(pk);
               if (!la.Valid)
                  shop.SetMasteredRecordFlag(j, false);
             }
            pk= Handle_OTPokemon(pk,pkm);
            pk.ResetHeight();
            pk.ResetWeight();
            pk.ClearNickname();
            Editor.PopulateFields(pk, false);
            SAV.ReloadSlots();

        }
        private PA8 GetMoveFromDataBase (PKM pk)
        {
            IEncounterInfo enc;
            LegalityAnalysis la;
            List<PA8> PokeList = new();
            PKM pkm = pk;
            var p = (PA8)pkm;
            var setting = new SearchSettings
            {
                Species = pk.Species,
                SearchEgg = false,
                Version = 47,
            };
            var search = EncounterUtil.SearchDatabase(setting, SAV.SAV);
            var results = search.ToList();
            if (results.Count != 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    enc = results[i];
                    var criteria = EncounterUtil.GetCriteria(enc, pk);
                    pkm = enc.ConvertToPKM(SAV.SAV, criteria);
                    p = (PA8)pkm;
                    if (p.IsAlpha == true && p.Species == pk.Species && p.Form == pk.Form)
                    {
                        PokeList.Add(p);
                    }
                }
                if (PokeList.Count != 0)
                {
                    for(int i=0;i<PokeList.Count;i++)
                    {
                        pkm = PokeList[i];
                        pkm.SetShiny();
                        la = new LegalityAnalysis(pkm);
                        if (la.Valid&& pk.Species!=550)
                            return PokeList[i];
                        if (pk.Species == 550 && pk.Gender == 0)
                            return PokeList[i + 1];

                    }
                }

            }
            return p;
        }
        private PA8 Handle_OTPokemon(PA8 pk,PKM pkm)
        {
            pk.Language = pkm.Language;
            pk.PID = pkm.PID;
            pk.EncryptionConstant = pkm.EncryptionConstant;
            pk.OT_Name = pkm.OT_Name;
            pk.TrainerID7 = pkm.TrainerID7;
            pk.TrainerSID7 = pkm.TrainerSID7;
            pk.OT_Gender = pkm.OT_Gender;
            pk.IVs = pkm.IVs;
            pk.EVs = pkm.EVs;
            pk.Nature = pkm.Nature;
            pk.AbilityNumber = pkm.AbilityNumber;
            pk.StatNature = pkm.StatNature;
            pk.CurrentLevel = pkm.CurrentLevel;
            pk.Ball = pkm.Ball;
            pk.GV_ATK = 7;
            pk.GV_DEF = 7;
            pk.GV_HP = 7;
            pk.GV_SPA = 7;
            pk.GV_SPD = 7;
            pk.GV_SPE = 7;
            pk.Form = pkm.Form;
            if (pk.Species is 571 or 362 or 706 or 904)
            {
                pk.CurrentLevel = 85;
                pk.IV_SPE = 31;
                pk.IV_HP = 31;
                pk.IV_DEF = 31;
            }
                return pk;
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
        private void Legal_BTN_Click(object sender, EventArgs e)
        {
            LegalBox(SAV);
            SAV.ReloadSlots();
            MessageBox.Show("搞定啦");
        }

        private void LegalALL_BTN_Click(object sender, EventArgs e)
        {
            LegalAll(SAV);
            SAV.ReloadSlots();
            MessageBox.Show("搞定啦");
        }
    }
}
