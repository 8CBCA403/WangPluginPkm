using PKHeX.Core;
using PKHeX.Core.Searching;
using System.Collections.Generic;
using System.Linq;
namespace WangPluginPkm
{
    internal class SearchDatabase
    {
        public static GameStrings GameStrings = GameInfo.GetStrings("zh-Hans");
        public static PKM SearchPKM(ISaveFileProvider SAV, IPKMView Editor, ushort species, int version, int form = 0, bool egg = false, int location = 0, int gender = 0, int r = 0, int level = 0)
        {
            var setting = new SearchSettings
            {
                SearchShiny = false,
                Species = species,
                SearchEgg = egg,
                Version = (GameVersion)version,
            };

            var search = EncounterUtil.SearchDatabase(setting, SAV.SAV);
            var results = search.ToList();

            // Filter by form if specified
            if (form != 0)
            {
                results = results.Where(pkm => pkm.Form == form).ToList();
            }

            // Ensure results is not empty
            if (results.Count == 0) return null;

            // Filter by location if specified
            if (location != 0)
            {
                results = results.Where(pkm => pkm.ConvertToPKM(SAV.SAV).MetLocation == location).ToList();
                if (results.Count == 0) return null;
            }

            // Filter by gender if specified
            if (gender != 0)
            {
                results = results.Where(pkm => pkm.ConvertToPKM(SAV.SAV).Gender == gender - 1).ToList();
                if (results.Count == 0) return null;
            }

            // Filter by level if specified
            if (level != 0)
            {
                results = results.Where(pkm => pkm.ConvertToPKM(SAV.SAV).MetLevel == level).ToList();
                if (results.Count == 0) return null;
            }

            // Get the 'r' indexed PKM from the results
            var enc = results.ElementAtOrDefault(r);
            if (enc == null) return null;

            PKM pk = enc.ConvertToPKM(SAV.SAV);

            // Convert the PKM to the appropriate type
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
            var results = search.ToList(); // Ensure we have a concrete list

            // Filter by form if specified
            if (form != 0)
            {
                results = results.Where(pkm => pkm.Form == form).ToList();
            }

            // If no results, return empty list
            if (!results.Any())
            {
                return new List<PKM>();
            }

            // Convert results to PKM list
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
            // 获取所有事件并转换为列表
            var db = EncounterEvent.GetAllEvents();
            var rawDB = new List<MysteryGift>(db);

            // 筛选符合条件的神秘礼物
            var results = rawDB
                .Where(pkm => pkm.Species == species && pkm.Form == form && pkm.Generation == version)
                .ToList();

            // 如果没有找到符合条件的结果，返回 null
            if (results.Count == 0)
            {
                return null;
            }

            // 返回第一个符合条件的 PKM
            var pkc = results[0].ConvertToPKM(SAV.SAV);
            // 如果需要类型转换，可以启用以下代码
            // pkc = EntityConverter.ConvertToType(pkc, SAV.SAV.PKMType, out var r1);

            return pkc;
        }

        public static bool MytheryPKList(ref List<PKM> L, ISaveFileProvider SAV, ushort species, int version, int form = 0)
        {
            var db = EncounterEvent.GetAllEvents();
            var RawDB = new List<MysteryGift>(db);

            // 合并筛选条件
            var results = RawDB
                .Where(pkm => pkm.Species == species && pkm.Form == form && pkm.Generation == version)
                .ToList();

            // 如果没有符合条件的结果，返回 false
            if (results.Count == 0)
            {
                return false;
            }

            // 清空传入的 List<PKM>，确保添加新的数据
            L.Clear();

            // 将符合条件的 MysteryGift 转换为 PKM 并添加到列表
            foreach (var gift in results)
            {
                var pkc = gift.ConvertToPKM(SAV.SAV);
                // 可以启用以下代码来进行兼容性转换
                // EntityConverter.TryMakePKMCompatible(pkc, pk, out var c, out pkc);
                L.Add(pkc);
            }

            return true;
        }

        public static PKM MytheryLanguage(ISaveFileProvider SAV, ushort species, int version, int form = 0, int language = 1)
        {
            var db = EncounterEvent.GetAllEvents();
            var rawDB = new List<MysteryGift>(db);

            // 合并筛选条件
            var results = rawDB
                .Where(pkm => pkm.Species == species && pkm.Form == form && pkm.Generation == version)
                .ToList();

            // 如果没有找到符合条件的宝可梦，返回 null
            if (results.Count == 0)
            {
                return null;
            }

            // 遍历符合条件的宝可梦并进行处理
            string OT = "";
            foreach (var gift in results)
            {
                var g = (WC8)gift;
                OT = g.GetOT(language);
                var pkc = gift.ConvertToPKM(SAV.SAV);
                pkc.Language = language;
                pkc.OriginalTrainerName = OT;
                pkc.ClearNickname(); // 清除昵称
                return pkc; // 返回第一个符合条件的宝可梦
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

            // 如果没有符合条件的结果，返回 "无法匹配"
            if (results.Length == 0)
            {
                return "无法匹配";
            }

            // 获取第一个符合条件的结果
            var gift = results[0];

            // 处理 WC6 类型的礼物
            if (gift.Type == "WC6")
            {
                var WC6gift = (WC6)gift;
                return $"Name: {GameStrings.Species[WC6gift.Species]} CardHeader: {WC6gift.CardHeader}";
            }

            return "无法匹配";
        }

        public static PKM SearchPK(ISaveFileProvider SAV, IPKMView Editor, ushort species, int version, EncounterCriteria En, int form = 0, bool egg = false, int location = 0, int gender = 0, int r = 0)
        {
            List<IEncounterInfo> Results;
            IEncounterInfo enc;
            var setting = new SearchSettings
            {
                Species = species,
                SearchEgg = egg,
                Version = (GameVersion)version,
            };
            var search = EncounterUtil.SearchDatabase(setting, SAV.SAV);
            var results = search.ToList();
            IEnumerable<IEncounterInfo> res = results;
            if (form != 0)
            {
                res = res.Where(pkm => pkm.Form == form);
                if (res.Count() != 0)
                    results = res.ToList();
            }
            PKM pk = Editor.Data;
            if (results.Count != 0)
            {
                Results = results;
                enc = Results[r];
                pk = enc.ConvertToPKM(SAV.SAV, En);
                if (location != 0)
                {
                    for (int i = 0; ; i++)
                    {
                        enc = Results[i];
                        pk = enc.ConvertToPKM(SAV.SAV, En);
                        if (pk.MetLocation == location)
                            break;
                    }
                }
                if (gender != 0)
                {
                    for (int i = 0; i < Results.Count; i++)
                    {
                        enc = Results[i];
                        pk = enc.ConvertToPKM(SAV.SAV, En);
                        if (pk.Gender == 1)
                            break;
                    }
                    pk.Gender = 1;
                }

            }
            return pk;
        }
        public static PKM SearchPKMBW(ISaveFileProvider SAV, IPKMView Editor, ushort species, int version, int loc = 0, int r = 0)
        {
            List<IEncounterInfo> Results;
            IEncounterInfo enc;
            var setting = new SearchSettings
            {
                Species = species,
                SearchEgg = false,
                Version = (GameVersion)version,
            };
            var search = EncounterUtil.SearchDatabase(setting, SAV.SAV);
            var results = search.ToList();
            IEnumerable<IEncounterInfo> res = results;

            PKM pk = Editor.Data;
            if (results.Count != 0)
            {
                Results = results;
                enc = Results[r];
                pk = enc.ConvertToPKM(SAV.SAV);
                if (loc != 0)
                {
                    for (int i = 0; ; i++)
                    {
                        enc = Results[i];
                        pk = enc.ConvertToPKM(SAV.SAV);

                        if (pk.MetLocation != loc)
                            break;
                    }
                }

                pk = EntityConverter.ConvertToType(pk, SAV.SAV.PKMType, out var r2);

            }
            return pk;
        }


    }
}

