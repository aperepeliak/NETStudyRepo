using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_ClassesObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook();

            // Example of different notations
            book.NameChanged += new NameChangedDelegate(OnNameChanged);
            book.NameChanged += OnNameChanged2;

            // with events we cannot assign or reassign, we can only subscribe(+=) or unsubscribe(-=)
            // but we can do so with delegates, that's why events are preferable
            // book.NameChanged = new NameChangedDelegate(OnNameChanged3);

            book.Name = "My book";

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
        }

        static void WriteResult(string desc, int result)
        {
            Console.WriteLine(desc + ": " + result);
        }

        static void WriteResult(string desc, float result)
        {
            Console.WriteLine(desc + ": " + result);
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }

        static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"***");
        }
    }
}
