using System;
using PKHeX.Core.Searching;
using PKHeX.Core;
using PKHeX.Core.AutoMod;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace WangPlugin
{
    internal class ConvertToEgg
    {
        public static void Egg(PKM pk, IPKMView PKMEditor, ISaveFileProvider SaveFileEditor)
        {
            List<IEncounterInfo> Results = new();
            IEncounterInfo enc;
            PKM pkm = PKMEditor.Data;
            ITechRecord8 techRecord = pk as ITechRecord8;
            int[] zero = {0,0,0,0,0,0 };
            var tree = EvolutionTree.GetEvolutionTree(PKMEditor.Data, PKMEditor.Data.Format);
            var PE=tree.GetPreEvolutions(PKMEditor.Data.Species, PKMEditor.Data.Form);
            if (PE.Count() != 0)
            {
                int PreSpecies = PE.First();
                pk.Species = PreSpecies;
            }
            var setting = new SearchSettings
            {
                Species = pk.Species,
                SearchEgg = true,
            };
            var search = EncounterUtil.SearchDatabase(setting, SaveFileEditor.SAV);
            var results = search.ToList();
            if(results.Count != 0)
            {
                Results = results;
                enc = Results[0];
                var criteria = EncounterUtil.GetCriteria(enc, pkm);
                pkm = enc.ConvertToPKM(SaveFileEditor.SAV, criteria);
            }
            pk.IsEgg = true;
            pk.TrainerID7 = SaveFileEditor.SAV.TrainerID7;
            pk.TrainerSID7 = SaveFileEditor.SAV.TrainerSID7;
            pk.OT_Gender = SaveFileEditor.SAV.Gender;
            pk.OT_Name = SaveFileEditor.SAV.OT;
            pk.CurrentHandler = 0;
            if (pk.Ball == 1)
            {
                pk.Ball = 4;
            }
            TechnicalRecordApplicator.SetRecordFlags(techRecord,false, 112);
            pk.Moves = pkm.Moves;
            pk.Move1_PP = pkm.Move1_PP;
            pk.Move2_PP = pkm.Move2_PP;
            pk.Move3_PP = pkm.Move3_PP;
            pk.Move4_PP = pkm.Move4_PP;
            pk.Move1_PPUps = 0;
            pk.Move2_PPUps = 0;
            pk.Move3_PPUps = 0;
            pk.Move4_PPUps = 0;
            pk.Met_Level = 1;
            pk.CurrentLevel = 1;
            pk.Egg_Location = 60002;
            pk.Met_Location = 0;
            pk.EggMetDate = DateTime.Today;
            pk.MetDate = DateTime.Today;
            pk.RelearnMove1 = pk.Move1;
            pk.RelearnMove2 = pk.Move2;
            pk.RelearnMove3 = pk.Move3;
            pk.RelearnMove4 = pk.Move4;
            pk.EVs =zero;
            pk.OT_Friendship = 1;
            pk.IsNicknamed = true;
            if(pk.Language==10||pk.Language==9)
            {
                pk.Nickname = "蛋";
            }
            if (pk.Language == 2)
            {
                pk.Nickname = "Egg";
            }
            pk.SetDynamaxLevel(0);
            RibbonApplicator.RemoveAllValidRibbons(pk);
            pk.RefreshChecksum();
            PKMEditor.PopulateFields(pk, false);
            SaveFileEditor.ReloadSlots();
            MessageBox.Show($"Success！");
        }

    }
}
