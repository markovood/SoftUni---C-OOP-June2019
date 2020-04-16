using System;

using Logger.Constants;

namespace Logger.Exceptions
{
    public class InvalidAppenderTypeException : Exception
    {
        public InvalidAppenderTypeException() :
            base(ProjectConstants.INVALID_APPENDERTYPE_VALIDATION_MESSAGE)
        {
        }
    }
}
