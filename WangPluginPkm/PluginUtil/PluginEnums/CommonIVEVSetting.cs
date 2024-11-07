using PKHeX.Core;
using System;

namespace WangPluginPkm
{
    internal class CommonIVEVSetting
    {
        public static PKM ATKIVEV(PKM pk)
        {
            int[] iv = { 31, 31, 31, 31, 31, 31 };
            int[] ev = { 6, 252, 0, 252, 0, 0 };
            pk.IVs = iv;
            pk.SetEVs(ev);
            pk.Nature = (Nature)13;
            pk.StatNature = pk.Nature;
            return pk;
        }
        public static PKM SPAIVEV(PKM pk)
        {
            int[] iv = { 31, 0, 31, 31, 31, 31 };
            int[] ev = { 6, 0, 0, 252, 252, 0 };
            pk.IVs = iv;
            pk.SetEVs(ev);
            pk.Nature = (Nature)10;
            pk.StatNature = pk.Nature;
            return pk;
        }
        public static PKM ATK_0SPEIVEV(PKM pk)
        {
            int[] iv = { 31, 31, 31, 0, 31, 31 };
            int[] ev = { 252, 252, 0, 0, 0, 6 };
            pk.IVs = iv;
            pk.SetEVs(ev);
            pk.Nature = (Nature)2;
            pk.StatNature = pk.Nature;
            return pk;
        }
        public static PKM SPA_0SPEIVEV(PKM pk)
        {
            int[] iv = { 31, 0, 31, 0, 31, 31 };
            int[] ev = { 252, 0, 0, 0, 252, 6 };
            pk.IVs = iv;
            pk.SetEVs(ev);
            pk.Nature = (Nature)17;
            pk.StatNature = pk.Nature;
            return pk;
        }
        public static PKM TANKIVEV(PKM pk)
        {
            int[] iv = { 31, 0, 31, 0, 31, 31 };
            int[] ev = { 252, 0, 6, 0, 0, 252 };
            pk.IVs = iv;
            pk.SetEVs(ev);
            pk.Nature = (Nature)22;
            pk.StatNature = pk.Nature;
            return pk;
        }
        public static PKM Clearnike(PKM pk)
        {
            ClearOTTrash(pk,pk.OriginalTrainerName);
            ClearOTTrash(pk,pk.Nickname);
            return pk;
        }
        public static PK9 cid(PK9 pk, ISaveFileProvider sav)
        {
            pk.Language = sav.SAV.Language;
            pk.TrainerTID7 = sav.SAV.TrainerTID7;
            pk.TrainerSID7 = sav.SAV.TrainerSID7;
            pk.OriginalTrainerGender = sav.SAV.Gender;
            pk.OriginalTrainerName = sav.SAV.OT;
            pk.ObedienceLevel = 1;
            RibbonApplicator.RemoveAllValidRibbons(pk);
            pk.HandlingTrainerLanguage = 0;
            pk.HandlingTrainerGender = 0;
            pk.HandlingTrainerName = "";
            pk.SetMarking(0, MarkingColor.None);
            pk.SetMarking(1, MarkingColor.None);
            pk.SetMarking(2, MarkingColor.None);
            pk.SetMarking(3, MarkingColor.None);
            pk.SetMarking(4, MarkingColor.None);
            pk.SetMarking(5, MarkingColor.None);

            pk.HandlingTrainerFriendship = 0;
            pk.HandlingTrainerTrash.Clear();
            pk.NicknameTrash.Clear();
            pk.ClearNickname();
            return pk;
        }
        public static void ClearOTTrash(PKM pokemon, string OT)
        {
            Span<byte> trash = pokemon.OriginalTrainerTrash;
            trash.Clear();
            string name = OT;
            int maxLength = trash.Length / 2;
            int actualLength = Math.Min(name.Length, maxLength);
            for (int i = 0; i < actualLength; i++)
            {
                char value = name[i];
                trash[i * 2] = (byte)value;
                trash[(i * 2) + 1] = (byte)(value >> 8);
            }
            if (actualLength < maxLength)
            {
                trash[actualLength * 2] = 0x00;
                trash[(actualLength * 2) + 1] = 0x00;
            }
        }
        public static void ClearNickTrash(PKM pokemon, string nick)
        {
            Span<byte> trash = pokemon.NicknameTrash;
            trash.Clear();
            string name = nick;
            int maxLength = trash.Length / 2;
            int actualLength = Math.Min(name.Length, maxLength);
            for (int i = 0; i < actualLength; i++)
            {
                char value = name[i];
                trash[i * 2] = (byte)value;
                trash[(i * 2) + 1] = (byte)(value >> 8);
            }
            if (actualLength < maxLength)
            {
                trash[actualLength * 2] = 0x00;
                trash[(actualLength * 2) + 1] = 0x00;
            }
        }

    }
}
