using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DigitalShutterRentals
{
    public partial class EditGearForm : Form
    {
        private Equipment gear;
        public EditGearForm(Equipment gearToEdit)
        {
            if (gearToEdit is null) throw new ArgumentNullException(nameof(gearToEdit));
            InitializeComponent();
            this.gear = gearToEdit;

            lblGearId.Text = $"Editing Gear ID: {gear.Id ?? string.Empty}";
            txtModelName.Text = gear.ModelName ?? string.Empty;
            cmbGearCategory.SelectedItem = gear.Category ?? string.Empty;
            numDailyRate.Value = gear.DailyRate;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newName = txtModelName.Text.Trim();
            decimal newRate = numDailyRate.Value;

            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Model Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newName.Contains(","))
            {
                MessageBox.Show("Model Name cannot contain commas.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newRate <= 0)
            {
                MessageBox.Show("Daily rate must be greater than $0.00.", "Invalid Rate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbGearCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a gear category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Apply updates to the equipment object
            gear.ModelName = newName;
            gear.Category = cmbGearCategory.SelectedItem.ToString() ?? string.Empty;
            gear.DailyRate = newRate;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
