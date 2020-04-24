using System;

namespace CommandPattern.Core.Exceptions
{
    public class CommandTypeNotFoundException : Exception
    {
        public CommandTypeNotFoundException(string message) : 
            base(message)
        {
        }
    }
}
