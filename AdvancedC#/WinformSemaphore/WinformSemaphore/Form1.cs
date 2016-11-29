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
        private static int remover;
        public static Semaphore Pool { get; set; }
        public List<Thread> threads;

        private int initialCounter = 0;

        bool stopTimer = false;

        public event Action actionEvent;
        public event Action stopCountdown;

        public Form1()
        {
            InitializeComponent();
            counter = 0;
            remover = 0;
            Pool = new Semaphore(0, (int)numThreads.Value);
            threads = new List<Thread>();

            actionEvent += Form1_actionEvent;
            stopCountdown += Form1_stopCountdown;
        }

        private void Form1_stopCountdown()
        {
            stopTimer = true;
        }

        private void Form1_actionEvent()
        {
            lbxWorking.Items.RemoveAt(0);
            
            stopCountdown.Invoke();
            threads[remover].Abort();
        }

        public void InvokeEvent()
        {
            actionEvent.Invoke();
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
            
            t.Enabled = true;

            Stopwatch s = new Stopwatch();
            s.Start();
            
            t.Elapsed += delegate
            {
                this.Invoke((MethodInvoker)delegate {
                    txtTest.Text = (s.ElapsedMilliseconds / 1000).ToString(); // runs on UI thread
                });
                if (stopTimer)
                {
                    t.Stop();
                    t.Enabled = false;
                    t.Dispose();
                    stopTimer = false;
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtTest.Text = "";
                    });             
                }
            };

            Pool.Release(1);
        }

        private void lbxCreated_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string threadNum = lbxCreated.SelectedItem.ToString().Substring(6, 1);

            var selected = threads.Where(t => t.Name.StartsWith(threadNum)).FirstOrDefault();

            selected.Start(threadNum);

            if (initialCounter < (int)numThreads.Value)
            {
                Pool.Release(1);
            }

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
