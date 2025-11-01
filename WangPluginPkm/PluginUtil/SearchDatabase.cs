using PKHeX.Core;
using PKHeX.Core.Searching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace WangPluginPkm
{
    internal class SearchDatabase
    {
        public static GameStrings GameStrings = GameInfo.GetStrings("zh-Hans");
    
        public static PKM SearchPKM(ISaveFileProvider SAV, IPKMView Editor, ushort species, int version, int form = 0, bool egg = false, int location = 0, int gender = 0, int r = 0, byte level = 0)
        {
            var setting = new SearchSettings
            {
                SearchShiny = false,
                Species = species,
                SearchEgg = egg,
                Level=level,
                
                SearchLevel = SearchComparison.Equals,
                Version = (GameVersion)version,
            };
            var search = EncounterUtil.SearchDatabase(setting, SAV.SAV);
            var results = search.ToList();
            if (form != 0)
            {
                results = results.Where(pkm => pkm.Form == form).ToList();
            }
            if (results.Count == 0) return null;
            if (location != 0)
            {
                results = results.Where(pkm => pkm.ConvertToPKM(SAV.SAV).MetLocation == location).ToList();
                if (results.Count == 0) return null;
            }
            if (gender != 0)
            {
                results = results.Where(pkm => pkm.ConvertToPKM(SAV.SAV).Gender == gender - 1).ToList();
                if (results.Count == 0) return null;
            }
            
            var enc = results.ElementAtOrDefault(r);
            if (enc == null) return null;

            PKM pk = enc.ConvertToPKM(SAV.SAV);
            pk = EntityConverter.ConvertToType(pk, SAV.SAV.PKMType, out var r2);

            return pk;
        }
        public static List<PKM> SearchPKMList(ISaveFileProvider SAV, IPKMView Editor, ushort species, int version, int form = 0, bool egg = false)
        {
            var setting = new SearchSettings
            {
                Species = species,
                SearchEgg = egg,
                Version = (GameVersion)version,
            };
            var search = EncounterUtil.SearchDatabase(setting, SAV.SAV);
            var results = search.ToList(); 
            if (form != 0)
            {
                results = results.Where(pkm => pkm.Form == form).ToList();
            }
            if (!results.Any())
            {
                return new List<PKM>();
            }
            var pkl = results.Select(en =>
            {
                var pk = en.ConvertToPKM(SAV.SAV);
                return EntityConverter.ConvertToType(pk, SAV.SAV.PKMType, out var r1);
            }).ToList();

            return pkl;
        }

        public static PKM GetGodPkm(ISaveFileProvider SAV, IPKMView Editor, ushort species)
        {
            var setting = new SearchSettings
            {
                Species = species,
                SearchEgg = false,
                Version = (GameVersion)(int)SAV.SAV.Version,
            };

            var search = EncounterUtil.SearchDatabase(setting, SAV.SAV);
            var results = search.ToList();

            // 如果没有找到任何匹配的宝可梦，返回 null
            if (results.Count == 0)
            {
                return null;
            }

            // 遍历所有结果，找到第一个符合条件的宝可梦
            foreach (var enc in results)
            {
                var pk = enc.ConvertToPKM(SAV.SAV);

                // 检查 MetLocation 是否为 244
                if (pk.MetLocation == 244)
                {
                    // 如果找到，直接返回
                    return pk;
                }
            }

            // 如果没有符合条件的宝可梦，返回 null
            return null;
        }

        public static PKM MytheryPK(ISaveFileProvider SAV, ushort species, int version, int form = 0)
        {
            var db = EncounterEvent.GetAllEvents();
            var rawDB = new List<MysteryGift>(db);
            var results = rawDB
                .Where(pkm => pkm.Species == species && pkm.Form == form && pkm.Generation == version)
                .ToList();
            if (results.Count == 0)
            {
                return null;
            }
            var pkc = results[0].ConvertToPKM(SAV.SAV);
            return pkc;
        }

        public static bool MytheryPKList(ref List<PKM> L, ISaveFileProvider SAV, ushort species, int version, int form = 0)
        {
            var db = EncounterEvent.GetAllEvents();
            var RawDB = new List<MysteryGift>(db);
            var results = RawDB
                .Where(pkm => pkm.Species == species && pkm.Form == form && pkm.Generation == version)
                .ToList();
            if (results.Count == 0)
            {
                return false;
            }
            L.Clear();
            foreach (var gift in results)
            {
                var pkc = gift.ConvertToPKM(SAV.SAV);
                L.Add(pkc);
            }

            return true;
        }

        public static PKM MytheryLanguage(ISaveFileProvider SAV, ushort species, int version, int form = 0, int language = 1)
        {
            var db = EncounterEvent.GetAllEvents();
            var rawDB = new List<MysteryGift>(db);
            var results = rawDB
                .Where(pkm => pkm.Species == species && pkm.Form == form && pkm.Generation == version)
                .ToList();
            if (results.Count == 0)
            {
                return null;
            }
            string OT = "";
            foreach (var gift in results)
            {
                var g = (WC8)gift;
                OT = g.GetOT(language);
                var pkc = gift.ConvertToPKM(SAV.SAV);
                pkc.Language = language;
                pkc.OriginalTrainerName = OT;
                pkc.ClearNickname(); 
                return pkc; 
            }

            return null;
        }

        public static string SearchMytheryGift(ushort species, int Generation, string otname, int SID16, int TID16, int form = 0)
        {
            var db = EncounterEvent.GetAllEvents();
            var RawDB = new List<MysteryGift>(db);
            var results = RawDB
                .Where(pkm => pkm.Species == species &&
                              pkm.Form == form &&
                              pkm.Generation == Generation &&
                              pkm.OriginalTrainerName == otname &&
                              pkm.SID16 == SID16 &&
                              pkm.TID16 == TID16)
                .ToArray();
            if (results.Length == 0)
            {
                return "无法匹配";
            }
            var gift = results[0];
            if (gift.Type == "WC6")
            {
                var WC6gift = (WC6)gift;
                return $"Name: {GameStrings.Species[WC6gift.Species]} CardHeader: {WC6gift.CardHeader}";
            }

            return "无法匹配";
        }

        public static PKM SearchPK(ISaveFileProvider SAV, IPKMView Editor, ushort species, int version, EncounterCriteria En, int form = 0, bool egg = false, int location = 0, int gender = 0, int r = 0)
        {
            var setting = new SearchSettings
            {
                Species = species,
                SearchEgg = egg,
                Version = (GameVersion)version,
            };
            var results = EncounterUtil.SearchDatabase(setting, SAV.SAV).ToList();
            if (form != 0)
                results = results.Where(pkm => pkm.Form == form).ToList();
            if (results.Count == 0)
                return Editor.Data;
            var enc = results.ElementAtOrDefault(r);
            if (enc == null)
                return Editor.Data;
            var pk = enc.ConvertToPKM(SAV.SAV, En);
            if (location != 0)
                results = results.Where(p => p.ConvertToPKM(SAV.SAV, En).MetLocation == location).ToList();
            if (gender != 0)
                results = results.Where(p => p.ConvertToPKM(SAV.SAV, En).Gender == gender).ToList();
            if (results.Count == 0)
                return Editor.Data;
            enc = results.ElementAtOrDefault(r);
            return enc?.ConvertToPKM(SAV.SAV, En) ?? Editor.Data;
        }

        public static PKM SearchPKMBW(ISaveFileProvider SAV, IPKMView Editor, ushort species, int version, int loc = 0, int r = 0)
        {
            var setting = new SearchSettings
            {
                Species = species,
                SearchEgg = false,
                Version = (GameVersion)version,
            };

            var results = EncounterUtil.SearchDatabase(setting, SAV.SAV).ToList();
            if (results.Count == 0)
                return Editor.Data;
            var enc = results.ElementAtOrDefault(r);
            if (enc == null)
                return Editor.Data;
            var pk = enc.ConvertToPKM(SAV.SAV);
            if (loc != 0)
            {
                var matchingLocation = results.FirstOrDefault(p => p.ConvertToPKM(SAV.SAV).MetLocation == loc);
                if (matchingLocation != null)
                    pk = matchingLocation.ConvertToPKM(SAV.SAV);
            }
            pk = EntityConverter.ConvertToType(pk, SAV.SAV.PKMType, out var r2);

            return pk;
        }

        public static PKM GetWildGen3PKM(ISaveFileProvider provider, ushort species)
        {
            var sav = provider.SAV;
            var version = GameVersion.E; 
            var flags = EncounterTypeGroup.Slot; 
            var evo = new EvoCriteria { Species = species };

            var encounters = new EncounterPossible3([evo], flags, version);
            while (encounters.MoveNext())
            {
                var enc = encounters.Current;
                var pkm = enc.ConvertToPKM(sav);
                var converted = EntityConverter.ConvertToType(pkm, sav.PKMType, out _);
                return converted;
            }

            return null!; 
        }
        public static PKM GetWildGen1PKM(ISaveFileProvider provider, ushort species, GameVersion version, int level = 0)
        {
            var sav = provider.SAV;
            var evo = new EvoCriteria { Species = species };
            var encounters = new EncounterPossible1([evo], EncounterTypeGroup.Slot, version);

            while (encounters.MoveNext())
            {
                var raw = encounters.Current.ConvertToPKM(sav);
                var pkm = EntityConverter.ConvertToType(raw, sav.PKMType, out _);

                if (level == 0 || pkm.MetLevel == level)
                    return pkm;
            }

            return null;
        }
        public static PKM GetWildGen4PKM(SaveFile sav, ushort species, GameVersion version,Gender gender)
        {
            var blank = EntityBlank.GetBlank(sav.PKMType);
            blank.Version = version;
            var evo = new[] {
            new EvoCriteria {
            Species = species,
            Form = 0,
            LevelMin = 1,
            LevelMax = 100,
            LevelUpRequired = 0,
            Method = EvolutionType.None
                }
            };
            var flags = EncounterTypeGroup.Slot;
            var ep4 = new EncounterPossible4(evo, flags, version, blank);
            while (ep4.MoveNext())
            {
                var enc = ep4.Current;
                var pkm = enc.ConvertToPKM(sav);

                if (pkm.Gender == (byte)gender)
                {
                    return EntityConverter.ConvertToType(pkm, sav.PKMType, out _);
                }
            }
            return null;
        }
        public static PKM GetWildGen5PKM(SaveFile sav, ushort species, GameVersion version, Gender gender)
        {
        var evo = new[] {
        new EvoCriteria {
        Species = species,
        Form = 0,
        LevelMin = 1,
        LevelMax = 100,
        LevelUpRequired = 0,
        Method = EvolutionType.None
            }
         };
            var flags = EncounterTypeGroup.Slot;
            var ep4 = new EncounterPossible5(evo, flags, version);
            while (ep4.MoveNext())
            {
                var enc = ep4.Current;
                var pkm = enc.ConvertToPKM(sav);

                if (pkm.Gender == (byte)gender) 
                {
                    return EntityConverter.ConvertToType(pkm, sav.PKMType, out _);
                }
            }
            return null;
        }

 
    }
}

