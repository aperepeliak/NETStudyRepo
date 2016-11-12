using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstData
{
    class MyMathClass
    {
        // Static implicitly
        public const double PI = 3.14;

        // We can assign in ctor but nowhere else
        public readonly double PI2;

        public static readonly double PI3;

        public MyMathClass()
        {
            PI2 = 3.14;
        }

        // Static ctor for static members
        static MyMathClass()
        {
            PI3 = 3.14;
        }
    }
}
