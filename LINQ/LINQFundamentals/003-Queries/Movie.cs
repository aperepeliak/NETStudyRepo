using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_Queries
{
    public class Movie
    {
        public string Title { get; set; }
        public float Rating { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return string.Format($"{Title,-20} | {Year,5} | {Rating,5:N1}");
        }
    }
}
