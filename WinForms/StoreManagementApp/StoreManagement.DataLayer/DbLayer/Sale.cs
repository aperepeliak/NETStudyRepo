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
        public int SaleId { get; set; }

        public int SalePosId { get; set; }

        //[ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime SaleDate { get; set; }

        public  SalePos SalePos { get; set; }
        public virtual User User { get; set; }
    }
}
