using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiggyBankChallenge
{
    class PiggyBank
    {
        private readonly int _goal;
        private int _currBalance;
        public string Name { get; }

        public PiggyBank(int goal, string name)
        {
            Name = name;
            _goal = goal;
        }

        public event EventHandler<BalanceUpdEventArgs> balanceUpdate;
        public event EventHandler<GoalReachedEventArgs> goalReached;

        public int CurrrentBalance
        {
            get { return _currBalance; }
            set
            {
                _currBalance += value;
                balanceUpdate?.Invoke(this, new BalanceUpdEventArgs(_currBalance));

                if (_currBalance >= _goal)
                    goalReached?.Invoke(this,
                        new GoalReachedEventArgs($"Congratulations! You have reached your goal of ${_goal}!"));
            }
        }

    }
}
