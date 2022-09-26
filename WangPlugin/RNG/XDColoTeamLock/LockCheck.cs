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
                    if(Lockfun.Makuhita(ref seed))
                        return true;
                    else
                        return false;
                case 207:
                    if (Lockfun.Gligar(ref seed))
                        return true;
                    else
                        return false;
                case 198:
                    if (Lockfun.Murkrow(ref seed))
                        return true;
                    else
                        return false;
                case 214:
                    if (Lockfun.Heracross(ref seed))
                        return true;
                    else
                        return false;
                case 217:
                    if (Lockfun.Ursaring(ref seed))
                        return true;
                    else
                        return false;
                default:
                    return false;
            }
          
        }
    }
}
