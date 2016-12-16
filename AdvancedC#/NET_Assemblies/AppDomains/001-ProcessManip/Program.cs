using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace _001_ProcessManip
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Learning Processes ****\n");

            ListAllRunningProcesses();
            GetSpecificProcess();
            EnumThreadsForPID();

            Console.ReadKey();
        }

        static void ListAllRunningProcesses()
        {
            // Get all running processes on the local machine, ordered by PID
            var runningProc = Process.GetProcesses(".")
                .OrderBy(proc => proc.Id);

            foreach (var proc in runningProc)
            {
                Console.WriteLine($" -> PID: {proc.Id} \tName: {proc.ProcessName}");
            }
            Console.WriteLine(new string('=', 30));
        }

        static void GetSpecificProcess()
        {
            Process theProc;
            try
            {
                Console.Write("Enter PID -> ");
                int id = int.Parse(Console.ReadLine());
                theProc = Process.GetProcessById(id);
                Console.WriteLine($"Info: {theProc.ProcessName}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(new string('=', 30));
        }

        static void EnumThreadsForPID()
        {
            Process theProc;
            try
            {
                Console.Write("Enter PID -> ");
                int id = int.Parse(Console.ReadLine());
                theProc = Process.GetProcessById(id);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            // List out stats for each thread in the specified process
            Console.WriteLine($"Here are the threads used by {theProc.ProcessName} :");

            ProcessThreadCollection threads = theProc.Threads;

            foreach (ProcessThread t in threads)
            {
                Console.WriteLine($" -> Thread ID: {t.Id}\tStart Time: {t.StartTime.ToShortTimeString()}\tPriority: {t.PriorityLevel}");
            }
            Console.WriteLine(new string('=', 30));
        }
    }
}
