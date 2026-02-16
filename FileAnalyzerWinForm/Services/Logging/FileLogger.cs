using FileAnalyzerWinForm.Core;
using System;
using System.IO;

namespace FileAnalyzerWinForm.DataAccess
{
    public class FileLogger : ILogger
    {
        private readonly string _logFilePath;

        public FileLogger()
        {
            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
            _logFilePath = Path.Combine(folder, "app_log.txt");
        }

        public void Log(string message)
        {
            string log = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | INFO  | {message}";

            File.AppendAllText(_logFilePath, log + Environment.NewLine);
        }

        public void LogError(string message, Exception ex)
        {
            string log =
                $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | ERROR | {message} | {ex.Message}";

            File.AppendAllText(_logFilePath, log + Environment.NewLine);
        }
    }
}

