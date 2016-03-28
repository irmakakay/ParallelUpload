namespace ParallelUpload
{
    public interface IMessageFormatter
    {
        ILogMessage Format<T>(T message, params object[] @params);
    }
}