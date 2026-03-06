using System;
using Microsoft.Data.SqlClient; // NOT System.Data.SqlClient
using System.Drawing;
using System.Windows.Forms;


namespace CarRental
{
    public partial class SignUpForm : Form
    {
        // Replace this connection string with your actual one from Server Explorer
        string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog = CARRENTALDB; Integrated Security = True; Trust Server Certificate=True";

        public SignUpForm()
        {
            InitializeComponent();
            // Hook up the click event handler
            btnSignUp.Click += btnSignUp_Click;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // 1. Basic Validation
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            if (!chkTerms.Checked)
            {
                MessageBox.Show("You must agree to the Terms of Service.");
                return;
            }

            // 2. Database Insertion
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (FullName, Email, Username, Password) VALUES (@FullName, @Email, @Username, @Password)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text); // Plain text for simplicity, use hashing in production

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sign Up Successful!");

                        // Clear fields or redirect to login
                        this.Close();
                        Form1 loginForm = new Form1();
                        loginForm.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void lblAlreadyHaveAccount_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }

        private void pictureBoxCar_Click(object sender, EventArgs e) { }
    



private void panelLeft_Paint(object sender, PaintEventArgs e)
        {
            // Custom painting code goes here, or leave empty
        }

    }

}