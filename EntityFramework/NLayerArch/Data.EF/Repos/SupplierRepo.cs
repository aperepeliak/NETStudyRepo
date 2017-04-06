using DomainLayer.Repos;
using DomainLayer.Models;

namespace Data.EF.Repos
{
    public class SupplierRepo : BaseRepo<Supplier>, ISupplierRepo
    {
        ProductContext _context;

        public SupplierRepo(ProductContext context)
        {
            _context = context;
            _table = _context.Suppliers;
        }
    }
}
