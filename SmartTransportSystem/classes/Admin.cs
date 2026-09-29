using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
   public class Admin:Person
    {
        public string Role { get; set; }
        public Admin():base()
        {
            Role = "admin";
        }
        public Admin(int id, string name, string email, string phone, double walletBalance, string role) :
            base(id, name, email, phone)
        {
            Role = role;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("ID" + Id + "NAME" + Name + "Email" + Email + "PHONE" + Phone );
        }
      public void AddTrip(Trip trip)
        {
            if (trip != null)
            {
                Console.WriteLine($"add trip {Name} added {trip.TripId} from {trip.FromLocation} to {trip.ToLocation}");
            }
            else
            {
                Console.WriteLine("[Error] Cannot add a null trip!");
            }
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
        public void GenerateSystemReport()
        {
///شو بنحط فيها مش فاهم 
        }
    }
}
