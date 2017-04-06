using DomainLayer;
using DomainLayer.Models;
using Ninject;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System;

namespace UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkWithEF();

            //WorkWithAdoNet();

        }

        private static void WorkWithAdoNet()
        {
            DataSet _db = new DataSet("ProductsDb");

            string sql = "SELECT * from Categories;SELECT * from Products;SELECT * from Suppliers;";
            string connectionString =
                ConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString;

            SqlDataAdapter _adapter = new SqlDataAdapter(sql, connectionString);

            _adapter.Fill(_db);

            _db.Tables[0].TableName = "Categories";

            Console.WriteLine(_db.Tables[0].TableName);

            Console.WriteLine(_db.Tables[0].Rows[0][1]);
            Console.WriteLine(_db.Tables[0].Rows[1][1]);
            Console.WriteLine(_db.Tables[0].Rows[2][1]);
        }

        private static void WorkWithEF()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            IUnitOfWork unitOfWork = kernel.Get<IUnitOfWork>();

            // unitOfWork.Categories.Add(new Category { Name = "Laptop" });
            // unitOfWork.Complete();

            var cats = unitOfWork.Categories.GetAll();
            foreach (var c in cats)
            {
                Console.WriteLine(c.Name);
            }
        }
    }
}
