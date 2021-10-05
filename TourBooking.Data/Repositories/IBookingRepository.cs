using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Data.Entities;
using TourBooking.Data.GenericRepository;

namespace TourBooking.Data.Repositories
{
    public interface IBookingRepository: IGenericRepository<Booking>
    {
    }
}
