using BusinessLayer.DTOs;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface ICategoryService
    {
        void AddCategory(CategoryDTO categoryDto);
        CategoryDTO GetCategory(int id);
        IEnumerable<CategoryDTO> GetCategories();
    }
}
