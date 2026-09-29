using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
    public class WalletPayment : PaymentMethod
    {
        Passenger Passenger { get; set; }
        public WalletPayment(int paymentId, decimal amount, Passenger passenger) :
          base(paymentId, amount)
        {
            Passenger = passenger; throw new ArgumentNullException(nameof(passenger), "الراكب لا يمكن أن يكون null");
        }
        public override bool ProcessPayment()
        {
            if (Passenger == null)
            {
                Console.WriteLine($" passenger data not here");
                return false;
            }
            else if ((decimal)Passenger.WalletBalance < Amount)
            {
                Console.WriteLine($" passenger doesnt payament amount of trip {Passenger.WalletBalance}  ");
                return false;
            }
            else {
                Passenger.WalletBalance-=(double)Amount;
                Console.WriteLine($"[Wallet Payment Successful] تم خصم " +
                $"{Amount} JOD من محفظة {Passenger.Name}. " +
                $"الرصيد الجديد: {Passenger.WalletBalance} JOD");
                return true; }
        }
    }
}