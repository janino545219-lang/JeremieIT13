using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace CarRental
{
    public partial class AddCarForm : Form
    {
        // Connection string - UPDATE THIS with your actual connection string
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CARRENTALDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public AddCarForm()
        {
            InitializeComponent();
        }

        private void AddCarForm_Load(object sender, EventArgs e)
        {
            // Set default values
            numCarYear.Value = DateTime.Now.Year;
            cmbFuelType.SelectedIndex = 0; // Default to Gasoline
            cmbTransmission.SelectedIndex = 0; // Default to Automatic
            numSeats.Value = 5;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate all fields
            if (!ValidateFields())
            {
                return;
            }

            try
            {
                // Parse the daily price
                if (!decimal.TryParse(txtDailyPrice.Text, out decimal dailyPrice))
                {
                    MessageBox.Show("Please enter a valid daily rental price.", "Invalid Price",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDailyPrice.Focus();
                    return;
                }

                // Insert car into database with 'Pending' status
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO Cars (PlateNumber, CarMaker, CarModel, CarYear, 
                                    FuelType, Seats, Transmission, DailyRentalPrice, Status, IsArchived) 
                                    VALUES (@PlateNumber, @CarMaker, @CarModel, @CarYear, 
                                    @FuelType, @Seats, @Transmission, @DailyRentalPrice, 'Pending', 0)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PlateNumber", txtPlateNumber.Text.Trim().ToUpper());
                        cmd.Parameters.AddWithValue("@CarMaker", txtCarMaker.Text.Trim());
                        cmd.Parameters.AddWithValue("@CarModel", txtCarModel.Text.Trim());
                        cmd.Parameters.AddWithValue("@CarYear", (int)numCarYear.Value);
                        cmd.Parameters.AddWithValue("@FuelType", cmbFuelType.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Seats", (int)numSeats.Value);
                        cmd.Parameters.AddWithValue("@Transmission", cmbTransmission.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@DailyRentalPrice", dailyPrice);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Car added successfully!\n\nStatus: Pending (waiting for admin approval)",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the form for next entry
                ClearForm();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Duplicate key error
                {
                    MessageBox.Show("A car with this plate number already exists!", "Duplicate Entry",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPlateNumber.Focus();
                }
                else
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateFields()
        {
            // Validate Plate Number
            if (string.IsNullOrWhiteSpace(txtPlateNumber.Text))
            {
                MessageBox.Show("Please enter the plate number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPlateNumber.Focus();
                return false;
            }

            // Validate Car Maker
            if (string.IsNullOrWhiteSpace(txtCarMaker.Text))
            {
                MessageBox.Show("Please enter the car maker.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCarMaker.Focus();
                return false;
            }

            // Validate Car Model
            if (string.IsNullOrWhiteSpace(txtCarModel.Text))
            {
                MessageBox.Show("Please enter the car model.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCarModel.Focus();
                return false;
            }
                
            // Validate Fuel Type
            if (cmbFuelType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the fuel type.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbFuelType.Focus();
                return false;
            }

            // Validate Transmission
            if (cmbTransmission.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the transmission type.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTransmission.Focus();
                return false;
            }

            // Validate Daily Price
            if (string.IsNullOrWhiteSpace(txtDailyPrice.Text))
            {
                MessageBox.Show("Please enter the daily rental price.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDailyPrice.Focus();
                return false;
            }

            if (!decimal.TryParse(txtDailyPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid positive price.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDailyPrice.Focus();
                return false;
            }

            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear all fields?",
                "Clear Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ClearForm();
            }
        }

        private void ClearForm()
        {
            txtPlateNumber.Clear();
            txtCarMaker.Clear();
            txtCarModel.Clear();
            numCarYear.Value = DateTime.Now.Year;
            cmbFuelType.SelectedIndex = 0;
            numSeats.Value = 5;
            cmbTransmission.SelectedIndex = 0;
            txtDailyPrice.Clear();
            txtPlateNumber.Focus();
        }
    }
}