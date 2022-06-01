using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using PKHeX.Core.Searching;
using PKHeX.Core;

namespace WangPlugin
{
    internal class EncounterUtil
    {
        public static IEnumerable<IEncounterInfo> SearchDatabase(SearchSettings settings, SaveFile SAV)
        {
            var versions = settings.GetVersions(SAV);
            var pk = SAV.BlankPKM;
            var species = settings.Species;
            var results = EncounterUtil.GetAllSpeciesFormEncounters(species, SAV.Personal, versions, pk);
            results = results.Where(z => z.EggEncounter == settings.SearchEgg);
            // return filtered results
            var comparer = new ReferenceComparer<IEncounterInfo>();
            results = results.Distinct(comparer); // only distinct objects
            return results;
        }
        private static IEnumerable<IEncounterInfo> GetAllSpeciesFormEncounters(int species, PersonalTable pt, IReadOnlyList<GameVersion> versions, PKM pk)
        {
            var pi = pt.GetFormEntry(species, 0);
            var fc = pi.FormCount;
            for (int f = 0; f < fc; f++)
            {
                if (FormInfo.IsBattleOnlyForm(species, f, pk.Format))
                    continue;
                var encs = GetEncounters(species, f, pk, versions);
                foreach (var enc in encs)
                    yield return enc;
            }
        }

        /// <summary>
        ///  species: 
        /// </summary>
        /// <param name="species"></param>
        /// <returns></returns>
        public static IEnumerable<IEncounterInfo> GetEncounters(int species, int form, PKM pkm, IReadOnlyList<GameVersion> versions)
        {
            pkm.Species = species;
            pkm.Form = form;
            pkm.SetGender(pkm.GetSaneGender());
            return EncounterMovesetGenerator.GenerateEncounters(pkm, null, versions);
        }
        public static EncounterCriteria GetCriteria(ISpeciesForm enc, PKM editor)
        {
            //if any then return EncounterCriteria.Unrestricted;

            var tree = EvolutionTree.GetEvolutionTree(editor.Context);
            bool isInChain = tree.IsSpeciesDerivedFrom(editor.Species, editor.Form, enc.Species, enc.Form);
            var set = new ShowdownSet(editor);
            var criteria = EncounterCriteria.GetCriteria(set, editor.PersonalInfo);
            if (!isInChain)
                criteria = criteria with { Gender = -1 }; // Genderless tabs and a gendered enc -> let's play safe.
            return criteria;
        }
        sealed class ReferenceComparer<T> : IEqualityComparer<T> where T : class
        {
#pragma warning disable CS8632 // 只能在 "#nullable" 注释上下文内的代码中使用可为 null 的引用类型的注释。
            public bool Equals(T? x, T? y)
#pragma warning restore CS8632 // 只能在 "#nullable" 注释上下文内的代码中使用可为 null 的引用类型的注释。
            {
                if (x == null)
                    return false;
                if (y == null)
                    return false;
                return RuntimeHelpers.GetHashCode(x).Equals(RuntimeHelpers.GetHashCode(y));
            }

            public int GetHashCode(T obj)
            {
                if (obj == null) throw new ArgumentNullException(nameof(obj));
                return RuntimeHelpers.GetHashCode(obj);
            }
        }
    }
}
