using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace DigitalShutterRentals
{
    public partial class MainDashboardForm : Form
    {
        private User loggedInUser;
        private List<Equipment> equipmentInventory = new List<Equipment>();
        private const string EquipmentFilePath = "equipment.txt";
        private Equipment? selectedGear = null;
        private const string BookingsFilePath = "rentals.txt";

        public MainDashboardForm(User user)
        {
            InitializeComponent();
            this.loggedInUser = user;

            // displays the user logged in
            tslblUser.Text = $"👤 Logged in: {loggedInUser.Username} ({loggedInUser.Role})";
            tsbtnAddGear.Visible = (loggedInUser.Role == "Admin");

            LoadEquipmentFromFile();
            DisplayGear();
            cmbCategoryFilter.SelectedIndex = 0;

            dtpStartDate.MinDate = DateTime.Today;
            dtpEndDate.MinDate = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddDays(1);

        }

        private void tsbtnLogout_Click_1(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void LoadEquipmentFromFile()
        {
            equipmentInventory.Clear();

            if (!File.Exists(EquipmentFilePath))
            {
                string[] defaultGear = new[]
                {
            "EQ101,Sony A7 IV Mirrorless Body,Camera,75.00,admin,True",
            "EQ102,Canon EOS R5 8K Cinema,Camera,110.00,admin,True",
            "EQ103,Sony FE 24-70mm f/2.8 GM II,Lens,45.00,admin,True",
            "EQ104,Canon RF 70-200mm f/2.8L,Lens,50.00,admin,True",
            "EQ105,Aputure 300d II LED Light,Lighting,40.00,admin,True",
            "EQ106,DJI Mavic 3 Cine Drone,Drone,120.00,admin,False"
        };
                File.WriteAllLines(EquipmentFilePath, defaultGear);
            }

            foreach (string line in File.ReadAllLines(EquipmentFilePath))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(',');
                if (parts.Length == 6)
                {
                    equipmentInventory.Add(new Equipment(
                        parts[0].Trim(),
                        parts[1].Trim(),
                        parts[2].Trim(),
                        decimal.Parse(parts[3].Trim()),
                        parts[4].Trim(),
                        bool.Parse(parts[5].Trim())
                    ));
                }
            }
        }

        private void DisplayGear()
        {
            dgvEquipment.DataSource = null;
            dgvEquipment.DataSource = equipmentInventory;
        }

        private void FilterGear()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            string selectedCategory = cmbCategoryFilter.SelectedItem?.ToString() ?? "All Categories";

            List<Equipment> filtered = new List<Equipment>();

            foreach (var item in equipmentInventory)
            {
                bool matchesKeyword = string.IsNullOrWhiteSpace(keyword) || item.ModelName.ToLower().Contains(keyword);
                bool matchesCategory = (selectedCategory == "All Categories") || (item.Category == selectedCategory);

                if (matchesKeyword && matchesCategory)
                {
                    filtered.Add(item);
                }
            }

            dgvEquipment.DataSource = null;
            dgvEquipment.DataSource = filtered;
        }

        private void CalculateTotal()
        {
            if (selectedGear == null) return;

            DateTime start = dtpStartDate.Value.Date;
            DateTime end = dtpEndDate.Value.Date;

            if (end <= start)
            {
                lblTotalSummary.Text = "Return date must be after pickup date.";
                return;
            }

            int days = (end - start).Days;
            decimal total = days * selectedGear.DailyRate;

            lblTotalSummary.Text = $"Duration: {days} day(s) | Total: ${total:N2}";
        }

        private void dgvEquipment_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvEquipment.SelectedRows.Count > 0)
            {
                selectedGear = dgvEquipment.SelectedRows[0].DataBoundItem as Equipment;
                if (selectedGear != null)
                {
                    lblSelectedGear.Text = $"Selected: {selectedGear.ModelName} (${selectedGear.DailyRate:F2}/day)";
                    CalculateTotal();
                }
                else
                {
                    lblSelectedGear.Text = "Selected: None";
                }
            }
            else
            {
                selectedGear = null;
                lblSelectedGear.Text = "Selected: None";
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void btnBookGear_Click_1(object sender, EventArgs e)
        {
            if (selectedGear == null)
            {
                MessageBox.Show("Please select an item from the table first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!selectedGear.IsAvailable)
            {
                MessageBox.Show("This gear is currently rented out and unavailable.", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime start = dtpStartDate.Value.Date;
            DateTime end = dtpEndDate.Value.Date;

            if (end <= start)
            {
                MessageBox.Show("Return date must be after pickup date.", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int days = (end - start).Days;
            decimal totalCost = days * selectedGear.DailyRate;

            string confirmMsg = $"Confirm rental for {selectedGear.ModelName}?\n\n" +
                               $"Duration: {days} day(s)\n" +
                               $"Total Cost: ${totalCost:N2}";

            if (MessageBox.Show(confirmMsg, "Confirm Booking", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // mark as rented
                selectedGear.IsAvailable = false;

                // append booking to rentals.txt
                string bookingId = Guid.NewGuid().ToString().Substring(0, 8);
                string bookingRecord = $"{bookingId},{selectedGear.Id},{selectedGear.ModelName},{loggedInUser.Username},{start:yyyy-MM-dd},{end:yyyy-MM-dd},{totalCost},Active{Environment.NewLine}";
                File.AppendAllText(BookingsFilePath, bookingRecord);

                // save updated status back to equipment.txt
                List<string> lines = new List<string>();
                foreach (var item in equipmentInventory)
                {
                    lines.Add(item.ToCsvLine());
                }
                File.WriteAllLines(EquipmentFilePath, lines);

                MessageBox.Show("Booking confirmed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DisplayGear();
            }
        }

        private void tsbtnAddGear_Click_1(object sender, EventArgs e)
        {

        }

        private void tsbtnRentals_Click_1(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterGear();
        }

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterGear();
        }
        private void btnResetFilter_Click_1(object sender, EventArgs e)
        {
            // reset the search and category filter
            txtSearch.Clear();
            cmbCategoryFilter.SelectedIndex = 0;
            DisplayGear();
        }
    }
}