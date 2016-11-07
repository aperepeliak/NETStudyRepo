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

namespace WinformSemaphore
{
    public partial class Form1 : Form
    {
        private static int counter;
        public static Semaphore Pool { get; set; }
        public List<Thread> threads;

        public Form1()
        {
            InitializeComponent();
            counter = 0;
            Pool = new Semaphore((int)numThreads.Value, (int)numThreads.Value);
            threads = new List<Thread>();
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
            //Pool.WaitOne();
            //MessageBox.Show("Test");
        }

        private void lbxCreated_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string threadNum = lbxCreated.SelectedItem.ToString().Substring(6, 1);

            var selected = threads.Where(t => t.Name.StartsWith(threadNum)).FirstOrDefault();

            selected.Start();
            Pool.WaitOne();

            if (selected.ThreadState == ThreadState.Running)
            {
                lbxWorking.Items.Add($"Поток {selected.Name} --> работает");
            }
            else
            {
                lbxWaiting.Items.Add($"Поток {selected.Name} --> ожидает");
            }
            MessageBox.Show(selected.ThreadState.ToString());
            lbxCreated.Items.Remove($"Поток {selected.Name} --> создан");
        }

        private void lbxWorking_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string threadNum = lbxCreated.SelectedItem.ToString().Substring(6, 1);
            var selected = threads.Where(t => t.Name.StartsWith(threadNum)).FirstOrDefault();
            selected.Abort();
        }
    }
}
