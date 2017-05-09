using System;

namespace _004_Interfaces.Activities
{
    public class SendNotification : IActivity
    {
        public void Execute() => Console.WriteLine("Sending email to the owner of the video...");
    }
}