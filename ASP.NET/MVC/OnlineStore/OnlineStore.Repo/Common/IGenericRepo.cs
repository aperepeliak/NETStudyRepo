using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineStore.Repo.Common
{
    public interface IGenericRepo<T>
    {
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();

        T Get       (int id);
        T Add       (T entity);
        T Delete    (T entity);
        void Edit   (T entity);
    }
}
