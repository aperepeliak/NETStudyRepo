using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDataLayer.BusinessLayer
{
    public class CartGood
    {
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public decimal Quantity { get; set; }
        public decimal CartPosSum { get; set; }
    }
}
