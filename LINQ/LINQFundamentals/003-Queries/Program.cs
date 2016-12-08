using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = MyLinq.Random()
                .Where(n => n > 0.5)
                .Take(10);

            foreach (var number in numbers)
            {
                Console.WriteLine($"number: {number, 0:N2}");
            }
            
            var movies = new List<Movie>
            {
                new Movie {Title = "The Dark Knight", Rating = 8.9f, Year = 2008 },
                new Movie {Title = "The King's Speech", Rating = 8.0f, Year = 2010 },
                new Movie {Title = "Casablanca", Rating = 8.5f, Year = 1942 },
                new Movie {Title = "Star Wars V", Rating = 8.7f, Year = 1980 }
            };

            var query = movies.Where(m => m.Year > 2000);

            // My implementation of filter (the same as Where above)
            //var query2 = movies.Filter(m => m.Year > 2000);

            foreach (var movie in query)
                Console.WriteLine(movie.ToString());

        }
    }
}
