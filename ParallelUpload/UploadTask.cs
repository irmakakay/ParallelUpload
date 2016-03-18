using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelUpload
{
    public class UploadTask
    {
        private readonly string _sourceDir;
        private readonly string _targetDir;
        private readonly IFileServiceProxy _fileService;

        public UploadTask(string sourceDir, string targetDir, IFileServiceProxy fileService)
        {
            _sourceDir = sourceDir;
            _targetDir = targetDir;
            _fileService = fileService;
        }
    }
}
