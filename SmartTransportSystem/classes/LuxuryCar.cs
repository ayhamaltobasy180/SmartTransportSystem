using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
    using System;

    namespace SmartTransportSystem.classes
    {
        public class LuxuryCar : Vehicle
        {
            public double RatePerKm { get; set; } = 3.0;
            public double ExtraServiceFee { get; set; } = 10.0;

            public LuxuryCar() : base()
            {
                Capacity = 4;
                BaseFare = 5.0;
            }

            public LuxuryCar(int vehicleId, string model, string plateNumber, int capacity, double baseFare, double extraServiceFee = 10.0, double ratePerKm = 3.0)
                : base(vehicleId, model, plateNumber, capacity, baseFare)
            {
                ExtraServiceFee = extraServiceFee;
                RatePerKm = ratePerKm;
            }

            
            public override double CalculateFare(double distance)
            {
                return BaseFare + (distance * RatePerKm) + ExtraServiceFee;
            }

       
            public override void DisplayVehicleDetails()
            {
                base.DisplayVehicleDetails();
                Console.WriteLine($"Type: Luxury Car Service Fee:{ExtraServiceFee} | Premium Rate/Km:{RatePerKm}");
            }
        }
    }
}
