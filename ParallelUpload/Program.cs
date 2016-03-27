using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Practices.Unity;

namespace ParallelUpload
{    
    static class Program
    {
        private static readonly IUnityContainer Container = new UnityContainer();

        static void Main(string[] args)
        {
            //GenerateFiles();            

            UploadBootstrapper.Configure(Container);

            var task = Create<ITask>();

            var sw = Stopwatch.StartNew();

            task.Run();

            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        private static T Create<T>()
        {
            return Container.Resolve<T>();
        }

        private static void GenerateFiles()
        {
            foreach (var i in Enumerable.Range(1, 1000))
            {
                SaveFile(i.ToString());
            }
        }

        private static void SaveFile(string fileName)
        {
            var config = Create<IUploadConfiguration>();

            using (var file = File.CreateText(Path.Combine(config.SourceDir, fileName + ".txt")))
            {
                file.WriteLine(fileName);
            }
        }
    }
}
