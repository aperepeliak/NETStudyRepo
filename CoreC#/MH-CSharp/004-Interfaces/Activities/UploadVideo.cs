using System;

namespace _004_Interfaces.Activities
{
    public class UploadVideo : IActivity
    {
        public void Execute() => Console.WriteLine("Uploading video...");
    }
}