using DomainLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;
using System.Data;
using System.Data.SqlClient;

namespace Data.AdoNet.Repos
{
    public class ProductRepo : IProductRepo
    {
        DataTable _table;

        public ProductRepo(DataTable table)
        {
            _table = table;
        }

        public void Add(Product entity)
        {
            var newRow = _table.NewRow();

            newRow["Name"] = entity.Name;
            newRow["CategoryId"] = entity.CategoryId;
            newRow["SupplierId"] = entity.SupplierId;

            _table.Rows.Add(newRow);
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();

            for (int curRow = 0; curRow < _table.Rows.Count; curRow++)
            {
                products.Add(new Product
                {
                    Id = (int)_table.Rows[curRow]["Id"],
                    Name = (string)_table.Rows[curRow]["Name"],
                    CategoryId  = (int)_table.Rows[curRow]["CategoryId"],
                    SupplierId  = (int)_table.Rows[curRow]["SupplierId"]
                });
            }

            return products;
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
