using System;

using Logger.Constants;

namespace Logger.Exceptions
{
    public class InvalidDateTimeParseException : Exception
    {
        public InvalidDateTimeParseException() :
            base(ProjectConstants.INVALID_DATETIME_PARSING_MESSAGE)
        {
        }
    }
}
