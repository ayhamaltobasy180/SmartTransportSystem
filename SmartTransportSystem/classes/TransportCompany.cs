using SmartTransportSystem.classes.SmartTransportSystem.classes;
using SmartTransportSystem.enums;
using System;
using System.Collections.Generic;

namespace SmartTransportSystem.classes
{
    // Delegates Definition for Events
    public delegate void BookingCreatedHandler(string message);
    public delegate void BookingCancelledHandler(string message);
    public delegate void TripCancelledHandler(string message);

    public class TransportCompany : IReportable
    {
        public string Name { get; set; }

        // Generic Repositories
        public Repository<Passenger> Passengers { get; set; } = new Repository<Passenger>();
        public Repository<Driver> Drivers { get; set; } = new Repository<Driver>();
        public Repository<Vehicle> Vehicles { get; set; } = new Repository<Vehicle>();
        public Repository<Trip> Trips { get; set; } = new Repository<Trip>();
        public Repository<Booking> Bookings { get; set; } = new Repository<Booking>();
        public List<PaymentMethod> Payments { get; set; } = new List<PaymentMethod>();

        // Events Definition
        public event BookingCreatedHandler OnBookingCreated;
        public event BookingCancelledHandler OnBookingCancelled;
        public event TripCancelledHandler OnTripCancelled;

        public TransportCompany(string name)
        {
            Name = name;

            // Subscribe events to logging helper
            OnBookingCreated += SystemHelper.Log;
            OnBookingCancelled += SystemHelper.Log;
            OnTripCancelled += SystemHelper.Log;
        }

        // --- Method Overloading (Shortened Messages) ---
        public void AddPassenger(Passenger passenger)
        {
            if (passenger == null) return;
            Passengers.Add(passenger);
            Console.WriteLine($"[Passenger Added] ID: {passenger.Id} | Name: {passenger.Name}");
        }

        public void AddPassenger(string name, string email, string phone, double initialBalance)
        {
            if (!SystemHelper.ValidateEmail(email))
                throw new ArgumentException("Invalid email address!");

            int id = SystemHelper.GenerateId();
            Passenger p = new Passenger(id, name, email, phone, initialBalance);
            Passengers.Add(p);
            Console.WriteLine($"[Passenger Added] ID: {id} | Name: {name}");
        }

        public void AddDriver(Driver driver)
        {
            if (driver == null) return;
            Drivers.Add(driver);
            Console.WriteLine($"[Driver Added] ID: {driver.Id} | Name: {driver.Name}");
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle == null) return;
            Vehicles.Add(vehicle);
            Console.WriteLine($"[Vehicle Added] ID: {vehicle.VehicleId}");
        }

        public void CreateTrip(Trip trip)
        {
            if (trip == null) return;
            if (trip.Driver != null && !trip.Driver.IsAvailable)
                throw new VehicleUnavailableException("Driver/Vehicle unavailable!");

            Trips.Add(trip);
            Console.WriteLine($"[Trip Created] ID: {trip.TripId}");
        }

        // --- Search Methods ---
        public Passenger FindPassengerById(int id) => Passengers.Find(p => p.Id == id);
        public Driver FindDriverById(int id) => Drivers.Find(d => d.Id == id);
        public Trip FindTripById(int tripId) => Trips.Find(t => t.TripId == tripId);

        // --- Booking Operations (Shortened Events) ---
        public void BookTrip(int passengerId, int tripId, int seats)
        {
            Passenger passenger = FindPassengerById(passengerId);
            Trip trip = FindTripById(tripId);

            if (passenger == null)
                throw new InvalidBookingException("Passenger not found!");

            if (trip == null)
                throw new InvalidBookingException("Trip not found!");

            if (trip.Status == TripStatus.Cancelled)
                throw new InvalidBookingException("Cannot book on a cancelled trip!");

            if (seats <= 0 || seats > trip.AvailableSeats)
                throw new TripFullyBookedException($"Insufficient seats! Requested: {seats}, Available: {trip.AvailableSeats}");

            double totalCost = trip.CalculateTripCost() * seats;

            int newBookingId = Bookings.Count + 1;
            Booking newBooking = new Booking(newBookingId, passenger, trip, seats);

            Bookings.Add(newBooking);
            passenger.bookings.Add(newBooking);
            trip.ReserveSeats(seats);

            // Trigger Compact Booking Event
            string msg = $"[Booked] Trip #{tripId} | Passenger: {passenger.Name} | Seats: {seats}";
            OnBookingCreated?.Invoke(msg);
        }

        public void CancelBooking(int bookingId)
        {
            Booking booking = Bookings.Find(b => b.BookingId == bookingId);

            if (booking == null)
                throw new InvalidBookingException($"Booking #{bookingId} not found!");

            if (booking.Payment == PaymentStatusenum.Paid)
            {
                double refundAmount = booking.Trip.CalculateTripCost() * booking.SeatsCount;
                booking.Passenger.AddBalance((decimal)refundAmount);
            }

            booking.Payment = PaymentStatusenum.Unpaid;

            // Trigger Compact Cancel Event
            string msg = $"[Cancelled] Booking #{bookingId} (Refunded)";
            OnBookingCancelled?.Invoke(msg);
        }

        public void CancelTripFromAdmin(int tripId)
        {
            Trip trip = FindTripById(tripId);
            if (trip == null)
                throw new InvalidBookingException("Trip not found!");

            trip.Status = TripStatus.Cancelled;

            foreach (var b in Bookings.FindAll(b => b.Trip != null && b.Trip.TripId == tripId))
            {
                if (b.Payment == PaymentStatusenum.Paid)
                {
                    double refund = b.Trip.CalculateTripCost() * b.SeatsCount;
                    b.Passenger.AddBalance((decimal)refund);
                    b.Payment = PaymentStatusenum.Refunded;
                }
            }

            // Trigger Compact Trip Cancel Event
            string msg = $"[Trip Cancelled] ID: #{tripId} (100% Refunded)";
            OnTripCancelled?.Invoke(msg);
        }

        // --- Displays & Reports ---
        public void ShowAllTrips()
        {
            SystemHelper.PrintHeader("All Trips List");
            if (Trips.Count == 0) { Console.WriteLine("No registered trips."); return; }

            foreach (var t in Trips.GetAll())
            {
                Console.WriteLine(t.GenerateReport());
            }
        }

        public void ShowAllVehicles()
        {
            SystemHelper.PrintHeader("All Vehicles List");
            if (Vehicles.Count == 0) { Console.WriteLine("No registered vehicles."); return; }

            foreach (var v in Vehicles.GetAll())
            {
                string status = v.IsAvailable ? "Available" : "Unavailable";
                Console.WriteLine($"ID: {v.VehicleId} | Model: {v.Model} | Capacity: {v.Capacity} | Status: {status}");
            }
        }

        public void ShowAllBookings()
        {
            SystemHelper.PrintHeader("All Bookings List");
            if (Bookings.Count == 0) { Console.WriteLine("No registered bookings."); return; }

            foreach (var b in Bookings.GetAll())
            {
                Console.WriteLine(b.GenerateReport());
            }
        }

        public string GenerateReport()
        {
            return $"Company: {Name}\n" +
                   $"Passengers: {Passengers.Count} | Drivers: {Drivers.Count} | Vehicles: {Vehicles.Count} | Trips: {Trips.Count} | Bookings: {Bookings.Count}";
        }

        public void GenerateFullReport()
        {
            SystemHelper.PrintHeader($"Full Report: {Name}");
            Console.WriteLine(GenerateReport());
            ShowAllTrips();
            PrintCancelledTripsReport();
            PrintMostBookedDriver();
            PrintTopRatedDriver();
            PrintMostActivePassenger();
            PrintTotalRevenueReport();
            PrintVehiclesAvailabilityReport();
            PrintBookingsPaymentStatusReport();
            Console.WriteLine("==================================================\n");
        }

        private void PrintCancelledTripsReport()
        {
            Console.WriteLine("\n--- [1] Cancelled Bookings ---");
            int count = 0;
            foreach (var b in Bookings.GetAll())
            {
                if (b.Payment == PaymentStatusenum.Unpaid || b.Payment == PaymentStatusenum.Refunded)
                {
                    Console.WriteLine($"Booking #{b.BookingId} | Passenger: {b.Passenger?.Name} | Trip #{b.Trip?.TripId}");
                    count++;
                }
            }
            if (count == 0) Console.WriteLine("No cancelled bookings.");
        }

        private void PrintMostBookedDriver()
        {
            Console.WriteLine("\n--- [2] Most Booked Driver ---");
            Driver topDriver = null;
            int maxCount = 0;

            foreach (var driver in Drivers.GetAll())
            {
                int count = 0;
                foreach (var b in Bookings.GetAll())
                {
                    if (b.Trip != null && b.Trip.Driver != null && b.Trip.Driver.Id == driver.Id)
                        count++;
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    topDriver = driver;
                }
            }

            if (topDriver != null)
                Console.WriteLine($"Driver: {topDriver.Name} | Bookings: {maxCount}");
            else
                Console.WriteLine("No driver bookings found.");
        }

        private void PrintTopRatedDriver()
        {
            Console.WriteLine("\n--- [3] Top Rated Driver ---");
            Driver topDriver = null;
            double maxRating = -1;

            foreach (var driver in Drivers.GetAll())
            {
                double avg = driver.GetAverageRating();
                if (avg > maxRating)
                {
                    maxRating = avg;
                    topDriver = driver;
                }
            }

            if (topDriver != null)
                Console.WriteLine($"Driver: {topDriver.Name} | Rating: {maxRating:F1} ★");
            else
                Console.WriteLine("No drivers found.");
        }

        private void PrintMostActivePassenger()
        {
            Console.WriteLine("\n--- [4] Most Active Passenger ---");
            Passenger topPassenger = null;
            int maxCount = 0;

            foreach (var passenger in Passengers.GetAll())
            {
                int count = 0;
                foreach (var b in Bookings.GetAll())
                {
                    if (b.Passenger != null && b.Passenger.Id == passenger.Id)
                        count++;
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    topPassenger = passenger;
                }
            }

            if (topPassenger != null)
                Console.WriteLine($"Passenger: {topPassenger.Name} | Bookings: {maxCount}");
            else
                Console.WriteLine("No passenger bookings found.");
        }

        private void PrintTotalRevenueReport()
        {
            Console.WriteLine("\n--- [5] Total Revenue ---");
            double totalRevenue = 0;
            foreach (var b in Bookings.GetAll())
            {
                if (b.Payment == PaymentStatusenum.Paid && b.Trip != null)
                {
                    totalRevenue += (b.Trip.CalculateTripCost() * b.SeatsCount);
                }
            }
            Console.WriteLine($"Completed Revenue: {SystemHelper.FormatCurrency(totalRevenue)}");
        }

        private void PrintVehiclesAvailabilityReport()
        {
            Console.WriteLine("\n--- [6] Vehicles Availability ---");
            int available = 0, unavailable = 0;

            foreach (var v in Vehicles.GetAll())
            {
                if (v.IsAvailable) available++;
                else unavailable++;
            }

            Console.WriteLine($"Available: {available} | Unavailable: {unavailable}");
        }

        private void PrintBookingsPaymentStatusReport()
        {
            Console.WriteLine("\n--- [7] Bookings Payment Status ---");
            int paid = 0, unpaid = 0;

            foreach (var b in Bookings.GetAll())
            {
                if (b.Payment == PaymentStatusenum.Paid) paid++;
                else unpaid++;
            }

            Console.WriteLine($"Paid: {paid} | Unpaid/Cancelled: {unpaid}");
        }
    }
}