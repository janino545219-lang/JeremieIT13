using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CarRental.DAL
{
    public class CarMaintenance
    {
        public int MaintenanceID { get; set; }
        public int CarID { get; set; }
        public string PlateNumber { get; set; }
        public string CarMaker { get; set; }
        public string CarModel { get; set; }
        public int CarYear { get; set; }
        public string MaintenanceType { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string MechanicName { get; set; }
        public decimal Cost { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CarMaintenanceDAL
    {
        private readonly string _connectionString;

        // Maintenance type constants
        public static readonly string[] MaintenanceTypes = new[]
        {
            "Oil & Filter Change",
            "Tire Rotation",
            "Brake Inspection",
            "Coolant Top-Off",
            "Brake Fluid Top-Off",
            "Transmission Fluid Top-Off",
            "Battery Test",
            "Air Filter Replacement",
            "General Maintenance"
        };

        public CarMaintenanceDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ─── CREATE ───────────────────────────────────────────────────────────
        /// <summary>
        /// Creates a new maintenance record. 
        /// The INSERT trigger will automatically set the Car's Status to 'Under Maintenance'.
        /// </summary>
        public int AddMaintenance(CarMaintenance m)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                INSERT INTO CarMaintenance 
                    (CarID, MaintenanceType, Description, Status, ScheduledDate, MechanicName, Cost, Notes)
                VALUES 
                    (@CarID, @MaintenanceType, @Description, 'In Progress', @ScheduledDate, @MechanicName, @Cost, @Notes);
                SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@CarID", m.CarID);
                cmd.Parameters.AddWithValue("@MaintenanceType", m.MaintenanceType);
                cmd.Parameters.AddWithValue("@Description", (object)m.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ScheduledDate", m.ScheduledDate);
                cmd.Parameters.AddWithValue("@MechanicName", (object)m.MechanicName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Cost", m.Cost);
                cmd.Parameters.AddWithValue("@Notes", (object)m.Notes ?? DBNull.Value);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // ─── READ ─────────────────────────────────────────────────────────────
        /// <summary>
        /// Gets all maintenance records (optionally filtered by CarID).
        /// </summary>
        public DataTable GetAllMaintenances(int? carID = null)
        {
            string query = @"
                SELECT 
                    cm.MaintenanceID, c.CarID, c.PlateNumber,
                    c.CarMaker + ' ' + c.CarModel + ' (' + CAST(c.CarYear AS NVARCHAR) + ')' AS CarInfo,
                    cm.MaintenanceType, cm.Description, cm.Status,
                    cm.ScheduledDate, cm.CompletedDate, cm.MechanicName,
                    cm.Cost, cm.Notes, cm.CreatedDate
                FROM CarMaintenance cm
                INNER JOIN Cars c ON cm.CarID = c.CarID";

            if (carID.HasValue)
                query += " WHERE cm.CarID = @CarID";

            query += " ORDER BY cm.ScheduledDate DESC";

            using (var conn = new SqlConnection(_connectionString))
            using (var adapter = new SqlDataAdapter(query, conn))
            {
                if (carID.HasValue)
                    adapter.SelectCommand.Parameters.AddWithValue("@CarID", carID.Value);

                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Gets only active (In Progress) maintenances.
        /// </summary>
        public DataTable GetActiveMaintenances()
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var adapter = new SqlDataAdapter(
                "SELECT * FROM vw_ActiveMaintenances ORDER BY ScheduledDate DESC", conn))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Gets maintenance history for a specific car.
        /// </summary>
        public DataTable GetMaintenanceHistoryByCar(int carID)
        {
            return GetAllMaintenances(carID);
        }

        /// <summary>
        /// Returns the active maintenance types for a car (empty if not in maintenance).
        /// </summary>
        public List<string> GetActiveMaintenanceTypes(int carID)
        {
            var types = new List<string>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                SELECT MaintenanceType FROM CarMaintenance
                WHERE CarID = @CarID AND Status = 'In Progress'", conn))
            {
                cmd.Parameters.AddWithValue("@CarID", carID);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        types.Add(reader.GetString(0));
            }
            return types;
        }

        /// <summary>
        /// Gets a single maintenance record by ID.
        /// </summary>
        public CarMaintenance GetMaintenanceByID(int maintenanceID)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                SELECT cm.*, c.PlateNumber, c.CarMaker, c.CarModel, c.CarYear
                FROM CarMaintenance cm
                INNER JOIN Cars c ON cm.CarID = c.CarID
                WHERE cm.MaintenanceID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", maintenanceID);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                        return MapMaintenance(r);
                }
            }
            return null;
        }

        // ─── UPDATE ───────────────────────────────────────────────────────────
        /// <summary>
        /// Marks maintenance as Completed.
        /// The UPDATE trigger will set the car back to 'Available' if no other active maintenance exists.
        /// </summary>
        public bool CompleteMaintenance(int maintenanceID, string notes = null, decimal finalCost = 0)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                UPDATE CarMaintenance SET
                    Status = 'Completed',
                    CompletedDate = GETDATE(),
                    Notes = ISNULL(@Notes, Notes),
                    Cost = CASE WHEN @Cost > 0 THEN @Cost ELSE Cost END,
                    ModifiedDate = GETDATE()
                WHERE MaintenanceID = @ID AND Status = 'In Progress'", conn))
            {
                cmd.Parameters.AddWithValue("@ID", maintenanceID);
                cmd.Parameters.AddWithValue("@Notes", (object)notes ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Cost", finalCost);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Cancels a maintenance record. 
        /// The UPDATE trigger will set the car back to 'Available' if no other active maintenance exists.
        /// </summary>
        public bool CancelMaintenance(int maintenanceID)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                UPDATE CarMaintenance SET
                    Status = 'Cancelled',
                    ModifiedDate = GETDATE()
                WHERE MaintenanceID = @ID AND Status = 'In Progress'", conn))
            {
                cmd.Parameters.AddWithValue("@ID", maintenanceID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Updates maintenance details (only while still In Progress).
        /// </summary>
        public bool UpdateMaintenance(CarMaintenance m)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                UPDATE CarMaintenance SET
                    MaintenanceType = @MaintenanceType,
                    Description = @Description,
                    ScheduledDate = @ScheduledDate,
                    MechanicName = @MechanicName,
                    Cost = @Cost,
                    Notes = @Notes,
                    ModifiedDate = GETDATE()
                WHERE MaintenanceID = @ID AND Status = 'In Progress'", conn))
            {
                cmd.Parameters.AddWithValue("@ID", m.MaintenanceID);
                cmd.Parameters.AddWithValue("@MaintenanceType", m.MaintenanceType);
                cmd.Parameters.AddWithValue("@Description", (object)m.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ScheduledDate", m.ScheduledDate);
                cmd.Parameters.AddWithValue("@MechanicName", (object)m.MechanicName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Cost", m.Cost);
                cmd.Parameters.AddWithValue("@Notes", (object)m.Notes ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ─── HELPERS ──────────────────────────────────────────────────────────
        /// <summary>
        /// Checks if a car is currently under maintenance.
        /// Use this in CreateCarRental to block renting a car that's in maintenance.
        /// </summary>
        public bool IsCarUnderMaintenance(int carID)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                SELECT COUNT(1) FROM CarMaintenance
                WHERE CarID = @CarID AND Status = 'In Progress'", conn))
            {
                cmd.Parameters.AddWithValue("@CarID", carID);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        /// <summary>
        /// Gets all cars that are available (Status = 'Available', not archived).
        /// Use this in CreateCarRental to populate the car dropdown.
        /// </summary>
        public DataTable GetAvailableCars()
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var adapter = new SqlDataAdapter(@"
                SELECT CarID, PlateNumber, CarMaker, CarModel, CarYear, DailyRentalPrice
                FROM Cars
                WHERE Status = 'Available' AND (IsArchived = 0 OR IsArchived IS NULL)
                ORDER BY CarMaker, CarModel", conn))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        private CarMaintenance MapMaintenance(SqlDataReader r)
        {
            return new CarMaintenance
            {
                MaintenanceID = r.GetInt32(r.GetOrdinal("MaintenanceID")),
                CarID = r.GetInt32(r.GetOrdinal("CarID")),
                PlateNumber = r["PlateNumber"].ToString(),
                CarMaker = r["CarMaker"].ToString(),
                CarModel = r["CarModel"].ToString(),
                CarYear = r.GetInt32(r.GetOrdinal("CarYear")),
                MaintenanceType = r["MaintenanceType"].ToString(),
                Description = r["Description"] as string,
                Status = r["Status"].ToString(),
                ScheduledDate = r.GetDateTime(r.GetOrdinal("ScheduledDate")),
                CompletedDate = r["CompletedDate"] as DateTime?,
                MechanicName = r["MechanicName"] as string,
                Cost = r["Cost"] == DBNull.Value ? 0 : (decimal)r["Cost"],
                Notes = r["Notes"] as string,
                CreatedDate = r.GetDateTime(r.GetOrdinal("CreatedDate"))
            };
        }
    }
}