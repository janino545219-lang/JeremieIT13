using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace CarRental
{
    public partial class StaffServiceStatusForm : Form
    {
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CARRENTALDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";

        private Panel pnlTop;
        private Panel pnlStats;
        private DataGridView dgvServices;
        private Panel pnlBottom;
        private ComboBox cmbFilter;
        private Button btnRefresh;
        private Label lblPendingCount;
        private Label lblApprovedCount;
        private Label lblRejectedCount;

        public StaffServiceStatusForm()
        {
            InitializeComponents();
            LoadServiceStatuses();
        }

        private void InitializeComponents()
        {
            this.Text = "Service Request Status";
            this.BackColor = Color.FromArgb(245, 246, 250);

            // ── Top Panel ──
            pnlTop = new Panel();
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 62;
            pnlTop.BackColor = Color.White;

            Label lblTitle = new Label();
            lblTitle.Text = "📋  My Service Request Status";
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(41, 44, 51);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(18, 16);

            Label lblFilter = new Label();
            lblFilter.Text = "Filter:";
            lblFilter.Font = new Font("Segoe UI", 10F);
            lblFilter.ForeColor = Color.FromArgb(100, 100, 100);
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(370, 22);

            cmbFilter = new ComboBox();
            cmbFilter.Items.AddRange(new object[] { "All", "Pending", "Approved", "Rejected" });
            cmbFilter.SelectedIndex = 0;
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Font = new Font("Segoe UI", 10F);
            cmbFilter.Location = new Point(418, 19);
            cmbFilter.Width = 130;
            cmbFilter.SelectedIndexChanged += (s, e) => LoadServiceStatuses();

            btnRefresh = new Button();
            btnRefresh.Text = "↻  Refresh";
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.BackColor = Color.FromArgb(41, 128, 185);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Size = new Size(95, 30);
            btnRefresh.Location = new Point(562, 16);
            btnRefresh.Click += (s, e) => LoadServiceStatuses();

            pnlTop.Controls.AddRange(new Control[] { lblTitle, lblFilter, cmbFilter, btnRefresh });

            // ── Stats Panel ──
            pnlStats = new Panel();
            pnlStats.Dock = DockStyle.Top;
            pnlStats.Height = 80;
            pnlStats.BackColor = Color.FromArgb(245, 246, 250);

            Panel cardPending = CreateStatCard("⏳  Pending", "0", Color.FromArgb(243, 156, 18), out lblPendingCount);
            Panel cardApproved = CreateStatCard("✔  Approved", "0", Color.FromArgb(39, 174, 96), out lblApprovedCount);
            Panel cardRejected = CreateStatCard("✘  Rejected", "0", Color.FromArgb(192, 57, 43), out lblRejectedCount);

            cardPending.Location = new Point(15, 10);
            cardApproved.Location = new Point(225, 10);
            cardRejected.Location = new Point(435, 10);

            pnlStats.Controls.AddRange(new Control[] { cardPending, cardApproved, cardRejected });

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

            dgvServices.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            dgvServices.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvServices.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvServices.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvServices.EnableHeadersVisualStyles = false;
            dgvServices.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);
            dgvServices.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 238, 245);

            // ── Bottom status bar ──
            pnlBottom = new Panel();
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Height = 36;
            pnlBottom.BackColor = Color.White;

            Label lblRowCount = new Label();
            lblRowCount.Name = "lblRowCount";
            lblRowCount.Text = "";
            lblRowCount.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblRowCount.ForeColor = Color.FromArgb(120, 120, 120);
            lblRowCount.AutoSize = true;
            lblRowCount.Location = new Point(18, 10);
            pnlBottom.Controls.Add(lblRowCount);

            // ── Assemble ──
            this.Controls.Add(dgvServices);
            this.Controls.Add(pnlStats);
            this.Controls.Add(pnlBottom);
            this.Controls.Add(pnlTop);
        }

        private Panel CreateStatCard(string title, string count, Color accentColor, out Label countLabel)
        {
            Panel card = new Panel();
            card.Size = new Size(195, 58);
            card.BackColor = Color.White;

            Panel accent = new Panel();
            accent.Size = new Size(6, 58);
            accent.Location = new Point(0, 0);
            accent.BackColor = accentColor;

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 9F);
            lblTitle.ForeColor = Color.FromArgb(120, 120, 120);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(14, 8);

            countLabel = new Label();
            countLabel.Text = count;
            countLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            countLabel.ForeColor = accentColor;
            countLabel.AutoSize = true;
            countLabel.Location = new Point(14, 26);

            card.Controls.AddRange(new Control[] { accent, lblTitle, countLabel });
            return card;
        }

        private void LoadServiceStatuses()
        {
            try
            {
                string filterStatus = cmbFilter.SelectedItem?.ToString() ?? "All";
                string whereClause = filterStatus == "All" ? "" : "AND sa.Status = @Status";

                string query = $@"
                    SELECT
                        sa.ApprovalID,
                        sa.RentalID        AS [Rental ID],
                        r.CustomerFullName AS [Customer],
                        r.PlateNumber      AS [Car],
                        sa.ServiceName     AS [Service],
                        sa.DailyRate       AS [Rate/Day],
                        sa.RentalDays      AS [Days],
                        sa.TotalServiceCost AS [Total Cost],
                        sa.Status,
                        sa.RequestedDate   AS [Requested On],
                        sa.ReviewedDate    AS [Reviewed On],
                        ISNULL(sa.AdminRemarks, '—') AS [Admin Remarks]
                    FROM ServiceApprovals sa
                    INNER JOIN Rentals r ON sa.RentalID = r.RentalID
                    WHERE 1 = 1
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

                    // Load stat counts
                    using (SqlCommand countCmd = new SqlCommand(
                        "SELECT Status, COUNT(*) AS Cnt FROM ServiceApprovals GROUP BY Status", conn))
                    using (SqlDataReader r = countCmd.ExecuteReader())
                    {
                        lblPendingCount.Text = "0";
                        lblApprovedCount.Text = "0";
                        lblRejectedCount.Text = "0";

                        while (r.Read())
                        {
                            string status = r["Status"].ToString();
                            string cnt = r["Cnt"].ToString();
                            if (status == "Pending") lblPendingCount.Text = cnt;
                            if (status == "Approved") lblApprovedCount.Text = cnt;
                            if (status == "Rejected") lblRejectedCount.Text = cnt;
                        }
                    }
                }

                // Format columns
                if (dgvServices.Columns.Count > 0)
                {
                    if (dgvServices.Columns.Contains("ApprovalID"))
                        dgvServices.Columns["ApprovalID"].Visible = false;

                    if (dgvServices.Columns.Contains("Rate/Day"))
                        dgvServices.Columns["Rate/Day"].DefaultCellStyle.Format = "C2";
                    if (dgvServices.Columns.Contains("Total Cost"))
                        dgvServices.Columns["Total Cost"].DefaultCellStyle.Format = "C2";
                    if (dgvServices.Columns.Contains("Requested On"))
                        dgvServices.Columns["Requested On"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
                    if (dgvServices.Columns.Contains("Reviewed On"))
                        dgvServices.Columns["Reviewed On"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";

                    foreach (DataGridViewColumn col in dgvServices.Columns)
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    if (dgvServices.Columns.Contains("Customer"))
                        dgvServices.Columns["Customer"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    if (dgvServices.Columns.Contains("Service"))
                        dgvServices.Columns["Service"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    if (dgvServices.Columns.Contains("Admin Remarks"))
                        dgvServices.Columns["Admin Remarks"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                ColorRowsByStatus();

                var lbl = pnlBottom.Controls["lblRowCount"] as Label;
                if (lbl != null)
                    lbl.Text = $"Showing {dgvServices.Rows.Count} record(s).";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading service statuses: " + ex.Message,
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
    }
}