using Data.AdoNet.Interfaces;
using Data.AdoNet.Models;
using Data.AdoNet.Repos;

namespace Data.AdoNet
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProductContext _context;

        public IRepo<Product>  Products   { get; private set; }
        public IRepo<Category> Categories { get; private set; }
        public IRepo<Supplier> Suppliers  { get; private set; }

        public UnitOfWork(ProductContext context)
        {
            _context = context;

            Products   = new ProductRepo  (_context);
            Categories = new CategoryRepo (_context);
            Suppliers  = new SupplierRepo (_context);
        }

        public void Save() => _context.SaveChanges();
    }
}
