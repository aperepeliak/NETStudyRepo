using Ninject.Modules;
using OnlineStore.DAL.Entities;
using OnlineStore.Repo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DITestConsole
{
    public class MyModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<DbContext>().To<ShopContext>().InRequestScope();
            Bind(typeof(IGenericRepo<>)).To(typeof(GenericRepo<>)).InSingletonScope();
        }
    }
}
