using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm
{
    public class LockCheck
    {
        public static bool ChooseLock(ushort Species, PKM pk, ref uint seed)
        {
            switch (Species)
            {
                case 296:{
                        if (pk.Met_Location == 5)
                        {
                            if (Lockfun.Makuhita(ref seed))
                                return true;
                            else
                                return false;
                        }
                        else
                        {
                            if (Lockfun.MakuhitaX(ref seed))
                                return true;
                            else
                                return false;
                        }
                    }
                case 207:{
                        if (Lockfun.Gligar(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 198:{
                        if (Lockfun.Murkrow(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 214:{
                        if (Lockfun.Heracross(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 217:{
                        if (Lockfun.Ursaring(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 280:{
                        if (Lockfun.Ralts(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 261:{
                        if (Lockfun.Poochyena(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 165:{
                        if (Lockfun.Ledyba(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 316:{
                        if (Lockfun.Gulpin(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 167:{
                        if (Lockfun.Spinarak(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 322:{
                        if (Lockfun.Numel(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 285:{
                        if (Lockfun.Shroomish(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 301:{
                        if (Lockfun.Delcatty(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 100:{
                        if (Lockfun.Voltorb(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 37:{
                        if (Lockfun.Vulpix(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 355:{
                        if (Lockfun.Duskull(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 303:{
                        if (Lockfun.Mawile(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 361:{
                        if (Lockfun.Snorunt(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 204:{
                        if (Lockfun.Pineco(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 177:{
                        if (Lockfun.Natu(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 315:{
                        if (Lockfun.Roselia(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 52:{
                        if (Lockfun.Meowth(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 220:{
                        if (Lockfun.Swinub(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 21:{
                        if (Lockfun.Spearow(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 88:{
                        if (Lockfun.Grimer(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 86:{
                        if (Lockfun.Seel(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 337:{
                        if (Lockfun.Lunatone(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 299:{
                        if (Lockfun.Nosepass(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 46:{
                        if (Lockfun.Paras(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 17:{
                        if (Lockfun.Pidgeotto(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 114:{
                        if (Lockfun.Tangela(ref seed))
                            return true;
                        else
                            return false;
                     }
                case 82:{
                        if (Lockfun.Magneton(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 49:{
                        if (Lockfun.Venomoth(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 24:{
                        if (Lockfun.Arbok(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 57:{ 
                        if (Lockfun.Primeape(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 55:{
                        if (Lockfun.Golduck(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 85:{
                        if (Lockfun.Dodrio(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 20:{
                        if (Lockfun.Raticate(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 83:{
                        if (Lockfun.Farfetchd(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 115:{
                        if (Lockfun.Kangaskhan(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 126:{
                        if (Lockfun.Magmar(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 78:{
                        if (Lockfun.Rapidash(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 107:{
                        if (Lockfun.Hitmonchan(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 106:{
                        if (Lockfun.Hitmonlee(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 108:{
                        if (Lockfun.Lickitung(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 123:{
                        if (Lockfun.Scyther(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 338:{
                        if (Lockfun.Solrock(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 121:{
                        if (Lockfun.Starmie(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 125:{
                        if (Lockfun.Electabuzz(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 62:{
                        if (Lockfun.Poliwrath(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 51:{
                        if (Lockfun.Dugtrio(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 310:{
                        if (Lockfun.Manectric(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 105:{
                        if (Lockfun.Marowak(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 149:{
                        if (Lockfun.Dragonite(ref seed)) 
                            return true;
                        else
                            return false;
                    }
                case 175:{
                        if (Lockfun.Togepi(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 179:{
                        if (Lockfun.Mareep(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 212:{
                        if (Lockfun.Scizor(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 363:{
                        if (pk.Met_Location == 11)
                        {
                            if (Lockfun.SphealCipherLab(ref seed))
                                return true;
                            else
                                return false;
                        }
                        else
                        {
                            if (Lockfun.SphealPhenacCityandPost(ref seed))
                                return true;
                            else
                                return false;
                        }
                    }
                case 273:{
                        if (pk.Met_Location == 11)
                        {
                            if (Lockfun.SeedotCipherLab(ref seed))
                                return true;
                            else
                                return false;
                        }
                        else
                        {
                            if (Lockfun.SeedotPhenacCity(ref seed))
                                return true;
                            else
                                return false;
                        }
                    }
                default:
                    return false;
            }
          
        }
    }
}
