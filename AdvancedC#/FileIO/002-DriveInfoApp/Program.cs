using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_DriveInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var myDrives = DriveInfo.GetDrives();
            foreach (var drive in myDrives)
            {
                Console.WriteLine($"{"Name", -12} : {drive.Name}");
                Console.WriteLine($"{"Type", -12} : {drive.DriveType}");

                // Check to see whether the drive is mounted
                if (drive.IsReady)
                {
                    Console.WriteLine($"{"Free space", -12} : {drive.TotalFreeSpace / 1024 / 1024, 0:N0} MB");
                    Console.WriteLine($"{"Format",     -12} : {drive.DriveFormat}");
                    Console.WriteLine($"{"Label",      -12} : {drive.VolumeLabel}");
                }
                Console.WriteLine();
            }
        }
    }
}
