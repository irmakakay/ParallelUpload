using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelUpload
{
    public class LoggingClient
    {
        private readonly ILogger _logger;

        public LoggingClient(ILogger logger)
        {
            _logger = logger;
        }
    }
}
