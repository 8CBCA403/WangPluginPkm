using PKHeX.Core;
namespace SysBotBase
{
    public class LiveHeXController
    {
        private readonly ISaveFileProvider SAV;
        public readonly IPKMView Editor;
        public PokeSysBotMini Bot;

        public LiveHeXController(ISaveFileProvider boxes, IPKMView editor, InjectorCommunicationType ict)
        {
            SAV = boxes;
            Editor = editor;
            var ValidVers = RamOffsets.GetValidVersions(boxes.SAV);
            Bot = new PokeSysBotMini(ValidVers[0], ict);
        }

        public bool ReadOffset(ulong offset, RWMethod method = RWMethod.Heap)
        {
            var data = ReadData(offset, method);
            var pkm = SAV.SAV.GetDecryptedPKM(data);

            // Since data might not actually exist at the user-specified offset, double check that the pkm data is valid.
            if (!pkm.ChecksumValid)
                return false;

            Editor.PopulateFields(pkm);
            return true;
        }

        private byte[] ReadData(ulong offset, RWMethod method)
        {
            if (Bot.com is not ICommunicatorNX nx)
                return Bot.ReadOffset(offset);
            return method switch
            {
                RWMethod.Heap => Bot.ReadOffset(offset),
                RWMethod.Main => nx.ReadBytesMain(offset, Bot.SlotSize),
                RWMethod.Absolute => nx.ReadBytesAbsolute(offset, Bot.SlotSize),
                _ => Bot.ReadOffset(offset),
            };
        }

        public byte[] ReadRAM(ulong offset, int size) => Bot.com.ReadBytes(offset, size);

        public void WriteRAM(ulong offset, byte[] data) => Bot.com.WriteBytes(data, offset);
    }
}