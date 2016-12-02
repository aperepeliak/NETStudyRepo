using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002___InterfaceExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Extending interface compatible types\n\n");

            // System.Array implements IEnumerable
            string[] data = { "If", "you", "happy", "and", "you", "know",
                "and", "you", "really", "wanna", "show", "it", "say", "hello" };

            data.PrintDataAndBeep();
            Console.WriteLine();

        }
    }
}
