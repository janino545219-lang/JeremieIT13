namespace CarRental
{
    partial class ArchiveCarsForm
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
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvArchivedCars = new System.Windows.Forms.DataGridView();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivedCars)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.None;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(41, 44, 51);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size = new System.Drawing.Size(500, 45);
            this.lblTitle.Text = "Archived Cars";

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSearch.Location = new System.Drawing.Point(20, 85);
            this.lblSearch.Text = "Search:";

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(20, 108);
            this.txtSearch.Size = new System.Drawing.Size(400, 28);
            this.txtSearch.PlaceholderText = "Search by plate number, maker, or model...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // lblCount
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.lblCount.Location = new System.Drawing.Point(20, 148);
            this.lblCount.Text = "Total Archived Cars: 0";

            // dgvArchivedCars
            this.dgvArchivedCars.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.dgvArchivedCars.Location = new System.Drawing.Point(20, 178);
            this.dgvArchivedCars.Size = new System.Drawing.Size(1260, 450);
            this.dgvArchivedCars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArchivedCars.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArchivedCars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArchivedCars.MultiSelect = false;
            this.dgvArchivedCars.ReadOnly = true;
            this.dgvArchivedCars.AllowUserToAddRows = false;
            this.dgvArchivedCars.SelectionChanged += new System.EventHandler(this.dgvArchivedCars_SelectionChanged);

            // btnRefresh
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(20, 648);
            this.btnRefresh.Size = new System.Drawing.Size(150, 45);
            this.btnRefresh.Text = "⟳ Refresh";
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnRestore
            this.btnRestore.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(1130, 648);
            this.btnRestore.Size = new System.Drawing.Size(150, 45);
            this.btnRestore.Text = "↩ Restore Car";
            this.btnRestore.Enabled = false;
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);

            // ArchiveCarsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1300, 720);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvArchivedCars);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRestore);
            this.Name = "ArchiveCarsForm";
            this.Text = "Archive Cars";
            this.Load += new System.EventHandler(this.ArchiveCarsForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivedCars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvArchivedCars;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnRefresh;
    }
}