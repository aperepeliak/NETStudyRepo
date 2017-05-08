using System;

namespace _001_Classes
{
    public class Post
    {
        public string   Title           { get; set; }
        public string   Description     { get; set; }
        public int      Vote            { get; private set; }

        public DateTime DateTimeCreated => DateTime.Now;

        public void UpVote() => Vote++;
        public void DownVote() => Vote--;
    }
}
