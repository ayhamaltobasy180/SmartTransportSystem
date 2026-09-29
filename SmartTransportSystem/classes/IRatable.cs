using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
   public interface IRatable
    {
      public int AddRating(int Rating);
     public double GetAverageRating();
    }
}
