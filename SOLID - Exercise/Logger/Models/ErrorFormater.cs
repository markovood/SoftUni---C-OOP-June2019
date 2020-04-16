using System.Globalization;

using Logger.Constants;
using Logger.Contracts;

namespace Logger.Models
{
    public static class ErrorFormater
    {
        public static string Format(ILayout layout, IError error)
        {
            string format = layout.Format;
            string formated = string.Format(format,
                                            error.DateTime.ToString(ProjectConstants.DATETIME_FORMAT,
                                                                    CultureInfo.InvariantCulture),
                                            error.Level,
                                            error.Message);

            return formated;
        }
    }
}
