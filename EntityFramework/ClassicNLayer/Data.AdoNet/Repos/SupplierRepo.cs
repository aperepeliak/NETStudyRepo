using Data.AdoNet.Interfaces;
using Data.AdoNet.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.AdoNet.Repos
{
    public class SupplierRepo : IRepo<Supplier>
    {
        ProductContext _context;
        DataTable _table;

        public SupplierRepo(ProductContext context)
        {
            _context = context;
            _table = _context.Suppliers;
        }

        public void Create(Supplier entity)
        {
            DataRow newRow = _table.NewRow();
            newRow["Name"] = entity.Name;
            newRow["Location"] = entity.Location;
            _table.Rows.Add(newRow);
        }
        public void Delete(Supplier entity)
        {
            int id = entity.Id;
            var supplier = Get(id);

            if (supplier != null)
            {
                DataRow rowToDelete = _table.Select($"Id = {id}")[0];
                rowToDelete.Delete();
                return;
            }
        }
        public IEnumerable<Supplier> GetAll()
        {
            var suppliers = new List<Supplier>();

            for (int curRow = 0; curRow < _table.Rows.Count; curRow++)
            {
                var supplier = new Supplier
                {
                    Id       = (int)    _table.Rows[curRow]["Id"],
                    Name     = (string) _table.Rows[curRow]["Name"],
                    Location = (string) _table.Rows[curRow]["Location"],
                    Products = new List<Product>()
                };

                var productRows = _context.GetChildRowsFor
                                  (_table.Rows[curRow], "SupplierProduct");

                for (int i = 0; i < productRows.Length; i++)
                {
                    supplier.Products.Add(new Product
                    {
                        Id         = (int)     productRows[i]["Id"],
                        Name       = (string)  productRows[i]["Name"],
                        CategoryId = (int)     productRows[i]["CategoryId"],
                        SupplierId = (int)     productRows[i]["SupplierId"],
                        Price      = (decimal) productRows[i]["Price"]
                    });
                }

                suppliers.Add(supplier);
            }

            return suppliers;
        }
        public Supplier Get(int id)
        {
            DataRow[] query = _table.Select($"Id = {id}");

            if (query.Length == 0) return null;

            DataRow row = query[0];
            var supplier = new Supplier
            {
                Id = (int)row["Id"],
                Name = (string)row["Name"],
                Location = (string)row["Location"],
                Products = new List<Product>()
            };

            var productRows = _context.GetChildRowsFor
                                  (row, "SupplierProduct");

            for (int i = 0; i < productRows.Length; i++)
            {
                supplier.Products.Add(new Product
                {
                    Id         = (int)     productRows[i]["Id"],
                    Name       = (string)  productRows[i]["Name"],
                    CategoryId = (int)     productRows[i]["CategoryId"],
                    SupplierId = (int)     productRows[i]["SupplierId"],
                    Price      = (decimal) productRows[i]["Price"]
                });
            }

            return supplier;
        }
    }
}
