namespace DigitalShutterRentals
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelBrand = new Panel();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtUsername = new TextBox();
            label5 = new Label();
            txtPassword = new TextBox();
            chkShowPassword = new CheckBox();
            btnLogin = new Button();
            lnkRegister = new LinkLabel();
            panelBrand.SuspendLayout();
            SuspendLayout();
            // 
            // panelBrand
            // 
            panelBrand.BackColor = SystemColors.ActiveCaptionText;
            panelBrand.Controls.Add(label2);
            panelBrand.Controls.Add(label1);
            panelBrand.Dock = DockStyle.Left;
            panelBrand.Location = new Point(0, 0);
            panelBrand.Name = "panelBrand";
            panelBrand.Size = new Size(320, 461);
            panelBrand.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Goldenrod;
            label2.Location = new Point(73, 206);
            label2.Name = "label2";
            label2.Size = new Size(176, 20);
            label2.TabIndex = 2;
            label2.Text = "Camera and Gear Rentals";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(52, 172);
            label1.Name = "label1";
            label1.Size = new Size(218, 32);
            label1.TabIndex = 1;
            label1.Text = "DIGITAL SHUTTER";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(480, 143);
            label3.Name = "label3";
            label3.Size = new Size(155, 30);
            label3.TabIndex = 1;
            label3.Text = "Welcome Back";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(411, 196);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 2;
            label4.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(480, 189);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(152, 27);
            txtUsername.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(414, 241);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 4;
            label5.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(480, 234);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(152, 27);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(638, 242);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(108, 19);
            chkShowPassword.TabIndex = 6;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged_1;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Orange;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(519, 267);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 31);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "LOG IN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // lnkRegister
            // 
            lnkRegister.AutoSize = true;
            lnkRegister.Location = new Point(458, 301);
            lnkRegister.Name = "lnkRegister";
            lnkRegister.Size = new Size(202, 15);
            lnkRegister.TabIndex = 8;
            lnkRegister.TabStop = true;
            lnkRegister.Text = "Don't have an account? Register here";
            lnkRegister.LinkClicked += lnkRegister_LinkClicked_1;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(lnkRegister);
            Controls.Add(btnLogin);
            Controls.Add(chkShowPassword);
            Controls.Add(txtPassword);
            Controls.Add(label5);
            Controls.Add(txtUsername);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panelBrand);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Digital Shutter Rentals";
            panelBrand.ResumeLayout(false);
            panelBrand.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelBrand;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox txtUsername;
        private Label label5;
        private TextBox txtPassword;
        private CheckBox chkShowPassword;
        private Button btnLogin;
        private LinkLabel lnkRegister;
    }
}
