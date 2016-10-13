﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;

namespace DatabaseToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BookContext())
            {
                var query = from store in db.Stores
                            orderby store.Name
                            select store;

                foreach (var s in query)
                {
                    XElement storeElement = new XElement("store",
                        new XAttribute("name", s.Name),
                        new XAttribute("address", s.Address),
                        from stock in s.Stocks
                        select new XElement("stock",
                            new XAttribute("StockID", stock.StockId),
                            new XAttribute("onHand", stock.OnHand),
                            new XAttribute("onOrder", stock.OnOrder),
                        new XElement("book",
                            new XAttribute("title", stock.Book.Title),
                            new XAttribute("author", stock.Book.Author)
                            )
                        )
                    );
                    Console.WriteLine(storeElement);
                }
                Console.WriteLine("Press any key ...");
                Console.ReadKey();
            }
        }
    }
}
