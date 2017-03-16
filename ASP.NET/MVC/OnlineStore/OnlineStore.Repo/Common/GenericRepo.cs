using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineStore.Repo.Common
{
    public class GenericRepo<T> : IGenericRepo<T> 
                                  where T: class
    {
        protected DbContext          _context;
        protected readonly IDbSet<T> _dbset;

        public GenericRepo(DbContext context)
        {
            _context = context;
            _dbset   = context.Set<T>();
        }

        public T Add    (T entity)      => _dbset.Add(entity);
        public T Delete (T entity)      => _dbset.Remove(entity);
        public void Edit(T entity)      => _context.Entry(entity).State = EntityState.Modified;

        public T Get    (int id)        => _dbset.Find(id);
        public IEnumerable<T> GetAll()  => _dbset.AsEnumerable();
        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate) 
                                        => _dbset.Where(predicate).AsEnumerable();
    }
}
