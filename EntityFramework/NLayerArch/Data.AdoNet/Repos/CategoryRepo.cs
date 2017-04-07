using DomainLayer.Repos;
using System.Collections.Generic;
using DomainLayer.Models;
using System.Data;

namespace Data.AdoNet.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        ProductContext _context;
        DataTable _table;

        public CategoryRepo(ProductContext context)
        {
            _context = context;
            _table = _context.Categories;
        }

        public void Add(Category entity)
        {
            DataRow newRow = _table.NewRow();
            newRow["Name"] = entity.Name;
            _table.Rows.Add(newRow);
        }
        public void Delete(Category entity)
        {
            int id = entity.Id;
            DataRow rowToDelete = _table.Select($"Id={id}")[0];
            rowToDelete.Delete();
        }
        public IEnumerable<Category> GetAll()
        {
            var categories = new List<Category>();

            for (int curRow = 0; curRow < _table.Rows.Count; curRow++)
            {
                var category = new Category
                {
                    Id       = (int)_table.Rows[curRow]["Id"],
                    Name     = (string)_table.Rows[curRow]["Name"],
                    Products = new List<Product>()
                };

                var productRows = _context.GetChildRowsFor
                                  (_table.Rows[curRow], "CategoryProduct");

                for (int i = 0; i < productRows.Length; i++)
                {
                    category.Products.Add(new Product
                    {
                        Id         = (int)    productRows[i]["Id"],
                        Name       = (string) productRows[i]["Name"],
                        CategoryId = (int)    productRows[i]["CategoryId"],
                        SupplierId = (int)    productRows[i]["SupplierId"]
                    });
                }          

                categories.Add(category);
            }

            return categories;
        }
        public Category GetById(int id)
        {
            DataRow row = _table.Select($"Id = {id}")[0];

            var category = new Category
            {
                Id       = (int)   row["Id"],
                Name     = (string)row["Name"],
                Products = new List<Product>()
            };

            var productRows = _context.GetChildRowsFor
                                  (row, "CategoryProduct");

            for (int i = 0; i < productRows.Length; i++)
            {
                category.Products.Add(new Product
                {
                    Id         = (int)   productRows[i]["Id"],
                    Name       = (string)productRows[i]["Name"],
                    CategoryId = (int)   productRows[i]["CategoryId"],
                    SupplierId = (int)   productRows[i]["SupplierId"]
                });
            }

            return category;
        }
    }
}
