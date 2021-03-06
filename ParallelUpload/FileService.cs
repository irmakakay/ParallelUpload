﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelUpload
{
    public interface IFileService
    {
        Task<bool> Upload(string source, string target);

        Task<bool> UploadAsync(string source, string target);
    }

    public class FileService : IFileService
    {
        public Task<bool> Upload(string source, string target)
        {
            return Task.Run(() => UploadFile(source, target));
        }

        public async Task<bool> UploadAsync(string source, string target)
        {
            return await Upload(source, target);
        }

        private bool UploadFile(string source, string target)
        {
            try
            {
                var file = new FileInfo(source);
                file.CopyTo(Path.Combine(target, file.Name));
                
                Thread.Sleep(200);

                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }
    }
}
