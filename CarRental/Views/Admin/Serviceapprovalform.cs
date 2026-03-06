using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace CarRental
{
    public partial class ServiceApprovalForm : Form
    {
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CARRENTALDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";

        // Controls
        private Panel pnlTop;
        private Label lblTitle;
        private ComboBox cmbFilter;
        private Button btnRefresh;
        private DataGridView dgvServices;
        private Panel pnlBottom;
        private Label lblRemarks;
        private TextBox txtRemarks;
        private Button btnApprove;
        private Button btnReject;
        private Label lblStatus;

        public ServiceApprovalForm()
        {
            InitializeComponents();
            LoadServiceRequests();
        }

        private void InitializeComponents()
        {
            this.Text = "Service Approval";
            this.BackColor = Color.FromArgb(245, 246, 250);

            // ── Top Panel ──
            pnlTop = new Panel();
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 60;
            pnlTop.BackColor = Color.White;
            pnlTop.Padding = new Padding(15, 0, 15, 0);

            lblTitle = new Label();
            lblTitle.Text = "Service Approval Requests";
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(41, 44, 51);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(15, 15);

            Label lblFilter = new Label();
            lblFilter.Text = "Filter:";
            lblFilter.Font = new Font("Segoe UI", 10F);
            lblFilter.ForeColor = Color.FromArgb(100, 100, 100);
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(320, 20);

            cmbFilter = new ComboBox();
            cmbFilter.Items.AddRange(new object[] { "All", "Pending", "Approved", "Rejected" });
            cmbFilter.SelectedIndex = 1; // Default to Pending
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Font = new Font("Segoe UI", 10F);
            cmbFilter.Location = new Point(370, 17);
            cmbFilter.Width = 130;
            cmbFilter.SelectedIndexChanged += (s, e) => LoadServiceRequests();

            btnRefresh = new Button();
            btnRefresh.Text = "↻ Refresh";
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.BackColor = Color.FromArgb(41, 128, 185);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Size = new Size(90, 30);
            btnRefresh.Location = new Point(515, 14);
            btnRefresh.Click += (s, e) => LoadServiceRequests();

            pnlTop.Controls.AddRange(new Control[] { lblTitle, lblFilter, cmbFilter, btnRefresh });

            // ── DataGridView ──
            dgvServices = new DataGridView();
            dgvServices.Dock = DockStyle.Fill;
            dgvServices.BackgroundColor = Color.FromArgb(245, 246, 250);
            dgvServices.BorderStyle = BorderStyle.None;
            dgvServices.RowHeadersVisible = false;
            dgvServices.AllowUserToAddRows = false;
            dgvServices.AllowUserToDeleteRows = false;
            dgvServices.ReadOnly = true;
            dgvServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServices.MultiSelect = false;
            dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServices.Font = new Font("Segoe UI", 10F);
            dgvServices.ColumnHeadersHeight = 40;
            dgvServices.RowTemplate.Height = 36;
            dgvServices.GridColor = Color.FromArgb(220, 220, 220);
            dgvServices.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Header style
            dgvServices.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            dgvServices.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvServices.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvServices.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvServices.EnableHeadersVisualStyles = false;

            // Row style
            dgvServices.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);
            dgvServices.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 238, 245);

            dgvServices.SelectionChanged += DgvServices_SelectionChanged;

            // ── Bottom Panel ──
            pnlBottom = new Panel();
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Height = 100;
            pnlBottom.BackColor = Color.White;
            pnlBottom.Padding = new Padding(15, 10, 15, 10);

            lblRemarks = new Label();
            lblRemarks.Text = "Admin Remarks (optional):";
            lblRemarks.Font = new Font("Segoe UI", 9F);
            lblRemarks.ForeColor = Color.FromArgb(100, 100, 100);
            lblRemarks.AutoSize = true;
            lblRemarks.Location = new Point(15, 12);

            txtRemarks = new TextBox();
            txtRemarks.Font = new Font("Segoe UI", 10F);
            txtRemarks.Location = new Point(15, 32);
            txtRemarks.Width = 500;
            txtRemarks.Height = 30;
            txtRemarks.PlaceholderText = "Enter reason for approval or rejection...";
            txtRemarks.BorderStyle = BorderStyle.FixedSingle;

            btnApprove = new Button();
            btnApprove.Text = "✔  Approve";
            btnApprove.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnApprove.BackColor = Color.FromArgb(39, 174, 96);
            btnApprove.ForeColor = Color.White;
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.FlatAppearance.BorderSize = 0;
            btnApprove.Size = new Size(130, 40);
            btnApprove.Location = new Point(530, 25);
            btnApprove.Enabled = false;
            btnApprove.Click += BtnApprove_Click;

            btnReject = new Button();
            btnReject.Text = "✘  Reject";
            btnReject.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReject.BackColor = Color.FromArgb(192, 57, 43);
            btnReject.ForeColor = Color.White;
            btnReject.FlatStyle = FlatStyle.Flat;
            btnReject.FlatAppearance.BorderSize = 0;
            btnReject.Size = new Size(130, 40);
            btnReject.Location = new Point(675, 25);
            btnReject.Enabled = false;
            btnReject.Click += BtnReject_Click;

            lblStatus = new Label();
            lblStatus.Text = "";
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblStatus.ForeColor = Color.FromArgb(100, 100, 100);
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(15, 75);

            pnlBottom.Controls.AddRange(new Control[] { lblRemarks, txtRemarks, btnApprove, btnReject, lblStatus });

            // ── Assemble ──
            this.Controls.Add(dgvServices);
            this.Controls.Add(pnlBottom);
            this.Controls.Add(pnlTop);
        }

        private void LoadServiceRequests()
        {
            try
            {
                string filterStatus = cmbFilter.SelectedItem?.ToString() ?? "Pending";

                string whereClause = filterStatus == "All"
                    ? ""
                    : "WHERE sa.Status = @Status";

                string query = $@"
                    SELECT 
                        sa.ApprovalID,
                        sa.RentalID,
                        r.CustomerFullName AS Customer,
                        r.PlateNumber AS Car,
                        sa.ServiceName AS [Service],
                        sa.DailyRate AS [Rate/Day],
                        sa.RentalDays AS Days,
                        sa.TotalServiceCost AS [Total Cost],
                        sa.Status,
                        sa.RequestedDate AS [Requested],
                        sa.ReviewedDate AS [Reviewed],
                        sa.AdminRemarks AS [Admin Remarks]
                    FROM ServiceApprovals sa
                    INNER JOIN Rentals r ON sa.RentalID = r.RentalID
                    {whereClause}
                    ORDER BY 
                        CASE sa.Status WHEN 'Pending' THEN 0 WHEN 'Approved' THEN 1 ELSE 2 END,
                        sa.RequestedDate DESC";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (filterStatus != "All")
                            cmd.Parameters.AddWithValue("@Status", filterStatus);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvServices.DataSource = dt;
                        }
                    }
                }

                // Format columns
                if (dgvServices.Columns.Count > 0)
                {
                    // Hide internal ID columns
                    if (dgvServices.Columns.Contains("ApprovalID"))
                        dgvServices.Columns["ApprovalID"].Visible = false;

                    // Format decimals
                    if (dgvServices.Columns.Contains("Rate/Day"))
                        dgvServices.Columns["Rate/Day"].DefaultCellStyle.Format = "C2";
                    if (dgvServices.Columns.Contains("Total Cost"))
                        dgvServices.Columns["Total Cost"].DefaultCellStyle.Format = "C2";

                    // Format dates
                    if (dgvServices.Columns.Contains("Requested"))
                        dgvServices.Columns["Requested"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
                    if (dgvServices.Columns.Contains("Reviewed"))
                        dgvServices.Columns["Reviewed"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";

                    // Center-align some columns
                    foreach (DataGridViewColumn col in dgvServices.Columns)
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    // Left-align text columns
                    if (dgvServices.Columns.Contains("Customer"))
                        dgvServices.Columns["Customer"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    if (dgvServices.Columns.Contains("Service"))
                        dgvServices.Columns["Service"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    if (dgvServices.Columns.Contains("Admin Remarks"))
                        dgvServices.Columns["Admin Remarks"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                // Color rows by status
                ColorRowsByStatus();

                // Update status label
                lblStatus.Text = $"Showing {dgvServices.Rows.Count} record(s).";

                // Disable buttons — no row selected yet
                btnApprove.Enabled = false;
                btnReject.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading service requests: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColorRowsByStatus()
        {
            if (!dgvServices.Columns.Contains("Status")) return;

            foreach (DataGridViewRow row in dgvServices.Rows)
            {
                string status = row.Cells["Status"].Value?.ToString();
                switch (status)
                {
                    case "Pending":
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(243, 156, 18);
                        row.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        break;
                    case "Approved":
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(39, 174, 96);
                        row.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
                        break;
                    case "Rejected":
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(192, 57, 43);
                        row.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
                        break;
                }
            }
        }

        private void DgvServices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count == 0)
            {
                btnApprove.Enabled = false;
                btnReject.Enabled = false;
                return;
            }

            string status = dgvServices.SelectedRows[0].Cells["Status"].Value?.ToString();

            // Only allow action on Pending rows
            bool isPending = status == "Pending";
            btnApprove.Enabled = isPending;
            btnReject.Enabled = isPending;
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count == 0) return;

            int approvalID = Convert.ToInt32(dgvServices.SelectedRows[0].Cells["ApprovalID"].Value);
            string serviceName = dgvServices.SelectedRows[0].Cells["Service"].Value?.ToString();
            int rentalID = Convert.ToInt32(dgvServices.SelectedRows[0].Cells["RentalID"].Value);
            decimal totalServiceCost = Convert.ToDecimal(dgvServices.SelectedRows[0].Cells["Total Cost"].Value);

            DialogResult confirm = MessageBox.Show(
                $"Approve '{serviceName}' for Rental ID {rentalID}?\n\nThis will add ${totalServiceCost:N2} to the rental total.",
                "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Update ServiceApprovals status
                            string updateApproval = @"
                                UPDATE ServiceApprovals 
                                SET Status = 'Approved', 
                                    ReviewedDate = GETDATE(), 
                                    AdminRemarks = @Remarks
                                WHERE ApprovalID = @ApprovalID";

                            using (SqlCommand cmd = new SqlCommand(updateApproval, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@ApprovalID", approvalID);
                                cmd.Parameters.AddWithValue("@Remarks",
                                    string.IsNullOrWhiteSpace(txtRemarks.Text) ? (object)DBNull.Value : txtRemarks.Text.Trim());
                                cmd.ExecuteNonQuery();
                            }

                            // 2. Add cost to Rental TotalCost and AdditionalServicesCost
                            string updateRental = @"
                                UPDATE Rentals 
                                SET AdditionalServicesCost = AdditionalServicesCost + @Cost,
                                    TotalCost = TotalCost + @Cost,
                                    ModifiedDate = GETDATE()
                                WHERE RentalID = @RentalID";

                            using (SqlCommand cmd = new SqlCommand(updateRental, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Cost", totalServiceCost);
                                cmd.Parameters.AddWithValue("@RentalID", rentalID);
                                cmd.ExecuteNonQuery();
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

                MessageBox.Show(
                    $"✔ '{serviceName}' has been APPROVED.\n${totalServiceCost:N2} added to Rental ID {rentalID}.",
                    "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtRemarks.Clear();
                LoadServiceRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error approving service: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count == 0) return;

            int approvalID = Convert.ToInt32(dgvServices.SelectedRows[0].Cells["ApprovalID"].Value);
            string serviceName = dgvServices.SelectedRows[0].Cells["Service"].Value?.ToString();
            int rentalID = Convert.ToInt32(dgvServices.SelectedRows[0].Cells["RentalID"].Value);

            if (string.IsNullOrWhiteSpace(txtRemarks.Text))
            {
                MessageBox.Show("Please provide a reason for rejection in the remarks field.",
                    "Remarks Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRemarks.Focus();
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Reject '{serviceName}' for Rental ID {rentalID}?\n\nThis service will NOT be added to the payment.",
                "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE ServiceApprovals 
                        SET Status = 'Rejected', 
                            ReviewedDate = GETDATE(), 
                            AdminRemarks = @Remarks
                        WHERE ApprovalID = @ApprovalID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ApprovalID", approvalID);
                        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    $"✘ '{serviceName}' has been REJECTED for Rental ID {rentalID}.",
                    "Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtRemarks.Clear();
                LoadServiceRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error rejecting service: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}