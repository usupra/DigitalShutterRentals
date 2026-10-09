namespace DigitalShutterRentals
{
    partial class EditGearForm
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
            lblGearId = new Label();
            txtModelName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            cmbGearCategory = new ComboBox();
            numDailyRate = new NumericUpDown();
            label3 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numDailyRate).BeginInit();
            SuspendLayout();
            // 
            // lblGearId
            // 
            lblGearId.AutoSize = true;
            lblGearId.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGearId.Location = new Point(29, 105);
            lblGearId.Name = "lblGearId";
            lblGearId.Size = new Size(98, 20);
            lblGearId.TabIndex = 0;
            lblGearId.Text = "Gear ID: [ID]";
            // 
            // txtModelName
            // 
            txtModelName.Location = new Point(252, 136);
            txtModelName.Name = "txtModelName";
            txtModelName.Size = new Size(157, 23);
            txtModelName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(252, 105);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 2;
            label1.Text = "Model / Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 177);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 3;
            label2.Text = "Category:";
            // 
            // cmbGearCategory
            // 
            cmbGearCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGearCategory.FormattingEnabled = true;
            cmbGearCategory.Items.AddRange(new object[] { "Camera", "Lens", "Lighting", "Drone", "Audio" });
            cmbGearCategory.Location = new Point(29, 206);
            cmbGearCategory.Name = "cmbGearCategory";
            cmbGearCategory.Size = new Size(157, 23);
            cmbGearCategory.TabIndex = 4;
            // 
            // numDailyRate
            // 
            numDailyRate.DecimalPlaces = 2;
            numDailyRate.Location = new Point(252, 206);
            numDailyRate.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numDailyRate.Name = "numDailyRate";
            numDailyRate.Size = new Size(157, 23);
            numDailyRate.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(252, 177);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 6;
            label3.Text = "Daily Rate ($):";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(230, 126, 34);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(181, 246);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 7;
            btnSave.Text = "SAVE CHANGES";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(181, 285);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // EditGearForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 381);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label3);
            Controls.Add(numDailyRate);
            Controls.Add(cmbGearCategory);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtModelName);
            Controls.Add(lblGearId);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "EditGearForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Equipment Details";
            ((System.ComponentModel.ISupportInitialize)numDailyRate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblGearId;
        private TextBox txtModelName;
        private Label label1;
        private Label label2;
        private ComboBox cmbGearCategory;
        private NumericUpDown numDailyRate;
        private Label label3;
        private Button btnSave;
        private Button btnCancel;
    }
}