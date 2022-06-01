using System;
using System.Collections.Generic;
using System.Text;
using PKHeX.Core;
using static System.Buffers.Binary.BinaryPrimitives;

namespace WangPlugin
{
    internal class GP1M
    {
        public const int SIZE = 0x1B0;
        public byte[] Data;
        public bool EggEncounter => false;
        public byte LevelMin => Level;
        public byte LevelMax => Level;
        public int Generation => 7;
        public AbilityPermission Ability => AbilityPermission.Any12;
        public Span<byte> User_name1 => Data.AsSpan(0x00, 0x10);
        public Span<byte> User_name2 => Data.AsSpan(0x10, 0x10);
        public Span<byte> Nick_Name => Data.AsSpan(0x12D, 0x20);
        public Span<byte> GeoCity_Name => Data.AsSpan(0x7C, 0x60);
        public GP1M(byte[] data) => Data = data;
        public GP1M() : this((byte[])Blank.Clone()) { }
        public void WriteTo(byte[] data, int offset) => Data.CopyTo(data, offset);

        public void WriteByte(Span<byte> destBuffer, ReadOnlySpan<byte> value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                var c = value[i];
                WriteUInt16LittleEndian(destBuffer[(i)..], c);
            }
        }
        public static GP1M FromData(byte[] data, int offset)
        {
            var span = data.AsSpan(offset);
            return FromData(span);
        }

        private static GP1M FromData(ReadOnlySpan<byte> span)
        {
            var gpkm = new GP1M();
            span[..SIZE].CopyTo(gpkm.Data);
            return gpkm;
        }

        /// <summary>
        /// First 0x20 bytes of an empty <see cref="GP1"/>, all other bytes are 0.
        /// </summary>
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
            byte[] data = new byte[SIZE];
            Blank20.CopyTo(data, 0x20);
            return data;
        }

        public string Username1
        {
            get => Util.TrimFromZero(Encoding.ASCII.GetString(Data, 0x00, 0x10));
            set => WriteByte(User_name1, Encoding.ASCII.GetBytes(value));

        }
        public string Username2
        {
            get => Util.TrimFromZero(Encoding.ASCII.GetString(Data, 0x10, 0x20));
            set => WriteByte(User_name2, Encoding.ASCII.GetBytes(value));
        }

        public int Species
        {
            get => ReadInt32LittleEndian(Data.AsSpan(0x28));
            set => WriteInt32LittleEndian(Data.AsSpan(0x28), (ushort)value);
        }
        public int CP
        {
            get => ReadInt32LittleEndian(Data.AsSpan(0x2C));
            set => WriteInt32LittleEndian(Data.AsSpan(0x2C), value);
        }
        public float LevelF => ReadInt32LittleEndian(Data.AsSpan(0x30));
        public byte Level => Math.Max((byte)1, (byte)Math.Round(LevelF));
        public int Stat_HP => ReadInt32LittleEndian(Data.AsSpan(0x34));
        // geolocation data 0x38-0x47?
        public float HeightF => ReadInt32LittleEndian(Data.AsSpan(0x48));
        public float WeightF => ReadInt32LittleEndian(Data.AsSpan(0x4C));

        public byte HeightScalar
        {
            get
            {
                var height = HeightF * 100f;
                var pi = PersonalTable.GG.GetFormEntry(Species, Form);
                var avgHeight = pi.Height;
                return PB7.GetHeightScalar(height, avgHeight);
            }
        }
        public byte WeightScalar
        {
            get
            {
                var height = HeightF * 100f;
                var weight = WeightF * 10f;
                var pi = PersonalTable.GG.GetFormEntry(Species, Form);
                var avgHeight = pi.Height;
                var avgWeight = pi.Weight;
                return PB7.GetWeightScalar(height, weight, avgHeight, avgWeight);
            }
        }

        public int IV_HP
        {
            get => ReadInt32LittleEndian(Data.AsSpan(0x50));
            set => WriteInt32LittleEndian(Data.AsSpan(0x50), (ushort)value);
        }
        public int IV_ATK
        {
            get => ReadInt32LittleEndian(Data.AsSpan(0x54));
            set => WriteInt32LittleEndian(Data.AsSpan(0x54), (ushort)value);
        }

        public int IV_DEF
        {
            get => ReadInt32LittleEndian(Data.AsSpan(0x58));
            set => WriteInt32LittleEndian(Data.AsSpan(0x58), (ushort)value);

        }
        public int Date
        {
            get => ReadInt32LittleEndian(Data.AsSpan(0x5C)); // ####.##.## YYYY.MM.DD
            set => WriteInt32LittleEndian(Data.AsSpan(0x5C), value);
        }
        public int Year => Date / 1_00_00;
        public int Month => (Date / 1_00) % 1_00;
        public int Day => Date % 1_00;

        public int Gender
        {
            get => ReadInt32LittleEndian(Data.AsSpan(0x70)); // M=1, F=2, G=3 ;; shift down by 1.
            set => WriteInt32LittleEndian(Data.AsSpan(0x70), value);
        }
        public byte Form
        {
            get => Data[0x72];
            set => Data[0x72] = value;
        }
        public byte IsShiny
        {
            get => Data[0x73];
            set => Data[0x73] = value;
        }

        // https://bulbapedia.bulbagarden.net/wiki/List_of_moves_in_Pok%C3%A9mon_GO
        public int Move1
        {
            get => ReadInt32LittleEndian(Data.AsSpan(0x74));
            set => WriteInt32LittleEndian(Data.AsSpan(0x74), value);
        }
        public int Move2
        {
            get => ReadInt32LittleEndian(Data.AsSpan(0x78)); // uses Go Indexes
            set => WriteInt32LittleEndian(Data.AsSpan(0x78), value);
        }

        public string GeoCityName 
        {
            get=>Util.TrimFromZero(Encoding.ASCII.GetString(Data, 0x7C, 0x60)); // dunno length
            set => WriteByte(GeoCity_Name, Encoding.ASCII.GetBytes(value));
        }
        public string Nickname
        {
            get=>Util.TrimFromZero(Encoding.ASCII.GetString(Data, 0x12D, 0x20));
            set=> WriteByte(Nick_Name, Encoding.ASCII.GetBytes(value));


        }// dunno length

        public static readonly IReadOnlyList<string> Genders = GameInfo.GenderSymbolASCII;
        public string GenderString => (uint)Gender >= Genders.Count ? string.Empty : Genders[Gender];
        public string ShinyString => IsShiny==1 ? "★ " : string.Empty;
        public string FormString => Form != 0 ? $"-{Form}" : string.Empty;
        private string NickStr => string.IsNullOrWhiteSpace(Nickname) ? SpeciesName.GetSpeciesNameGeneration(Species, (int)LanguageID.English, 7) : Nickname;
        public string FileName => $"{FileNameWithoutExtension}.gp1";

        public string FileNameWithoutExtension
        {
            get
            {
                string form = Form > 0 ? $"-{Form:00}" : string.Empty;
                string star = IsShiny==1 ? " ★" : string.Empty;
                return $"{Species:000}{form}{star} - {NickStr} - Lv. {Level:00} - {IV_HP:00}.{IV_ATK:00}.{IV_DEF:00} - CP {CP:0000} (Moves {Move1:000}, {Move2:000})";
            }
        }

        public string GeoTime => $"Captured in {GeoCityName} by {Username1} on {Year}/{Month:00}/{Day:00}";
        public string StatMove => $"{IV_HP:00}/{IV_ATK:00}/{IV_DEF:00}, CP {CP:0000} (Moves {Move1:000}, {Move2:000})";
        public string Dump(IReadOnlyList<string> speciesNames, int index) => $"{index:000} {Nickname} ({speciesNames[Species]}{FormString} {ShinyString}[{GenderString}]) @ Lv. {Level:00} - {StatMove}, {GeoTime}.";

       
        
    }
}
