using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
   public interface IPayable
    {
      bool Pay(decimal amount);
        bool Refund(decimal amount);
    }
}
