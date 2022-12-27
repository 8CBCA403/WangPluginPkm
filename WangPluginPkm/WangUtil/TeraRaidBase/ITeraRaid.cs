using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm.WangUtil.TeraRaidBase
{

    public interface ITeraRaid
    {
        ushort Species { get; }
        byte Form { get; }
        sbyte Gender { get; }
        AbilityPermission Ability { get; }
        byte FlawlessIVCount { get; }
        Shiny Shiny { get; }
        byte Level { get; }
        ushort Move1 { get; }
        ushort Move2 { get; }
        ushort Move3 { get; }
        ushort Move4 { get; }
        byte Stars { get; }
        byte RandRate { get; }

        ushort[] ExtraMoves { get; }
    }

}
