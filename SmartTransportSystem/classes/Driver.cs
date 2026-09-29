using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
   public class Driver:Person,INotifiable,IRatable
    {
        private List<int> _ratings = new List<int>();
        public string LicenseNumber { get; set; }
    public int Rating { get; set; }

	public Vehicle AssignedVehicle { get; set; } 
	public bool IsAvailable { get; set; }
        public Driver() : base()
        {
            LicenseNumber = "N/A";
            IsAvailable = true; 
            Rating = 5;
            AssignedVehicle = null;
        }
        public Driver(int id, string name, string email, string phone, string licenseNumber) :
            base(id, name, email, phone)

        { 
            LicenseNumber = licenseNumber;
            IsAvailable = true;
            Rating = 5;
           
        }
    
        public int AddRating(int value)
        {
            if (value >= 1 && value <= 5)
            {
                Rating = value;
                Console.WriteLine($"Driver {Name}'s rating updated to: {Rating}");
                return Rating;
            }
            else
            {
                Console.WriteLine("Rating must be between 1.0 and 5.0");
                return 0;
            }
        }
       
        public double GetAverageRating(){
            if (_ratings.Count == 0)
                return 5.0; // التقييم الافتراضي للسائق الجديد

            return _ratings.Average();
        }
        
        public void AssignVehicle(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                AssignedVehicle = vehicle;
                Console.WriteLine($"Vehicle assigned successfully to driver {Name}.");
            }
            else
            {
                Console.WriteLine("Invalid vehicle!");
            }
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("ID" + Id + "NAME" + Name + "Email" + Email + "PHONE" + Phone+"Rating"+Rating);
        }
        public void Notify(Notification notification){
            Console.WriteLine("this is noty to Driver ");
            notification.send();
        }
      
    }

}
