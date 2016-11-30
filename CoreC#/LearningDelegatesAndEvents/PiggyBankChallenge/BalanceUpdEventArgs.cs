using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiggyBankChallenge
{
    public class BalanceUpdEventArgs : EventArgs
    {
        public int NewBalance { get; set; }

        public BalanceUpdEventArgs(int currBalance)
        {
            NewBalance = currBalance;
        }
    }
}
