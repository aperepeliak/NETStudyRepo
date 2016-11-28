using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformSemaphore
{
    public class TimerEventArgs : EventArgs
    {
        public readonly string msg;
        public readonly string threadNum;
        public TimerEventArgs(string msg, string threadNum)
        {
            this.msg = msg;
            this.threadNum = threadNum;
        }
    }
}
