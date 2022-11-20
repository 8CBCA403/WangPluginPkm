using System;

namespace Noexes.Base
{
    class ResultException : Exception
    {
        public ResultException(int result): base($"err code: {result}") { }
    }

    class ImpossibleException : Exception
    {
        public ImpossibleException(int result) : base($"[{result}]This is impossible, so you've done something terribly wrong") { }
    }
}
