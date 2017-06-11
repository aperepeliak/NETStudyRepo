using System.Collections.Generic;

namespace GS.Domain.Repos
{
    public interface IBaseRepo<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        IEnumerable<T> GetAll();
    }
}
