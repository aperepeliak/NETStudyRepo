using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun with object members\n\n");
            Person p1 = new Person("Homer", "Simpson", 50);
            Person p2 = new Person("Homer", "Simpson", 50);

            Console.WriteLine($"p1.ToString() = {p1.ToString()}");
            Console.WriteLine($"p2.ToString() = {p2.ToString()}");

            // Test overridden Equals()
            Console.WriteLine($"p1 = p2?: {p1.Equals(p2)}");

            // Test hash codes
            Console.WriteLine($"Same hash codes?: {p1.GetHashCode() == p2.GetHashCode()}");
            Console.WriteLine();

            p2.Age = 42;
            Console.WriteLine($"p1.ToString() = {p1.ToString()}");
            Console.WriteLine($"p2.ToString() = {p2.ToString()}");
            Console.WriteLine($"p1 = p2?: {p1.Equals(p2)}");
            Console.WriteLine($"Same hash codes?: {p1.GetHashCode() == p2.GetHashCode()}");
            Console.WriteLine();

            // Static members of System.Object
            Person p3 = new Person("Vasya", "Pupkin", 32);
            Person p4 = new Person("Vasya", "Pupkin", 32);

            Console.WriteLine($"P3 and P4 have same state: {object.Equals(p3, p4)}");
            Console.WriteLine($"P3 and P4 are pointing to the same object: {object.ReferenceEquals(p3, p4)}");
        }
    }
}
