using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
    public class CashPayment:PaymentMethod
    {
    public decimal CashRecived { get; set; }
        public CashPayment(int paymentId, decimal amount, decimal cashRecived) :
        base(paymentId,amount)
        {
            CashRecived= cashRecived;
        }
        public override bool ProcessPayment(){
            if (CashRecived < Amount)
            {
                Console.WriteLine($"this is error becouse this little than trip amount, amount is {Amount} and cash you{CashRecived}  ");
                return false;

            }
            else
            {
                decimal change = CashRecived - Amount;
                Console.WriteLine($"this is  trip amount  this done, " +
                $"amount is {Amount} and cash you{CashRecived} and  change is {change}  ");
                return true;
                
            }

        }
        public override  void PrintPaymentInfo()
        {
           base.PrintPaymentInfo();
            Console.WriteLine($"{CashRecived}jod");
        }

    }
}
