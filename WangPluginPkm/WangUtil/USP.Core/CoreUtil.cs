using Noexes.Base;
using SysBot.Base;
using System;
using System.Collections.Generic;

namespace USP.Core
{
    public static class CoreUtil
    {
        public static List<string> USBPort => USBUtil.GetList();

        public static SysBot GetSysBot(string ip, int port, ProtocolType protocol = ProtocolType.WiFi)
        {
            var cfg = BotConfigUtil.GetConfig<SwitchConnectionConfig>(ip, port);

            if (protocol == ProtocolType.Noexs)
            {
                throw new Exception("unsupport protocol");
            }

            if (protocol == ProtocolType.USB) cfg.Protocol = SwitchProtocol.USB;

            var bot = new SysBot(cfg);
            bot.Run();

            return bot;
        }

        public static NoexsBot GetNoexsBot(string ip, int port)
        {
            var cfg = BotConfigUtil.GetConfig<NoexsConnectionConfig>(ip, port);

            var bot = new NoexsBot(cfg);
            bot.Run();

            return bot;
        }
    }

    public sealed class SysBot : CoreExecutor<SwitchConnectionConfig> { public SysBot(SwitchConnectionConfig cfg) : base(cfg) { } }

    public sealed class NoexsBot : NoexsExecutor<NoexsConnectionConfig> { public NoexsBot(NoexsConnectionConfig cfg) : base(cfg) { } }

    public enum ProtocolType // as SwitchProtocol
    {
        WiFi,
        USB,
        Noexs,
    }
}
