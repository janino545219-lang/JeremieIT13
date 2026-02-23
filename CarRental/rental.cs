using System;

namespace CarRental
{
    public class Rental
    {
        public int RentalID { get; set; }
        public int CarID { get; set; }
        public int CustomerID { get; set; }
        public string PlateNumber { get; set; }
        public string CustomerFullName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RentalDays { get; set; }

        // Additional Services
        public bool AdditionalInsurance { get; set; }
        public bool RoadsideAssistance { get; set; }
        public bool WifiHotspot { get; set; }
        public bool ExtendedMileage { get; set; }
        public bool ExtraDriver { get; set; }

        // Pricing
        public decimal DailyRate { get; set; }
        public decimal AdditionalServicesCost { get; set; }
        public decimal TotalCost { get; set; }

        // Status
        public string RentalStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Rental()
        {
            RentalStatus = "Active";
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
    }
}