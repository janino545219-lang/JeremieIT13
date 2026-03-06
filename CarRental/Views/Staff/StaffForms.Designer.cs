namespace CarRental
{
    partial class StaffForms
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            btnLogout = new Button();
            btnServiceStatus = new Button(); // NEW
            btnPayment = new Button();
            btnReturnCarRent = new Button();
            btnAddCustomer = new Button();
            btnCreateCarRent = new Button();
            panelLogo = new Panel();
            lblStaffPanel = new Label();
            panelMain = new Panel();
            lblWelcome = new Label();
            panelSidebar.SuspendLayout();
            panelLogo.SuspendLayout();
            panelMain.SuspendLayout();
            SuspendLayout();

            // panelSidebar
            panelSidebar.BackColor = Color.FromArgb(41, 44, 51);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(btnServiceStatus); // NEW
            panelSidebar.Controls.Add(btnPayment);
            panelSidebar.Controls.Add(btnReturnCarRent);
            panelSidebar.Controls.Add(btnAddCustomer);
            panelSidebar.Controls.Add(btnCreateCarRent);
            panelSidebar.Controls.Add(panelLogo);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(250, 768);
            panelSidebar.TabIndex = 0;

            // btnLogout
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Image = new Bitmap(Properties.Resources.enter, new Size(20, 20));
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.Location = new Point(0, 524);
            btnLogout.Margin = new Padding(3, 2, 3, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(15, 0, 0, 0);
            btnLogout.Size = new Size(219, 38);
            btnLogout.TabIndex = 9;
            btnLogout.Text = " Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;

            // btnServiceStatus (NEW — appears after Payment)
            btnServiceStatus.Dock = DockStyle.Top;
            btnServiceStatus.FlatAppearance.BorderSize = 0;
            btnServiceStatus.FlatStyle = FlatStyle.Flat;
            btnServiceStatus.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnServiceStatus.ForeColor = Color.White;
            btnServiceStatus.Location = new Point(0, 330);
            btnServiceStatus.Name = "btnServiceStatus";
            btnServiceStatus.Padding = new Padding(10, 0, 0, 0);
            btnServiceStatus.Size = new Size(250, 50);
            btnServiceStatus.TabIndex = 5;
            btnServiceStatus.Text = "📋 Service Status";
            btnServiceStatus.TextAlign = ContentAlignment.MiddleLeft;
            btnServiceStatus.UseVisualStyleBackColor = true;
            btnServiceStatus.Click += btnServiceStatus_Click;

            // btnPayment
            btnPayment.Dock = DockStyle.Top;
            btnPayment.FlatAppearance.BorderSize = 0;
            btnPayment.FlatStyle = FlatStyle.Flat;
            btnPayment.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnPayment.ForeColor = Color.White;
            btnPayment.Location = new Point(0, 280);
            btnPayment.Name = "btnPayment";
            btnPayment.Padding = new Padding(10, 0, 0, 0);
            btnPayment.Size = new Size(250, 50);
            btnPayment.TabIndex = 4;
            btnPayment.Text = "💳 Payment";
            btnPayment.TextAlign = ContentAlignment.MiddleLeft;
            btnPayment.UseVisualStyleBackColor = true;
            btnPayment.Click += btnPayment_Click;

            // btnReturnCarRent
            btnReturnCarRent.Dock = DockStyle.Top;
            btnReturnCarRent.FlatAppearance.BorderSize = 0;
            btnReturnCarRent.FlatStyle = FlatStyle.Flat;
            btnReturnCarRent.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnReturnCarRent.ForeColor = Color.White;
            btnReturnCarRent.Location = new Point(0, 230);
            btnReturnCarRent.Name = "btnReturnCarRent";
            btnReturnCarRent.Padding = new Padding(10, 0, 0, 0);
            btnReturnCarRent.Size = new Size(250, 50);
            btnReturnCarRent.TabIndex = 3;
            btnReturnCarRent.Text = "🔄 Return Car Rent";
            btnReturnCarRent.TextAlign = ContentAlignment.MiddleLeft;
            btnReturnCarRent.UseVisualStyleBackColor = true;
            btnReturnCarRent.Click += btnReturnCarRent_Click;

            // btnAddCustomer
            btnAddCustomer.Dock = DockStyle.Top;
            btnAddCustomer.FlatAppearance.BorderSize = 0;
            btnAddCustomer.FlatStyle = FlatStyle.Flat;
            btnAddCustomer.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddCustomer.ForeColor = Color.White;
            btnAddCustomer.Location = new Point(0, 180);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Padding = new Padding(10, 0, 0, 0);
            btnAddCustomer.Size = new Size(250, 50);
            btnAddCustomer.TabIndex = 2;
            btnAddCustomer.Text = "👤 Add Customer";
            btnAddCustomer.TextAlign = ContentAlignment.MiddleLeft;
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click;

            // btnCreateCarRent
            btnCreateCarRent.Dock = DockStyle.Top;
            btnCreateCarRent.FlatAppearance.BorderSize = 0;
            btnCreateCarRent.FlatStyle = FlatStyle.Flat;
            btnCreateCarRent.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreateCarRent.ForeColor = Color.White;
            btnCreateCarRent.Location = new Point(0, 130);
            btnCreateCarRent.Name = "btnCreateCarRent";
            btnCreateCarRent.Padding = new Padding(10, 0, 0, 0);
            btnCreateCarRent.Size = new Size(250, 50);
            btnCreateCarRent.TabIndex = 1;
            btnCreateCarRent.Text = "🚗 Create Car Rent";
            btnCreateCarRent.TextAlign = ContentAlignment.MiddleLeft;
            btnCreateCarRent.UseVisualStyleBackColor = true;
            btnCreateCarRent.Click += btnCreateCarRent_Click;

            // panelLogo
            panelLogo.BackColor = Color.FromArgb(30, 33, 38);
            panelLogo.Controls.Add(lblStaffPanel);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(250, 130);
            panelLogo.TabIndex = 0;

            // lblStaffPanel
            lblStaffPanel.AutoSize = true;
            lblStaffPanel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblStaffPanel.ForeColor = Color.White;
            lblStaffPanel.Location = new Point(35, 45);
            lblStaffPanel.Name = "lblStaffPanel";
            lblStaffPanel.Size = new Size(165, 41);
            lblStaffPanel.TabIndex = 0;
            lblStaffPanel.Text = "Staff Panel";

            // panelMain
            panelMain.BackColor = Color.WhiteSmoke;
            panelMain.Controls.Add(lblWelcome);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(250, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1174, 768);
            panelMain.TabIndex = 1;

            // lblWelcome
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblWelcome.ForeColor = Color.FromArgb(64, 64, 64);
            lblWelcome.Location = new Point(50, 50);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(525, 54);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome to Staff Dashboard";

            // StaffForms
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1424, 768);
            Controls.Add(panelMain);
            Controls.Add(panelSidebar);
            Name = "StaffForms";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Staff Dashboard - Car Rental System";
            WindowState = FormWindowState.Maximized;
            Load += StaffForms_Load;
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
        private Label lblStaffPanel;
        private Button btnCreateCarRent;
        private Button btnAddCustomer;
        private Button btnReturnCarRent;
        private Button btnPayment;
        private Button btnServiceStatus; // NEW
        private Button btnLogout;
        private Panel panelMain;
        private Label lblWelcome;
    }
}