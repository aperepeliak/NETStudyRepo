using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_LazyObjectInstantiation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Lazy Instantiation ****");
            var myPlayer = new MediaPlayer();
            myPlayer.Play();

            var yourPlayer = new MediaPlayer();
            yourPlayer.GetAllTracks();
        }
    }
}
