using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Handling multiple exceptions *****\n");

            Car myCar = new Car("Lollipop", 90);

            try
            {
                // Trip Arg out of  range exception.
                myCar.Accelerate(-10);
            }
            catch (CarIsDeadException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
