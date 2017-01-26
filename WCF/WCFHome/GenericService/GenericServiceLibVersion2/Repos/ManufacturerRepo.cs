using GenericServiceLib.Models;

namespace GenericServiceLib.Repos
{
    public class ManufacturerRepo : GenericRepo<Manufacturer>, IManufacturerRepo
    {
        public ManufacturerRepo()
        {
            Table = Context.Manufacturers;
        }
    }
}
