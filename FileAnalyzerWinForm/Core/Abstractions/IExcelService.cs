using FileAnalyzerWinForm.Model;

namespace FileAnalyzerWinForm.Core
{
    public interface IExcelService
    {
        void ExportAnalysis(AnalysisResult result, string filePath, string targetSavePath);
    }
}
