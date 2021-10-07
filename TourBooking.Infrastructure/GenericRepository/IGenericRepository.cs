using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBooking.Infrastructure.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IQueryable<T> GetAllAsQueryAble();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        Task<int> SaveChangesAsync();
    }
}
