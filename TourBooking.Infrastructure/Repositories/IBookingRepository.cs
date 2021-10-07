using TourBooking.Infrastructure.Entities;
using TourBooking.Infrastructure.GenericRepository;

namespace TourBooking.Infrastructure.Repositories
{
    public interface IBookingRepository: IGenericRepository<Booking>
    {
    }
}
