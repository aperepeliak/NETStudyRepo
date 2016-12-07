using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_Features
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (x, y) => x + y;
            Action<int> write = x => Console.WriteLine(x);
            write(square(add(3, 5)));

            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee {Id = 1, Name = "Scott" },
                new Employee {Id = 2, Name = "Chris" }
            };

            IEnumerable<Employee> sales = new List<Employee>
            {
                new Employee { Id = 3, Name = "Alex" }
            };

            // foreach - the hard way
            //IEnumerator<Employee> enumerator = sales.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current.Name);
            //}

            // Method syntax
            var query = developers
                .Where(e => e.Name.Length == 5)
                .OrderBy(e => e.Name);

            foreach (var employee in query)
            {
                Console.WriteLine(employee.Name);
            }

            // Query syntax
            var query2 = from e in developers
                         where e.Name.Length == 5
                         orderby e.Name descending
                         select e;

            foreach (var employee in query2)
                Console.WriteLine(employee.Name);


        }
    }
}
