using FileAnalyzerWinForm.Core;
using FileAnalyzerWinForm.Core.Enums;
using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace FileAnalyzerWinForm.DataAccess.FileReaders
{
    public class PdfFileReader : IFileReader
    {
        public FileType FileType => FileType.PdfFormat;

        public string ReadFile(string filePath)
        {
            using (PdfDocument document = PdfDocument.Open(filePath))
            {
                StringBuilder text = new StringBuilder();
                foreach (Page page in document.GetPages())
                    text.AppendLine(page.Text);

                return text.ToString();
            }
        }
    }
}
