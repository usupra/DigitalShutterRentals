namespace DigitalShutterRentals
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtRegUsername = new TextBox();
            txtRegPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            cmbRole = new ComboBox();
            btnRegister = new Button();
            btnCancel = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            lblAdminKey = new Label();
            txtAdminKey = new TextBox();
            chkShowPassword2 = new CheckBox();
            chkShowPassword3 = new CheckBox();
            chkShowPassword4 = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(115, 44);
            label1.Name = "label1";
            label1.Size = new Size(193, 30);
            label1.TabIndex = 0;
            label1.Text = "Create an Account";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(163, 74);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 1;
            label2.Text = "Renter or Admin";
            // 
            // txtRegUsername
            // 
            txtRegUsername.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRegUsername.Location = new Point(46, 145);
            txtRegUsername.Name = "txtRegUsername";
            txtRegUsername.Size = new Size(146, 27);
            txtRegUsername.TabIndex = 2;
            // 
            // txtRegPassword
            // 
            txtRegPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRegPassword.Location = new Point(46, 206);
            txtRegPassword.Name = "txtRegPassword";
            txtRegPassword.Size = new Size(146, 27);
            txtRegPassword.TabIndex = 3;
            txtRegPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPassword.Location = new Point(46, 269);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(146, 27);
            txtConfirmPassword.TabIndex = 4;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Renter", "Admin" });
            cmbRole.Location = new Point(225, 145);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(174, 23);
            cmbRole.TabIndex = 5;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(230, 126, 34);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(149, 385);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(120, 23);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "CREATE ACCOUNT";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(158, 414);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Back to Login";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 119);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 8;
            label3.Text = "Username:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(225, 119);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 9;
            label4.Text = "Account Role:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(46, 184);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 10;
            label5.Text = "Password:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(46, 244);
            label6.Name = "label6";
            label6.Size = new Size(107, 15);
            label6.TabIndex = 11;
            label6.Text = "Confirm Password:";
            // 
            // lblAdminKey
            // 
            lblAdminKey.AutoSize = true;
            lblAdminKey.Location = new Point(46, 313);
            lblAdminKey.Name = "lblAdminKey";
            lblAdminKey.Size = new Size(143, 15);
            lblAdminKey.TabIndex = 12;
            lblAdminKey.Text = "Admin Security Passcode:";
            lblAdminKey.Visible = false;
            // 
            // txtAdminKey
            // 
            txtAdminKey.Location = new Point(46, 342);
            txtAdminKey.Name = "txtAdminKey";
            txtAdminKey.Size = new Size(146, 23);
            txtAdminKey.TabIndex = 13;
            txtAdminKey.UseSystemPasswordChar = true;
            txtAdminKey.Visible = false;
            // 
            // chkShowPassword2
            // 
            chkShowPassword2.AutoSize = true;
            chkShowPassword2.Location = new Point(198, 212);
            chkShowPassword2.Name = "chkShowPassword2";
            chkShowPassword2.Size = new Size(108, 19);
            chkShowPassword2.TabIndex = 14;
            chkShowPassword2.Text = "Show Password";
            chkShowPassword2.UseVisualStyleBackColor = true;
            chkShowPassword2.CheckedChanged += chkShowPassword2_CheckedChanged;
            // 
            // chkShowPassword3
            // 
            chkShowPassword3.AutoSize = true;
            chkShowPassword3.Location = new Point(198, 269);
            chkShowPassword3.Name = "chkShowPassword3";
            chkShowPassword3.Size = new Size(108, 19);
            chkShowPassword3.TabIndex = 15;
            chkShowPassword3.Text = "Show Password";
            chkShowPassword3.UseVisualStyleBackColor = true;
            chkShowPassword3.CheckedChanged += chkShowPassword3_CheckedChanged;
            // 
            // chkShowPassword4
            // 
            chkShowPassword4.AutoSize = true;
            chkShowPassword4.Location = new Point(198, 346);
            chkShowPassword4.Name = "chkShowPassword4";
            chkShowPassword4.Size = new Size(108, 19);
            chkShowPassword4.TabIndex = 16;
            chkShowPassword4.Text = "Show Password";
            chkShowPassword4.UseVisualStyleBackColor = true;
            chkShowPassword4.Visible = false;
            chkShowPassword4.CheckedChanged += chkShowPassword4_CheckedChanged;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(434, 481);
            Controls.Add(chkShowPassword4);
            Controls.Add(chkShowPassword3);
            Controls.Add(chkShowPassword2);
            Controls.Add(txtAdminKey);
            Controls.Add(lblAdminKey);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnCancel);
            Controls.Add(btnRegister);
            Controls.Add(cmbRole);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtRegPassword);
            Controls.Add(txtRegUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Digital Shutter Rentals - Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtRegUsername;
        private TextBox txtRegPassword;
        private TextBox txtConfirmPassword;
        private ComboBox cmbRole;
        private Button btnRegister;
        private Button btnCancel;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label lblAdminKey;
        private TextBox txtAdminKey;
        private CheckBox chkShowPassword2;
        private CheckBox chkShowPassword3;
        private CheckBox chkShowPassword4;
    }
}