using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Repos;
using System.Data.Common;
using System.Data;
using Data.AdoNet.Repos;

namespace Data.AdoNet
{
    public class UnitOfWork : IUnitOfWork
    {
        DataAdapter _adapter;
        DataSet _db;

        public IProductRepo Products { get; private set; }
        public ICategoryRepo Categories { get; private set; }
        public ISupplierRepo Suppliers { get; private set; }

        public UnitOfWork()
        {
            _adapter.Fill(_db);
            Products = new ProductRepo("connstr");
        }

        public void Complete()
        {
            _adapter.Update(_db);
        }
    }
}
