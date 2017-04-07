using DomainLayer.Repos;
using System.Collections.Generic;
using DomainLayer.Models;
using System.Data;

namespace Data.AdoNet.Repos
{
    public class ProductRepo : IProductRepo
    {
        ProductContext _context;
        DataTable _table;

        public ProductRepo(ProductContext context)
        {
            _context = context;
            _table = _context.Products;
        }

        public void Add(Product entity)
        {
            DataRow newRow = _table.NewRow();

            newRow["Name"] = entity.Name;
            newRow["CategoryId"] = entity.CategoryId;
            newRow["SupplierId"] = entity.SupplierId;

            _table.Rows.Add(newRow);
        }
        public void Delete(Product entity)
        {
            int id = entity.Id;
            DataRow rowToDelete = _table.Select($"Id={id}")[0];
            rowToDelete.Delete();
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
                    CategoryId = (int)_table.Rows[curRow]["CategoryId"],
                    SupplierId = (int)_table.Rows[curRow]["SupplierId"],

                    Category = new Category
                    {
                        Id = (int)_context.GetParentRowFor
                                (_table.Rows[curRow], "CategoryProduct")["Id"],

                        Name = (string)_context.GetParentRowFor
                                (_table.Rows[curRow], "CategoryProduct")["Name"]
                    },

                    Supplier = new Supplier
                    {
                        Id = (int)_context.GetParentRowFor
                                (_table.Rows[curRow], "SupplierProduct")["Id"],

                        Name = (string)_context.GetParentRowFor
                                (_table.Rows[curRow], "SupplierProduct")["Name"]
                    }
                });
            }

            return products;
        }
        public Product GetById(int id)
        {
            DataRow[] query = _table.Select($"Id = {id}");

            if (query.Length == 0) return null;

            DataRow row = query[0];

            return new Product
            {
                Id         = (int)   row["Id"],
                Name       = (string)row["Name"],
                CategoryId = (int)   row["CategoryId"],
                SupplierId = (int)   row["SupplierId"],

                Category = new Category
                {
                    Id   = (int)_context.GetParentRowFor
                                (row, "CategoryProduct")["Id"],
                    Name = (string)_context.GetParentRowFor
                                (row, "CategoryProduct")["Name"]
                },

                Supplier = new Supplier
                {
                    Id   = (int)_context.GetParentRowFor
                                (row, "SupplierProduct")["Id"],
                    Name = (string)_context.GetParentRowFor
                                (row, "SupplierProduct")["Name"]
                }
            };
        }
    }
}
