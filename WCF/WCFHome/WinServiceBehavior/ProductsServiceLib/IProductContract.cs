using System.Collections.Generic;
using System.ServiceModel;

namespace ProductsServiceLib
{
    [ServiceContract]
    interface IProductContract
    {
        [OperationContract]
        IEnumerable<Product> GetAll();
        [OperationContract]
        Product Get(int id);
        [OperationContract]
        void Remove(int id);
        [OperationContract]
        string GetServiceHash();
    }
}
