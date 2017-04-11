using Data.AdoNet.Interfaces;
using Data.AdoNet.Models;
using System.Collections.Generic;
using System.Data;

namespace Data.AdoNet.Repos
{
    public class ProductRepo : IRepo<Product>
    {
        ProductContext _context;
        DataTable _table;

        public ProductRepo(ProductContext context)
        {
            _context = context;
            _table = _context.Products;
        }

        public void Create(Product entity)
        {
            DataRow newRow = _table.NewRow();

            newRow["Name"]       = entity.Name;
            newRow["Price"]      = entity.Price;
            newRow["CategoryId"] = entity.CategoryId;
            newRow["SupplierId"] = entity.SupplierId;

            _table.Rows.Add(newRow);
        }
        public void Delete(Product entity)
        {
            int id = entity.Id;
            var product = Get(id);

            if (product != null)
            {
                DataRow rowToDelete = _table.Select($"Id = {id}")[0];
                rowToDelete.Delete();
                return;
            }
        }
        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();

            for (int curRow = 0; curRow < _table.Rows.Count; curRow++)
            {
                products.Add(new Product
                {
                    Id         = (int)     _table.Rows[curRow]["Id"],
                    Name       = (string)  _table.Rows[curRow]["Name"],
                    CategoryId = (int)     _table.Rows[curRow]["CategoryId"],
                    SupplierId = (int)     _table.Rows[curRow]["SupplierId"],
                    Price      = (decimal) _table.Rows[curRow]["Price"],

                    Category = new Category
                    {
                        Id   = (int)_context.GetParentRowFor
                                (_table.Rows[curRow], "CategoryProduct")["Id"],

                        Name = (string)_context.GetParentRowFor
                                (_table.Rows[curRow], "CategoryProduct")["Name"]
                    },

                    Supplier = new Supplier
                    {
                        Id       = (int)_context.GetParentRowFor
                                   (_table.Rows[curRow], "SupplierProduct")["Id"],

                        Name     = (string)_context.GetParentRowFor
                                   (_table.Rows[curRow], "SupplierProduct")["Name"],

                        Location = (string)_context.GetParentRowFor
                                   (_table.Rows[curRow], "SupplierProduct")["Location"]
                    }
                });
            }

            return products;
        }
        public Product Get(int id)
        {
            DataRow[] query = _table.Select($"Id = {id}");

            if (query.Length == 0) return null;

            DataRow row = query[0];

            return new Product
            {
                Id         = (int)     row["Id"],
                Name       = (string)  row["Name"],
                CategoryId = (int)     row["CategoryId"],
                SupplierId = (int)     row["SupplierId"],
                Price      = (decimal) row["Price"],

                Category = new Category
                {
                    Id = (int)_context.GetParentRowFor
                                (row, "CategoryProduct")["Id"],
                    Name = (string)_context.GetParentRowFor
                                (row, "CategoryProduct")["Name"]
                },

                Supplier = new Supplier
                {
                    Id       = (int)_context.GetParentRowFor
                                   (row, "SupplierProduct")["Id"],
                    Name     = (string)_context.GetParentRowFor
                                   (row, "SupplierProduct")["Name"],
                    Location = (string)_context.GetParentRowFor
                                   (row, "SupplierProduct")["Location"]
                }
            };
        }
    }
}
