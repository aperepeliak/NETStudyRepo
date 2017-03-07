using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA_GenericReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeList = CreateCollection(typeof(List<>), typeof(Employee));
            Console.Write(employeeList.GetType().Name);

            var genericArguments = employeeList.GetType().GenericTypeArguments;
            foreach (var arg in genericArguments)
            {
                Console.Write($"[{arg.Name}]");
            }
            Console.WriteLine();

            var employee = new Employee();
            var employeeType = typeof(Employee);
            var methodInfo = employeeType.GetMethod("Speak");
            methodInfo = methodInfo.MakeGenericMethod(typeof(DateTime));

            methodInfo.Invoke(employee, null);
        }

        private static object CreateCollection(Type collectionType, Type itemType)
        {
            var closedType = collectionType.MakeGenericType(itemType);
            return Activator.CreateInstance(closedType);
        }
    }
}
