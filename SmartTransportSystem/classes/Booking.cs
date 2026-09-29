using SmartTransportSystem.classes.SmartTransportSystem.classes;
using SmartTransportSystem.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
    public class Booking: IBookable,IPayable, IReportable
    {
      public  int BookingId { get; set; }
        public Passenger Passenger { get; set; }
        public Trip Trip { get; set; }
        public int SeatsCount { get; set; }
        public decimal TotalAmount { get; set; }
        public BookingStatusenum Status { get; set; } = BookingStatusenum.Pending;
        public PaymentStatusenum Payment { get; set; } = PaymentStatusenum.Unpaid;
        public DateTime CreatedAt { get; set; }
        public Booking()
        {

        }
        public Booking(int bookingId, Passenger passenger, Trip trip, int seatsCount)
        {
            BookingId = bookingId;
            Passenger = passenger;
            Trip = trip;
            SeatsCount = seatsCount;
            CreatedAt = DateTime.Now;
            Status = BookingStatusenum.Pending;

            if (trip != null)
            {
                TotalAmount = (decimal)trip.CalculateTripCost() * seatsCount;//سعر المقعد الفردي  بارجعو
            }
        }

        public bool Book()
        {
            if (Status == BookingStatusenum.Cancelled || Status == BookingStatusenum.Confirmed)
            {
                Console.WriteLine("عذرا لا يمكن تأكيد هذا الحجز");
                return false;
            }

            Status = BookingStatusenum.Confirmed;
            Console.WriteLine($"تم تأكيد الحجز رقم {BookingId} بنجاح.");
            return true;
        }

        public bool Cancle()
        {
            if (Status == BookingStatusenum.Cancelled)
            {
                Console.WriteLine("الحجز ملغى بالفعل!");
                return false;
            }

            Status = BookingStatusenum.Cancelled;
            Console.WriteLine($"تم إلغاء الحجز رقم {BookingId}.");
            return true;
        }

        public bool Pay(decimal amount)
        {
            if (Payment == PaymentStatusenum.Paid)
            {
                Console.WriteLine("هذا الحجز مدفوع مسبقاً!");
                return false;
            }

            if (amount < TotalAmount)
            {
                Console.WriteLine($"المبلغ المدفوع غير كافٍ! المطلوب: {TotalAmount}");
                return false;
            }

            Payment = PaymentStatusenum.Paid;
            Console.WriteLine($"تم دفع مبلغ {amount} بنجاح للحجز رقم {BookingId}.");
            return true;
        }

        public bool Refund(decimal amount)
        {
            if (Payment != PaymentStatusenum.Paid)
            {
                Console.WriteLine("لا يمكن استرجاع مبلغ لحجز غير مدفوع أصلاً!");
                return false;
            }

            Payment = PaymentStatusenum.Refunded;
            Console.WriteLine($"تم استرجاع مبلغ {amount} للحجز رقم {BookingId}.");
            return true;
        }
        public void PrintBookingDetails(){
          Console.WriteLine($"[Booking #{BookingId}] Passenger: {Passenger?.Name ?? "N/A"} | Trip: {Trip?.GetType().Name ?? "N/A"} | Seats: {SeatsCount} | Total: {TotalAmount} JOD | Status: {Status} | Payment: {Payment} | Date: {CreatedAt}");
        }
        public string GenerateReport()
        {
            string passengerName = Passenger != null ? Passenger.Name : "N/A";
            return $"[Booking Report] BookingID: {BookingId} | TripID: {Trip?.TripId} | Passenger: {passengerName} | Payment: {Payment}";
        }
    }
}
