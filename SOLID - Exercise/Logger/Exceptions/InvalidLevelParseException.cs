using System;

using Logger.Constants;

namespace Logger.Exceptions
{
    public class InvalidLevelParseException : Exception
    {
        public InvalidLevelParseException() :
            base(ProjectConstants.INVALID_LEVEL_PARSING_MESSAGE)
        {
        }
    }
}
