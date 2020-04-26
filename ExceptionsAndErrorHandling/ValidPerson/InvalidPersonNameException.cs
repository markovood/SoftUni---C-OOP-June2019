using System;
using System.Runtime.Serialization;

namespace ValidPerson
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
