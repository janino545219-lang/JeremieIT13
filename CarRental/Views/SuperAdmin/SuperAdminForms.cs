using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarRental
{
    public partial class SuperAdminForms : Form
    {
        private Button currentButton;

        public SuperAdminForms()
        {
            InitializeComponent();
        }

        private void SuperAdminForms_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        // Highlights the active sidebar button
        private void HighlightButton(Button button)
        {
            if (currentButton != null)
                currentButton.BackColor = Color.FromArgb(41, 44, 51);

            currentButton = button;
            currentButton.BackColor = Color.FromArgb(0, 122, 204);
        }

        // Loads a child form into the main panel
        private void LoadForm(Form form)
        {
            panelMain.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            HighlightButton(btnUserManagement);
            LoadForm(new UserManagementForm());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            HighlightButton(btnReports);
            MessageBox.Show("Reports - Form not yet created", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: LoadForm(new ReportsForm());
        }

        private void btnTNC_Click(object sender, EventArgs e)
        {
            HighlightButton(btnTNC);
            MessageBox.Show("Terms & Conditions - Form not yet created", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: LoadForm(new TNCForm());
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            HighlightButton(btnPayments);
            MessageBox.Show("Payments - Form not yet created", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: LoadForm(new PaymentsForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Close();
            }
        }
    }
}