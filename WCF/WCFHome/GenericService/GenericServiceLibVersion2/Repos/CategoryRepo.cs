using GenericServiceLib.Models;

namespace GenericServiceLib.Repos
{
    // Add known type here ???
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        public CategoryRepo()
        {
            Table = Context.Categories;
        }
    }
}
