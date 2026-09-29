using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
    public class EmailNotification : Notification
    {
    public string EmailAddress { get; set; }
  
        public EmailNotification(string message, string emailAddress) :
        base(message)
        {
            EmailAddress = emailAddress;
        }

        public override void send(){
            Console.WriteLine($"this is massage{Message}" +
            $" to email:{EmailAddress} time:{CreadetAt}");
        }

    }
}
