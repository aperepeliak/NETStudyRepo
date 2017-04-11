using Ninject.Extensions.Conventions;

namespace UI.ConsoleApp
{
    public class NinjectBinding : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x => x.FromAssembliesMatching("BusinessLayer.dll")
                            .SelectAllClasses()
                            .BindAllInterfaces());
        }
    }
}
