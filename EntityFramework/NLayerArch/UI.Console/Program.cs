using DomainLayer;
using DomainLayer.Models;
using Ninject;
using System.Reflection;

namespace UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var unit = kernel.Get<IUnitOfWork>();

            unit.Categories.Add(new Category { Name = "Printer" });
            unit.Complete();
        }
    }
}
