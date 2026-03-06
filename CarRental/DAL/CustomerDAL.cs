using System;
using System.Collections.Generic;
using System.Data;
using CarRental.Models;
using Microsoft.Data.SqlClient;

namespace CarRental.DAL
{
    public class CustomerDAL
    {
        // Connection string for CARRENTALDB database
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CARRENTALDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";

        // CREATE - Add new customer
        public bool AddCustomer(Customer customer)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Customers (FirstName, LastName, Email, PhoneNumber, Address, UserLicense) 
                                   VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Address, @UserLicense)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Address", customer.Address);
                        cmd.Parameters.AddWithValue("@UserLicense", customer.UserLicense);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding customer: " + ex.Message);
            }
        }

        // READ - Get all customers
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Customers WHERE IsActive = 1 ORDER BY DateCreated DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer
                                {
                                    CustomerID = Convert.ToInt32(reader["CustomerID"]),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    UserLicense = reader["UserLicense"].ToString(),
                                    DateCreated = Convert.ToDateTime(reader["DateCreated"]),
                                    DateModified = Convert.ToDateTime(reader["DateModified"]),
                                    IsActive = Convert.ToBoolean(reader["IsActive"])
                                };
                                customers.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving customers: " + ex.Message);
            }

            return customers;
        }

        // READ - Get customer by ID
        public Customer GetCustomerById(int customerId)
        {
            Customer customer = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                customer = new Customer
                                {
                                    CustomerID = Convert.ToInt32(reader["CustomerID"]),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    UserLicense = reader["UserLicense"].ToString(),
                                    DateCreated = Convert.ToDateTime(reader["DateCreated"]),
                                    DateModified = Convert.ToDateTime(reader["DateModified"]),
                                    IsActive = Convert.ToBoolean(reader["IsActive"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving customer: " + ex.Message);
            }

            return customer;
        }

        // READ - Search customers
        public List<Customer> SearchCustomers(string searchTerm)
        {
            List<Customer> customers = new List<Customer>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT * FROM Customers 
                                   WHERE IsActive = 1 AND 
                                   (FirstName LIKE @SearchTerm OR 
                                    LastName LIKE @SearchTerm OR 
                                    Email LIKE @SearchTerm OR 
                                    PhoneNumber LIKE @SearchTerm OR
                                    UserLicense LIKE @SearchTerm)
                                   ORDER BY FirstName, LastName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer
                                {
                                    CustomerID = Convert.ToInt32(reader["CustomerID"]),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    UserLicense = reader["UserLicense"].ToString(),
                                    DateCreated = Convert.ToDateTime(reader["DateCreated"]),
                                    DateModified = Convert.ToDateTime(reader["DateModified"]),
                                    IsActive = Convert.ToBoolean(reader["IsActive"])
                                };
                                customers.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching customers: " + ex.Message);
            }

            return customers;
        }

        // UPDATE - Update existing customer
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE Customers 
                                   SET FirstName = @FirstName, 
                                       LastName = @LastName, 
                                       Email = @Email, 
                                       PhoneNumber = @PhoneNumber, 
                                       Address = @Address, 
                                       UserLicense = @UserLicense,
                                       DateModified = GETDATE()
                                   WHERE CustomerID = @CustomerID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Address", customer.Address);
                        cmd.Parameters.AddWithValue("@UserLicense", customer.UserLicense);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating customer: " + ex.Message);
            }
        }

        // DELETE - Soft delete customer (set IsActive to false)
        public bool DeleteCustomer(int customerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Customers SET IsActive = 0, DateModified = GETDATE() WHERE CustomerID = @CustomerID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting customer: " + ex.Message);
            }
        }

        // Hard delete - Permanently remove customer (use with caution)
        public bool PermanentDeleteCustomer(int customerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error permanently deleting customer: " + ex.Message);
            }
        }

        // Check if email exists (for validation)
        public bool EmailExists(string email, int? excludeCustomerId = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Customers WHERE Email = @Email";

                    if (excludeCustomerId.HasValue)
                    {
                        query += " AND CustomerID != @CustomerID";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        if (excludeCustomerId.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@CustomerID", excludeCustomerId.Value);
                        }

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking email: " + ex.Message);
            }
        }

        // Check if license exists (for validation)
        public bool LicenseExists(string license, int? excludeCustomerId = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Customers WHERE UserLicense = @UserLicense";

                    if (excludeCustomerId.HasValue)
                    {
                        query += " AND CustomerID != @CustomerID";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserLicense", license);

                        if (excludeCustomerId.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@CustomerID", excludeCustomerId.Value);
                        }

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking license: " + ex.Message);
            }
        }

        // Get customer count
        public int GetCustomerCount()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Customers WHERE IsActive = 1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        return (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting customer count: " + ex.Message);
            }
        }
    }
}