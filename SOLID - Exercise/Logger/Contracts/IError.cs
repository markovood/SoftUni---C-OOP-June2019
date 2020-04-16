using System;

using Logger.Enumerations;

namespace Logger.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }

        Level Level { get; }

        string Message { get; }
    }
}
