using System;

namespace CustomException
{
    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException()
        {
        }

        public InvalidPersonNameException(string message) :
            base(message)
        {
        }
    }
}
