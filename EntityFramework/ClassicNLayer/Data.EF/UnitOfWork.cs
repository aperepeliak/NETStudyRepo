using Data.EF.Interfaces;
using System;
using Data.EF.Models;
using Data.EF.Repos;

namespace Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProductContext _db;

        public IRepo<Product>  Products   { get; private set; }
        public IRepo<Category> Categories { get; private set; }
        public IRepo<Supplier> Suppliers  { get; private set; }

        public UnitOfWork(ProductContext db)
        {
            _db = db;

            Products   = new ProductRepo  (_db);
            Categories = new CategoryRepo (_db);
            Suppliers  = new SupplierRepo (_db);
        }

        public void Save() => _db.SaveChanges();

        #region Dispose
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
