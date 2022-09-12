using PKHeX.Core.Searching;
using PKHeX.Core;
using System.Collections.Generic;
using System.Linq;

namespace WangPlugin
{
    internal class SearchDatabase
    {
        public static PKM SearchPKM(ISaveFileProvider SAV, IPKMView Editor, ushort species, int version, int form = 0, bool egg=false, int location =0)
        {
            List<IEncounterInfo> Results;
            IEncounterInfo enc;
            var setting = new SearchSettings
            {
                Species = species,
                SearchEgg = egg,
                Version = version,
            };
            var search = EncounterUtil.SearchDatabase(setting, SAV.SAV);
            var results = search.ToList();
            IEnumerable<IEncounterInfo> res = results;
            if (form != 0)
            {
                res = res.Where(pkm => pkm.Form == form);
                if(res.Count()!=0)
                results =res.ToList();
            }
            PKM pk = Editor.Data;
            if (results.Count != 0)
            {
                Results = results;
                enc = Results[0];
                pk = enc.ConvertToPKM(SAV.SAV);
                if (location != 0)
                {
                    for (int i = 0; ; i++)
                    {
                        enc = Results[i];
                        pk = enc.ConvertToPKM(SAV.SAV);
                        if (pk.Met_Location == location)
                            break;
                    }
                }
               
            }
            return pk;
        }
        public static PKM GetGodPkm(ISaveFileProvider SAV, IPKMView Editor, ushort species)
        {
            List<IEncounterInfo> Results;
            IEncounterInfo enc;
            var setting = new SearchSettings
            {
                Species = species,
                SearchEgg = false,
                Version = (int)SAV.SAV.Version,
            };
            var search = EncounterUtil.SearchDatabase(setting, SAV.SAV);
            var results = search.ToList();
            PKM pk = Editor.Data;
            if (results.Count != 0)
            {
                for (int i = 0; ; i++)
                {
                    Results = results;
                    enc = Results[i];
                    pk = enc.ConvertToPKM(SAV.SAV);
                    if (pk.Met_Location == 244)
                        break;
                }
            }
            return pk;
        }
        public static PKM MytheryPK(ISaveFileProvider SAV, IPKMView Editor, ushort species, int version,int form=0)
        {
            var db = EncounterEvent.GetAllEvents();
            var RawDB = new List<MysteryGift>(db);
            PKM pkc;
            List<PKM> p = new();
            IEnumerable<MysteryGift> res = RawDB;
            res = res.Where(pkm => pkm.Species == species);
            res = res.Where(pkm => pkm.Form == form);
            res = res.Where(pkm => pkm.Generation == version);
            var results = res.ToArray();
            if (results.Count() != 0)
            {
                foreach (MysteryGift gift in results)
                {
                    pkc = gift.ConvertToPKM(SAV.SAV);
                   // EntityConverter.TryMakePKMCompatible(pkc, pk, out var c, out pkc);
                    p.Add(pkc);
                }
            }
            return p[0];
            }
        }
}
