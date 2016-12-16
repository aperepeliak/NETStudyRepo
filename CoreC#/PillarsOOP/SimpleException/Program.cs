﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleException
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Exception example");

            Console.WriteLine(" => creating a car and stepping on it!");
            Car myCar = new Car("Zippy", 20);
            myCar.CrankTunes(true);

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    myCar.Accelerate(10);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n Error!");
                Console.WriteLine("Member name: {0}", e.TargetSite);

                Console.WriteLine("Class defining member: {0}", e.TargetSite.DeclaringType);
                Console.WriteLine("Member type: {0}", e.TargetSite.MemberType);

                Console.WriteLine("Message: {0}", e.Message);
                Console.WriteLine("Source: {0}", e.Source);

                Console.WriteLine("\n-> Custom Data:");
                foreach (DictionaryEntry de in e.Data)
                {
                    Console.WriteLine("-> {0} : {1}", de.Key, de.Value);
                }

                Console.WriteLine("More details: {0}", e.HelpLink);

                //Console.WriteLine("Stack: {0}", e.StackTrace);
            }
            
        }
    }
}