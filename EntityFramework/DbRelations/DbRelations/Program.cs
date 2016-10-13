using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace DbRelations
{
    public class Book
    {
        [Key]
        public int Code { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }

    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual List<Stock> Inventory { get; set; }
    }

    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        public int OnHand { get; set; }
        public int OnOrder { get; set; }
        public virtual Book Item { get; set; }
    }

    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }



    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BookContext())
            {
                Book book1 = new Book
                {
                    Title = "Beginning C#",
                    Author = "Perkins"
                };
                db.Books.Add(book1);

                Book book2 = new Book { Title = "LearnJS", Author = "Kantor" };
                db.Books.Add(book2);

                var store1 = new Store { Name = "Main St Books", Address = "123 Main St", Inventory = new List<Stock>() };
                db.Stores.Add(store1);

                Stock store1book1 = new Stock { Item = book1, OnHand = 4, OnOrder = 6 };
                store1.Inventory.Add(store1book1);

                Stock store1book2 = new Stock { Item = book2, OnHand = 2, OnOrder = 10 };
                store1.Inventory.Add(store1book2);

                var store2 = new Store { Name = "Campus Books", Address = "321 Avenue", Inventory = new List<Stock>() };
                db.Stores.Add(store2);

                Stock store2book1 = new Stock { Item = book1, OnHand = 9, OnOrder = 7 };
                store2.Inventory.Add(store2book1);

                Stock store2book2 = new Stock { Item = book2, OnHand = 15, OnOrder = 1 };
                store2.Inventory.Add(store2book2);

                db.SaveChanges();

                var query = from store in db.Stores
                            orderby store.Name
                            select store;

                Console.WriteLine("Bookstore Inventory Report:");
                foreach (var store in query)
                {
                    Console.WriteLine($"{store.Name} located at {store.Address}");
                    foreach (var stock in store.Inventory)
                    {
                        Console.WriteLine($"\t- Title: {stock.Item.Title}");
                        Console.WriteLine($"\t\t-- Copies in Store: {stock.OnHand}");
                        Console.WriteLine($"\t\t-- Copies on Order: {stock.OnOrder}");
                    }
                }
            }

            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }
    }
}
