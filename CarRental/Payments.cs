using System;

namespace CarRental
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int RentalID { get; set; }
        public string CustomerName { get; set; }
        public string PlateNumber { get; set; }

        // Payment Details
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal ChangeAmount { get; set; }

        // Card/GCash Details
        public string ReferenceNumber { get; set; }
        public string CardLastFourDigits { get; set; }

        // Status
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public Payment()
        {
            PaymentStatus = "Completed";
            PaymentDate = DateTime.Now;
            CreatedDate = DateTime.Now;
        }
    }
}