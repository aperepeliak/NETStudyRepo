using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDataLayer.BusinessLayer
{
    public class BusinessSale
    {
        public int SaleId { get; set; }
        public string SaleNumber { get; set; }
        public string CashierName { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SaleAmount { get; set; }
    }
}
