using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarRental
{
    public partial class CarApprovalForm : Form
    {
        // Connection string - UPDATE THIS with your actual connection string
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CARRENTALDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        private DataTable carsTable;

        public CarApprovalForm()
        {
            InitializeComponent();
        }

        private void CarApprovalForm_Load(object sender, EventArgs e)
        {
            // Initialize the form
            SetupDataGridView();
            cmbStatusFilter.SelectedIndex = 0; // Default to "All"
            LoadCars();
        }

        private void SetupDataGridView()
        {
            // Configure DataGridView appearance
            dgvCars.EnableHeadersVisualStyles = false;
            dgvCars.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvCars.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCars.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvCars.ColumnHeadersHeight = 40;
            dgvCars.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvCars.RowTemplate.Height = 35;
            dgvCars.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvCars.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgvCars.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void LoadCars(string searchText = "", string statusFilter = "All")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT 
                                        CarID,
                                        PlateNumber AS 'Plate Number',
                                        CarMaker AS 'Maker',
                                        CarModel AS 'Model',
                                        CarYear AS 'Year',
                                        FuelType AS 'Fuel Type',
                                        Seats,
                                        Transmission,
                                        DailyRentalPrice AS 'Daily Price',
                                        Status,
                                        CreatedDate AS 'Created Date'
                                    FROM Cars 
                                    WHERE IsArchived = 0";

                    // Add search filter
                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        query += @" AND (PlateNumber LIKE @Search 
                                    OR CarMaker LIKE @Search 
                                    OR CarModel LIKE @Search)";
                    }

                    // Add status filter
                    if (statusFilter != "All")
                    {
                        query += " AND Status = @Status";
                    }

                    query += " ORDER BY CreatedDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(searchText))
                        {
                            cmd.Parameters.AddWithValue("@Search", "%" + searchText + "%");
                        }

                        if (statusFilter != "All")
                        {
                            cmd.Parameters.AddWithValue("@Status", statusFilter);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        carsTable = new DataTable();
                        adapter.Fill(carsTable);

                        dgvCars.DataSource = carsTable;

                        // Hide CarID column
                        if (dgvCars.Columns["CarID"] != null)
                        {
                            dgvCars.Columns["CarID"].Visible = false;
                        }

                        // Format columns
                        FormatDataGridViewColumns();

                        // Update status label (if you want to add one)
                        UpdateStatusLabel();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cars: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridViewColumns()
        {
            // Format Daily Price as currency
            if (dgvCars.Columns["Daily Price"] != null)
            {
                dgvCars.Columns["Daily Price"].DefaultCellStyle.Format = "C2";
            }

            // Format Created Date
            if (dgvCars.Columns["Created Date"] != null)
            {
                dgvCars.Columns["Created Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            }

            // Color code Status column
            if (dgvCars.Columns["Status"] != null)
            {
                foreach (DataGridViewRow row in dgvCars.Rows)
                {
                    string status = row.Cells["Status"].Value?.ToString();
                    if (status == "Approve")
                    {
                        row.Cells["Status"].Style.ForeColor = Color.Green;
                        row.Cells["Status"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }
                    else if (status == "Pending")
                    {
                        row.Cells["Status"].Style.ForeColor = Color.Orange;
                        row.Cells["Status"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }
                    else if (status == "Rented")
                    {
                        row.Cells["Status"].Style.ForeColor = Color.Red;
                        row.Cells["Status"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }
                    else if (status == "Maintenance")
                    {
                        row.Cells["Status"].Style.ForeColor = Color.DarkOrange;
                        row.Cells["Status"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }
                }
            }
        }

        private void UpdateStatusLabel()
        {
            // You can add a status label to show total cars if needed
            // For now, we'll update the form title
            this.Text = $"Car Approval & Deletion - {dgvCars.Rows.Count} cars";
        }

        private void dgvCars_SelectionChanged(object sender, EventArgs e)
        {
            // Enable/disable buttons based on selection
            bool hasSelection = dgvCars.SelectedRows.Count > 0;
            btnApprove.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;

            if (hasSelection)
            {
                // Get the selected car's status
                string status = dgvCars.SelectedRows[0].Cells["Status"].Value?.ToString();

                // Disable approve button if already approved/available
                if (status == "Approve")
                {
                    btnApprove.Text = "✅ Already Approved";
                    btnApprove.Enabled = false;
                }
                else
                {
                    btnApprove.Text = "✅ Approve Car";
                    btnApprove.Enabled = true;
                }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a car to approve.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dgvCars.SelectedRows[0];
            int carId = Convert.ToInt32(selectedRow.Cells["CarID"].Value);
            string plateNumber = selectedRow.Cells["Plate Number"].Value.ToString();
            string currentStatus = selectedRow.Cells["Status"].Value.ToString();

            if (currentStatus == "Approve")
            {
                MessageBox.Show("This car is already approved!", "Already Approved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to approve the car with plate number: {plateNumber}?\n\n" +
                $"This will change the status from '{currentStatus}' to 'Approve'.",
                "Confirm Approval",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string query = @"UPDATE Cars 
                                       SET Status = 'Approved', 
                                           ModifiedDate = GETDATE() 
                                       WHERE CarID = @CarID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@CarID", carId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show($"Car '{plateNumber}' has been approved successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadCars(txtSearch.Text, cmbStatusFilter.SelectedItem.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error approving car: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a car to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dgvCars.SelectedRows[0];
            int carId = Convert.ToInt32(selectedRow.Cells["CarID"].Value);
            string plateNumber = selectedRow.Cells["Plate Number"].Value.ToString();
            string carInfo = $"{selectedRow.Cells["Maker"].Value} {selectedRow.Cells["Model"].Value} ({plateNumber})";

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to DELETE this car?\n\n" +
                $"Car: {carInfo}\n\n" +
                $"⚠️ WARNING: This action cannot be undone!\n" +
                $"The car will be permanently removed from the database.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Double confirmation for deletion
                DialogResult confirmAgain = MessageBox.Show(
                    "Are you ABSOLUTELY SURE?\n\nThis will permanently delete the car record!",
                    "Final Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation);

                if (confirmAgain == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();

                            // Option 1: Soft delete (set IsArchived = 1)
                            // This is safer as it doesn't permanently delete the data
                            string query = @"UPDATE Cars 
                                           SET IsArchived = 1, 
                                               ModifiedDate = GETDATE() 
                                           WHERE CarID = @CarID";

                            // Option 2: Hard delete (permanently remove from database)
                            // Uncomment this if you want permanent deletion
                            // string query = "DELETE FROM Cars WHERE CarID = @CarID";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@CarID", carId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show($"Car '{plateNumber}' has been deleted successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadCars(txtSearch.Text, cmbStatusFilter.SelectedItem.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting car: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCars(txtSearch.Text, cmbStatusFilter.SelectedItem.ToString());
            MessageBox.Show("Data refreshed successfully!", "Refresh",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCars(txtSearch.Text, cmbStatusFilter.SelectedItem?.ToString() ?? "All");
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCars(txtSearch.Text, cmbStatusFilter.SelectedItem.ToString());
        }
    }
}