using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace CarRental
{
    public partial class PaymentListForm : Form
    {
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CARRENTALDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";

        private int rentalID;
        private decimal totalAmount;
        private string customerName;
        private string plateNumber;
        private string selectedPaymentMethod = "";

        // Constructor to receive data from CreateCarRentalForm
        public PaymentListForm(int rentalID, decimal totalAmount, string customerName, string plateNumber)
        {
            InitializeComponent();

            this.rentalID = rentalID;
            this.totalAmount = totalAmount;
            this.customerName = customerName;
            this.plateNumber = plateNumber;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            // Display rental information
            lblRentalIDValue.Text = rentalID.ToString();
            lblCustomerValue.Text = customerName;
            lblPlateNumberValue.Text = plateNumber;
            lblTotalAmountValue.Text = string.Format("${0:N2}", totalAmount);

            // Set default amount paid to total amount
            txtAmountPaid.Text = totalAmount.ToString("F2");
        }

        private void panelCash_Click(object sender, EventArgs e)
        {
            SelectPaymentMethod("Cash", panelCash);
            txtAmountPaid.Enabled = true;
            txtReferenceNumber.Enabled = false;
            txtReferenceNumber.Clear();
        }

        private void panelGCash_Click(object sender, EventArgs e)
        {
            SelectPaymentMethod("GCash", panelGCash);
            txtAmountPaid.Text = totalAmount.ToString("F2");
            txtAmountPaid.Enabled = false; // GCash pays exact amount
            txtReferenceNumber.Enabled = true;
            CalculateChange();
        }

        private void panelCard_Click(object sender, EventArgs e)
        {
            SelectPaymentMethod("Card", panelCard);
            txtAmountPaid.Text = totalAmount.ToString("F2");
            txtAmountPaid.Enabled = false; // Card pays exact amount
            txtReferenceNumber.Enabled = true;
            CalculateChange();
        }

        private void SelectPaymentMethod(string method, Panel selectedPanel)
        {
            selectedPaymentMethod = method;

            // Reset all panels
            panelCash.BackColor = Color.FromArgb(236, 240, 241);
            panelGCash.BackColor = Color.FromArgb(236, 240, 241);
            panelCard.BackColor = Color.FromArgb(236, 240, 241);

            panelCash.BorderStyle = BorderStyle.FixedSingle;
            panelGCash.BorderStyle = BorderStyle.FixedSingle;
            panelCard.BorderStyle = BorderStyle.FixedSingle;

            // Highlight selected panel
            selectedPanel.BackColor = Color.FromArgb(255, 255, 255);
            selectedPanel.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void CalculateChange()
        {
            if (decimal.TryParse(txtAmountPaid.Text, out decimal amountPaid))
            {
                decimal change = amountPaid - totalAmount;

                if (change < 0)
                {
                    lblChangeAmount.Text = "$0.00";
                    lblChangeAmount.ForeColor = Color.FromArgb(231, 76, 60); // Red
                }
                else
                {
                    lblChangeAmount.Text = string.Format("${0:N2}", change);
                    lblChangeAmount.ForeColor = Color.FromArgb(39, 174, 96); // Green
                }
            }
            else
            {
                lblChangeAmount.Text = "$0.00";
            }
        }

        private void btnProcessPayment_Click(object sender, EventArgs e)
        {
            if (!ValidatePayment())
                return;

            try
            {
                decimal amountPaid = decimal.Parse(txtAmountPaid.Text);
                decimal change = amountPaid - totalAmount;

                if (change < 0)
                {
                    MessageBox.Show("Amount paid is less than the total amount!",
                        "Insufficient Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Save payment to database
                int paymentID = SavePayment(amountPaid, change);

                // Update rental status
                UpdateRentalPaymentStatus();

                // Show success message
                string successMessage = string.Format(
                    "Payment Processed Successfully!\n\n" +
                    "Payment ID: {0}\n" +
                    "Rental ID: {1}\n" +
                    "Payment Method: {2}\n" +
                    "Total Amount: ${3:N2}\n" +
                    "Amount Paid: ${4:N2}\n" +
                    "Change: ${5:N2}\n\n" +
                    "Thank you for your payment!",
                    paymentID,
                    rentalID,
                    selectedPaymentMethod,
                    totalAmount,
                    amountPaid,
                    change);

                MessageBox.Show(successMessage, "Payment Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close form or navigate back
                CloseForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing payment: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidatePayment()
        {
            if (string.IsNullOrEmpty(selectedPaymentMethod))
            {
                MessageBox.Show("Please select a payment method.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtAmountPaid.Text, out decimal amountPaid) || amountPaid <= 0)
            {
                MessageBox.Show("Please enter a valid amount paid.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmountPaid.Focus();
                return false;
            }

            if ((selectedPaymentMethod == "GCash" || selectedPaymentMethod == "Card") &&
                string.IsNullOrWhiteSpace(txtReferenceNumber.Text))
            {
                MessageBox.Show("Please enter a reference number for " + selectedPaymentMethod + " payment.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReferenceNumber.Focus();
                return false;
            }

            return true;
        }

        private int SavePayment(decimal amountPaid, decimal change)
        {
            int paymentID = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO Payments 
                               (RentalID, CustomerName, PlateNumber, TotalAmount, 
                                PaymentMethod, AmountPaid, ChangeAmount, ReferenceNumber, 
                                PaymentStatus, PaymentDate) 
                               VALUES 
                               (@RentalID, @CustomerName, @PlateNumber, @TotalAmount, 
                                @PaymentMethod, @AmountPaid, @ChangeAmount, @ReferenceNumber, 
                                'Completed', GETDATE());
                               SELECT CAST(SCOPE_IDENTITY() AS INT)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RentalID", rentalID);
                    cmd.Parameters.AddWithValue("@CustomerName", customerName);
                    cmd.Parameters.AddWithValue("@PlateNumber", plateNumber);
                    cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    cmd.Parameters.AddWithValue("@PaymentMethod", selectedPaymentMethod);
                    cmd.Parameters.AddWithValue("@AmountPaid", amountPaid);
                    cmd.Parameters.AddWithValue("@ChangeAmount", change);
                    cmd.Parameters.AddWithValue("@ReferenceNumber",
                        string.IsNullOrWhiteSpace(txtReferenceNumber.Text) ? (object)DBNull.Value : txtReferenceNumber.Text.Trim());

                    paymentID = (int)cmd.ExecuteScalar();
                }
            }

            return paymentID;
        }

        private void UpdateRentalPaymentStatus()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // You can add a PaymentStatus column to Rentals table if needed
                string query = @"UPDATE Rentals 
                               SET ModifiedDate = GETDATE() 
                               WHERE RentalID = @RentalID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RentalID", rentalID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel this payment?\n\nThe rental will remain unpaid.",
                "Cancel Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CloseForm();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender, e);
        }

        private void CloseForm()
        {
            // Check if form is embedded in a panel
            if (this.Parent != null && this.Parent is Panel)
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