using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_StreamWriterReaderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = File.CreateText("reminders.txt"))
            {
                writer.WriteLine("Sharpen the knife");
                writer.WriteLine("Walk the dog");
                writer.WriteLine("Don't forget these numbers:");

                for (int i = 0; i < 10; i++)
                    writer.Write(i + " ");

                writer.Write(writer.NewLine);
            }

            Console.WriteLine("File created...");

            // Now read data

            Console.WriteLine("Here are your thoughts: \n");
            using (var reader = File.OpenText("reminders.txt"))
            {
                string input = null;
                while ((input = reader.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
            }
        }
    }
}
