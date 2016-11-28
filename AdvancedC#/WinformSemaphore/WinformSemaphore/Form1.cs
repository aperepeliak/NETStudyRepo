using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WinformSemaphore
{
     public partial class Form1 : Form
    {
        private static int counter;
        public static Semaphore Pool { get; set; }
        public List<Thread> threads;

        public event Action actionEvent;
        public event EventHandler<TimerEventArgs> UpdateTime;

        public Form1()
        {
            InitializeComponent();
            counter = 0;
            Pool = new Semaphore((int)numThreads.Value, (int)numThreads.Value);
            threads = new List<Thread>();

            actionEvent += Form1_actionEvent;
            UpdateTime += Form1_UpdateTime;
        }

        private void Form1_actionEvent()
        {
            Pool.Release(1);
            lbxWorking.Items.RemoveAt(0);
        }

        public void InvokeEvent()
        {
            actionEvent.Invoke();
            //if (lbxWaiting.Items.Count > 0)
            //{
            //    string threadNum = lbxWaiting.SelectedItem.ToString().Substring(6, 1);
            //}
        }

        private void btnCreateThread_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(ThreadFunc) { Name = counter.ToString() };
            lbxCreated.Items.Add($"Поток {thread.Name} --> создан");
            threads.Add(thread);
            counter++;
        }

        private void ThreadFunc(object args)
        {
            Pool.WaitOne();

            // Timer
            System.Timers.Timer t = new System.Timers.Timer(1000);
            t.Elapsed += T_Elapsed;
            t.Enabled = true;

            Stopwatch s = new Stopwatch();
            s.Start();
                    
        }

        private void Form1_UpdateTime(object sender, TimerEventArgs e)
        {
            int index = Convert.ToInt32(e.threadNum);
            lbxWorking.Items[index] = "Test";
        }

        private void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateTime?.Invoke(this, new TimerEventArgs(s.ElapsedMilliseconds.ToString(), args.ToString()));
        }

        private void lbxCreated_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string threadNum = lbxCreated.SelectedItem.ToString().Substring(6, 1);

            var selected = threads.Where(t => t.Name.StartsWith(threadNum)).FirstOrDefault();

            selected.Start(threadNum);

            if (Pool.WaitOne(0))
            {
                lbxWorking.Items.Add($"Поток {selected.Name} --> работает");
            } else
            {
                lbxWaiting.Items.Add($"Поток {selected.Name} --> ожидает");
            }
            lbxCreated.Items.Remove($"Поток {selected.Name} --> создан");
        }

        private void lbxWorking_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbxWorking.SelectedItem != null)
            {
                InvokeEvent();
            }     
        }
    }
}
