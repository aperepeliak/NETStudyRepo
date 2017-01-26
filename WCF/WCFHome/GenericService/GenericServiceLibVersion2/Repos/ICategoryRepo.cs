using GenericServiceLib.Models;
using System.ServiceModel;

namespace GenericServiceLib.Repos
{
    [ServiceContract]
    interface ICategoryRepo : IGenericRepository<Category> { }
}
