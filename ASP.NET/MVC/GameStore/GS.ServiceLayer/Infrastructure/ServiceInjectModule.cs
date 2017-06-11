using GS.DAL.UoW;
using GS.Domain.UoW;
using Ninject.Extensions.Conventions;

namespace GS.ServiceLayer.Infrastructure
{
    public class ServiceInjectModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            //Kernel.Bind(x => x.FromAssembliesMatching("GS.DAL.dll")
            //                  .SelectAllClasses()
            //                  .BindAllInterfaces());

            Kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
