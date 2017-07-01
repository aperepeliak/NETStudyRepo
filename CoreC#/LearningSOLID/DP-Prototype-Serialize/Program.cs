using System;
using System.IO;
using System.Xml.Serialization;

namespace DP_Prototype_Serialize
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

    public class Point
    {
        public int X, Y;

        public override string ToString()
        {
            return $"[{X}:{Y}]";
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            return this.DeepClone();
        }

        public override string ToString()
        {
            return $"Start: {Start} End: {End}";
        }
    }

    public static class PrototypeExtensions
    {
        public static T DeepClone<T>(this T self)
        {
            using (var memoryStream = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(memoryStream, self);
                memoryStream.Position = 0;
                return (T)s.Deserialize(memoryStream);
            }
        }
    }
}
