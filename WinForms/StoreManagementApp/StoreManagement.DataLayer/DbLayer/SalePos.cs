using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.DataLayer.DbLayer
{
    public class SalePos
    {
        [ForeignKey("Sale")]
        public int SalePosId { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
        public Sale Sale { get; set; }

        public SalePos()
        {
            Goods = new List<Good>();
        }
    }
}
