using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace CarRental
{
    public partial class CreateCarRentalForm : Form
    {
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CARRENTALDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";

        // Service costs per day
        private const decimal INSURANCE_COST = 20m;
        private const decimal ROADSIDE_COST = 12m;
        private const decimal WIFI_COST = 8m;
        private const decimal MILEAGE_COST = 15m;
        private const decimal DRIVER_COST = 10m;

        private decimal selectedCarDailyRate = 0m;
        private int selectedCarID = 0;

        public CreateCarRentalForm()
        {
            InitializeComponent();
        }

        private void CreateCarRentalForm_Load(object sender, EventArgs e)
        {
            // Set minimum dates to today
            dtpStartDate.MinDate = DateTime.Today;
            dtpEndDate.MinDate = DateTime.Today;

            // Set default dates
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddDays(1);

            // Load available cars and customers
            LoadAvailableCars();
            LoadCustomers();

            // Calculate initial rental days
            CalculateRentalDays();
        }

        private void LoadAvailableCars()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Get only cars that are NOT rented and not archived
                    string query = @"SELECT CarID, PlateNumber, CarMaker, CarModel, CarYear, 
                                   FuelType, Seats, Transmission, DailyRentalPrice, Status 
                                   FROM Cars 
                                   WHERE IsArchived = 0 
                                   AND (Status != 'Rented' OR Status IS NULL)
                                   ORDER BY PlateNumber";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            cmbPlateNumber.DisplayMember = "PlateNumber";
                            cmbPlateNumber.ValueMember = "CarID";
                            cmbPlateNumber.DataSource = dt;
                        }
                    }
                }

                if (cmbPlateNumber.Items.Count == 0)
                {
                    MessageBox.Show("No available cars found. All cars are currently rented or archived.",
                        "No Available Cars", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cars: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT CustomerID, FirstName, LastName, 
                                   (FirstName + ' ' + LastName) AS FullName 
                                   FROM Customers 
                                   WHERE IsActive = 1
                                   ORDER BY FirstName, LastName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            cmbCustomer.DisplayMember = "FullName";
                            cmbCustomer.ValueMember = "CustomerID";
                            cmbCustomer.DataSource = dt;
                        }
                    }
                }

                if (cmbCustomer.Items.Count == 0)
                {
                    MessageBox.Show("No customers found. Please add customers first.",
                        "No Customers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPlateNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlateNumber.SelectedValue != null && cmbPlateNumber.SelectedValue is int)
            {
                selectedCarID = (int)cmbPlateNumber.SelectedValue;
                LoadCarDetails(selectedCarID);
            }
        }

        private void LoadCarDetails(int carID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT CarMaker, CarModel, CarYear, FuelType, 
                                   Seats, Transmission, DailyRentalPrice 
                                   FROM Cars WHERE CarID = @CarID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CarID", carID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                selectedCarDailyRate = Convert.ToDecimal(reader["DailyRentalPrice"]);

                                string carInfo = string.Format(
                                    "Car: {0} {1} ({2}) | Fuel: {3} | Seats: {4} | Transmission: {5} | Daily Rate: ${6:N2}",
                                    reader["CarMaker"],
                                    reader["CarModel"],
                                    reader["CarYear"],
                                    reader["FuelType"],
                                    reader["Seats"],
                                    reader["Transmission"],
                                    selectedCarDailyRate
                                );

                                lblCarInfo.Text = carInfo;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading car details: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            // Ensure end date is not before start date
            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                dtpEndDate.Value = dtpStartDate.Value.AddDays(1);
            }

            dtpEndDate.MinDate = dtpStartDate.Value.AddDays(1);
            CalculateRentalDays();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateRentalDays();
        }

        private void CalculateRentalDays()
        {
            TimeSpan difference = dtpEndDate.Value.Date - dtpStartDate.Value.Date;
            int days = difference.Days;

            if (days < 0) days = 0;

            txtRentalDays.Text = days.ToString();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateTotalCost();
        }

        private void CalculateTotalCost()
        {
            if (selectedCarDailyRate == 0)
            {
                MessageBox.Show("Please select a car first.", "No Car Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rentalDays = int.Parse(txtRentalDays.Text);

            if (rentalDays <= 0)
            {
                MessageBox.Show("Rental period must be at least 1 day.", "Invalid Period",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calculate base rental cost
            decimal baseRentalCost = selectedCarDailyRate * rentalDays;

            // Calculate additional services cost
            decimal servicesCost = 0m;

            if (chkAdditionalInsurance.Checked)
                servicesCost += INSURANCE_COST * rentalDays;

            if (chkRoadsideAssistance.Checked)
                servicesCost += ROADSIDE_COST * rentalDays;

            if (chkWifiHotspot.Checked)
                servicesCost += WIFI_COST * rentalDays;

            if (chkExtendedMileage.Checked)
                servicesCost += MILEAGE_COST * rentalDays;

            if (chkExtraDriver.Checked)
                servicesCost += DRIVER_COST * rentalDays;

            // Calculate total
            decimal totalCost = baseRentalCost + servicesCost;

            // Display results
            lblDailyRateAmount.Text = string.Format("${0:N2} x {1} days = ${2:N2}",
                selectedCarDailyRate, rentalDays, baseRentalCost);
            lblServiceCostAmount.Text = string.Format("${0:N2}", servicesCost);
            lblTotalAmount.Text = string.Format("${0:N2}", totalCost);
        }

        private void btnSaveRental_Click(object sender, EventArgs e)
        {
            // Validate all fields
            if (!ValidateFields())
                return;

            // Calculate cost first
            CalculateTotalCost();

            try
            {
                int rentalDays = int.Parse(txtRentalDays.Text);
                decimal servicesCost = decimal.Parse(lblServiceCostAmount.Text.Replace("$", "").Replace(",", ""));
                decimal totalCost = decimal.Parse(lblTotalAmount.Text.Replace("$", "").Replace(",", ""));
                int newRentalID = 0;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO Rentals 
                                   (CarID, CustomerID, PlateNumber, CustomerFullName, 
                                    StartDate, EndDate, RentalDays, 
                                    AdditionalInsurance, RoadsideAssistance, WifiHotspot, 
                                    ExtendedMileage, ExtraDriver, 
                                    DailyRate, AdditionalServicesCost, TotalCost, RentalStatus) 
                                   VALUES 
                                   (@CarID, @CustomerID, @PlateNumber, @CustomerFullName, 
                                    @StartDate, @EndDate, @RentalDays, 
                                    @AdditionalInsurance, @RoadsideAssistance, @WifiHotspot, 
                                    @ExtendedMileage, @ExtraDriver, 
                                    @DailyRate, @AdditionalServicesCost, @TotalCost, 'Active');
                                   SELECT CAST(SCOPE_IDENTITY() AS INT)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CarID", selectedCarID);
                        cmd.Parameters.AddWithValue("@CustomerID", cmbCustomer.SelectedValue);
                        cmd.Parameters.AddWithValue("@PlateNumber", cmbPlateNumber.Text);
                        cmd.Parameters.AddWithValue("@CustomerFullName", cmbCustomer.Text);
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date);
                        cmd.Parameters.AddWithValue("@RentalDays", rentalDays);
                        cmd.Parameters.AddWithValue("@AdditionalInsurance", chkAdditionalInsurance.Checked);
                        cmd.Parameters.AddWithValue("@RoadsideAssistance", chkRoadsideAssistance.Checked);
                        cmd.Parameters.AddWithValue("@WifiHotspot", chkWifiHotspot.Checked);
                        cmd.Parameters.AddWithValue("@ExtendedMileage", chkExtendedMileage.Checked);
                        cmd.Parameters.AddWithValue("@ExtraDriver", chkExtraDriver.Checked);
                        cmd.Parameters.AddWithValue("@DailyRate", selectedCarDailyRate);
                        cmd.Parameters.AddWithValue("@AdditionalServicesCost", servicesCost);
                        cmd.Parameters.AddWithValue("@TotalCost", totalCost);

                        // Get the newly created RentalID
                        newRentalID = (int)cmd.ExecuteScalar();
                    }

                    // Update car status to Rented
                    string updateQuery = "UPDATE Cars SET Status = 'Rented' WHERE CarID = @CarID";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@CarID", selectedCarID);
                        updateCmd.ExecuteNonQuery();
                    }
                }

                string successMessage = string.Format(
                    "Rental created successfully!\n\n" +
                    "Rental ID: {0}\n" +
                    "Customer: {1}\n" +
                    "Car: {2}\n" +
                    "Period: {3} days ({4:dd/MM/yyyy} - {5:dd/MM/yyyy})\n" +
                    "Total Cost: ${6:N2}\n\n" +
                    "Proceeding to Payment...",
                    newRentalID,
                    cmbCustomer.Text,
                    cmbPlateNumber.Text,
                    rentalDays,
                    dtpStartDate.Value,
                    dtpEndDate.Value,
                    totalCost);

                MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Navigate to Payment form
                NavigateToPayment(newRentalID, totalCost, cmbCustomer.Text, cmbPlateNumber.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving rental: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NavigateToPayment(int rentalID, decimal totalAmount, string customerName, string plateNumber)
        {
            try
            {
                // Check if form is embedded in a panel (Staff Dashboard)
                if (this.Parent != null && this.Parent is Panel)
                {
                    Panel parentPanel = (Panel)this.Parent;

                    // Clear current form from panel
                    parentPanel.Controls.Clear();

                    // Create payment form with rental details
                    PaymentListForm paymentForm = new PaymentListForm(rentalID, totalAmount, customerName, plateNumber);
                    paymentForm.TopLevel = false;
                    paymentForm.FormBorderStyle = FormBorderStyle.None;
                    paymentForm.Dock = DockStyle.Fill;
                    parentPanel.Controls.Add(paymentForm);
                    paymentForm.Show();
                }
                else
                {
                    // If standalone, open as dialog
                    PaymentListForm paymentForm = new PaymentListForm(rentalID, totalAmount, customerName, plateNumber);
                    paymentForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error navigating to payment: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateFields()
        {
            if (cmbPlateNumber.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a car.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPlateNumber.Focus();
                return false;
            }

            if (cmbCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a customer.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCustomer.Focus();
                return false;
            }

            int rentalDays = int.Parse(txtRentalDays.Text);
            if (rentalDays <= 0)
            {
                MessageBox.Show("Rental period must be at least 1 day.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndDate.Focus();
                return false;
            }

            if (dtpStartDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Start date cannot be in the past.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpStartDate.Focus();
                return false;
            }

            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear the form?",
                "Clear Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ClearForm();
            }
        }

        private void ClearForm()
        {
            cmbPlateNumber.SelectedIndex = -1;
            cmbCustomer.SelectedIndex = -1;
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddDays(1);
            txtRentalDays.Text = "1";

            chkAdditionalInsurance.Checked = false;
            chkRoadsideAssistance.Checked = false;
            chkWifiHotspot.Checked = false;
            chkExtendedMileage.Checked = false;
            chkExtraDriver.Checked = false;

            lblDailyRateAmount.Text = "$0.00";
            lblServiceCostAmount.Text = "$0.00";
            lblTotalAmount.Text = "$0.00";
            lblCarInfo.Text = "Select a car to see details...";

            selectedCarDailyRate = 0m;
            selectedCarID = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Check if form is embedded in a panel
            if (this.Parent != null)
            {
                // Clear the panel to go back to dashboard
                this.Parent.Controls.Clear();
            }
            else
            {
                // Close the form if opened as standalone
                this.Close();
            }
        }
    }
}