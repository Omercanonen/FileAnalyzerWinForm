using FileAnalyzerWinForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileAnalyzerWinForm.Business
{
    public class AuthService
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Username = "admin", Password = "admin", DisplayName = "Admin" },
        };

        public bool Login(string username, string password, out User user)
        {
            user = _users.FirstOrDefault(u =>
                string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);

            return user != null;
        }

        public bool Register(string username, string password, string displayName, out string message)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(displayName))
            {
                message = "Username, password and display name are required.";
                return false;
            }

            bool exists = _users.Any(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase));
            if (exists)
            {
                message = "This username is already taken.";
                return false;
            }

            _users.Add(new User
            {
                Username = username.Trim(),
                Password = password,
                DisplayName = displayName.Trim()
            });

            message = "User created successfully.";
            return true;
        }


        public IReadOnlyList<User> GetUsers() => _users;
    }
}
