using TourBooking.Data.DBContext;
using TourBooking.Data.Entities;
using TourBooking.Data.GenericRepository;
using TourBooking.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Domain.Services
{
    public class PersonService:IPersonService
    {
        private IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void SaveSomthing()
        {
            var obj = new Person()
            {
                FamilyName="rezaiyan",
                FirstName="Sajad",
                PersonId=new Guid()
            };
            _personRepository.Insert(obj);
            //_personRepository.Save();

        }
    }
}
