using FileAnalyzerWinForm.Business;
using FileAnalyzerWinForm.Core;
using FileAnalyzerWinForm.Core.Enums;
using FileAnalyzerWinForm.DataAccess;
using FileAnalyzerWinForm.Model;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileAnalyzerWinForm.View.Pages
{
    public partial class FileAnalyzer : UserControl
    {
        private readonly ILogger _logger;
        private readonly User _user;
        private readonly IExcelService _excelService;
        private AnalysisResult _lastResult;

        private string _selectedFilePath = string.Empty;
        public FileAnalyzer(ILogger logger, User user, IExcelService excelService)
        {
            InitializeComponent();
            _logger = logger;
            _user = user;
            _excelService = excelService;

            comboBoxFileType.DataSource = Enum.GetValues(typeof(FileType));
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            if (comboBoxFileType.SelectedItem == null)
            {
                MessageBox.Show("Please select a file type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FileType selectedType = (FileType)comboBoxFileType.SelectedItem;
            string ext = selectedType.GetExtension();
            string extName = ext.TrimStart('.').ToUpper();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Please Select a File";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Filter = $"{extName} Files (*{ext})|*{ext}";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _selectedFilePath = openFileDialog.FileName;
                    _logger?.Log($"File Selected {_selectedFilePath}");

                    buttonAnalysis.Enabled = true;
                }
            }

        }

        private async void buttonAnalysis_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedFilePath))
            {
                MessageBox.Show("Please select a file", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            await SimulateLoadingAsync();

            PerformAnalysis();
        }

        private void PerformAnalysis()
        {
            try
            {
                var reader = FileReader.GetReader(_selectedFilePath);
                string fileContent = reader.ReadFile(_selectedFilePath);

                var analyzer = new TextAnalyzer();
                var result = analyzer.Analyze(fileContent);
                _lastResult = result;

                _logger?.Log($"Analysis Completed for: {_selectedFilePath}");

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Analysis Results");
                sb.AppendLine($"File: {Path.GetFileName(_selectedFilePath)}");
                sb.AppendLine();

                sb.AppendLine($"Total Words: {result.TotalWords}");
                sb.AppendLine($"Repeating Words: {result.RepeatingWords}");

                if (result.PuntactionCnt != null && result.PuntactionCnt.Count > 0)
                {
                    sb.AppendLine($"Total Punctuations: {result.PuntactionCnt.Count}");
                    foreach (var kv in result.PuntactionCnt)
                    {
                        sb.AppendLine($"{kv.Key} : {kv.Value}");
                    }
                }
                else
                {
                    sb.AppendLine("Total Punctuations: 0");
                }

                if (result.RepeatingWordsList != null && result.RepeatingWordsList.Count > 0)
                {
                    foreach (var kv in result.RepeatingWordsList)
                    {
                        sb.AppendLine($"{kv.Key} : {kv.Value}");
                    }
                }

                richTextBoxAnalysisResult.Text = sb.ToString();
            }
            catch (NotSupportedException ex)
            {
                _logger?.LogError("This file type is not supported", ex);
                MessageBox.Show(ex.Message, "This file type is not supported.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                _logger?.LogError("Error Occurred", ex);
                MessageBox.Show("Error Occurred:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonAnalysis.Enabled = true;
                buttonSelectFile.Enabled = true;
                comboBoxFileType.Enabled = true;

                progressBarLoading.Visible = false;
                progressBarLoading.Value = 0;
            }
        }

        private async Task SimulateLoadingAsync()
        {
            buttonAnalysis.Enabled = false;
            buttonSelectFile.Enabled = false;
            comboBoxFileType.Enabled = false;

            progressBarLoading.Visible = true;
            progressBarLoading.Value = 0;

            for (int i = 0; i <= 100; i += 10)
            {
                progressBarLoading.Value = i;
                await Task.Delay(100);
            }
        }

        private void buttonExcelExport_Click(object sender, EventArgs e)
        {
            if (_lastResult == null)
            {
                MessageBox.Show("Please perform analysis first before exporting", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Save Analysis Result";
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string targetPath = saveFileDialog.FileName;
                    try
                    {
                        _excelService.ExportAnalysis(_lastResult, _selectedFilePath, targetPath);
                        _logger?.Log($"Analysis exported to Excel {targetPath}");
                        MessageBox.Show("Analysis exported successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        _logger?.LogError("Failed to export analysis to Excel", ex);
                        MessageBox.Show("Failed to export analysis:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
    }
}
