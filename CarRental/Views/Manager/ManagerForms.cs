using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CarRental
{
    public partial class ManagerForms : Form
    {
        private Button currentButton;

        public ManagerForms()
        {
            InitializeComponent();
        }

        private void ManagerForms_Load(object sender, EventArgs e)
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

        private void btnAddCars_Click(object sender, EventArgs e)
        {
            HighlightButton(btnAddCars);
            LoadForm(new AddCarForm());
        }

        private void btnArchiveCars_Click(object sender, EventArgs e)
        {
            HighlightButton(btnArchiveCars);
            LoadForm(new ArchiveCarsForm()); // ← CHANGED: loads the new ArchiveCarsForm
        }

        private void btnCarMaintenance_Click(object sender, EventArgs e)
        {
            HighlightButton(btnCarMaintenance);
            LoadForm(new CarMaintenanceForm());
        }

        private void btnCreateService_Click(object sender, EventArgs e)
        {
            HighlightButton(btnCreateService);
            MessageBox.Show("Create Service - Form not yet created", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Load CreateService form/user control here
        }

        private void btnMechanicService_Click(object sender, EventArgs e)
        {
            HighlightButton(btnMechanicService);
            MessageBox.Show("Mechanic Service - Form not yet created", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Load MechanicService form/user control here
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
    }
}