using TourBooking.Data.DBContext;
using TourBooking.Data.Entities;
using TourBooking.Data.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBooking.Data.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDBContext context)
            : base(context)
        {
        }

        public List<Person> GetPersonTest()
        {
            return this.GetAll().Take(10).ToList();
        }
    }
}
