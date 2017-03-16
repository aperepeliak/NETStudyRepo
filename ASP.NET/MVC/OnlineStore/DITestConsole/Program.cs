using Ninject;
using OnlineStore.DAL.Entities;
using OnlineStore.Repo.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DITestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<DbContext>().To<ShopContext>();
            kernel.Bind(typeof(IGenericRepo<>)).To(typeof(GenericRepo<>));

            IGenericRepo<Good> goods = kernel.Get<IGenericRepo<Good>>();

            foreach (var item in goods.GetAll())
            {
                Console.WriteLine($"{item.GoodName}");
            }
        }
    }
}
