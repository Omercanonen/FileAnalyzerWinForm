using FileAnalyzerWinForm.Business;
using FileAnalyzerWinForm.Core;
using FileAnalyzerWinForm.Model;
using FileAnalyzerWinForm.Services;
using System;
using System.Windows.Forms;

namespace FileAnalyzerWinForm
{
    public partial class Login : Form
    {

        private readonly ILogger _logger;
        private readonly AuthService _authService;
        public Login(ILogger logger)
        {
            InitializeComponent();

            _logger = logger;
            _authService = new AuthService();

            this.AcceptButton = buttonLogin;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password cannot be empty", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_authService.Login(username, password, out User user))
                {
                    _logger.Log($"Successfully Login : {username}");

                    this.Hide();
                    IExcelService excelService = new ExcelService(_logger);
                    var mainForm = new View.MainForm(_logger, user, excelService, _authService);
                    // mainForm.FormClosed += (_, __) => this.Close();
                    mainForm.FormClosed += (_, __) =>
                    {
                        textBoxPassword.Clear();
                        this.Show();
                        this.Activate();
                    };
                    mainForm.Show();
                }
                else
                {
                    _logger.Log($"Login Failed: {username}");
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Hatalı Giriş",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed During Login Process", ex);
                MessageBox.Show("Hata Olustu.", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private bool _passwordVisible = false;
        private void button1_Click_1(object sender, EventArgs e)
        {
            _passwordVisible = !_passwordVisible;

            if (_passwordVisible)
            {

                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true;
            }

        }

    }
}
