using System;
using System.Collections.Generic;

namespace Data.EF.Interfaces
{
    public interface IRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
