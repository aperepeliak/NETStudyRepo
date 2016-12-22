using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_SimpleFileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] myTasks =
            {
                "Learn ASP.NET MVC",
                "Learn WCF",
                "Learn JS",
                "Study C#"
            };

            File.WriteAllLines(@"D:\tasks.txt", myTasks);

            foreach (var task in File.ReadAllLines(@"D:\tasks.txt"))
            {
                Console.WriteLine($"TODO: {task}");
            }
        }
    }
}
