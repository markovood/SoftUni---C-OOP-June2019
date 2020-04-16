using System;
using System.Globalization;

using Logger.Constants;
using Logger.Enumerations;
using Logger.Exceptions;

namespace Logger.Models.Factories
{
    public static class ErrorFactory
    {
        public static Error Create(string level, string dateTime, string message)
        {
            Level errorLevel;
            bool isLevelParsed = Enum.TryParse(level.ToUpper(), out errorLevel);

            if (!isLevelParsed)
            {
                throw new InvalidLevelParseException();
            }

            try
            {
                DateTime errorDateTime = DateTime.ParseExact(dateTime,
                                                            ProjectConstants.DATETIME_FORMAT,
                                                            CultureInfo.InvariantCulture);

                return new Error(errorDateTime, errorLevel, message);
            }
            catch (Exception)
            {
                throw new InvalidDateTimeParseException();
            }
        }
    }
}
