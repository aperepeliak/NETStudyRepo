using System.Collections.Generic;

namespace DomainLayer.Repos
{
    public interface IBaseRepo<T>
    {
        void Add(T enity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
