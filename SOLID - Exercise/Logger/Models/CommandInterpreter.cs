using System;

using Logger.Contracts;
using Logger.Enumerations;
using Logger.Exceptions;

namespace Logger.Models
{
    public static class CommandInterpreter
    {
        public static void Run(ILogger logger)
        {
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "END")
                {
                    break;
                }

                // "<REPORT LEVEL>|<time>|<message>"
                string[] cmdArgs = cmd.Split('|', StringSplitOptions.RemoveEmptyEntries);

                bool hasParsed = Enum.TryParse(cmdArgs[0], out Level level);
                if (!hasParsed)
                {
                    throw new InvalidLevelParseException();
                }

                switch (level)
                {
                    case Level.INFO:
                        logger.Info(cmdArgs[1], cmdArgs[2]);
                        break;
                    case Level.WARNING:
                        logger.Warning(cmdArgs[1], cmdArgs[2]);
                        break;
                    case Level.CRITICAL:
                        logger.Critical(cmdArgs[1], cmdArgs[2]);
                        break;
                    case Level.ERROR:
                        logger.Error(cmdArgs[1], cmdArgs[2]);
                        break;
                    case Level.FATAL:
                        logger.Fatal(cmdArgs[1], cmdArgs[2]);
                        break;
                }
            }
        }
    }
}
