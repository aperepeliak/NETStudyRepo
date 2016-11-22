using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004___CustomGenericStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generic Structures\n");

            Point<int> p = new Point<int>(10, 10);
            Console.WriteLine($"p: {p}");

            p.ResetPoint();
            Console.WriteLine($"p: {p}");

            Point<double> p2 = new Point<double>(2.54, 3.7);
            Console.WriteLine($"p2: {p2}");
            
        }

        public struct Point<T>
        {
            private T xPos;
            private T yPos;

            //Generic ctor
            public Point(T xVal, T yVal)
            {
                this.xPos = xVal;
                this.yPos = xVal;
            }

            public T X
            {
                get { return xPos; }
                set { xPos = value; }
            }

            public T Y
            {
                get { return yPos; }
                set { yPos = value; }
            }

            public override string ToString()
            {
                return string.Format($"[{xPos}, {yPos}]");
            }

            public void ResetPoint()
            {
                xPos = default(T);
                yPos = default(T);
            }
        }
    }
}
