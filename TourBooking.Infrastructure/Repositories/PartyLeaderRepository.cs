using TourBooking.Domain.Contracts;
using TourBooking.Domain.Entities;
using TourBooking.Infrastructure.DBContext;
using TourBooking.Infrastructure.GenericRepository;

namespace TourBooking.Infrastructure.Repositories
{
    public class PartyLeaderRepository: GenericRepository<PartyLeader>, IPartyLeaderRepository
    {
        public PartyLeaderRepository(ApplicationDBContext context)
            : base(context)
        {
        }
    }
}
