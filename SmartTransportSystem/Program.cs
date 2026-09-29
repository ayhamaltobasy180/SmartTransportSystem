using System;
using SmartTransportSystem.classes;
using SmartTransportSystem.classes.SmartTransportSystem.classes;
using SmartTransportSystem.enums;

namespace SmartTransportManagementSystem.classs;

public class Program
{
    private static TransportCompany company = new TransportCompany("Smart Transport Co.");

    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool running = true;

        while (running)
        {
            SystemHelper.PrintHeader("Smart Transport Management System");
            Console.WriteLine("1. Run Demo Data");
            Console.WriteLine("2. Add Passenger");
            Console.WriteLine("3. Add Driver");
            Console.WriteLine("4. Add Vehicle");
            Console.WriteLine("5. Create Trip");
            Console.WriteLine("6. Show Trips");
            Console.WriteLine("7. Book Trip");
            Console.WriteLine("8. Pay for Booking");
            Console.WriteLine("9. Cancel Booking");
            Console.WriteLine("10. Show Passenger Bookings");
            Console.WriteLine("11. Rate Driver");
            Console.WriteLine("12. Cancel Trip");
            Console.WriteLine("13. Show Vehicles");
            Console.WriteLine("14. Show Drivers");
            Console.WriteLine("15. Generate Full Report");
            Console.WriteLine("0. Exit");
            Console.WriteLine("==================================================");
            Console.Write("Choose an option in menu: ");

            string input = Console.ReadLine();
            Console.Clear();

            try
            {
                switch (input)
                {
                    case "1":
                        RunDemoData();
                        break;
                    case "2":
                        AddNewPassengerUI();
                        break;
                    case "3":
                        AddNewDriverUI();
                        break;
                    case "4":
                        AddNewVehicleUI();
                        break;
                    case "5":
                        AddNewTripUI();
                        break;
                    case "6":
                        company.ShowAllTrips();
                        break;
                    case "7":
                        BookTripUI();
                        break;
                    case "8":
                        PayForBookingUI();
                        break;
                    case "9":
                        CancelBookingUI();
                        break;
                    case "10":
                        ShowPassengerBookingsUI();
                        break;
                    case "11":
                        RateDriverUI();
                        break;
                    case "12":
                        CancelTripUI();
                        break;
                    case "13":
                        company.ShowAllVehicles();
                        break;
                    case "14":
                        ShowDriversUI();
                        break;
                    case "15":
                        company.GenerateFullReport();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Thank you for using Smart Transport Management System. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("[ERROR] Invalid option, please try again.");
                        break;
                }
            }
            catch (InvalidBookingException ex)
            {
                Console.WriteLine($"\n[Booking Error]: {ex.Message}");
            }
            catch (TripFullyBookedException ex)
            {
                Console.WriteLine($"\n[Seats Error]: {ex.Message}");
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"\n[Balance Error]: {ex.Message}");
            }
            catch (VehicleUnavailableException ex)
            {
                Console.WriteLine($"\n[Vehicle Error]: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[System Error]: {ex.Message}");
            }

            if (running)
            {
                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    // Demo Data Scenario
    private static void RunDemoData()
    {
        SystemHelper.PrintHeader("Running Comprehensive Demo Data Scenario");

        // Create 5 Passengers using Overloading & Constructor
        company.AddPassenger("Ayham Mohammad", "ayhamaltobasy90@mail.com", "0785267140", 100.0);
        company.AddPassenger("Mohammed Ali", "mohammed@mail.com", "0790000002", 50.0);
        company.AddPassenger("Ahmed Hassan", "ahmed@mail.com", "0790000003", 30.0);
        company.AddPassenger("Sara Omar", "sara@mail.com", "0790000004", 150.0);
        company.AddPassenger("Raed Al-Rashed", "raed@mail.com", "0790000005", 20.0);

        // Create 3 Drivers
        Driver d1 = new Driver(101, "Mahmoud Khalil", "mahmoud@mail.com", "0780000001", "LIC-9988");
        Driver d2 = new Driver(102, "Samer Al-Qasim", "samer@mail.com", "0780000002", "LIC-7766");
        Driver d3 = new Driver(103, "Khaled Abdullah", "khaled@mail.com", "0780000003", "LIC-5544");

        company.AddDriver(d1);
        company.AddDriver(d2);
        company.AddDriver(d3);

        // Create 4 Vehicles
        Vehicle v1 = new Car(1, "Toyota Camry", "20-11111", 4, 2.0);
        Vehicle v2 = new Bus(2, "Mercedes Bus", "10-55555", 30, 1.0);
        Vehicle v3 = new LuxuryCar(3, "BMW 7 Series", "50-77777", 3, 5.0, 10.0);
        Vehicle v4 = new Car(4, "Hyundai Elantra", "30-22222", 4, 2.0);

        company.AddVehicle(v1);
        company.AddVehicle(v2);
        company.AddVehicle(v3);
        company.AddVehicle(v4);

        d1.AssignVehicle(v1);
        d2.AssignVehicle(v2);
        d3.AssignVehicle(v3);

        // Create 6 Trips
        Trip t1 = new LocalTrip(1001, "Amman - 7th Circle", "Amman - Downtown", 12.0, DateTime.Now.AddHours(2), d1, v1, 4, TripStatus.Scheduled);
        Trip t2 = new InterCityTrip(1002, "Amman", "Irbid", 85.0, DateTime.Now.AddDays(1), d2, v2, 30, TripStatus.Scheduled, 3.0);
        Trip t3 = new VIPTrip(1003, "Amman", "Aqaba", 330.0, DateTime.Now.AddDays(2), d3, v3, 3, TripStatus.Scheduled, 2.0, 1.5);
        Trip t4 = new LocalTrip(1004, "Zarqa", "Amman", 25.0, DateTime.Now.AddHours(5), d1, v1, 4, TripStatus.Scheduled);
        Trip t5 = new InterCityTrip(1005, "Amman", "Mafraq", 70.0, DateTime.Now.AddDays(3), d2, v2, 30, TripStatus.Scheduled, 2.5);
        Trip t6 = new LocalTrip(1006, "Tabarbour", "Hashemite University", 18.0, DateTime.Now.AddHours(1), d1, v4, 4, TripStatus.Scheduled);

        company.CreateTrip(t1);
        company.CreateTrip(t2);
        company.CreateTrip(t3);
        company.CreateTrip(t4);
        company.CreateTrip(t5);
        company.CreateTrip(t6);

        // Process Bookings
        var p1 = company.Passengers.GetAll()[0]; // Ayham
        var p2 = company.Passengers.GetAll()[1]; // Mohammed

        company.BookTrip(p1.Id, 1001, 1);
        company.BookTrip(p2.Id, 1002, 2);
        company.BookTrip(p1.Id, 1004, 1);

        // Pay for Bookings
        if (company.Bookings.Count > 0)
            company.Bookings.GetAll()[0].Payment = PaymentStatusenum.Paid;
        if (company.Bookings.Count > 1)
            company.Bookings.GetAll()[1].Payment = PaymentStatusenum.Paid;

        // Cancel Booking & Trip by Admin
        if (company.Bookings.Count > 2)
        {
            int bIdToCancel = company.Bookings.GetAll()[2].BookingId;
            company.CancelBooking(bIdToCancel);
        }

        company.CancelTripFromAdmin(1005); // Cancel Mafraq Trip

        // Driver Ratings
        p1.RatCoplTrip(d1, 5, t1);
        p2.RatCoplTrip(d2, 4, t2);

        Console.WriteLine("\n[SUCCESS] All demo data and test scenarios loaded successfully!");
    }

    // Interactive UI Interfaces

    private static void AddNewPassengerUI()
    {
        SystemHelper.PrintHeader("Add New Passenger");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Phone: ");
        string phone = Console.ReadLine();
        Console.Write("Initial Wallet Balance: ");
        double.TryParse(Console.ReadLine(), out double balance);

        company.AddPassenger(name, email, phone, balance);
    }

    private static void AddNewDriverUI()
    {
        SystemHelper.PrintHeader("Add New Driver");
        int id = SystemHelper.GenerateId();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Phone: ");
        string phone = Console.ReadLine();
        Console.Write("Driver License Number: ");
        string license = Console.ReadLine();

        Driver driver = new Driver(id, name, email, phone, license);
        company.AddDriver(driver);
    }

    private static void AddNewVehicleUI()
    {
        SystemHelper.PrintHeader("Add New Vehicle");
        Console.WriteLine("Select Type: 1. Car | 2. Bus | 3. LuxuryCar");
        string type = Console.ReadLine();

        int id = SystemHelper.GenerateId();
        Console.Write("Model: ");
        string model = Console.ReadLine();
        Console.Write("License Plate: ");
        string plate = Console.ReadLine();
        Console.Write("Capacity: ");
        int capacity = int.Parse(Console.ReadLine());
        Console.Write("Base Fare: ");
        double fare = double.Parse(Console.ReadLine());

        Vehicle v = null;
        if (type == "1") v = new Car(id, model, plate, capacity, fare);
        else if (type == "2") v = new Bus(id, model, plate, capacity, fare);
        else if (type == "3")
        {
            Console.Write("Extra Service Fee: ");
            double extra = double.Parse(Console.ReadLine());
            v = new LuxuryCar(id, model, plate, capacity, fare, extra);
        }

        if (v != null) company.AddVehicle(v);
    }

    private static void AddNewTripUI()
    {
        SystemHelper.PrintHeader("Create New Trip");
        int id = SystemHelper.GenerateId();
        Console.Write("From: ");
        string from = Console.ReadLine();
        Console.Write("To: ");
        string to = Console.ReadLine();
        Console.Write("Distance: ");
        double dist = double.Parse(Console.ReadLine());

        Console.Write("Driver ID: ");
        int driverId = int.Parse(Console.ReadLine());
        Driver driver = company.FindDriverById(driverId);

        Console.WriteLine("Select Trip Type: 1. Local | 2. Intercity | 3. VIP");
        string tType = Console.ReadLine();

        Trip t = null;
        if (tType == "1")
            t = new LocalTrip(id, from, to, dist, DateTime.Now.AddHours(2), driver, driver?.AssignedVehicle, 4, TripStatus.Scheduled);
        else if (tType == "2")
            t = new InterCityTrip(id, from, to, dist, DateTime.Now.AddHours(2), driver, driver?.AssignedVehicle, 20, TripStatus.Scheduled, 2.0);
        else if (tType == "3")
            t = new VIPTrip(id, from, to, dist, DateTime.Now.AddHours(2), driver, driver?.AssignedVehicle, 3, TripStatus.Scheduled, 2.0, 1.5);

        if (t != null) company.CreateTrip(t);
    }

    private static void BookTripUI()
    {
        SystemHelper.PrintHeader("Book Trip");
        Console.Write("Passenger ID: ");
        int pId = int.Parse(Console.ReadLine());
        Console.Write("Trip ID: ");
        int tId = int.Parse(Console.ReadLine());
        Console.Write("Requested Seats Count: ");
        int seats = int.Parse(Console.ReadLine());

        company.BookTrip(pId, tId, seats);
    }

    private static void PayForBookingUI()
    {
        SystemHelper.PrintHeader("Pay for Booking");
        Console.Write("Booking ID: ");
        int bId = int.Parse(Console.ReadLine());

        var booking = company.Bookings.Find(b => b.BookingId == bId);
        if (booking != null)
        {
            booking.Payment = PaymentStatusenum.Paid;
            Console.WriteLine($"[SUCCESS] Booking ID ({bId}) has been paid successfully!");
        }
        else
        {
            throw new InvalidBookingException("Booking not found!");
        }
    }

    private static void CancelBookingUI()
    {
        SystemHelper.PrintHeader("Cancel Booking");
        Console.Write("Booking ID: ");
        int bId = int.Parse(Console.ReadLine());
        company.CancelBooking(bId);
    }

    private static void ShowPassengerBookingsUI()
    {
        SystemHelper.PrintHeader("Show Passenger Bookings");
        Console.Write("Passenger ID: ");
        int pId = int.Parse(Console.ReadLine());

        Passenger p = company.FindPassengerById(pId);
        if (p != null)
        {
            Console.WriteLine($"--- Bookings for Passenger: {p.Name} ---");
            if (p.bookings.Count == 0) Console.WriteLine("No bookings found.");

            foreach (var b in p.bookings)
            {
                Console.WriteLine(b.GenerateReport());
            }
        }
        else
        {
            throw new InvalidBookingException("Passenger not found!");
        }
    }

    private static void RateDriverUI()
    {
        SystemHelper.PrintHeader("Rate Driver");
        Console.Write("Passenger ID: ");
        int pId = int.Parse(Console.ReadLine());
        Console.Write("Driver ID: ");
        int dId = int.Parse(Console.ReadLine());
        Console.Write("Trip ID: ");
        int tId = int.Parse(Console.ReadLine());
        Console.Write("Rating (1 - 5): ");
        int score = int.Parse(Console.ReadLine());

        Passenger p = company.FindPassengerById(pId);
        Driver d = company.FindDriverById(dId);
        Trip t = company.FindTripById(tId);

        if (p != null && d != null)
        {
            p.RatCoplTrip(d, score, t);
        }
        else
        {
            throw new InvalidBookingException("Provided data is invalid for rating!");
        }
    }

    private static void CancelTripUI()
    {
        SystemHelper.PrintHeader("Cancel Trip from Admin");
        Console.Write("Trip ID: ");
        int tId = int.Parse(Console.ReadLine());

        company.CancelTripFromAdmin(tId);
    }

    private static void ShowDriversUI()
    {
        SystemHelper.PrintHeader("Registered Drivers List");
        if (company.Drivers.Count == 0)
        {
            Console.WriteLine("No drivers registered.");
            return;
        }

        foreach (var d in company.Drivers.GetAll())
        {
            Console.WriteLine($"ID: {d.Id} | Name: {d.Name} | License: {d.LicenseNumber} | Rating: {d.GetAverageRating():F1} ★");
        }
    }
}