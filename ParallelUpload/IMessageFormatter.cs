using System;

namespace ParallelUpload
{
    public interface IMessageFormatter
    {
        ILogMessage Format<T>(T message, LogLevel level = LogLevel.Info, Exception ex = null);
    }
}