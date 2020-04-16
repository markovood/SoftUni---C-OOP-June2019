using System.Collections.Generic;
using System.Text;

using Logger.Contracts;
using Logger.Models.Factories;

namespace Logger.Models
{
    public class Logger : ILogger
    {
        private IEnumerable<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Critical(string dateTime, string message)
        {
            IError error = ErrorFactory.Create("Critical", dateTime, message);
            PassToAll(error);
        }

        public void Error(string dateTime, string message)
        {
            IError error = ErrorFactory.Create("Error", dateTime, message);
            PassToAll(error);
        }

        public void Fatal(string dateTime, string message)
        {
            IError error = ErrorFactory.Create("Fatal", dateTime, message);
            PassToAll(error);
        }

        public void Info(string dateTime, string message)
        {
            IError error = ErrorFactory.Create("Info", dateTime, message);
            PassToAll(error);
        }

        public void Warning(string dateTime, string message)
        {
            IError error = ErrorFactory.Create("Warning", dateTime, message);
            PassToAll(error);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Logger info ");

            foreach (var appender in this.Appenders)
            {
                result.AppendLine(appender.ToString());
            }

            return result.ToString();
        }

        private void PassToAll(IError error)
        {
            foreach (var appender in appenders)
            {
                appender.Append(error);
            }
        }
    }
}
