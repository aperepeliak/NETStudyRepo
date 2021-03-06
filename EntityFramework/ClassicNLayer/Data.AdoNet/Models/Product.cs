﻿namespace Data.AdoNet.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        public decimal Price { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
