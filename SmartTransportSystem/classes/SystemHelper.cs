using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTransportSystem.classes
{
    using System;
    using System.Text.RegularExpressions;

    namespace SmartTransportSystem.classes
    {
        public static class SystemHelper
        {
            private static int counter = 1000;

            public static int GenerateId()
            {
                return ++counter;
            }

            public static bool ValidateEmail(string email)
            {
                if (string.IsNullOrWhiteSpace(email))
                    return false;

                // نمط التعبير النمطي (Regex) للتحقق من صحة الإيميل
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                return Regex.IsMatch(email, emailPattern);
            }
            public static string FormatCurrency(double amount)
            {
                return $"{amount:F2} JOD";
            }

            public static void PrintHeader(string title)
            {
                
                Console.WriteLine($"{title}");
            }

            public static void Log(string message)
            {
            
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
            }
        }
    }
}
