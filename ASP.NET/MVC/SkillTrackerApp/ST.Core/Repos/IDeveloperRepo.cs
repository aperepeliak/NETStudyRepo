using ST.Core.Models;
using System.Collections.Generic;

namespace ST.Core.Repos
{
    public interface IDeveloperRepo
    {
        void Add(Developer developer);
        void Remove(Developer developer);
        Developer GetDeveloper(string id);
        IEnumerable<Developer> GetAll();
    }
}
