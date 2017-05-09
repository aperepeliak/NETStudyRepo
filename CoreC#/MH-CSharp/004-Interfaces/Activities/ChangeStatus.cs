using System;

namespace _004_Interfaces.Activities
{
    public class ChangeStatus : IActivity
    {
        public void Execute() => Console.WriteLine("Changing the status of video to processing...");
    }
}