using GenericServiceLib.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GenericServiceLib
{
    [ServiceContract]
    interface IContract
    {
        [OperationContract]
        CategoryRepo GetCategories();

        [OperationContract]
        ManufacturerRepo GetManufacturers(); 
    }
}
