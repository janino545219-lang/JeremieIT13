using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CarRental
{
    public partial class StaffForms : Form
    {
        private Button currentButton;

        public StaffForms()
        {
            InitializeComponent();
        }

        private void StaffForms_Load(object sender, EventArgs e)
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

        private void btnCreateCarRent_Click(object sender, EventArgs e)
        {
            HighlightButton(btnCreateCarRent);
            try
            {
                CreateCarRentalForm rentalForm = new CreateCarRentalForm();
                LoadForm(rentalForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Car Rental Form: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            HighlightButton(btnAddCustomer);
            // Load Customer Management Form inside the main panel
            try
            {
                CustomerManagementForm customerForm = new CustomerManagementForm();
                LoadForm(customerForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Customer Management: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturnCarRent_Click(object sender, EventArgs e)
        {
            HighlightButton(btnReturnCarRent);
            try
            {
                ReturnCarForm returnForm = new ReturnCarForm();
                LoadForm(returnForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Return Car Form: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            HighlightButton(btnPayment);
            MessageBox.Show(
                "To process a payment:\n\n" +
                "1. Click 'Create Car Rent'\n" +
                "2. Create a rental\n" +
                "3. Payment form opens automatically",
                "Payment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
            // Clear any existing controls in the panel
            panelMain.Controls.Clear();

            // Configure the form to be embedded in the panel
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Add the form to the panel and show it
            panelMain.Controls.Add(form);
            panelMain.Tag = form;
            form.Show();
        }
    }
}