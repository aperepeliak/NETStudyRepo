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
        public string Units { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Ingredient && obj != null)
            {
                var temp = (Ingredient)obj;
                if (temp.Name == this.Name)
                {
                    return true;
                }
                else return false;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Units}";
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
