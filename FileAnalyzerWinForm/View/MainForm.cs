using FileAnalyzerWinForm.Business;
using FileAnalyzerWinForm.Core;
using FileAnalyzerWinForm.Model;
using FileAnalyzerWinForm.View.Pages;
using System;
using System.Windows.Forms;

namespace FileAnalyzerWinForm.View
{
    public partial class MainForm : Form
    {

        private readonly ILogger _logger;
        private readonly User _user;
        private readonly IExcelService _excelService;
        private readonly AuthService _authService;

        public MainForm(ILogger logger, User user, IExcelService excelService, AuthService authService)
        {
            InitializeComponent();
            _logger = logger;
            _user = user;
            _excelService = excelService;
            _authService = authService; 

            DisplayUserInfo();
        }

        private void DisplayUserInfo()
        {
            if (_user != null && !string.IsNullOrEmpty(_user.DisplayName))
            {

                labelUser.Text = $"{_user.DisplayName}";
            }
            else
            {
                labelUser.Text = "Guest";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FileAnalyzer fileAnalyzerControl = new FileAnalyzer(_logger, _user, _excelService);
            LoadUserControl(fileAnalyzerControl);

        }

        private void LoadUserControl(UserControl userControl)
        {
            if (panelContent != null)
            {
                panelContent.Controls.Clear();
                userControl.Dock = DockStyle.Fill;
                panelContent.Controls.Add(userControl);
                userControl.BringToFront();
            }
        }

        private void buttonAddAccount_Click(object sender, EventArgs e)
        {
            var addAccountControl = new AddAccount(_authService);
            LoadUserControl(addAccountControl);
        }

        private void labelLogOut_Click(object sender, EventArgs e)
        {
            _logger.Log($"Logout : {_user?.Username}");
            this.Close();
        }

        private void buttonHomePage_Click(object sender, EventArgs e)
        {
            var fileAnalyzerControl = new FileAnalyzer(_logger, _user, _excelService);
            LoadUserControl(fileAnalyzerControl);
        }
    }
}


