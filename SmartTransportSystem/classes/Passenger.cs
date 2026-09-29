using SmartTransportSystem.classes.SmartTransportSystem.classes;
using SmartTransportSystem.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes

{
    public class Passenger : Person,INotifiable
    {
        public double WalletBalance { get; set; }
        public List<Booking> bookings { get; set; }
        public Passenger(int id, string name, string email, string phone, double walletBalance) :
            base(id, name, email, phone)

        {

            WalletBalance = walletBalance;
            bookings = new List<Booking>();
        }
        public Passenger() : base()
        {
            WalletBalance = 0.0;
            bookings = new List<Booking>();

        }
        public override void DisplayInfo()
        {
            Console.WriteLine("ID" + Id + "NAME" + Name + "Email" + Email + "PHONE" + Phone);
        }
        public void AddBalance(decimal amount)
        {

            if (amount > 0)
            {
                WalletBalance += (double)amount;
                Console.WriteLine($"added {amount}.new Balance:{WalletBalance}");

            }
            else
            {
                Console.WriteLine("inter num posative");
            }
        }
        public void BookTrip(Trip trip, int seats)
        {
            Booking newBooking = new Booking();
            bookings.Add(newBooking);
            Console.WriteLine($"sucssefully add {seats}");
        }
        public bool CancelBooking(int bookingId)
        {
            Booking bookingToRemove = bookings.Find(b => b.BookingId == bookingId);


            if (bookingToRemove != null)
            {
                bookings.Remove(bookingToRemove);
                Console.WriteLine($"Booking {bookingId}  cancelled.");
                return true;
            }


            Console.WriteLine($"Booking {bookingId} not found");
            return false;
        }
       public void Notify(Notification notification)
        {
            Console.WriteLine("this is noty to passenger ");
            notification.send();
        }
        public void RatCoplTrip(Driver driver, int score, Trip trip)
        {
        if(driver==null||trip==null){
                Console.WriteLine("no trip so no driver so no rating");
                return; 
        }
            bool hasCompletedBooking = bookings.Any(b => b.Trip.TripId == trip.TripId &&
                                                     b.Trip.Driver != null &&
                                                     b.Trip.Driver.Id == driver.Id &&
                                                     b.Payment == PaymentStatusenum.Paid);
            if (!hasCompletedBooking)
            {
                Console.WriteLine($"[Rating Denied] You cannot rate driver {driver.Name} because you do not have a paid/completed booking with them for this trip!");
                return;
            }

            Console.WriteLine($"Passenger ({Name}) is rating driver ({driver.Name})...");
            driver.AddRating(score);
        }

      
    }
}

