using System;
using System.Collections.Generic;

using SysBotBase;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WangPluginPkm.WangUtil;
using SysBot.Base;
using WangPluginPkm.Properties;
using System.Net.Sockets;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using PKHeX.Core;

namespace WangPluginPkm.GUI
{
    public partial class SVRaidEditor : Form
    {
        public const string RaidBlockPointer = "[[main+42FD560]+160]+40";
        private readonly static SwitchConnectionConfig Config = new() { Protocol = SwitchProtocol.WiFi, IP = "192.168.3.10", Port = 6000 };
        private readonly static SwitchSocketAsync SwitchConnection = new(Config);
        private readonly static OffsetUtil OffsetUtil = new(SwitchConnection);
       // private int index =0;

        private readonly List<SVRaid> Raids = new();
        private SysBotMini sysbot = new SysBotMini()
        {
            IP = "192.168.3.10",
            Port = 6000,
        };
        public SVRaidEditor()
        {
            InitializeComponent();
        }
        private void IPBox_Changed(object sender, EventArgs e)
        {
            Config.IP= IPBox.Text;
        }
        private void Connect_BTN_Click(object sender, EventArgs e)
        {
            Connect();
        }
        private void Connect()
        {
            if (!SwitchConnection.Connected)
            {
                try
                {
                    SwitchConnection.Connect();
                }
                catch (SocketException err)
                {
                    Disconnect(true);
                    // a bit hacky but it works
                    if (err.Message.Contains("failed to respond") || err.Message.Contains("actively refused"))
                    {
                        MessageBox.Show(err.Message);
                    }
                }
            }
        }
        private void Disconnect(bool SkipCheckForExistingConnection = false)
        {
            if (SwitchConnection.Connected || SkipCheckForExistingConnection)
            {
                SwitchConnection.Disconnect();
               
            }
        }
        private async Task ReadRaids(CancellationToken token)
        {
            ulong offset = await OffsetUtil.GetPointerAddress(SVRaidOffsets.RaidBlockPointer, CancellationToken.None);
            Raids.Clear();
            //index = 0;
            SVRaid raid;
            for (uint i = RaidBlock.HEADER_SIZE; i < RaidBlock.SIZE; i += SVRaid.SIZE)
            {
                var Data = await SwitchConnection.ReadBytesAbsoluteAsync(offset + i, SVRaid.SIZE, token);
                raid = new SVRaid(Data);
                if (raid.IsValid) Raids.Add(raid);
            }
          //  DisplayRaid(index);
        }
        private async void ReadRaid_BTN_Click(object sender, EventArgs e)
        {
            await ReadRaids(CancellationToken.None);
        }
       
        private void SeedGenBTN_Click(object sender, EventArgs e)
        {
           // SVXoro.ComputeShinySeed(Util.Rand32());
        }
    }
}
