using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DigitalShutterRentals
{
    public partial class LoginForm : Form
    {
        
        private Dictionary<string, User> userDatabase = new Dictionary<string, User>(StringComparer.OrdinalIgnoreCase);
        private const string UserFilePath = "users.txt";

        public LoginForm()
        {
            InitializeComponent();
            LoadUsersFromFile();
        }

        private void LoadUsersFromFile()
        {
            userDatabase.Clear();

            
            if (!File.Exists(UserFilePath))
            {
                File.WriteAllLines(UserFilePath, new[] {
                    "admin,admin123,Admin",
                    "john_doe,pass123,Renter"
                });
            }

            string[] lines = File.ReadAllLines(UserFilePath);
            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                if (string.IsNullOrWhiteSpace(trimmedLine)) continue;

                string[] parts = trimmedLine.Split(',');
                if (parts.Length == 3)
                {
                    string username = parts[0].Trim();
                    string password = parts[1].Trim();
                    string role = parts[2].Trim();

                    userDatabase[username] = new User(username, password, role);
                }
            }
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (userDatabase.ContainsKey(username))
            {
                User currentUser = userDatabase[username];

                if (currentUser.Password == password)
                {
                    MessageBox.Show($"Login Successful! Welcome {currentUser.Username} ({currentUser.Role}).",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                }
                else
                {
                    MessageBox.Show("Incorrect password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            else
            {
                MessageBox.Show("User does not exist. Please register first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void lnkRegister_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            this.Hide();
            regForm.ShowDialog();

            this.Show();
            LoadUsersFromFile();
        }
    }
}