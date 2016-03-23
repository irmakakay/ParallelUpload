using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelUpload
{
    public class UploadTask
    {
        private readonly string _sourceDir;        
        private readonly IFileServiceProxy _fileService;
        private readonly ILoggingClient _logger;
        private readonly ConcurrentQueue<string> _messages = new ConcurrentQueue<string>(); 

        public UploadTask(string sourceDir, IFileServiceProxy fileService, ILoggingClient logger)
        {
            _sourceDir = sourceDir;            
            _fileService = fileService;
            _logger = logger;

            InitMessages();
        }

        public void InitMessages()
        {
            _fileService.SubscibeOn(_messages);
            _logger.SubscribeOn(_messages);
        }

        public void Run()
        {           
            var files = Directory.GetFiles(_sourceDir);

            _fileService.UploadFiles(files);
        }
    }
}
