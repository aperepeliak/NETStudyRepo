using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****Custom Exception example****\n\n");

            Car myCar = new Car("Daisy", 90);

            try
            {
                // Trip exception
                myCar.Accelerate(50);
            } catch (CarIsDeadException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ErrorTimeStamp);
                Console.WriteLine(e.CauseOfError);
            }
        }
    }
}
