using GenericServiceLib.Models;
using System.ServiceModel;

namespace GenericServiceLib.Repos
{
    [ServiceContract]
    interface IManufacturerRepo : IGenericRepository<Manufacturer> { }
}
