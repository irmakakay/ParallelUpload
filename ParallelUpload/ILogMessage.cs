using System;

namespace ParallelUpload
{
    public enum LogLevel
    {
        Info,
        Debug,
        Warning,
        Error
    }

    public interface ILogMessage
    {
        LogLevel LogLevel { get; }

        string Text { get; }

        Exception Exception { get; }
    }
}