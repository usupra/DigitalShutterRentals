using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DigitalShutterRentals
{
    public partial class RegisterForm : Form
    {
        private const string UserFilePath = "users.txt";
        private const string MASTER_ADMIN_KEY = "YESSIR";

        public RegisterForm()
        {
            InitializeComponent();

            cmbRole.Items.Clear();
            cmbRole.Items.Add("Renter");
            cmbRole.Items.Add("Admin");
            cmbRole.SelectedIndex = 0;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtRegUsername.Text.Trim();
            string password = txtRegPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string selectedRole = cmbRole.SelectedItem as string ?? cmbRole.Text ?? "Renter";

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (username.Contains(",") || password.Contains(","))
            {
                MessageBox.Show("Usernames and passwords cannot contain commas.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRegPassword.Focus();
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
                return;
            }

            if (selectedRole == "Admin")
            {
                if (txtAdminKey.Text != MASTER_ADMIN_KEY)
                {
                    MessageBox.Show("Access Denied: Invalid Admin Security Passcode!\nYou cannot create an administrator account without authorization.",
                                    "Security Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtAdminKey.Clear();
                    txtAdminKey.Focus();
                    return;
                }
            }
            if (File.Exists(UserFilePath))
            {
                string[] lines = File.ReadAllLines(UserFilePath);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split(',');
                    if (parts.Length > 0 && parts[0].Trim().Equals(username, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("This username is already taken. Please choose another one.", "Account Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRegUsername.Focus();
                        return;
                    }
                }
            }

            try
            {
                string newUserRecord = $"{username},{password},{selectedRole}{Environment.NewLine}";
                File.AppendAllText(UserFilePath, newUserRecord);

                MessageBox.Show($"Account created successfully as {selectedRole}! You can now log in.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving account: {ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isAdmin = (cmbRole.SelectedItem as string ?? cmbRole.Text ?? string.Empty) == "Admin";

            lblAdminKey.Visible = isAdmin;
            txtAdminKey.Visible = isAdmin;
            chkShowPassword4.Visible = isAdmin;

            if (!isAdmin)
            {
                txtAdminKey.Clear();
            }
        }

        private void chkShowPassword2_CheckedChanged(object sender, EventArgs e)
        {
            txtRegPassword.UseSystemPasswordChar = !chkShowPassword2.Checked;
        }

        private void chkShowPassword3_CheckedChanged(object sender, EventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = !chkShowPassword3.Checked;
        }

        private void chkShowPassword4_CheckedChanged(object sender, EventArgs e)
        {
            txtAdminKey.UseSystemPasswordChar = !chkShowPassword4.Checked;
        }
    }

}