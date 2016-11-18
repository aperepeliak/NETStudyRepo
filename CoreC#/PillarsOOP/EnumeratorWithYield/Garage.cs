using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorWithYield
{
    public class Garage : IEnumerable
    {
        private Car[] carArray = new Car[4];

        public Garage()
        {
            carArray[0] = new Car("Rusty", 50);
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Daisy", 23);
            carArray[3] = new Car("Philly", 45);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Car c in carArray)
            {
                yield return c;
            }
        }

        public IEnumerable GetTheCars(bool returnReversed)
        {
            // Return the item in reverse
            if (returnReversed)
            {
                for (int i = carArray.Length; i != 0; i--)
                {
                    yield return carArray[i - 1];
                }
            } else
            {
                // Return the items as placed in the array
                foreach(Car c in carArray)
                {
                    yield return c;
                }
            }
        }
    }
}
