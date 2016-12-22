using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_StringReaderWriterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StringWriter strWriter = new StringWriter())
            {
                strWriter.WriteLine("Walk the dog");
                Console.WriteLine($"Contents of StringWriter: \n{strWriter}");

                // Read data from the StringWriter
                using (StringReader strReader = new StringReader(strWriter.ToString()))
                {
                    string input = null;
                    while ((input = strReader.ReadLine()) != null)
                    {
                        Console.WriteLine(input);
                    }
                }
            }
        }
    }
}
