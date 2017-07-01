using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Singletone
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            var a = func();
            var b = func();

            return a.Equals(b);
        }
    }
}
