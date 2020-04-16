using System.Linq;
using System.Text;

using Logger.Constants;
using Logger.Contracts;

namespace Logger.Models
{
    public class LogFile : IFile
    {
        private StringBuilder contents;

        public LogFile()
        {
            this.contents = new StringBuilder();
        }

        public string Path => ProjectConstants.PATH_TO_LOGTXT;

        public ulong Size => (ulong)this.
                            contents.
                            ToString().
                            ToCharArray().
                            Where(c => char.IsLetter(c)).
                            Sum(c => c);

        public string Contents => this.contents.ToString();

        public void Write(ILayout layout, IError error)
        {
            this.contents.AppendLine(ErrorFormater.Format(layout, error));
        }
    }
}
