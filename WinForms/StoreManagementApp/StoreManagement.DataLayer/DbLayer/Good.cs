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

        //[ForeignKey("ManufacturerId")]
        public int ManufacturerId { get; set; }

        //[ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<SalePos> SalePos { get; set; }

        public Good()
        {
            SalePos = new List<SalePos>();
        }
    }
}
