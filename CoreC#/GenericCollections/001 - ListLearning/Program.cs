using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001___ListLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Learning Generic Collections\n");

            //UseGenericList();

            //UseGenericStack();

            //UseGenericQueue();

            //UseGenericSortedSet();

            UseGenericDictionary();
        }

        static void UseGenericList()
        {
            List<Person> people = new List<Person>()
            {
                new Person () {FirstName = "Andrew", LastName = "Smith", Age = 25 },
                new Person() {FirstName = "Tom", LastName = "Jones", Age = 70 }
            };

            Console.WriteLine($"Items in list: {people.Count}");

            foreach (var p in people)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("\nInserting another person...\n");
            people.Insert(1, new Person() { FirstName = "Vasya", LastName = "Pupkin", Age = 19 });

            Console.WriteLine($"Items in list: {people.Count}");

            foreach (var p in people)
            {
                Console.WriteLine(p);
            }

            // Copy data into a new array
            Person[] arrayOfPeople = people.ToArray();
        }

        static void UseGenericStack()
        {
            Stack<Person> stackOfPeople = new Stack<Person>();

            stackOfPeople.Push(new Person() { FirstName = "Andrew", LastName = "Smith", Age = 25 });
            stackOfPeople.Push(new Person() { FirstName = "Tom", LastName = "Jones", Age = 28 });

            Console.WriteLine($"First person is: {stackOfPeople.Peek()}\n");
            Console.WriteLine($"Popped off {stackOfPeople.Pop()}");
            Console.WriteLine($"First person is: {stackOfPeople.Peek()}\n");
            Console.WriteLine($"Popped off {stackOfPeople.Pop()}");
            try
            {
                Console.WriteLine($"First person is: {stackOfPeople.Peek()}\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void UseGenericQueue()
        {
            Queue<Person> peopleQ = new Queue<Person>();

            peopleQ.Enqueue(new Person() { FirstName = "Andrew", LastName = "Smith", Age = 25 });
            peopleQ.Enqueue(new Person() { FirstName = "Lucy", LastName = "Johnson", Age = 35 });
            peopleQ.Enqueue(new Person() { FirstName = "Vasya", LastName = "Pupkin", Age = 45 });

            Console.WriteLine($"{peopleQ.Peek()} is the first in line");

            GetCoffee(peopleQ.Dequeue());
            Console.WriteLine($"{peopleQ.Peek()} is the first in line");
            GetCoffee(peopleQ.Dequeue());
        }

        static void GetCoffee(Person p)
        {
            Console.WriteLine($"{p.FirstName} got the coffee!");
        }

        static void UseGenericSortedSet()
        {
            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByAge())
            {
                new Person () {FirstName = "Andrew", LastName = "Smith", Age = 25 },
                new Person() {FirstName = "Tom", LastName = "Jones", Age = 70 },
                new Person() {FirstName = "Bill", LastName = "Trump", Age = 36 },
                new Person() {FirstName = "Bill", LastName = "Trump", Age = 36 }
            };

            foreach (var p in setOfPeople)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine(new string('-', 20));

            setOfPeople.Add(new Person() { FirstName = "Kazuhito", LastName = "Yamashita", Age = 42 });
            setOfPeople.Add(new Person() { FirstName = "Vladimir", LastName = "Noskov", Age = 19 });

            foreach (var p in setOfPeople)
            {
                Console.WriteLine(p);
            }
        }

        static void UseGenericDictionary()
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();

            people.Add("Andrew", new Person { FirstName = "Andrew", LastName = "Smith", Age = 25 });
            people.Add("Marge", new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            people.Add("Lisa", new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            // Get Andrew
            Person andrew = people["Andrew"];
            Console.WriteLine(andrew);

            // Populate Dictionary with initialization syntax
            Dictionary<string, Person> test = new Dictionary<string, Person>
            {
                {"Homer", new Person() { FirstName = "Homer", LastName = "Simpson", Age = 47} },
                {"Marge", new Person() { FirstName = "Marge", LastName = "Simpson", Age = 45 } }
            };

            Person marge = test["Marge"];
            Console.WriteLine(marge);
        }
    }
}
