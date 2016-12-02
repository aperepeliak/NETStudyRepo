﻿using System;
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
            ThreadAPI model = new ThreadAPI(2);

            view.onStopThread += () =>
            {
                model.onReadyToStop += () => true;
            };

            //view.Load +=

            Application.Run(view);
        }
    }
}
