﻿using System;
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

        public event Action<int> onTimerUpdate;
        public event Func<bool> onReadyToStop;

        public ThreadAPI(int semaphoreNumThreads)
        {
            threads = new Queue<Thread>();
            Pool = new Semaphore(semaphoreNumThreads, semaphoreNumThreads);
        }

        public void createThread(int counter)
        {
            threads.Enqueue(new Thread(ThreadMain) { Name = counter.ToString() });
        }

        private void ThreadMain(object args)
        {
            Pool.WaitOne();

            //System.Windows.Forms.MessageBox.Show(Pool.Release().ToString());

            //System.Windows.Forms.MessageBox.Show(threads.().ThreadState.ToString());

            System.Timers.Timer t = new System.Timers.Timer(1000);
            t.Enabled = true;
            int counter = 0;

            t.Elapsed += (sender, e) =>
            {
                onTimerUpdate?.Invoke(counter++);

                if(onReadyToStop?.Invoke() == true)
                {
                    t.Stop();
                    Pool.Release(1);
                }
            };
        }

        public void LaunchThread()
        {
            Thread toLaunch = threads.Dequeue();
            toLaunch.Start();
        }
    }
}
