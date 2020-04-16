namespace Logger.Contracts
{
    public interface IFile
    {
        string Path { get; }

        ulong Size { get; }

        string Contents { get; }

        void Write(ILayout layout, IError error);
    }
}
