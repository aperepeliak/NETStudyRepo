using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Conventions;

namespace UI.ConsoleApp
{
    public class NinjectBinding : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x => x.FromAssembliesMatching("Data.AdoNet.dll")
                            .SelectAllClasses()
                            .BindAllInterfaces());
        }
    }
}
