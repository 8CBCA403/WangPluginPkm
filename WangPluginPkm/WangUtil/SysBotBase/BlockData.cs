﻿using System;
using System.Collections.Generic;
using System.Text;
using PKHeX.Core;
namespace SysBotBase
{
    public record BlockData
    {
        public string Name { get; set; } = string.Empty;
        public string Display { get; set; } = string.Empty;
        public uint SCBKey { get; set; }
        public string Pointer { get; set; } = string.Empty;
        public uint Offset { get; set; }
        public SCTypeCode Type { get; set; } = SCTypeCode.None;
    }
}
