using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarRental
{
    public partial class ArchiveCarsForm : Form
    {
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CARRENTALDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        private DataTable carsTable;

        public ArchiveCarsForm()
        {
            InitializeComponent();
        }

        private void ArchiveCarsForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadArchivedCars();
        }

        private void SetupDataGridView()
        {
            dgvArchivedCars.EnableHeadersVisualStyles = false;
            dgvArchivedCars.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvArchivedCars.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvArchivedCars.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvArchivedCars.ColumnHeadersHeight = 40;
            dgvArchivedCars.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvArchivedCars.RowTemplate.Height = 35;
            dgvArchivedCars.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvArchivedCars.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgvArchivedCars.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvArchivedCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArchivedCars.MultiSelect = false;
            dgvArchivedCars.ReadOnly = true;
        }

        private void LoadArchivedCars(string searchText = "")
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
                                        ModifiedDate     AS 'Archived Date'
                                    FROM Cars
                                    WHERE IsArchived = 1";

                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        query += @" AND (PlateNumber LIKE @Search
                                    OR CarMaker    LIKE @Search
                                    OR CarModel    LIKE @Search)";
                    }

                    query += " ORDER BY ModifiedDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(searchText))
                            cmd.Parameters.AddWithValue("@Search", "%" + searchText + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        carsTable = new DataTable();
                        adapter.Fill(carsTable);

                        dgvArchivedCars.DataSource = carsTable;

                        if (dgvArchivedCars.Columns["CarID"] != null)
                            dgvArchivedCars.Columns["CarID"].Visible = false;

                        FormatColumns();
                        lblCount.Text = $"Total Archived Cars: {dgvArchivedCars.Rows.Count}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading archived cars: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatColumns()
        {
            if (dgvArchivedCars.Columns["Daily Price"] != null)
                dgvArchivedCars.Columns["Daily Price"].DefaultCellStyle.Format = "C2";

            if (dgvArchivedCars.Columns["Archived Date"] != null)
                dgvArchivedCars.Columns["Archived Date"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
        }

        private void dgvArchivedCars_SelectionChanged(object sender, EventArgs e)
        {
            btnRestore.Enabled = dgvArchivedCars.SelectedRows.Count > 0;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (dgvArchivedCars.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a car to restore.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dgvArchivedCars.SelectedRows[0];
            int carId = Convert.ToInt32(selectedRow.Cells["CarID"].Value);
            string plateNumber = selectedRow.Cells["Plate Number"].Value?.ToString();
            string carInfo = $"{selectedRow.Cells["Maker"].Value} {selectedRow.Cells["Model"].Value} ({plateNumber})";

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to RESTORE this car?\n\n" +
                $"Car: {carInfo}\n\n" +
                $"It will be moved back to the active car list with 'Pending' status.",
                "Confirm Restore",
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
                                         SET IsArchived   = 0,
                                             Status       = 'Pending',
                                             ModifiedDate = GETDATE()
                                         WHERE CarID = @CarID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@CarID", carId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show($"Car '{plateNumber}' has been restored successfully!\nStatus set back to 'Pending'.",
                        "Restored", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadArchivedCars(txtSearch.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error restoring car: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadArchivedCars(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadArchivedCars(txtSearch.Text);
        }
    }
}