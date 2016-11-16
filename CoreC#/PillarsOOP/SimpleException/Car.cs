using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleException
{
    class Car
    {
        public const int MaxSpeed = 100;

        public int CurrSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";

        // Is the car still operational
        private bool carIsDead;

        private Radio theMusicBox = new Radio();

        // Constructors
        public Car() { }
        public Car(string name, int speed)
        {
            CurrSpeed = speed;
            PetName = name;
        }

        public void CrankTunes(bool state)
        {
            // Delegate request to inner object
            theMusicBox.TurnOn(state);
        }

        // See if car has overheated
        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                Console.WriteLine($"{PetName} is out of order.");
            }
            else
            {
                CurrSpeed += delta;
                if (CurrSpeed > MaxSpeed)
                {
                    Console.WriteLine($"{PetName} has overheated.");
                    CurrSpeed = 0;
                    carIsDead = true;
                    Exception ex = new Exception(string.Format("{0} has overheated!", PetName));
                    ex.HelpLink = "https://google.com";

                    ex.Data.Add("Timestamp", string.Format("The car exploded at: {0}", DateTime.Now));
                    ex.Data.Add("Cause", "You have a lead foot.");
                    throw ex;
                    
                }
                else
                {
                    Console.WriteLine($" => Current speed = {CurrSpeed}");
                }
            }
        }
    }
}
