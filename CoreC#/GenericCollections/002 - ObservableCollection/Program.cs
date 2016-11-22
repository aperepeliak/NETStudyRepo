using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace _002___ObservableCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person() {FirstName = "Homer", LastName = "Simpson", Age = 25 },
                new Person() {FirstName = "Marge", LastName = "Simpson", Age = 40 }
            };

            // Wire up the CollectionChanged event
            people.CollectionChanged += People_CollectionChanged;

            people.Add(new Person() { FirstName = "Lisa", LastName = "Simpson", Age = 9 });
            Console.WriteLine(new string('-', 10));
            people.RemoveAt(0);
        }

        private static void People_CollectionChanged(object sender, 
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // What was the action that caused the event?
            Console.WriteLine($"Action for this event: {e.Action}");

            // They removed something
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the old items:");
                foreach (var p in e.OldItems)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }

            // They added something
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Here are the new items:");
                foreach (var p in e.NewItems)
                {
                    Console.WriteLine(p);
                }
            }
        }
    }
}
