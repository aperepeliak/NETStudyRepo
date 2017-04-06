using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DomainLayer.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

        public Supplier()
        {
            Products = new Collection<Product>();
        }
    }
}
