using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.DataLayer.DbLayer
{
    public class Sale
    {
        [Key]
        public int SalesId { get; set; }

        [ForeignKey("SalesPos")]
        public int SalesPosId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime? SaleDate { get; set; }

        public virtual SalesPos SalesPos { get; set; }
        public virtual User User { get; set; }
    }
}
