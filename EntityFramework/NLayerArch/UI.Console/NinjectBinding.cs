using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Conventions;

namespace UI.Console
{
    public class NinjectBinding : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x => x.FromAssembliesMatching("Data.*.dll")
                            .SelectAllClasses()
                            .BindAllInterfaces());
        }
    }
}
