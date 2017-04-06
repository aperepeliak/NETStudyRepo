using Data.AdoNet.Repos;
using DomainLayer;
using DomainLayer.Repos;

namespace Data.AdoNet
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

            Products    = new ProductRepo(_context.Products);
            //Categories  = new CategoryRepo(_context.Categories);
            //Suppliers   = new SupplierRepo(_context.Suppliers);
        }

        public void Complete() => _context.SaveChanges();
    }
}
