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
    public partial class AddGearForm : Form
    {
        private const string EquipmentFilePath = "equipment.txt";
        private string adminUsername = string.Empty;

        public AddGearForm(string adminUsername)
        {
            InitializeComponent();
            this.adminUsername = adminUsername;

            if (cmbGearCategory.Items.Count > 0)
            {
                cmbGearCategory.SelectedIndex = 0; // defaults to the first category
            }

            numDailyRate.Value = 50.00m; // defaults to 50.00
        }

        private void btnSaveGear_Click(object sender, EventArgs e)
        {
            // Trimming inputs
            string id = txtGearId.Text.Trim().ToUpper();
            string modelName = txtModelName.Text.Trim();

            if (cmbGearCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGearCategory.Focus();
                return;
            }

            string category = cmbGearCategory.SelectedItem?.ToString() ?? string.Empty;
            decimal dailyRate = numDailyRate.Value;

            // Validations
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(modelName))
            {
                MessageBox.Show("Please enter both Gear ID and Equipment Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id.Contains(",") || modelName.Contains(","))
            {
                MessageBox.Show("Gear ID and Name cannot contain commas.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dailyRate <= 0)
            {
                MessageBox.Show("Daily rate must be greater than $0.00.", "Invalid Rate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // check if Gear ID already exists in equipment.txt
            if (File.Exists(EquipmentFilePath))
            {
                foreach (string line in File.ReadAllLines(EquipmentFilePath))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split(',');
                    if (parts.Length > 0 && parts[0].Trim().Equals(id, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show($"Gear ID '{id}' already exists. Please use a unique ID.", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtGearId.Focus();
                        return;
                    }
                }
            }

            // append new equipment to equipment.txt (Status is True = Available)
            try
            {
                Equipment newGear = new Equipment(id, modelName, category, dailyRate, adminUsername, true);
                File.AppendAllText(EquipmentFilePath, newGear.ToCsvLine() + Environment.NewLine);

                MessageBox.Show($"'{modelName}' successfully added to inventory!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK; // signals success to the dashboard
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save equipment: {ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
