using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaphoreMVC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainView view = new MainView();
            ThreadAPI model = new ThreadAPI();

            // Subscribing for view events
            view.onFormLoad += (num) => model.SetPool(num);
            view.onCreateThread += (counter) => model.CreateThread(counter);
            view.onLaunchThread += () => model.LaunchThread();

            view.onStopThread += (threadNum) =>
            {
                model.onReadyToStop += () => true;
                model.onStopThreadNum += () => threadNum;
            };

            // Subscribing for model events
            model.onTimerUpdate += (threadNum, timerCounter) => view.UpdateState(threadNum, timerCounter);

            Application.Run(view);
        }
    }
}
