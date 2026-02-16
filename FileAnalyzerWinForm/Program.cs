using FileAnalyzerWinForm.Core;
using FileAnalyzerWinForm.DataAccess;
using FileAnalyzerWinForm.Services;
using System;
using System.Windows.Forms;

namespace FileAnalyzerWinForm
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ILogger logger = new FileLogger();

            Application.Run(new Login(logger));

            IExcelService excelService = new ExcelService(logger);
        }
    }
}
