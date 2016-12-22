using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_DirectoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Learning Directory Info *****\n\n");

            ShowWindowsDirectoryInfo();
            DisplayImageFiles();
            ListDrives();
        }

        private static void ListDrives()
        {
            var drives = Directory.GetLogicalDrives();
            Console.WriteLine("Here are your drives: ");

            foreach (var s in drives)
                Console.WriteLine($" --> {s}");
        }

        private static void DisplayImageFiles()
        {
            var dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");
            var imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);

            Console.WriteLine($"Found {imageFiles.Length} *.jpg files\n");

            foreach (var file in imageFiles)
            {
                Console.WriteLine(new string('=', 30));

                Console.WriteLine($"{"File name",-12} : {file.Name}");
                Console.WriteLine($"{"File size",-12} : {file.Length}");
                Console.WriteLine($"{"Creation",-12} : {file.CreationTime}");
                Console.WriteLine($"{"Attributes",-12} : {file.Attributes}");

                Console.WriteLine(new string('=', 30));
            }
        }

        private static void ShowWindowsDirectoryInfo()
        {
            var dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("\n==== Directory info ====");
            Console.WriteLine($"{"Full name",-12}: {dir.FullName}");
            Console.WriteLine($"{"Name",-12}: {dir.Name}");
            Console.WriteLine($"{"Parent",-12}: {dir.Parent}");
            Console.WriteLine($"{"Creation",-12}: {dir.CreationTime}");
            Console.WriteLine($"{"Attributes",-12}: {dir.Attributes}");
            Console.WriteLine($"{"Root",-12}: {dir.Root}");
            Console.WriteLine("===========================");
        }
    }
}
