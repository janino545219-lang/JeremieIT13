using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace CarRental
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CARRENTALDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
            this.Hide();
        }

        private void pictureBoxCar_Click(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if admin credentials
            if (username.ToLower() == "admin" && password == "admin123")
            {
                MessageBox.Show("Welcome Admin!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AdminDashboard adminDashboard = new AdminDashboard();
                adminDashboard.Show();
                this.Hide();
                return;
            }

            // Check regular user credentials from database and get role
            string userRole = ValidateUserAndGetRole(username, password);

            if (!string.IsNullOrEmpty(userRole))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirect based on role
                if (userRole.ToLower() == "manager")
                {
                    // Manager goes to Manager Dashboard
                    ManagerForms managerDashboard = new ManagerForms();
                    managerDashboard.Show();
                    this.Hide();
                }
                else if (userRole.ToLower() == "staff" || userRole.ToLower() == "super admin")
                {
                    // Staff and Super Admin go to Staff Dashboard
                    StaffForms staffDashboard = new StaffForms();
                    staffDashboard.Show();
                    this.Hide();
                }
                else
                {
                    // Regular user - redirect to user dashboard (when created)
                    MessageBox.Show("User dashboard not yet implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // TODO: Uncomment when UserDashboard is created
                    // UserDashboard userDashboard = new UserDashboard();
                    // userDashboard.Show();
                    // this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ValidateUserAndGetRole(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Role FROM [dbo].[Users] WHERE Username = @Username AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        object result = cmd.ExecuteScalar();
                        return result?.ToString() ?? string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
    }
}