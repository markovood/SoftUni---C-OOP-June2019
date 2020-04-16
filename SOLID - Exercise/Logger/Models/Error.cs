using System;

using Logger.Contracts;
using Logger.Enumerations;

namespace Logger.Models
{
    public class Error : IError
    {
        public Error(DateTime dateTime, Level level, string message)
        {
            this.DateTime = dateTime;
            this.Level = level;
            this.Message = message;
        }

        public DateTime DateTime { get; }

        public Level Level { get; }

        public string Message { get; }
    }
}
