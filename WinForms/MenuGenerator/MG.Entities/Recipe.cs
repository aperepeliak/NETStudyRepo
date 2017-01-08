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
        public string Name { get; set; }
        public List<IngredientInfo> Ingredients { get; set; }
        public string Seasonality { get; set; }
        public string Category { get; set; }
    }
}
