using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaphoreRefactor
{
    public partial class MainView : Form
    {
        ThreadAPI threadAPI;
        static int counter = 0;

        public MainView()
        {
            InitializeComponent();

            threadAPI = new ThreadAPI((int)numThreads.Value);

            threadAPI.onTimerUpdate += (secondsPassed) =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    txtTest.Text = secondsPassed.ToString();
                });


            }; 
        }

        private void btnCreateThread_Click(object sender, EventArgs e)
        {
            threadAPI.createThread(counter);
            lbxCreated.Items.Add($"Поток {counter} --> создан");
            counter++;
        }

        private void lbxCreated_DoubleClick(object sender, EventArgs e)
        {
            if (lbxCreated.Items.Count != 0)
            {
                threadAPI.LaunchThread();
                lbxCreated.Items.RemoveAt(0);
            }
        }
    }
}
