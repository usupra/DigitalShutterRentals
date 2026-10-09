namespace DigitalShutterRentals
{
    partial class ManageRentalsForm
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
            dgvRentals = new DataGridView();
            label2 = new Label();
            cmbCondition = new ComboBox();
            btnReturnGear = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRentals).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(246, 9);
            label1.Name = "label1";
            label1.Size = new Size(341, 25);
            label1.TabIndex = 0;
            label1.Text = "Active Rentals and Return Processing";
            // 
            // dgvRentals
            // 
            dgvRentals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRentals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRentals.Location = new Point(-1, 56);
            dgvRentals.MultiSelect = false;
            dgvRentals.Name = "dgvRentals";
            dgvRentals.ReadOnly = true;
            dgvRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRentals.Size = new Size(835, 331);
            dgvRentals.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(-1, 396);
            label2.Name = "label2";
            label2.Size = new Size(159, 15);
            label2.TabIndex = 2;
            label2.Text = "Return Inspection Condition:";
            // 
            // cmbCondition
            // 
            cmbCondition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCondition.FormattingEnabled = true;
            cmbCondition.Items.AddRange(new object[] { "Excellent (Like New)", "Good (Minor Wear)", "Damaged / Needs Service" });
            cmbCondition.Location = new Point(164, 393);
            cmbCondition.Name = "cmbCondition";
            cmbCondition.Size = new Size(152, 23);
            cmbCondition.TabIndex = 3;
            // 
            // btnReturnGear
            // 
            btnReturnGear.BackColor = Color.FromArgb(230, 126, 34);
            btnReturnGear.FlatStyle = FlatStyle.Flat;
            btnReturnGear.ForeColor = Color.White;
            btnReturnGear.Location = new Point(322, 393);
            btnReturnGear.Name = "btnReturnGear";
            btnReturnGear.Size = new Size(132, 23);
            btnReturnGear.TabIndex = 4;
            btnReturnGear.Text = "PROCESS RETURN";
            btnReturnGear.UseVisualStyleBackColor = false;
            btnReturnGear.Click += btnReturnGear_Click;
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(460, 393);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ManageRentalsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 441);
            Controls.Add(btnClose);
            Controls.Add(btnReturnGear);
            Controls.Add(cmbCondition);
            Controls.Add(label2);
            Controls.Add(dgvRentals);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ManageRentalsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Digital Shutter Rentals - Bookings & Returns";
            ((System.ComponentModel.ISupportInitialize)dgvRentals).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvRentals;
        private Label label2;
        private ComboBox cmbCondition;
        private Button btnReturnGear;
        private Button btnClose;
    }
}