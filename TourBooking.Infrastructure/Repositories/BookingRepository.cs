using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Infrastructure.DBContext;
using TourBooking.Infrastructure.Entities;
using TourBooking.Infrastructure.GenericRepository;

namespace TourBooking.Infrastructure.Repositories
{
    public class BookingRepository: GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationDBContext context)
            : base(context)
        {
        }
    }
}
