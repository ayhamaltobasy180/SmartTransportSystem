using System;

namespace SmartTransportSystem.classes
{
    public class CardPayment : PaymentMethod
    {
        public string CardNumber { get; set; }
        public string CardName { get; set; }

        public CardPayment(int paymentId, decimal amount, string cardNumber, string cardName)
            : base(paymentId, amount)
        {
            CardNumber = cardNumber ;
            CardName = cardName;
        }

        public override bool ProcessPayment()
        {
            switch (true)
            {
                // 1. التحقق من رقم البطاقة
                case bool _ when string.IsNullOrWhiteSpace(CardNumber) || CardNumber.Length < 12:
                    Console.WriteLine("[Card Error] رقم البطاقة غير صحيح!");
                    return false;
                    break;
                // 2. التحقق من اسم صاحب البطاقة
                case bool _ when string.IsNullOrWhiteSpace(CardName):
                    Console.WriteLine("[Card Error] اسم صاحب البطاقة مطلوب!");
                    return false;

                // 3. حالة نجاح عملية الدفع
                default:
                    string lastFourDigits = CardNumber.Substring(CardNumber.Length - 4);
                    Console.WriteLine($"[Card Payment Successful]" +$" خصم" +
                    $" {Amount} JOD من البطاقة المنتهية بـ (****{lastFourDigits}) للعميل {CardName}.");
                    return true;
            }
        }

        public override void PrintPaymentInfo()
        {
            base.PrintPaymentInfo();
            string lastFourDigits = CardNumber.Length >= 4 ? CardNumber.Substring(CardNumber.Length - 4) : "****";
            Console.WriteLine($"Payment Type: Credit/Debit Card (****{lastFourDigits}) | Holder: {CardName}");
        }
    }
}