using System;
using Microsoft.Practices.Unity;

namespace ParallelUpload
{
    public static class UploadBootstrapper
    {        
        public static void Configure(IUnityContainer container)
        {
            if (container == null) throw new ArgumentException("container");

            container.RegisterType<IUploadConfiguration, UploadConfiguration>();
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<ILoggingClient, LoggingClient>();
            container.RegisterType<IMessageFormatter, DefaultMessageFormatter>();
            container.RegisterType<IParallelIterator, ParallelIterator>();
            container.RegisterType<IFileService, FileService>();
            container.RegisterType<IFileServiceProxy, FileServiceProxy>();
            container.RegisterType<ITask, UploadTask>();
        }
    }
}
