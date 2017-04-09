using ST.Core.Models;
using System.Collections.Generic;

namespace ST.Core.Repos
{
    public interface IManagerRepo
    {
        void Add(Manager manager);
        void Remove(Manager manager);
        Manager GetManager(string id);
        IEnumerable<Manager> GetAll();
    }
}
