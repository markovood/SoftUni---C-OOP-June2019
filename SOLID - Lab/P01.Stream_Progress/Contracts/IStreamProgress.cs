namespace P01.Stream_Progress.Contracts
{
    public interface IStreamProgress
    {
        int Length { get; }

        int BytesSent { get; }
    }
}
