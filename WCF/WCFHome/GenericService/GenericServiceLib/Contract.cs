using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericServiceLib.Repos;

namespace GenericServiceLib
{
    public class Contract : IContract
    {
        public CategoryRepo GetCategories()
        {
            return new CategoryRepo();
        }

        public ManufacturerRepo GetManufacturers()
        {
            return new ManufacturerRepo();
        }
    }
}
