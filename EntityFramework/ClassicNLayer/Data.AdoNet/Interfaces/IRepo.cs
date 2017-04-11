using System.Collections.Generic;

namespace Data.AdoNet.Interfaces
{
    public interface IRepo<T> where T : class
    {
        void           Create(T entity);
        void           Delete(T entity);
        T              Get(int id);
        IEnumerable<T> GetAll();
    }
}
