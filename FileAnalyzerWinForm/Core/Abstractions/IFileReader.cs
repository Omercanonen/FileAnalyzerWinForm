using FileAnalyzerWinForm.Core.Enums;

namespace FileAnalyzerWinForm.Core
{
    public interface IFileReader
    {
        FileType FileType { get; }
        string ReadFile(string filePath);
    }
}
