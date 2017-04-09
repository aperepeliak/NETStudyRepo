using ST.Core.Repos;
using System.Collections.Generic;
using ST.Core.Models;
using System.Data.Entity;

namespace ST.DAL.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private ApplicationDbContext _context;
        public CategoryRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Category category)        => _context.Categories.Add(category);
        public void Remove(Category category)     => _context.Entry(category).State = EntityState.Deleted;
        public IEnumerable<Category> GetAll()     => _context.Categories;
        public Category GetCategory(int id)       => _context.Categories.Find(id);
    }
}
