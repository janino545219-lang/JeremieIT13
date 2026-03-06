using CarRental.Views.Shared;
using System;
using System.Drawing;
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
            this.WindowState = FormWindowState.Maximized;
        }

        private void HighlightButton(Button button)
        {
            if (currentButton != null)
                currentButton.BackColor = Color.FromArgb(41, 44, 51);
            currentButton = button;
            currentButton.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void btnMechanicService_Click(object sender, EventArgs e)
        {
            HighlightButton(btnMechanicService);
            MessageBox.Show("Mechanic Service - Form not yet created", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            HighlightButton(btnUserManagement);
            LoadForm(new UserManagementForm());
        }

        private void btnCarApproval_Click(object sender, EventArgs e)
        {
            HighlightButton(btnCarApproval);
            LoadForm(new CarApprovalForm());
        }

        private void btnServiceApproval_Click(object sender, EventArgs e)
        {
            HighlightButton(btnServiceApproval);
            // ── CHANGED: Load the real ServiceApprovalForm ──
            LoadForm(new ServiceApprovalForm());
        }

        private void btnRentalPrice_Click(object sender, EventArgs e)
        {
            RentalPriceForm form = new RentalPriceForm();
            form.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            HighlightButton(btnReports);
            MessageBox.Show("Reports - Form not yet created", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTNC_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            Label lblTitle = new Label();
            lblTitle.Text = "📋  Terms and Conditions";
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(41, 44, 51);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 50;
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblTitle.Padding = new Padding(15, 0, 0, 0);
            lblTitle.BackColor = Color.WhiteSmoke;

            RichTextBox rtb = new RichTextBox();
            rtb.ReadOnly = true;
            rtb.Font = new Font("Courier New", 9.5F);
            rtb.BackColor = Color.WhiteSmoke;
            rtb.BorderStyle = BorderStyle.None;
            rtb.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtb.Dock = DockStyle.Fill;
            rtb.Padding = new Padding(15);
            rtb.Text = GetTermsText();

            Panel bottomPanel = new Panel();
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Height = 55;
            bottomPanel.BackColor = Color.FromArgb(41, 44, 51);

            CheckBox chk = new CheckBox();
            chk.Text = "I have read and agree to all Terms and Conditions";
            chk.Font = new Font("Segoe UI", 10F);
            chk.ForeColor = Color.White;
            chk.AutoSize = true;
            chk.Location = new Point(15, 15);

            Button btnAgree = new Button();
            btnAgree.Text = "✔  I Agree";
            btnAgree.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAgree.BackColor = Color.FromArgb(39, 174, 96);
            btnAgree.ForeColor = Color.White;
            btnAgree.FlatStyle = FlatStyle.Flat;
            btnAgree.FlatAppearance.BorderSize = 0;
            btnAgree.Size = new Size(120, 35);
            btnAgree.Location = new Point(820, 10);
            btnAgree.Enabled = false;

            Button btnDecline = new Button();
            btnDecline.Text = "✘  Decline";
            btnDecline.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDecline.BackColor = Color.FromArgb(192, 57, 43);
            btnDecline.ForeColor = Color.White;
            btnDecline.FlatStyle = FlatStyle.Flat;
            btnDecline.FlatAppearance.BorderSize = 0;
            btnDecline.Size = new Size(120, 35);
            btnDecline.Location = new Point(950, 10);

            chk.CheckedChanged += (s, ev) => btnAgree.Enabled = chk.Checked;
            btnAgree.Click += (s, ev) =>
                MessageBox.Show("Thank you for agreeing to our Terms and Conditions!", "Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnDecline.Click += (s, ev) =>
            {
                if (MessageBox.Show("Are you sure you want to decline the Terms and Conditions?",
                    "Decline", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    panelMain.Controls.Clear();
            };

            bottomPanel.Controls.Add(chk);
            bottomPanel.Controls.Add(btnAgree);
            bottomPanel.Controls.Add(btnDecline);

            panelMain.Controls.Add(rtb);
            panelMain.Controls.Add(bottomPanel);
            panelMain.Controls.Add(lblTitle);
        }

        private string GetTermsText()
        {
            return
        @"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
        TERMS AND CONDITIONS — CAR RENTAL SYSTEM
        Effective Date: January 1, 2025 | Last Updated: March 2026
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

Please read these Terms and Conditions carefully before renting a vehicle
from our Car Rental System. By proceeding with a rental, you confirm that
you have read, understood, and agreed to be bound by these terms.

────────────────────────────────────────────────────────────────────────
SECTION 1: ELIGIBILITY REQUIREMENTS
────────────────────────────────────────────────────────────────────────

1.1  AGE REQUIREMENT
     The minimum age to rent a vehicle is 21 years old. Renters between
     21-25 years old may be subject to a young driver surcharge fee.

1.2  VALID DRIVER'S LICENSE
     A valid, government-issued driver's license is required at the time
     of pickup. International renters must present an International
     Driving Permit (IDP) alongside their home country license.

1.3  IDENTITY VERIFICATION
     A valid government-issued ID (passport, national ID, or driver's
     license) must be presented upon vehicle pickup. Failure to provide
     valid identification will result in cancellation of the rental
     with no refund.

1.4  CREDIT/DEBIT CARD
     A valid credit or debit card is required for the security deposit.
     Prepaid cards are not accepted for deposit purposes.";
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            HighlightButton(btnPayments);
            MessageBox.Show("Payments - Form not yet created", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new Form1().Show();
                this.Close();
            }
        }

        private void LoadForm(Form form)
        {
            panelMain.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }

        private void lblWelcome_Click(object sender, EventArgs e) { }
    }
}