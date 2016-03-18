using System;

namespace ParallelUpload
{
    public class Logger : ILogger
    {
        #region Implementation of ILogger

        public void Debug(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(string message, Exception ex)
        {
            Console.WriteLine(message, ex);
        }

        #endregion
    }
}