using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Entities
{
    [Serializable]
    public class Recipe
    {    
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IngridientInfo> Ingridients { get; set; }
        public Season Seasonality { get; set; }
        public Category DishCategory { get; set; }
    }
}
