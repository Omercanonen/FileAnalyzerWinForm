using FileAnalyzerWinForm.Core;
using FileAnalyzerWinForm.Model;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.IO;

namespace FileAnalyzerWinForm.Services
{
    public class ExcelService : IExcelService
    {
        private readonly ILogger _logger;

        public ExcelService(ILogger logger)
        {
            _logger = logger;
        }

        public void ExportAnalysis(AnalysisResult result, string sourceFilePath, string targetSavePath)
        {
            ExcelPackage.License.SetNonCommercialPersonal("File Analyzer");

            try
            {
                using (var package = new ExcelPackage())
                {
                    var summarySheet = package.Workbook.Worksheets.Add("Summary");
                    summarySheet.Cells["A1"].Value = "FILE ANALYSIS SUMMARY";
                    summarySheet.Cells["A1:B1"].Merge = true;
                    summarySheet.Cells["A1"].Style.Font.Bold = true;
                    summarySheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    summarySheet.Cells["A3"].Value = "File Name:";
                    summarySheet.Cells["B3"].Value = Path.GetFileName(sourceFilePath);
                    summarySheet.Cells["A4"].Value = "Total Words:";
                    summarySheet.Cells["B4"].Value = result.TotalWords;
                    summarySheet.Cells["A5"].Value = "Repeating Words:";
                    summarySheet.Cells["B5"].Value = result.RepeatingWords;

                    summarySheet.Cells["A1:A5"].Style.Font.Bold = true;
                    summarySheet.Column(1).AutoFit();

                    if (result.RepeatingWordsList != null && result.RepeatingWordsList.Count > 0)
                    {
                        var wordSheet = package.Workbook.Worksheets.Add("Word Frequencies");
                        wordSheet.Cells["A1"].Value = "Word";
                        wordSheet.Cells["B1"].Value = "Frequency";

                        using (var range = wordSheet.Cells["A1:B1"])
                        {
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                        }

                        int row = 2;
                        foreach (var kv in result.RepeatingWordsList)
                        {
                            wordSheet.Cells[row, 1].Value = kv.Key;
                            wordSheet.Cells[row, 2].Value = kv.Value;
                            row++;
                        }
                        wordSheet.Cells[wordSheet.Dimension.Address].AutoFitColumns();
                    }

                    FileInfo fileInfo = new FileInfo(targetSavePath);
                    package.SaveAs(fileInfo);
                    _logger?.Log($"Excel report created: {targetSavePath}");
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError("Service Export Error", ex);
                throw; 
            }
        }
    }
}

