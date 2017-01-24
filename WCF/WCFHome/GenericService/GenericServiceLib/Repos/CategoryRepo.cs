using GenericServiceLib.Models;

namespace GenericServiceLib.Repos
{
    public class CategoryRepo : GenericRepo<Category>, IGenericRepository<Category>
    {
        public CategoryRepo()
        {
            Table = Context.Categories;
        }
    }
}
