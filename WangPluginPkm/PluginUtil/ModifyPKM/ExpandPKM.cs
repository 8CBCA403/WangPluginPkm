using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKHeX.Core;
namespace WangPluginPkm.PluginUtil.ModifyPKM
{
    public class ExpandPKM
    {
      public PKM pk { get; set; }
      public string Name ;
        public override string ToString()
        {
            return Name;
        }

    }
   
}
