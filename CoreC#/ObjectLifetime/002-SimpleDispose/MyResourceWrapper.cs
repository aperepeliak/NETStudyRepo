using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_SimpleDispose
{
    public class MyResourceWrapper : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("===== In Dispose! =====");
        }
    }
}
