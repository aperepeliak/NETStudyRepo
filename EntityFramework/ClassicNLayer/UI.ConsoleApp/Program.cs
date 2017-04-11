using BusinessLayer.Infrastructure;
using BusinessLayer.Interfaces;
using Ninject;
using Ninject.Modules;
using System;
using System.Reflection;

namespace UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var modules = new INinjectModule[] { new ServiceModule() };
            var kernel = new StandardKernel(modules);
            kernel.Load(Assembly.GetExecutingAssembly());
            IProductService productService = kernel.Get<IProductService>();

            WorkingData(productService);
        }

        private static void WorkingData(IProductService productService)
        {
            //var productsByCategory = productService.GetProductsByCategory(1);
            var productsBySupplier = productService.GetProductsBySupplier(2);
            //var ProductsWithPrice = productService.GetProductsBy(p => p.Price < 200);

            foreach (var p in productsBySupplier)
            {
                Console.WriteLine(p.Name + " \t| " + p.Price);
            }
        }
    }
}
