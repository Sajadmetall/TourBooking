using TourBooking.Domain.Entities;
using TourBooking.Infrastructure.GenericRepository;

namespace TourBooking.Infrastructure.Repositories
{
    public interface IBookingRepository: IGenericRepository<Booking>
    {
    }
}
