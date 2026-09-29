using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace SmartTransportSystem.classes
    {
        public class InvalidBookingException : Exception
        {
            public InvalidBookingException(string message) : base(message) { }
        }

        public class TripFullyBookedException : Exception
        {
            public TripFullyBookedException(string message) : base(message) { }
        }

        public class InsufficientBalanceException : Exception
        {
            public InsufficientBalanceException(string message) : base(message) { }
        }

        public class VehicleUnavailableException : Exception
        {
            public VehicleUnavailableException(string message) : base(message) { }
        }

        public class InvalidRatingException : Exception
        {
            public InvalidRatingException(string message) : base(message) { }
        }

        public class PaymentFailedException : Exception
        {
            public PaymentFailedException(string message) : base(message) { }
        }
    }