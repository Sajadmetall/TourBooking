using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TourBooking.Application.Enumeration.BookingEnumeration;

namespace TourBooking.Application.ViewModels
{
    public class BookingViewModel
    {
        public Guid? BookingId { get; set; }
        
        public string Name { get; set; }
        public Nullable<DateTime> CreateDate { get; set; }
        public Nullable<BookingStatus> Status { get; set; }
        public string StatusText { get; set; }
        public string Price { get; set; }
        public Nullable<BookingCurrency> Currency { get; set; }
        public string CurrencyText { get; set; }
        public List<PartyLeaderViewModel> PartyLeaders { get; set; }

        public static string SetStatusText(BookingStatus status)
        {
            if (status == BookingStatus.Temporary)
                return "Temporary";
            else if (status == BookingStatus.Confirmed)
                return "Confirmed";
            else
                return "Canceled";
        }

        internal static string SetCurrencyText(BookingCurrency currency)
        {
            if (currency == BookingCurrency.USDolar)
                return "USDolar";
            else if (currency == BookingCurrency.Euro)
                return "Euro";
            else
                return "Pound";
        }
    }
}
