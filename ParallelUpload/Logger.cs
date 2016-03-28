using System;

namespace ParallelUpload
{
    public class Logger : ILogger
    {
        #region Implementation of ILogger

        public void Info(string message)
        {
            Console.WriteLine("INFO - {0}", message);
        }

        public void Debug(string message)
        {
            Console.WriteLine("DEBUG - {0}", message);
        }

        public void Warning(string message)
        {
            Console.WriteLine("WARNING - {0}", message);
        }

        public void Error(string message, Exception ex)
        {
            Console.WriteLine("ERROR - {0}{1}EXCEPTION - {2}", message, Environment.NewLine, ex);
        }

        public void Log(ILogMessage message)
        {
            switch (message.LogLevel)
            {
                    case LogLevel.Info: Info(message.Text);
                    break;
                    case LogLevel.Debug: Debug(message.Text);
                    break;
                    case LogLevel.Warning: Warning(message.Text);
                    break;
                    case LogLevel.Error: Error(message.Text, message.Exception);
                    break;
            }            
        }

        #endregion
    }
}