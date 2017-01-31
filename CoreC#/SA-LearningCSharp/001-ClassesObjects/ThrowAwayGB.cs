using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_ClassesObjects
{
    public class ThrowAwayGB : GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("ThrowAwayGradeBook::ComputeStats");
            float lowest = float.MaxValue;

            foreach (float grade in grades)
            {
                lowest = Math.Min(lowest, grade);
            }

            grades.Remove(lowest);

            return base.ComputeStatistics();
        }
    }
}
