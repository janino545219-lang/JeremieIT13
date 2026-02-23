namespace CarRental
{
    partial class ManagerForms
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
            btnMechanicService = new Button();
            btnCreateService = new Button();
            btnCarMaintenance = new Button();
            btnArchiveCars = new Button();
            btnAddCars = new Button();
            panelLogo = new Panel();
            lblManagerPanel = new Label();
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
            panelSidebar.Controls.Add(btnMechanicService);
            panelSidebar.Controls.Add(btnCreateService);
            panelSidebar.Controls.Add(btnCarMaintenance);
            panelSidebar.Controls.Add(btnArchiveCars);
            panelSidebar.Controls.Add(btnAddCars);
            panelSidebar.Controls.Add(panelLogo);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(250, 768);
            panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 718);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(10, 0, 0, 0);
            btnLogout.Size = new Size(250, 50);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "🚪 Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnMechanicService
            // 
            btnMechanicService.Dock = DockStyle.Top;
            btnMechanicService.FlatAppearance.BorderSize = 0;
            btnMechanicService.FlatStyle = FlatStyle.Flat;
            btnMechanicService.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnMechanicService.ForeColor = Color.White;
            btnMechanicService.Location = new Point(0, 330);
            btnMechanicService.Name = "btnMechanicService";
            btnMechanicService.Padding = new Padding(10, 0, 0, 0);
            btnMechanicService.Size = new Size(250, 50);
            btnMechanicService.TabIndex = 5;
            btnMechanicService.Text = "🔧 Mechanic Service";
            btnMechanicService.TextAlign = ContentAlignment.MiddleLeft;
            btnMechanicService.UseVisualStyleBackColor = true;
            btnMechanicService.Click += btnMechanicService_Click;
            // 
            // btnCreateService
            // 
            btnCreateService.Dock = DockStyle.Top;
            btnCreateService.FlatAppearance.BorderSize = 0;
            btnCreateService.FlatStyle = FlatStyle.Flat;
            btnCreateService.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreateService.ForeColor = Color.White;
            btnCreateService.Location = new Point(0, 280);
            btnCreateService.Name = "btnCreateService";
            btnCreateService.Padding = new Padding(10, 0, 0, 0);
            btnCreateService.Size = new Size(250, 50);
            btnCreateService.TabIndex = 4;
            btnCreateService.Text = "➕ Create Service";
            btnCreateService.TextAlign = ContentAlignment.MiddleLeft;
            btnCreateService.UseVisualStyleBackColor = true;
            btnCreateService.Click += btnCreateService_Click;
            // 
            // btnCarMaintenance
            // 
            btnCarMaintenance.Dock = DockStyle.Top;
            btnCarMaintenance.FlatAppearance.BorderSize = 0;
            btnCarMaintenance.FlatStyle = FlatStyle.Flat;
            btnCarMaintenance.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnCarMaintenance.ForeColor = Color.White;
            btnCarMaintenance.Location = new Point(0, 230);
            btnCarMaintenance.Name = "btnCarMaintenance";
            btnCarMaintenance.Padding = new Padding(10, 0, 0, 0);
            btnCarMaintenance.Size = new Size(250, 50);
            btnCarMaintenance.TabIndex = 3;
            btnCarMaintenance.Text = "🔨 Car Maintenance";
            btnCarMaintenance.TextAlign = ContentAlignment.MiddleLeft;
            btnCarMaintenance.UseVisualStyleBackColor = true;
            btnCarMaintenance.Click += btnCarMaintenance_Click;
            // 
            // btnArchiveCars
            // 
            btnArchiveCars.Dock = DockStyle.Top;
            btnArchiveCars.FlatAppearance.BorderSize = 0;
            btnArchiveCars.FlatStyle = FlatStyle.Flat;
            btnArchiveCars.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnArchiveCars.ForeColor = Color.White;
            btnArchiveCars.Location = new Point(0, 180);
            btnArchiveCars.Name = "btnArchiveCars";
            btnArchiveCars.Padding = new Padding(10, 0, 0, 0);
            btnArchiveCars.Size = new Size(250, 50);
            btnArchiveCars.TabIndex = 2;
            btnArchiveCars.Text = "📦 Archive Cars";
            btnArchiveCars.TextAlign = ContentAlignment.MiddleLeft;
            btnArchiveCars.UseVisualStyleBackColor = true;
            btnArchiveCars.Click += btnArchiveCars_Click;
            // 
            // btnAddCars
            // 
            btnAddCars.Dock = DockStyle.Top;
            btnAddCars.FlatAppearance.BorderSize = 0;
            btnAddCars.FlatStyle = FlatStyle.Flat;
            btnAddCars.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddCars.ForeColor = Color.White;
            btnAddCars.Location = new Point(0, 130);
            btnAddCars.Name = "btnAddCars";
            btnAddCars.Padding = new Padding(10, 0, 0, 0);
            btnAddCars.Size = new Size(250, 50);
            btnAddCars.TabIndex = 1;
            btnAddCars.Text = "🚗 Add Cars";
            btnAddCars.TextAlign = ContentAlignment.MiddleLeft;
            btnAddCars.UseVisualStyleBackColor = true;
            btnAddCars.Click += btnAddCars_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(30, 33, 38);
            panelLogo.Controls.Add(lblManagerPanel);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(250, 130);
            panelLogo.TabIndex = 0;
            // 
            // lblManagerPanel
            // 
            lblManagerPanel.AutoSize = true;
            lblManagerPanel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblManagerPanel.ForeColor = Color.White;
            lblManagerPanel.Location = new Point(20, 45);
            lblManagerPanel.Name = "lblManagerPanel";
            lblManagerPanel.Size = new Size(212, 41);
            lblManagerPanel.TabIndex = 0;
            lblManagerPanel.Text = "Manager Panel";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.WhiteSmoke;
            panelMain.Controls.Add(lblWelcome);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(250, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1174, 768);
            panelMain.TabIndex = 1;
            // 
            // ManagerForms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1424, 768);
            Controls.Add(panelMain);
            Controls.Add(panelSidebar);
            Name = "ManagerForms";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manager Dashboard - Car Rental System";
            WindowState = FormWindowState.Maximized;
            Load += ManagerForms_Load;
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
        private Label lblManagerPanel;
        private Button btnAddCars;
        private Button btnArchiveCars;
        private Button btnCarMaintenance;
        private Button btnCreateService;
        private Button btnMechanicService;
        private Button btnLogout;
        private Panel panelMain;
        private Label lblWelcome;
    }
}