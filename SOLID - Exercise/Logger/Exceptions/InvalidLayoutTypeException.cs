using System;

using Logger.Constants;

namespace Logger.Exceptions
{
    public class InvalidLayoutTypeException : Exception
    {
        public InvalidLayoutTypeException() :
            base(ProjectConstants.INVALID_LAYOUT_VALIDATING_MESSAGE)
        {
        }
    }
}
