using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Infrastructure.DBContext;
using TourBooking.Domain.Entities;
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
