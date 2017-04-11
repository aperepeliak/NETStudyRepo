using System.Collections.Generic;

namespace Data.AdoNet.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Supplier()
        {
            Products = new List<Product>();
        }
    }
}
