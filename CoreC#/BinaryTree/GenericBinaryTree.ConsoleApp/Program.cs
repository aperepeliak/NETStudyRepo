using GenericBinaryTree.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBinaryTree.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int>(50);

            // tree.ElementAdded += (data) => Console.WriteLine($"Added: {data}");

            tree.AddRange(new int[] { 10, 28, 1, 3, 70 });

            foreach (var item in tree.Iterate(TraverseMethod.inOrder))
            {
                Console.WriteLine(item);
            }

            var studs = new BinaryTree<Student>(new Student()
            {
                FirstName = "Vasya",
                LastName = "Pupkin",
                Grade = 75
            });

            studs.AddRange(new Student[]
            {
                new Student() { FirstName = "Denis", LastName = "Petrov", Grade = 98},
                new Student() { FirstName = "Petr", LastName = "Ivanov", Grade = 80 },
                new Student() { FirstName = "Joe", LastName = "Dow", Grade = 87 }
            });

            foreach (var stud in studs)
            {
                Console.WriteLine(stud);
            }
        }
    }

    class Student : IComparable<Student>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }

        public int CompareTo(Student other) => Grade.CompareTo(other.Grade);
        public override string ToString() => $"{FirstName} {LastName} : {Grade}";
    }
}
