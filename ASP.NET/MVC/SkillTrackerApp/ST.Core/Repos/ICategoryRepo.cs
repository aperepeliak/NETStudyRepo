using ST.Core.Models;
using System.Collections.Generic;

namespace ST.Core.Repos
{
    public interface ICategoryRepo
    {
        void Add(Category skill);
        bool Remove(Category skill);
        IEnumerable<Category> GetAll();
    }
}
