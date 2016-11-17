using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class ThreeDCircle : Circle, IDraw3D
    { 
        // Ignoring base class member
        public new string PetName { get; set; }

        public new void Draw()
        {
            Console.WriteLine(" -> Drawing a 3D CIRCLE");
        }

        public void Draw3D()
        {
            Console.WriteLine("Drawing circle in 3D");
        }
    }
}
