using ShopDataLayer.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDataLayer.BusinessLayer
{
    public class GoodsRepresentation
    {
        public static List<GoodForDisplay> GetGoodForDisplay(ShopContext context)
        {
            string queryString = @"SELECT     g.GoodId, g.GoodName, m.ManufacturerName,
                                        c.CategoryName, g.Price, g.GoodCount
                             FROM       dbo.Good g LEFT JOIN dbo.Manufacturer m ON (g.ManufacturerId = m.ManufacturerId)
                                        LEFT JOIN dbo.Category c ON (g.CategoryId = c.CategoryId)";

            var query = context
                .Database
                .SqlQuery<GoodForDisplay>(queryString);

            return query.ToList();
        }
    }
}
