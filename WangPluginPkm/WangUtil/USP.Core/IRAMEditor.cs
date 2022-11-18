
namespace USP.Core
{
    public interface IRAMEditor
    {
        ProcessInfo GetInfo();
        byte[] Read(uint offset, int length);
        byte[] ReadMain(ulong offset, int length);
        byte[] ReadAbsolute(ulong offset, int length);

        void Write(byte[] data, uint offset);
        void WriteMain(byte[] data, ulong offset);
        void WriteAbsolute(byte[] data, ulong offset);

        ulong GetPointer(string parser);
    }

    public record ProcessInfo
    {
        public ulong MainBase { get; init; } = ulong.MinValue;
        public ulong HeepBase { get; init; } = ulong.MinValue;

        public ulong TitleId { get; init; } = ulong.MaxValue;
        public ulong BuildId { get; init; } = ulong.MaxValue;
    }
}
