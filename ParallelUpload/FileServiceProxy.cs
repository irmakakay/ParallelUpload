﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelUpload
{
    public interface IFileServiceProxy
    {
        void SubscibeOn(BlockingCollection<ILogMessage> messages);

        void UploadFiles(IEnumerable<string> files);
    }

    public class FileServiceProxy : IFileServiceProxy
    {
        private readonly IFileService _fileService;

        private readonly IUploadConfiguration _configuration;

        private readonly IParallelIterator _iterator;

        private HashSet<string> _existingFiles;

        private BlockingCollection<ILogMessage> _messages; 

        public FileServiceProxy(IFileService fileService, IParallelIterator iterator, IUploadConfiguration configuration)
        {
            _fileService = fileService;
            _configuration = configuration;
            _iterator = iterator;
        }

        #region Implementation of IFileServiceProxy

        public void SubscibeOn(BlockingCollection<ILogMessage> messages)
        {
            _messages = messages;
        }

        public void UploadFiles(IEnumerable<string> files)
        {
            _iterator.ForEachAsync(
                _messages, 
                files, 
                Environment.ProcessorCount, 
                f => _fileService.Upload(f, _configuration.TargetDir))
                .Wait();   
            
            _messages.CompleteAdding();
        }

        #endregion

        private HashSet<string> ExistingFiles
        {
            get { return _existingFiles ?? 
                (_existingFiles = new HashSet<string>(Directory.GetFiles(_configuration.TargetDir))); }
        }
    }
}
