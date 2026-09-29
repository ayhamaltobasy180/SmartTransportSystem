using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
    public class Bus : Vehicle
    {
        public double RatePerKm { get; set; } = 0.5;

        public Bus() : base()
        {
            Capacity = 30; 
            BaseFare = 1.5;
        }

        public Bus(int vehicleId, string model, string plateNumber, int capacity, double baseFare, double ratePerKm = 0.5)
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
            Console.WriteLine($"[Type: Bus] Capacity: {Capacity} seats | Low Rate/Km: ${RatePerKm}");
        }
    }
    }
