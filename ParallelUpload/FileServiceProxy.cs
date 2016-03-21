using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelUpload
{
    public interface IFileServiceProxy
    {
        void UploadFiles(IEnumerable<string> files);
    }

    public class FileServiceProxy : IFileServiceProxy
    {
        private readonly IFileService _fileService;

        private readonly string _targetDir;

        private HashSet<string> _existingFiles; 

        public FileServiceProxy(IFileService fileService, string targetDir)
        {
            _fileService = fileService;
            _targetDir = targetDir;
        }

        #region Implementation of IFileServiceProxy

        public void UploadFiles(IEnumerable<string> files)
        {
            

            throw new NotImplementedException();
        }

        #endregion

        private HashSet<string> ExistingFiles
        {
            get { return _existingFiles ?? 
                (_existingFiles = new HashSet<string>(Directory.GetFiles(_targetDir))); }
        }
    }
}
