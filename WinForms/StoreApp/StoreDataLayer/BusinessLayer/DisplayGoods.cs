using StoreDataLayer.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDataLayer.BusinessLayer
{
    public class DisplayGoods
    {
        public static List<BusinessGood> GetGoods(StoreContext context)
        {
            string queryString = @"SELECT     g.GoodId, g.GoodName, m.ManufacturerName,
                                              c.CategoryName, g.Price, g.Stock
                                    FROM      dbo.Good g LEFT JOIN dbo.Manufacturer m ON (g.ManufacturerId = m.ManufacturerId)
                                              LEFT JOIN dbo.Category c ON (g.CategoryId = c.CategoryId)";

            var query = context
                .Database
                .SqlQuery<BusinessGood>(queryString);

            return query.ToList();
        }
    }
}
