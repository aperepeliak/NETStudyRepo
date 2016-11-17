using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class Hexagon : Shape, IPointy, IDraw3D
    {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }

        public override void Draw()
        {
            Console.WriteLine($"Drawing {PetName} the Hexagon");
        }

        public void Draw3D()
        {
            Console.WriteLine(" -> Drawing hexagon in 3D");
        }

        public byte Points
        {
            get { return 6; }
        }
    }
}
