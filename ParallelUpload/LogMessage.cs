using System;

namespace ParallelUpload
{
    public class LogMessage : ILogMessage
    {
        #region Implementation of ILogMessage

        public LogLevel LogLevel { get; private set; }

        public string Text { get; private set; }

        public Exception Exception { get; private set; }

        #endregion

        public LogMessage(string text, LogLevel level = LogLevel.Info, Exception exception = null)
        {            
            Text = text;
            LogLevel = level;
            Exception = exception;
        }
    }
}