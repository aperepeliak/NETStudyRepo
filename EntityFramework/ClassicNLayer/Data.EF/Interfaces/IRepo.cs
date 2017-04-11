using System;
using System.Collections.Generic;

namespace Data.EF.Interfaces
{
    public interface IRepo<T> where T : class
    {
        void           Create (T entity);
        void           Delete (T entity);
        T              Get    (int id);
        IEnumerable<T> GetAll ();
        IEnumerable<T> Find   (Func<T, Boolean> predicate);
    }
}
