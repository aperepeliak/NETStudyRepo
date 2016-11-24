using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003___GenericEventHandler
{
    public class Car
    {
        // Internal state data
        public int CurrrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }

        // Is the car alive or dead?
        private bool carIsDead;

        // Ctors
        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            CurrrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        // No more need to define custom delegate type
        // when using generic EventHandler<T> delegate
        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;

        public void Accelerate(int delta)
        {
            // If this car is "dead" send dead message
            if (carIsDead)
            {
                Exploded?.Invoke(this, new CarEventArgs("Sorry, this car is dead..."));
            }
            else
            {
                CurrrentSpeed += delta;

                if (10 == (MaxSpeed - CurrrentSpeed))
                {
                    AboutToBlow?.Invoke(this, new CarEventArgs("Careful buddy! Gonna blow!"));
                }

                // Still OK!
                if (CurrrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                }
                else
                {
                    Console.WriteLine($"Current speed = {CurrrentSpeed}");
                }
            }
        }
    }
}
