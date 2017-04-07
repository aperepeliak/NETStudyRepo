using System.Collections.Generic;

namespace DomainLayer.Repos
{
    public interface IBaseRepo<T>
    {
        void Add(T entity);
        T Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
