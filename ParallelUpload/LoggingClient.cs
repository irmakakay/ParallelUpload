using System;
using System.Collections.Concurrent;

namespace ParallelUpload
{
    public interface ILoggingClient
    {
        void SubscribeOn(BlockingCollection<ILogMessage> messages);

        void TryLog();
    }

    public class LoggingClient : ILoggingClient
    {
        private readonly ILogger _logger;

        private BlockingCollection<ILogMessage> _messages;

        public LoggingClient(ILogger logger)
        {
            _logger = logger;
        }

        public void SubscribeOn(BlockingCollection<ILogMessage> messages)
        {
            _messages = messages;
        }

        public void TryLog()
        {
            try
            {                
                while (true) _logger.Log(_messages.Take());
            }
            catch (InvalidOperationException)
            {                
                _logger.Debug("Upload complete.");
            }              
        }
    }
}
