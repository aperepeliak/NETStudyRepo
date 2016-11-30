using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiggyBankChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            PiggyBank iPhone = new PiggyBank(800, "iPhone");
            bool areWeThereYet = false;

            iPhone.balanceUpdate += (sender, e) =>
            {
                Console.WriteLine($"Balance for {iPhone.Name} : ${e.NewBalance}");
            };

            iPhone.goalReached += (sender, e) => {
                Console.WriteLine(e.Msg);
                areWeThereYet = true;
            };

            do
            {
                Console.Write("How much money you wanna to put -> ");
                string toSubmitStr = Console.ReadLine();
                int toSubmit = int.Parse(toSubmitStr);

                iPhone.CurrrentBalance = toSubmit;

            } while (!areWeThereYet);
        }
    }
}
