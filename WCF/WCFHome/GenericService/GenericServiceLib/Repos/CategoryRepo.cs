using GenericServiceLib.Models;

namespace GenericServiceLib.Repos
{
    // Add known type here ???
    public class CategoryRepo : GenericRepo<Category>, IGenericRepository<Category>
    {
        public CategoryRepo()
        {
            Table = Context.Categories;
        }
    }
}
