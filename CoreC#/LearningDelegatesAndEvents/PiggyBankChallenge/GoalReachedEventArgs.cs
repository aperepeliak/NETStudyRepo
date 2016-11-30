using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiggyBankChallenge
{
    class GoalReachedEventArgs
    {
        public string Msg { get; set; }
        public GoalReachedEventArgs(string msg)
        {
            this.Msg = msg;
        }
    }
}
