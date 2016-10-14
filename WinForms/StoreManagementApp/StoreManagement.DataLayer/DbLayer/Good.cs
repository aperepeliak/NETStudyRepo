using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.DataLayer.DbLayer
{
    public class Good
    {
        [Key]
        public int GoodId { get; set; }
        public string GoodName { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public virtual Manufacturer Manufacturers { get; set; }
        public virtual Category Categories { get; set; }

        public virtual ICollection<SalesPos> SalesPos { get; set; }

        public Good()
        {
            SalesPos = new List<SalesPos>();
        }
    }
}
