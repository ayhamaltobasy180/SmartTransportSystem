using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
    public class ConsoleNotification : Notification
    {
        public ConsoleNotification(string message):base(message)
        {

        }
        public override void send()
        {
            Console.WriteLine($"this is message {Message} on date{CreadetAt}");
        }
    }
}