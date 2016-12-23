using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_MyDirectoryWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();

            try
            {
                watcher.Path = @"D:\MyFolder";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            watcher.NotifyFilter = NotifyFilters.LastAccess
                | NotifyFilters.LastWrite
                | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;

            watcher.Filter = "*.txt";

            // When file is changed, created or deleted
            watcher.Changed += OnChange;
            watcher.Deleted += OnChange;
            watcher.Created += OnChange;

            watcher.Renamed +=
                (source, e) => Console.WriteLine($"File {e.OldFullPath} renamed to {e.FullPath}");

            // Begin watching the directory
            watcher.EnableRaisingEvents = true;

            // Wait for the user to quit the program
            Console.WriteLine(@"Press 'q' to quit the app");
            while (Console.Read() != 'q')
                ;
        }

        static void OnChange(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        }
    }
}
