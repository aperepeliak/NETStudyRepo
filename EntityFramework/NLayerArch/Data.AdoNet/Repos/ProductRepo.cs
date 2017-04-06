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
        DataTable table = new DataTable();

        public ProductRepo(string connectionString)
        {
            using (var linkToDB = new SqlConnection(connectionString))
            {
                SqlDataAdapter workAdapter = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand("SELECT * FROM Customer ORDER BY LastName", 
                    linkToDB)
                };
                workAdapter.Fill(table);
            }
        }

        public void Add(Product entity)
        {

            table.Rows.Add(new object[] { entity });
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
