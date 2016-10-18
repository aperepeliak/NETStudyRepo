using StoreDataLayer.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDataLayer.BusinessLayer
{
    public class DisplayCategory
    {
        public static List<BusinessCategory> GetCategories(StoreContext context)
        {
            string queryString = @"SELECT	c.CategoryId, c.CategoryName
                                   FROM	Category c";

            var query = context
                .Database
                .SqlQuery<BusinessCategory>(queryString);

            return query.ToList();
        }
    }
}
