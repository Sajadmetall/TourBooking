using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBooking.Domain.Enumeration
{
    public class Enumeration
    {
        public enum BookingStatus
        {
            Temporary,
            Confirmed,
            Canceled
        }
        public enum BookingCurrency { 
            USDolar,
            Euro,
            Pound
        }
    }
}
