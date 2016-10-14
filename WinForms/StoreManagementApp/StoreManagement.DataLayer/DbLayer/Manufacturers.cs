using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace StoreManagement.DataLayer.DbLayer
{
    public class Manufacturers
    {
        [Key]
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }

        public virtual Goods Goods { get; set; }
    }
}
