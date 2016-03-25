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
        
        private readonly BlockingCollection<string> _messages = new BlockingCollection<string>(); 

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

            var upload = Task.Factory.StartNew(() => _fileService.UploadFiles(files));
            var log = Task.Factory.StartNew(() => _logger.TryLog());

            Task.WaitAll(upload, log);
        }      
    }
}
