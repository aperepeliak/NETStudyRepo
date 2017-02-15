using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInterfcs
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new[]
            {
                "John", "Jane"
            };

            var list1 = new List<string>(names);
            var list2 = new List<string>
            {
                "John", "Jane"
            };

            var list3 = new List<string>();
            list3.Add("Tim");
            list3.AddRange(names);

            

        }
    }
}
