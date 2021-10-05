using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Data.DBContext;
using TourBooking.Data.Entities;
using TourBooking.Data.GenericRepository;

namespace TourBooking.Data.Repositories
{
    public class BookingRepository: GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationDBContext context)
            : base(context)
        {
        }
    }
}
