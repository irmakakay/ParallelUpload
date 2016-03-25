using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Timer = System.Timers.Timer;

namespace ParallelUpload
{
    class Program
    {
        private const string SourceDir = @"D:\code\massive\ParallelUpload\Source";
        private const string TargetDir = @"D:\code\massive\ParallelUpload\Target";

        static void Main(string[] args)
        {
            //GenerateFiles();            

            var task = new UploadTask(
                SourceDir, 
                new FileServiceProxy(new FileService(), new ParallelIterator(new DefaultMessageFormatter()), TargetDir), 
                new LoggingClient(new Logger()));

            var sw = Stopwatch.StartNew();

            task.Run();

            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds);
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
            using (var file = File.CreateText(Path.Combine(SourceDir, fileName + ".txt")))
            {
                file.WriteLine(fileName);
            }
        }
    }
}
