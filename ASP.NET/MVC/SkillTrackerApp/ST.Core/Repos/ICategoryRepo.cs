using ST.Core.Models;
using System.Collections.Generic;

namespace ST.Core.Repos
{
    public interface ICategoryRepo
    {
        void Add(Category category);
        Category Remove(Category category);
        Category GetCategory(int categoryId);
        IEnumerable<Category> GetAll();
    }
}
