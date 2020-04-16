using System;
using System.Collections.Generic;
using System.Globalization;

using Logger.Constants;
using Logger.Contracts;
using Logger.Enumerations;
using Logger.Models;
using Logger.Models.Appenders;
using Logger.Models.Factories;
using Logger.Models.Layouts;

namespace Logger
{
    public class Program
    {
        public static void Main()
        {
            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            //ILogger logger = new Models.Logger(consoleAppender);

            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            // **********************************************

            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender = new ConsoleAppender(simpleLayout);

            //IFile file = new LogFile();
            ////file.Write(simpleLayout, ErrorFactory.Create("Fatal",
            ////    DateTime.Now.ToString(ProjectConstants.DATETIME_FORMAT,CultureInfo.InvariantCulture),
            ////    "Super fatality happened!"));
            //IAppender fileAppender = new FileAppender(simpleLayout, file);

            //ILogger logger = new Models.Logger(consoleAppender, fileAppender);
            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            // **********************************************

            //ILayout xmlLayout = new XmlLayout();
            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender = new ConsoleAppender(simpleLayout);

            //IFile file = new LogFile();
            //IAppender fileAppender = new FileAppender(xmlLayout, file);

            //ILogger logger = new Models.Logger(consoleAppender, fileAppender);

            //logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            //logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");

            // **********************************************

            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);
            //consoleAppender.ReportLevel = Level.Error;

            //var logger = new Models.Logger(consoleAppender);

            //logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            //logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            //logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");

            // **********************************************

            //var layout = new SimpleLayout();
            //var xmlLayout = new XmlLayout();

            //var file = new LogFile();
            //var fileAppender = new FileAppender(layout, file);

            //var logger = new Models.Logger(fileAppender);
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //Console.WriteLine(file.Size);

            // **********************************************

            int appendersCount = int.Parse(Console.ReadLine());
            IAppender[] appenders = new IAppender[appendersCount];
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (appenderArgs.Length)
                {
                    // "<appender type> <layout type> <REPORT LEVEL>"
                    case 2:
                        appenders[i] = AppenderFactory.Create(appenderArgs[1], appenderArgs[0]);
                        break;
                    case 3:
                        appenders[i] = AppenderFactory.Create(appenderArgs[1], appenderArgs[0], appenderArgs[2]);
                        break;
                }
            }

            var logger = new Models.Logger(appenders);
            CommandInterpreter.Run(logger);

            Console.WriteLine(logger);
        }
    }
}
