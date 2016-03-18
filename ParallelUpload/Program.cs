using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ParallelUpload
{
    class Program
    {
        private const string SourceDir = @"D:\code\massive\ParallelUpload\Source";
        private const string TargetDir = @"D:\code\massive\ParallelUpload\Target";

        static void Main(string[] args)
        {
            GenerateFiles();
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
