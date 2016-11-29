using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006___LambdaExpMultipleParams
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleMath m = new SimpleMath();

            m.SetMathHandller((msg, result) => {
                Console.WriteLine($"Message: {msg}, Result: {result}");
            });

            m.Add(10, 10);
        }
    }
}
