using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelUpload
{
    public interface ILoggingClient
    {
        void SubscribeOn(ConcurrentQueue<string> messages);

        void TryLog();
    }

    public class LoggingClient : ILoggingClient
    {
        private readonly ILogger _logger;

        private ConcurrentQueue<string> _messages;

        public LoggingClient(ILogger logger)
        {
            _logger = logger;
        }

        public void SubscribeOn(ConcurrentQueue<string> messages)
        {
            _messages = messages;
        }

        public void TryLog()
        {
            string message;
            if (_messages.TryDequeue(out message))
            {
                _logger.Debug(message);
            }
        }
    }
}
