using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using PKHeX.Core.AutoMod;
using WangPluginPkm.Properties;
using WangPluginPkm.PluginUtil.LegalLogic;
namespace WangPluginPkm.PluginUtil.Functions
{
    public static class DexBuildFunctions
    {
        public static void UnionPKM(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            var a = sav.GetAllPKM();
            var pkms = sav.GenerateLivingDex().ToList();
            foreach (var item in a)
            {
                var pk = pkms.Find(x => x.Species == item.Species);
                pkms.Remove(pk);
            }
            var o = a.Union(pkms).ToArray();
            o = o.OrderBySpecies().ToArray();
            Span<PKM> bd = sav.BoxData.ToArray();
            o.CopyTo(bd);
            sav.BoxData = bd.ToArray();
            SaveFileEditor.ReloadSlots();
        }
        public static void LivingDex(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            Span<PKM> pkms = sav.GenerateLivingDex().ToArray();
            Span<PKM> bd = sav.BoxData.ToArray();
            pkms.CopyTo(bd);
            sav.BoxData = bd.ToArray();
            SaveFileEditor.ReloadSlots();
        }
        public static void LivingDexHome(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            Span<PKM> pkms = sav.GenerateLivingDex().ToArray();
            Span<PKM> bd = sav.BoxData.ToArray();
            pkms.CopyTo(bd);
            sav.BoxData = bd.ToArray();
            SaveFileEditor.ReloadSlots();
        }
        public static void LegalBox(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            Legalize.LegalizeBox(sav, sav.CurrentBox);

        }
        public static void LegalAll(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
           
            sav.LegalizeBoxes();
        }
        public static void ClearPKM(PKM pkm)
        {
            pkm.Species = 0;
            pkm.PID = 0;
        }
        public static void RandomPKMPID(PKM pkm)
        {
            pkm.PID = Util.Rand32();

        }
        public static void RandomPKMEC(PKM pkm)
        {
            pkm.SetRandomEC();
        }

    }
}
