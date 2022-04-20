namespace WangPlugin
{
    public record RNGpkEntry
    {
        public ulong EC;
        public uint PID;
        public int ShinyStatus;
        public uint Ability;
        public uint Nature;
        public uint Height;
        public uint Weight;
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        public uint[] ivs;
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        public uint HP => ivs[0];
        public uint Atk => ivs[1];
        public uint Def => ivs[2];
        public uint SpA => ivs[3];
        public uint SpD => ivs[4];
        public uint Spe => ivs[5];
    }

}

