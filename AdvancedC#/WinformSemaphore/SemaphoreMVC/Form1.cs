using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaphoreMVC
{
    public partial class MainView : Form
    {

        static int threadsCounter = 0;
        private int launchedThreadsCounter = 0;

        BindingList<string> createdThreads;
        BindingList<string> waitingThreads;

        // All events sent by mainView
        public event Action<int> onFormLoad;
        public event Action<int> onCreateThread;
        public event Action onLaunchThread;
        public event Action onStopThread;

        public MainView()
        {
            InitializeComponent();

            createdThreads = new BindingList<string>();
            waitingThreads = new BindingList<string>();

            lbxCreated.DataSource = createdThreads;
            lbxWaiting.DataSource = waitingThreads;
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            onFormLoad?.Invoke((int)numThreads.Value);
        }

        private void btnCreateThread_Click(object sender, EventArgs e)
        {
            createdThreads.Add($"Поток {threadsCounter} --> создан");
            onCreateThread?.Invoke(threadsCounter);
            threadsCounter++;
        }

        private void lbxCreated_DoubleClick(object sender, EventArgs e)
        {
            if (createdThreads.Count != 0)
            {
                if (launchedThreadsCounter < (int)numThreads.Value)
                {
                    string changeStatus = createdThreads[0].Replace("создан", "0");
                    lbxWorking.Items.Add(changeStatus);
                    launchedThreadsCounter++;
                }
                else
                {
                    string changeStatus = createdThreads[0].Replace("создан", "ожидает");
                    waitingThreads.Add(changeStatus);
                }
                createdThreads.RemoveAt(0);
                onLaunchThread?.Invoke();
            }
        }

        private void lbxWorking_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            onStopThread?.Invoke();
        }

        public void UpdateState(int threadNum, int timerCounter)
        {
            for (int i = 0; i < lbxWorking.Items.Count; i++)
            {
                char[] working = lbxWorking.Items[i].ToString().Replace("Поток ", "").ToCharArray();
                List<char> buf = new List<char>();
                for (int j = 0; j < working.Length; j++)
                {
                    if (working[j] != ' ')
                        buf.Add(working[j]);
                    else
                        break;
                }
                int parsedThreadNum = int.Parse(string.Join("", buf));
                if (parsedThreadNum == threadNum)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        lbxWorking.Items[i] = "Поток " + parsedThreadNum + " --> " + timerCounter;
                    });
                    break;
                }
            }
        }
    }
}
