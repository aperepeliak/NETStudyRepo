using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Entities
{
    [Serializable]
    public class IngredientInfo
    {
        public int Id { get; set; }
        public Ingredient Ingredient { get; set; }
        public double Amount { get; set; }
    }
}
