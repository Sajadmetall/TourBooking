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
                return BookingStatus.Temporary.ToString();
            else if (status == BookingStatus.Confirmed)
                return BookingStatus.Confirmed.ToString();
            else
                return BookingStatus.Canceled.ToString();
        }

        internal static string SetCurrencyText(BookingCurrency currency)
        {
            if (currency == BookingCurrency.USDolar)
                return BookingCurrency.USDolar.ToString();
            else if (currency == BookingCurrency.Euro)
                return BookingCurrency.Euro.ToString();
            else
                return BookingCurrency.Pound.ToString();
        }
    }
}
