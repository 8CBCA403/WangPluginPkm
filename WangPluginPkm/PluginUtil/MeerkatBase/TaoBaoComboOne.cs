using PKHeX.Core;
using System.Collections.Generic;
using System.Linq;
using WangPluginPkm.PluginUtil.AchieveBase.PostGameAchieve;
using WangPluginPkm.PluginUtil.AchieveBase.SpecificForm;
using WangPluginPkm.PluginUtil.DexBase;

namespace WangPluginPkm.PluginUtil.MeerkatBase
{
    internal class TaoBaoCombo1One
    {
        public static List<PKM> Sets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            var PKLB = new List<PKM>();
            if (SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                PKL = RSE.RSESets(SAV, Editor).Concat(FRLG.FRLGSets(SAV, Editor)).Concat(DPPT.DPPTSets(SAV, Editor)).
                                   Concat(HGSS.HGSSSets(SAV, Editor)).Concat(BW.BWSets(SAV, Editor)).
                                   Concat(XY.XYSets(SAV, Editor)).Concat(ORAS.ORASSets(SAV, Editor)).
                                    Concat(SM.SMSets(SAV, Editor)).Concat(RBY.RBYSets(SAV, Editor)).
                                    Concat(GDSI.GDSISets(SAV, Editor)).ToList(); ;
                PKLB = PKLB.Concat(PKL).ToList();
                PKL = VivillonDex.VivillonSets(SAV, Editor).Concat(Alola.AlolaSets(SAV, Editor)).
                              Concat(AlolaformDex.AlolaSets(SAV, Editor)).Concat(Fossil.FossilSets(SAV, Editor)).
                              Concat(UnownDex.UnownSets(SAV, Editor)).Concat(OricorioDex.OricorioSets(SAV, Editor)).
                              Concat(UltraBeast.UltraSets(SAV, Editor)).Concat(RotomDex.RotomSets(SAV, Editor)).
                              Concat(MiniorDex.MiniorSets(SAV, Editor)).Concat(Eevee.EeveeSets(SAV, Editor)).
                              Concat(Deerling.SpringSets(SAV, Editor)).Concat(Deerling.SummerSets(SAV, Editor)).
                              Concat(Deerling.AutumnSets(SAV, Editor)).Concat(Deerling.WinterSets(SAV, Editor)).
                              Concat(Misc.SnorlaxSets(SAV, Editor)).Concat(Misc.MetagrossSets(SAV, Editor)).
                              Concat(Misc.ShayminSets(SAV, Editor)).Concat(Misc.MeloettaSets(SAV, Editor)).
                              Concat(Misc.GenesectSets(SAV, Editor)).Concat(GuardianDeity.GSets(SAV, Editor)).
                              Concat(CapPikachuDex.CapPikachuSets(SAV, Editor)).Concat(Pika.PikaSets(SAV, Editor)).Concat(Ditto.DittoSets(SAV, Editor)).
                              ToList();
                PKLB = PKLB.Concat(PKL).ToList();
                PKL = MytheryPK.ESets(SAV, Editor).ToList();
                PKLB = PKLB.Concat(PKL).ToList();
                PKL = MytheryPK.BWSets(SAV, Editor).ToList();
                PKLB = PKLB.Concat(PKL).ToList();
                PKL = MytheryPK.ORASSets(SAV, Editor).ToList();
                PKLB = PKLB.Concat(PKL).ToList();
                PKL = MytheryPK.SMSets(SAV, Editor).ToList();
                PKLB = PKLB.Concat(PKL).ToList();
                PKL = MytheryPK.USUMSets(SAV, Editor).ToList();
                PKLB = PKLB.Concat(PKL).ToList();
            }
            return PKLB;
        }
    }
}
