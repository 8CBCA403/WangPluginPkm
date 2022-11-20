using SysBot.Base;
using System;
using System.Net.Sockets;

namespace Noexes.Base
{
    public abstract class NoexsConnection : IConsoleConnection
    {
        protected Socket Connection;
        protected readonly IWirelessConnectionConfig Info;

        public string Name { get; }
        public string Label { get; set; }
        public bool Connected { get; protected set; }

        public int MaximumTransferSize { get; set; } = 0x1C0;
        public int BaseDelay { get; set; } = 64;
        public int DelayFactor { get; set; } = 256;

        protected NoexsConnection(IWirelessConnectionConfig wi, SocketType type = SocketType.Stream, ProtocolType proto = ProtocolType.Tcp)
        {
            Connection = new Socket(type, proto);
            Info = wi;
            Name = Label = wi.IP;
        }

        public void Connect()
        {
            Log("Connecting to device...");
            // Info.Port == 7331;
            var result = Connection.BeginConnect(Info.IP, Info.Port, null, null);

            bool success = result.AsyncWaitHandle.WaitOne(3000, true);
            if (success)
            {
                Connection.EndConnect(result);
            }
            else
            {
                Connection.Close();
                throw new SocketException(10060); // Connection timed out.
            }
            Connected = true;
            Log("Connected!");
        }

        public void Reset()
        {
            Disconnect();
            Connect();
        }

        public void Disconnect()
        {
            Log("Disconnecting from device...");
            Connection.Disconnect(false);
            Connected = false;
            Log("Disconnected!");
        }

        public void Log(string message) => System.Diagnostics.Debug.WriteLine(message);
        public void LogInfo(string message) => LogUtil.LogInfo(message, Label);
        public void LogError(string message) => LogUtil.LogError(message, Label);

        private int Read(byte[] buffer) => Connection.Receive(buffer);
        public int Send(byte[] buffer) => Connection.Send(buffer);

        protected int ReadResult()
        {
            var c = ReadResponse(4);
            return BitConverter.ToInt32(c, 0);
        }

        protected byte ReadByte() => ReadResponse(1)[0];

        protected ushort ReadShort() => BitConverter.ToUInt16(ReadResponse(2), 0);

        protected uint ReadInt() => BitConverter.ToUInt32(ReadResponse(4), 0);

        protected ulong ReadLong() => BitConverter.ToUInt64(ReadResponse(8), 0);


        protected byte[] ReadResponse(int length)
        {
            var buffer = new byte[length];
            var i = Read(buffer);
            Log($"[read] Real: {i}");
            Log($"[read] Require: {length}, Get:{i}, Available: {Connection.Available}");

            return buffer;
        }

        protected int SendReadResult(byte[] buf)
        {
            Send(buf);
            return ReadResult();
        }

        protected void WaitForAvailable(int len)
        {
            while (Connection.Available < len) {; }
        }
    }
}
