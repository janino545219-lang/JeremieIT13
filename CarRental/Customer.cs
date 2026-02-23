using System;

namespace CarRental
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string UserLicense { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsActive { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public Customer()
        {
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
            IsActive = true;
        }
    }
}