using BusinessLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.DTOs;

// If using EF data layer
// using Data.EF.Interfaces;
// using Data.EF.Models;

// If using ADO.NET data layer
using Data.AdoNet.Interfaces;
using Data.AdoNet.Models;

namespace BusinessLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _db;
        public CategoryService(IUnitOfWork db)
        {
            _db = db;
        }

        public void AddCategory(CategoryDTO categoryDto)
        {
            _db.Categories.Create(new Category
            {
                Name = categoryDto.Name
            });

            _db.Save();
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            return _db.Categories.GetAll().Select(p => new CategoryDTO
            {
                Id = p.Id,
                Name = p.Name
            });
        }

        public CategoryDTO GetCategory(int id)
        {
            var category = _db.Categories.Get(id);

            return new CategoryDTO
            {
                Id   = category.Id,
                Name = category.Name,
            };
        }
    }
}
