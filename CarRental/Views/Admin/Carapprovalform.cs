using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarRental
{
    public partial class CarApprovalForm : Form
    {
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CARRENTALDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        private DataTable carsTable;

        public CarApprovalForm()
        {
            InitializeComponent();
        }

        private void CarApprovalForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            cmbStatusFilter.SelectedIndex = 0; // Default to "All"
            LoadCars();
        }

        private void SetupDataGridView()
        {
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
                                        PlateNumber      AS 'Plate Number',
                                        CarMaker         AS 'Maker',
                                        CarModel         AS 'Model',
                                        CarYear          AS 'Year',
                                        FuelType         AS 'Fuel Type',
                                        Seats,
                                        Transmission,
                                        DailyRentalPrice AS 'Daily Price',
                                        Status,
                                        CreatedDate      AS 'Created Date'
                                    FROM Cars 
                                    WHERE IsArchived = 0";

                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        query += @" AND (PlateNumber LIKE @Search 
                                    OR CarMaker LIKE @Search 
                                    OR CarModel LIKE @Search)";
                    }

                    if (statusFilter != "All")
                        query += " AND Status = @Status";

                    query += " ORDER BY CreatedDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(searchText))
                            cmd.Parameters.AddWithValue("@Search", "%" + searchText + "%");

                        if (statusFilter != "All")
                            cmd.Parameters.AddWithValue("@Status", statusFilter);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        carsTable = new DataTable();
                        adapter.Fill(carsTable);

                        dgvCars.DataSource = carsTable;

                        if (dgvCars.Columns["CarID"] != null)
                            dgvCars.Columns["CarID"].Visible = false;

                        FormatDataGridViewColumns();
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
            if (dgvCars.Columns["Daily Price"] != null)
                dgvCars.Columns["Daily Price"].DefaultCellStyle.Format = "C2";

            if (dgvCars.Columns["Created Date"] != null)
                dgvCars.Columns["Created Date"].DefaultCellStyle.Format = "MM/dd/yyyy";

            if (dgvCars.Columns["Status"] != null)
            {
                foreach (DataGridViewRow row in dgvCars.Rows)
                {
                    string status = row.Cells["Status"].Value?.ToString();
                    switch (status)
                    {
                        case "Available":
                        case "Approved":
                            row.Cells["Status"].Style.ForeColor = Color.Green;
                            row.Cells["Status"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            break;
                        case "Pending":
                            row.Cells["Status"].Style.ForeColor = Color.Orange;
                            row.Cells["Status"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            break;
                        case "Rented":
                            row.Cells["Status"].Style.ForeColor = Color.Red;
                            row.Cells["Status"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            break;
                        case "Maintenance":
                            row.Cells["Status"].Style.ForeColor = Color.DarkOrange;
                            row.Cells["Status"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            break;
                    }
                }
            }
        }

        private void UpdateStatusLabel()
        {
            this.Text = $"Car Approval & Deletion - {dgvCars.Rows.Count} cars";
        }

        private void dgvCars_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvCars.SelectedRows.Count > 0;
            btnApprove.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;

            if (hasSelection)
            {
                string status = dgvCars.SelectedRows[0].Cells["Status"].Value?.ToString();

                if (status == "Approved" || status == "Available")
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

            if (currentStatus == "Approved" || currentStatus == "Available")
            {
                MessageBox.Show("This car is already approved!", "Already Approved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to approve the car with plate number: {plateNumber}?\n\n" +
                $"This will change the status from '{currentStatus}' to 'Available'.",
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
                                         SET Status       = 'Available', 
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

        // NOTE: btnDelete is the "Archive" button on the form.
        // It performs a soft delete (IsArchived = 1) so the car
        // moves to the Manager's Archive Cars view instead of being
        // permanently removed.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a car to archive.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dgvCars.SelectedRows[0];
            int carId = Convert.ToInt32(selectedRow.Cells["CarID"].Value);
            string plateNumber = selectedRow.Cells["Plate Number"].Value.ToString();
            string carInfo = $"{selectedRow.Cells["Maker"].Value} {selectedRow.Cells["Model"].Value} ({plateNumber})";

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to ARCHIVE this car?\n\n" +
                $"Car: {carInfo}\n\n" +
                $"The car will be moved to the Archive and removed from the active list.\n" +
                $"The Manager can restore it later if needed.",
                "Confirm Archive",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Soft delete — sets IsArchived = 1
                        // The Manager can see and restore this car from Archive Cars
                        string query = @"UPDATE Cars 
                                         SET IsArchived   = 1, 
                                             ModifiedDate = GETDATE() 
                                         WHERE CarID = @CarID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@CarID", carId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show($"Car '{plateNumber}' has been archived successfully!\n" +
                                    $"It is now visible under Archive Cars in the Manager Panel.",
                        "Archived", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadCars(txtSearch.Text, cmbStatusFilter.SelectedItem.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error archiving car: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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