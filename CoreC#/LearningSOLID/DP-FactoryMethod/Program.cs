using System;

namespace DP_FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = new PersonFactory();

            var a = f.CreatePerson("John");
            var b = f.CreatePerson("Willie");

            Console.WriteLine(a);
            Console.WriteLine(b);
        }

        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return $"{nameof(Name)}:{Name}, {nameof(Id)}:{Id}";
            }
        }

        public class PersonFactory
        {
            private int _counter = 0;

            public Person CreatePerson(string name)
            {
                return new Person()
                {
                    Name = name,
                    Id = _counter++
                };
            }
        }
    }
}
