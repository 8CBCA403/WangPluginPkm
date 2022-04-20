

namespace WangPlugin
{
    public record IVs
    {
        public uint hp;
        public uint atk;
        public uint def;
        public uint spa;
        public uint spd;
        public uint spe;
    }
    public class Frame
    {
        public uint seed;
        public int number;
        public uint rngValue;
        public uint pid;
        public uint TID;
        public uint SID;
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        public IVs ivs;
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。

    }

    public static class FrameUtil
    {

        public static IVs dvsToIVs(uint dvUpper, uint dvLower)
        {
            return new IVs
            {
                hp = dvLower & 0x1f,
                atk = (dvLower & 0x3E0) >> 5,
                def = (dvLower & 0x7C00) >> 10,
                spe = dvUpper & 0x1f,
                spa = (dvUpper & 0x3E0) >> 5,
                spd = (dvUpper & 0x7C00) >> 10
            };
        }
    }

}

