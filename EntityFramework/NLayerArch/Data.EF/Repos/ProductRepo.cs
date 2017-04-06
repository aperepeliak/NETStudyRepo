using DomainLayer.Repos;
using DomainLayer.Models;

namespace Data.EF.Repos
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        ProductContext _context;
        public ProductRepo(ProductContext context)
        {
            _context = context;
            _table = _context.Products;
        }
    }
}
