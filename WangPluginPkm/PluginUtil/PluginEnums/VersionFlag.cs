using PKHeX.Core;
using System;

namespace WangPluginPkm
{
    internal class VersionFlag
    {
        public static bool Gen3Flag(GameVersion version)
        {
            return version is GameVersion.S or GameVersion.R or GameVersion.E or GameVersion.FR or GameVersion.LG;
        }

        public static bool Gen4Flag(GameVersion version)
        {
            return version is GameVersion.D or GameVersion.P or GameVersion.Pt or GameVersion.HG or GameVersion.SS;
        }

        public static bool Gen5Flag(GameVersion version)
        {
            return version is GameVersion.W or GameVersion.B or GameVersion.W2 or GameVersion.B2;
        }

        public static bool Gen6Flag(GameVersion version)
        {
            return version is GameVersion.X or GameVersion.Y or GameVersion.AS or GameVersion.OR;
        }

        public static bool Gen7Flag(GameVersion version)
        {
            return version is GameVersion.SN or GameVersion.MN or GameVersion.US or GameVersion.UM or
                   GameVersion.GP or GameVersion.GE;
        }

        public static bool Gen8SWSHFlag(GameVersion version)
        {
            return version is GameVersion.SW or GameVersion.SH;
        }

        public static bool Gen8BDSPFlag(GameVersion version)
        {
            return version is GameVersion.BD or GameVersion.SP;
        }

        public static bool Gen8PLAFlag(GameVersion version)
        {
            return version is GameVersion.PLA;
        }

        public static bool Gen1VCFlag(GameVersion version)
        {
            return version is GameVersion.RBY or GameVersion.RB or GameVersion.YW or GameVersion.RD;
        }

        public static bool Gen2VCFlag(GameVersion version)
        {
            return version is GameVersion.GSC or GameVersion.GS or GameVersion.C;
        }

        public static bool CXDFlag(GameVersion version)
        {
            return version is GameVersion.CXD;
        }

        public static bool Gen9Flag(GameVersion version)
        {
            return version is GameVersion.SL or GameVersion.VL;
        }
        public static bool Gen9aFlag(GameVersion version)
        {
            return version is GameVersion.ZA;
        }
        public static bool ID7Flag(GameVersion version)
        {
            return version is GameVersion.SN or GameVersion.MN or GameVersion.US or GameVersion.UM or
                   GameVersion.GP or GameVersion.GE or GameVersion.SW or GameVersion.SH or GameVersion.PLA or
                   GameVersion.BD or GameVersion.SP or GameVersion.VL or GameVersion.SL or GameVersion.SV;
        }
    }
}
