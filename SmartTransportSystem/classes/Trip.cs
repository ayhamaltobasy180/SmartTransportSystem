using SmartTransportSystem.classes.SmartTransportSystem.classes;
using SmartTransportSystem.enums;
using System;
using System.Collections.Generic;

namespace SmartTransportSystem.classes
{
    public abstract class Trip : IReportable
    {
        public int TripId { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public double Distance { get; set; }
        public DateTime TripDate { get; set; }
        public Driver Driver { get; set; }
        public Vehicle Vehicle { get; set; }
        public int AvailableSeats { get; set; }
        public TripStatus Status { get; set; }

        public Trip()
        {
            TripId = 0;
            FromLocation = "Unknown";
            ToLocation = "Unknown";
            Distance = 0.0;
            TripDate = DateTime.Now;
            AvailableSeats = 0;
            Status = TripStatus.Scheduled;
        }

        public Trip(int tripId, string fromLocation, string toLocation, double distance, DateTime tripDate, Driver driver, Vehicle vehicle, int availableSeats, TripStatus status)
        {
            TripId = tripId;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            Distance = distance;
            TripDate = tripDate;
            Driver = driver;
            Vehicle = vehicle;
            AvailableSeats = vehicle != null ? vehicle.Capacity : availableSeats;
            Status = status;
        }

        public abstract double CalculateTripCost();

        // --- تعديل ميثود ReserveSeats الافتراضية بدلاً من طباعة this is virtual ---
        public virtual void ReserveSeats(int count)
        {
            if (count <= 0)
                throw new ArgumentException("Seats count must be greater than zero.");

            if (count > AvailableSeats)
                throw new InvalidOperationException("Not enough available seats on this trip.");

            AvailableSeats -= count;
            Console.WriteLine($"[Trip Seats Updated] Reserved {count} seats. Remaining available seats for Trip #{TripId}: {AvailableSeats}");
        }

        public bool CancelTrip(List<Trip> allTrips, int tripId)
        {
            Trip tripToRemove = allTrips.Find(t => t.TripId == tripId);

            if (tripToRemove != null)
            {
                allTrips.Remove(tripToRemove);
                Console.WriteLine($"[Admin Action] Trip #{tripId} has been successfully deleted from system.");
                return true;
            }

            Console.WriteLine($"Trip #{tripId} was not found!");
            return false;
        }

        public abstract void DisplayTripInfo();

     
        public virtual string GenerateReport()
        {
            string driverName = Driver != null ? Driver.Name : "Unassigned";

            return $"[Trip Report] ID: {TripId} | From: {FromLocation} -> " +
            $"To: {ToLocation} | Distance: {Distance}km | Price: {CalculateTripCost():C} |" +
            $" Driver: {driverName} | Available Seats: {AvailableSeats}";
        }
    }
}