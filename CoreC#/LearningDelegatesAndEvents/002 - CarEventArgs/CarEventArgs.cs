using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002___CarEventArgs
{
    public class CarEventArgs : EventArgs
    {
        public readonly string msg;
        public CarEventArgs(string msg)
        {
            this.msg = msg;
        }
    }
}
