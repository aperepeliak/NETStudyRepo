using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SemaphoreRefactor
{
    public class ThreadAPI
    {
        private Queue<Thread> threads;
        private Semaphore Pool;

        public ThreadAPI(int semaphoreNumThreads)
        {
            threads = new Queue<Thread>();
            Pool = new Semaphore(semaphoreNumThreads, semaphoreNumThreads);
        }

        public void createThread(int counter)
        {
            threads.Enqueue(new Thread(ThreadMain) { Name = counter.ToString() });
        }

        private void ThreadMain (object args)
        {
            Pool.WaitOne();



        }

         public void LaunchThread()
        {
            Thread toLaunch = threads.Dequeue();
            toLaunch.Start();
        }

    }
}
