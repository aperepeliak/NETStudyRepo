using DomainLayer.Repos;
using DomainLayer.Models;

namespace Data.EF.Repos
{
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {
        ProductContext _context;

        public CategoryRepo(ProductContext context)
        {
            _context = context;
            _table = _context.Categories;
        }
    }
}
