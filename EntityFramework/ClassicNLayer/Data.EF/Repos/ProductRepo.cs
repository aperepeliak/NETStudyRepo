using Data.EF.Interfaces;
using Data.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.EF.Repos
{
    public class ProductRepo : IRepo<Product>
    {
        private ProductContext _db;
        public ProductRepo(ProductContext db)
        {
            _db = db;
        }

        public void Create(Product entity)   => _db.Products.Add(entity);
        public void Delete(Product entity)   => _db.Entry(entity).State = EntityState.Deleted;
        public void Update(Product entity)   => _db.Entry(entity).State = EntityState.Modified;
        public Product Get(int id)           => _db.Products.Find(id);
        public IEnumerable<Product> GetAll() => _db.Products;

        public IEnumerable<Product> Find(Func<Product, bool> predicate) 
                                             => _db.Products.Where(predicate).ToList();
    }
}
