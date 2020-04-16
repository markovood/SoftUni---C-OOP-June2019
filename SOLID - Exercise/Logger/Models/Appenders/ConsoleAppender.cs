using System;

using Logger.Contracts;
using Logger.Enumerations;

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, Level level = Level.INFO)
        {
            this.AppendedCount = 0;
            this.Layout = layout;
            this.ReportLevel = level;
        }

        public int AppendedCount { get; private set; }

        public ILayout Layout { get; }

        public Level ReportLevel { get; set; }

        public void Append(IError error)
        {
            if (error.Level >= this.ReportLevel)
            {
                // format the error according to layout
                string formated = ErrorFormater.Format(this.Layout, error);

                // print on the console
                Console.WriteLine(formated);
                this.AppendedCount++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}" + 
                $", Layout type: {this.Layout.GetType().Name}" +
                $", Report level: {this.ReportLevel}" +
                $", Messages appended: {this.AppendedCount}";
        }
    }
}
