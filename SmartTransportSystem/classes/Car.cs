using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
        public class Car : Vehicle
        {
            public double RatePerKm { get; set; } = 1.5; 

            public Car() : base() {
            Capacity = 5;
            BaseFare = 3.0;
        
     }

            public Car(int vehicleId, string model, string plateNumber, int capacity, double baseFare, double ratePerKm = 1.5)
                : base(vehicleId, model, plateNumber, capacity, baseFare)
            {
                RatePerKm = ratePerKm;
         
            }

        
            public override double CalculateFare(double distance)
            {
                return BaseFare + (distance * RatePerKm);
            }
            public override void DisplayVehicleDetails()
            {
                base.DisplayVehicleDetails();
                Console.WriteLine($"Type: Regular Car Rate Per Km: {RatePerKm}");
            }

        
    }
    }
