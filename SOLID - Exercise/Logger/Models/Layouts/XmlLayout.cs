using System.Text;

using Logger.Contracts;

namespace Logger.Models.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format
        {
            get
            {
                StringBuilder xmlFormat = new StringBuilder();
                xmlFormat.AppendLine("<log>").
                    AppendLine("\t<date>{0}</date>").
                    AppendLine("\t<level>{1}</level>").
                    AppendLine("\t<message>{2}</message>").
                    AppendLine("</log>");

                return xmlFormat.ToString().TrimEnd();
            }
        }
    }
}
