using System;
using System.Data;
using Microsoft.Data.SqlClient;  // ← Changed from System.Data.SqlClient
using System.Drawing;
using System.Windows.Forms;

namespace CarRental
{
    public partial class ReturnCarForm : Form
    {
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CARRENTALDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        // Damage prices (can be adjusted)
        private const decimal SCRATCH_PRICE = 500.00m;
        private const decimal DENTED_BUMPER_PRICE = 1500.00m;
        private const decimal BROKEN_MIRROR_PRICE = 800.00m;
        private const decimal FLAT_TIRE_PRICE = 600.00m;
        private const decimal WINDSHIELD_CRACK_PRICE = 2000.00m;
        private const decimal BROKEN_HEADLIGHT_PRICE = 700.00m;
        private const decimal BROKEN_TAILLIGHT_PRICE = 600.00m;
        private const decimal STAINED_UPHOLSTERY_PRICE = 1000.00m;
        private const decimal OVERDUE_DAILY_RATE = 200.00m; // Daily penalty for overdue

        public ReturnCarForm()
        {
            InitializeComponent();
        }

        private void ReturnCarForm_Load(object sender, EventArgs e)
        {
            LoadActiveRentals();
            SetupDamageCheckboxes();
            dtpReturnDate.Value = DateTime.Now;
        }

        private void LoadActiveRentals()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT RentalID, 
                                           CAST(RentalID AS NVARCHAR) + ' - ' + CustomerFullName + ' (' + PlateNumber + ')' AS DisplayText
                                    FROM Rentals 
                                    WHERE RentalStatus = 'Active'
                                    ORDER BY RentalID DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbRentalID.DataSource = dt;
                        cmbRentalID.DisplayMember = "DisplayText";
                        cmbRentalID.ValueMember = "RentalID";
                        cmbRentalID.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rentals: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDamageCheckboxes()
        {
            // Hook up event handlers to all damage checkboxes
            chkScratch.CheckedChanged += DamageCheckbox_CheckedChanged;
            chkDentedBumper.CheckedChanged += DamageCheckbox_CheckedChanged;
            chkBrokenMirror.CheckedChanged += DamageCheckbox_CheckedChanged;
            chkFlatTire.CheckedChanged += DamageCheckbox_CheckedChanged;
            chkWindshieldCrack.CheckedChanged += DamageCheckbox_CheckedChanged;
            chkBrokenHeadlight.CheckedChanged += DamageCheckbox_CheckedChanged;
            chkBrokenTaillight.CheckedChanged += DamageCheckbox_CheckedChanged;
            chkStainedUpholstery.CheckedChanged += DamageCheckbox_CheckedChanged;
        }

        private void cmbRentalID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRentalID.SelectedIndex == -1) return;

            try
            {
                DataRowView drv = cmbRentalID.SelectedItem as DataRowView;
                if (drv != null)
                {
                    int rentalID = Convert.ToInt32(drv["RentalID"]);
                    LoadRentalDetails(rentalID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rental details: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRentalDetails(int rentalID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT r.CustomerFullName, r.PlateNumber, r.EndDate, r.DailyRate,
                                           c.CarMaker, c.CarModel, c.CarYear
                                    FROM Rentals r
                                    INNER JOIN Cars c ON r.CarID = c.CarID
                                    WHERE r.RentalID = @RentalID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RentalID", rentalID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtCustomerName.Text = reader["CustomerFullName"].ToString();
                                txtPlateNumber.Text = reader["PlateNumber"].ToString();
                                txtCarRented.Text = $"{reader["CarYear"]} {reader["CarMaker"]} {reader["CarModel"]}";

                                DateTime endDate = Convert.ToDateTime(reader["EndDate"]);
                                DateTime returnDate = dtpReturnDate.Value.Date;

                                CalculateOverdueDays(endDate, returnDate);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            if (cmbRentalID.SelectedIndex != -1)
            {
                int rentalID = Convert.ToInt32(cmbRentalID.SelectedValue);
                LoadRentalDetails(rentalID);
            }
        }

        private void CalculateOverdueDays(DateTime endDate, DateTime returnDate)
        {
            TimeSpan difference = returnDate - endDate;
            int overdueDays = difference.Days > 0 ? difference.Days : 0;

            txtOverdueDays.Text = overdueDays.ToString();
            CalculateTotalPrice();
        }

        private void DamageCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            decimal totalDamageCost = 0;
            decimal overdueCharges = 0;

            // Calculate overdue charges
            if (int.TryParse(txtOverdueDays.Text, out int overdueDays))
            {
                overdueCharges = overdueDays * OVERDUE_DAILY_RATE;
            }

            // Calculate damage costs
            if (chkScratch.Checked) totalDamageCost += SCRATCH_PRICE;
            if (chkDentedBumper.Checked) totalDamageCost += DENTED_BUMPER_PRICE;
            if (chkBrokenMirror.Checked) totalDamageCost += BROKEN_MIRROR_PRICE;
            if (chkFlatTire.Checked) totalDamageCost += FLAT_TIRE_PRICE;
            if (chkWindshieldCrack.Checked) totalDamageCost += WINDSHIELD_CRACK_PRICE;
            if (chkBrokenHeadlight.Checked) totalDamageCost += BROKEN_HEADLIGHT_PRICE;
            if (chkBrokenTaillight.Checked) totalDamageCost += BROKEN_TAILLIGHT_PRICE;
            if (chkStainedUpholstery.Checked) totalDamageCost += STAINED_UPHOLSTERY_PRICE;

            decimal totalPrice = overdueCharges + totalDamageCost;

            txtOverdueCharges.Text = overdueCharges.ToString("N2");
            txtDamageCost.Text = totalDamageCost.ToString("N2");
            txtTotalPrice.Text = totalPrice.ToString("N2");
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (cmbRentalID.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a rental to return.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int rentalID = Convert.ToInt32(cmbRentalID.SelectedValue);
                int overdueDays = int.Parse(txtOverdueDays.Text);
                decimal overdueCharges = decimal.Parse(txtOverdueCharges.Text);
                decimal damageCost = decimal.Parse(txtDamageCost.Text);
                decimal totalCharges = decimal.Parse(txtTotalPrice.Text);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Insert return record
                            string insertReturnQuery = @"
                                INSERT INTO Returns (
                                    RentalID, CustomerName, PlateNumber, ReturnDate, 
                                    OverdueDays, OverdueCharges,
                                    HasScratch, HasDentedBumper, HasBrokenMirror, HasFlatTire,
                                    HasWindshieldCrack, HasBrokenHeadlight, HasBrokenTaillight, HasStainedUpholstery,
                                    ScratchCost, DentedBumperCost, BrokenMirrorCost, FlatTireCost,
                                    WindshieldCrackCost, BrokenHeadlightCost, BrokenTaillightCost, StainedUpholsteryCost,
                                    TotalDamageCost, TotalCharges, Notes
                                ) VALUES (
                                    @RentalID, @CustomerName, @PlateNumber, @ReturnDate,
                                    @OverdueDays, @OverdueCharges,
                                    @HasScratch, @HasDentedBumper, @HasBrokenMirror, @HasFlatTire,
                                    @HasWindshieldCrack, @HasBrokenHeadlight, @HasBrokenTaillight, @HasStainedUpholstery,
                                    @ScratchCost, @DentedBumperCost, @BrokenMirrorCost, @FlatTireCost,
                                    @WindshieldCrackCost, @BrokenHeadlightCost, @BrokenTaillightCost, @StainedUpholsteryCost,
                                    @TotalDamageCost, @TotalCharges, @Notes
                                )";

                            using (SqlCommand cmd = new SqlCommand(insertReturnQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@RentalID", rentalID);
                                cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                                cmd.Parameters.AddWithValue("@PlateNumber", txtPlateNumber.Text);
                                cmd.Parameters.AddWithValue("@ReturnDate", dtpReturnDate.Value);
                                cmd.Parameters.AddWithValue("@OverdueDays", overdueDays);
                                cmd.Parameters.AddWithValue("@OverdueCharges", overdueCharges);

                                // Damage flags
                                cmd.Parameters.AddWithValue("@HasScratch", chkScratch.Checked);
                                cmd.Parameters.AddWithValue("@HasDentedBumper", chkDentedBumper.Checked);
                                cmd.Parameters.AddWithValue("@HasBrokenMirror", chkBrokenMirror.Checked);
                                cmd.Parameters.AddWithValue("@HasFlatTire", chkFlatTire.Checked);
                                cmd.Parameters.AddWithValue("@HasWindshieldCrack", chkWindshieldCrack.Checked);
                                cmd.Parameters.AddWithValue("@HasBrokenHeadlight", chkBrokenHeadlight.Checked);
                                cmd.Parameters.AddWithValue("@HasBrokenTaillight", chkBrokenTaillight.Checked);
                                cmd.Parameters.AddWithValue("@HasStainedUpholstery", chkStainedUpholstery.Checked);

                                // Damage costs
                                cmd.Parameters.AddWithValue("@ScratchCost", chkScratch.Checked ? SCRATCH_PRICE : 0);
                                cmd.Parameters.AddWithValue("@DentedBumperCost", chkDentedBumper.Checked ? DENTED_BUMPER_PRICE : 0);
                                cmd.Parameters.AddWithValue("@BrokenMirrorCost", chkBrokenMirror.Checked ? BROKEN_MIRROR_PRICE : 0);
                                cmd.Parameters.AddWithValue("@FlatTireCost", chkFlatTire.Checked ? FLAT_TIRE_PRICE : 0);
                                cmd.Parameters.AddWithValue("@WindshieldCrackCost", chkWindshieldCrack.Checked ? WINDSHIELD_CRACK_PRICE : 0);
                                cmd.Parameters.AddWithValue("@BrokenHeadlightCost", chkBrokenHeadlight.Checked ? BROKEN_HEADLIGHT_PRICE : 0);
                                cmd.Parameters.AddWithValue("@BrokenTaillightCost", chkBrokenTaillight.Checked ? BROKEN_TAILLIGHT_PRICE : 0);
                                cmd.Parameters.AddWithValue("@StainedUpholsteryCost", chkStainedUpholstery.Checked ? STAINED_UPHOLSTERY_PRICE : 0);

                                cmd.Parameters.AddWithValue("@TotalDamageCost", damageCost);
                                cmd.Parameters.AddWithValue("@TotalCharges", totalCharges);
                                cmd.Parameters.AddWithValue("@Notes", txtNotes.Text ?? "");

                                cmd.ExecuteNonQuery();
                            }

                            // Update rental status to 'Returned'
                            string updateRentalQuery = "UPDATE Rentals SET RentalStatus = 'Returned', ModifiedDate = GETDATE() WHERE RentalID = @RentalID";
                            using (SqlCommand cmd = new SqlCommand(updateRentalQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@RentalID", rentalID);
                                cmd.ExecuteNonQuery();
                            }

                            // Update car status to 'Available'
                            string updateCarQuery = @"UPDATE Cars SET Status = 'Available', ModifiedDate = GETDATE() 
                                                     WHERE CarID = (SELECT CarID FROM Rentals WHERE RentalID = @RentalID)";
                            using (SqlCommand cmd = new SqlCommand(updateCarQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@RentalID", rentalID);
                                cmd.ExecuteNonQuery();
                            }

                            // If there are charges (overdue or damage), create a payment record
                            if (totalCharges > 0)
                            {
                                string insertPaymentQuery = @"
                                    INSERT INTO Payments (
                                        RentalID, CustomerName, PlateNumber, TotalAmount, 
                                        PaymentMethod, AmountPaid, ChangeAmount, 
                                        ReferenceNumber, PaymentStatus
                                    ) VALUES (
                                        @RentalID, @CustomerName, @PlateNumber, @TotalAmount,
                                        'Pending', 0, 0, 
                                        @ReferenceNumber, 'Pending'
                                    )";

                                using (SqlCommand cmd = new SqlCommand(insertPaymentQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@RentalID", rentalID);
                                    cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                                    cmd.Parameters.AddWithValue("@PlateNumber", txtPlateNumber.Text);
                                    cmd.Parameters.AddWithValue("@TotalAmount", totalCharges);
                                    cmd.Parameters.AddWithValue("@ReferenceNumber", $"RETURN-{rentalID}-{DateTime.Now:yyyyMMddHHmmss}");

                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();

                            string message = "Car returned successfully!";
                            if (totalCharges > 0)
                            {
                                message += $"\n\nAdditional charges: ₱{totalCharges:N2}";
                                if (overdueCharges > 0)
                                    message += $"\n- Overdue charges: ₱{overdueCharges:N2}";
                                if (damageCost > 0)
                                    message += $"\n- Damage charges: ₱{damageCost:N2}";
                                message += "\n\nA payment record has been created.";
                            }

                            MessageBox.Show(message, "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearForm();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing return: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            cmbRentalID.SelectedIndex = -1;
            txtCustomerName.Clear();
            txtPlateNumber.Clear();
            txtCarRented.Clear();
            txtOverdueDays.Text = "0";
            txtOverdueCharges.Text = "0.00";
            txtDamageCost.Text = "0.00";
            txtTotalPrice.Text = "0.00";
            txtNotes.Clear();

            // Uncheck all damage checkboxes
            chkScratch.Checked = false;
            chkDentedBumper.Checked = false;
            chkBrokenMirror.Checked = false;
            chkFlatTire.Checked = false;
            chkWindshieldCrack.Checked = false;
            chkBrokenHeadlight.Checked = false;
            chkBrokenTaillight.Checked = false;
            chkStainedUpholstery.Checked = false;

            dtpReturnDate.Value = DateTime.Now;
            LoadActiveRentals();
        }
    }
}