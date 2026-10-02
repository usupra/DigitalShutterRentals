namespace DigitalShutterRentals
{
    partial class MainDashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDashboardForm));
            lblUserGreeting = new Label();
            txtSearch = new TextBox();
            cmbCategoryFilter = new ComboBox();
            btnResetFilter = new Button();
            dgvEquipment = new DataGridView();
            lblSelectedGear = new Label();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            lblTotalSummary = new Label();
            btnBookGear = new Button();
            label1 = new Label();
            label2 = new Label();
            toolStripMain = new ToolStrip();
            tslblUser = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbtnRentals = new ToolStripButton();
            tsbtnAddGear = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbtnLogout = new ToolStripButton();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEquipment).BeginInit();
            toolStripMain.SuspendLayout();
            SuspendLayout();
            // 
            // lblUserGreeting
            // 
            lblUserGreeting.AutoSize = true;
            lblUserGreeting.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserGreeting.Location = new Point(295, 29);
            lblUserGreeting.Name = "lblUserGreeting";
            lblUserGreeting.Size = new Size(87, 21);
            lblUserGreeting.TabIndex = 0;
            lblUserGreeting.Text = "Welcome!";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(616, 31);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(128, 23);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cmbCategoryFilter
            // 
            cmbCategoryFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoryFilter.FormattingEnabled = true;
            cmbCategoryFilter.Items.AddRange(new object[] { "All Categories", "Camera", "Lens", "Lighting", "Drone" });
            cmbCategoryFilter.Location = new Point(750, 31);
            cmbCategoryFilter.Name = "cmbCategoryFilter";
            cmbCategoryFilter.Size = new Size(121, 23);
            cmbCategoryFilter.TabIndex = 3;
            cmbCategoryFilter.SelectedIndexChanged += cmbCategoryFilter_SelectedIndexChanged;
            // 
            // btnResetFilter
            // 
            btnResetFilter.Location = new Point(877, 31);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(75, 23);
            btnResetFilter.TabIndex = 4;
            btnResetFilter.Text = "Reset";
            btnResetFilter.UseVisualStyleBackColor = true;
            btnResetFilter.Click += btnResetFilter_Click_1;
            // 
            // dgvEquipment
            // 
            dgvEquipment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEquipment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipment.Location = new Point(2, 77);
            dgvEquipment.MultiSelect = false;
            dgvEquipment.Name = "dgvEquipment";
            dgvEquipment.ReadOnly = true;
            dgvEquipment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEquipment.Size = new Size(742, 481);
            dgvEquipment.TabIndex = 5;
            dgvEquipment.SelectionChanged += dgvEquipment_SelectionChanged_1;
            // 
            // lblSelectedGear
            // 
            lblSelectedGear.Location = new Point(758, 201);
            lblSelectedGear.Name = "lblSelectedGear";
            lblSelectedGear.Size = new Size(263, 15);
            lblSelectedGear.TabIndex = 6;
            lblSelectedGear.Text = "Selected Gear: None";
            lblSelectedGear.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(833, 234);
            dtpStartDate.MinDate = new DateTime(2026, 10, 2, 0, 0, 0, 0);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(133, 23);
            dtpStartDate.TabIndex = 7;
            dtpStartDate.Value = new DateTime(2026, 10, 2, 21, 56, 1, 0);
            dtpStartDate.ValueChanged += dtpStartDate_ValueChanged;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(833, 265);
            dtpEndDate.MinDate = new DateTime(2026, 10, 2, 0, 0, 0, 0);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(133, 23);
            dtpEndDate.TabIndex = 8;
            dtpEndDate.ValueChanged += dtpEndDate_ValueChanged;
            // 
            // lblTotalSummary
            // 
            lblTotalSummary.Location = new Point(758, 309);
            lblTotalSummary.Name = "lblTotalSummary";
            lblTotalSummary.Size = new Size(263, 15);
            lblTotalSummary.TabIndex = 9;
            lblTotalSummary.Text = "Duration: 0 days | Total: $0.00";
            lblTotalSummary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBookGear
            // 
            btnBookGear.BackColor = Color.FromArgb(230, 126, 34);
            btnBookGear.FlatStyle = FlatStyle.Flat;
            btnBookGear.ForeColor = Color.WhiteSmoke;
            btnBookGear.Location = new Point(833, 350);
            btnBookGear.Name = "btnBookGear";
            btnBookGear.Size = new Size(122, 23);
            btnBookGear.TabIndex = 10;
            btnBookGear.Text = "REQUEST BOOKING";
            btnBookGear.UseVisualStyleBackColor = false;
            btnBookGear.Click += btnBookGear_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(758, 240);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 11;
            label1.Text = "Start Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(758, 271);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 12;
            label2.Text = "Return Date:";
            // 
            // toolStripMain
            // 
            toolStripMain.Items.AddRange(new ToolStripItem[] { tslblUser, toolStripSeparator1, tsbtnRentals, tsbtnAddGear, toolStripSeparator2, tsbtnLogout });
            toolStripMain.Location = new Point(0, 0);
            toolStripMain.Name = "toolStripMain";
            toolStripMain.Size = new Size(1033, 25);
            toolStripMain.TabIndex = 13;
            toolStripMain.Text = "toolStrip1";
            // 
            // tslblUser
            // 
            tslblUser.Name = "tslblUser";
            tslblUser.Size = new Size(118, 22);
            tslblUser.Text = "User: [Name] ([Role])";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // tsbtnRentals
            // 
            tsbtnRentals.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbtnRentals.ImageTransparentColor = Color.Magenta;
            tsbtnRentals.Name = "tsbtnRentals";
            tsbtnRentals.Size = new Size(187, 22);
            tsbtnRentals.Text = "📋 Manage Bookings and Returns";
            tsbtnRentals.Click += tsbtnRentals_Click_1;
            // 
            // tsbtnAddGear
            // 
            tsbtnAddGear.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbtnAddGear.Image = (Image)resources.GetObject("tsbtnAddGear.Image");
            tsbtnAddGear.ImageTransparentColor = Color.Magenta;
            tsbtnAddGear.Name = "tsbtnAddGear";
            tsbtnAddGear.Size = new Size(109, 22);
            tsbtnAddGear.Text = "➕ Add Equipment";
            tsbtnAddGear.Click += tsbtnAddGear_Click_1;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // tsbtnLogout
            // 
            tsbtnLogout.Alignment = ToolStripItemAlignment.Right;
            tsbtnLogout.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbtnLogout.Image = (Image)resources.GetObject("tsbtnLogout.Image");
            tsbtnLogout.ImageTransparentColor = Color.Magenta;
            tsbtnLogout.Name = "tsbtnLogout";
            tsbtnLogout.Size = new Size(69, 22);
            tsbtnLogout.Text = "🚪 Log Out";
            tsbtnLogout.Click += tsbtnLogout_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(572, 35);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 14;
            label3.Text = "Search:";
            // 
            // MainDashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1033, 561);
            Controls.Add(label3);
            Controls.Add(toolStripMain);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnBookGear);
            Controls.Add(lblTotalSummary);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(lblSelectedGear);
            Controls.Add(dgvEquipment);
            Controls.Add(btnResetFilter);
            Controls.Add(cmbCategoryFilter);
            Controls.Add(txtSearch);
            Controls.Add(lblUserGreeting);
            Name = "MainDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Digital Shutter Rentals - Catalog & Booking";
            ((System.ComponentModel.ISupportInitialize)dgvEquipment).EndInit();
            toolStripMain.ResumeLayout(false);
            toolStripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUserGreeting;
        private TextBox txtSearch;
        private ComboBox cmbCategoryFilter;
        private Button btnResetFilter;
        private DataGridView dgvEquipment;
        private Label lblSelectedGear;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label lblTotalSummary;
        private Button btnBookGear;
        private Label label1;
        private Label label2;
        private ToolStrip toolStripMain;
        private ToolStripLabel tslblUser;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbtnRentals;
        private ToolStripButton tsbtnAddGear;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbtnLogout;
        private Label label3;
    }
}