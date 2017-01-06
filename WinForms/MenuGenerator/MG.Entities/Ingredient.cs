using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Entities
{
    [Serializable]
    public class Ingredient
    {
        public string Name { get; set; }
        public Unit Units { get; set; }
    }
}
