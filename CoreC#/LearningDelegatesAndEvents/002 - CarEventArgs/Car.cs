using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002___CarEventArgs
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

        // 1) Define a delegate type
        public delegate void CarEngineHandler(object sender, CarEventArgs args);

        // This car can send this events
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;

        // 4) Implement the Accelerate() method to invoke the delegate's
        //    invocation list under the correct circumstances
        public void Accelerate(int delta)
        {
            // If this car is "dead" send dead message
            if (carIsDead)
            {
                // Instead of checking an event against null we can leverage 
                // the null conditional operator, which performs the check automatically
                //if (Exploded != null)
                //    Exploded("Sorry, this car is dead...");

                // In this case we must call Invoke() explicitly
                Exploded?.Invoke(this, new CarEventArgs("Sorry, this car is dead..."));
            }
            else
            {
                CurrrentSpeed += delta;

                // Is this car "almost dead"?
                // Without null conditional operator
                //if (10 == (MaxSpeed - CurrrentSpeed) && AboutToBlow != null)
                //{
                //    AboutToBlow("Careful buddy! Gonna blow!");
                //}

                // with null conditional operator
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
