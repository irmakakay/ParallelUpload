using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelUpload
{
    public interface IFileServiceProxy
    {
        void SubscibeOn(ConcurrentQueue<string> messages);

        void UploadFiles(IEnumerable<string> files);
    }

    public class FileServiceProxy : IFileServiceProxy
    {
        private readonly IFileService _fileService;

        private readonly string _targetDir;

        private HashSet<string> _existingFiles;

        private ConcurrentQueue<string> _messages; 

        public FileServiceProxy(IFileService fileService, string targetDir)
        {
            _fileService = fileService;
            _targetDir = targetDir;
        }

        #region Implementation of IFileServiceProxy

        public void SubscibeOn(ConcurrentQueue<string> messages)
        {
            _messages = messages;
        }

        public void UploadFiles(IEnumerable<string> files)
        {
            ForEachAsync(files, 
                Environment.ProcessorCount, 
                f => _fileService.UploadAsync(f, _targetDir))
                .Wait();

            //var options = new ParallelOptions {MaxDegreeOfParallelism = Environment.ProcessorCount};

            //var result = Parallel.ForEach(files, options, file =>
            //{
            //    _fileService.Upload(file, _targetDir);
            //    _messages.Enqueue(string.Format("{0} copied under {1}", file, _targetDir));
            //});                      
        }

        #endregion

        private HashSet<string> ExistingFiles
        {
            get { return _existingFiles ?? 
                (_existingFiles = new HashSet<string>(Directory.GetFiles(_targetDir))); }
        }

        public Task ForEachAsync<T>(IEnumerable<T> source, int dop, Func<T, Task> body)
        {
            return Task.WhenAll(
                from partition in Partitioner.Create(source).GetPartitions(dop)
                select Task.Run(async delegate
                {
                    using (partition)
                        while (partition.MoveNext())
                        {
                            await body(partition.Current);
                            _messages.Enqueue(string.Format("{0} copied under {1}", partition.Current, _targetDir));
                        }
                }));
        }
    }
}
