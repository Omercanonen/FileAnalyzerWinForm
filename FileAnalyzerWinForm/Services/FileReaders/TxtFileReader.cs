using FileAnalyzerWinForm.Core;
using FileAnalyzerWinForm.Core.Enums;
using System.IO;

namespace FileAnalyzerWinForm.DataAccess.FileReaders
{
    public class TxtFileReader : IFileReader
    {
        public FileType FileType => FileType.TxtFormat;
        public string ReadFile(string filePath) => File.ReadAllText(filePath);
    }
}
