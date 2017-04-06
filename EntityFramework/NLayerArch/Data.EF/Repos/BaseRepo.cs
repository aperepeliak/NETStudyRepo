using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.EF.Repos
{
    public abstract class BaseRepo<T> where T : class
    {
        protected DbSet<T> _table;

        public void Add(T entity) => _table.Add(entity);
        public void Delete(T entity)    => _table.Remove(entity);
        public T GetById(int id)        => _table.Find(id);
        public IEnumerable<T> GetAll() => _table.ToList();
    }
}
