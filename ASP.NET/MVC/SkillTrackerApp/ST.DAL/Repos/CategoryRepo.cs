﻿using ST.Core.Repos;
using System.Collections.Generic;
using ST.Core.Models;
using System.Linq;

namespace ST.DAL.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Category category)        => _context.Categories.Add(category);
        public Category Remove(Category category) => _context.Categories.Remove(category);
        public IEnumerable<Category> GetAll()     => _context.Categories;
    }
}
