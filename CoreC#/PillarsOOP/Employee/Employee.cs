using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Employee
    {
        // Field data
        private string empName;
        private int empID;
        private float currPay;
        private int empAge;

        // Properties
        public string Name
        {
            get { return empName; }
            set
            {
                if (value.Length > 15)
                    Console.WriteLine("Error!");
                else
                    empName = value;
            }
        }

        public int ID { get; set; }
        public float Pay { get; set; }
        public int Age { get; set; }


        // Constructors
        public Employee() { }
        public Employee(string name, int id, float pay)
        : this(name, 0, id, pay) { }
        public Employee(string name, int age, int id, float pay)
        {
            Name = name;
            Age = age;
            ID = id;
            Pay = pay;
        }

        // Methods
        public void GiveBonus(float amount)
        {
            currPay += amount;
        }

        public void DisplayStats()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Pay: {Pay}");
        }
    }
}
