using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadSync
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer p = new Printer();

            Thread[] threads = new Thread[10];

            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(p.PrintNumbers);
                threads[i].Name = string.Format($"Worker thread №{i}");
            }

            foreach (var t in threads)
            {
                t.Start();
            }
        }
    }
}
