using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace StoreManagement.DataLayer.DbLayer
{
    public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }

        public string ManufacturerName { get; set; }

        public virtual ICollection<Good> Goods { get; set; }

        public Manufacturer()
        {
            Goods = new List<Good>();
        }
    }
}
