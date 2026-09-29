using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SmartTransportSystem.enums;

namespace SmartTransportSystem.classes
{
   public class LocalTrip:Trip
    {

        public LocalTrip() : base()
        {
        }
        public LocalTrip(int tripId, string fromLocation, string toLocation, double distance, DateTime tripDate, Driver driver, Vehicle Vehicle, int availableSeats, TripStatus Status)
            : base(tripId, fromLocation, toLocation, distance, tripDate, driver, Vehicle, availableSeats,Status)
        {
           
        }

        // 3. اكتب ميثود حساب التكلفة بإيدك
        // فكر: التكلفة هي ناتج حساب سعر المركبة للمسافة (Vehicle.CalculateFare(Distance))
        public override double CalculateTripCost()
        {
            if (Vehicle == null) return 0.0;
                double baseVehicleFare = Vehicle.CalculateFare(Distance);
           
       
            {
                return baseVehicleFare*1.10;//ضفنا ضريبة على الرحلة والرحلة هون حسابها بكون عبارة عن اعتمادية على نوع المركبة الي بدو يركبها بروح بجيالعملية الحسابية من كلاس المركبة وبضربها بضريبة الشركة وهسا لازم نطبع النتيجة  بميثود اخرى تحت  
            }
        }
          
       
        public override void DisplayTripInfo()
        {
            Console.WriteLine($"Local Trip #{TripId}{FromLocation} to {ToLocation} | Distance: {Distance} | Vehicle: {Vehicle?.Model} | Cost: ${CalculateTripCost()} | Status: {Status}");
        }
    }
}
