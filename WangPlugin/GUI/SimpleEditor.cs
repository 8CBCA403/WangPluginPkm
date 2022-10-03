using System;
using PKHeX.Core;
using System.Windows.Forms;
using System.Collections.Generic;
using PKHeX.Core.Searching;
using System.Linq;

namespace WangPlugin.GUI
{
    partial class SimpleEditor : Form
    {
        private IPKMView Editor { get; }
        private ISaveFileProvider SAV { get; }
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
            pk.EV_ATK = pkm.EV_ATK;
            pk.EV_DEF = pkm.EV_DEF;
            pk.EV_HP = pkm.EV_HP;
            pk.EV_SPA = pkm.EV_SPA;
            pk.EV_SPD = pkm.EV_SPD;
            pk.EV_SPE = pkm.EV_SPE;
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
    }
}
