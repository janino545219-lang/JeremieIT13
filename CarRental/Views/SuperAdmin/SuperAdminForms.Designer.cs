namespace CarRental
{
    partial class SuperAdminForms
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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.lblPanelTitle = new System.Windows.Forms.Label();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnTNC = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.panelLogout = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();

            this.panelSidebar.SuspendLayout();
            this.panelLogout.SuspendLayout();
            this.SuspendLayout();

            // ── panelSidebar ──────────────────────────────────────────
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(41, 44, 51);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Width = 220;
            this.panelSidebar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblPanelTitle,
                this.btnUserManagement,
                this.btnReports,
                this.btnTNC,
                this.btnPayments,
                this.panelLogout
            });

            // ── lblPanelTitle ─────────────────────────────────────────
            this.lblPanelTitle.AutoSize = false;
            this.lblPanelTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPanelTitle.ForeColor = System.Drawing.Color.White;
            this.lblPanelTitle.BackColor = System.Drawing.Color.FromArgb(30, 33, 39);
            this.lblPanelTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPanelTitle.Size = new System.Drawing.Size(220, 60);
            this.lblPanelTitle.Text = "  Super Admin";
            this.lblPanelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── Sidebar nav buttons ───────────────────────────────────
            SetupSidebarButton(this.btnUserManagement, "👤  User Management", 68);
            SetupSidebarButton(this.btnReports, "📊  Reports", 113);
            SetupSidebarButton(this.btnTNC, "📄  Terms & Conditions", 158);
            SetupSidebarButton(this.btnPayments, "💳  Payments", 203);

            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            this.btnTNC.Click += new System.EventHandler(this.btnTNC_Click);
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);

            // ── panelLogout (separator line + logout button) ──────────
            // This panel is docked to the BOTTOM of panelSidebar
            // so it is always visible regardless of child form height
            this.panelLogout.BackColor = System.Drawing.Color.FromArgb(30, 33, 39);
            this.panelLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLogout.Height = 55;
            this.panelLogout.Controls.Add(this.btnLogout);

            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(30, 33, 39);
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.Text = "🚪  Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // ── panelMain ─────────────────────────────────────────────
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;

            // ── SuperAdminForms ───────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSidebar);
            this.Name = "SuperAdminForms";
            this.Text = "Super Admin Dashboard - Car Rental System";
            this.Load += new System.EventHandler(this.SuperAdminForms_Load);

            this.panelLogout.ResumeLayout(false);
            this.panelSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void SetupSidebarButton(System.Windows.Forms.Button btn, string text, int top)
        {
            btn.BackColor = System.Drawing.Color.FromArgb(41, 44, 51);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            btn.ForeColor = System.Drawing.Color.White;
            btn.Location = new System.Drawing.Point(0, top);
            btn.Size = new System.Drawing.Size(220, 40);
            btn.Text = text;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelLogout;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblPanelTitle;
        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnTNC;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnLogout;
    }
}