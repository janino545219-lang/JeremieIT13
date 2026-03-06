namespace CarRental
{
    partial class CarMaintenanceForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvMaintenance = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnStartMaintenance = new System.Windows.Forms.Button();
            this.btnMarkComplete = new System.Windows.Forms.Button();
            this.btnCancelRecord = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvMaintenance)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();

            // ── pnlTop (fixed height top area) ───────────────────────────
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 160;
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Size = new System.Drawing.Size(500, 45);
            this.lblTitle.Text = "Car Maintenance";

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblSearch.Location = new System.Drawing.Point(20, 72);
            this.lblSearch.Text = "Search:";

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(20, 92);
            this.txtSearch.Size = new System.Drawing.Size(420, 26);
            this.txtSearch.PlaceholderText = "Search by plate number, type, technician...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.lblTotal.Location = new System.Drawing.Point(20, 130);
            this.lblTotal.Text = "Total Records: 0";

            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.lblTotal);

            // ── pnlBottom (fixed height bottom buttons) ───────────────────
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 64;
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);

            // btnRefresh
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(110, 115, 130);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Text = "⟳ Refresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 40);
            this.btnRefresh.Location = new System.Drawing.Point(20, 12);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnCancelRecord
            this.btnCancelRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelRecord.FlatAppearance.BorderSize = 0;
            this.btnCancelRecord.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnCancelRecord.ForeColor = System.Drawing.Color.White;
            this.btnCancelRecord.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelRecord.Text = "✘ Cancel";
            this.btnCancelRecord.Size = new System.Drawing.Size(120, 40);
            this.btnCancelRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelRecord.Enabled = false;
            this.btnCancelRecord.Click += new System.EventHandler(this.btnCancelRecord_Click);

            // btnMarkComplete
            this.btnMarkComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkComplete.FlatAppearance.BorderSize = 0;
            this.btnMarkComplete.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnMarkComplete.ForeColor = System.Drawing.Color.White;
            this.btnMarkComplete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMarkComplete.Text = "✔ Mark Completed";
            this.btnMarkComplete.Size = new System.Drawing.Size(165, 40);
            this.btnMarkComplete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarkComplete.Enabled = false;
            this.btnMarkComplete.Click += new System.EventHandler(this.btnMarkComplete_Click);

            // btnStartMaintenance
            this.btnStartMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartMaintenance.FlatAppearance.BorderSize = 0;
            this.btnStartMaintenance.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnStartMaintenance.ForeColor = System.Drawing.Color.White;
            this.btnStartMaintenance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStartMaintenance.Text = "➕ New Maintenance";
            this.btnStartMaintenance.Size = new System.Drawing.Size(175, 40);
            this.btnStartMaintenance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartMaintenance.Click += new System.EventHandler(this.btnStartMaintenance_Click);

            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnCancelRecord);
            this.pnlBottom.Controls.Add(this.btnMarkComplete);
            this.pnlBottom.Controls.Add(this.btnStartMaintenance);

            // ── dgvMaintenance (fills remaining middle space) ─────────────
            this.dgvMaintenance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaintenance.AllowUserToAddRows = false;
            this.dgvMaintenance.AllowUserToDeleteRows = false;
            this.dgvMaintenance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaintenance.BackgroundColor = System.Drawing.Color.White;
            this.dgvMaintenance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMaintenance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMaintenance.ColumnHeadersHeight = 40;
            this.dgvMaintenance.EnableHeadersVisualStyles = false;
            this.dgvMaintenance.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.dgvMaintenance.MultiSelect = false;
            this.dgvMaintenance.ReadOnly = true;
            this.dgvMaintenance.RowHeadersVisible = false;
            this.dgvMaintenance.RowTemplate.Height = 30;
            this.dgvMaintenance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaintenance.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.dgvMaintenance.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMaintenance.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvMaintenance.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.dgvMaintenance.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvMaintenance.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.dgvMaintenance.RowsDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvMaintenance.RowsDefaultCellStyle.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.dgvMaintenance.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 246, 255);
            this.dgvMaintenance.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.dgvMaintenance.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMaintenance.GridColor = System.Drawing.Color.FromArgb(220, 225, 235);
            this.dgvMaintenance.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMaintenance_CellFormatting);
            this.dgvMaintenance.SelectionChanged += new System.EventHandler(this.dgvMaintenance_SelectionChanged);

            // ── CarMaintenanceForm ────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 750);
            this.Controls.Add(this.dgvMaintenance);   // Fill — goes in middle
            this.Controls.Add(this.pnlBottom);        // Bottom
            this.Controls.Add(this.pnlTop);           // Top (added last so it renders on top)
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "CarMaintenanceForm";
            this.Text = "Car Maintenance";
            this.Load += new System.EventHandler(this.CarMaintenanceForm_Load);
            this.Resize += new System.EventHandler(this.CarMaintenanceForm_Resize);

            ((System.ComponentModel.ISupportInitialize)(this.dgvMaintenance)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvMaintenance;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnStartMaintenance;
        private System.Windows.Forms.Button btnMarkComplete;
        private System.Windows.Forms.Button btnCancelRecord;
    }
}