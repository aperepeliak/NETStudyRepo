using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneablePoint
{
    class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PointDescription desc = new PointDescription();

        public Point(int x, int y, string petName) : this(x, y) { desc.PetName = petName; }
        public Point(int x, int y) { X = x; Y = y; }
        public Point() { }

        public override string ToString()
        {
            return string.Format("X = {0}, Y = {1} Name = {2} \nID = {3}\n",
                X, Y, desc.PetName, desc.PointID);
        }


        //public object Clone()
        //{
        //    return new Point(this.X, this.Y);
        //}

        // If class does not contain any internal reference type vars,
        // the implementation of Clone() can be simplified:
        //public object Clone()
        //{
        //    // Copy each field of the Point member by member
        //    return this.MemberwiseClone();
        //}

        // A complete deep copy of internal reference types
        public object Clone()
        {
            // First get a shallow copy
            Point newPoint = (Point)this.MemberwiseClone();

            // Then fill in the gaps
            PointDescription currDesc = new PointDescription();

            currDesc.PetName = this.desc.PetName;
            newPoint.desc = currDesc;
            return newPoint;
        }
    }
}
