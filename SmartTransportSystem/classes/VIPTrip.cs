using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartTransportSystem.enums;

namespace SmartTransportSystem.classes
{
    using System;

    namespace SmartTransportSystem.classes
    {
        public class VIPTrip : Trip
        {

            public double VipServiceFee  { get; set; } = 15.0;
            public double VipMultiplier { get; set; } = 1.2;
            public VIPTrip() : base()
            {
            }
            public VIPTrip(int tripId, string fromLocation, string toLocation, double distance, DateTime tripDate, Driver driver, Vehicle Vehicle, int availableSeats, TripStatus Status, double vipServiceFee, double vipMultiplier)
                : base(tripId, fromLocation, toLocation, distance, tripDate, driver, Vehicle, availableSeats, Status)
            {



                VipServiceFee = vipServiceFee;
                VipMultiplier = vipMultiplier;
            }
            public override double CalculateTripCost()
            {
                if (Vehicle == null)
                {
                    return 0.0;
                }

                return (Vehicle.CalculateFare(Distance) * VipMultiplier) + VipServiceFee;
            }
            public override void DisplayTripInfo()
            {
                Console.WriteLine($"[VIP Trip #{TripId}] {FromLocation} -> {ToLocation} | Distance: {Distance}km | Vehicle: {Vehicle?.Model} | VIP Fee: ${VipServiceFee} | Total Cost: ${CalculateTripCost()} | Status: {Status}");
            }
        }
    }
}
