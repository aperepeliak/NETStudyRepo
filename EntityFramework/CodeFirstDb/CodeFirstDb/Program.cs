using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace CodeFirstDb
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BookContext())
            {
                Book book1 = new Book { Title = "Beginning C#", Author = "Perkins" };
                db.Books.Add(book1);

                Book book2 = new Book { Title = "LearnJS", Author = "Kantor" };
                db.Books.Add(book2);

                db.SaveChanges();

                var query = from b in db.Books
                            orderby b.Title
                            select b;

                Console.WriteLine("All books in db : ");

                foreach (var b in query)
                {
                    Console.WriteLine($"{b.Title} by {b.Author}, code = {b.Code}");
                }

                Console.ReadKey();
            }
        }
    }
}
