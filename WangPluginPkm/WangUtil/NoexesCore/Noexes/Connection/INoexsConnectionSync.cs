using SysBot.Base;
using System.Collections.Generic;

namespace Noexes.Base
{
    public interface INoexsConnectionSync : ISwitchConnectionSync
    {
        int Attach(ulong pid);

        void Detach();

        void Resume();

        void Pause();

        IEnumerable<ulong> GetPids();

        ulong GetTitleIdFromPid(ulong pid);
    }
}
