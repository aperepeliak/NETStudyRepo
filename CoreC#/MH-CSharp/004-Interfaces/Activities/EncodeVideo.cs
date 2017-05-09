using System;

namespace _004_Interfaces.Activities
{
    public class EncodeVideo : IActivity
    {
        public void Execute() => Console.WriteLine("Encoding video...");
    }
}