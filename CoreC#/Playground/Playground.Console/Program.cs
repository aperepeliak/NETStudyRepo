using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var dict = new Dictionary<string, int>
            {
                {"one", 1 },
                {"two", 2 }
            };

            CheckAddMethod(dict.Values);
        }

        private static void CheckAddMethod(ICollection<int> coll)
        {
            coll.Add(100);

            foreach (var item in coll)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
