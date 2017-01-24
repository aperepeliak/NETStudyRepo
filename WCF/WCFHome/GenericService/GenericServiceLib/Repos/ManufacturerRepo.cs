using GenericServiceLib.Models;

namespace GenericServiceLib.Repos
{
    public class ManufacturerRepo : GenericRepo<Manufacturer>, IGenericRepository<Manufacturer>
    {
        public ManufacturerRepo()
        {
            Table = Context.Manufacturers;
        }
    }
}
