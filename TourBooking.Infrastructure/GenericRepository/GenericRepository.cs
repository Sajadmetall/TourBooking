using TourBooking.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourBooking.Infrastructure.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {


        private ApplicationDBContext _context = null;
        private Microsoft.EntityFrameworkCore.DbSet<T> table = null;


        public GenericRepository(ApplicationDBContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public IQueryable<T> GetAllAsQueryAble()
        {
            return table.AsQueryable();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Delete(T obj)
        {
            _context.Remove(obj);
        }
    }
}
