using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.DataLayer.DbLayer
{
    public class SalesPos
    {
        [Key]
        public int SalesPosId { get; set; }
        public virtual ICollection<Goods> Goods { get; set; }

        public virtual Sales Sales { get; set; }

        public SalesPos()
        {
            Goods = new List<Goods>();
        }
    }
}
