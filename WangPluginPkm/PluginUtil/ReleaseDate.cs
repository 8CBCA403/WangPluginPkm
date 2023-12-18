using PKHeX.Core;
using System;
namespace WangPluginPkm;

public class ReleaseDate
{
    public ReleaseDate(GameVersion version)
    {
        Version = version;
    }

    private GameVersion Version { get; }

    public DateTime Date => GetReleaseDate();

    private DateTime GetReleaseDate()
    {
        return Version switch
        {
            GameVersion.RD => new DateTime(2016, 2, 27),
            GameVersion.BU => new DateTime(2016, 2, 27),
            GameVersion.YW => new DateTime(2016, 2, 27),
            GameVersion.GD => new DateTime(2017, 9, 22),
            GameVersion.SI => new DateTime(2017, 9, 22),
            GameVersion.C => new DateTime(2018, 1, 26),
            GameVersion.S => new DateTime(2002, 11, 21),
            GameVersion.R => new DateTime(2002, 11, 21),
            GameVersion.E => new DateTime(2004, 9, 16),
            GameVersion.FR => new DateTime(2004, 1, 29),
            GameVersion.LG => new DateTime(2004, 1, 29),
            GameVersion.D => new DateTime(2006, 9, 28),
            GameVersion.P => new DateTime(2006, 9, 28),
            GameVersion.Pt => new DateTime(2008, 9, 13),
            GameVersion.HG => new DateTime(2009, 9, 12),
            GameVersion.SS => new DateTime(2009, 9, 12),
            GameVersion.W => new DateTime(2010, 9, 18),
            GameVersion.B => new DateTime(2010, 9, 18),
            GameVersion.W2 => new DateTime(2012, 6, 23),
            GameVersion.B2 => new DateTime(2012, 6, 23),
            GameVersion.X => new DateTime(2013, 10, 12),
            GameVersion.Y => new DateTime(2013, 10, 12),
            GameVersion.AS => new DateTime(2014, 11, 21),
            GameVersion.OR => new DateTime(2014, 11, 21),
            GameVersion.SN => new DateTime(2016, 11, 18),
            GameVersion.MN => new DateTime(2016, 11, 18),
            GameVersion.US => new DateTime(2017, 11, 17),
            GameVersion.UM => new DateTime(2017, 11, 17),
            GameVersion.GP => new DateTime(2018, 11, 16),
            GameVersion.GE => new DateTime(2018, 11, 16),
            GameVersion.SW => new DateTime(2019, 11, 15),
            GameVersion.SH => new DateTime(2019, 11, 15),
            GameVersion.PLA => new DateTime(2022, 1, 28),
            GameVersion.BD => new DateTime(2021, 11, 19),
            GameVersion.SP => new DateTime(2021, 11, 19),
            GameVersion.SL => new DateTime(2022, 11, 18),
            GameVersion.VL => new DateTime(2022, 11, 18),
            _ => DateTime.Today
        };
    }
}