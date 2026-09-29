using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
    public abstract class PaymentMethod
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
     
        public PaymentMethod(){ }
        public PaymentMethod(int paymentId, decimal amount)
        {
            PaymentId = paymentId;
            Amount = amount;
            PaymentDate = DateTime.Now;
        }
        public abstract bool ProcessPayment();

        public virtual void PrintPaymentInfo()
        {
            Console.WriteLine($"[Payment #{PaymentId}] Amount: {Amount} JOD | Date: {PaymentDate}");
        }
    }
}
