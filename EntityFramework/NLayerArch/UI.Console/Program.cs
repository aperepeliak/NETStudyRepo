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
            // WorkWithEF();

            WorkWithAdoNet();

        }

        private static void WorkWithAdoNet()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            IUnitOfWork unitOfWork = kernel.Get<IUnitOfWork>();

            #region AddItem
            //unitOfWork.Products.Add(new Product { Name = "iPhone", CategoryId = 2, SupplierId = 2 });
            //unitOfWork.Complete();
            #endregion

            #region IterateOverCollection
            //var products = unitOfWork.Products.GetAll();
            //foreach (var p in products)
            //{
            //    Console.WriteLine(p.Name);
            //}
            #endregion

            #region GetById
            var p = unitOfWork.Products.GetById(3);
            Console.WriteLine($"{p.Name} | {p.Category.Name} | {p.Supplier.Name}");
            #endregion

        }

        private static void WorkWithEF()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            IUnitOfWork unitOfWork = kernel.Get<IUnitOfWork>();

            // unitOfWork.Categories.Add(new Category { Name = "Laptop" });
            // unitOfWork.Complete();

            var categories = unitOfWork.Categories.GetAll();
            foreach (var c in categories)
            {
                Console.WriteLine(c.Name);
            }
        }
    }
}
