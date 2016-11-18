using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
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
            // Return the array of object's IEnumerator
            return carArray.GetEnumerator();
        }
    }
}
