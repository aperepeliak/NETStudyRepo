using System.Collections.Generic;

namespace DomainLayer.Repos
{
    public interface IBaseRepo<T>
    {
        void Add(T entity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
