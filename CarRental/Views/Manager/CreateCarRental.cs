using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            dtpStartDate.MinDate = DateTime.Today;
            dtpEndDate.MinDate = DateTime.Today;
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddDays(1);

            LoadAvailableCars();
            LoadCustomers();
            CalculateRentalDays();
        }

        private void LoadAvailableCars()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT CarID, PlateNumber, CarMaker, CarModel, CarYear, 
                                   FuelType, Seats, Transmission, DailyRentalPrice, Status 
                                   FROM Cars 
                                   WHERE IsArchived = 0 
                                   AND Status = 'Available'
                                   ORDER BY PlateNumber";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        cmbPlateNumber.DisplayMember = "PlateNumber";
                        cmbPlateNumber.ValueMember = "CarID";
                        cmbPlateNumber.DataSource = dt;
                    }
                }

                if (cmbPlateNumber.Items.Count == 0)
                {
                    MessageBox.Show(
                        "No available cars found.\nAll cars are currently rented, under maintenance, or archived.",
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
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        cmbCustomer.DisplayMember = "FullName";
                        cmbCustomer.ValueMember = "CustomerID";
                        cmbCustomer.DataSource = dt;
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
                                   Seats, Transmission, DailyRentalPrice, Status
                                   FROM Cars WHERE CarID = @CarID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CarID", carID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string status = reader["Status"].ToString();
                                if (status != "Available")
                                {
                                    MessageBox.Show(
                                        $"This car is currently unavailable.\nStatus: {status}\n\nPlease select a different car.",
                                        "Car Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    cmbPlateNumber.SelectedIndex = -1;
                                    lblCarInfo.Text = "Select a car to see details...";
                                    selectedCarDailyRate = 0m;
                                    selectedCarID = 0;
                                    return;
                                }

                                selectedCarDailyRate = Convert.ToDecimal(reader["DailyRentalPrice"]);
                                lblCarInfo.Text = string.Format(
                                    "Car: {0} {1} ({2}) | Fuel: {3} | Seats: {4} | Transmission: {5} | Daily Rate: ${6:N2}",
                                    reader["CarMaker"], reader["CarModel"], reader["CarYear"],
                                    reader["FuelType"], reader["Seats"], reader["Transmission"],
                                    selectedCarDailyRate);
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
            if (dtpEndDate.Value < dtpStartDate.Value)
                dtpEndDate.Value = dtpStartDate.Value.AddDays(1);
            dtpEndDate.MinDate = dtpStartDate.Value.AddDays(1);
            CalculateRentalDays();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateRentalDays();
        }

        private void CalculateRentalDays()
        {
            int days = (dtpEndDate.Value.Date - dtpStartDate.Value.Date).Days;
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

            decimal baseRentalCost = selectedCarDailyRate * rentalDays;

            // ── CHANGED: Services are now PENDING approval, so we show them
            //    as "pending" in the breakdown but do NOT add them to total yet.
            decimal pendingServicesCost = 0m;
            if (chkAdditionalInsurance.Checked) pendingServicesCost += INSURANCE_COST * rentalDays;
            if (chkRoadsideAssistance.Checked) pendingServicesCost += ROADSIDE_COST * rentalDays;
            if (chkWifiHotspot.Checked) pendingServicesCost += WIFI_COST * rentalDays;
            if (chkExtendedMileage.Checked) pendingServicesCost += MILEAGE_COST * rentalDays;
            if (chkExtraDriver.Checked) pendingServicesCost += DRIVER_COST * rentalDays;

            // Total for now = base only (services added after admin approval)
            decimal totalCost = baseRentalCost;

            lblDailyRateAmount.Text = $"${selectedCarDailyRate:N2} x {rentalDays} days = ${baseRentalCost:N2}";

            // Show pending services cost with a note
            lblServiceCostAmount.Text = pendingServicesCost > 0
                ? $"${pendingServicesCost:N2} (Pending Admin Approval)"
                : "$0.00";

            lblTotalAmount.Text = $"${totalCost:N2}";
        }

        private void btnSaveRental_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            // Final safety check — re-verify car is still Available
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT Status FROM Cars WHERE CarID = @CarID", conn))
                    {
                        cmd.Parameters.AddWithValue("@CarID", selectedCarID);
                        string currentStatus = cmd.ExecuteScalar()?.ToString();
                        if (currentStatus != "Available")
                        {
                            MessageBox.Show(
                                $"This car is no longer available.\nCurrent status: {currentStatus}\n\nPlease select a different car.",
                                "Car Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            LoadAvailableCars();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error verifying car status: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CalculateTotalCost();

            try
            {
                int rentalDays = int.Parse(txtRentalDays.Text);

                // Base cost only — services are pending
                decimal baseRentalCost = selectedCarDailyRate * rentalDays;
                decimal totalCost = baseRentalCost; // Services NOT included yet
                int newRentalID = 0;

                // Build list of selected services for ServiceApprovals insert
                var selectedServices = new List<(string Name, decimal DailyRate)>();
                if (chkAdditionalInsurance.Checked) selectedServices.Add(("Additional Insurance", INSURANCE_COST));
                if (chkRoadsideAssistance.Checked) selectedServices.Add(("Roadside Assistance", ROADSIDE_COST));
                if (chkWifiHotspot.Checked) selectedServices.Add(("WiFi Hotspot", WIFI_COST));
                if (chkExtendedMileage.Checked) selectedServices.Add(("Extended Mileage", MILEAGE_COST));
                if (chkExtraDriver.Checked) selectedServices.Add(("Extra Driver", DRIVER_COST));

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // ── 1. Insert Rental (AdditionalServicesCost = 0 until approved) ──
                            string insertRental = @"
                                INSERT INTO Rentals 
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
                                 @DailyRate, 0, @TotalCost, 'Active');
                                SELECT CAST(SCOPE_IDENTITY() AS INT)";

                            using (SqlCommand cmd = new SqlCommand(insertRental, conn, transaction))
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
                                cmd.Parameters.AddWithValue("@TotalCost", totalCost);
                                newRentalID = (int)cmd.ExecuteScalar();
                            }

                            // ── 2. Update car status to Rented ──
                            using (SqlCommand updateCmd = new SqlCommand(
                                "UPDATE Cars SET Status = 'Rented' WHERE CarID = @CarID", conn, transaction))
                            {
                                updateCmd.Parameters.AddWithValue("@CarID", selectedCarID);
                                updateCmd.ExecuteNonQuery();
                            }

                            // ── 3. Insert each selected service into ServiceApprovals as Pending ──
                            if (selectedServices.Count > 0)
                            {
                                string insertService = @"
                                    INSERT INTO ServiceApprovals 
                                    (RentalID, ServiceName, DailyRate, RentalDays, TotalServiceCost, Status)
                                    VALUES (@RentalID, @ServiceName, @DailyRate, @RentalDays, @TotalServiceCost, 'Pending')";

                                foreach (var svc in selectedServices)
                                {
                                    using (SqlCommand svcCmd = new SqlCommand(insertService, conn, transaction))
                                    {
                                        svcCmd.Parameters.AddWithValue("@RentalID", newRentalID);
                                        svcCmd.Parameters.AddWithValue("@ServiceName", svc.Name);
                                        svcCmd.Parameters.AddWithValue("@DailyRate", svc.DailyRate);
                                        svcCmd.Parameters.AddWithValue("@RentalDays", rentalDays);
                                        svcCmd.Parameters.AddWithValue("@TotalServiceCost", svc.DailyRate * rentalDays);
                                        svcCmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }

                // Build service summary message
                string serviceNote = selectedServices.Count > 0
                    ? $"\n\n⚠ {selectedServices.Count} additional service(s) sent for Admin Approval:\n" +
                      string.Join("\n", selectedServices.ConvertAll(s => $"  • {s.Name} (+${s.DailyRate:N2}/day)")) +
                      "\n\nThese will be added to the total once approved."
                    : "";

                MessageBox.Show(
                    $"Rental created successfully!\n\n" +
                    $"Rental ID: {newRentalID}\n" +
                    $"Customer: {cmbCustomer.Text}\n" +
                    $"Car: {cmbPlateNumber.Text}\n" +
                    $"Period: {rentalDays} days ({dtpStartDate.Value:dd/MM/yyyy} - {dtpEndDate.Value:dd/MM/yyyy})\n" +
                    $"Base Cost: ${totalCost:N2}" +
                    $"{serviceNote}\n\n" +
                    $"Proceeding to Payment...",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                if (this.Parent != null && this.Parent is Panel parentPanel)
                {
                    parentPanel.Controls.Clear();
                    PaymentListForm paymentForm = new PaymentListForm(rentalID, totalAmount, customerName, plateNumber);
                    paymentForm.TopLevel = false;
                    paymentForm.FormBorderStyle = FormBorderStyle.None;
                    paymentForm.Dock = DockStyle.Fill;
                    parentPanel.Controls.Add(paymentForm);
                    paymentForm.Show();
                }
                else
                {
                    new PaymentListForm(rentalID, totalAmount, customerName, plateNumber).ShowDialog();
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

            if (int.Parse(txtRentalDays.Text) <= 0)
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
            if (MessageBox.Show("Are you sure you want to clear the form?",
                "Clear Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                ClearForm();
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
            if (this.Parent != null)
                this.Parent.Controls.Clear();
            else
                this.Close();
        }
    }
}