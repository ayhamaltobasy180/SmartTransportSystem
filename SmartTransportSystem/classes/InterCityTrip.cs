using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartTransportSystem.enums;

namespace SmartTransportSystem.classes
{
    public class InterCityTrip : Trip
    {
        public double InterCityFee { get; set; } = 5.0;
        public InterCityTrip() : base()
        {
            
        }
        public InterCityTrip(int tripId, string fromLocation, string toLocation, double distance, DateTime tripDate, Driver driver, Vehicle Vehicle, int availableSeats, TripStatus Status,double interCityFee = 5.0)
           : base(tripId, fromLocation, toLocation, distance, tripDate, driver, Vehicle, availableSeats, Status)
        {
            InterCityFee = interCityFee;
        }
        public override double CalculateTripCost()
        {

            if (Vehicle == null) return 0.0;
            double baseVehicleFare = Vehicle.CalculateFare(Distance);


            {
                return( baseVehicleFare * 1.10)+ InterCityFee;//ضفنا ضريبة على الرحلة والرحلة هون حسابها بكون عبارة عن اعتمادية على نوع المركبة الي بدو يركبها بروح بجيالعملية الحسابية من كلاس المركبة وبضربها بضريبة الشركة وهسا لازم نطبع النتيجة  بميثود اخرى تحت واضفنا هنا رسوم سفر خارجية اي بين المدن زي من عمان للعقبة  
            }
        }
        
        public override void DisplayTripInfo()
        {
            Console.WriteLine($"Local Trip #{TripId}{FromLocation} to {ToLocation} | Distance: {Distance} | Vehicle: {Vehicle?.Model} | Cost: ${CalculateTripCost()} | Status: {Status}");
        }
    }
}