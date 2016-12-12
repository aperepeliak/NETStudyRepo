using System;

namespace _003_LazyObjectInstantiation
{
    class AllTracks
    {
        private Song[] allSongs = new Song[1000];

        public AllTracks()
        {
            Console.WriteLine("Filling up the songs!");
        }
    }
}
