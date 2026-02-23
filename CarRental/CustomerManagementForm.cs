using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CarRental
{
    public partial class CustomerManagementForm : Form
    {
        private CustomerDAL customerDAL;
        private int selectedCustomerId = 0;

        public CustomerManagementForm()
        {
            InitializeComponent();
            customerDAL = new CustomerDAL();
        }

        private void CustomerManagementForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.Columns.Clear();

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerID",
                HeaderText = "ID",
                Name = "CustomerID",
                Width = 50
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FirstName",
                HeaderText = "First Name",
                Name = "FirstName"
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastName",
                HeaderText = "Last Name",
                Name = "LastName"
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Name = "Email"
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PhoneNumber",
                HeaderText = "Phone Number",
                Name = "PhoneNumber"
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UserLicense",
                HeaderText = "License No.",
                Name = "UserLicense"
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Address",
                HeaderText = "Address",
                Name = "Address"
            });

            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCustomers.ColumnHeadersHeight = 40;
            dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241);
            dgvCustomers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void LoadCustomers()
        {
            try
            {
                List<Customer> customers = customerDAL.GetAllCustomers();
                dgvCustomers.DataSource = customers;

                if (customers.Count > 0)
                {
                    lblTitle.Text = "Customer Management (" + customers.Count.ToString() + " customers)";
                }
                else
                {
                    lblTitle.Text = "Customer Management (No customers)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Phone Number is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumber.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUserLicense.Text))
            {
                MessageBox.Show("Driver License Number is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserLicense.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Address is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                if (customerDAL.EmailExists(txtEmail.Text))
                {
                    MessageBox.Show("Email already exists. Please use a different email.",
                        "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (customerDAL.LicenseExists(txtUserLicense.Text))
                {
                    MessageBox.Show("License number already exists. Please use a different license number.",
                        "Duplicate License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserLicense.Focus();
                    return;
                }

                Customer customer = new Customer();
                customer.FirstName = txtFirstName.Text.Trim();
                customer.LastName = txtLastName.Text.Trim();
                customer.Email = txtEmail.Text.Trim();
                customer.PhoneNumber = txtPhoneNumber.Text.Trim();
                customer.UserLicense = txtUserLicense.Text.Trim();
                customer.Address = txtAddress.Text.Trim();

                bool result = customerDAL.AddCustomer(customer);

                if (result)
                {
                    MessageBox.Show("Customer added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadCustomers();
                }
                else
                {
                    MessageBox.Show("Failed to add customer.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == 0)
            {
                MessageBox.Show("Please select a customer to update.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs())
                return;

            try
            {
                if (customerDAL.EmailExists(txtEmail.Text, selectedCustomerId))
                {
                    MessageBox.Show("Email already exists for another customer.",
                        "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (customerDAL.LicenseExists(txtUserLicense.Text, selectedCustomerId))
                {
                    MessageBox.Show("License number already exists for another customer.",
                        "Duplicate License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserLicense.Focus();
                    return;
                }

                Customer customer = new Customer();
                customer.CustomerID = selectedCustomerId;
                customer.FirstName = txtFirstName.Text.Trim();
                customer.LastName = txtLastName.Text.Trim();
                customer.Email = txtEmail.Text.Trim();
                customer.PhoneNumber = txtPhoneNumber.Text.Trim();
                customer.UserLicense = txtUserLicense.Text.Trim();
                customer.Address = txtAddress.Text.Trim();

                bool result = customerDAL.UpdateCustomer(customer);

                if (result)
                {
                    MessageBox.Show("Customer updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadCustomers();
                }
                else
                {
                    MessageBox.Show("Failed to update customer.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == 0)
            {
                MessageBox.Show("Please select a customer to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show(
                "Are you sure you want to delete " + txtFirstName.Text + " " + txtLastName.Text + "?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    bool result = customerDAL.DeleteCustomer(selectedCustomerId);

                    if (result)
                    {
                        MessageBox.Show("Customer deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadCustomers();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete customer.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtCustomerID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtUserLicense.Clear();
            txtAddress.Clear();
            selectedCustomerId = 0;
            txtFirstName.Focus();
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

                selectedCustomerId = Convert.ToInt32(row.Cells["CustomerID"].Value);
                txtCustomerID.Text = row.Cells["CustomerID"].Value.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhoneNumber.Text = row.Cells["PhoneNumber"].Value.ToString();
                txtUserLicense.Text = row.Cells["UserLicense"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadCustomers();
                return;
            }

            try
            {
                List<Customer> customers = customerDAL.SearchCustomers(txtSearch.Text.Trim());
                dgvCustomers.DataSource = customers;

                if (customers.Count > 0)
                {
                    lblTitle.Text = "Customer Management (" + customers.Count.ToString() + " found)";
                }
                else
                {
                    lblTitle.Text = "Customer Management (No results)";
                    MessageBox.Show("No customers found matching your search.", "No Results",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching customers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadCustomers();
            ClearFields();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Check if form is embedded in a panel (part of Staff Dashboard)
            if (this.Parent != null)
            {
                // Clear the panel to go back to dashboard
                this.Parent.Controls.Clear();
            }
            else
            {
                // Close the form if opened as standalone window
                this.Close();
            }
        }
    }
}