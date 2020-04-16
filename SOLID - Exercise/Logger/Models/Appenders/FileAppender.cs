using System.IO;

using Logger.Contracts;
using Logger.Enumerations;

namespace Logger.Models.Appenders
{
    public class FileAppender : IAppender
    {
        private IFile file;

        public FileAppender(ILayout layout, IFile fileToWrite, Level level = Level.INFO)
        {
            this.file = fileToWrite;

            this.Layout = layout;
            this.ReportLevel = level;
            this.AppendedCount = 0;
        }

        public ILayout Layout { get; }

        public Level ReportLevel { get; private set; }

        public int AppendedCount { get; private set; }

        public void Append(IError error)
        {
            if (error.Level >= this.ReportLevel)
            {
                this.file.Write(this.Layout, error);

                using StreamWriter writer = new StreamWriter(this.file.Path);
                writer.WriteLine(this.file.Contents);

                this.AppendedCount++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}" +
                $", Layout type: {this.Layout.GetType().Name}" +
                $", Report level: {this.ReportLevel}" +
                $", Messages appended: {this.AppendedCount}" +
                $", File size {this.file.Size}";
        }
    }
}
