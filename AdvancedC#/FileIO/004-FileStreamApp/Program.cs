using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_FileStreamApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var fStream = File.Open(@"D:\myMessage.dat", FileMode.Create))
            {
                var msg = "Hello!";
                byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);

                // Write byte[] to file
                fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);

                // Reset internal position of stream
                fStream.Position = 0;

                Console.Write("Your message as an array of bytes: ");
                byte[] bytesFromFile = new byte[msgAsByteArray.Length];
                for (int i = 0; i < msgAsByteArray.Length; i++)
                {
                    bytesFromFile[i] = (byte)fStream.ReadByte();
                    Console.Write(bytesFromFile[i]);
                }

                // Display decoded message
                Console.WriteLine("\nDecoded message: ");
                Console.WriteLine((Encoding.Default.GetString(bytesFromFile)));
            }
        }
    }
}
