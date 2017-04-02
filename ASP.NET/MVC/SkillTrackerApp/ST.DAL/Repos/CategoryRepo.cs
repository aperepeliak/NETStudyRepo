using ST.Core.Repos;
using System;
using System.Collections.Generic;
using ST.Core.Models;

namespace ST.DAL.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Category skill)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Category skill)
        {
            throw new NotImplementedException();
        }
    }
}
