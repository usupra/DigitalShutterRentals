using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DigitalShutterRentals
{
    public partial class ManageRentalsForm : Form
    {
        private const string BookingsFilePath = "rentals.txt";
        private const string EquipmentFilePath = "equipment.txt";
        private User currentUser;

        public class RentalItem
        {
            public string BookingId { get; set; } = string.Empty;
            public string GearId { get; set; } = string.Empty;
            public string GearName { get; set; } = string.Empty;
            public string Renter { get; set; } = string.Empty;
            public string StartDate { get; set; } = string.Empty;
            public string ReturnDate { get; set; } = string.Empty;
            public string TotalCost { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
        }
        private List<RentalItem> rentalRecords = new List<RentalItem>();


        public ManageRentalsForm(User user)
        {
            InitializeComponent();
            this.currentUser = user ?? throw new ArgumentNullException(nameof(user));

            if (cmbCondition != null && cmbCondition.Items.Count > 0)
            {
                cmbCondition.SelectedIndex = 0;
            }

            LoadRentalsFromFile();
        }

        private void LoadRentalsFromFile()
        {
            rentalRecords.Clear();

            if (!File.Exists(BookingsFilePath))
            {
                dgvRentals.DataSource = null;
                return;
            }

            string[] lines = File.ReadAllLines(BookingsFilePath);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(',');
                if (parts.Length >= 8)
                {
                    string renter = parts[3].Trim();
                    string status = parts[7].Trim();

                    // Only show "Active" rentals.
                    // If Renter, only show their rentals.
                    // If Admin, show all rentals.
                    bool canView = (currentUser.Role == "Admin") || (renter.Equals(currentUser.Username, StringComparison.OrdinalIgnoreCase));

                    if (canView && status.Equals("Active", StringComparison.OrdinalIgnoreCase))
                    {
                        rentalRecords.Add(new RentalItem
                        {
                            BookingId = parts[0].Trim(),
                            GearId = parts[1].Trim(),
                            GearName = parts[2].Trim(),
                            Renter = renter,
                            StartDate = parts[4].Trim(),
                            ReturnDate = parts[5].Trim(),
                            TotalCost = parts[6].Trim().StartsWith("$") ? parts[6].Trim() : "$" + parts[6].Trim(),
                            Status = status
                        });
                    }
                }
            }

            dgvRentals.DataSource = null;
            dgvRentals.DataSource = rentalRecords;
        }

        private void btnReturnGear_Click(object sender, EventArgs e)
        {
            if (dgvRentals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an active rental from the table to process return.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RentalItem? selectedBooking = dgvRentals.SelectedRows[0].DataBoundItem as RentalItem;
            if (selectedBooking == null)
            {
                MessageBox.Show("Unable to determine selected booking.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedCondition = cmbCondition?.SelectedItem?.ToString() ?? "Unknown";

            string confirmMsg = $"Process return for {selectedBooking.GearName}?\n\n" +
                               $"Renter: {selectedBooking.Renter}\n" +
                               $"Inspection Condition: {selectedCondition}\n\n" +
                               "This will mark the gear as returned and make it available again.";

            if (MessageBox.Show(confirmMsg, "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Update status in rentals.txt from "Active" to "Returned"
                if (File.Exists(BookingsFilePath))
                {
                    string[] bookingLines = File.ReadAllLines(BookingsFilePath);
                    List<string> updatedBookings = new List<string>();

                    foreach (string line in bookingLines)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            updatedBookings.Add(line);
                            continue;
                        }

                        string[] parts = line.Split(',');

                        if (parts.Length >= 8 && parts[0].Trim() == selectedBooking.BookingId)
                        {
                            // Change "Active" to "Returned"
                            parts[7] = "Returned";
                            updatedBookings.Add(string.Join(",", parts));
                        }
                        else
                        {
                            updatedBookings.Add(line);
                        }
                    }

                    File.WriteAllLines(BookingsFilePath, updatedBookings);
                }

                // Update equipment.txt so IsAvailable becomes "True" again
                if (File.Exists(EquipmentFilePath))
                {
                    string[] gearLines = File.ReadAllLines(EquipmentFilePath);
                    List<string> updatedGear = new List<string>();

                    foreach (string line in gearLines)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            updatedGear.Add(line);
                            continue;
                        }

                        string[] parts = line.Split(',');

                        // Allow lines with at least 1 column; update last column if it refers to the gear id
                        if (parts.Length >= 1 && parts[0].Trim() == selectedBooking.GearId)
                        {
                            // If file uses 6 columns with IsAvailableS at index 5, try to set that;
                            // otherwise set the last column to True.
                            int isAvailableIndex = parts.Length > 5 ? 5 : parts.Length - 1;
                            parts[isAvailableIndex] = "True";
                            updatedGear.Add(string.Join(",", parts));
                        }
                        else
                        {
                            updatedGear.Add(line);
                        }
                    }

                    File.WriteAllLines(EquipmentFilePath, updatedGear);
                }

                MessageBox.Show($"Return and inspection complete!\n'{selectedBooking.GearName}' is now available for rent.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload the active rentals table
                LoadRentalsFromFile();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
