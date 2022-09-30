using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WangPlugin
{
    public class Lockfun
    {
        public static bool FiveNpcTeam(ref uint seed, NPCClass T1, NPCClass T2, NPCClass T3, NPCClass T4, NPCClass T5)
        {
            if (TeamLockXD.GenPkm(seed, T1))
            {
                seed = XDRNG.Next7(seed);
                {
                    if (TeamLockXD.GenPkm(seed, T2))
                    {
                        seed = XDRNG.Next7(seed);
                        if (TeamLockXD.GenPkm(seed, T3))
                        {
                            seed = XDRNG.Next7(seed);
                            if (TeamLockXD.GenPkm(seed, T4))
                            {
                                seed = XDRNG.Next7(seed);
                                if (TeamLockXD.GenPkm(seed, T5))
                                {
                                    seed = XDRNG.Next7(seed);
                                    return true;
                                }
                                else
                                    return false;
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
            }
            else
                return false;
        }
        public static bool FourNpcTeam(ref uint seed, NPCClass T1, NPCClass T2, NPCClass T3, NPCClass T4)
        {
            if (TeamLockXD.GenPkm(seed, T1))
            {
                seed = XDRNG.Next7(seed);
                {
                    if (TeamLockXD.GenPkm(seed, T2))
                    {
                        seed = XDRNG.Next7(seed);
                        if (TeamLockXD.GenPkm(seed, T3))
                        {
                            seed = XDRNG.Next7(seed);
                            if (TeamLockXD.GenPkm(seed, T4))
                            {
                                seed = XDRNG.Next7(seed);
                                return true;
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
            }
            else
                return false;
        }
        public static bool ThreeNpcTeam(ref uint seed, NPCClass T1, NPCClass T2, NPCClass T3)
        {
            if (TeamLockXD.GenPkm(seed, T1))
            {
                seed = XDRNG.Next7(seed);
                {
                    if (TeamLockXD.GenPkm(seed,T2))
                    {
                        seed = XDRNG.Next7(seed);
                        if (TeamLockXD.GenPkm(seed,T3))
                        {
                            seed = XDRNG.Next7(seed);
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
            }
            else
                return false;
        }
        public static bool TwoNpcTeam(ref uint seed, NPCClass T1, NPCClass T2)
        {
            if (TeamLockXD.GenPkm(seed, T1))
            {
                seed = XDRNG.Next7(seed);
                {
                    if (TeamLockXD.GenPkm(seed, T2))
                    {
                        seed = XDRNG.Next7(seed);
                        return true;
                    }
                    else
                        return false;
                }
            }
            else
                return false;
        }
        public static bool OneNpcTeam(ref uint seed, NPCClass T1)
        {
            if (TeamLockXD.GenPkm(seed, T1))
            {
                seed = XDRNG.Next7(seed);
                {
                    return true;
                }
            }
            else
                return false;
        }
 
        public static bool Makuhita(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, CMakuhita[0], CMakuhita[1]))
                return true;
            else
                return false;
        }
        public static bool Gligar(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, CGligar[0], CGligar[1], CGligar[2]))
                return true;
            else
                return false;
        }
        public static bool Murkrow(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, CMurkrow[0], CMurkrow[1], CMurkrow[2]))
                return true;
            else
                return false;
        }
        public static bool Heracross(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, CHeracross[0], CHeracross[1]))
                return true;
            else
                return false;
        }
        public static bool Ursaring(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, CUrsaring[0], CUrsaring[1], CUrsaring[2]))
                return true;
            else
                return false;
        }
        public static bool Ralts(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XRalts[0], XRalts[1], XRalts[2]))
                return true;
            else
                return false;
        }
        public static bool Poochyena(ref uint seed)
        {
            if (OneNpcTeam(ref seed, XPoochyena[0]))
                return true;
            else
                return false;
        }
        public static bool Ledyba(ref uint seed)
        {
            if (OneNpcTeam(ref seed, XLedyba[0]))
                return true;
            else
                return false;
        }
        public static bool Gulpin(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XGulpin[0], XGulpin[1]))
                return true;
            else
                return false;
        }
        public static bool Spinarak(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XSpinarak[0], XSpinarak[1]))
                return true;
            else
                return false;
        }
        public static bool Numel(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XNumel[0], XNumel[1], XNumel[2]))
                return true;
            else
                return false;
        }
        public static bool Shroomish(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XShroomish[0], XShroomish[1]))
                return true;
            else
                return false;
        }
        public static bool Delcatty(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XDelcatty[0], XDelcatty[1], XDelcatty[2]))
                return true;
            else
                return false;
        }
        public static bool Voltorb(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XVoltorb[0], XVoltorb[1], XVoltorb[2]))
                return true;
            else
                return false;
        }
        public static bool Makuhita_XD(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XMakuhita[0], XMakuhita[1]))
                return true;
            else
                return false;
        }
        public static bool Vulpix(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XVulpix[0], XVulpix[1], XVulpix[2]))
                return true;
            else
                return false;
        }
        public static bool Duskull(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XDuskull[0], XDuskull[1], XDuskull[2]))
                return true;
            else
                return false;
        }
        public static bool Mawile(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XMawile[0], XMawile[1]))
                return true;
            else
                return false;
        }
        public static bool Snorunt(ref uint seed)
        {
            if (OneNpcTeam(ref seed, XSnorunt[0]))
                return true;
            else
                return false;
        }
           public static bool Pineco(ref uint seed)
        {
            if (OneNpcTeam(ref seed, XPineco[0]))
                return true;
            else
                return false;
        }
        public static bool Natu(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XNatu[0], XNatu[1]))
                return true;
            else
                return false;
        }
        public static bool Roselia(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XRoselia[0], XRoselia[1]))
                return true;
            else
                return false;
        }
        public static bool Meowth(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XMeowth[0], XMeowth[1], XMeowth[2]))
                return true;
            else
                return false;
        }
        public static bool Swinub(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XSwinub[0], XSwinub[1]))
                return true;
            else
                return false;
        }
        public static bool Spearow(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XSpearow[0], XSpearow[1]))
                return true;
            else
                return false;
        }
        public static bool Grimer(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XGrimer[0], XGrimer[1]))
                return true;
            else
                return false;
        }
        public static bool Seel(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XSeel[0], XSeel[1], XSeel[2]))
                return true;
            else
                return false;
        }
        public static bool Lunatone(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XLunatone[0], XLunatone[1]))
                return true;
            else
                return false;
        }
        public static bool Nosepass(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XNosepass[0], XNosepass[1], XNosepass[2]))
                return true;
            else
                return false;
        }
        public static bool Paras(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XParas[0], XParas[1]))
                return true;
            else
                return false;
        }
        public static bool Pidgeotto(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XPidgeotto[0], XPidgeotto[1]))
                return true;
            else
                return false;
        }

        public static bool Tangela(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XTangela[0], XTangela[1], XTangela[2]))
                return true;
            else
                return false;
        }
        public static bool Magneton(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XMagneton[0], XMagneton[1], XMagneton[2]))
                return true;
            else
                return false;
        }
        public static bool Venomoth(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XVenomoth[0], XVenomoth[1], XVenomoth[2]))
                return true;
            else
                return false;
        }
        public static bool Arbok(ref uint seed)
        {
            if (FourNpcTeam(ref seed, XArbok[0], XArbok[1], XArbok[2], XArbok[3]))
                return true;
            else
                return false;
        }
        public static bool Primeape(ref uint seed)
        {
            if (FourNpcTeam(ref seed, XPrimeape[0], XPrimeape[1], XPrimeape[2], XPrimeape[3]))
                return true;
            else
                return false;
        }
        public static bool Golduck(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XGolduck[0], XGolduck[1], XGolduck[2]))
                return true;
            else
                return false;
        }
        public static bool Dodrio(ref uint seed)
        {
            if (OneNpcTeam(ref seed, XDodrio[0]))
                return true;
            else
                return false;
        }
        public static bool Raticate(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XRaticate[0], XRaticate[1]))
                return true;
            else
                return false;
        }


        public static bool Farfetchd(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XFarfetchd[0], XFarfetchd[1], XFarfetchd[2]))
                return true;
            else
                return false;
        }
        public static bool Kangaskhan(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XKangaskhan[0], XKangaskhan[1], XKangaskhan[2]))
                return true;
            else
                return false;
        }
        public static bool Magmar(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XMagmar[0], XMagmar[1], XMagmar[2]))
                return true;
            else
                return false;
        }
        public static bool Rapidash(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XRapidash[0], XRapidash[1], XRapidash[2]))
                return true;
            else
                return false;
        }
        
        public static bool Hitmonchan(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XHitmonchan[0], XHitmonchan[1], XHitmonchan[2]))
                return true;
            else
                return false;
        }
        public static bool Hitmonlee(ref uint seed)
        {
            if (FourNpcTeam(ref seed, XHitmonlee[0], XHitmonlee[1], XHitmonlee[2], XHitmonlee[3]))
                return true;
            else
                return false;
        }
        public static bool Lickitung(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XLickitung[0], XLickitung[1]))
                return true;
            else
                return false;
        }
        public static bool Scyther(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XScyther[0], XScyther[1]))
                return true;
            else
                return false;
        }

        public static bool Solrock(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XSolrock[0], XSolrock[1], XSolrock[2]))
                return true;
            else
                return false;
        }
        public static bool Starmie(ref uint seed)
        {
            if (FourNpcTeam(ref seed, XStarmie[0], XStarmie[1], XStarmie[2], XStarmie[3]))
                return true;
            else
                return false;
        }
        public static bool Electabuzz(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XElectabuzz[0], XElectabuzz[1], XElectabuzz[2]))
                return true;
            else
                return false;
        }
        public static bool Poliwrath(ref uint seed)
        {
            if (FourNpcTeam(ref seed, XPoliwrath[0], XPoliwrath[1], XPoliwrath[2], XPoliwrath[3]))
                return true;
            else
                return false;
        }
        public static bool Dugtrio(ref uint seed)
        {
            if (FourNpcTeam(ref seed, XDugtrio[0], XDugtrio[1], XDugtrio[2], XDugtrio[3]))
                return true;
            else
                return false;
        }
        public static bool Manectric(ref uint seed)
        {
            if (OneNpcTeam(ref seed, XManectric[0]))
                return true;
            else
                return false;
        }
        public static bool Marowak(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XMarowak[0], XMarowak[1]))
                return true;
            else
                return false;
        }
        public static bool Dragonite(ref uint seed)
        {
            if (FiveNpcTeam(ref seed, XDragonite[0], XDragonite[1], XDragonite[2], XDragonite[3], XDragonite[4]))
                return true;
            else
                return false;
        }
        public static bool Togepi(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, ETogepi[0], ETogepi[1], ETogepi[2]))
                return true;
            else
                return false;
        }
        public static bool Mareep(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, EMareep[0], EMareep[1], EMareep[2]))
                return true;
            else
                return false;
        }
        public static bool Scizor(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, EScizor[0], EScizor[1], EScizor[2]))
                return true;
            else
                return false;
        }
        public static bool SphealCipherLab(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XSphealCipherLab[0], XSphealCipherLab[1]))
                return true;
            else
                return false;
        }
        public static bool SphealPhenacCityandPost(ref uint seed)
        {
            if (ThreeNpcTeam(ref seed, XSphealPhenacCityandPost[0], XSphealPhenacCityandPost[1],XSphealPhenacCityandPost[2]))
                return true;
            else
                return false;
        }
        public static bool SeedotCipherLab(ref uint seed)
        {
            if (FiveNpcTeam(ref seed, XSeedotCipherLab[0], XSeedotCipherLab[1], XSeedotCipherLab[2], XSeedotCipherLab[3], XSeedotCipherLab[4]))
                return true;
            else
                return false;
        }
        public static bool SeedotPhenacCity(ref uint seed)
        {
            if (FiveNpcTeam(ref seed, XSeedotPhenacCity[0], XSeedotPhenacCity[1], XSeedotPhenacCity[2], XSeedotPhenacCity[3], XSeedotPhenacCity[4]))
                return true;
            else
                return false;
        }
        public static bool SeedotPost(ref uint seed)
        {
            if (FiveNpcTeam(ref seed, XSeedotPost[0], XSeedotPost[1], XSeedotPost[2], XSeedotPost[3], XSeedotPost[4]))
                return true;
            else
                return false;
        }
        public static bool MakuhitaX(ref uint seed)
        {
            if (TwoNpcTeam(ref seed, XMakuhita[0], XMakuhita[1]))
                return true;
            else
                return false;
        }

        //Colo
        public static readonly NPCClass[] CMakuhita = 
       {
            new NPCClass(355, 24, 0, 127), // Duskull (M) (Quirky)
            new NPCClass(167, 00, 1, 127), // Spinarak (F) (Hardy)
       };
        public static readonly NPCClass[] CGligar = {
            new NPCClass(216, 12, 0, 127), // Teddiursa (M) (Serious)
            new NPCClass(039, 06, 1, 191), // Jigglypuff (F) (Docile)
            new NPCClass(285, 18, 0, 127), // Shroomish (M) (Bashful)
            };
        public static readonly NPCClass[] CMurkrow = {
            new NPCClass(318, 06, 0, 127), // Carvanha (M) (Docile)
            new NPCClass(274, 12, 1, 127), // Nuzleaf (F) (Serious)
            new NPCClass(228, 18, 0, 127), // Houndour (M) (Bashful)
            };
        public static readonly NPCClass[] CHeracross =  {
            new NPCClass(284, 00, 0, 127), // Masquerain (M) (Hardy)
            new NPCClass(168, 00, 1, 127), // Ariados (F) (Hardy)
            };
        public static readonly NPCClass[] CUrsaring =  {
            new NPCClass(067, 20, 1, 063), // Machoke (F) (Calm)
            new NPCClass(259, 16, 0, 031), // Marshtomp (M) (Mild)
            new NPCClass(275, 21, 1, 127), // Shiftry (F) (Gentle)
            };
        //XD
        public static readonly NPCClass[] XRalts = {
            new NPCClass(064, 00, 0, 063), // Kadabra (M) (Hardy)
            new NPCClass(180, 06, 1, 127), // Flaaffy (F) (Docile)
            new NPCClass(288, 18, 0, 127), // Vigoroth (M) (Bashful)
        };
        public static readonly NPCClass[] XPoochyena = {
            new NPCClass(041, 12, 1, 127), // Zubat (F) (Serious)
            };
        public static readonly NPCClass[] XLedyba = {
            new NPCClass(276, 00, 1, 127), // Taillow (F) (Hardy)
            };
        public static readonly NPCClass[] XGulpin = {
            new NPCClass(109, 12, 1, 127), // Koffing (F) (Serious)
            new NPCClass(088, 06, 0, 127), // Grimer (M) (Docile)
            };
        public static readonly NPCClass[] XSpinarak = {
            new NPCClass(220, 12, 1, 127), // Swinub (F) (Serious)
            new NPCClass(353, 06, 0, 127), // Shuppet (M) (Docile)
            };
        public static readonly NPCClass[] XNumel = {
            new NPCClass(280, 06, 0, 127), // Ralts (M) (Docile)
            new NPCClass(100, 00, 2, 255), // Voltorb (-) (Hardy)
            new NPCClass(371, 24, 1, 127), // Bagon (F) (Quirky)
            };
        public static readonly NPCClass[] XShroomish = {
            new NPCClass(209, 24, 1, 191), // Snubbull (F) (Quirky)
            new NPCClass(352, 00, 1, 127), // Kecleon (F) (Hardy)
            };
        public static readonly NPCClass[] XDelcatty = {
            new NPCClass(370, 06, 1, 191), // Luvdisc (F) (Docile)
            new NPCClass(267, 00, 0, 127), // Beautifly (M) (Hardy)
            new NPCClass(315, 24, 0, 127), // Roselia (M) (Quirky)
            };
        public static readonly NPCClass[] XVoltorb = {
            new NPCClass(271, 00, 0, 127), // Lombre (M) (Hardy)
            new NPCClass(271, 18, 0, 127), // Lombre (M) (Bashful)
            new NPCClass(271, 12, 1, 127), // Lombre (F) (Serious)
            };
        public static readonly NPCClass[] XMakuhita = {
            new NPCClass(352, 06, 0, 127), // Kecleon (M) (Docile)
            new NPCClass(283, 18, 1, 127), // Surskit (F) (Bashful)
            };
        public static readonly NPCClass[] XVulpix = {
            new NPCClass(167, 00, 0, 127), // Spinarak (M) (Hardy)
            new NPCClass(267, 06, 1, 127), // Beautifly (F) (Docile)
            new NPCClass(269, 18, 0, 127), // Dustox (M) (Bashful)
            };
        public static readonly NPCClass[] XDuskull = {
            new NPCClass(215, 12, 0, 127), // Sneasel (M) (Serious)
            new NPCClass(193, 18, 1, 127), // Yanma (F) (Bashful)
            new NPCClass(200, 24, 0, 127), // Misdreavus (M) (Quirky)
            };
        public static readonly NPCClass[] XMawile = {
            new NPCClass(294, 06, 0, 127), // Loudred (M) (Docile)
            new NPCClass(203, 18, 1, 127), // Girafarig (F) (Bashful)
            };
        public static readonly NPCClass[] XSnorunt = {
            new NPCClass(336, 06, 1, 127), // Seviper (F) (Docile)
            };
        public static readonly NPCClass[] XPineco = {
            new NPCClass(198, 06, 0, 127), // Murkrow (M) (Docile)
            };
        public static readonly NPCClass[] XNatu = {
            new NPCClass(281, 00, 0, 127), // Kirlia (M) (Hardy)
            new NPCClass(264, 00, 1, 127), // Linoone (F) (Hardy)
            };
        public static readonly NPCClass[] XRoselia = {
            new NPCClass(223, 06, 0, 127), // Remoraid (M) (Docile)
            new NPCClass(042, 18, 0, 127), // Golbat (M) (Bashful)
            };
        public static readonly NPCClass[] XMeowth = {
            new NPCClass(064, 06, 0, 063), // Kadabra (M) (Docile)
            new NPCClass(215, 00, 1, 127), // Sneasel (F) (Hardy)
            new NPCClass(200, 18, 1, 127), // Misdreavus (F) (Bashful)
            };
        public static readonly NPCClass[] XSwinub = {
            new NPCClass(324, 18, 1, 127), // Torkoal (F) (Bashful)
            new NPCClass(274, 00, 0, 127), // Nuzleaf (M) (Hardy)
            };
        public static readonly NPCClass[] XSpearow = {
            new NPCClass(279, 18, 0, 127), // Pelipper (M) (Bashful)
            new NPCClass(309, 06, 1, 127), // Electrike (F) (Docile)
            };
        public static readonly NPCClass[] XGrimer = {
            new NPCClass(358, 12, 0, 127), // Chimecho (M) (Serious)
            new NPCClass(234, 18, 0, 127), // Stantler (M) (Bashful)
            };
        public static readonly NPCClass[] XSeel = {
            new NPCClass(163, 06, 0, 127), // Hoothoot (M) (Docile)
            new NPCClass(075, 18, 0, 127), // Graveler (M) (Bashful)
            new NPCClass(316, 18, 1, 127), // Gulpin (F) (Bashful)
            };
        public static readonly NPCClass[] XLunatone = {
            new NPCClass(171, 00, 1, 127), // Lanturn (F) (Hardy)
            new NPCClass(195, 18, 0, 127), // Quagsire (M) (Bashful)
            };
        public static readonly NPCClass[] XNosepass = {
            new NPCClass(271, 00, 0, 127), // Lombre (M) (Hardy)
            new NPCClass(271, 18, 0, 127), // Lombre (M) (Bashful)
            new NPCClass(271, 12, 1, 127), // Lombre (F) (Serious)
            };
        public static readonly NPCClass[] XParas = 
{
            new NPCClass(336, 24, 0, 127), // Seviper (M) (Quirky)
            new NPCClass(198, 06, 1, 127), // Murkrow (F) (Docile)
            };
        public static readonly NPCClass[] XPidgeotto = {
           // new NPCClass(015), // Shadow Beedrill
            new NPCClass(162, 12, 0, 127), // Furret (M) (Serious)
            new NPCClass(176, 18, 0, 031), // Togetic (M) (Bashful)
            };
        public static readonly NPCClass[] XTangela =  {
            new NPCClass(038, 12, 1, 191), // Ninetales (F) (Serious)
            new NPCClass(189, 06, 0, 127), // Jumpluff (M) (Docile)
            new NPCClass(184, 00, 1, 127), // Azumarill (F) (Hardy)
            };
        public static readonly NPCClass[] XMagneton = {
            new NPCClass(292, 18, 2, 255), // Shedinja (-) (Bashful)
            new NPCClass(202, 00, 0, 127), // Wobbuffet (M) (Hardy)
            new NPCClass(329, 12, 1, 127), // Vibrava (F) (Serious)
            };
        public static readonly NPCClass[] XVenomoth = {
            new NPCClass(055, 18, 1, 127), // Golduck (F) (Bashful)
            new NPCClass(237, 24, 0, 000), // Hitmontop (M) (Quirky)
            new NPCClass(297, 12, 0, 063), // Hariyama (M) (Serious)
            };
        public static readonly NPCClass[] XArbok = {
            new NPCClass(367, 06, 0, 127), // Huntail (M) (Docile)
            new NPCClass(332, 00, 1, 127), // Cacturne (F) (Hardy)
            new NPCClass(110, 12, 1, 127), // Weezing (F) (Serious)
            new NPCClass(217, 18, 1, 127), // Ursaring (F) (Bashful)
            };
        public static readonly NPCClass[] XPrimeape = {
            new NPCClass(305, 18, 1, 127), // Lairon (F) (Bashful)
            new NPCClass(364, 12, 1, 127), // Sealeo (F) (Serious)
            new NPCClass(199, 06, 1, 127), // Slowking (F) (Docile)
            new NPCClass(217, 24, 0, 127), // Ursaring (M) (Quirky)
            };
        public static readonly NPCClass[] XGolduck = {
            new NPCClass(342, 24, 0, 127), // Crawdaunt (M) (Quirky)
            new NPCClass(279, 06, 1, 127), // Pelipper (F) (Docile)
            new NPCClass(226, 18, 1, 127), // Mantine (F) (Bashful)
            };
        public static readonly NPCClass[] XDodrio =  {
            new NPCClass(178, 18, 1, 127), // Xatu (F) (Bashful)
            };
        public static readonly NPCClass[] XRaticate = {
            new NPCClass(178, 18, 1, 127), // Xatu (F) (Bashful)
         //   new NPCClass(085), // Shadow Dodrio
            new NPCClass(340, 18, 0, 127), // Whiscash (M) (Bashful)
            };
        public static readonly NPCClass[] XFarfetchd = {
            new NPCClass(282, 12, 0, 127), // Gardevoir (M) (Serious)
            new NPCClass(368, 00, 1, 127), // Gorebyss (F) (Hardy)
            new NPCClass(315, 24, 0, 127), // Roselia (M) (Quirky)
            };
        public static readonly NPCClass[] XKangaskhan =  {
            new NPCClass(101, 00, 2, 255), // Electrode (-) (Hardy)
            new NPCClass(200, 18, 1, 127), // Misdreavus (F) (Bashful)
            new NPCClass(344, 12, 2, 255), // Claydol (-) (Serious)
            };
        public static readonly NPCClass[] XMagmar =  {
            new NPCClass(229, 18, 0, 127), // Houndoom (M) (Bashful)
            new NPCClass(038, 18, 0, 191), // Ninetales (M) (Bashful)
            new NPCClass(045, 00, 1, 127), // Vileplume (F) (Hardy)
            };
        public static readonly NPCClass[] XRapidash =  {
            new NPCClass(323, 24, 0, 127), // Camerupt (M) (Quirky)
            new NPCClass(110, 06, 0, 127), // Weezing (M) (Docile)
            new NPCClass(089, 12, 1, 127), // Muk (F) (Serious)
            };
        public static readonly NPCClass[] XHitmonchan = {
            new NPCClass(308, 24, 0, 127), // Medicham (M) (Quirky)
            new NPCClass(076, 06, 1, 127), // Golem (F) (Docile)
            new NPCClass(178, 18, 1, 127), // Xatu (F) (Bashful)
            };
        public static readonly NPCClass[] XHitmonlee = {
            new NPCClass(326, 18, 0, 127), // Grumpig (M) (Bashful)
            new NPCClass(227, 12, 1, 127), // Skarmory (F) (Serious)
            new NPCClass(375, 06, 2, 255), // Metang (-) (Docile)
            new NPCClass(297, 24, 1, 063), // Hariyama (F) (Quirky)
            };
        public static readonly NPCClass[] XLickitung = {
            new NPCClass(171, 24, 0, 127), // Lanturn (M) (Quirky)
            new NPCClass(082, 06, 2, 255), // Magneton (-) (Docile)
            };
        public static readonly NPCClass[] XScyther = {
            new NPCClass(234, 06, 1, 127), // Stantler (F) (Docile)
            new NPCClass(295, 24, 0, 127), // Exploud (M) (Quirky)
            };
        public static readonly NPCClass[] XSolrock = {
            new NPCClass(375, 24, 2, 255), // Metang (-) (Quirky)
            new NPCClass(195, 06, 0, 127), // Quagsire (M) (Docile)
            new NPCClass(212, 00, 1, 127), // Scizor (F) (Hardy)
            };
        public static readonly NPCClass[] XStarmie = {
            new NPCClass(375, 24, 2, 255), // Metang (-) (Quirky)
            new NPCClass(195, 06, 0, 127), // Quagsire (M) (Docile)
            new NPCClass(212, 00, 1, 127), // Scizor (F) (Hardy)
     //     new NPCClass(338), // Shadow Solrock
            new NPCClass(351, 18, 0, 127), // Castform (M) (Bashful)
            };
        public static readonly NPCClass[] XElectabuzz = {
      //      new NPCClass(277), // Shadow Swellow
            new NPCClass(065, 24, 0, 063), // Alakazam (M) (Quirky)
            new NPCClass(230, 6, 1, 127), // Kingdra (F) (Docile)
            new NPCClass(214, 18, 1, 127), // Heracross (F) (Bashful)
            };
        public static readonly NPCClass[] XPoliwrath = {
            new NPCClass(199, 18, 0, 127), // Slowking (M) (Bashful)
            new NPCClass(217, 18, 0, 127), // Ursaring (M) (Bashful)
            new NPCClass(306, 24, 0, 127), // Aggron (M) (Quirky)
            new NPCClass(365, 06, 1, 127), // Walrein (F) (Docile)
            };
        public static readonly NPCClass[] XDugtrio = {
            new NPCClass(362, 00, 0, 127), // Glalie (M) (Hardy)
            new NPCClass(181, 18, 0, 127), // Ampharos (M) (Bashful)
            new NPCClass(286, 06, 1, 127), // Breloom (F) (Docile)
            new NPCClass(232, 12, 0, 127), // Donphan (M) (Serious)
            };
        public static readonly NPCClass[] XManectric = {
            new NPCClass(291, 06, 1, 127), // Ninjask (F) (Docile)
            };
        public static readonly NPCClass[] XMarowak = {
            new NPCClass(291, 06, 1, 127), // Ninjask (F) (Docile)
     //       new NPCClass(310), // Shadow Manectric
     //       new NPCClass(373), // Shadow Salamence
            new NPCClass(330, 24, 0, 127), // Flygon (M) (Quirky)
            };
        public static readonly NPCClass[] XDragonite = {
            new NPCClass(272, 00, 0, 127), // Ludicolo (M) (Hardy)
            new NPCClass(272, 18, 0, 127), // Ludicolo (M) (Bashful)
            new NPCClass(272, 12, 1, 127), // Ludicolo (F) (Serious)
            new NPCClass(272, 12, 1, 127), // Ludicolo (F) (Serious)
            new NPCClass(272, 00, 0, 127), // Ludicolo (M) (Hardy)
            };
        public static readonly NPCClass[] XSphealCipherLab = {
            new NPCClass(116, 24, 0, 063), // Horsea (M) (Quirky)
            new NPCClass(118, 12, 1, 127), // Goldeen (F) (Serious)
       };
        public static readonly NPCClass[] XSphealPhenacCityandPost =
        {
            new NPCClass(116, 24, 0, 063), // Horsea (M) (Quirky)
            new NPCClass(118, 12, 1, 127), // Goldeen (F) (Serious)
            new NPCClass(374, 00, 2, 255), // Beldum (-) (Hardy)
            };
        public static readonly NPCClass[] XSeedotCipherLab =
        {
            new NPCClass(043, 06, 0, 127), // Oddish (M) (Docile)
            new NPCClass(331, 24, 1, 127), // Cacnea (F) (Quirky)
            new NPCClass(285, 18, 1, 127), // Shroomish (F) (Bashful)
            new NPCClass(270, 00, 0, 127), // Lotad (M) (Hardy)
            new NPCClass(204, 12, 0, 127), // Pineco (M) (Serious)
        };

        public static readonly NPCClass[] XSeedotPhenacCity =
        {
            new NPCClass(043, 06, 0, 127), // Oddish (M) (Docile)
            new NPCClass(331, 24, 1, 127), // Cacnea (F) (Quirky)
            new NPCClass(285, 00, 1, 127), // Shroomish (F) (Hardy)
            new NPCClass(270, 00, 1, 127), // Lotad (F) (Hardy)
            new NPCClass(204, 06, 0, 127), // Pineco (M) (Docile)
            };

        public static readonly NPCClass[] XSeedotPost =
        {
            new NPCClass(045, 06, 0, 127), // Vileplume (M) (Docile)
            new NPCClass(332, 24, 1, 127), // Cacturne (F) (Quirky)
            new NPCClass(286, 00, 1, 127), // Breloom (F) (Hardy)
            new NPCClass(271, 00, 0, 127), // Lombre (M) (Hardy)
            new NPCClass(205, 12, 0, 127), // Forretress (M) (Serious)
            };
        //E-Card
        public static readonly NPCClass[] ETogepi ={
            new NPCClass(302, 23, 0, 127), // Sableye (M) (Careful)
            new NPCClass(088, 08, 0, 127), // Grimer (M) (Impish)
            new NPCClass(316, 24, 0, 127), // Gulpin (M) (Quirky)
    
        };
        public static readonly NPCClass[] EMareep ={
            new NPCClass(300, 04, 1, 191), // Skitty (F) (Naughty)
            new NPCClass(211, 10, 1, 127), // Qwilfish (F) (Timid)
            new NPCClass(355, 12, 1, 127), // Duskull (F) (Serious)
 
            };
        public static readonly NPCClass[] EScizor ={
            new NPCClass(198, 13, 1, 191), // Murkrow (F) (Jolly)
            new NPCClass(344, 02, 2, 255), // Claydol (-) (Brave)
            new NPCClass(208, 03, 0, 127), // Steelix (M) (Adamant)
          
            };
       
    }
}
