using ST.Core.Models;
using System.Collections.Generic;

namespace ST.Core.Repos
{
    public interface ICategoryRepo
    {
        void Add(Category category);
        Category Remove(Category category);
        IEnumerable<Category> GetAll();
        Category GetCategoryById(int categoryId);
    }
}
