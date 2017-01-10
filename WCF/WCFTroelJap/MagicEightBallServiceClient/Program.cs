using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MagicEightBallServiceClient.ServiceReference;

namespace MagicEightBallServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Ask the Magic Ball *****\n");

            using (var magicBall = new EightBallClient())
            {
                Console.Write("Your question -> ");
                var question = Console.ReadLine();
                var answer = magicBall.ObtainAnswerToQuestion(question);

                Console.WriteLine($"The ball says: {answer}");
            }
            Console.ReadLine();
        }
    }
}
