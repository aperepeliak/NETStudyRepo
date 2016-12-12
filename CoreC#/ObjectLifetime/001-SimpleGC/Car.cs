using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_SimpleGC
{
    public class Car
    {
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }

        public Car(string name = default(string), int speed = default(int))
        {
            PetName = name;
            CurrentSpeed = speed;
        }

        public override string ToString()
        {
            return string.Format($"{PetName} is going {CurrentSpeed} MPH");
        }
    }
}
