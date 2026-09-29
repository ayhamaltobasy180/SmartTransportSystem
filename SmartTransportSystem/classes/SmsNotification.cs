using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
  public class SmsNotification:Notification
    {
        public int NumPhone { get; set;}
        public SmsNotification(string message, int numPhone):base(message){
        NumPhone=numPhone;
        }
        public override void send(){
            Console.WriteLine($"this is message {Message} to {NumPhone} on date {CreadetAt}");
        }
    }
}
