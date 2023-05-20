using System;
using PKHeX.Core;
using System.Windows.Forms;
using System.Collections.Generic;
using PKHeX.Core.Searching;
using System.Linq;
using System.IO;

namespace WangPluginPkm.GUI
{
    partial class SimpleEditor : Form
    {

        private IPKMView Editor { get; }
        private ISaveFileProvider SAV { get; }
        private PK8 gp = new();
        private const string GoFilter = "Go Park Entity |*.pk9|All Files|*.*";
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
            ITechRecord techRecord = Editor.Data as ITechRecord;
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
                MessageBox.Show("只适用于阿尔宙斯！", "SuperWang");
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
            pk = Handle_OTPokemon(pk, pkm);
            pk.ResetHeight();
            pk.ResetWeight();
            pk.ClearNickname();
            Editor.PopulateFields(pk, false);
            SAV.ReloadSlots();
        }
        private PA8 GetMoveFromDataBase(PKM pk)
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
                    for (int i = 0; i < PokeList.Count; i++)
                    {
                        pkm = PokeList[i];
                        pkm.SetShiny();
                        la = new LegalityAnalysis(pkm);
                        if (la.Valid && pk.Species != 550)
                            return PokeList[i];
                        if (pk.Species == 550 && pk.Gender == 0)
                            return PokeList[i + 1];

                    }
                }

            }
            return p;
        }
        private PA8 Handle_OTPokemon(PA8 pk, PKM pkm)
        {
            pk.Language = pkm.Language;
            pk.PID = pkm.PID;
            pk.EncryptionConstant = pkm.EncryptionConstant;
            pk.OT_Name = pkm.OT_Name;
            pk.DisplayTID = pkm.DisplayTID;
            pk.DisplaySID = pkm.DisplaySID;
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

        //处理神秘礼物
        #region
        private void SearchGift()
        {

            string r = "";
            var L = SAV.SAV.GetBoxData(SAV.CurrentBox);
            PKM pk;
            int j = 1;
            if (L.Count() != 0)
            {
                for (int i = 0; i < L.Count(); i++)
                {
                    pk = L[i];
                    r += $"序号：{j}" + SearchDatabase.SearchMytheryGift(pk.Species, pk.Generation, pk.OT_Name, pk.SID16, pk.TID16, pk.Form);
                    j++;
                }
            }
            MessageBox.Show($"{r}");
        }

        private void Check_Gift_Click(object sender, EventArgs e)
        {
            SearchGift();
        }

        private void ALLMG_Click(object sender, EventArgs e)
        {


            IList<PKM> BoxData;
            for (ushort i = 1; i < 722; i++)
            {
                List<PKM> L = new();

                BoxData = SAV.SAV.BoxData;
                IList<PKM> arr2 = BoxData;
                List<int> list = FindAllEmptySlots(arr2, 0);
                if (SearchDatabase.MytheryPKList(ref L, SAV, i, 6))
                {
                    for (int j = 0; j < L.Count; j++)
                    {
                        int index = list[j];
                        SAV.SAV.SetBoxSlotAtIndex(L[j], index);
                    }
                }
                SAV.ReloadSlots();
            }


        }
        #endregion
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

        private void button1_Click(object sender, EventArgs e)
        {
            PK8 pk;
            pk = gp;
            var o = PokeCrypto.EncryptArray8(pk.Data);
            using var sfd = new SaveFileDialog
            {
                FileName = "A",
                Filter = GoFilter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            File.WriteAllBytes(sfd.FileName, o);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using var sfd = new OpenFileDialog
            {
                Filter = GoFilter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };
            // Export
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            string path = sfd.FileName;
            ImportG9From(path);
        }
        private void ImportG9From(string path)
        {
            var data = File.ReadAllBytes(path);
            if (data.Length != 344)
            {
                MessageBox.Show(MessageStrings.MsgFileLoadIncompatible);
                return;
            }
            var gp1 = new PK8();
            data.CopyTo(gp1.Data, 0);
            gp = gp1;
        }

    }
}
