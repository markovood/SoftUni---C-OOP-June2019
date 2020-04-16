using Logger.Enumerations;

namespace Logger.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        Level ReportLevel { get; }

        int AppendedCount { get; }

        void Append(IError error);
    }
}
