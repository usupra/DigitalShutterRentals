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
            dgvEquipment.DataError += (s, e) => { e.ThrowException = false; };
            this.loggedInUser = user;

            // displays the user logged in
            tsddbUser.Text = $"👤 Logged in: {loggedInUser.Username} ({loggedInUser.Role})";
            tsbtnAddGear.Visible = (loggedInUser.Role == "Admin");
            tsbtnRemoveGear.Visible = (loggedInUser.Role == "Admin");
            tsbtnEditGear.Visible = (loggedInUser.Role == "Admin");
            toolStripSeparator2.Visible = (loggedInUser.Role == "Admin");

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
            "EQ106,DJI Mavic 3 Cine Drone,Drone,120.00,admin,True"
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
            dgvEquipment.DataSource = equipmentInventory.ToList();
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

        private void SaveInventoryToFile()
        {
            List<string> lines = new List<string>();
            foreach (var item in equipmentInventory)
            {
                lines.Add(item.ToCsvLine());
            }
            File.WriteAllLines(EquipmentFilePath, lines);
        }

        private void tsbtnAddGear_Click_1(object sender, EventArgs e)
        {
            AddGearForm addForm = new AddGearForm(loggedInUser.Username);

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // If an item was added, reload from file and refresh the grid immediately
                LoadEquipmentFromFile();
                DisplayGear();
            }
        }

        private void tsbtnRemoveGear_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (selectedGear == null)
            {
                MessageBox.Show("Please select an equipment item from the table to remove.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Do not allow deleting rented gear
            if (!selectedGear.IsAvailable)
            {
                MessageBox.Show($"Cannot remove '{selectedGear.ModelName}' because it is currently rented out!\n" +
                                "Wait until the renter returns the item before deleting it.",
                                "Action Blocked", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string confirmMsg = $"Are you sure you want to permanently delete:\n\n" +
                                $"ID: {selectedGear.Id}\n" +
                                $"Model: {selectedGear.ModelName}?\n\n" +
                                "This will remove it from the catalog.";

            DialogResult result = MessageBox.Show(confirmMsg, "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                equipmentInventory.Remove(selectedGear);

                // Rewrite equipment.txt without the deleted item
                SaveInventoryToFile();

                MessageBox.Show($"'{selectedGear.ModelName}' has been removed from inventory.",
                                "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset selection and refresh table
                selectedGear = null;
                lblSelectedGear.Text = "Selected: None";
                lblTotalSummary.Text = "Duration: 0 days | Total: $0.00";
                btnBookGear.Enabled = false;

                DisplayGear();
            }
        }
        private void tsbtnEditGear_Click(object sender, EventArgs e)
        {

            if (selectedGear == null)
            {
                MessageBox.Show("Please select an equipment item from the table to edit.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string targetId = selectedGear.Id;

            EditGearForm editForm = new EditGearForm(selectedGear);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                string updatedName = selectedGear.ModelName;

                SaveInventoryToFile();

                FilterGear();

                foreach (DataGridViewRow row in dgvEquipment.Rows)
                {
                    var item = row.DataBoundItem as Equipment;
                    if (item != null && item.Id.Equals(targetId, StringComparison.OrdinalIgnoreCase))
                    {
                        row.Selected = true;
                        dgvEquipment.CurrentCell = row.Cells[0];
                        selectedGear = item;
                        lblSelectedGear.Text = $"Selected: {selectedGear.ModelName} (${selectedGear.DailyRate:F2}/day)";
                        CalculateTotal();
                        break;
                    }
                }

                MessageBox.Show($"'{updatedName}' updated successfully!",
                                "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbtnRentals_Click_1(object sender, EventArgs e)
        {
            ManageRentalsForm rentalsForm = new ManageRentalsForm(loggedInUser);
            rentalsForm.ShowDialog();

            LoadEquipmentFromFile();
            DisplayGear();
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

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiDeleteAccount_Click(object sender, EventArgs e)
        {
            const string UsersFilePath = "users.txt";

            // Implement account deletion logic
            if (loggedInUser.Username.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("The primary system administrator account cannot be deleted.",
                                "Protected Account", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Check if user has active rentals in rentals.txt
            if (File.Exists(BookingsFilePath))
            {
                foreach (string line in File.ReadAllLines(BookingsFilePath))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split(',');
                    if (parts.Length >= 8)
                    {
                        string renter = parts[3].Trim();
                        string status = parts[7].Trim();

                        if (renter.Equals(loggedInUser.Username, StringComparison.OrdinalIgnoreCase) &&
                            status.Equals("Active", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("You cannot delete your account while you have active equipment rentals!\n\n" +
                                            "Please return all rented gear before closing your account.",
                                            "Active Rental Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }

            string confirmMsg = $"Are you sure you want to permanently delete your account '{loggedInUser.Username}'?\n\n" +
                                "This action cannot be undone, and you will be logged out immediately.";

            DialogResult result = MessageBox.Show(confirmMsg, "Confirm Account Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Rewrite users.txt without this user
                if (File.Exists(UsersFilePath))
                {
                    string[] lines = File.ReadAllLines(UsersFilePath);
                    List<string> remainingUsers = new List<string>();

                    foreach (string line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        string[] parts = line.Split(',');

                        if (parts.Length >= 1 && parts[0].Trim().Equals(loggedInUser.Username, StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        remainingUsers.Add(line);
                    }

                    File.WriteAllLines(UsersFilePath, remainingUsers);
                }

                MessageBox.Show("Your account has been deleted successfully.", "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Close Dashboard and return to Login Screen
                this.Close();
            }
        }
    }
}