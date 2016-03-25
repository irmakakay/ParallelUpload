using System;
using System.Collections.Concurrent;

namespace ParallelUpload
{
    public interface ILoggingClient
    {
        void SubscribeOn(BlockingCollection<string> messages);

        void TryLog();
    }

    public class LoggingClient : ILoggingClient
    {
        private readonly ILogger _logger;

        private BlockingCollection<string> _messages;

        public LoggingClient(ILogger logger)
        {
            _logger = logger;
        }

        public void SubscribeOn(BlockingCollection<string> messages)
        {
            _messages = messages;
        }

        public void TryLog()
        {
            try
            {                
                while (true) _logger.Debug(_messages.Take());
            }
            catch (InvalidOperationException)
            {                
                _logger.Debug("Upload complete.");
            }              
        }
    }
}
