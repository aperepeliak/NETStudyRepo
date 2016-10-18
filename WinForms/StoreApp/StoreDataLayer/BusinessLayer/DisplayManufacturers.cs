using StoreDataLayer.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDataLayer.BusinessLayer
{
    public class DisplayManufacturers
    {
        public static List<BusinessManufacturer> GetManufacturers(StoreContext context)
        {
            string queryString = @"SELECT	m.ManufacturerId, m.ManufacturerName
                                   FROM	Manufacturer m";

            var query = context
                .Database
                .SqlQuery<BusinessManufacturer>(queryString);

            return query.ToList();
        }
    }
}
