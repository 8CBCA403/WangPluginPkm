using PKHeX.Core.AutoMod;
using PKHeX.Core;

namespace WangPlugin
{
    public static class FindNestPIDIV
    {
        public static void PreSetPIDIV(this PKM pk, IEncounterable enc)
        {
          
            if (enc is EncounterStatic8N or EncounterStatic8NC or EncounterStatic8ND or EncounterStatic8U)
            {

                var e = (EncounterStatic)enc;
                var isShiny = pk.IsShiny;
                if (pk.AbilityNumber == 4 && e.Ability is AbilityPermission.Any12 or AbilityPermission.OnlyFirst or AbilityPermission.OnlySecond)
                    return;
                

                var pk8 = (PK8)pk;
                switch (e)
                {
                    case EncounterStatic8NC c: FindNestPID(pk8, c, isShiny); break;
                    case EncounterStatic8ND c: FindNestPID(pk8, c, isShiny); break;
                    case EncounterStatic8N c: FindNestPID(pk8, c, isShiny); break;
                    case EncounterStatic8U c: FindNestPID(pk8, c, isShiny); break;
                }
            }
        }
            public static void FindNestPID<T>( PK8 pk, T enc, bool shiny) where T : EncounterStatic8Nest<T>
        {
            // Preserve Nature, Form (all abilities should be possible in gen 8, so no need to early return on a mismatch for enc HA bool vs set HA bool)
            // Nest encounter RNG generation
            var iterPKM = pk.Clone();
           
            if (shiny && enc is not EncounterStatic8U)
                return;

            if (pk.Species == (int)Species.Toxtricity && pk.Form != EvolutionMethod.GetAmpLowKeyResult(pk.Nature))
            {
                enc.ApplyDetailsTo(pk, GetRandomULong());
                pk.RefreshAbility(iterPKM.AbilityNumber >> 1);
                pk.StatNature = iterPKM.StatNature;
                return;
            }

            var count = 0;
            do
            {
                ulong seed = GetRandomULong();
                enc.ApplyDetailsTo(pk, seed);
                if (IsMatchCriteria<T>(pk, iterPKM))
                    break;
            } while (++count < 10_000);

            if (shiny)
            {
                // Dynamax Adventure shinies are always XOR 1
                pk.PID = SimpleEdits.GetShinyPID(pk.TID, pk.SID, pk.PID, 1);
            }

            pk.Species = iterPKM.Species; // possible evolution
            // can be ability capsuled
            if (FormInfo.IsFormChangeable(pk.Species, pk.Form, iterPKM.Form, pk.Format))
                pk.Form = iterPKM.Form; // set alt form if it can be freely changed!
            pk.RefreshAbility(iterPKM.AbilityNumber >> 1);
            pk.StatNature = iterPKM.StatNature;
        }
        public static ulong GetRandomULong()
        {
            return ((ulong)Util.Rand.Next(1 << 30) << 34) | ((ulong)Util.Rand.Next(1 << 30) << 4) | (uint)Util.Rand.Next(1 << 4);
        }
        public static bool IsMatchCriteria<T>(PK8 pk, PKM template) where T : EncounterStatic8Nest<T>
        {
            if (template.Nature != pk.Nature) // match nature
                return false;
            if (template.Gender != pk.Gender) // match gender
                return false;
            if (template.Form != pk.Form && !FormInfo.IsFormChangeable(pk.Species, pk.Form, template.Form, pk.Format)) // match form -- Toxtricity etc
                return false;
            return true;
        }
    }
}
