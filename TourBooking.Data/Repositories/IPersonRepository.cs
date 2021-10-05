using TourBooking.Data.Entities;
using TourBooking.Data.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBooking.Data.Repositories
{
    public interface IPersonRepository: IGenericRepository<Person>
    {
        List<Person> GetPersonTest();

    }
}
