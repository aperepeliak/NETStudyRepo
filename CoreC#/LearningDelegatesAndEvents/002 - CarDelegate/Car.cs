using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002___CarDelegate
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
        public delegate void CarEngineHandler(string msgForCaller);

        // 2) Define a member variable for this delegate
        private CarEngineHandler listOfHandlers;

        // 3) Add registration function for the caller
        // += --> multicasting support
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers += methodToCall;
        }

        // "Unsubscribe" from a given notification at runtime
        public void UnregisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }

        // 4) Implement the Accelerate() method to invoke the delegate's
        //    invocation list under the correct circumstances
        public void Accelerate(int delta)
        {
            // If this car is "dead" send dead message
            if (carIsDead)
            {
                if (listOfHandlers != null)
                    listOfHandlers("Sorry, this car is dead...");
            } else
            {
                CurrrentSpeed += delta;

                // Is this car "almost dead"?
                if (10 == (MaxSpeed - CurrrentSpeed) && listOfHandlers != null)
                {
                    listOfHandlers("Careful buddy! Gonna blow!");
                }
                if (CurrrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                } else
                {
                    Console.WriteLine($"Current speed = {CurrrentSpeed}");
                }
            }
        }
    }
}
