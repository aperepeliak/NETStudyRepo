using Data.EF.Interfaces;
using Data.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.EF.Repos
{
    public class CategoryRepo : IRepo<Category>
    {
        private ProductContext _db;
        public CategoryRepo(ProductContext db)
        {
            _db = db;
        }

        public void Create(Category entity)   => _db.Categories.Add(entity);
        public void Delete(Category entity)   => _db.Entry(entity).State = EntityState.Deleted;
        public Category Get(int id)           => _db.Categories.Find(id);
        public IEnumerable<Category> GetAll() => _db.Categories;

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
                                              => _db.Categories.Where(predicate).ToList();
    }
}
