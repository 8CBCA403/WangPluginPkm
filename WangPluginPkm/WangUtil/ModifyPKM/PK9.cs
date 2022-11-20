using PKHeX.Core;
using System;
using System.Drawing;
using static System.Buffers.Binary.BinaryPrimitives;

namespace WangPluginPkm
{
    internal class PK9
    {
        public byte[] Data;
        public PK9(byte[] data) => Data = data;
        public PK9() : this((byte[])Blank.Clone()) { }
        public  Span<byte> OT_Trash => Data.AsSpan(0xF8, 26);
        public uint EncryptionConstant 
        { 
            get => ReadUInt32LittleEndian(Data.AsSpan(0x00)); 
            set => WriteUInt32LittleEndian(Data.AsSpan(0x00), value); 
        }
        public int Language 
        { 
            get => Data[0xD5]; 
            set => Data[0xD5] = (byte)value; 
        }
        public ushort Species 
        { 
            get => ReadUInt16LittleEndian(Data.AsSpan(0x08)); 
            set => WriteUInt16LittleEndian(Data.AsSpan(0x08), value); 
        }
        public int Gender 
        { 
            get => (Data[0x22] ) ; 
            set => Data[0x22]  = (byte)value; 
        }
        public  int HeldItem 
        { 
            get => ReadUInt16LittleEndian(Data.AsSpan(0x0A)); 
            set => WriteUInt16LittleEndian(Data.AsSpan(0x0A), (ushort)value); 
        }
        public  int TID 
        { 
            get => ReadUInt16LittleEndian(Data.AsSpan(0x0C)); 
            set => WriteUInt16LittleEndian(Data.AsSpan(0x0C), (ushort)value); 
        }
        public  int SID 
        { 
            get => ReadUInt16LittleEndian(Data.AsSpan(0x0E)); 
            set => WriteUInt16LittleEndian(Data.AsSpan(0x0E), (ushort)value); 
        }
      
        public  int Ability 
        { 
            get => ReadUInt16LittleEndian(Data.AsSpan(0x14)); 
            set => WriteUInt16LittleEndian(Data.AsSpan(0x14), (ushort)value); 
        }
        public  int AbilityNumber 
        { 
            get => Data[0x16] & 7; 
            set => Data[0x16] = (byte)((Data[0x16] & ~7) | (value & 7)); 
        }
        public  uint PID 
        { 
            get => ReadUInt32LittleEndian(Data.AsSpan(0x1C)); 
            set => WriteUInt32LittleEndian(Data.AsSpan(0x1C), value); 
        }
        public  int Nature 
        { 
            get => Data[0x20]; 
            set => Data[0x20] = (byte)value; 
        }
        public  int StatNature 
        { 
            get => Data[0x21]; 
            set => Data[0x21] = (byte)value; 
        }
        public int StatTera
        {
            get => Data[0x95];
            set => Data[0x95] = (byte)value;
        }
        public  byte Form 
        { 
            get => Data[0x24]; 
            set => WriteUInt16LittleEndian(Data.AsSpan(0x24), value); 
        }
        public  int EV_HP { get => Data[0x26]; set => Data[0x26] = (byte)value; }
        public  int EV_ATK { get => Data[0x27]; set => Data[0x27] = (byte)value; }
        public  int EV_DEF { get => Data[0x28]; set => Data[0x28] = (byte)value; }
        public  int EV_SPE { get => Data[0x29]; set => Data[0x29] = (byte)value; }
        public  int EV_SPA { get => Data[0x2A]; set => Data[0x2A] = (byte)value; }
        public  int EV_SPD { get => Data[0x2B]; set => Data[0x2B] = (byte)value; }
        public ushort Move1 
        { 
            get => ReadUInt16LittleEndian(Data.AsSpan(0x72)); 
            set => WriteUInt16LittleEndian(Data.AsSpan(0x72), value); 
        }
        public ushort Move2 
        { 
            get => ReadUInt16LittleEndian(Data.AsSpan(0x74)); 
            set => WriteUInt16LittleEndian(Data.AsSpan(0x74), value); 
        }
        public ushort Move3 
        { 
            get => ReadUInt16LittleEndian(Data.AsSpan(0x76)); 
            set => WriteUInt16LittleEndian(Data.AsSpan(0x76), value); 
        }
        public ushort Move4 
        { 
            get => ReadUInt16LittleEndian(Data.AsSpan(0x78)); 
            set => WriteUInt16LittleEndian(Data.AsSpan(0x78), value); 
        }

        public int Move1_PP { get => Data[0x7A]; set => Data[0x7A] = (byte)value; }
        public int Move2_PP { get => Data[0x7B]; set => Data[0x7B] = (byte)value; }
        public int Move3_PP { get => Data[0x7C]; set => Data[0x7C] = (byte)value; }
        public int Move4_PP { get => Data[0x7D]; set => Data[0x7D] = (byte)value; }
        private uint IV32 
        { 
            get => ReadUInt32LittleEndian(Data.AsSpan(0x8C)); 
            set => WriteUInt32LittleEndian(Data.AsSpan(0x8C), value); 
        }
        public int IV_HP 
        { 
            get => (int)(IV32 >> 00) & 0x1F; 
            set => IV32 = (IV32 & ~(0x1Fu << 00)) | ((value > 31 ? 31u : (uint)value) << 00); 
        }
        public int IV_ATK 
        { 
            get => (int)(IV32 >> 05) & 0x1F; 
            set => IV32 = (IV32 & ~(0x1Fu << 05)) | ((value > 31 ? 31u : (uint)value) << 05); 
        }
        public int IV_DEF 
        { 
            get => (int)(IV32 >> 10) & 0x1F; 
            set => IV32 = (IV32 & ~(0x1Fu << 10)) | ((value > 31 ? 31u : (uint)value) << 10); 
        }
        public int IV_SPE 
        { 
            get => (int)(IV32 >> 15) & 0x1F; 
            set => IV32 = (IV32 & ~(0x1Fu << 15)) | ((value > 31 ? 31u : (uint)value) << 15); 
        }
        public int IV_SPA 
        { 
            get => (int)(IV32 >> 20) & 0x1F; 
            set => IV32 = (IV32 & ~(0x1Fu << 20)) | ((value > 31 ? 31u : (uint)value) << 20); 
        }
        public int IV_SPD 
        { 
            get => (int)(IV32 >> 25) & 0x1F; 
            set => IV32 = (IV32 & ~(0x1Fu << 25)) | ((value > 31 ? 31u : (uint)value) << 25); 
        }
        public int Move1_PPUps { get => Data[0x7E]; set => Data[0x7E] = (byte)value; }
        public int Move2_PPUps { get => Data[0x7F]; set => Data[0x7F] = (byte)value; }
        public int Move3_PPUps { get => Data[0x80]; set => Data[0x80] = (byte)value; }
        public int Move4_PPUps { get => Data[0x81]; set => Data[0x81] = (byte)value; }
        public  int Ball { get => Data[0x124]; set => Data[0x124] = (byte)value; }
        public  int OT_Friendship { get => Data[0x112]; set => Data[0x112] = (byte)value; }
        public  string OT_Name
        {
            get => StringConverter8.GetString(OT_Trash);
            set => StringConverter8.SetString(OT_Trash, value.AsSpan(), 12, StringConverterOption.None);
        }
        private static readonly byte[] Blank20 =
       {
            0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x80, 0x3F, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF0, 0x3F,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF0, 0x3F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00, 0x80, 0x3F,
            0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x85, 0xEC, 0x33, 0x01,
        };

        public static readonly byte[] Blank = GetBlank();

        public static byte[] GetBlank()
        {
            byte[] data = new byte[344];
            Blank20.CopyTo(data, 0x20);
            return data;
        }
    }
}
