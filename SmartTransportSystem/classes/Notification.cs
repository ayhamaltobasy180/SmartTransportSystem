using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
  public abstract class Notification
    {
        public string Message{ get; set; }
        public DateTime CreadetAt { get; set; }
        public Notification() { }
        public Notification(string message){
            Message = message;
            CreadetAt = DateTime.Now;
        }
        public abstract void send();

    }
}
