using StoreDataLayer.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDataLayer.BusinessLayer
{
    public class DisplaySalePos
    {
        public static List<BusinessSalePos> GetSalePos(StoreContext context, int saleId)
        {
            var query = from s in context.SalePos
                        join g in context.Goods on s.GoodId equals g.GoodId
                        where s.SaleId == saleId
                        select new BusinessSalePos
                        {
                            GoodName = g.GoodName,
                            Quantity = s.Quantity,
                            TotalSum = s.SalePosSum
                        };

            return query.ToList();
        }
    }
}
