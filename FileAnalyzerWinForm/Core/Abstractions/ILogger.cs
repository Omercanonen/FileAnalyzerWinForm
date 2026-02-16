using System;

namespace FileAnalyzerWinForm.Core
{
    public interface ILogger
    {
        void Log(string message);
        void LogError(string message, Exception ex);
    }
}
