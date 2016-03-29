using System;
using System.Linq;

namespace ParallelUpload
{
    public class DefaultMessageFormatter : IMessageFormatter
    {
        #region Implementation of IMessageFormatter

        public ILogMessage Format<T>(T message, LogLevel level = LogLevel.Info, Exception ex = null)
        {
            return new LogMessage(string.Format("Uploading {0}", message), level, ex);
        }

        #endregion
    }
}