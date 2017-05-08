using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExploringStopwatch();

            ExploringPosts();
        }

        private static void ExploringPosts()
        {
            var post = new Post();
            Console.WriteLine("Post created: " + post.DateTimeCreated.ToString("dd-MM-yyyy"));

            post.UpVote();
            post.UpVote();
            post.UpVote();
            post.DownVote();

            Console.WriteLine("Current vote: " + post.Vote);
        }

        private static void ExploringStopwatch()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("Stopwatch is running.\nClick enter to stop it.");
            Console.ReadLine();
            stopwatch.Stop();

            Console.WriteLine($"Duration: {stopwatch.Duration.ToString(@"mm\:ss")}");
        }
    }
}
