using System.Collections.Generic;

namespace Logger.Contracts
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Error(string dateTime, string message);

        void Info(string dateTime, string message);

        void Warning(string dateTime, string message);

        void Critical(string dateTime, string message);

        void Fatal(string dateTime, string message);
    }
}
