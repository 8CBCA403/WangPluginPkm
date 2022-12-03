﻿using PKHeX.Core;
using SysBot.Base;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Linq;

namespace WangPluginPkm
{
    internal class SVRaidOffsets
    {
        public const string RaidBlockPointer = "[[main+42FD560]+160]+40";
    }
    internal class RaidBlock
    {
        public static uint HEADER_SIZE = 0x10;
        public static uint SIZE = 0xC98;
    }
    internal class OffsetUtil
    {
        readonly SwitchSocketAsync SwitchConnection;
        public OffsetUtil(SwitchSocketAsync c)
        {
            SwitchConnection = c;
        }

        // From LiveHex
        // MIT License
        // https://github.com/architdate/PKHeX-Plugins
        public async Task<ulong> GetPointerAddress(string pointer, CancellationToken token, bool heaprealtive = false)
        {
            var ptr = pointer;
            if (string.IsNullOrWhiteSpace(ptr) || ptr.IndexOfAny(new char[] { '-', '/', '*' }) != -1)
                return 0;
            while (ptr.Contains("]]"))
                ptr = ptr.Replace("]]", "]+0]");
            uint? finadd = null;
            if (!ptr.EndsWith("]"))
            {
                finadd = Util.GetHexValue(ptr.Split('+').Last());
                ptr = ptr.Substring(0, ptr.LastIndexOf('+'));
            }
            var jumps = ptr.Replace("main", "").Replace("[", "").Replace("]", "").Split(new[] { "+" }, StringSplitOptions.RemoveEmptyEntries);
            if (jumps.Length == 0)
                return 0;

            var initaddress = Util.GetHexValue(jumps[0].Trim());
            ulong address = BitConverter.ToUInt64(await SwitchConnection.ReadBytesMainAsync(initaddress, 0x8, token).ConfigureAwait(false), 0);
            foreach (var j in jumps)
            {
                var val = Util.GetHexValue(j.Trim());
                if (val == initaddress)
                    continue;
                address = BitConverter.ToUInt64(await SwitchConnection.ReadBytesAbsoluteAsync(address + val, 0x8, token).ConfigureAwait(false), 0);
            }
            if (finadd != null) address += (ulong)finadd;
            if (heaprealtive)
            {
                ulong heap = await SwitchConnection.GetHeapBaseAsync(token);
                address -= heap;
            }
            return address;
        }
    }
}
