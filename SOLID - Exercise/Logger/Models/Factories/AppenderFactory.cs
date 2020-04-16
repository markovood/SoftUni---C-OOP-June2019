using Logger.Contracts;
using Logger.Enumerations;
using Logger.Exceptions;
using Logger.Models.Appenders;
using Logger.Models.Layouts;

namespace Logger.Models.Factories
{
    public static class AppenderFactory
    {
        public static IAppender Create(string layoutType, string appenderType, string reportLevel = "INFO")
        {
            // validate layout type
            ILayout layout;
            switch (layoutType)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;
                case "XmlLayout":
                    layout = new XmlLayout();
                    break;
                default:
                    throw new InvalidLayoutTypeException();
            }

            // validate reportLevel
            Level level;
            switch (reportLevel)
            {
                case "WARNING":
                    level = Level.WARNING;
                    break;
                case "ERROR":
                    level = Level.ERROR;
                    break;
                case "CRITICAL":
                    level = Level.CRITICAL;
                    break;
                case "FATAL":
                    level = Level.FATAL;
                    break;
                default:
                    level = Level.INFO;
                    break;
            }

            // validate appenderType
            IAppender appender;
            switch (appenderType)
            {
                case "ConsoleAppender":
                    return appender = new ConsoleAppender(layout, level);
                case "FileAppender":
                    IFile file = new LogFile();
                    return appender = new FileAppender(layout, file, level);
                default:
                    throw new InvalidAppenderTypeException();
            }
        }
    }
}
