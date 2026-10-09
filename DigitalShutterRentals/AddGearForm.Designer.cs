namespace DigitalShutterRentals
{
    partial class AddGearForm
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
            txtGearId = new TextBox();
            txtModelName = new TextBox();
            cmbGearCategory = new ComboBox();
            numDailyRate = new NumericUpDown();
            btnSaveGear = new Button();
            btnCancel = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numDailyRate).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(91, 9);
            label1.Name = "label1";
            label1.Size = new Size(258, 25);
            label1.TabIndex = 0;
            label1.Text = "Add New Gear to Inventory";
            // 
            // txtGearId
            // 
            txtGearId.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGearId.Location = new Point(57, 96);
            txtGearId.Name = "txtGearId";
            txtGearId.Size = new Size(138, 25);
            txtGearId.TabIndex = 1;
            // 
            // txtModelName
            // 
            txtModelName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtModelName.Location = new Point(234, 96);
            txtModelName.Name = "txtModelName";
            txtModelName.Size = new Size(149, 25);
            txtModelName.TabIndex = 2;
            // 
            // cmbGearCategory
            // 
            cmbGearCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGearCategory.FormattingEnabled = true;
            cmbGearCategory.Items.AddRange(new object[] { "Camera", "Lens", "Lighting", "Drone", "Audio" });
            cmbGearCategory.Location = new Point(57, 183);
            cmbGearCategory.Name = "cmbGearCategory";
            cmbGearCategory.Size = new Size(138, 23);
            cmbGearCategory.TabIndex = 3;
            // 
            // numDailyRate
            // 
            numDailyRate.DecimalPlaces = 2;
            numDailyRate.Location = new Point(234, 184);
            numDailyRate.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numDailyRate.Name = "numDailyRate";
            numDailyRate.Size = new Size(149, 23);
            numDailyRate.TabIndex = 4;
            // 
            // btnSaveGear
            // 
            btnSaveGear.BackColor = Color.FromArgb(230, 126, 34);
            btnSaveGear.ForeColor = Color.White;
            btnSaveGear.Location = new Point(161, 235);
            btnSaveGear.Name = "btnSaveGear";
            btnSaveGear.Size = new Size(110, 23);
            btnSaveGear.TabIndex = 5;
            btnSaveGear.Text = "SAVE EQUIPMENT";
            btnSaveGear.UseVisualStyleBackColor = false;
            btnSaveGear.Click += btnSaveGear_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(181, 264);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 69);
            label2.Name = "label2";
            label2.Size = new Size(114, 15);
            label2.TabIndex = 7;
            label2.Text = "Gear ID (e.g. EQ107):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(234, 69);
            label3.Name = "label3";
            label3.Size = new Size(148, 15);
            label3.TabIndex = 8;
            label3.Text = "Model / Equipment Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(57, 145);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 9;
            label4.Text = "Category:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(234, 145);
            label5.Name = "label5";
            label5.Size = new Size(115, 15);
            label5.TabIndex = 10;
            label5.Text = "Daily Rental Rate ($):";
            // 
            // AddGearForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 337);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveGear);
            Controls.Add(numDailyRate);
            Controls.Add(cmbGearCategory);
            Controls.Add(txtModelName);
            Controls.Add(txtGearId);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AddGearForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Digital Shutter Rentals - Add Equipment";
            ((System.ComponentModel.ISupportInitialize)numDailyRate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtGearId;
        private TextBox txtModelName;
        private ComboBox cmbGearCategory;
        private NumericUpDown numDailyRate;
        private Button btnSaveGear;
        private Button btnCancel;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}