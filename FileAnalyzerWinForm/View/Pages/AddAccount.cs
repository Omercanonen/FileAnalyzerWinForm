using FileAnalyzerWinForm.Business;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FileAnalyzerWinForm.View.Pages
{
    public partial class AddAccount : UserControl
    {

        private readonly AuthService _authService;
        public AddAccount(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
            SetupUsersGrid();
            RefreshUsers();

            textBoxDisplayName.KeyDown += Input_KeyDown;
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAddAccount.PerformClick();
            }
        }

        private void SetupUsersGrid()
        {
            dataGridViewUsers.AutoGenerateColumns = false;
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.MultiSelect = false;

            dataGridViewUsers.Columns.Clear();

            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Display Name",
                DataPropertyName = "DisplayName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Username",
                DataPropertyName = "Username",
                Width = 160
            });

        }

        private void RefreshUsers()
        {
            var list = _authService.GetUsers()
                .Select(u => new { u.DisplayName, u.Username })
                .ToList();

            dataGridViewUsers.DataSource = null;
            dataGridViewUsers.DataSource = list;
        }

        private void buttonAddAccount_Click(object sender, EventArgs e)
        {
            string displayName = textBoxDisplayName.Text.Trim();
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text;

            bool ok = _authService.Register(username, password, displayName, out string message);

            MessageBox.Show(message);

            if (ok)
            {
                textBoxDisplayName.Clear();
                textBoxUsername.Clear();
                textBoxPassword.Clear();
                textBoxDisplayName.Focus();
                RefreshUsers();
            }
        }

    }
}
