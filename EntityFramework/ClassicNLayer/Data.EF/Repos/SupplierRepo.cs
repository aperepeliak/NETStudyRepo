using Data.EF.Interfaces;
using Data.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.EF.Repos
{
    public class SupplierRepo : IRepo<Supplier>
    {
        private ProductContext _db;
        public SupplierRepo(ProductContext db)
        {
            _db = db;
        }

        public void Create(Supplier entity)   => _db.Suppliers.Add(entity);
        public void Delete(Supplier entity)   => _db.Entry(entity).State = EntityState.Deleted;
        public Supplier Get(int id)           => _db.Suppliers.Find(id);
        public IEnumerable<Supplier> GetAll() => _db.Suppliers;

        public IEnumerable<Supplier> Find(Func<Supplier, bool> predicate)
                                              => _db.Suppliers.Where(predicate).ToList();
    }
}
