using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SemaphoreMVC
{
    public class ThreadAPI
    {
        private Queue<Thread> threads;
        private Semaphore Pool;

        public event Action<int, int> onTimerUpdate;
        public event Func<bool> onReadyToStop;
        public event Func<int> onStopThreadNum;

        public ThreadAPI()
        {
            threads = new Queue<Thread>();
        }

        public void SetPool(int semaphoreNumThreads)
        {
            int test = semaphoreNumThreads;
            Pool = new Semaphore(semaphoreNumThreads, semaphoreNumThreads);
        }

        public void CreateThread(int counter)
        {
            threads.Enqueue(new Thread(ThreadMain) { Name = counter.ToString() });
        }

        private void ThreadMain(object args)
        {
            Pool.WaitOne();

            System.Timers.Timer t = new System.Timers.Timer(1000);
            t.Enabled = true;
            int timerCounter = 1;

            t.Elapsed += (sender, e) =>
            {
                onTimerUpdate?.Invoke((int)args, timerCounter++);

                if (onReadyToStop?.Invoke() == true &&
                    onStopThreadNum?.Invoke() == (int)args)
                {
                    t.Stop();
                    Pool.Release(1);
                }
            };
        }

        public void LaunchThread()
        {
            Thread toLaunch = threads.Dequeue();
            int threadNumber = int.Parse(toLaunch.Name);
            toLaunch.Start(threadNumber);
        }
    }
}
