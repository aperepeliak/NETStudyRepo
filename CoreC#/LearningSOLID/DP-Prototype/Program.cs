using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new Line()
            {
                Start = new Point() { X = 5, Y = 10 },
                End = new Point() { X = 3, Y = 4 }
            };

            Console.WriteLine(l);

            var p = l.DeepCopy();
            p.Start.X = 100;
            Console.WriteLine(p);

        }
    }

    public class Point : IPrototype<Point>
    {
        public int X, Y;

        public Point()
        {
        }

        private Point(Point proto)
        {
            X = proto.X;
            Y = proto.Y;
        }

        public Point DeepCopy()
        {
            return new Point(this);
        }

        public override string ToString()
        {
            return $"[{X}:{Y}]";
        }
    }

    public class Line : IPrototype<Line>
    {
        public Point Start, End;

        public Line()
        {
        }

        private Line(Line proto)
        {
            Start = proto.Start.DeepCopy();
            End = proto.End.DeepCopy();
        }

        public Line DeepCopy()
        {
            return new Line(this);
        }

        public override string ToString()
        {
            return $"Start: {Start} End: {End}";
        }
    }

    public interface IPrototype<T>
    {
        T DeepCopy();
    }
}
