using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CarRental
{
    public partial class RentalPriceForm : Form
    {
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CARRENTALDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public RentalPriceForm()
        {
            InitializeComponent();
        }

        private void RentalPriceForm_Load(object sender, EventArgs e)
        {
            LoadCars();
        }

        // ─── Load all non-archived cars into the DataGridView ───────────────────
        private void LoadCars(string search = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT CarID,
                               PlateNumber,
                               CarMaker   AS Maker,
                               CarModel   AS Model,
                               CarYear    AS Year,
                               DailyRentalPrice AS [Daily Price ($)],
                               Status
                        FROM   Cars
                        WHERE  (IsArchived = 0 OR IsArchived IS NULL)
                          AND  (PlateNumber LIKE @search
                                OR CarMaker  LIKE @search
                                OR CarModel  LIKE @search)
                        ORDER BY CarMaker, CarModel";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvCars.DataSource = dt;

                    // Hide the CarID column — used internally only
                    dgvCars.Columns["CarID"].Visible = false;

                    // Style header
                    dgvCars.Columns["PlateNumber"].HeaderText = "Plate Number";
                    dgvCars.Columns["Maker"].HeaderText = "Maker";
                    dgvCars.Columns["Model"].HeaderText = "Model";
                    dgvCars.Columns["Year"].HeaderText = "Year";
                    dgvCars.Columns["Daily Price ($)"].HeaderText = "Daily Price ($)";
                    dgvCars.Columns["Status"].HeaderText = "Status";

                    // Column widths
                    dgvCars.Columns["PlateNumber"].Width = 110;
                    dgvCars.Columns["Maker"].Width = 100;
                    dgvCars.Columns["Model"].Width = 100;
                    dgvCars.Columns["Year"].Width = 60;
                    dgvCars.Columns["Daily Price ($)"].Width = 120;
                    dgvCars.Columns["Status"].Width = 90;

                    // Read-only except Daily Price
                    foreach (DataGridViewColumn col in dgvCars.Columns)
                        col.ReadOnly = true;
                    dgvCars.Columns["Daily Price ($)"].ReadOnly = false;
                    dgvCars.Columns["Daily Price ($)"].DefaultCellStyle.BackColor = Color.LightYellow;
                    dgvCars.Columns["Daily Price ($)"].DefaultCellStyle.Font =
                        new Font(dgvCars.Font, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cars:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Row click → populate the edit panel ────────────────────────────────
        private void dgvCars_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow == null) return;

            DataGridViewRow row = dgvCars.CurrentRow;
            txtPlateNumber.Text = row.Cells["PlateNumber"].Value?.ToString();
            txtMaker.Text = row.Cells["Maker"].Value?.ToString();
            txtModel.Text = row.Cells["Model"].Value?.ToString();
            txtYear.Text = row.Cells["Year"].Value?.ToString();

            if (decimal.TryParse(row.Cells["Daily Price ($)"].Value?.ToString(), out decimal price))
                txtNewPrice.Text = price.ToString("F2");
            else
                txtNewPrice.Text = "";
        }

        // ─── Save button: update price in DB ────────────────────────────────────
        private void btnSavePrice_Click(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow == null)
            {
                MessageBox.Show("Please select a car first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtNewPrice.Text.Trim(), out decimal newPrice) || newPrice <= 0)
            {
                MessageBox.Show("Please enter a valid price (e.g. 150.00).", "Invalid Price",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPrice.Focus();
                return;
            }

            int carId = Convert.ToInt32(dgvCars.CurrentRow.Cells["CarID"].Value);
            string plate = dgvCars.CurrentRow.Cells["PlateNumber"].Value?.ToString();

            DialogResult confirm = MessageBox.Show(
                $"Update daily rental price for {plate} to ${newPrice:F2}?",
                "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        UPDATE Cars
                        SET    DailyRentalPrice = @price,
                               ModifiedDate     = GETDATE()
                        WHERE  CarID = @carId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@price", newPrice);
                        cmd.Parameters.AddWithValue("@carId", carId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Price updated successfully for {plate}!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadCars(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving price:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Search box ──────────────────────────────────────────────────────────
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCars(txtSearch.Text.Trim());
        }

        // ─── Refresh button ──────────────────────────────────────────────────────
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtNewPrice.Clear();
            LoadCars();
        }

        // ─── Allow inline editing of Daily Price cell directly in grid ───────────
        private void dgvCars_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Sync inline edit to txtNewPrice
            if (dgvCars.Columns[e.ColumnIndex].Name == "Daily Price ($)")
            {
                txtNewPrice.Text = dgvCars.CurrentRow?.Cells["Daily Price ($)"].Value?.ToString();
            }
        }
    }
}