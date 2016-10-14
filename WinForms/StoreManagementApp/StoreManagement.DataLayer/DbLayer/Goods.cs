using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.DataLayer.DbLayer
{
    public class Goods
    {
        [Key]
        public int GoodId { get; set; }
        public string GoodName { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public virtual Manufacturers Manufacturers { get; set; }
        public virtual Categories Categories { get; set; }

        public virtual ICollection<SalesPos> SalesPos { get; set; }

        public Goods()
        {
            SalesPos = new List<SalesPos>();
        }
    }
}
