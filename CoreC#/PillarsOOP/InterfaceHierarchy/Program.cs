using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            BitmapImage myBitmap = new BitmapImage();

            myBitmap.Draw();
            myBitmap.DrawInBoundingBox(1,2,3,4);
            myBitmap.DrawUpsideDown();

            // Get IAdvancedDraw explicitly
            IAdvancedDraw adv = myBitmap as IAdvancedDraw;
            if (adv != null)
                adv.DrawUpsideDown();
        }
    }

    public interface IDrawable
    {
        void Draw();
    }

    public interface IAdvancedDraw : IDrawable
    {
        void DrawInBoundingBox(int top, int left, int bottom, int right);
        void DrawUpsideDown();
    }

    public class BitmapImage : IAdvancedDraw
    {
        public void Draw()
        {
            Console.WriteLine("Drawing...");
        }

        public void DrawInBoundingBox(int top, int left, int bottom, int right)
        {
            Console.WriteLine("Drawing in a box...");
        }

        public void DrawUpsideDown()
        {
            Console.WriteLine("Drawing upside down...");
        }
    }
}
