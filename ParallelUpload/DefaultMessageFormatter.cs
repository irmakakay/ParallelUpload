using System;
using System.Linq;

namespace ParallelUpload
{
    public class DefaultMessageFormatter : IMessageFormatter
    {
        #region Implementation of IMessageFormatter

        public ILogMessage Format<T>(T message, params object[] @params)
        {
            var ex = @params.OfType<Exception>().SingleOrDefault();
            var level = @params.OfType<LogLevel>().SingleOrDefault();

            return new LogMessage(message.ToString(), level, ex);
        }

        #endregion
    }
}