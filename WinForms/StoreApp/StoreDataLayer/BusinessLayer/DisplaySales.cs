using StoreDataLayer.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDataLayer.BusinessLayer
{
    public class DisplaySales
    {
        public static List<BusinessSale> GetSales(StoreContext context)
        {
            var query = from s in context.Sales
                         join u in context.UserProfiles on s.UserId equals u.UserId
                         select new BusinessSale
                         {
                             SaleId = s.SaleId,
                             SaleNumber = s.SaleNumber,
                             CashierName = u.UserFirstName + " " + u.UserLastName,
                             SaleDate = s.SaleDate,
                             SaleAmount = s.SaleAmount
                         };

            return query.ToList();
        }
    }
}
