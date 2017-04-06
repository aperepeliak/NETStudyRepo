using DomainLayer;
using DomainLayer.Repos;
using Data.EF.Repos;

namespace Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProductContext _context;

        public IProductRepo  Products   { get; private set; }
        public ICategoryRepo Categories { get; private set; }
        public ISupplierRepo Suppliers  { get; private set; }

        public UnitOfWork(ProductContext context)
        {
            _context = context;

            Products = new ProductRepo(_context);
            Categories = new CategoryRepo(_context);
            Suppliers = new SupplierRepo(_context);
        }

        public void Complete() => _context.SaveChanges();
    }
}
