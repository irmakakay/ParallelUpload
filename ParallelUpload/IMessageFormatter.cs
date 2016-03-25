namespace ParallelUpload
{
    public interface IMessageFormatter
    {
        string Format<T>(T message, params object[] @params);
    }
}