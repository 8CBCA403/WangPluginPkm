using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPlugin
{
    public class LockCheck
    {
        public static bool ChooseLock(ushort s, PKM pk, ref uint seed)
        {
            switch (s)
            {
                case 296:
                    {
                        if (Lockfun.Makuhita(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 207:
                    {
                        if (Lockfun.Gligar(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 198:
                    {
                        if (Lockfun.Murkrow(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 214:
                    {
                        if (Lockfun.Heracross(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 217:
                    {
                        if (Lockfun.Ursaring(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 280:
                    {
                        if (Lockfun.Ralts(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 261:
                    {
                        if (Lockfun.Poochyena(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 165:
                    {
                        if (Lockfun.Ledyba(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 316:
                    {
                        if (Lockfun.Gulpin(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 167:
                    {
                        if (Lockfun.Spinarak(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 322:
                    {
                        if (Lockfun.Numel(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 285:
                    {
                        if (Lockfun.Shroomish(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 301:
                    {
                        if (Lockfun.Delcatty(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 100:
                    {
                        if (Lockfun.Voltorb(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 37:
                    {
                        if (Lockfun.Vulpix(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 355:
                    {
                        if (Lockfun.Duskull(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 303:
                    {
                        if (Lockfun.Mawile(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 361:
                    {
                        if (Lockfun.Snorunt(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 204:
                    {
                        if (Lockfun.Pineco(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 177:
                    {
                        if (Lockfun.Natu(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 315:
                    {
                        if (Lockfun.Roselia(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 52:
                    {
                        if (Lockfun.Meowth(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 220:
                    {
                        if (Lockfun.Swinub(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 21:
                    {
                        if (Lockfun.Spearow(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 88:
                    {
                        if (Lockfun.Grimer(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 86:
                    {
                        if (Lockfun.Seel(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 337:
                    {
                        if (Lockfun.Lunatone(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 299:
                    {
                        if (Lockfun.Nosepass(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 46:
                    {
                        if (Lockfun.Paras(ref seed))
                            return true;
                        else
                            return false;
                    }
                case 17:
                    {
                        if (Lockfun.Pidgeotto(ref seed))
                            return true;
                        else
                            return false;
                    }
                default:
                    return false;
            }
          
        }
    }
}
