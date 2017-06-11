using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GS.DAL.Repos
{
    public abstract class BaseRepo<T> where T : class
    {
        protected readonly AppContext _context;
        protected DbSet<T> _table;

        public BaseRepo(AppContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _table.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }
    }
}
