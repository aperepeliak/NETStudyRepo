﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefTypeValTypeParams
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Passing Person object by value");
            Person fred = new Person("Fred", 12);

            Console.WriteLine("\nBefore by value call: ");
            fred.Display();

            SendAPersonByValue(fred);

            Console.WriteLine("\nAfter the call: ");
            fred.Display();
        }

        static void SendAPersonByValue(Person p)
        {
            p.personAge = 99;
            p = new Person("Nikki", 99);
        }
    }

    class Person
    {
        public string personName;
        public int personAge;

        public Person(string name, int age)
        {
            personName = name;
            personAge = age;
        }

        public Person()
        {

        }

        public void Display()
        {
            Console.WriteLine($"Name: {personName}, Age: {personAge}");
        }
    }
}
