using System;
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

        public UploadTask(string sourceDir, IFileServiceProxy fileService, ILoggingClient logger)
        {
            _sourceDir = sourceDir;            
            _fileService = fileService;
            _logger = logger;
        }

        public void Run()
        {
            var files = Directory.GetFiles(_sourceDir);

            
        }
    }
}
