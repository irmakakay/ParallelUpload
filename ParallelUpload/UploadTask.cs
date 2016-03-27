using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;

namespace ParallelUpload
{
    public class UploadTask : ITask
    {        
        private readonly IUploadConfiguration _configuration;
        private readonly IFileServiceProxy _fileService;
        private readonly ILoggingClient _logger;
        
        private readonly BlockingCollection<string> _messages = new BlockingCollection<string>();

        public UploadTask(IUploadConfiguration configuration, IFileServiceProxy fileService, ILoggingClient logger)
        {
            _configuration = configuration; 
            _fileService = fileService;
            _logger = logger;            

            InitMessages();
        }

        public void Run()
        {           
            var files = Directory.GetFiles(_configuration.SourceDir);            

            var upload = Task.Factory.StartNew(() => _fileService.UploadFiles(files));
            var log = Task.Factory.StartNew(() => _logger.TryLog());

            Task.WaitAll(upload, log);
        }

        private void InitMessages()
        {
            _fileService.SubscibeOn(_messages);
            _logger.SubscribeOn(_messages);
        }
    }
}
