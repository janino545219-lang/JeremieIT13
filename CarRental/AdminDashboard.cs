using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CarRental
{
    public partial class AdminDashboard : Form
    {
        private Button currentButton;

        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            // Set form to fullscreen/maximized
            this.WindowState = FormWindowState.Maximized;
        }

        // Method to highlight active button
        private void HighlightButton(Button button)
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(41, 44, 51);
            }

            currentButton = button;
            currentButton.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void btnMechanicService_Click(object sender, EventArgs e)
        {
            HighlightButton(btnMechanicService);
            MessageBox.Show("Mechanic Service - Form not yet created", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Load MechanicService form/user control here
            // Example: LoadForm(new MechanicServiceForm());
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            HighlightButton(btnUserManagement);
            LoadForm(new UserManagementForm());
        }

        private void btnCarApproval_Click(object sender, EventArgs e)
        {
            HighlightButton(btnCarApproval);
            // Load Car Approval & Deletion Form
            LoadForm(new CarApprovalForm());
        }

        private void btnServiceApproval_Click(object sender, EventArgs e)
        {
            HighlightButton(btnServiceApproval);
            MessageBox.Show("Service Approval - Form not yet created", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Load ServiceApproval form/user control here
        }

        private void btnRentalPrice_Click(object sender, EventArgs e)
        {
            HighlightButton(btnRentalPrice);
            MessageBox.Show("Rental Price - Form not yet created", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Load RentalPrice form/user control here
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            HighlightButton(btnReports);
            MessageBox.Show("Reports - Form not yet created", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Load Reports form/user control here
        }

        private void btnTNC_Click(object sender, EventArgs e)
        {
            HighlightButton(btnTNC);
            MessageBox.Show("Terms & Conditions - Form not yet created", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Load TNC form/user control here
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            HighlightButton(btnPayments);
            MessageBox.Show("Payments - Form not yet created", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Load Payments form/user control here
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Close();
            }
        }

        // Method to load forms into the main panel
        private void LoadForm(Form form)
        {
            panelMain.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}