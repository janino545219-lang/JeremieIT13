namespace CarRental
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            btnLogout = new Button();
            btnPayments = new Button();
            btnTNC = new Button();
            btnReports = new Button();
            btnRentalPrice = new Button();
            btnServiceApproval = new Button();
            btnCarApproval = new Button();
            btnUserManagement = new Button();
            btnMechanicService = new Button();
            panelLogo = new Panel();
            lblAdminPanel = new Label();
            panelMain = new Panel();
            lblWelcome = new Label();
            panelSidebar.SuspendLayout();
            panelLogo.SuspendLayout();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(41, 44, 51);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(btnPayments);
            panelSidebar.Controls.Add(btnTNC);
            panelSidebar.Controls.Add(btnReports);
            panelSidebar.Controls.Add(btnRentalPrice);
            panelSidebar.Controls.Add(btnServiceApproval);
            panelSidebar.Controls.Add(btnCarApproval);
            panelSidebar.Controls.Add(btnUserManagement);
            panelSidebar.Controls.Add(btnMechanicService);
            panelSidebar.Controls.Add(panelLogo);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(3, 2, 3, 2);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(219, 562);
            panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 524);
            btnLogout.Margin = new Padding(3, 2, 3, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(9, 0, 0, 0);
            btnLogout.Size = new Size(219, 38);
            btnLogout.TabIndex = 9;
            btnLogout.Text = "🚪 Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnPayments
            // 
            btnPayments.Dock = DockStyle.Top;
            btnPayments.FlatAppearance.BorderSize = 0;
            btnPayments.FlatStyle = FlatStyle.Flat;
            btnPayments.Font = new Font("Segoe UI", 11F);
            btnPayments.ForeColor = Color.White;
            btnPayments.Location = new Point(0, 364);
            btnPayments.Margin = new Padding(3, 2, 3, 2);
            btnPayments.Name = "btnPayments";
            btnPayments.Padding = new Padding(9, 0, 0, 0);
            btnPayments.Size = new Size(219, 38);
            btnPayments.TabIndex = 8;
            btnPayments.Text = "💳 Payments";
            btnPayments.TextAlign = ContentAlignment.MiddleLeft;
            btnPayments.UseVisualStyleBackColor = true;
            btnPayments.Click += btnPayments_Click;
            // 
            // btnTNC
            // 
            btnTNC.Dock = DockStyle.Top;
            btnTNC.FlatAppearance.BorderSize = 0;
            btnTNC.FlatStyle = FlatStyle.Flat;
            btnTNC.Font = new Font("Segoe UI", 11F);
            btnTNC.ForeColor = Color.White;
            btnTNC.Location = new Point(0, 326);
            btnTNC.Margin = new Padding(3, 2, 3, 2);
            btnTNC.Name = "btnTNC";
            btnTNC.Padding = new Padding(9, 0, 0, 0);
            btnTNC.Size = new Size(219, 38);
            btnTNC.TabIndex = 7;
            btnTNC.Text = "📋 Terms & Conditions";
            btnTNC.TextAlign = ContentAlignment.MiddleLeft;
            btnTNC.UseVisualStyleBackColor = true;
            btnTNC.Click += btnTNC_Click;
            // 
            // btnReports
            // 
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 11F);
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(0, 288);
            btnReports.Margin = new Padding(3, 2, 3, 2);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(9, 0, 0, 0);
            btnReports.Size = new Size(219, 38);
            btnReports.TabIndex = 6;
            btnReports.Text = "📊 Reports";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnRentalPrice
            // 
            btnRentalPrice.Dock = DockStyle.Top;
            btnRentalPrice.FlatAppearance.BorderSize = 0;
            btnRentalPrice.FlatStyle = FlatStyle.Flat;
            btnRentalPrice.Font = new Font("Segoe UI", 11F);
            btnRentalPrice.ForeColor = Color.White;
            btnRentalPrice.Location = new Point(0, 250);
            btnRentalPrice.Margin = new Padding(3, 2, 3, 2);
            btnRentalPrice.Name = "btnRentalPrice";
            btnRentalPrice.Padding = new Padding(9, 0, 0, 0);
            btnRentalPrice.Size = new Size(219, 38);
            btnRentalPrice.TabIndex = 5;
            btnRentalPrice.Text = "💰 Rental Price";
            btnRentalPrice.TextAlign = ContentAlignment.MiddleLeft;
            btnRentalPrice.UseVisualStyleBackColor = true;
            btnRentalPrice.Click += btnRentalPrice_Click;
            // 
            // btnServiceApproval
            // 
            btnServiceApproval.Dock = DockStyle.Top;
            btnServiceApproval.FlatAppearance.BorderSize = 0;
            btnServiceApproval.FlatStyle = FlatStyle.Flat;
            btnServiceApproval.Font = new Font("Segoe UI", 11F);
            btnServiceApproval.ForeColor = Color.White;
            btnServiceApproval.Location = new Point(0, 212);
            btnServiceApproval.Margin = new Padding(3, 2, 3, 2);
            btnServiceApproval.Name = "btnServiceApproval";
            btnServiceApproval.Padding = new Padding(9, 0, 0, 0);
            btnServiceApproval.Size = new Size(219, 38);
            btnServiceApproval.TabIndex = 4;
            btnServiceApproval.Text = "✅ Service Approval";
            btnServiceApproval.TextAlign = ContentAlignment.MiddleLeft;
            btnServiceApproval.UseVisualStyleBackColor = true;
            btnServiceApproval.Click += btnServiceApproval_Click;
            // 
            // btnCarApproval
            // 
            btnCarApproval.Dock = DockStyle.Top;
            btnCarApproval.FlatAppearance.BorderSize = 0;
            btnCarApproval.FlatStyle = FlatStyle.Flat;
            btnCarApproval.Font = new Font("Segoe UI", 11F);
            btnCarApproval.ForeColor = Color.White;
            btnCarApproval.Location = new Point(0, 174);
            btnCarApproval.Margin = new Padding(3, 2, 3, 2);
            btnCarApproval.Name = "btnCarApproval";
            btnCarApproval.Padding = new Padding(9, 0, 0, 0);
            btnCarApproval.Size = new Size(219, 38);
            btnCarApproval.TabIndex = 3;
            btnCarApproval.Text = "🚗 Car Approval && Deletion";
            btnCarApproval.TextAlign = ContentAlignment.MiddleLeft;
            btnCarApproval.UseVisualStyleBackColor = true;
            btnCarApproval.Click += btnCarApproval_Click;
            // 
            // btnUserManagement
            // 
            btnUserManagement.Dock = DockStyle.Top;
            btnUserManagement.FlatAppearance.BorderSize = 0;
            btnUserManagement.FlatStyle = FlatStyle.Flat;
            btnUserManagement.Font = new Font("Segoe UI", 11F);
            btnUserManagement.ForeColor = Color.White;
            btnUserManagement.Location = new Point(0, 136);
            btnUserManagement.Margin = new Padding(3, 2, 3, 2);
            btnUserManagement.Name = "btnUserManagement";
            btnUserManagement.Padding = new Padding(9, 0, 0, 0);
            btnUserManagement.Size = new Size(219, 38);
            btnUserManagement.TabIndex = 2;
            btnUserManagement.Text = "👥 User Management";
            btnUserManagement.TextAlign = ContentAlignment.MiddleLeft;
            btnUserManagement.UseVisualStyleBackColor = true;
            btnUserManagement.Click += btnUserManagement_Click;
            // 
            // btnMechanicService
            // 
            btnMechanicService.Dock = DockStyle.Top;
            btnMechanicService.FlatAppearance.BorderSize = 0;
            btnMechanicService.FlatStyle = FlatStyle.Flat;
            btnMechanicService.Font = new Font("Segoe UI", 11F);
            btnMechanicService.ForeColor = Color.White;
            btnMechanicService.Location = new Point(0, 98);
            btnMechanicService.Margin = new Padding(3, 2, 3, 2);
            btnMechanicService.Name = "btnMechanicService";
            btnMechanicService.Padding = new Padding(9, 0, 0, 0);
            btnMechanicService.Size = new Size(219, 38);
            btnMechanicService.TabIndex = 1;
            btnMechanicService.Text = "🔧 Mechanic Service";
            btnMechanicService.TextAlign = ContentAlignment.MiddleLeft;
            btnMechanicService.UseVisualStyleBackColor = true;
            btnMechanicService.Click += btnMechanicService_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(30, 33, 38);
            panelLogo.Controls.Add(lblAdminPanel);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(3, 2, 3, 2);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(219, 98);
            panelLogo.TabIndex = 0;
            // 
            // lblAdminPanel
            // 
            lblAdminPanel.AutoSize = true;
            lblAdminPanel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAdminPanel.ForeColor = Color.White;
            lblAdminPanel.Location = new Point(22, 34);
            lblAdminPanel.Name = "lblAdminPanel";
            lblAdminPanel.Size = new Size(159, 32);
            lblAdminPanel.TabIndex = 0;
            lblAdminPanel.Text = "Admin Panel";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.WhiteSmoke;
            panelMain.Controls.Add(lblWelcome);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(219, 0);
            panelMain.Margin = new Padding(3, 2, 3, 2);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(980, 562);
            panelMain.TabIndex = 1;
            // 
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 562);
            Controls.Add(panelMain);
            Controls.Add(panelSidebar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AdminDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard - Car Rental System";
            WindowState = FormWindowState.Maximized;
            Load += AdminDashboard_Load;
            panelSidebar.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Panel panelLogo;
        private Label lblAdminPanel;
        private Button btnMechanicService;
        private Button btnUserManagement;
        private Button btnCarApproval;
        private Button btnServiceApproval;
        private Button btnRentalPrice;
        private Button btnReports;
        private Button btnTNC;
        private Button btnPayments;
        private Button btnLogout;
        private Panel panelMain;
        private Label lblWelcome;
    }
}